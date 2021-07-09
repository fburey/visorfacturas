using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace VisorFacturas.Reports.CNZF
{
    public partial class xrsaldoclientesdetalle : DevExpress.XtraReports.UI.XtraReport
    {
        public xrsaldoclientesdetalle()
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
