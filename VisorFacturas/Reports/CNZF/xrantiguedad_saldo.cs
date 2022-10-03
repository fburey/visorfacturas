using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using VisorFacturas.Clases;

namespace VisorFacturas.Reports.CNZF
{
    public partial class xrantiguedad_saldo : DevExpress.XtraReports.UI.XtraReport
    {
        
        int rowcount = 0;

        public xrantiguedad_saldo()
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

        private void gh_regimen_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (gh_cliente.DrillDownExpanded == true && gh_cliente.DrillDownControl.Name == "mchk_expandcollapseRegimen")
            {
                mchk_expandcollapseRegimen.Checked = false;
            }
            else if (gh_cliente.DrillDownExpanded == false && gh_cliente.DrillDownControl.Name == "mchk_expandcollapseRegimen")
            {
                mchk_expandcollapseRegimen.Checked = true;
            }
        }

        private void gh_cliente_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            xrtc_contador.Text = (++rowcount).ToString();

            if (gh_DetailHeaders.DrillDownExpanded == true && gh_DetailHeaders.DrillDownControl.Name == "mchk_expandcollapseCliente")
            {
                mchk_expandcollapseCliente.Checked = false;
            }
            else if (gh_DetailHeaders.DrillDownExpanded == false && gh_DetailHeaders.DrillDownControl.Name == "mchk_expandcollapseCliente")
            {
                mchk_expandcollapseCliente.Checked = true;
            }
        }        

        private void ReportFooter_AfterPrint(object sender, EventArgs e)
        {
            rowcount = 0;
        }

       
    }
}
