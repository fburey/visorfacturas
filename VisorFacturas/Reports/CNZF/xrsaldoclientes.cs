using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace VisorFacturas.Reports.CNZF
{
    public partial class xrsaldoclientes : DevExpress.XtraReports.UI.XtraReport
    {
        public xrsaldoclientes()
        {
            InitializeComponent();
        }
        public void mpxSetTittle(string patittle02 = "", string patittle03 = "", string paTC = "")
        {
            if (!String.IsNullOrEmpty(patittle02))
            {
                mtblcelTit020.Text = patittle02;
            }
            if (!String.IsNullOrEmpty(patittle03))
            {
                mtblcelTit030.Text = patittle03;
            }
            if (!String.IsNullOrEmpty(paTC))
            {
                xrlbl_tasacambio.Text = paTC;
            }
        }
    }
}
