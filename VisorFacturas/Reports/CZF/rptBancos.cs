using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using VisorFacturas.Clases;

namespace VisorFacturas.Reports.CZF
{
    public partial class rptBancos : DevExpress.XtraReports.UI.XtraReport
    {
        decimal aosdo_ACUM = 0, aosdo_ANT = 0;
        public rptBancos()
        {
            InitializeComponent();
        }

        public void mpxSetTittle(string patittle01, string patittle02, string patittle03)
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

        private void Detail_BeforePrint(object sender, CancelEventArgs e)
        {
            //view_rpt_saldoclientes aocurrent = (view_rpt_saldoclientes)this.GetCurrentRow();
            //if (aocurrent != null)
            //{
            //    if (aocurrent.fac_debe == 7)
            //    {
            //        aosdo_ANT = aocurrent.sdototd;
            //        xrow_01.Visible = true;
            //        xrow_02.Visible = false;
            //    }
            //    else
            //    {
            //        aosdo_ACUM += aocurrent.sdototd;
            //        xrow_01.Visible = false;
            //        xrow_02.Visible = true;
            //    }
            //}
            //else
            //{
            //    xrow_02.Visible = true;
            //}
                
        }

        private void Detail_AfterPrint(object sender, EventArgs e)
        {
            //view_rpt_saldoclientes aocurrent = (view_rpt_saldoclientes)this.GetCurrentRow();
            //if (aocurrent != null)
            //    aosdo_ACUM += aocurrent.sdototd;
            //else
            //    aosdo_ACUM += 0;
        }

        private void GroupFooter1_BeforePrint(object sender, CancelEventArgs e)
        {
            //xrtc_SUMSDOTOTD.Text = aosdo_ACUM.ToString("#,0.00");
            //xrtc_SDOFIN.Text = (aosdo_ACUM + aosdo_ANT).ToString("#,0.00");
        }

        

        private void GroupHeader1_AfterPrint(object sender, EventArgs e)
        {
            aosdo_ACUM = 0;
            aosdo_ANT = 0;
            //view_rpt_saldoclientes aocurrent = (view_rpt_saldoclientes)this.GetCurrentRow();
            //if (aocurrent != null)
            //    aosdo_ANT = aocurrent.sdo_antd;
            //else
            //    aosdo_ACUM = 0;
            
        }
    }
}
