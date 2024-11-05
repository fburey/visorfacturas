using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using VisorFacturas.Clases;

namespace VisorFacturas.Reports.CZF
{
    public partial class rptBienesconMontos : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBienesconMontos(viewEmpleados paEMPLEADO, String paestnica, string pacompani)
        {
            InitializeComponent();
            mempleado_bndsrc.DataSource = paEMPLEADO;
        }

    }
}
