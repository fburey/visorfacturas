using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using VisorFacturas.Clases;
using VisorFacturas.Util;
using DevExpress.XtraEditors;

namespace VisorFacturas
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            try
            {               

                Application.Run(new Forms.frmMDI());
                //Application.Run(new Forms.frmEmpresaSelect());
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error N°: " + ex.HResult, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
