using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.ChartRangeControlClient.Core;
using DevExpress.XtraReports.UI;
using VisorFacturas.Clases;
using System.Collections.Generic;
using System.Linq;

namespace VisorFacturas.Reports.CZF
{
    public partial class rptBienesAllconMontos : DevExpress.XtraReports.UI.XtraReport
    {
        List<viewBIENES> ListBienes;    // Estos son todos los datos de Activos Fijos de todos los Empleados
        List<viewBIENES> ListBienesDet; // Estos son todos los datos de Activos Fijos de un Empleado (iteración)
        String c_codigo;
        public rptBienesAllconMontos(List<viewBIENES> paListBIENES)//(mstcia pocia)
        {
            InitializeComponent();            
            ListBienes = paListBIENES;
            //mpicboxLogCia.ImageUrl = pacompani;
            //mpicboxEscNic.ImageUrl = paestnica;
        }

        private void GroupHeader1_AfterPrint(object sender, EventArgs e)
        {
            // Obtengo el Cod Empleado actual
            c_codigo = this.GetCurrentColumnValue("c_codigo").ToString();
            // Filtro los Activos Fijos Asignados a este empleado
            ListBienesDet = ListBienes.Where(s => s.bi_codemp == c_codigo).ToList();
            // Lleno el binding source de Detail (Bienes)
            mactivos_bndsrc.DataSource = ListBienesDet.ToList();
        }
    }
}
