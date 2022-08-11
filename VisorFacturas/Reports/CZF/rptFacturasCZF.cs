using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using VisorFacturas.Clases;
using VisorFacturas.Enums;
using System.Linq;
using DevExpress.XtraPrinting.Drawing;

using VisorFacturas.DataNota;
using System.Text;
using DevExpress.XtraRichEdit;
using System.IO;

namespace VisorFacturas.Reports.CZF
{
    public partial class rptFacturasCZF : DevExpress.XtraReports.UI.XtraReport
    {
        clsAppEnum moclsAppEnum = new clsAppEnum();
        RichEditControl aortf = new RichEditControl();
        public rptFacturasCZF(dbo_pro_lst_NotasDC_Result paEnty)
        {
            InitializeComponent();
            mDetail_bndsrc.DataSource = paEnty;

            // Load de RTF Document
            aortf.RtfText = Encoding.UTF8.GetString(paEnty.ConceptoR);

            String path = Directory.GetCurrentDirectory() + @"\_report.html";
            //MemoryStream stream = new System.IO.MemoryStream();
            aortf.SaveDocument(path, DevExpress.XtraRichEdit.DocumentFormat.Html);
            xrRichText1.LoadFile(path);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

    }
}
