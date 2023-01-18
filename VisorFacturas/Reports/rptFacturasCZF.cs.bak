using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using VisorFacturas.Clases;
using VisorFacturas.Enums;
using System.Linq;
using DevExpress.XtraPrinting.Drawing;

namespace VisorFacturas.Reports
{
    public partial class rptFacturasCZF : DevExpress.XtraReports.UI.XtraReport
    {
        List<viewRemision> ListRem;    // Estos son todos los datos de Remision de todas las Facturas
        List<viewRemision> ListRemDet; // Estos son todos los datos de Remision de una Factura (iteración)
        String ord_num;
        String FacturacionMes;
        clsAppEnum moclsAppEnum = new clsAppEnum();
        String FormatoNumerico;
        String TotalFact = "";
        String MonedaFact;
        String SimboloMoneda;

        public rptFacturasCZF(List<viewRemision> List, String padescfact)
        {
            InitializeComponent();
            this.ListRem = List;
            mdetail_bndsrc.DataSource = List;
            FacturacionMes = padescfact;
            xrTableCell_FacturacionMes.Text = FacturacionMes;
        }

        private void GroupHeader1_AfterPrint(object sender, EventArgs e)
        {
            // Obtengo el ord_numero actual
            ord_num = this.GetCurrentColumnValue("ord_numero").ToString();
            // Filtro la Remision de esa Factura
            ListRemDet = ListRem.Where(s => s.rem_numero == ord_num).ToList();
            // Lleno el binding source de Detail (Remision)
            mdetail_bndsrc.DataSource = ListRemDet.ToList();

            // Si tiene descuento muestro el campo de descuento, en caso contrario, se oculta
            if (ListRemDet.AsEnumerable().Sum(o => o.rem_descue) > 0)
                xrtable_descuento.Visible = true;
            else
                xrtable_descuento.Visible = false;

            // Obtenemos la moneda de la factura
            MonedaFact = this.GetCurrentColumnValue("fac_dolcor").ToString();            

            // Obtenemos el formato numérico y total de la fact. conforme la moneda de la factura
            if (MonedaFact.Substring(0, 1).ToUpper() == "D")
            {
                TotalFact = this.GetCurrentColumnValue("fac_amo_do").ToString();
                FormatoNumerico = "{0:U$  #,0.00}";
                SimboloMoneda = "U$";
            }
            else
            {
                TotalFact = this.GetCurrentColumnValue("fac_amount").ToString();
                FormatoNumerico = "{0:C$  #,0.00}";
                SimboloMoneda = "C$";
            }   

            // Obtenemos el valor en letras del monto total de la factura (Params: Monto Total, Moneda)
            xrlabel_ValorEnLetras.Text = moclsAppEnum.enletras(TotalFact, MonedaFact);

            //// Si en el remision_descripcion abarca Directorio Industrial, entonces cambia el campo REVISADO
            //if (ListRemDet.AsEnumerable().Where(s => s.rem_desc.ToLower().Contains("directorio")).ToList().Count > 0)
            //    xrlab_Revisado.Text = "Mauricio Abarca";
            //else
            //    xrlab_Revisado.Text = "";

            ////Formateamos los campos de totales, descuento e IVA
            //xrlab_fac_total_1.DataBindings["Text"].FormatString = FormatoNumerico;
            //xrlab_fac_total_2.DataBindings["Text"].FormatString = FormatoNumerico;
            //xrlab_rem_descue.DataBindings["Text"].FormatString = FormatoNumerico;
            //xrlab_rem_impues.DataBindings["Text"].FormatString = FormatoNumerico;
            xtcmon_sub.Text = SimboloMoneda;
            xtcmon_desc.Text = SimboloMoneda;
            xtcmon_iva.Text = SimboloMoneda;
            xtcmon_tot.Text = SimboloMoneda;

        }

        public void SetPictureWatermark(XtraReport report)
        {
            // Adjust image watermark settings.
            report.Watermark.Image = VisorFacturas.Properties.Resources.Watermark_CZF_Logo;
            report.Watermark.ImageAlign = ContentAlignment.MiddleCenter;
            report.Watermark.ImageTiling = false;
            report.Watermark.ImageViewMode = ImageViewMode.Clip;
            report.Watermark.ImageTransparency = 217;//215;
            report.Watermark.ShowBehind = false;
            //report.Watermark.PageRange = "2,4";
        }

        private void rptFacturasCZF_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            SetPictureWatermark((XtraReport)sender);
        }
    }
}
