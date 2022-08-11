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
    public partial class xrantiguedad_saldo_CZF : DevExpress.XtraReports.UI.XtraReport
    {
        List<view_rpt_saldoclientes_CZF> aoListRPT;
        Boolean aovisibleDetail = false;
        Boolean aovisibleDetailGroup = false;
        int rowcount = 0;
        bool ind_va_A_contar = true;

        public xrantiguedad_saldo_CZF(List<view_rpt_saldoclientes_CZF> paList)
        {
            InitializeComponent();
            aoListRPT = paList;
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


        private void gh_cliente_AfterPrint(object sender, EventArgs e)
        {
            // Obtengo el ord_numero actual
            String cli_cod_current = this.GetCurrentColumnValue("cli_cod").ToString();
            // Filtro las Facturas por Cliente y Lleno el binding source de Detail
            mdetail_bndsrc.DataSource = aoListRPT.Where(s => s.cli_cod.Trim() == cli_cod_current.Trim()).ToList();
            aovisibleDetail = true;
            aovisibleDetailGroup = true;
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            Detail.Visible = aovisibleDetail;
        }

        private void Detail_AfterPrint(object sender, EventArgs e)
        {
            aovisibleDetail = false;
            aovisibleDetailGroup = true;
        }

        private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            GroupHeader1.Visible = aovisibleDetailGroup;
        }

        private void Detail1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            Detail1.Visible = aovisibleDetailGroup;
        }

        private void GroupFooter1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            GroupFooter1.Visible = aovisibleDetailGroup;
            aovisibleDetailGroup = false;
        }

        private void gh_cliente_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrtc_contador.Text = (++rowcount).ToString();
        }

        private void ReportFooter_AfterPrint(object sender, EventArgs e)
        {
            rowcount = 0;
        }
    }
}
