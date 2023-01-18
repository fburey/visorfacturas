using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

//Agregado
using DevExpress.UserSkins;
using DevExpress.XtraBars.Ribbon;


namespace VisorFacturas.Forms
{
    public partial class frmviewer : DevExpress.XtraEditors.XtraForm
    {
        DevExpress.XtraReports.UI.XtraReport moreport;

        public frmviewer(DevExpress.XtraReports.UI.XtraReport poreport)
        {
            InitializeComponent();

            moreport = poreport;
        }

        private void frmviewer_Load(object sender, EventArgs e)
        {
            mpxInitDocto();
        }

        private void mpxInitDocto()
        {
            if (this.moreport != null)
            {
                mptcForm.PrintingSystem = moreport.PrintingSystem;
                //DevExpress.XtraReports.UI.ReportPrintTool tool = new DevExpress.XtraReports.UI.ReportPrintTool(moreport);
                moreport.CreateDocument(true);
            }
        }

        private void mptcForm_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Mandamos a cerrar el visor de report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printPreviewBarItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //No hay pantallas abiertas
            //if (Application.OpenForms["frmmain"].MdiChildren.Count() <= 1)
            //{
            //    RibbonControl aocontrol = (RibbonControl)this.MdiParent.Controls["mbrnMain"];
            //    aocontrol.Minimized = false;
            //}
            this.Close();
        }

       
    }
}