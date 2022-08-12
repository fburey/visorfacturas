using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VisorFacturas.DataNota;
using VisorFacturas.Properties;
using VisorFacturas.Clases;
using VisorFacturas.Util;
using VisorFacturas.Enums;

namespace VisorFacturas.Forms
{
    public partial class frmNotas : DevExpress.XtraEditors.XtraForm
    {

        //SAFWINEntities Contexto = new SAFWINEntities();
        // Usuario Actual
        tblUser moCurrentUser;

        public frmNotas(tblUser pocurrentuser)
        {
            InitializeComponent();
            this.moCurrentUser = pocurrentuser;
        }

        private void frmNotas_Load(object sender, EventArgs e)
        {
            try
            {
                if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                {
                    
                }
                else if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CNZF)
                {
                  
                }              

                // Carga datos principales
                CargarDatos();

                // Configuración de propiedades del Grid
                //gvFacturas.OptionsBehavior.Editable = true;
                //gvFacturas.OptionsBehavior.ReadOnly = false;

                ////tipomoneda_ricmb.Items.AddEnum(typeof(clsAppEnum.MvxTipoMoneda), true);
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error No: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga datos principales
        /// </summary>
        private void CargarDatos()
        {
            using (SAFWINEntities Contexto = new SAFWINEntities())
            {

            }
        }
    }
}