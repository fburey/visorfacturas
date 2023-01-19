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
using System.Threading;

namespace VisorFacturas.Forms
{
    public partial class frmviewer : DevExpress.XtraEditors.XtraForm
    {
        DevExpress.XtraReports.UI.XtraReport moreport;        

        public frmviewer(DevExpress.XtraReports.UI.XtraReport poreport)
        {
            InitializeComponent();

            moreport = poreport;
            if (this.moreport != null)
            {
                documentViewer1.DocumentSource = moreport;
            }
        }

        private void frmviewer_Load(object sender, EventArgs e)
        {
        }
       
    }
}