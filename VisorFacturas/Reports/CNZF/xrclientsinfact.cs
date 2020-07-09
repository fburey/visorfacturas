using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace VisorFacturas.Reports.CNZF
{
    public partial class xrclientsinfact : DevExpress.XtraReports.UI.XtraReport
    {
        public xrclientsinfact(String TittleRpt)
        {
            InitializeComponent();
            mtblcelTit020.Text = TittleRpt;
        }

    }
}
