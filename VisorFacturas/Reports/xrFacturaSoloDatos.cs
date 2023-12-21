using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using VisorFacturas.Clases;
using System.Linq;
using VisorFacturas.Enums;

namespace VisorFacturas.Reports
{
    public partial class xrFacturaSoloDatos : DevExpress.XtraReports.UI.XtraReport
    {
        List<viewRemision> ListRem;
        List<viewRemision> ListRemDet;
        String ord_num;
        String FacturacionMes;
        clsAppEnum moclsAppEnum = new clsAppEnum();
        String FormatoNumerico;

        public xrFacturaSoloDatos(List<viewRemision> List, String MesFacturado, bool ind_EntMes, string Meses)
        {
            InitializeComponent();
            //mdetail_bndsrc.DataSource = List;
            this.ListRem = List;
            mdetail_bndsrc.DataSource = List;
            if (ind_EntMes)
            {
                FacturacionMes = Meses;

            }
            else
                FacturacionMes = "Facturación del Mes de " + MesFacturado;
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

            // Obtenemos el total de la factura
            String TotalFact = this.GetCurrentColumnValue("fac_amo_do").ToString();
            // Obtenemos la moneda de la factura
            String MonedaFact = this.GetCurrentColumnValue("fac_dolcor").ToString();
            // Obtenemos el valor en letras del monto total de la factura (Params: Monto Total, Moneda)
            xrlabel_ValorEnLetras.Text = moclsAppEnum.enletras(TotalFact, MonedaFact);

            //// Si en el remision_descripcion abarca Directorio Industrial, entonces cambia el campo REVISADO
            //if (ListRemDet.AsEnumerable().Where(s => s.rem_desc.ToLower().Contains("directorio")).ToList().Count > 0)
            //    xrlab_Revisado.Text = "Mauricio Abarca";
            //else
            //    xrlab_Revisado.Text = "Estrellita Blanco";

            // Obtenemos el formato numérico conforme la moneda de la factura
            if (MonedaFact.Substring(0, 1).ToUpper() == "D")
                FormatoNumerico = "{0:U$  #,0.00}";
            else
                FormatoNumerico = "{0:C$  #,0.00}";

            xrlab_fac_total_1.DataBindings["Text"].FormatString = FormatoNumerico;
            xrlab_fac_total_2.DataBindings["Text"].FormatString = FormatoNumerico;
        }
    }
}
