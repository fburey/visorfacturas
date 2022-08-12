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
using DevExpress.XtraBars;
using VisorFacturas.Forms;
using VisorFacturas.Clases;
using VisorFacturas.Util;

namespace VisorFacturas.Forms
{
    public partial class frmMDI : DevExpress.XtraEditors.XtraForm
    {
        tblUser moCurrentUser;
        clslistusers clsusuarios = new clslistusers();

        public frmMDI()
        {
            InitializeComponent();
        }

        private void frmMDI_Load(object sender, EventArgs e)
        {
            //ribbonMain.Minimized = true;
            //bbi_visorfactura.PerformClick();

            //// Obtener el usuario de Windows
            //XtraMessageBox.Show(System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\').Last());
            String username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;  // PARA SABER NOMBRE DE USUARIO CON DOMINIO
            //String username = Environment.UserName; // PARA SABER SOLO EL NOMBRE DE USUARIO

            moCurrentUser = clsusuarios.GetUserSystem(username, null);
            if (moCurrentUser.idEmpresa != 0 || moCurrentUser.username != "Usuario Inválido")
            {
                if (moCurrentUser.indVerFactura || moCurrentUser.indVerActFij)
                {
                    //// Puede ver facturas ?
                    if(moCurrentUser.indVerFactura)
                        bbi_visorfactura.Visibility = BarItemVisibility.Always;
                    else
                        bbi_visorfactura.Visibility= BarItemVisibility.Never;
                    //// Puede ver Activos Fijos ?
                    if (moCurrentUser.indVerActFij)                    
                        bbi_ActivosAsignados.Visibility = BarItemVisibility.Always;
                    else
                        bbi_ActivosAsignados.Visibility = BarItemVisibility.Never;
                    //// Puede ver Reportes ?
                    if (moCurrentUser.indVerNotas)
                    {
                        //bbi_SistInf.Visibility = BarItemVisibility.Always;
                    }
                    else
                    {
                        //bbi_SistInf.Visibility = BarItemVisibility.Never;
                    }
                    //// Puede ver Reportes ?
                    if (moCurrentUser.indVerSistInf)
                        bbi_SistInf.Visibility = BarItemVisibility.Always;
                    else
                        bbi_SistInf.Visibility = BarItemVisibility.Never;
                    
                    //// Verificamos en que empresa desea entrar, solo los que tienen el IndCambiarEmpresa en True
                    var idselectempresa = mvxCambiarEmpresa(moCurrentUser);
                    if (idselectempresa != moCurrentUser.idEmpresa)
                    {
                        moCurrentUser = clsusuarios.GetUserSystem(username, (Int16)idselectempresa);
                    }
                }
                else
                {
                    ribPag_Facturas.Visible = false;
                    ribpag_ActivosFijo.Visible = false;
                    XtraMessageBox.Show("Usted no puede visualizar ningún módulo del sistema!", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }
            }
            else
            {
                ribPag_Facturas.Visible = false;
                ribpag_ActivosFijo.Visible = false;
                XtraMessageBox.Show("Usted no pertenece a los usuarios autorizados para usar el sistema!", "El Usuario no Existe", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }

            //switch (username.ToLower())
            //{
            //    case "zfrancas\\adavila":
            //        ribPag_Facturas.Visible = true;
            //        ribpag_ActivosFijo.Visible = true;             
            //        break;
            //    case "zfrancas\\wmejia":
            //        ribPag_Facturas.Visible = true;
            //        ribpag_ActivosFijo.Visible = true;
            //        break;
            //    case "zfrancas\\rsblanco":
            //        ribPag_Facturas.Visible = true;
            //        ribpag_ActivosFijo.Visible = false;
            //        break;
            //    case "zfrancas\\dgonzalez":
            //        ribPag_Facturas.Visible = true;
            //        ribpag_ActivosFijo.Visible = true;
            //        break;
            //    case "zfrancas\\cobando":
            //        ribPag_Facturas.Visible = true;
            //        ribpag_ActivosFijo.Visible = false;
            //        break;
            //    default:
            //        ribPag_Facturas.Visible = false;
            //        ribpag_ActivosFijo.Visible = false;
            //        XtraMessageBox.Show("Usted no puede visualizar ningún módulo del sistema!", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //        Application.Exit();
            //        break;
            //}
        }

        private void bbi_visorfactura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm aofrmchild;
            BarButtonItem btnitem = (BarButtonItem)e.Item;
            switch (btnitem.Tag.ToString().ToLower())
            {
                case "frmfacturas":
                    aofrmchild = new frmFacturas(moCurrentUser);
                    aofrmchild.MdiParent = this;
                    aofrmchild.WindowState = FormWindowState.Maximized;
                    aofrmchild.CloseBox = false;
                    aofrmchild.Show();
                    break;
                case "frmconsulta1":
                    aofrmchild = new frmActivoFijo(moCurrentUser);
                    aofrmchild.MdiParent = this;
                    aofrmchild.WindowState = FormWindowState.Maximized;
                    aofrmchild.CloseBox = false;
                    aofrmchild.Show();
                    break;
                case "frmsistinf":
                    aofrmchild = new frmSistInfCNZF(moCurrentUser);
                    aofrmchild.MdiParent = this;
                    aofrmchild.WindowState = FormWindowState.Maximized;
                    aofrmchild.CloseBox = false;
                    aofrmchild.Show();
                    break;
                case "salirsistema":
                    Application.Exit();
                    break;
                default:
                    break;
            }
            ribbonMain.Minimized = true;
        }

        private void xtabmdiman_Main_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            if (this.MdiChildren.Count() < 1)
                ribbonMain.Minimized = false;
        }

        private Int16 mvxCambiarEmpresa(tblUser pauser)
        {
            if (pauser.indCambiarEmpresa == true)
            {
                //// Inicializando el XtraInputBox
                XtraInputBoxArgs args = new XtraInputBoxArgs();
                args.Caption = "Seleccionar Empresa";
                args.Prompt = "Seleccione la Empresa a visualizar:";
                args.DefaultButtonIndex = 0;

                ////// inicializamos el SpinEdit
                ComboBoxEdit cmb = new ComboBoxEdit();
                cmb.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                cmb.Properties.Items.Add("Corporación de Zonas Francas");
                cmb.Properties.Items.Add("Comisión Nacional de Zonas Francas");

                args.Editor = cmb;
                args.DefaultResponse = "Corporación de Zonas Francas";

                ////// Mostramos el cuadro de dialogo y obtenemos el valor
                var aoselectedvalue = XtraInputBox.Show(args);
                if (aoselectedvalue != null)
                {
                    if (aoselectedvalue.ToString() == "Corporación de Zonas Francas")
                        return 1;
                    else
                        return 2;
                }
                else
                {
                    return pauser.idEmpresa;
                }
            }
            else
            {
                return pauser.idEmpresa;
            }
        }
    }
}