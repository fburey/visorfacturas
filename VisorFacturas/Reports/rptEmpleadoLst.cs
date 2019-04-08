using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using VisorFacturas.Clases;

namespace VisorFacturas.Reports
{
    public partial class rptEmpleadoLst : DevExpress.XtraReports.UI.XtraReport
    {
        public rptEmpleadoLst(String paestnica, string pacompani)
        {
            InitializeComponent();
            mpicboxLogCia.ImageUrl = pacompani;
            mpicboxEscNic.ImageUrl = paestnica;
        }

    }
}
