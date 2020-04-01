using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace VisorFacturas.Reports.CNZF
{
    public partial class xrmetrajeanual : DevExpress.XtraReports.UI.XtraReport
    {
        public xrmetrajeanual()
        {
            InitializeComponent();
        }
        public void mpxSetTittle(string patittle02 = "", string patittle03 = "")
        {
            if (!String.IsNullOrEmpty(patittle02))
            {
                mtblcelTit020.Text = patittle02;
            }
            if (!String.IsNullOrEmpty(patittle03))
            {
                mtblcelTit030.Text = patittle03;
            }
        }
    }
}
