using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;
using VisorFacturas.Clases;
using VisorFacturas.Util;

namespace VisorFacturas.Forms
{
    public partial class frmEmpresaSelect : DevExpress.XtraEditors.XtraForm
    {
        tblUser moCurrentUser = new tblUser();
        clslistusers clsusuarios = new clslistusers();
        clsCnfParameterLogin moClsCnfParameter = new clsCnfParameterLogin();
        clsMenuMDI moclsMenuMDI = new clsMenuMDI();
        //Variables de empresas
        Guid ao_idczf = new Guid("44702ab9-76d3-e111-bfc5-88ae1d4560b2");
        string ao_nom_czf = "CORPORACIÓN DE ZONAS FRANCAS";
        Guid ao_idcnzf = new Guid("077ad8d0-bbf4-e711-9450-005056844ab1");
        string ao_nom_cnzf = "COMISIÓN NACIONAL DE ZONAS FRANCAS";
        string username = string.Empty;
        //Numero del producto que nesesita mostrar
        short ID_czf = 1;
        short ID_cnzf = 2;
        public frmEmpresaSelect(clsCnfParameterLogin poClsCnfParameter)
        {
            InitializeComponent();
            moClsCnfParameter = poClsCnfParameter;
        }

        private void picture_Click(object sender, EventArgs e)
        {
            PictureEdit aosender = (PictureEdit)sender;
            var Empre_selecion = aosender.Tag.ToString();

            moClsCnfParameter.orden_interna = true;
            //moClsCnfParameter.mcIdEmpresa =
            if (!String.IsNullOrEmpty(Empre_selecion))
            {
                switch (Empre_selecion)
                {
                    case "CZF":
                        if (moClsCnfParameter.orden_interna)
                        {
                            //if (moClsCnfParameter.mcIdEmpresa != ID_czf)
                            //{
                                moClsCnfParameter.orden_interna = false;
                                //Aqui mando a cerrar las pantallas abiertas
                                moclsMenuMDI.CerrarTodosMenosMDI(moClsCnfParameter);
                                if (!moClsCnfParameter.permi_closePantalla)
                                {
                                    this.Close();
                                    return;
                                }
                            //}
                            //else
                            //{
                            //    this.Close();
                            //    return;
                            //}
                        }

                        //moClsCnfParameter.GetGuidEmpresaSelec = ao_idczf;
                        moClsCnfParameter.mcIdEmpresa = ID_czf;
                        moClsCnfParameter.GetNombreEmpresaSelec = ao_nom_czf;
                        //moClsCnfParameter.GetnumProduc = moClsCnfParameter.GetnumProducDefect;
                        this.Close();


                        break;
                    case "CNZF":

                        if (moClsCnfParameter.orden_interna)
                        {
                            //if (moClsCnfParameter.mcIdEmpresa != ID_cnzf)
                            //{
                                moClsCnfParameter.orden_interna = false;
                                //Aqui mando a cerrar las pantallas abiertas
                                moclsMenuMDI.CerrarTodosMenosMDI(moClsCnfParameter);
                                if (!moClsCnfParameter.permi_closePantalla)
                                {
                                    this.Close();
                                    return;
                                }
                            //}
                            //else
                            //{
                            //    this.Close();
                            //    return;
                            //}
                        }

                        //moClsCnfParameter.GetGuidEmpresaSelec = ao_idczf;
                        moClsCnfParameter.mcIdEmpresa = ID_cnzf;
                        moClsCnfParameter.GetNombreEmpresaSelec = ao_nom_cnzf;
                        //moClsCnfParameter.GetnumProduc = moClsCnfParameter.GetnumProducDefect;
                        this.Close();

                        break;
                    default:
                        break;
                }

            }
            else
            {
                XtraMessageBox.Show("No a seleccionado ninguna empresa", "Seleccion de empresa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.Hide();
            }
            this.Hide();
        }  

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEmpresaSelect_Load(object sender, EventArgs e)
        {
           // username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        }
    }
}