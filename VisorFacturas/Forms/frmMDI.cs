using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using VisorFacturas.Clases;
using VisorFacturas.Util;
using VisorFacturas.Enums;

namespace VisorFacturas.Forms
{
    public partial class frmMDI : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Clase tblUser
        /// </summary>
        tblUser moCurrentUser;// = new tblUser();
        clslistusers clsusuarios = new clslistusers();
        clsCnfParameterLogin moClsCnfParameter = new clsCnfParameterLogin();
        String username = string.Empty;
        String PantTitle = "SISTEMA DE CONSULTAS DBF";
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
            username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;  // PARA SABER NOMBRE DE USUARIO CON DOMINIO
            //String username = Environment.UserName; // PARA SABER SOLO EL NOMBRE DE USUARIO

            moCurrentUser = clsusuarios.GetUserSystem(username, null);

            //if (moCurrentUser.indCambiarEmpresa)
            //{
            //    //AQUI OBTENGO LOS PERMISOS DEL USUARIO
            //    moCurrentUser = clsusuarios.GetUserSystem(username, moClsCnfParameter.mcIdEmpresa);
            //    btnmenuCam.Visibility = BarItemVisibility.Always;
            //}
            //else
            //{
            //    //AQUI OBTENGO LOS PERMISOS DEL USUARIO
            //    moCurrentUser = clsusuarios.GetUserSystem(username, null);
            //    btnmenuCam.Visibility = BarItemVisibility.Never;
            //}
            moClsCnfParameter.mcIdEmpresa = moCurrentUser.idEmpresa;
            mpxGetPermiso();
            
        }

        private void mpxGetPermiso()
        {
            if (moCurrentUser.indVerFactura || moCurrentUser.indVerActFij)
            {
                //// Puede ver facturas ?
                if (moCurrentUser.indVerFactura)
                {
                    ribbonPageGroup1.Visible = true;
                    bbi_visorfactura.Visibility = BarItemVisibility.Always;
                    bbi_visorfactura1.Visibility = BarItemVisibility.Always;
                }
                else
                {
                    ribbonPageGroup1.Visible = false;
                    bbi_visorfactura.Visibility = BarItemVisibility.Never;
                    bbi_visorfactura1.Visibility = BarItemVisibility.Never;
                }
                //// Puede ver Activos Fijos ?
                if (moCurrentUser.indVerActFij)
                {
                    ribbonPageGroup3.Visible = true;
                    bbi_ActivosAsignados.Visibility = BarItemVisibility.Always;

                }
                else
                {
                    ribbonPageGroup3.Visible = false;
                    bbi_ActivosAsignados.Visibility = BarItemVisibility.Never;
                }
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
                {
                    ribbonPageGroup5.Visible = true;
                    bbi_SistInf.Visibility = BarItemVisibility.Always;
                }
                else
                {
                    ribbonPageGroup5.Visible = false;
                    bbi_SistInf.Visibility = BarItemVisibility.Never;
                }

                ////// Verificamos en que empresa desea entrar, solo los que tienen el IndCambiarEmpresa en True
                //var idselectempresa = mvxCambiarEmpresa(moCurrentUser);
                ////if (idselectempresa != moCurrentUser.idEmpresa)
                ////{
                //  moCurrentUser = clsusuarios.GetUserSystem(username, (Int16)idselectempresa);
                ////}



                if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                    this.Text = PantTitle + " - CZF";
                else if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CNZF)
                    this.Text = PantTitle + " - CNZF";
            }
            else
            {
                ribPag_Facturas.Visible = false;
                ribpag_ActivosFijo.Visible = false;
                XtraMessageBox.Show("Usted no puede visualizar ningún módulo del sistema!", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }
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
                case "frmfacturasaud":
                    aofrmchild = new frmFacturasAUD(moCurrentUser);
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

        private void btnmenuCam_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraForm aofrmchild;
            moClsCnfParameter.orden_interna = true;

            aofrmchild = new frmEmpresaSelect(moClsCnfParameter);
            aofrmchild.ShowDialog();
            //// Verificamos en que empresa desea entrar, solo los que tienen el IndCambiarEmpresa en True
            moCurrentUser = clsusuarios.GetUserSystem(username, moClsCnfParameter.mcIdEmpresa);
            
            if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                this.Text = PantTitle + " - CZF";
            else if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CNZF)
                this.Text = PantTitle + " - CNZF";

            mpxGetPermiso();
        }
    }
}