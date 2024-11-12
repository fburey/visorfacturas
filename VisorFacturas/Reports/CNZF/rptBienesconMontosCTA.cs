using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using VisorFacturas.Clases;

namespace VisorFacturas.Reports.CNZF
{
    public partial class rptBienesconMontosCTA : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBienesconMontosCTA(viewEmpleados paEMPLEADO, String paestnica, string pacompani)
        {
            InitializeComponent();
            mempleado_bndsrc.DataSource = paEMPLEADO;
        }

    }
}
