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
        // Variables globales
        short aomes_entero;
        string aomes_cadena;
        short aoanyo_entero;
        string aoNombreReporte;
        string aoCodReporte;
        short aoidximage;

        public frmSistInfCNZF(tblUser pocurrentuser)
        {
            InitializeComponent();
        }

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

        private void mpxSalir()
        {
            this.Close();
            this.Dispose();
        }

        private void mpxHideControls()
        {
            mlytitm_speanno.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            mlytitm_cmbMes.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            mlytitm_pagostiemporeal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            mlcg_filtros.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            mempty_filtros.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void mpxShowControls(string paReportCod)
        {
            mpxHideControls();

            switch (paReportCod)
            {
                case "RPT101":                    
                    mlytitm_speanno.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    mlytitm_cmbMes.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    mlytitm_pagostiemporeal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                    mlcg_filtros.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    mempty_filtros.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    break;                    
            }
        }

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

                if (String.IsNullOrEmpty(aoCodReporte))
                {
                    XtraMessageBox.Show("Debe seleccionar un reporte", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Identificamos que reporte vamos a imprimir para asignar la query SQL
                switch (aoCodReporte)
                {
                    case "RPT101":
                        List<view_rpt_facturasmes> aolistrpt = new List<view_rpt_facturasmes>();
                        if (mchk_pagostiemporeal.Checked)
                        {
                            acSql = String.Format(Resources.xr_proc_facturas_mes, aoanyo_entero, aomes_entero, "");                            
                        }
                        else
                        {
                            string aoSentenciaAND = "AND YEAR(PAG.pg_fecpag) = " + aoanyo_entero.ToString() + " AND MONTH(PAG.pg_fecpag) = " + aomes_entero.ToString();
                            acSql = String.Format(Resources.xr_proc_facturas_mes, aoanyo_entero, aomes_entero, aoSentenciaAND);
                        }                        
                        
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
                            List<view_rpt_facturasmes> aoexistregistro = new List<view_rpt_facturasmes>();
                            aoexistregistro = (from t in aolistrpt.AsQueryable()
                                               where t.fac_numfac.Trim() == item["fac_numfac"].ToString().Trim()
                                               select t).ToList();

                            if (aoexistregistro.Count > 0)
                            {
                                view_rpt_facturasmes aoety_exist = aoexistregistro[0];
                                Int32 posety = aolistrpt.IndexOf(aoety_exist);
                                aolistrpt.RemoveAt(posety);

                                aoety_exist.pag_numroc += Environment.NewLine + item["pag_numroc"].ToString();
                                aoety_exist.pag_fecha = DateTime.Parse(item["pag_fecha"].ToString());
                                aoety_exist.pag_amount += Double.Parse(item["pag_amount"].ToString());
                                aolistrpt.Insert(posety, aoety_exist);
                            }
                            else
                            {
                                aolistrpt.Add(new view_rpt_facturasmes()
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

                        Reports.CNZF.xrfacturasmes aorpt = new Reports.CNZF.xrfacturasmes();
                        aorpt.DataSource = aolistrpt;
                        aorpt.mpxSetTittle("", "Año: " + aoanyo_entero.ToString() + "  Mes: " + aomes_cadena + "  Moneda: Dólares (US$)");
                        //aorpt.picLogo.Image = VisorFacturas.Properties.Resources.CZF_Logo;
                        frmviewer aofrmviewer = new frmviewer(aorpt);
                        aofrmviewer.Text = aoNombreReporte + " - " + aomes_cadena + " " + aoanyo_entero.ToString();
                        aofrmviewer.MdiParent = this.MdiParent;
                        aofrmviewer.WindowState = FormWindowState.Maximized;
                        aofrmviewer.Show();

                        break;    
                }

                // Ejecutamos la query SQL para rellenar los datos
                switch (aoCodReporte)
                {
                    case "RPT101":
                        
                        break;
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Mensaje del Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}