using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using VisorFacturas.Clases;
using System.Data.OleDb;
using VisorFacturas.Properties;
using VisorFacturas.ni.gob.bcn.servicios;
using System.Xml.Serialization;
using VisorFacturas.Util;
using System.IO;
using VisorFacturas.Enums;
using System.Globalization;

namespace VisorFacturas.Forms
{
    public partial class frmSistInfCNZF : DevExpress.XtraEditors.XtraForm
    {
        // Usuario del sistema
        tblUser moCurrentUser;
        string mocadenaconexOLEDB;
        //DataAdapters
        OleDbDataAdapter adapter;

        //Commands
        OleDbCommand command;
        public frmSistInfCNZF(tblUser paCurrentUser)
        {
            InitializeComponent();
            this.moCurrentUser = paCurrentUser;
        }

        #region VARIABLES GLOBALES  
        // Variables globales
        string aoNombreReporte;
        string aoCodReporte;
        short aoidximage;
        DevExpress.XtraLayout.Utils.LayoutVisibility aoAlways = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        DevExpress.XtraLayout.Utils.LayoutVisibility aoNever = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        DateTime aoFecha2000 = new DateTime(2000, 1, 1);
        List<viewClientes> aoclientes_lst;
        String sqlClientes_TODOS = "";

        // Variables de Filtros - Parametros
        short aofiltro_mes_entero;
        string aofiltro_mes_cadena;
        short aofiltro_anyo_entero;
        DateTime aofiltro_mesyearini;
        DateTime aofiltro_mesyearfin;
        String aofiltro_codcliente;

        // Variables de Filtros - Indicadores
        bool aofiltroind_pagosfechaact;
        bool aofiltroind_CtaAuditoria;
        bool aofiltroind_SoloCliIndustr;
        bool aofiltroind_PgoOrg;
        bool aofiltroind_comparamesyearANT;
        bool aofiltroind_solofactpendientes;

        // Otras variables
        String aosql_clientes_gle = "";
        DataTable acDT_temp;
        DataTable acDT_temp_02;

        string Str_Ruta = "";
        #endregion

        #region EVENTOS

        private void frmSistInfCNZF_Load(object sender, EventArgs e)
        {
            // Poblamos el TreeList
            mtree_bndsrc.DataSource = clsTreeListSistInf.mfxGetTreeList(moCurrentUser);
            mtree_sistinf.ExpandAll();

            //Cargamos los permisos del usuario en la pantalla
            //mpxCargarPermisosUsuario();

            mpxInitControls();

            mpxFillLoadDta();

        }
        /// <summary>
        /// Cargamos los permisos del usuario en la pantalla
        /// </summary>
        //private void mpxCargarPermisosUsuario()
        //{
            
        //}

        private void mtree_sistinf_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                aoCodReporte = e.Node["fldcodrep"].ToString();
                aoNombreReporte = e.Node["fldnamrep"].ToString();
                aoidximage = Convert.ToInt16(e.Node["fldimageidx"].ToString());

                if (aoidximage != 0)
                {
                    mpxShowControls(aoCodReporte);
                    mbtn_imprimir.Enabled = true;
                }
                else
                {
                    mpxHideControls();
                    mbtn_imprimir.Enabled = false;
                }
            }
        }

        private void mbtn_imprimir_Click(object sender, EventArgs e)
        {
            mpxImprimir();
        }

        private void mbtn_salir_Click(object sender, EventArgs e)
        {
            mpxSalir();
        }

        private void mgle_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            (sender as GridLookUpEdit).Properties.View.ClearColumnsFilter();
        }

        private void mrdg_Param_cli_buscarpor_EditValueChanged(object sender, EventArgs e)
        {
            RadioGroup aosender = sender as RadioGroup;
            if (aosender != null)
            {
                if (Convert.ToInt16(aosender.EditValue) == 1)
                {
                    mlytitm_Param_cliente.Visibility = aoAlways;
                    mlytitm_Param_codcliente.Visibility = aoNever;
                }
                else
                {
                    mlytitm_Param_cliente.Visibility = aoNever;
                    mlytitm_Param_codcliente.Visibility = aoAlways;
                }
            }
        }

        private void mdte_mesyearinifin_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void mdte_mesyearinifin_Validated(object sender, EventArgs e)
        {
            DateEdit aosender = sender as DateEdit;
            if (aosender != null)
            {
                if (aosender.Tag.ToString() == "mvxmesyear_ini")
                {
                    // Si la fecha Inicial pasa a ser mayor que la final
                    if (aosender.DateTime.Date > mdte_Param_mesyearfin.DateTime.Date)
                    {
                        mdte_Param_mesyearfin.DateTime = aosender.DateTime;
                    }
                }
                else if (aosender.Tag.ToString() == "mvxmesyear_fin")
                {
                    // Si la fecha Final pasa a ser menor que la inicial
                    if (aosender.DateTime.Date < mdte_Param_mesyearini.DateTime.Date)
                    {
                        mdte_Param_mesyearini.DateTime = aosender.DateTime;
                    }
                }
            }
        }

        #endregion

        #region METODOS Y FUNCIONES

        private void mpxInitControls()
        {
            // Valores por defecto
            speAnno.Value = DateTime.Now.Year;
            cmbMes.SelectedIndex = DateTime.Now.Month - 1;
            mdte_Param_mesyearini.DateTime = new DateTime(DateTime.Now.Year, 1, 1);
            mdte_Param_mesyearfin.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);
            mrdg_Param_cli_buscarpor.EditValue = 1;
            mrdg_Param_cli_buscarpor.SelectedIndex = 0;
            mrdg_Param_cli_mon.EditValue = 1;
            mrdg_Param_cli_mon.SelectedIndex = 0;

            mlcg_Params.ExpandButtonVisible = false;
            mlcg_indicadores.ExpandButtonVisible = false;

            mlcg_Params.Expanded = true;
            mlcg_indicadores.Expanded = true;

            // Gridlookupedit Clientes
            mgle_Param_cliente_grv.RowHeight = 25;
        }

        private void mpxFillLoadDta()
        {
            acDT_temp = new DataTable();
            Str_Ruta = Settings.Default.mCnxCNZF_TablasCXC;
            //Cargamos los clientes
            if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
            {
                aosql_clientes_gle = "Select cli_cod, cli_nom from CLIENTE";
                sqlClientes_TODOS = "SELECT cli_cod, cli_nom, 'Usuaria' as 'tipo_reg' FROM CLIENTE";
                Str_Ruta = Settings.Default.mCnxCZF_TablasCXC;

                mlytitm_Param_cliente.Text = "Cliente CZF:";
            }
            else
            {
                aosql_clientes_gle = "Select cli_cod, cli_nom from CLIENTE WHERE tip_regime > 0";
                sqlClientes_TODOS = "SELECT cli_cod, cli_nom, UPPER(cli_regime) as 'tipo_reg' FROM CLIENTE";
                Str_Ruta = Settings.Default.mCnxCNZF_TablasCXC;
                mlytitm_Param_cliente.Text = "Cliente CNZF:";
            }

            using (OleDbDataAdapter adapt = new OleDbDataAdapter(aosql_clientes_gle, Str_Ruta))
            {
                adapt.Fill(acDT_temp);
            }

            // Cargamos los clientes para el GRID LOOKUPEDIT
            List<viewClientes> aoclientes_lstgle = new List<viewClientes>();            
            foreach (DataRow item in acDT_temp.Rows)
            {
                aoclientes_lstgle.Add(new viewClientes()
                {
                    cli_cod = item["cli_cod"].ToString(),
                    cli_nom = item["cli_nom"].ToString()
                });
            }

            mclientes_bndsrc.DataSource = aoclientes_lstgle.OrderBy(x => x.cli_nom).ToList();

            // Cargamos un listado general de todos los clientes
            acDT_temp = new DataTable();
            aoclientes_lst = new List<viewClientes>();
            using (OleDbDataAdapter adapt = new OleDbDataAdapter(sqlClientes_TODOS, Str_Ruta))
            {
                adapt.Fill(acDT_temp);
            }

            acDT_temp.AsEnumerable().ToList().ForEach(s => aoclientes_lst.Add(new viewClientes()
            {
                cli_cod = s["cli_cod"].ToString(),
                cli_nom = s["cli_nom"].ToString(),
                cli_regimen = s["tipo_reg"].ToString(),
            }));
        }

        private void mpxSalir()
        {
            this.Close();
            this.Dispose();
        }

        /// <summary>
        /// Oculta todos los controles filtros
        /// </summary>
        private void mpxHideControls()
        {
            mlytitm_speanno.Visibility = aoNever;
            mempty_speanno.Visibility = aoNever;
            mlytitm_cmbMes.Visibility = aoNever;
            mempty_cmbmes.Visibility = aoNever;
            mlytitm_Param_cli_mon.Visibility = aoNever;
            mlytitm_Param_mesyearini.Visibility = aoNever;
            mlytitm_Param_mesyearfin.Visibility = aoNever;
            //mlytitm_Param_cliente.Visibility = aoNever;
            mlcg_cliente.Visibility = aoNever;
            mlcg_Params.Visibility = aoNever;

            mlytitm_pagosfechaactual.Visibility = aoNever;
            mlytitm_CtaAuditoria.Visibility = aoNever;
            mlytitm_SoloCliIndustr.Visibility = aoNever;
            mlytitm_comparamesanyoant.Visibility = aoNever;
            mlytitm_solofactpendientes.Visibility = aoNever;
            mlcg_indicadores.Visibility = aoNever;

            // Ocultamos el Grupo filtro y el espacio en blanco a la derecha
            mlcg_filtros.Visibility = aoNever;
            mempty_filtros.Visibility = aoNever;
        }

        /// <summary>
        /// Muestra los controles filtros, dependiendo de que reporte haya seleccionado
        /// </summary>
        /// <param name="paReportCod"></param>
        private void mpxShowControls(string paReportCod)
        {
            mpxHideControls();

            switch (paReportCod)
            {
                case "RPT101":
                    // Listado de Facturas Mensual
                    mlytitm_speanno.Visibility = aoAlways;
                    mempty_speanno.Visibility = aoAlways;
                    mlytitm_cmbMes.Visibility = aoAlways;
                    mempty_cmbmes.Visibility = aoAlways;
                    mlcg_Params.Visibility = aoAlways;

                    mlytitm_pagosfechaactual.Visibility = aoAlways;
                    mlytitm_CtaAuditoria.Visibility = aoAlways;
                    mlytitm_SoloCliIndustr.Visibility = aoAlways;
                    mlcg_indicadores.Visibility = aoAlways;
                    break;

                case "RPT102":
                    // Metraje Anual de Clientes
                    mlytitm_speanno.Visibility = aoAlways;
                    mempty_speanno.Visibility = aoAlways;
                    mlcg_Params.Visibility = aoAlways;
                    break;

                case "RPT103":
                    // Comparación de Facturas por Mes
                    mlytitm_speanno.Visibility = aoAlways;
                    mempty_speanno.Visibility = aoAlways;
                    mlytitm_cmbMes.Visibility = aoAlways;
                    mempty_cmbmes.Visibility = aoAlways;
                    mlcg_Params.Visibility = aoAlways;

                    mlytitm_comparamesanyoant.Visibility = aoAlways;
                    mlcg_indicadores.Visibility = aoAlways;
                    break;

                case "RPT104":
                    // Saldo de Clientes
                    //mlytitm_Param_mesyearini.Visibility = aoAlways;
                    mlytitm_Param_mesyearfin.Visibility = aoAlways;
                    mlcg_Params.Visibility = aoAlways;

                    mlytitm_pagosfechaactual.Visibility = aoAlways;
                    mlcg_indicadores.Visibility = aoAlways;
                    break;

                case "RPT105":
                    // Saldo de Clientes detallado
                    mlytitm_Param_mesyearini.Visibility = aoAlways;
                    mlytitm_Param_mesyearfin.Visibility = aoAlways;
                    //mlytitm_Param_cliente.Visibility = aoAlways;
                    mlcg_cliente.Visibility = aoAlways;
                    mlcg_Params.Visibility = aoAlways;

                    mlytitm_solofactpendientes.Visibility = aoAlways;
                    mlytitm_pagosfechaactual.Visibility = aoAlways;
                    mlcg_indicadores.Visibility = aoAlways;
                    break;
                case "RPT501":
                    // Saldo de Clientes detallado
                    mlytitm_Param_mesyearini.Visibility = aoAlways;
                    mlytitm_Param_mesyearfin.Visibility = aoAlways;
                    //mlytitm_Param_cliente.Visibility = aoAlways;
                    mlcg_cliente.Visibility = aoAlways;
                    mlcg_Params.Visibility = aoAlways;

                    mlytitm_solofactpendientes.Visibility = aoAlways;
                    mlytitm_pagosfechaactual.Visibility = aoAlways;
                    mlcg_indicadores.Visibility = aoAlways;
                    break;
                case "RPT502":
                    // Metraje Anual de Clientes
                    mlytitm_speanno.Visibility = aoAlways;
                    mempty_speanno.Visibility = aoAlways;
                    mlytitm_cmbMes.Visibility = aoAlways;
                    mempty_cmbmes.Visibility = aoAlways;
                    mlytitm_Param_cli_mon.Visibility = aoAlways;
                    mlcg_Params.Visibility = aoAlways;


                    break;
            }

            // Mostramos el Grupo filtro y el espacio en blanco a la derecha
            mlcg_filtros.Visibility = aoAlways;
            mempty_filtros.Visibility = aoAlways;
        }

        private void mpxValidarFiltros()
        {
            //String aomsgError = "";
            /**#####################################################################################################################################**/
            // Lo primero que hacemos es actualizar todas las variables con su valor actualizado

            /******************************************************************************************/
            /***********   GRUPO DE PARAMETROS ****************************************************** */
            #region PARAMETROS
            aofiltro_anyo_entero = (short)speAnno.Value;
            aofiltro_mes_entero = Convert.ToInt16(cmbMes.SelectedIndex + 1);
            aofiltro_mes_cadena = cmbMes.Text.Trim();

            // Rango de Meses
            aofiltro_mesyearini = new DateTime(mdte_Param_mesyearini.DateTime.Year, mdte_Param_mesyearini.DateTime.Month, 1);
            aofiltro_mesyearfin = new DateTime(mdte_Param_mesyearfin.DateTime.Year, mdte_Param_mesyearfin.DateTime.Month, 1).AddMonths(1).AddDays(-1);

            /**#####################################################################################################################################**/
            // Ahora vamos a validar todos aquellos parámetros que estén visibles (si están visibles, es xq el reporte los requiere)
            // Cuenta contable
            if (mlcg_cliente.Visibility == aoAlways)
            {
                if (Convert.ToInt16(mrdg_Param_cli_buscarpor.EditValue) == 1)
                {
                    if (String.IsNullOrEmpty(Convert.ToString(mgle_Param_cliente.EditValue)))
                        aofiltro_codcliente = null;
                    else
                        aofiltro_codcliente = mgle_Param_cliente.EditValue.ToString();
                }
                else if (Convert.ToInt16(mrdg_Param_cli_buscarpor.EditValue) == 2)
                {
                    if (String.IsNullOrEmpty((mtxt_Param_codcliente.Text)))
                        aofiltro_codcliente = null;
                    else
                        aofiltro_codcliente = mtxt_Param_codcliente.Text.Trim();
                }
                else
                {
                    aofiltro_codcliente = null;
                }

            }
            #endregion

            /******************************************************************************************/
            /***********   GRUPO DE INDICADORES ****************************************************** */
            #region INDICADORES

            //// Pagos a la Fecha Actual
            //if (mlytitm_pagosfechaactual.Visibility == aoAlways)
            //    aofiltroind_pagosfechaact = mchk_pagosfechaactual.Checked;
            //else
            //    aofiltroind_pagosfechaact = false;

            aofiltroind_pagosfechaact = mchk_pagosfechaactual.Checked;
            aofiltroind_CtaAuditoria = mchk_ctaAuditoria.Checked;
            aofiltroind_SoloCliIndustr = mchk_SoloCliIndustr.Checked;
            aofiltroind_PgoOrg = mchk_PgoOrg.Checked;
            aofiltroind_comparamesyearANT = mchk_comparamesanyoant.Checked;
            aofiltroind_solofactpendientes = mchk_solofactpendientes.Checked;
            #endregion
        }

        /// <summary>
        /// Visualiza el reporte seleccionado
        /// </summary>
        private void mpxImprimir()
        {
            try
            {
                // Declaramos las variables locales a ocupar
                string acSql_01 = "";
                string acSql_02 = "";
                Str_Ruta = "";
                acDT_temp = new DataTable();
                acDT_temp_02 = new DataTable();
                short aoanyo_entero_ANT = 0;
                short aoMES_entero_ANT = 0;
                decimal aoTasaCambio = 36.6243M;
                string aotittle2 = "";
                String aofechaini_cadena = "";
                String aofechafin_cadena = "";
                String aoSentenciaAND_1 = "";
                String aoSentenciaAND_2 = "";
                frmviewer aofrmviewer;

                // Rellenamos las variables de filtros
                mpxValidarFiltros();

                if (String.IsNullOrEmpty(aoCodReporte))
                {
                    XtraMessageBox.Show("Debe seleccionar un reporte", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                mpxShowSplashForm();

                // Identificamos que reporte vamos a imprimir para asignar la query SQL
                switch (aoCodReporte)
                {
                    case "RPT101":
                        #region RPT101
                        // Creamos la lista del reporte a imprimir
                        List<view_rpt_facturasmes> aolistrpt_101 = new List<view_rpt_facturasmes>();
                        List<view_rpt_facturasmes_czf> aolistrpt_101CZF = new List<view_rpt_facturasmes_czf>();

                        if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                        {                           

                            if (aofiltroind_CtaAuditoria)
                            {
                                // Si no está seleccionado, solo mostrará pagos que se hayan efectuados el mismo mes filtrado
                                aoSentenciaAND_1 = "AND YEAR(PAG.pg_fecpag) = " + aofiltro_anyo_entero.ToString() + " AND MONTH(PAG.pg_fecpag) = " + aofiltro_mes_entero.ToString();
                                acSql_01 = String.Format(Resources.xr_proc_facturas_mes_AUD, aofiltro_anyo_entero, aofiltro_mes_entero, aoSentenciaAND_1);
                            }
                            else if ((aofiltroind_pagosfechaact) && (aofiltroind_SoloCliIndustr) && (aofiltroind_PgoOrg))
                            {
                                // Si no está seleccionado, solo mostrará pagos que se hayan efectuados el mismo mes filtrado
                                aoSentenciaAND_1 = "AND YEAR(PAG.pg_fecpag) = " + aofiltro_anyo_entero.ToString() + " AND MONTH(PAG.pg_fecpag) = " + aofiltro_mes_entero.ToString();
                                string aoLIKE = " AND CLI.cli_nom NOT Like 'FLOTA%' AND CLI.cli_nom NOT Like 'PARASOL%'";
                                acSql_01 = String.Format(Resources.xr_proc_facturas_mes_czf, aofiltro_anyo_entero, aofiltro_mes_entero, aoSentenciaAND_1, aoLIKE);
                            }
                            // Preguntamos si esta seleccionado los pagos hasta el dia de hoy
                            else if ((aofiltroind_pagosfechaact) && (!aofiltroind_SoloCliIndustr) && (!aofiltroind_PgoOrg))
                            {
                                acSql_01 = String.Format(Resources.xr_proc_facturas_mes_czf, aofiltro_anyo_entero, aofiltro_mes_entero, "", "");
                            }
                            else if ((aofiltroind_pagosfechaact) && (!aofiltroind_SoloCliIndustr) && (aofiltroind_PgoOrg))
                            {
                                // Si no está seleccionado, solo mostrará pagos que se hayan efectuados el mismo mes filtrado
                                aoSentenciaAND_1 = "AND YEAR(PAG.pg_fecpag) = " + aofiltro_anyo_entero.ToString() + " AND MONTH(PAG.pg_fecpag) = " + aofiltro_mes_entero.ToString();
                                string aoLIKE = " AND CLI.cli_nom NOT Like 'FLOTA%' AND CLI.cli_nom NOT Like 'PARASOL%'";
                                acSql_01 = String.Format(Resources.xr_proc_facturas_mes_czf, aofiltro_anyo_entero, aofiltro_mes_entero, aoSentenciaAND_1, aoLIKE);
                            }
                            else if ((!aofiltroind_pagosfechaact) && (aofiltroind_SoloCliIndustr) && (!aofiltroind_PgoOrg))
                            {
                                // Si no está seleccionado, solo mostrará pagos que se hayan efectuados el mismo mes filtrado
                                aoSentenciaAND_1 = "AND YEAR(PAG.pg_fecpag) = " + aofiltro_anyo_entero.ToString() + " AND MONTH(PAG.pg_fecpag) = " + aofiltro_mes_entero.ToString();
                                string aoLIKE = " AND CLI.cli_nom NOT Like 'FLOTA%' AND CLI.cli_nom NOT Like 'PARASOL%'";
                                acSql_01 = String.Format(Resources.xr_proc_facturas_mes_czf, aofiltro_anyo_entero, aofiltro_mes_entero, aoSentenciaAND_1, aoLIKE);
                            }
                            else if ((!aofiltroind_pagosfechaact) && (aofiltroind_SoloCliIndustr) && (aofiltroind_PgoOrg))
                            {
                                // Si no está seleccionado, solo mostrará pagos que se hayan efectuados el mismo mes filtrado
                                aoSentenciaAND_1 = "AND YEAR(PAG.pg_fecpag) = " + aofiltro_anyo_entero.ToString() + " AND MONTH(PAG.pg_fecpag) = " + aofiltro_mes_entero.ToString();
                                string aoLIKE = " AND CLI.cli_nom NOT Like 'FLOTA%' AND CLI.cli_nom NOT Like 'PARASOL%'";
                                acSql_01 = String.Format(Resources.xr_proc_facturas_mes_czf, aofiltro_anyo_entero, aofiltro_mes_entero, aoSentenciaAND_1, aoLIKE);
                            }
                            else if ((!aofiltroind_pagosfechaact) && (!aofiltroind_SoloCliIndustr) && (aofiltroind_PgoOrg))
                            {
                                // Si no está seleccionado, solo mostrará pagos que se hayan efectuados el mismo mes filtrado
                                aoSentenciaAND_1 = "AND YEAR(PAG.pg_fecpag) = " + aofiltro_anyo_entero.ToString() + " AND MONTH(PAG.pg_fecpag) = " + aofiltro_mes_entero.ToString();
                                //string aoLIKE = " AND CLI.cli_nom NOT Like 'FLOTA%' AND CLI.cli_nom NOT Like 'PARASOL%'";
                                acSql_01 = String.Format(Resources.xr_proc_facturas_mes_czf, aofiltro_anyo_entero, aofiltro_mes_entero, aoSentenciaAND_1, "");
                            }
                            else if ((aofiltroind_pagosfechaact) && (aofiltroind_SoloCliIndustr) && (!aofiltroind_PgoOrg))
                            {
                                // Si no está seleccionado, solo mostrará pagos que se hayan efectuados el mismo mes filtrado
                                aoSentenciaAND_1 = "AND YEAR(PAG.pg_fecpag) = " + aofiltro_anyo_entero.ToString() + " AND MONTH(PAG.pg_fecpag) = " + aofiltro_mes_entero.ToString();
                                string aoLIKE = " AND CLI.cli_nom NOT Like 'FLOTA%' AND CLI.cli_nom NOT Like 'PARASOL%'";
                                acSql_01 = String.Format(Resources.xr_proc_facturas_mes_czf, aofiltro_anyo_entero, aofiltro_mes_entero, aoSentenciaAND_1, aoLIKE);
                            }
                            else
                            {
                                // Si no está seleccionado, solo mostrará pagos que se hayan efectuados el mismo mes filtrado    + 
                                aoSentenciaAND_1 = "AND YEAR(PAG.pg_fecpag) = " + aofiltro_anyo_entero.ToString() + " AND MONTH(PAG.pg_fecpag) = " + aofiltro_mes_entero.ToString();                                
                                acSql_01 = String.Format(Resources.xr_proc_facturas_mes_czf, aofiltro_anyo_entero, aofiltro_mes_entero, aoSentenciaAND_1, "");
                            }
                            Str_Ruta = Settings.Default.mCnxCZF_TablasCXC;
                        }
                        else
                        {
                            if (aofiltroind_CtaAuditoria)
                            {
                                // Si no está seleccionado, solo mostrará pagos que se hayan efectuados el mismo mes filtrado
                                aoSentenciaAND_1 = "AND YEAR(PAG.pg_fecpag) = " + aofiltro_anyo_entero.ToString() + " AND MONTH(PAG.pg_fecpag) = " + aofiltro_mes_entero.ToString();
                                acSql_01 = String.Format(Resources.xr_proc_facturas_mes_AUD, aofiltro_anyo_entero, aofiltro_mes_entero, aoSentenciaAND_1);
                            }
                            // Preguntamos si esta seleccionado los pagos hasta el dia de hoy
                            else if (aofiltroind_pagosfechaact)
                            {
                                acSql_01 = String.Format(Resources.xr_proc_facturas_mes, aofiltro_anyo_entero, aofiltro_mes_entero, "");
                            }
                            else
                            {
                                // Si no está seleccionado, solo mostrará pagos que se hayan efectuados el mismo mes filtrado
                                aoSentenciaAND_1 = "AND YEAR(PAG.pg_fecpag) = " + aofiltro_anyo_entero.ToString() + " AND MONTH(PAG.pg_fecpag) = " + aofiltro_mes_entero.ToString();
                                acSql_01 = String.Format(Resources.xr_proc_facturas_mes, aofiltro_anyo_entero, aofiltro_mes_entero, aoSentenciaAND_1);
                            }
                            Str_Ruta = Settings.Default.mCnxCNZF_TablasCXC;
                        }
                        // Hacemos la conexión a las tablas y lo llenamos al DATATABLE Temporal
                        using (OleDbDataAdapter adapt = new OleDbDataAdapter(acSql_01, Str_Ruta))
                        {
                            adapt.Fill(acDT_temp);
                        }

                        if (acDT_temp.Rows.Count == 0)
                        {
                            mpxCloseSplashForm();
                            XtraMessageBox.Show("No se encontraron datos en los filtros especificados", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // Rellenamos la lista que se enviara al reporte
                        foreach (DataRow item in acDT_temp.Rows)
                        {
                            if(item["fac_numfac"].ToString().Trim() == "36087")
                            {
                                var Temp = item["fac_numfac"].ToString().Trim();
                            }

                            if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                            {
                                // Variable para capturar registros repetidos, y actualizar valores
                                List<view_rpt_facturasmes_czf> aoexistregistro = new List<view_rpt_facturasmes_czf>();
                                // Consulta para ubicar registro repetidos
                                aoexistregistro = (from t in aolistrpt_101CZF.AsQueryable()
                                                   where t.fac_numfac.Trim() == item["fac_numfac"].ToString().Trim()
                                                   select t).ToList();

                              

                                if (aoexistregistro.Count > 0)
                                {
                                    
                                    view_rpt_facturasmes_czf aoety_exist = aoexistregistro[0];
                                    Int32 posety = aolistrpt_101CZF.IndexOf(aoety_exist);
                                    aolistrpt_101CZF.RemoveAt(posety);

                                    var Pru = aoety_exist.rem_cantprecio;

                                    aoety_exist.pag_numroc += Environment.NewLine + item["pag_numroc"].ToString();
                                    //aoety_exist.pag_fecha += DateTime.Parse(item["pag_fecha"].ToString());
                                    aoety_exist.impuesto += Double.Parse(item["iva"].ToString());
                                    //aoety_exist.pag_amount_sub = Double.Parse(item["pag_amount"].ToString());
                                    aolistrpt_101CZF.Insert(posety, aoety_exist);
                                }
                                else
                                {
                                    aolistrpt_101CZF.Add(new view_rpt_facturasmes_czf()
                                    {
                                        fac_numfac = item["fac_numfac"].ToString(),
                                        fac_fecha = DateTime.Parse(item["fac_fecha"].ToString()),
                                        cli_nombre = item["cli_nombre"].ToString(),
                                        cli_pais = item["cli_pais"].ToString(),
                                        cli_ciudad = item["cli_ciudad"].ToString(),
                                        rem_cant = Double.Parse(item["rent_cant"].ToString()),
                                        rem_precio = Double.Parse(item["rent_precio"].ToString()),
                                        rem_cantprecio = Double.Parse(item["rent_cantprecio"].ToString()),
                                        man_cant = Double.Parse(item["mant_cant"].ToString()),
                                        man_precio = Double.Parse(item["mant_precio"].ToString()),
                                        man_cantprecio = Double.Parse(item["mant_cantprecio"].ToString()),
                                        com_cant = Double.Parse(item["comd_cant"].ToString()),
                                        com_precio = Double.Parse(item["comd_precio"].ToString()),
                                        com_cantprecio = Double.Parse(item["comd_cantprecio"].ToString()),
                                        impuesto = Double.Parse(item["iva"].ToString()),
                                        pag_amount_sub = Double.Parse(item["pag_amount"].ToString()),//Double.Parse(item["fac_total"].ToString()) - Double.Parse(item["iva"].ToString()),
                                        pag_numroc = item["pag_numroc"].ToString(),
                                        pag_fecha = item["pag_fecha"] != null ? DateTime.Parse(item["pag_fecha"].ToString()) : new DateTime(),
                                        fac_total = Double.Parse(item["fac_total"].ToString()),
                                        tipo_regimen = item["tipo_regimen"].ToString()
                                    });
                                }
                            }
                            else
                            {
                                // Variable para capturar registros repetidos, y actualizar valores
                                List<view_rpt_facturasmes> aoexistregistro = new List<view_rpt_facturasmes>();
                                // Consulta para ubicar registro repetidos
                                aoexistregistro = (from t in aolistrpt_101.AsQueryable()
                                                   where t.fac_numfac.Trim() == item["fac_numfac"].ToString().Trim()
                                                   select t).ToList();

                                if (aoexistregistro.Count > 0)
                                {
                                    view_rpt_facturasmes aoety_exist = aoexistregistro[0];
                                    Int32 posety = aolistrpt_101.IndexOf(aoety_exist);
                                    aolistrpt_101.RemoveAt(posety);

                                    aoety_exist.pag_numroc += Environment.NewLine + item["pag_numroc"].ToString();
                                    aoety_exist.pag_fecha = DateTime.Parse(item["pag_fecha"].ToString());
                                    aoety_exist.pag_amount += Double.Parse(item["pag_amount"].ToString());
                                    aolistrpt_101.Insert(posety, aoety_exist);
                                }
                                else
                                {
                                    aolistrpt_101.Add(new view_rpt_facturasmes()
                                    {
                                        fac_numfac = item["fac_numfac"].ToString(),
                                        fac_fecha = DateTime.Parse(item["fac_fecha"].ToString()),
                                        cli_nombre = item["cli_nombre"].ToString(),
                                        cli_pais = item["cli_pais"].ToString(),
                                        cli_ciudad = item["cli_ciudad"].ToString(),
                                        rem_cant = Double.Parse(item["rem_cant"].ToString()),
                                        rem_precio = Double.Parse(item["rem_precio"].ToString()),
                                        rem_cantprecio = Double.Parse(item["rem_cantprecio"].ToString()),
                                        rem_descuen = Double.Parse(item["rem_descuen"].ToString()),
                                        rem_tramit = Double.Parse(item["rem_tramit"].ToString()),
                                        pag_amount = Double.Parse(item["pag_amount"].ToString()),
                                        pag_numroc = item["pag_numroc"].ToString(),
                                        pag_fecha = item["pag_fecha"] != null ? DateTime.Parse(item["pag_fecha"].ToString()) : new DateTime(),
                                        fac_total = Double.Parse(item["fac_total"].ToString()),
                                        tipo_regimen = item["tipo_regimen"].ToString()
                                    });
                                }
                            }
                        }

                        //Cargamos los clientes
                        if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                        {
                            if (aofiltroind_CtaAuditoria)
                            {
                                Reports.CZF.xrfacturasmes aorpt_101 = new Reports.CZF.xrfacturasmes();
                                aorpt_101.DataSource = aolistrpt_101;
                                aorpt_101.mpxSetTittle("", "Año: " + aofiltro_anyo_entero.ToString() + "  Mes: " + aofiltro_mes_cadena + "  Moneda: Dólares (US$)");
                                //aorpt.picLogo.Image = VisorFacturas.Properties.Resources.CZF_Logo;
                                aofrmviewer = new frmviewer(aorpt_101);
                                aofrmviewer.Text = aoNombreReporte + " - " + aofiltro_mes_cadena + " " + aofiltro_anyo_entero.ToString();
                                //aofrmviewer.MdiParent = this.MdiParent;
                                aofrmviewer.WindowState = FormWindowState.Maximized;
                                aorpt_101.PrintingSystem.Document.AutoFitToPagesWidth = 1;
                                aofrmviewer.Show();
                            }
                            else if (!aofiltroind_PgoOrg)
                            {
                                Reports.CZF.xrfacturasmes aorpt_101 = new Reports.CZF.xrfacturasmes();
                                aorpt_101.DataSource = aolistrpt_101CZF;
                                aorpt_101.mpxSetTittle("", "Año: " + aofiltro_anyo_entero.ToString() + "  Mes: " + aofiltro_mes_cadena + "  Moneda: Dólares (US$)");
                                //aorpt.picLogo.Image = VisorFacturas.Properties.Resources.CZF_Logo;
                                aofrmviewer = new frmviewer(aorpt_101);
                                aofrmviewer.Text = aoNombreReporte + " - " + aofiltro_mes_cadena + " " + aofiltro_anyo_entero.ToString();
                                //aofrmviewer.MdiParent = this.MdiParent;
                                aofrmviewer.WindowState = FormWindowState.Maximized;
                                aorpt_101.PrintingSystem.Document.AutoFitToPagesWidth = 1;
                                aofrmviewer.Show();
                            }
                            else
                            {
                                Reports.CZF.xrfacturasmesDet aorpt_101 = new Reports.CZF.xrfacturasmesDet();
                                aorpt_101.DataSource = aolistrpt_101CZF;
                                aorpt_101.mpxSetTittle("", "Año: " + aofiltro_anyo_entero.ToString() + "  Mes: " + aofiltro_mes_cadena + "  Moneda: Dólares (US$)");
                                //aorpt.picLogo.Image = VisorFacturas.Properties.Resources.CZF_Logo;
                                aofrmviewer = new frmviewer(aorpt_101);
                                aofrmviewer.Text = aoNombreReporte + " - " + aofiltro_mes_cadena + " " + aofiltro_anyo_entero.ToString();
                                //aofrmviewer.MdiParent = this.MdiParent;
                                aofrmviewer.WindowState = FormWindowState.Maximized;
                                aorpt_101.PrintingSystem.Document.AutoFitToPagesWidth = 1;
                                aofrmviewer.Show();
                            }
                        }
                        else
                        {
                            if (aofiltroind_CtaAuditoria)
                            {
                                Reports.CNZF.xrfacturasmes_Copia aorpt_101 = new Reports.CNZF.xrfacturasmes_Copia();
                                aorpt_101.DataSource = aolistrpt_101;
                                aorpt_101.mpxSetTittle("", "Año: " + aofiltro_anyo_entero.ToString() + "  Mes: " + aofiltro_mes_cadena + "  Moneda: Dólares (US$)");
                                //aorpt.picLogo.Image = VisorFacturas.Properties.Resources.CZF_Logo;
                                aofrmviewer = new frmviewer(aorpt_101);
                                aofrmviewer.Text = aoNombreReporte + " - " + aofiltro_mes_cadena + " " + aofiltro_anyo_entero.ToString();
                                //aofrmviewer.MdiParent = this.MdiParent;
                                aofrmviewer.WindowState = FormWindowState.Maximized;
                                aofrmviewer.Show();
                            }
                            else
                            {
                                Reports.CNZF.xrfacturasmes aorpt_101 = new Reports.CNZF.xrfacturasmes();
                                aorpt_101.DataSource = aolistrpt_101;
                                aorpt_101.mpxSetTittle("", "Año: " + aofiltro_anyo_entero.ToString() + "  Mes: " + aofiltro_mes_cadena + "  Moneda: Dólares (US$)");
                                //aorpt.picLogo.Image = VisorFacturas.Properties.Resources.CZF_Logo;
                                aofrmviewer = new frmviewer(aorpt_101);
                                aofrmviewer.Text = aoNombreReporte + " - " + aofiltro_mes_cadena + " " + aofiltro_anyo_entero.ToString();
                                //aofrmviewer.MdiParent = this.MdiParent;
                                aofrmviewer.WindowState = FormWindowState.Maximized;
                                aofrmviewer.Show();
                            }
                            
                        }

                        //Reports.CNZF.xrfacturasmes aorpt_101 = new Reports.CNZF.xrfacturasmes();
                        //aorpt_101.DataSource = aolistrpt_101;
                        //aorpt_101.mpxSetTittle("", "Año: " + aofiltro_anyo_entero.ToString() + "  Mes: " + aofiltro_mes_cadena + "  Moneda: Dólares (US$)");
                        ////aorpt.picLogo.Image = VisorFacturas.Properties.Resources.CZF_Logo;
                        //aofrmviewer = new frmviewer(aorpt_101);
                        //aofrmviewer.Text = aoNombreReporte + " - " + aofiltro_mes_cadena + " " + aofiltro_anyo_entero.ToString();
                        ////aofrmviewer.MdiParent = this.MdiParent;
                        //aofrmviewer.WindowState = FormWindowState.Maximized;
                        //aofrmviewer.Show();

                        mpxCloseSplashForm();

                        break;
                    #endregion

                    case "RPT102":
                        #region RPT102
                        // Creamos la lista del reporte a imprimir                        
                        List<view_rpt_metrajeanual> aolistrpt_102 = new List<view_rpt_metrajeanual>();
                        acSql_01 = String.Format(Resources.xr_proc_metraje_anual, aofiltro_anyo_entero);

                        //Cargamos los clientes
                        if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                        {
                            Str_Ruta = Settings.Default.mCnxCZF_TablasCXC;
                        }
                        else
                        {
                            Str_Ruta = Settings.Default.mCnxCNZF_TablasCXC;
                        }

                        // Hacemos la conexión a las tablas y lo llenamos al DATATABLE Temporal
                        using (OleDbDataAdapter adapt = new OleDbDataAdapter(acSql_01, Str_Ruta))
                        {
                            adapt.Fill(acDT_temp);
                        }

                        if (acDT_temp.Rows.Count == 0)
                        {
                            mpxCloseSplashForm();
                            XtraMessageBox.Show("No se encontraron datos en los filtros especificados", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // Rellenamos la lista que se enviara al reporte
                        foreach (DataRow item in acDT_temp.Rows)
                        {
                            // Variable para capturar registros repetidos, y actualizar valores
                            List<view_rpt_metrajeanual> aoexistregistro = new List<view_rpt_metrajeanual>();
                            // Consulta para ubicar registro repetidos

                            aoexistregistro = (from t in aolistrpt_102.AsQueryable()
                                               where t.cli_cod.Trim() == item["cli_cod"].ToString().Trim()
                                               select t).ToList();

                            if (aoexistregistro.Count > 0)
                            {
                                view_rpt_metrajeanual aoety_exist = aoexistregistro[0];
                                Int32 posety = aolistrpt_102.IndexOf(aoety_exist);
                                aolistrpt_102.RemoveAt(posety);

                                switch (short.Parse(item["fac_mesfact"].ToString()))
                                {
                                    case 1:
                                        aoety_exist.rem_cant_01 += Double.Parse(item["rem_cant"].ToString());
                                        break;
                                    case 2:
                                        aoety_exist.rem_cant_02 += Double.Parse(item["rem_cant"].ToString());
                                        break;
                                    case 3:
                                        aoety_exist.rem_cant_03 += Double.Parse(item["rem_cant"].ToString());
                                        break;
                                    case 4:
                                        aoety_exist.rem_cant_04 += Double.Parse(item["rem_cant"].ToString());
                                        break;
                                    case 5:
                                        aoety_exist.rem_cant_05 += Double.Parse(item["rem_cant"].ToString());
                                        break;
                                    case 6:
                                        aoety_exist.rem_cant_06 += Double.Parse(item["rem_cant"].ToString());
                                        break;
                                    case 7:
                                        aoety_exist.rem_cant_07 += Double.Parse(item["rem_cant"].ToString());
                                        break;
                                    case 8:
                                        aoety_exist.rem_cant_08 += Double.Parse(item["rem_cant"].ToString());
                                        break;
                                    case 9:
                                        aoety_exist.rem_cant_09 += Double.Parse(item["rem_cant"].ToString());
                                        break;
                                    case 10:
                                        aoety_exist.rem_cant_10 += Double.Parse(item["rem_cant"].ToString());
                                        break;
                                    case 11:
                                        aoety_exist.rem_cant_11 += Double.Parse(item["rem_cant"].ToString());
                                        break;
                                    case 12:
                                        aoety_exist.rem_cant_12 += Double.Parse(item["rem_cant"].ToString());
                                        break;
                                }

                                aolistrpt_102.Insert(posety, aoety_exist);
                            }
                            else
                            {
                                view_rpt_metrajeanual aoety_new = new view_rpt_metrajeanual();
                                aoety_new.cli_cod = item["cli_cod"].ToString().Trim();
                                aoety_new.cli_nombre = item["cli_nombre"].ToString().Trim();
                                aoety_new.fac_mesfact = short.Parse(item["fac_mesfact"].ToString());
                                aoety_new.rem_cant_01 = 0;
                                aoety_new.rem_cant_02 = 0;
                                aoety_new.rem_cant_03 = 0;
                                aoety_new.rem_cant_04 = 0;
                                aoety_new.rem_cant_05 = 0;
                                aoety_new.rem_cant_06 = 0;
                                aoety_new.rem_cant_07 = 0;
                                aoety_new.rem_cant_08 = 0;
                                aoety_new.rem_cant_09 = 0;
                                aoety_new.rem_cant_10 = 0;
                                aoety_new.rem_cant_11 = 0;
                                aoety_new.rem_cant_12 = 0;

                                switch (aoety_new.fac_mesfact)
                                {
                                    case 1:
                                        aoety_new.rem_cant_01 = Double.Parse(item["rem_cant"].ToString());
                                        break;
                                    case 2:
                                        aoety_new.rem_cant_02 = Double.Parse(item["rem_cant"].ToString());
                                        break;
                                    case 3:
                                        aoety_new.rem_cant_03 = Double.Parse(item["rem_cant"].ToString());
                                        break;
                                    case 4:
                                        aoety_new.rem_cant_04 = Double.Parse(item["rem_cant"].ToString());
                                        break;
                                    case 5:
                                        aoety_new.rem_cant_05 = Double.Parse(item["rem_cant"].ToString());
                                        break;
                                    case 6:
                                        aoety_new.rem_cant_06 = Double.Parse(item["rem_cant"].ToString());
                                        break;
                                    case 7:
                                        aoety_new.rem_cant_07 = Double.Parse(item["rem_cant"].ToString());
                                        break;
                                    case 8:
                                        aoety_new.rem_cant_08 = Double.Parse(item["rem_cant"].ToString());
                                        break;
                                    case 9:
                                        aoety_new.rem_cant_09 = Double.Parse(item["rem_cant"].ToString());
                                        break;
                                    case 10:
                                        aoety_new.rem_cant_10 = Double.Parse(item["rem_cant"].ToString());
                                        break;
                                    case 11:
                                        aoety_new.rem_cant_11 = Double.Parse(item["rem_cant"].ToString());
                                        break;
                                    case 12:
                                        aoety_new.rem_cant_12 = Double.Parse(item["rem_cant"].ToString());
                                        break;
                                }

                                aolistrpt_102.Add(aoety_new);
                            }
                        }

                        mpxCloseSplashForm();

                        if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                        {
                            Reports.CZF.xrmetrajeanual aorpt_102 = new Reports.CZF.xrmetrajeanual();
                            aorpt_102.DataSource = aolistrpt_102;
                            aorpt_102.mpxSetTittle("", "Año: " + aofiltro_anyo_entero.ToString());
                            //aorpt.picLogo.Image = VisorFacturas.Properties.Resources.CZF_Logo;
                            aofrmviewer = new frmviewer(aorpt_102);
                            aofrmviewer.Text = aoNombreReporte + " - " + aofiltro_anyo_entero.ToString();
                            aofrmviewer.MdiParent = this.MdiParent;
                            aofrmviewer.WindowState = FormWindowState.Maximized;
                            aofrmviewer.Show();
                        }
                        else
                        {
                            Reports.CNZF.xrmetrajeanual aorpt_102 = new Reports.CNZF.xrmetrajeanual();
                            aorpt_102.DataSource = aolistrpt_102;
                            aorpt_102.mpxSetTittle("", "Año: " + aofiltro_anyo_entero.ToString());
                            //aorpt.picLogo.Image = VisorFacturas.Properties.Resources.CZF_Logo;
                            aofrmviewer = new frmviewer(aorpt_102);
                            aofrmviewer.Text = aoNombreReporte + " - " + aofiltro_anyo_entero.ToString();
                            aofrmviewer.MdiParent = this.MdiParent;
                            aofrmviewer.WindowState = FormWindowState.Maximized;
                            aofrmviewer.Show();
                        }
                        break;
                    #endregion

                    case "RPT103":
                        #region RPT103
                        // Creamos la lista del reporte a imprimir
                        List<view_rpt_facturacomparames_act_ant> aolistrpt_103 = new List<view_rpt_facturacomparames_act_ant>();
                        // Preguntamos si esta seleccionado el check Comparar Mismo mes Año Actual vs Año Anterior
                        if (aofiltroind_comparamesyearANT)
                        {
                            aoanyo_entero_ANT = Convert.ToInt16(aofiltro_anyo_entero - 1);
                            aoMES_entero_ANT = aofiltro_mes_entero;
                        }
                        else
                        {
                            // Si no está seleccionado, el reporte comparará Mes Actual y Mes Anterior
                            // Preguntamos si tiene Seleccionado Enero como Mes Actual
                            if (aofiltro_mes_entero == 1)
                            {
                                aoanyo_entero_ANT = Convert.ToInt16(aofiltro_anyo_entero - 1);
                                aoMES_entero_ANT = 12;
                            }
                            else
                            {
                                // Compararemos el Mes Actual vs El mes Anterior del mismo Año
                                aoanyo_entero_ANT = aofiltro_anyo_entero;
                                aoMES_entero_ANT = Convert.ToInt16(aofiltro_mes_entero - 1);
                            }
                        }

                        // Creamos la consulta
                        acSql_01 = String.Format(Resources.xr_proc_facturas_compara_mes_act_ant, aofiltro_anyo_entero, aofiltro_mes_entero, aoanyo_entero_ANT, aoMES_entero_ANT);

                        //Cargamos los clientes
                        if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                        {
                            Str_Ruta = Settings.Default.mCnxCZF_TablasCXC;
                        }
                        else
                        {
                            Str_Ruta = Settings.Default.mCnxCNZF_TablasCXC;
                        }

                        // Hacemos la conexión a las tablas y lo llenamos al DATATABLE Temporal
                        using (OleDbDataAdapter adapt = new OleDbDataAdapter(acSql_01, Str_Ruta))
                        {
                            adapt.Fill(acDT_temp);
                        }

                        if (acDT_temp.Rows.Count == 0)
                        {
                            mpxCloseSplashForm();
                            XtraMessageBox.Show("No se encontraron datos en los filtros especificados", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // Rellenamos la lista que se enviara al reporte
                        foreach (DataRow item in acDT_temp.Rows)
                        {
                            // Variable para capturar registros repetidos, y actualizar valores
                            List<view_rpt_facturacomparames_act_ant> aoexistregistro = new List<view_rpt_facturacomparames_act_ant>();
                            // Consulta para ubicar registro repetidos
                            aoexistregistro = (from t in aolistrpt_103.AsQueryable()
                                               where t.cli_cod.Trim() == item["cli_cod"].ToString().Trim()
                                               select t).ToList();

                            if (aoexistregistro.Count > 0)
                            {
                                view_rpt_facturacomparames_act_ant aoety_exist = aoexistregistro[0];
                                Int32 posety = aolistrpt_103.IndexOf(aoety_exist);
                                aolistrpt_103.RemoveAt(posety);

                                if (short.Parse(item["fac_yearfact"].ToString()) == aoanyo_entero_ANT &&
                                    short.Parse(item["fac_mesfact"].ToString()) == aoMES_entero_ANT)
                                {
                                    aoety_exist.rem_cant_ANT = Double.Parse(item["rem_cant"].ToString());
                                    aoety_exist.rem_cantprecio_ANT = Double.Parse(item["rem_cantprecio"].ToString());
                                    aoety_exist.rem_descuen_ANT = Double.Parse(item["rem_descuen"].ToString());
                                    aoety_exist.rem_tramit_ANT = Double.Parse(item["rem_tramit"].ToString());
                                    aoety_exist.fac_total_ANT = Double.Parse(item["fac_total"].ToString());
                                }
                                else if (short.Parse(item["fac_yearfact"].ToString()) == aofiltro_anyo_entero &&
                                    short.Parse(item["fac_mesfact"].ToString()) == aofiltro_mes_entero)
                                {
                                    aoety_exist.rem_cant_ACT = Double.Parse(item["rem_cant"].ToString());
                                    aoety_exist.rem_cantprecio_ACT = Double.Parse(item["rem_cantprecio"].ToString());
                                    aoety_exist.rem_descuen_ACT = Double.Parse(item["rem_descuen"].ToString());
                                    aoety_exist.rem_tramit_ACT = Double.Parse(item["rem_tramit"].ToString());
                                    aoety_exist.fac_total_ACT = Double.Parse(item["fac_total"].ToString());
                                }

                                aolistrpt_103.Insert(posety, aoety_exist);
                            }
                            else
                            {
                                view_rpt_facturacomparames_act_ant aoety_new = new view_rpt_facturacomparames_act_ant();
                                aoety_new.cli_cod = item["cli_cod"].ToString().Trim();
                                aoety_new.cli_nombre = item["cli_nombre"].ToString().Trim();
                                aoety_new.fac_mesfact = short.Parse(item["fac_mesfact"].ToString());
                                aoety_new.fac_yearfact = short.Parse(item["fac_yearfact"].ToString());
                                aoety_new.rem_cant_ANT = 0;
                                aoety_new.rem_cantprecio_ANT = 0;
                                aoety_new.rem_descuen_ANT = 0;
                                aoety_new.rem_tramit_ANT = 0;
                                aoety_new.fac_total_ANT = 0;
                                aoety_new.rem_cant_ACT = 0;
                                aoety_new.rem_cantprecio_ACT = 0;
                                aoety_new.rem_descuen_ACT = 0;
                                aoety_new.rem_tramit_ACT = 0;
                                aoety_new.fac_total_ACT = 0;

                                if (short.Parse(item["fac_yearfact"].ToString()) == aoanyo_entero_ANT &&
                                    short.Parse(item["fac_mesfact"].ToString()) == aoMES_entero_ANT)
                                {
                                    aoety_new.rem_cant_ANT = Double.Parse(item["rem_cant"].ToString());
                                    aoety_new.rem_cantprecio_ANT = Double.Parse(item["rem_cantprecio"].ToString());
                                    aoety_new.rem_descuen_ANT = Double.Parse(item["rem_descuen"].ToString());
                                    aoety_new.rem_tramit_ANT = Double.Parse(item["rem_tramit"].ToString());
                                    aoety_new.fac_total_ANT = Double.Parse(item["fac_total"].ToString());
                                }
                                else if (short.Parse(item["fac_yearfact"].ToString()) == aofiltro_anyo_entero &&
                                    short.Parse(item["fac_mesfact"].ToString()) == aofiltro_mes_entero)
                                {
                                    aoety_new.rem_cant_ACT = Double.Parse(item["rem_cant"].ToString());
                                    aoety_new.rem_cantprecio_ACT = Double.Parse(item["rem_cantprecio"].ToString());
                                    aoety_new.rem_descuen_ACT = Double.Parse(item["rem_descuen"].ToString());
                                    aoety_new.rem_tramit_ACT = Double.Parse(item["rem_tramit"].ToString());
                                    aoety_new.fac_total_ACT = Double.Parse(item["fac_total"].ToString());
                                }


                                aolistrpt_103.Add(aoety_new);
                            }
                        }

                        mpxCloseSplashForm();
                        if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                        {
                            Reports.CZF.xrfacturacomparames_act_ant aorpt_103 = new Reports.CZF.xrfacturacomparames_act_ant();
                            aorpt_103.DataSource = aolistrpt_103;
                            aotittle2 = Util.clsApp.mfxMesCadena(aoMES_entero_ANT) + " " + aoanyo_entero_ANT.ToString() + " vs " +
                                        Util.clsApp.mfxMesCadena(aofiltro_mes_entero) + " " + aofiltro_anyo_entero.ToString() + "  Moneda: Dólares (US$)";
                            aorpt_103.mpxSetTittle("", aotittle2, Util.clsApp.mfxMesCadena(aoMES_entero_ANT) + " " + aoanyo_entero_ANT.ToString(),
                                Util.clsApp.mfxMesCadena(aofiltro_mes_entero) + " " + aofiltro_anyo_entero.ToString());
                            //aorpt.picLogo.Image = VisorFacturas.Properties.Resources.CZF_Logo;
                            aofrmviewer = new frmviewer(aorpt_103);
                            aofrmviewer.Text = aoNombreReporte + " - " + aofiltro_mes_cadena + " " + aofiltro_anyo_entero.ToString();
                            aofrmviewer.MdiParent = this.MdiParent;
                            aofrmviewer.WindowState = FormWindowState.Maximized;
                            aofrmviewer.Show();
                        }
                        else
                        {
                            Reports.CNZF.xrfacturacomparames_act_ant aorpt_103 = new Reports.CNZF.xrfacturacomparames_act_ant();
                            aorpt_103.DataSource = aolistrpt_103;
                            aotittle2 = Util.clsApp.mfxMesCadena(aoMES_entero_ANT) + " " + aoanyo_entero_ANT.ToString() + " vs " +
                                        Util.clsApp.mfxMesCadena(aofiltro_mes_entero) + " " + aofiltro_anyo_entero.ToString() + "  Moneda: Dólares (US$)";
                            aorpt_103.mpxSetTittle("", aotittle2, Util.clsApp.mfxMesCadena(aoMES_entero_ANT) + " " + aoanyo_entero_ANT.ToString(),
                                Util.clsApp.mfxMesCadena(aofiltro_mes_entero) + " " + aofiltro_anyo_entero.ToString());
                            //aorpt.picLogo.Image = VisorFacturas.Properties.Resources.CZF_Logo;
                            aofrmviewer = new frmviewer(aorpt_103);
                            aofrmviewer.Text = aoNombreReporte + " - " + aofiltro_mes_cadena + " " + aofiltro_anyo_entero.ToString();
                            aofrmviewer.MdiParent = this.MdiParent;
                            aofrmviewer.WindowState = FormWindowState.Maximized;
                            aofrmviewer.Show();
                        }

                        break;
                    #endregion

                    case "RPT104":
                        #region RPT104

                        // Creamos la lista del reporte a imprimir
                        List<view_rpt_saldoclientes> aolistrpt_104 = new List<view_rpt_saldoclientes>();

                        //////// Obtenemos la tasa del día del Mes Year Final
                        //////Tipo_Cambio_BCN aoWebService = new Tipo_Cambio_BCN();
                        //////try
                        //////{
                        //////    // Hacemos la consulta al Web Service del BCN para obtener la tasa de cambio
                        //////    aoTasaCambio = (decimal)aoWebService.RecuperaTC_Dia(aofiltro_mesyearfin.Year, aofiltro_mesyearfin.Month, aofiltro_mesyearfin.Day);
                        //////    //XtraMessageBox.Show(String.Format("La Tasa del día es: {0}", aoTasaDia.ToString("#,0.0000")));

                        //////}
                        //////catch (Exception ex)
                        //////{
                        //////    mpxCloseSplashForm();
                        //////    //XtraMessageBox.Show(String.Format("La tasa del día {0} no existe", aoTasaCambio.ToString("dd/MMM/yyyy")), "No se pudo obtener la tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //////    XtraMessageBox.Show(ex.Message, "No se pudo obtener la tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //////    string msg = "¿Desea visualizar el reporte sin la tasa de cambio?";
                        //////    if (XtraMessageBox.Show(msg, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        //////    {
                        //////        aoTasaCambio = 0;
                        //////        mpxShowSplashForm();
                        //////    }                                
                        //////    else
                        //////        return;

                        //////}


                        //// Rellenamos la consulta SQL
                        //aofechaini_cadena = "{^" + aofiltro_mesyearini.ToString("yyyy/MM/dd") + "}";
                        aofechaini_cadena = "{^" + aoFecha2000.ToString("yyyy/MM/dd") + "}";
                        aofechafin_cadena = "{^" + aofiltro_mesyearfin.ToString("yyyy/MM/dd") + "}";

                        if (aofiltroind_pagosfechaact == false)
                        {
                            aoSentenciaAND_1 = "AND PAG.pg_fecpag <= " + aofechafin_cadena;
                        }

                        //acSql_01 = String.Format(Resources.xr_proc_antiguedad_sdo, aofechaini_cadena,
                        //                                                      aofechafin_cadena,
                        //                                                      aoSentenciaAND_1);

                        //Cargamos los clientes
                        if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                        {
                            Str_Ruta = Settings.Default.mCnxCZF_TablasCXC;
                            acSql_01 = String.Format(Resources.xr_proc_antiguedad_sdo_czf, aofechaini_cadena, aofechafin_cadena, aoSentenciaAND_1);
                        }
                        else
                        {
                            Str_Ruta = Settings.Default.mCnxCNZF_TablasCXC;
                            acSql_01 = String.Format(Resources.xr_proc_antiguedad_sdo, aofechaini_cadena, aofechafin_cadena, aoSentenciaAND_1);
                        }
                        // Hacemos la conexión a las tablas y lo llenamos al DATATABLE Temporal
                        using (OleDbDataAdapter adapt = new OleDbDataAdapter(acSql_01, Str_Ruta))
                        {
                            adapt.Fill(acDT_temp);
                        }

                        if (acDT_temp.Rows.Count == 0)
                        {
                            mpxCloseSplashForm();
                            XtraMessageBox.Show("No se encontraron datos en los filtros especificados", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        aolistrpt_104 = mpxFillListRPT104(aoTasaCambio);

                        mpxCloseSplashForm();

                        if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                        {
                            // Imprimimos el reporte
                            aolistrpt_104 = aolistrpt_104.Where(x => x.sdototd > 0).ToList();
                            Reports.CZF.xrantiguedad_saldo aorpt_104 = new Reports.CZF.xrantiguedad_saldo();
                            aorpt_104.DataSource = aolistrpt_104;
                            aorpt_104.mpxSetTittle(""
                                                   , "Al " + aofiltro_mesyearfin.ToString("dd") + " de " + aofiltro_mesyearfin.ToString("MMMM") + " del " + aofiltro_mesyearfin.ToString("yyyy")
                                                   , "T/C: " + aoTasaCambio.ToString("#,0.0000"));
                            //aorpt.picLogo.Image = VisorFacturas.Properties.Resources.CZF_Logo;
                            aofrmviewer = new frmviewer(aorpt_104);
                            aofrmviewer.Text = aoNombreReporte;
                            aofrmviewer.MdiParent = this.MdiParent;
                            aofrmviewer.WindowState = FormWindowState.Maximized;
                            aofrmviewer.Show();
                        }
                        else
                        {
                            // Imprimimos el reporte
                            aolistrpt_104 = aolistrpt_104.Where(x => x.sdototd > 0).ToList();
                            Reports.CNZF.xrantiguedad_saldo aorpt_104 = new Reports.CNZF.xrantiguedad_saldo();
                            aorpt_104.DataSource = aolistrpt_104;
                            aorpt_104.mpxSetTittle(""
                                                   , "Al " + aofiltro_mesyearfin.ToString("dd") + " de " + aofiltro_mesyearfin.ToString("MMMM") + " del " + aofiltro_mesyearfin.ToString("yyyy")
                                                   , "T/C: " + aoTasaCambio.ToString("#,0.0000"));
                            //aorpt.picLogo.Image = VisorFacturas.Properties.Resources.CZF_Logo;
                            aofrmviewer = new frmviewer(aorpt_104);
                            aofrmviewer.Text = aoNombreReporte;
                            aofrmviewer.MdiParent = this.MdiParent;
                            aofrmviewer.WindowState = FormWindowState.Maximized;
                            aofrmviewer.Show();
                        }
                        break;
                    #endregion

                    case "RPT105":
                        #region RPT 105
                        // Creamos la lista del reporte a imprimir
                        List<view_rpt_saldoclientes> aolistrpt_105 = new List<view_rpt_saldoclientes>();

                        //////// Obtenemos la tasa del día del Mes Year Final
                        //////Tipo_Cambio_BCN aoWebService_105 = new Tipo_Cambio_BCN();
                        //////try
                        //////{
                        //////    // Hacemos la consulta al Web Service del BCN para obtener la tasa de cambio
                        //////    aoTasaCambio = (decimal)aoWebService_105.RecuperaTC_Dia(aofiltro_mesyearfin.Year, aofiltro_mesyearfin.Month, aofiltro_mesyearfin.Day);
                        //////    //XtraMessageBox.Show(String.Format("La Tasa del día es: {0}", aoTasaDia.ToString("#,0.0000")));

                        //////}
                        //////catch (Exception ex)
                        //////{
                        //////    mpxCloseSplashForm();
                        //////    //XtraMessageBox.Show(String.Format("La tasa del día {0} no existe", aoTasaCambio.ToString("dd/MMM/yyyy")), "No se pudo obtener la tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //////    XtraMessageBox.Show(ex.Message, "No se pudo obtener la tasa", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //////    string msg = "¿Desea visualizar el reporte sin la tasa de cambio?";
                        //////    if (XtraMessageBox.Show(msg, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        //////    {
                        //////        aoTasaCambio = 0;
                        //////        mpxShowSplashForm();
                        //////    }
                        //////    else
                        //////        return;

                        //////}

                        // Rellenamos la consulta SQL
                        //Para ello hacemos algunas preguntas IF
                        aofechaini_cadena = "{^" + aofiltro_mesyearini.ToString("yyyy/MM/dd") + "}";
                        aofechafin_cadena = "{^" + aofiltro_mesyearfin.ToString("yyyy/MM/dd") + "}";

                        if (aofiltro_codcliente == null)
                        {
                            mpxCloseSplashForm();
                            XtraMessageBox.Show("No ha especificado un cliente", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            aoSentenciaAND_1 = String.Format("AND FAC.cli_codig = '{0}'", aofiltro_codcliente);
                        }

                        if (aofiltroind_pagosfechaact == false)
                        {
                            aoSentenciaAND_2 = "AND PAG.pg_fecpag <= " + aofechafin_cadena;
                        }                        

                        if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                        {
                            Str_Ruta = Settings.Default.mCnxCZF_TablasCXC;
                            // Query Principal
                            acSql_01 = String.Format(Resources.xr_proc_estado_cuenta_czf, aofechaini_cadena, aofechafin_cadena, aoSentenciaAND_1, aoSentenciaAND_2);
                        }
                        else
                        {
                            Str_Ruta = Settings.Default.mCnxCNZF_TablasCXC;
                            acSql_01 = String.Format(Resources.xr_proc_estado_cuenta, aofechaini_cadena, aofechafin_cadena, aoSentenciaAND_1, aoSentenciaAND_2);
                        }
                        // Hacemos la conexión a las tablas y lo llenamos al DATATABLE Temporal
                        using (OleDbDataAdapter adapt = new OleDbDataAdapter(acSql_01, Str_Ruta))
                        {
                            adapt.Fill(acDT_temp);
                        }

                        if (acDT_temp.Rows.Count == 0)
                        {
                            mpxCloseSplashForm();
                            XtraMessageBox.Show("No se encontraron datos en los filtros especificados", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;

                        }

                        aolistrpt_105 = mpxFillListRPT105(aoTasaCambio);

                        mpxCloseSplashForm();
                        if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                        {
                            // Imprimimos el reporte
                            Reports.CZF.xrestado_cta_cliente aorpt_105 = new Reports.CZF.xrestado_cta_cliente();
                            aorpt_105.mpxSetTittle("", "Del: " + aofiltro_mesyearini.ToString("dd/MM/yyyy") + "  Al: " + aofiltro_mesyearfin.ToString("dd/MM/yyyy"));
                            if (aofiltroind_solofactpendientes)
                            {
                                aorpt_105.DataSource = aolistrpt_105.Where(x => x.sdototd > 0).ToList();
                                aorpt_105.GroupHeader1.PageBreak = DevExpress.XtraReports.UI.PageBreak.None;
                            }
                            else
                            {
                                aorpt_105.DataSource = aolistrpt_105;
                            }

                            //aorpt.picLogo.Image = VisorFacturas.Properties.Resources.CZF_Logo;
                            aofrmviewer = new frmviewer(aorpt_105);
                            aofrmviewer.Text = aoNombreReporte;
                            aofrmviewer.MdiParent = this.MdiParent;
                            aofrmviewer.WindowState = FormWindowState.Maximized;
                            aofrmviewer.Show();
                        }
                        else
                        {
                            // Imprimimos el reporte
                            Reports.CNZF.xrestado_cta_cliente aorpt_105 = new Reports.CNZF.xrestado_cta_cliente();
                            aorpt_105.mpxSetTittle("", "Del: " + aofiltro_mesyearini.ToString("dd/MM/yyyy") + "  Al: " + aofiltro_mesyearfin.ToString("dd/MM/yyyy"));
                            if (aofiltroind_solofactpendientes)
                            {
                                aorpt_105.DataSource = aolistrpt_105.Where(x => x.sdototd > 0).ToList();
                                aorpt_105.GroupHeader1.PageBreak = DevExpress.XtraReports.UI.PageBreak.None;
                            }
                            else
                            {
                                aorpt_105.DataSource = aolistrpt_105;
                            }

                            //aorpt.picLogo.Image = VisorFacturas.Properties.Resources.CZF_Logo;
                            aofrmviewer = new frmviewer(aorpt_105);
                            aofrmviewer.Text = aoNombreReporte;
                            aofrmviewer.MdiParent = this.MdiParent;
                            aofrmviewer.WindowState = FormWindowState.Maximized;
                            aofrmviewer.Show();
                        }
                        #endregion
                        break;
                    

                    case "RPT502":
                        #region RPT 502
                        string Moneda = "'C'";
                        int C_CNZF = 15;
                        int D_CNZF = 03;
                        int CL_CZF = 11;
                        int CB_CZF = 17;
                        int DL_CZF = 22;
                        int DB_CZF = 26;

                        if (Convert.ToInt16(mrdg_Param_cli_mon.EditValue) == 1)
                        {
                            Moneda = "'C'";
                        }
                        else if (Convert.ToInt16(mrdg_Param_cli_mon.EditValue) == 2)
                        {
                            Moneda = "'D'";
                        }
                        //DateTime DATE = string.Empty;
                        string strMonthName = string.Empty;
                        int cont = 0;
                        string patittle01 = string.Empty;
                        string patittle02 = string.Empty;
                        // Creamos la lista del reporte a imprimir
                        List<view_rpt_BANCOS> aolistrpt_502 = new List<view_rpt_BANCOS>();
                        if (aofiltro_mes_entero < 10)
                        {
                            aofechaini_cadena = "0" + aofiltro_mes_entero.ToString() + aofiltro_anyo_entero.ToString().Substring(2);
                        }
                        else
                        {
                            aofechaini_cadena = aofiltro_mes_entero.ToString() + aofiltro_anyo_entero.ToString().Substring(2);
                        }
                        if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                        {
                            Str_Ruta = Settings.Default.mCnxCZF_TablasBANCO;
                            // Query Principal
                            acSql_01 = String.Format(Resources.xr_proc_bancos_czf_sdo, aofechaini_cadena, Moneda);
                            //if (Moneda == 1)
                            //{
                            //    acSql_01 = acSql_01 + String.Format("AND BAC.cuenco == {0} OR BAC.cuenco == {1}", CL_CZF, CB_CZF) + " order by BAC.fecha ";
                            //}
                            //else if (Moneda == 2)
                            //{
                            //    acSql_01 = acSql_01 + String.Format("AND BAC.cuenco == {0} OR BAC.cuenco == {1}", DL_CZF, DB_CZF) + " order by BAC.fecha ";
                            //}
                        }
                        else
                        {
                            acSql_01 = String.Format(Resources.xr_proc_bancos_cnzf_sdo, aofechaini_cadena, Moneda);
                            //if (Moneda == 1)
                            //{
                            //    acSql_01 = acSql_01 + String.Format("AND BAC.cuenco == {0}", C_CNZF) + " order by BAC.fecha ";
                            //}
                            //else if (Moneda == 2)
                            //{
                            //    acSql_01 = acSql_01 + String.Format("AND BAC.cuenco == {0}", D_CNZF) + " order by BAC.fecha ";
                            //}

                            Str_Ruta = Settings.Default.mCnxCNZF_TablasBANCO;

                            
                        }
                        //mpxCargarDatosTablasDBF(acSql_01);
                        // Hacemos la conexión a las tablas y lo llenamos al DATATABLE Temporal
                        using (OleDbDataAdapter adapt = new OleDbDataAdapter(acSql_01, Str_Ruta))
                        {
                            adapt.Fill(acDT_temp);
                        }

                        if (acDT_temp.Rows.Count == 0)
                        {
                            mpxCloseSplashForm();
                            XtraMessageBox.Show("No se encontraron datos en los filtros especificados", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        //Rellenamos la lista que se enviara al reporte
                        foreach (DataRow item in acDT_temp.Rows)
                        {
                            cont += 1;
                            if (cont == 1)
                            {
                                if(item["banco"].ToString().Trim() == "LC$")
                                {
                                    patittle01 = "LaFise";
                                    patittle02 = "Córdobas";
                                }
                                else
                                {
                                    patittle01 = "LaFise";
                                    patittle02 = "Dólares";
                                }
                                   
                                strMonthName = new DateTime(aofiltro_anyo_entero, aofiltro_mes_entero, 1).ToString("MMMM");
                                strMonthName = (CultureInfo.InvariantCulture.TextInfo.ToTitleCase(strMonthName));


                            }
                            
                            // Variable para capturar registros repetidos, y actualizar valores
                            List<view_rpt_BANCOS> aoexistregistro = new List<view_rpt_BANCOS>();
                            // Consulta para ubicar registro repetidos
                            aoexistregistro = (from t in aolistrpt_502.AsQueryable()
                                               where t.nodoc.Trim() == item["nodoc"].ToString().Trim()
                                               select t).ToList();

                            if (aoexistregistro.Count > 0)
                            {
                                view_rpt_BANCOS aoety_exist = aoexistregistro[0];
                                Int32 posety = aolistrpt_502.IndexOf(aoety_exist);
                                aolistrpt_502.RemoveAt(posety);

                                //aoety_exist.pag_numroc += Environment.NewLine + item["pag_numroc"].ToString();
                                //aoety_exist.pag_fecha = DateTime.Parse(item["pag_fecha"].ToString());
                                //aoety_exist.pag_amount += Double.Parse(item["pag_amount"].ToString());
                                //aolistrpt_502.Insert(posety, aoety_exist);
                            }
                            else
                            {
                                aolistrpt_502.Add(new view_rpt_BANCOS()
                                {
                                    fecha = DateTime.Parse(item["fecha"].ToString()),
                                    nodoc = item["nodoc"].ToString(),
                                    numcom = item["numcom"].ToString(),
                                    Beneficiario = item["Beneficiario"].ToString(),
                                    Concepto01 = item["Concepto01"].ToString().TrimEnd()+" "+ item["Concepto02"].ToString().TrimStart(),
                                    Concepto02 = item["Concepto02"].ToString(),
                                    tasaC = Decimal.Parse(item["tasaC"].ToString()),
                                    valche = Decimal.Parse(item["valche"].ToString()),
                                    MTO_C = Decimal.Parse(item["MTO_C"].ToString()),
                                    MTO_D = Decimal.Parse(item["MTO_D"].ToString()),
                                    tmoneda = item["tmoneda"].ToString(),
                                    aplicado = item["aplicado"].ToString(),
                                    cuenco = item["cuenco"].ToString(),
                                    Banco = item["Banco"].ToString(),
                                });
                            }
                        }

                        mpxCloseSplashForm();
                        if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                        {
                            // Imprimimos el reporte
                            Reports.CZF.rptBanco aorpt_105 = new Reports.CZF.rptBanco();
                            aorpt_105.mpxSetTittle(patittle01, patittle02, "Mes de " + strMonthName, strMonthName);
                            //if (aofiltroind_solofactpendientes)
                            //{
                            //    aorpt_105.DataSource = aolistrpt_105.Where(x => x.sdototd > 0).ToList();
                            //    aorpt_105.GroupHeader1.PageBreak = DevExpress.XtraReports.UI.PageBreak.None;
                            //}
                            //else
                            //{
                                aorpt_105.DataSource = aolistrpt_502;
                            //}

                            //aorpt.picLogo.Image = VisorFacturas.Properties.Resources.CZF_Logo;
                            aofrmviewer = new frmviewer(aorpt_105);
                            aofrmviewer.Text = aoNombreReporte;
                            aofrmviewer.MdiParent = this.MdiParent;
                            aofrmviewer.WindowState = FormWindowState.Maximized;
                            aofrmviewer.Show();
                        }
                        else
                        {
                            // Imprimimos el reporte
                            Reports.CNZF.rptBanco aorpt_105 = new Reports.CNZF.rptBanco();
                            aorpt_105.mpxSetTittle(patittle01, patittle02, "Mes de " + strMonthName, strMonthName);
                            //if (aofiltroind_solofactpendientes)
                            //{
                            //    aorpt_105.DataSource = aolistrpt_502.ToList();
                            //    aorpt_105.GroupHeader1.PageBreak = DevExpress.XtraReports.UI.PageBreak.None;
                            //}
                            //else
                            //{
                            aorpt_105.DataSource = aolistrpt_502;
                            //}

                            //aorpt.picLogo.Image = VisorFacturas.Properties.Resources.CZF_Logo;
                            aofrmviewer = new frmviewer(aorpt_105);
                            aofrmviewer.Text = aoNombreReporte;
                            aofrmviewer.MdiParent = this.MdiParent;
                            aofrmviewer.WindowState = FormWindowState.Maximized;
                            aofrmviewer.Show();
                        }
                        #endregion
                        break;
                        
                }

            }
            catch (Exception ex)
            {
                mpxCloseSplashForm();
                XtraMessageBox.Show(ex.Message, "Mensaje del Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Mandamos a cargar los datos de las tablas DBF
        /// </summary>
        private void mpxCargarDatosTablasDBF(string SqlEmpleadoCZF)
        {
            // Cadena de conexion            
            String aorutadiractfij = "";
            if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
            {
                mocadenaconexOLEDB = String.Format(@"Provider=VFPOLEDB.1;Data Source={0}; Extended Properties = dBase IV", Settings.Default.DirectorioCZF_TablasBANCO);
                aorutadiractfij = Settings.Default.DirectorioActivosFijosCZF;
            }
            else if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CNZF)
            {
                mocadenaconexOLEDB = String.Format(@"Provider=VFPOLEDB.1;Data Source={0}; Extended Properties = dBase IV", Settings.Default.DirectorioCNZF_TablasBANCO);
                aorutadiractfij = Settings.Default.DirectorioActivosFijosCNZF;
            }
            //Mandamos a cargar
            using (OleDbConnection dbConn = new OleDbConnection(mocadenaconexOLEDB))
            {
                try
                {
                    dbConn.Open();

                    // Cargamos los Empleados a la tabla del DATASET: TSECTION
                    if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                    {
                        command = new OleDbCommand(SqlEmpleadoCZF, dbConn);
                        command.CommandType = CommandType.Text;
                        adapter = new OleDbDataAdapter(command);
                        adapter.Fill(acDT_temp);
                    }
                    else
                    {
                        command = new OleDbCommand(SqlEmpleadoCZF, dbConn);

                        command.CommandType = CommandType.Text;
                        adapter = new OleDbDataAdapter(command);
                        adapter.Fill(acDT_temp);
                    }


                    //if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                    //{
                    //    // Llenamos el Grid Empleados
                    //    ListEmpleados = (from emp in tbl_EMPLEADO.AsQueryable()
                    //                         //join dep in tbl_DEPART.AsQueryable() on emp.c equals dep.codigo
                    //                         //join dep in tbl_DEPART.AsQueryable() on new { X1 = dep.codigo, X2 = m.uidemplea } equals new { X1 = aoemp.uidcia, X2 = aoemp.uidemplea }
                    //                     select new viewEmpleados
                    //                     {
                    //                         c_codigo = (emp.c + emp.codigo),
                    //                         nombre = emp.nombre,
                    //                         cargo = emp.descrip,
                    //                         c = emp.c,
                    //                         codigo = emp.codigo,
                    //                         //departamento = dep.descrip,
                    //                         departamento = emp.Depart,
                    //                         d = emp.d
                    //                     }).ToList();
                    //}
                    //else
                    //{
                    //    // Llenamos el Grid Empleados
                    //    ListEmpleados = (from emp in tbl_EMPLEADO.AsQueryable()
                    //                     join dep in tbl_DEPART.AsQueryable() on emp.c equals dep.codigo
                    //                     //join dep in tbl_DEPART.AsQueryable() on new { X1 = dep.codigo, X2 = m.uidemplea } equals new { X1 = aoemp.uidcia, X2 = aoemp.uidemplea }
                    //                     select new viewEmpleados
                    //                     {
                    //                         c_codigo = (emp.c + emp.codigo),
                    //                         nombre = emp.nombre,
                    //                         cargo = emp.descrip,
                    //                         c = emp.c,
                    //                         codigo = emp.codigo,
                    //                         departamento = dep.descrip,
                    //                         //departamento = emp.Depart,
                    //                         d = emp.d
                    //                     }).ToList();
                    //}

                                        

                    dbConn.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir la base de datos" + ex.Message);
                }
            }
        }
        private void mpxShowSplashForm()
        {
            if (msplashfrm_wait.IsSplashFormVisible)
            {
                msplashfrm_wait.CloseWaitForm();
            }
            msplashfrm_wait.ShowWaitForm();
            msplashfrm_wait.SetWaitFormCaption("Procesando los datos");
            msplashfrm_wait.SetWaitFormDescription("Por favor, espere...");
        }

        private void mpxShowSplashForm(String patitulo, String padescripcion)
        {
            if (msplashfrm_wait.IsSplashFormVisible)
            {
                msplashfrm_wait.CloseWaitForm();
            }
            msplashfrm_wait.ShowWaitForm();
            msplashfrm_wait.SetWaitFormCaption(patitulo);
            msplashfrm_wait.SetWaitFormDescription(padescripcion);
        }

        private void mpxCloseSplashForm()
        {
            if (msplashfrm_wait.IsSplashFormVisible == true)
            {
                msplashfrm_wait.CloseWaitForm();
            }
        }

        private List<view_rpt_saldoclientes> mpxFillListRPT104(Decimal paTasaCambio)
        {
            List<view_rpt_saldoclientes> aolistrpt = new List<view_rpt_saldoclientes>();

            #region CODIGO PARA PASAR DATOS DEL DATATABLE A UNA LISTA
            //// Pasamos
            //acDT_temp.AsEnumerable().ToList().ForEach(s => aolistrpt_104.Add(new view_rpt_saldoclientes() { 
            //    fac_numfac = s["fac_numfac"].ToString(),
            //    fac_fecha = DateTime.Parse(s["fac_fecha"].ToString()),
            //    cli_cod = s["cli_cod"].ToString(),
            //    cli_nombre = s["cli_nombre"].ToString(),
            //    tipo_regimen = s["tipo_reg"].ToString(),
            //    factotd = Decimal.Parse(s["factotd"].ToString()),
            //    factotc = Decimal.Parse(s["factotc"].ToString()),
            //    pag_numroc = s["pag_numroc"].ToString(),
            //    pag_fecha = s["pag_fecha"] != null ? DateTime.Parse(s["pag_fecha"].ToString()) : new DateTime(),
            //    pag_totd = Decimal.Parse(s["pag_totd"].ToString()),
            //    pag_totc = Decimal.Parse(s["pag_totc"].ToString()),
            //    sdototd = Decimal.Parse(s["sdo_totd"].ToString()),
            //    sdototc = Decimal.Parse(s["sdo_totc"].ToString()),
            //    sdototccalc = Decimal.Parse(s["sdo_totccalc"].ToString()),
            //    sdo_30 = Decimal.Parse(s["sdo_30"].ToString()),
            //    sdo_60 = Decimal.Parse(s["sdo_60"].ToString()),
            //    sdo_90 = Decimal.Parse(s["sdo_90"].ToString()),
            //    sdo_mas90 = Decimal.Parse(s["sdo_mas90"].ToString()),
            //    dias = int.Parse(s["dias"].ToString())
            //}));

            //var lst_repetidos = (from t in aolistrpt_104.AsQueryable()
            //                     group t by t.fac_numfac into t_group
            //                   where t_group.Count() > 1
            //                     select new
            //                     {
            //                         fac_numfac = Convert.ToInt32(t_group.Key),
            //                         Count = t_group.Count(),
            //                     }).OrderBy(x => x.fac_numfac).ToList();
            #endregion

            view_rpt_saldoclientes aoety_exist_ant = new view_rpt_saldoclientes();
            view_rpt_saldoclientes aoety_exist_act = new view_rpt_saldoclientes();
            double aodifday = 0;
            // Rellenamos la lista que se enviara al reporte
            foreach (DataRow item in acDT_temp.Rows)
            {
                //// Para prueba
                //if (Convert.ToInt32(item["fac_numfac"]) == 4788)
                //{
                //    MessageBox.Show("Test");
                //}

                // Si se repite el numero de Factura, quiere decir que se hizo mas de un recibo para pagar la factura
                if (Convert.ToInt32(aoety_exist_ant.fac_numfac) == Convert.ToInt32(item["fac_numfac"]))
                {
                    // Si el Numero de Fact ya existe en la lista, solo sumamos en la entidad existente los valores de la tabla PAGOS
                    aoety_exist_act = aoety_exist_ant; //aoexistregistro[0];

                    // Esto lo hacemos para ver donde se revive el saldo en la antiguedad
                    aodifday = Math.Abs((aoety_exist_act.fac_fecha - aofiltro_mesyearfin).TotalDays / 30.4166);

                    aoety_exist_act.pag_numroc += Environment.NewLine + item["pag_numroc"].ToString();
                    aoety_exist_act.pag_fecha += Environment.NewLine + DateTime.Parse(item["pag_fecha"].ToString()).ToString("dd/MM/yyyy");
                    aoety_exist_act.pag_totd += Decimal.Parse(item["pag_totd"].ToString());
                    aoety_exist_act.sdototd -= Decimal.Parse(item["pag_totd"].ToString());

                    // Esto lo hacemos porque hay registros de pagos que superan al monto de la factura por centavos,
                    // entonces para evitar que queden saldos en negativos, seteamos a cero los saldos
                    if (aoety_exist_act.sdototd <= 0)
                    {
                        aoety_exist_act.sdototccalc = 0;
                        aoety_exist_act.sdototc = 0;
                        aoety_exist_act.sdo_30 = 0;
                        aoety_exist_act.sdo_60 = 0;
                        aoety_exist_act.sdo_90 = 0;
                        aoety_exist_act.sdo_mas90 = 0;
                    }
                    /*****************************************************************************************************/
                    /* Este bloque else if sirve por el tema de la depuracion de contab (centavos que se acarreaban en el saldo). Como eso pasaba en las facturas viejas,
                     * se añadió el filtro de que todas las facturas que tengan saldo menor a $1 y que se emitieron antes del 2018, se pondran en cero el saldo*/
                    /*****************************************************************************************************/
                    else if ((aoety_exist_act.sdototd > 0 && aoety_exist_act.sdototd <= (decimal)0.99) && (aoety_exist_act.fac_fecha.Year < 2018))
                    {
                        aoety_exist_act.sdototd = 0;
                        aoety_exist_act.sdototccalc = 0;
                        aoety_exist_act.sdototc = 0;
                        aoety_exist_act.sdo_30 = 0;
                        aoety_exist_act.sdo_60 = 0;
                        aoety_exist_act.sdo_90 = 0;
                        aoety_exist_act.sdo_mas90 = 0;
                    }
                    else
                    {
                        aoety_exist_act.sdototccalc = aoety_exist_act.sdototd * paTasaCambio;
                        if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CNZF)
                        {
                            if (aodifday <= 1)
                                aoety_exist_act.sdo_30 -= Decimal.Parse(item["pag_totd"].ToString());
                            else if (aodifday > 1 && aodifday <= 2)
                                aoety_exist_act.sdo_60 -= Decimal.Parse(item["pag_totd"].ToString());
                            else if (aodifday > 2 && aodifday <= 3)
                                aoety_exist_act.sdo_90 -= Decimal.Parse(item["pag_totd"].ToString());
                            else
                                aoety_exist_act.sdo_mas90 -= Decimal.Parse(item["pag_totd"].ToString());
                        }
                        else
                        {
                            aoety_exist_act.sdo_90 = 0;

                            if (aodifday <= 1)
                                aoety_exist_act.sdo_30 -= Decimal.Parse(item["pag_totd"].ToString());
                            else if (aodifday > 1 && aodifday <= 2)
                                aoety_exist_act.sdo_60 -= Decimal.Parse(item["pag_totd"].ToString());
                            //else if (aodifday > 2 && aodifday <= 3)
                            //    aoety_exist_act.sdo_90 -= Decimal.Parse(item["pag_totd"].ToString());
                            else
                                aoety_exist_act.sdo_mas90 -= Decimal.Parse(item["pag_totd"].ToString());
                        }
                    }                        

                }
                else
                {
                    // Si el Numero de Fact NO existe, lo agregamos a la Lista
                    aoety_exist_act = new view_rpt_saldoclientes()
                    {
                        fac_numfac = item["fac_numfac"].ToString(),
                        fac_fecha = DateTime.Parse(item["fac_fecha"].ToString()),
                        cli_cod = item["cli_cod"].ToString(),
                        cli_nombre = item["cli_nombre"].ToString(),
                        tipo_regimen = item["tipo_reg"].ToString(),
                        factotd = Decimal.Parse(item["factotd"].ToString()),
                        pag_numroc = item["pag_numroc"].ToString(),
                        pag_fecha = Convert.ToDateTime(item["pag_fecha"]).ToString("dd/MM/yyyy"),
                        pag_totd = Decimal.Parse(item["pag_totd"].ToString()),
                        sdototd = 0,
                        sdototccalc = 0,
                        sdo_30 = 0,
                        sdo_60 = 0,
                        sdo_90 = 0,
                        sdo_mas90 = 0,
                        sdo_antd = 0,
                        sdo_actd = 0
                    };

                    // Esto lo hacemos para ver donde se revive el saldo en la antiguedad
                    aodifday = Math.Abs((aoety_exist_act.fac_fecha - aofiltro_mesyearfin).TotalDays / 30.4166);

                    // Revivimos el saldo de esa factura en caso de que tenga
                    aoety_exist_act.sdototd = aoety_exist_act.factotd - aoety_exist_act.pag_totd;

                    // Esto lo hacemos porque hay registros de pagos que superan al monto de la factura por centavos,
                    // entonces para evitar que queden saldos en negativos, seteamos a cero los saldos
                    if (aoety_exist_act.sdototd <= 0)
                    {
                        aoety_exist_act.sdototccalc = 0;
                        aoety_exist_act.sdototc = 0;
                        aoety_exist_act.sdo_30 = 0;
                        aoety_exist_act.sdo_60 = 0;
                        aoety_exist_act.sdo_90 = 0;
                        aoety_exist_act.sdo_mas90 = 0;
                    }
                    /*****************************************************************************************************/
                    /* Este bloque else if sirve por el tema de la depuracion de contab (centavos que se acarreaban en el saldo). Como eso pasaba en las facturas viejas,
                     * se añadió el filtro de que todas las facturas que tengan saldo menor a $1 y que se emitieron antes del 2018, se pondran en cero el saldo*/
                    /*****************************************************************************************************/
                    else if ((aoety_exist_act.sdototd > 0 && aoety_exist_act.sdototd <= (decimal)0.99) && (aoety_exist_act.fac_fecha.Year < 2018))
                    {
                        aoety_exist_act.sdototd = 0;
                        aoety_exist_act.sdototccalc = 0;
                        aoety_exist_act.sdototc = 0;
                        aoety_exist_act.sdo_30 = 0;
                        aoety_exist_act.sdo_60 = 0;
                        aoety_exist_act.sdo_90 = 0;
                        aoety_exist_act.sdo_mas90 = 0;
                    }
                    else
                    {
                        aoety_exist_act.sdototccalc = aoety_exist_act.sdototd * paTasaCambio;
                        
                        if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CNZF)
                        {
                            if (aodifday <= 1)
                                aoety_exist_act.sdo_30 = aoety_exist_act.sdototd;
                            else if (aodifday > 1 && aodifday <= 2)
                                aoety_exist_act.sdo_60 = aoety_exist_act.sdototd;
                            else if (aodifday > 2 && aodifday <= 3)
                                aoety_exist_act.sdo_90 = aoety_exist_act.sdototd;
                            else
                                aoety_exist_act.sdo_mas90 = aoety_exist_act.sdototd;
                        }
                        else
                        {
                            aoety_exist_act.sdo_90 = 0;

                            if (aodifday <= 1)
                                aoety_exist_act.sdo_30 = aoety_exist_act.sdototd;
                            else if (aodifday > 1 && aodifday <= 2)
                                aoety_exist_act.sdo_60 = aoety_exist_act.sdototd;
                            //else if (aodifday > 2 && aodifday <= 3)
                            //    aoety_exist_act.sdo_90 = aoety_exist_act.sdototd;
                            else
                                aoety_exist_act.sdo_mas90 = aoety_exist_act.sdototd;
                        }
                    }

                    // Formateamos la fecha
                    aoety_exist_act.pag_fecha = Convert.ToDateTime(aoety_exist_act.pag_fecha).Year < 2000 ? "" : Convert.ToDateTime(aoety_exist_act.pag_fecha).ToString("dd/MM/yyyy");
                    
                    aolistrpt.Add(aoety_exist_act); // Agregamos el registro a la Lista
                }

                // El registro actual pasa a ser el anterior
                aoety_exist_ant = aoety_exist_act;
            }

            return aolistrpt;
        }

        private List<view_rpt_saldoclientes> mpxFillListRPT105(Decimal paTasaCambio)
        {
            List<view_rpt_saldoclientes> aolistrpt = new List<view_rpt_saldoclientes>();

            #region CODIGO PARA PASAR DATOS DEL DATATABLE A UNA LISTA
            //// Pasamos
            //acDT_temp.AsEnumerable().ToList().ForEach(s => aolistrpt_104.Add(new view_rpt_saldoclientes() { 
            //    fac_numfac = s["fac_numfac"].ToString(),
            //    fac_fecha = DateTime.Parse(s["fac_fecha"].ToString()),
            //    cli_cod = s["cli_cod"].ToString(),
            //    cli_nombre = s["cli_nombre"].ToString(),
            //    tipo_regimen = s["tipo_reg"].ToString(),
            //    factotd = Decimal.Parse(s["factotd"].ToString()),
            //    factotc = Decimal.Parse(s["factotc"].ToString()),
            //    pag_numroc = s["pag_numroc"].ToString(),
            //    pag_fecha = s["pag_fecha"] != null ? DateTime.Parse(s["pag_fecha"].ToString()) : new DateTime(),
            //    pag_totd = Decimal.Parse(s["pag_totd"].ToString()),
            //    pag_totc = Decimal.Parse(s["pag_totc"].ToString()),
            //    sdototd = Decimal.Parse(s["sdo_totd"].ToString()),
            //    sdototc = Decimal.Parse(s["sdo_totc"].ToString()),
            //    sdototccalc = Decimal.Parse(s["sdo_totccalc"].ToString()),
            //    sdo_30 = Decimal.Parse(s["sdo_30"].ToString()),
            //    sdo_60 = Decimal.Parse(s["sdo_60"].ToString()),
            //    sdo_90 = Decimal.Parse(s["sdo_90"].ToString()),
            //    sdo_mas90 = Decimal.Parse(s["sdo_mas90"].ToString()),
            //    dias = int.Parse(s["dias"].ToString())
            //}));

            //var lst_repetidos = (from t in aolistrpt_104.AsQueryable()
            //                     group t by t.fac_numfac into t_group
            //                   where t_group.Count() > 1
            //                     select new
            //                     {
            //                         fac_numfac = Convert.ToInt32(t_group.Key),
            //                         Count = t_group.Count(),
            //                     }).OrderBy(x => x.fac_numfac).ToList();
            #endregion

            view_rpt_saldoclientes aoety_exist_ant = new view_rpt_saldoclientes();
            view_rpt_saldoclientes aoety_exist_act = new view_rpt_saldoclientes();
            double aodifday = 0;
            int aoregistrocount = 0;
            // Rellenamos la lista que se enviara al reporte
            foreach (DataRow item in acDT_temp.Rows)
            {
                aoregistrocount++;

                // Preguntamos si el primer registro es el saldo inicial
                if (Convert.ToInt16(item["fac_debe"]) != 7 && aoregistrocount == 1) // le puse el 7 para identificar que el primer registro tiene que ser el saldo inicial
                {
                    // Si entra es por que este cliente no tiene registro de facturas en ese período, 
                    // entonces procedemos a crearle el registro de saldo inicial

                    // Primero buscamos al cliente
                    viewClientes aocliente = aoclientes_lst.FirstOrDefault(s => s.cli_cod.Trim() == item["cli_cod"].ToString().Trim());
                    if (aocliente != null)
                    {
                        aoety_exist_act.cli_cod = aocliente.cli_cod;
                        aoety_exist_act.cli_nombre = aocliente.cli_nom;
                        aoety_exist_act.tipo_regimen = aocliente.cli_regimen;
                        aoety_exist_act.concept = "Saldo Inicial:";
                        aoety_exist_act.fac_fecha = new DateTime(1999, 12, 31);
                        aoety_exist_act.fac_numfac = "";
                        aoety_exist_act.factotd = 0;
                        aoety_exist_act.pag_totd = 0;
                        aoety_exist_act.pag_numroc = "";
                        aoety_exist_act.pag_fecha = "";
                        aoety_exist_act.fac_debe = 7;
                        aoety_exist_act.sdototc = 0;
                        aoety_exist_act.sdototccalc = 0;
                        aoety_exist_act.sdototd = 0;
                        aoety_exist_act.sdo_30 = 0;
                        aoety_exist_act.sdo_60 = 0;
                        aoety_exist_act.sdo_90 = 0;
                        aoety_exist_act.sdo_mas90 = 0;

                        aolistrpt.Add(aoety_exist_act);
                        aoety_exist_act = new view_rpt_saldoclientes();
                    }
                }

                //// Para prueba
                //if (Convert.ToInt32(item["fac_numfac"]) == 36197)
                //{
                //    MessageBox.Show("Test");
                //}

                // Si se repite el numero de Factura, quiere decir que se hizo mas de un recibo para pagar la factura
                if (Convert.ToInt32(aoety_exist_ant.fac_numfac) == Convert.ToInt32(item["fac_numfac"]))
                {
                    // Si el Numero de Fact ya existe en la lista, solo sumamos en la entidad existente los valores de la tabla PAGOS
                    aoety_exist_act = aoety_exist_ant; //aoexistregistro[0];

                    // Esto lo hacemos para ver donde se revive el saldo en la antiguedad
                    aodifday = Math.Abs((aoety_exist_act.fac_fecha - aofiltro_mesyearfin).TotalDays / 30.4166);

                    aoety_exist_act.pag_numroc += Environment.NewLine + item["pag_numroc"].ToString();
                    aoety_exist_act.pag_fecha += Environment.NewLine + DateTime.Parse(item["pag_fecha"].ToString()).ToString("dd/MM/yyyy");
                    aoety_exist_act.pag_totd += Decimal.Parse(item["pag_totd"].ToString());
                    aoety_exist_act.sdototd -= Decimal.Parse(item["pag_totd"].ToString());                    

                    // Esto lo hacemos porque hay registros de pagos que superan al monto de la factura por centavos,
                    // entonces para evitar que queden saldos en negativos, seteamos a cero los saldos
                    if (aoety_exist_act.sdototd <= 0)
                    {
                        aoety_exist_act.sdototccalc = 0;
                        aoety_exist_act.sdototc = 0;
                        aoety_exist_act.sdo_30 = 0;
                        aoety_exist_act.sdo_60 = 0;
                        aoety_exist_act.sdo_90 = 0;
                        aoety_exist_act.sdo_mas90 = 0;
                    }
                    else
                    {
                        aoety_exist_act.sdototccalc = aoety_exist_act.sdototd * paTasaCambio;

                        if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CNZF)
                        {
                            if (aodifday <= 1)
                                aoety_exist_act.sdo_30 -= Decimal.Parse(item["pag_totd"].ToString());
                            else if (aodifday > 1 && aodifday <= 2)
                                aoety_exist_act.sdo_60 -= Decimal.Parse(item["pag_totd"].ToString());
                            else if (aodifday > 2 && aodifday <= 3)
                                aoety_exist_act.sdo_90 -= Decimal.Parse(item["pag_totd"].ToString());
                            else
                                aoety_exist_act.sdo_mas90 -= Decimal.Parse(item["pag_totd"].ToString());
                        }
                        else
                        {
                            aoety_exist_act.sdo_90 = 0;

                            if (aodifday <= 1)
                                aoety_exist_act.sdo_30 -= Decimal.Parse(item["pag_totd"].ToString());
                            else if (aodifday > 1 && aodifday <= 2)
                                aoety_exist_act.sdo_60 -= Decimal.Parse(item["pag_totd"].ToString());
                            //else if (aodifday > 2 && aodifday <= 3)
                            //    aoety_exist_act.sdo_90 -= Decimal.Parse(item["pag_totd"].ToString());
                            else
                                aoety_exist_act.sdo_mas90 -= Decimal.Parse(item["pag_totd"].ToString());
                        }    
                    }

                }
                else
                {
                    // Si el Numero de Fact NO existe, lo agregamos a la Lista
                    aoety_exist_act = new view_rpt_saldoclientes()
                    {
                        fac_numfac = item["fac_numfac"].ToString(),
                        fac_fecha = DateTime.Parse(item["fac_fecha"].ToString()),
                        cli_cod = item["cli_cod"].ToString(),
                        cli_nombre = item["cli_nombre"].ToString(),
                        tipo_regimen = item["tipo_reg"].ToString(),
                        factotd = Decimal.Parse(item["factotd"].ToString()),
                        pag_numroc = item["pag_numroc"].ToString(),
                        pag_fecha = Convert.ToDateTime(item["pag_fecha"]).ToString("dd/MM/yyyy"),
                        pag_totd = Decimal.Parse(item["pag_totd"].ToString()),
                        sdototd = 0,
                        sdototccalc = 0,
                        sdo_30 = 0,
                        sdo_60 = 0,
                        sdo_90 = 0,
                        sdo_mas90 = 0,
                        sdo_antd = 0,
                        sdo_actd = 0,
                        concept = item["concept"].ToString(),
                        fac_debe = Convert.ToInt16(item["fac_debe"])
                    };

                    // Esto lo hacemos para ver donde se revive el saldo en la antiguedad
                    aodifday = Math.Abs((aoety_exist_act.fac_fecha - aofiltro_mesyearfin).TotalDays / 30.4166);

                    // Revivimos el saldo de esa factura en caso de que tenga
                    aoety_exist_act.sdototd = aoety_exist_act.factotd - aoety_exist_act.pag_totd;

                    // Preguntamos si en la query viene el saldo inicial, si es así, después de haber calculado el sdototD,
                    // limpiamos el factotd y el pag_totd para q no sumen en el reporte de estado de cuenta
                    if (aoety_exist_act.fac_debe == 7 && aoregistrocount == 1)
                    {
                        aoety_exist_act.factotd = 0;
                        aoety_exist_act.pag_totd = 0;
                    }

                    // Esto lo hacemos porque hay registros de pagos que superan al monto de la factura por centavos,
                    // entonces para evitar que queden saldos en negativos, seteamos a cero los saldos
                    if (aoety_exist_act.sdototd <= 0)
                    {
                        aoety_exist_act.sdototccalc = 0;
                        aoety_exist_act.sdototc = 0;
                        aoety_exist_act.sdo_30 = 0;
                        aoety_exist_act.sdo_60 = 0;
                        aoety_exist_act.sdo_90 = 0;
                        aoety_exist_act.sdo_mas90 = 0;
                    }
                    else
                    {
                        aoety_exist_act.sdototccalc = aoety_exist_act.sdototd * paTasaCambio;
                        if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CNZF)
                        {
                            if (aodifday <= 1)
                                aoety_exist_act.sdo_30 = aoety_exist_act.sdototd;
                            else if (aodifday > 1 && aodifday <= 2)
                                aoety_exist_act.sdo_60 = aoety_exist_act.sdototd;
                            else if (aodifday > 2 && aodifday <= 3)
                                aoety_exist_act.sdo_90 = aoety_exist_act.sdototd;
                            else
                                aoety_exist_act.sdo_mas90 = aoety_exist_act.sdototd;
                        }
                        else
                        {
                            aoety_exist_act.sdo_90 = 0;

                            if (aodifday <= 1)
                                aoety_exist_act.sdo_30 = aoety_exist_act.sdototd;
                            else if (aodifday > 1 && aodifday <= 2)
                                aoety_exist_act.sdo_60 = aoety_exist_act.sdototd;
                            //else if (aodifday > 2 && aodifday <= 3)
                            //    aoety_exist_act.sdo_90 = aoety_exist_act.sdototd;
                            else
                                aoety_exist_act.sdo_mas90 = aoety_exist_act.sdototd;
                        }
                    }

                    // Formateamos la fecha
                    aoety_exist_act.pag_fecha = Convert.ToDateTime(aoety_exist_act.pag_fecha).Year < 2000 ? "" : Convert.ToDateTime(aoety_exist_act.pag_fecha).ToString("dd/MM/yyyy");

                    aolistrpt.Add(aoety_exist_act); // Agregamos el registro a la Lista
                }

                // El registro actual pasa a ser el anterior
                aoety_exist_ant = aoety_exist_act;
            }

            return aolistrpt;
        }

        #endregion


    }
}