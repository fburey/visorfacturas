using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using VisorFacturas.Clases;

namespace VisorFacturas.Reports.CZF
{
    public partial class rptBanco : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBanco()
        {
            InitializeComponent();
            //mempleado_bndsrc.DataSource = paEMPLEADO;
        }
        public void mpxSetTittle(string patittle01, string patittle02, string patittle03, string patittle04)
        {
            if (!String.IsNullOrEmpty(patittle02))
            {
                xrTableCell3.Text = patittle01;
                xrTableCell8.Text = patittle02;
            }
            if (!String.IsNullOrEmpty(patittle03))
            {
                mtblcelTit030.Text = patittle03;
            }
        }
    }
}
