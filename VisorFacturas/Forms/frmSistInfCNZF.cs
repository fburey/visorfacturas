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

namespace VisorFacturas.Forms
{
    public partial class frmSistInfCNZF : DevExpress.XtraEditors.XtraForm
    {
        public frmSistInfCNZF(tblUser pocurrentuser)
        {
            InitializeComponent();
        }

        #region VARIABLES GLOBALES  
        // Variables globales
        short aomes_entero;
        string aomes_cadena;
        short aoanyo_entero;
        string aoNombreReporte;
        string aoCodReporte;
        short aoidximage;
        #endregion

        #region EVENTOS

        private void frmSistInfCNZF_Load(object sender, EventArgs e)
        {
            // Poblamos el TreeList
            mtree_bndsrc.DataSource = Util.clsTreeListSistInf.mfxGetTreeList();
            mtree_sistinf.ExpandAll();

            // Valores por defecto
            speAnno.Value = DateTime.Now.Year;
            cmbMes.SelectedIndex = DateTime.Now.Month - 1;

        }

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

        #endregion

        #region METODOS Y FUNCIONES

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
            mlytitm_speanno.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            mlytitm_pagostiemporeal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            mempty_speanno.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            mlytitm_cmbMes.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            mlytitm_comparamesanyoant.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            mempty_cmbmes.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            // Ocultamos el Grupo filtro y el espacio en blanco a la derecha
            mlcg_filtros.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            mempty_filtros.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
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
                    mlytitm_speanno.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    mlytitm_pagostiemporeal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    mempty_speanno.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                    mlytitm_cmbMes.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    mempty_cmbmes.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                    // Mostramos el Grupo filtro y el espacio en blanco a la derecha
                    mlcg_filtros.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    mempty_filtros.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    break;

                case "RPT102":
                    mlytitm_speanno.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    mempty_speanno.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                    mlcg_filtros.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    mempty_filtros.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    break;

                case "RPT103":
                    mlytitm_speanno.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    mempty_speanno.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                    mlytitm_cmbMes.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    mlytitm_comparamesanyoant.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    mempty_cmbmes.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                    // Mostramos el Grupo filtro y el espacio en blanco a la derecha
                    mlcg_filtros.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    mempty_filtros.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    break;
            }
        }

        /// <summary>
        /// Visualiza el reporte seleccionado
        /// </summary>
        private void mpxImprimir()
        {
            try
            {
                // Declaramos las variables locales
                string acSql = "";
                DataTable acDT_temp = new DataTable();

                // Asignamos el valor de las variables
                aoanyo_entero = (short)speAnno.Value;
                aomes_entero = Convert.ToInt16(cmbMes.SelectedIndex + 1);
                aomes_cadena = cmbMes.Text.Trim();

                short aoanyo_entero_ANT = 0;
                short aoMES_entero_ANT = 0;
                string aotittle2 = "";

                if (String.IsNullOrEmpty(aoCodReporte))
                {
                    XtraMessageBox.Show("Debe seleccionar un reporte", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Identificamos que reporte vamos a imprimir para asignar la query SQL
                switch (aoCodReporte)
                {
                    case "RPT101":
                        #region RPT101          
                        // Creamos la lista del reporte a imprimir
                        List<view_rpt_facturasmes> aolistrpt_101 = new List<view_rpt_facturasmes>();
                        // Preguntamos si esta seleccionado los pagos hasta el dia de hoy
                        if (mchk_pagostiemporeal.Checked)
                        {
                            acSql = String.Format(Resources.xr_proc_facturas_mes, aoanyo_entero, aomes_entero, "");                            
                        }
                        else
                        {
                            // Si no está seleccionado, solo mostrará pagos que se hayan efectuados el mismo mes filtrado
                            string aoSentenciaAND = "AND YEAR(PAG.pg_fecpag) = " + aoanyo_entero.ToString() + " AND MONTH(PAG.pg_fecpag) = " + aomes_entero.ToString();
                            acSql = String.Format(Resources.xr_proc_facturas_mes, aoanyo_entero, aomes_entero, aoSentenciaAND);
                        }                        
                        
                        // Hacemos la conexión a las tablas y lo llenamos al DATATABLE Temporal
                        using (OleDbDataAdapter adapt = new OleDbDataAdapter(acSql, Settings.Default.mCnxCNZF_TablasCXC))
                        {
                            adapt.Fill(acDT_temp);                            
                        }

                        if (acDT_temp.Rows.Count == 0)
                        {
                            XtraMessageBox.Show("No se encontraron datos en los filtros especificados", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // Rellenamos la lista que se enviara al reporte
                        foreach (DataRow item in acDT_temp.Rows)
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

                        Reports.CNZF.xrfacturasmes aorpt_101 = new Reports.CNZF.xrfacturasmes();
                        aorpt_101.DataSource = aolistrpt_101;
                        aorpt_101.mpxSetTittle("", "Año: " + aoanyo_entero.ToString() + "  Mes: " + aomes_cadena + "  Moneda: Dólares (US$)");
                        //aorpt.picLogo.Image = VisorFacturas.Properties.Resources.CZF_Logo;
                        frmviewer aofrmviewer = new frmviewer(aorpt_101);
                        aofrmviewer.Text = aoNombreReporte + " - " + aomes_cadena + " " + aoanyo_entero.ToString();
                        aofrmviewer.MdiParent = this.MdiParent;
                        aofrmviewer.WindowState = FormWindowState.Maximized;
                        aofrmviewer.Show();

                        break;
                    #endregion

                    case "RPT102":
                        #region RPT102
                        // Creamos la lista del reporte a imprimir
                        List<view_rpt_metrajeanual> aolistrpt_102 = new List<view_rpt_metrajeanual>();
                        acSql = String.Format(Resources.xr_proc_metraje_anual, aoanyo_entero);

                        // Hacemos la conexión a las tablas y lo llenamos al DATATABLE Temporal
                        using (OleDbDataAdapter adapt = new OleDbDataAdapter(acSql, Settings.Default.mCnxCNZF_TablasCXC))
                        {
                            adapt.Fill(acDT_temp);
                        }

                        if (acDT_temp.Rows.Count == 0)
                        {
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

                        Reports.CNZF.xrmetrajeanual aorpt_102 = new Reports.CNZF.xrmetrajeanual();
                        aorpt_102.DataSource = aolistrpt_102;
                        aorpt_102.mpxSetTittle("", "Año: " + aoanyo_entero.ToString());
                        //aorpt.picLogo.Image = VisorFacturas.Properties.Resources.CZF_Logo;
                        frmviewer aofrmviewer_102 = new frmviewer(aorpt_102);
                        aofrmviewer_102.Text = aoNombreReporte + " - " + aoanyo_entero.ToString();
                        aofrmviewer_102.MdiParent = this.MdiParent;
                        aofrmviewer_102.WindowState = FormWindowState.Maximized;
                        aofrmviewer_102.Show();

                        break;
                    #endregion

                    case "RPT103":
                        #region RPT103

                        // Creamos la lista del reporte a imprimir
                        List<view_rpt_facturacomparames_act_ant> aolistrpt_103 = new List<view_rpt_facturacomparames_act_ant>();
                        // Preguntamos si esta seleccionado el check Comparar Mismo mes Año Actual vs Año Anterior
                        if (mchk_comparamesanyoant.Checked)
                        {
                            aoanyo_entero_ANT = Convert.ToInt16(aoanyo_entero - 1);
                            aoMES_entero_ANT = aomes_entero;
                        }
                        else
                        {
                            // Si no está seleccionado, el reporte comparará Mes Actual y Mes Anterior
                            // Preguntamos si tiene Seleccionado Enero como Mes Actual
                            if (aomes_entero == 1)
                            {
                                aoanyo_entero_ANT = Convert.ToInt16(aoanyo_entero - 1);
                                aoMES_entero_ANT = 12;
                            }
                            else
                            {
                                // Compararemos el Mes Actual vs El mes Anterior del mismo Año
                                aoanyo_entero_ANT = aoanyo_entero;
                                aoMES_entero_ANT = Convert.ToInt16(aomes_entero - 1);
                            }                            
                        }

                        // Creamos la consulta
                        acSql = String.Format(Resources.xr_proc_facturas_compara_mes_act_ant, aoanyo_entero, aomes_entero,
                                                                                                  aoanyo_entero_ANT, aoMES_entero_ANT);

                        // Hacemos la conexión a las tablas y lo llenamos al DATATABLE Temporal
                        using (OleDbDataAdapter adapt = new OleDbDataAdapter(acSql, Settings.Default.mCnxCNZF_TablasCXC))
                        {
                            adapt.Fill(acDT_temp);
                        }

                        if (acDT_temp.Rows.Count == 0)
                        {
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
                                else if (short.Parse(item["fac_yearfact"].ToString()) == aoanyo_entero &&
                                    short.Parse(item["fac_mesfact"].ToString()) == aomes_entero)
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
                                else if (short.Parse(item["fac_yearfact"].ToString()) == aoanyo_entero &&
                                    short.Parse(item["fac_mesfact"].ToString()) == aomes_entero)
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

                        Reports.CNZF.xrfacturacomparames_act_ant aorpt_103 = new Reports.CNZF.xrfacturacomparames_act_ant();
                        aorpt_103.DataSource = aolistrpt_103;
                        aotittle2 = Util.clsApp.mfxMesCadena(aoMES_entero_ANT) + " " + aoanyo_entero_ANT.ToString() + " vs " +
                                    Util.clsApp.mfxMesCadena(aomes_entero) + " " + aoanyo_entero.ToString() + "  Moneda: Dólares (US$)";
                        aorpt_103.mpxSetTittle("", aotittle2, Util.clsApp.mfxMesCadena(aoMES_entero_ANT) + " " + aoanyo_entero_ANT.ToString(),
                            Util.clsApp.mfxMesCadena(aomes_entero) + " " + aoanyo_entero.ToString());
                        //aorpt.picLogo.Image = VisorFacturas.Properties.Resources.CZF_Logo;
                        frmviewer aofrmviewer_103 = new frmviewer(aorpt_103);
                        aofrmviewer_103.Text = aoNombreReporte + " - " + aomes_cadena + " " + aoanyo_entero.ToString();
                        aofrmviewer_103.MdiParent = this.MdiParent;
                        aofrmviewer_103.WindowState = FormWindowState.Maximized;
                        aofrmviewer_103.Show();


                        break;
                        #endregion

                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Mensaje del Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}