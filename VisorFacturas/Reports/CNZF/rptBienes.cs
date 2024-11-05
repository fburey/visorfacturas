using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.ChartRangeControlClient.Core;
using DevExpress.XtraReports.UI;
using VisorFacturas.Clases;
using System.Collections.Generic;

namespace VisorFacturas.Reports.CNZF
{
    public partial class rptBienes : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBienes(viewEmpleados paEMPLEADO, String paestnica, string pacompani)//(mstcia pocia)
        {
            InitializeComponent();
            mempleado_bndsrc.DataSource = paEMPLEADO;
            //mpicboxLogCia.ImageUrl = pacompani;
            //mpicboxEscNic.ImageUrl = paestnica;
        }
        public void mpxsettitle(string pctitle3)
        {
          //  this.mtblcelTit030.Text = pctitle3;
        }

        private void mtblcel_dsccatitm_BeforePrint(object sender, CancelEventArgs e)
        {
            //XRTableCell aosender = (XRTableCell)sender;
            //mpxareasdestinosgetlst_cpt aoety = (mpxareasdestinosgetlst_cpt)this.GetCurrentRow();
            //if (aoety != null)
            //{
            //    aosender.Text = new string(' ', (aoety.profundidad - 1) * 4) + aoety.descripci;
            //}
            //else
            //    aosender.Text = string.Empty;
        }

    }
}
