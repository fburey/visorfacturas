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
using VisorFacturas.Datasets;
using VisorFacturas.Properties;
using System.Data.OleDb;
using VisorFacturas.Clases;
using System.Net.Mail;
using VisorFacturas.Enums;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using System.Net;
using DevExpress.XtraLayout;
using DevExpress.Utils;
using System.Net.Mime;
using static VisorFacturas.Util.clsSendmail_richtext;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace VisorFacturas.Forms
{
    public partial class frmFacturasAUD : DevExpress.XtraEditors.XtraForm
    {

        #region VARIABLES GLOBALES Y FORMULARIOS MODALES

        // Usuario del sistema
        tblUser moCurrentUser;

        // Cadena de Conexion 
        String mocadenaconexOLEDB;

        /* Variables de Correo Electrónico */
        //String smtpCZF = "ns.czf.com.ni";
        String smtpCZF = "186.1.30.111";//"smtp.czf.com.ni";
        //String smtpCNZF = "mail.cnzf.gob.ni";
        String smtpCNZF = "186.1.30.111";//"smtp.czf.com.ni";
        String smtpCORREO;

        string UserCorreo;
        string UserPass;
        String correoRemitent;
        /* Variables para el envio de correos */
        //String NombreRemitenteCNZF = "Ramona Blanco Lezama";
        //String CorreoremitenteCNZF = "rblanco@cnzf.gob.ni";
        //String NombreRemitenteCNZF = "Ariel Davila";
        //String CorreoremitenteCNZF = "adavila@czf.com.ni";
        //String NombreRemitenteCZF = "";
        //String CorreoremitenteCZF = "";

        //Rutas de Directorios
        String pathTablas; // = Settings.Default.DirectorioTablasCNZF;
        String pathFact; // = Settings.Default.DirectorioFacturasCNZF;
        String pathTablaRemisionTemp; // = Settings.Default.DirectorioTablasRemisionCNZF;
        //String pathEmail = Settings.Default.DirectorioCorreos;

        String sqlClientesCZF = "SELECT cli_cod, cli_nom, (cli_direc1 + ' ' + cli_direc2) AS cli_dir FROM CLIENTE";

        String sqlClientesCNZF = "SELECT cli_cod, cli_nom, (cli_direc1 + ' ' + cli_direc2) AS cli_dir, cli_email1, cli_email2, cli_ruc, cli_regime FROM CLIENTE";
        String sqlFacturas = "SELECT cli_codig, fecha, ord_numero, fac_fac_nu, fac_tasa, fac_amo_do, fac_dolcor, tipo, fac_amount, fac_pagado, fac_pag_do FROM FACTURA WHERE fac_amo_do > 0 AND tipo == '1' order by fac_fac_nu ASC";
        //String sqlRemision = "Select DISTINCT rem_numero, rem_codig, (rem_desc1 + ' ' + rem_desc2) AS rem_desc, rem_canti, rem_precio, rem_impues, rem_descue, rem_fec_ve From REMISION ORDER BY rem_numero ASC";
        String sqlRemision = "Select rem_numero, rem_codig, (rem_desc1 + ' ' + rem_desc2) AS rem_desc, rem_canti, rem_precio, rem_impues, rem_descue, rem_fec_ve From REMISION ORDER BY rem_numero ASC";

        /* DataTables del DataSet - En estas tablas se almacenan los datos */
        dsModel.CLIENTEDataTable tbl_clientes = new dsModel.CLIENTEDataTable();
        dsModel.FACTURADataTable tbl_facturas = new dsModel.FACTURADataTable();
        dsModel.REMISIONDataTable tbl_remision = new dsModel.REMISIONDataTable();

        // Listas y objetos
        List<viewFactura> factura;   //Esta se ocupa para los reportes
        List<viewRemision> remision; //Esta se ocupa para los reportes
        List<viewClientes> Clientes; // Se usa en el grid Clientes
        viewClientes cliente_selected;
        List<viewFactura> ListFacturas; // Se usa en el Grid Facturas
        List<viewClientes> ListClientes_Err;


        //DataAdapters
        OleDbDataAdapter adapter;

        //Commands
        OleDbCommand command;

        //Conexion
        OleDbConnection con;

        //Variables locales
        String CodClienteSelect;
        String Month;
        String Year;
        Boolean isErrorSendMail = false;
        Boolean aoisfacturasgeneradas = false;
        Int32 aonum_fact_ini_modal;
        DateTime aofecha_fact_modal;
        DateTime aofecha_fact_vence_modal;
        AlternateView htmlView;
        LinkedResource img;

        // Clase para el XtraDialog MODAL 
        public class xdModalform : XtraUserControl
        {
            public DevExpress.XtraLayout.LayoutControl mlytctrl;
            public xdModalform()
            {
                mlytctrl = new DevExpress.XtraLayout.LayoutControl();
                mlytctrl.Dock = DockStyle.Fill;
                SpinEdit spenumfacturaini = new SpinEdit() { Name = "modal_spenumfacturaini" };
                DateEdit dteFechaFact = new DateEdit() { Name = "modal_dteFechaFact" };
                SeparatorControl separatorControl01 = new SeparatorControl();

                // Configuramos el SpinEdit
                spenumfacturaini.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                spenumfacturaini.Properties.Mask.EditMask = "D";
                spenumfacturaini.Properties.Mask.UseMaskAsDisplayFormat = true;

                // Configuramos el DateTime


                mlytctrl.AddItem(String.Empty, spenumfacturaini).Text = "Número de Fact. Inicial: ";
                mlytctrl.AddItem(String.Empty, dteFechaFact).Text = "Fecha Factura: ";
                //mlytctrl.AddItem(String.Empty, separatorControl01).TextVisible = false;

                this.Controls.Add(mlytctrl);
                this.Height = 100;
                this.Width = 250;
                //this.Dock = DockStyle.Top;
            }
        }

        #endregion

        #region CONSTRUCTORES

        public frmFacturasAUD(tblUser paCurrentUser)
        {
            InitializeComponent();
            this.moCurrentUser = paCurrentUser;
        }

        #endregion

        #region FUNCIONES Y MÉTODOS

        /// <summary>
        /// Verifica si las rutas a los archivos .DBF existen
        /// </summary>
        /// <returns></returns>
        private Boolean VerificarRutas()
        {
            if (!Directory.Exists(pathTablas))
            {
                XtraMessageBox.Show("Verifique la ruta de los archivos de datos: \n\n" + pathTablas, "La ruta no existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Directory.Exists(pathTablaRemisionTemp))
            {
                XtraMessageBox.Show("Verifique la ruta de los archivos de datos: \n\n" + pathTablaRemisionTemp, "La ruta no existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Directory.Exists(pathFact))
            {
                System.IO.Directory.CreateDirectory(pathFact);
            }

            return true;
        }

        /// <summary>
        /// Carga los datos de las tablas de Visual Fox Pro y los datos los guardamos en las tablas del dataset del proyecto
        /// </summary>
        private void CargarDatosTablasDBF()  //Se carga el dataset
        {
            try
            {
                                 //OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=dBASE IV;User ID=;Password=");
                con = new OleDbConnection("Provider=VFPOLEDB.1;Data Source=" + pathTablas + ";Extended Properties=dBASE IV;");
                OleDbConnection con2 = new OleDbConnection("Provider=VFPOLEDB.1;Data Source=" + pathTablaRemisionTemp + ";Extended Properties=dBASE IV;");

                //Cargamos los clientes
                if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                {
                    command = new OleDbCommand(sqlClientesCZF, con);
                }
                else
                {
                    command = new OleDbCommand(sqlClientesCNZF, con);
                }
                //command = new OleDbCommand(sqlClientesCNZF, con);
                command.CommandType = CommandType.Text;
                adapter = new OleDbDataAdapter(command);
                adapter.Fill(tbl_clientes);
                adapter.Dispose();
                bsClientes.DataSource = tbl_clientes;

                // Guardamos la lista de los clientes en un List<Clientes> para acceder a ellos facilmente
                var data = from cli in tbl_clientes.AsQueryable()
                              select new viewClientes
                              {
                                  cli_cod = cli.cli_cod,
                                  cli_nom = cli.cli_nom,
                                  cli_dir = cli.cli_dir,
                                  cli_email1 = cli.cli_email1,
                                  cli_email2 = cli.cli_email2,
                                  cli_ruc = cli.cli_ruc,
                                  cli_regimen = cli.cli_regime.ToUpper()
                              };
                Clientes = data.ToList();

                //Cargamos las facturas
                command = new OleDbCommand(sqlFacturas, con2);
                command.CommandType = CommandType.Text;
                adapter = new OleDbDataAdapter(command);
                adapter.Fill(tbl_facturas);

                //Cargamos las remisiones
                command = new OleDbCommand(sqlRemision, con2);
                command.CommandType = CommandType.Text;
                adapter = new OleDbDataAdapter(command);
                adapter.Fill(tbl_remision);

                con.Close();
                con.Dispose();
                con2.Close();
                con2.Dispose();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error No: " + ex.HResult, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga las facturas conforme al mes y año especificados
        /// </summary>
        private void CargarFacturas()
        {
            try
            {

                //// Si Imprime varias facturas
                // Por si ya estaba abierto, cerramos el splash form
                if (mspsmForm.IsSplashFormVisible) { mspsmForm.CloseWaitForm(); }

                //Formulario de espera abierto
                mspsmForm.ShowWaitForm();
                mspsmForm.SetWaitFormCaption("Obteniendo las Facturas...");

                //tbl_facturas.Clear();
                //String Sqlwhere = "";
                aoisfacturasgeneradas = false;
                DateTime fechaini = new DateTime((int)speAnno.Value, (cmbMes.SelectedIndex + 1), 1);
                DateTime fechafin = fechaini.AddMonths(1).AddDays(-1);

                IEnumerable<viewFactura> data = from fac in tbl_facturas.AsEnumerable()
                                                join client in tbl_clientes.AsEnumerable() on fac.cli_codig equals client.cli_cod
                                                //join rem in tbl_remision on fac.fac_fac_nu equals rem.rem_numero
                                                where (fac.fecha >= fechaini && fac.fecha <= fechafin)
                                                select new viewFactura
                                                {
                                                    cli_codig = fac.cli_codig,
                                                    cli_nom = client.cli_nom,
                                                    ord_numero = fac.ord_numero,
                                                    fecha = fac.fecha,
                                                    //fechaVence = rem.rem_fec_ve,
                                                    fac_fac_nu = fac.fac_fac_nu,
                                                    fac_tasa = fac.fac_tasa,
                                                    fac_amo_do = fac.fac_amo_do,
                                                    fac_dolcor = fac.fac_dolcor,
                                                    tipo = fac.tipo,
                                                    cli_dir = client.cli_dir,
                                                    cli_ruc = client.cli_ruc,
                                                    fac_amount = fac.fac_amount,
                                                    fac_pagado = fac.fac_pagado,
                                                    fac_pag_do = fac.fac_pag_do,
                                                    cli_regimen = client.cli_regime.ToUpper()
                                                };


                ListFacturas = data.OrderBy(s => s.fac_fac_nu).ToList();
                bsGrid.DataSource = ListFacturas;
                gvFacturas.ViewCaption = "Total de Facturas Encontradas: " + gvFacturas.DataRowCount; //+ bsGrid.List.Count;

                VerificarDuplicados();
                VerificarVerificar();

                //// Si Imprime varias facturas
                // Por si ya estaba abierto, cerramos el splash form
                if (mspsmForm.IsSplashFormVisible) { mspsmForm.CloseWaitForm(); }
            }
            catch (Exception ex)
            {
                //// Si Imprime varias facturas
                // Por si ya estaba abierto, cerramos el splash form
                if (mspsmForm.IsSplashFormVisible) { mspsmForm.CloseWaitForm(); }
                XtraMessageBox.Show(ex.Message, "Error No: " + ex.HResult, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Verifica las facturas que estén repetidas, en caso de que encuentre repetidas, imprime un mensaje de ALERTA
        /// </summary>
        private void VerificarVerificar()
        {
            String MensajeRepetidos = "";
            List<viewVerificadas> ListFacturasV;
            var obj = new viewVerificadas() { };
            ListFacturasV = new List<viewVerificadas>() { };
            //viewRemision remision;
            if (ListFacturas.Count > 0)
            {
                var dataFacturas = ListFacturas;
                viewRemision remisionTBL;
                int con = 0;
                foreach (var item in dataFacturas)
                {
                    //if(item.fac_fac_nu == 35192)
                    //{

                    //}
                    GetData(item.ord_numero);
                    if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                    {
                        remisionTBL = remision.Where(s => s.rem_fec_ve != (item.fecha.AddDays(5)) ).ToList().FirstOrDefault();
                    }
                    else
                    {
                        remisionTBL = remision.Where(s => s.rem_fec_ve != (item.fecha.AddDays(9))).ToList().FirstOrDefault();
                    }

                    if (remisionTBL != null)
                    {                         
                        con += 1;
                        MensajeRepetidos += "No. Factura: "+item.fac_fac_nu+", Fecha: " + item.fecha.ToString("d") + ", Fecha/Ven.: " + remisionTBL.rem_fec_ve.ToString("d") + " \n";
                        string item2 = "No. Factura: " + item.fac_fac_nu + ", Fecha: " + item.fecha.ToString("d") + ", Fecha/Ven.: " + remisionTBL.rem_fec_ve.ToString("d") + " \n";

                        
                        obj.FacturasV = item2;
                        ListFacturasV.Add(obj);
                        //ListFacturasV.Add(item2);
                    }
                }
                //ListFacturasV = MensajeRepetidos;


                if (MensajeRepetidos != "")
                {
                    //XtraMessageBox.Show("Las siguientes " + con + " facturas no cumplen con el parametro de fecha de vencimiento:\n" + MensajeRepetidos, "Fecha Vencimiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //bsVerificacion.DataSource = obj;
                    //ListFacturasV.Add(obj);
                    modal_frmVerificadas frm = new modal_frmVerificadas(ListFacturasV);
                    frm.ShowDialog();
                }
            }
        }
        /// <summary>
        /// Verifica las facturas que estén repetidas, en caso de que encuentre repetidas, imprime un mensaje de ALERTA
        /// </summary>
        private void VerificarDuplicados()
        {
            String MensajeRepetidos = "";
            if (ListFacturas.Count > 0)
            {
                var dataFacturas = ListFacturas.GroupBy(s => s.fac_fac_nu).Where(s => s.Count() != 1).ToList();
                foreach (var item in dataFacturas)
                    MensajeRepetidos += "No. Factura: " + item.Key + "\n";

                if (MensajeRepetidos != "")
                    XtraMessageBox.Show("Las siguientes facturas se encuentran repetidas:\n" + MensajeRepetidos, "Facturas Repetidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        /// <summary>
        /// Función que obtiene los registros del Grid, ya sea todos, o solamente el que tiene seleccionado
        /// </summary>
        /// <param name="ord_numero">
        /// Número
        /// </param>
        /// <returns></returns>
        private void GetData(String ord_numero = "")
        {
            //IEnumerable<viewFactura> factura;
            //List<viewFactura> ListFacturas = new List<viewFactura>();
            factura = new List<viewFactura>();
            remision = new List<viewRemision>();
            //facturasmasivas = new List<viewFacturasMasivas>();

            if (ord_numero != "")
            {
                //factura.Add((viewFactura)gvFacturas.GetRow(gvFacturas.FocusedRowHandle));
                factura = ListFacturas.Where(s => s.ord_numero.Contains(ord_numero)).ToList();

                // obtenemos el detalle de esta orden
                var dataRem = from rem in tbl_remision.AsQueryable()
                              select new viewRemision
                              {
                                  rem_numero = rem.rem_numero,
                                  rem_codig = rem.rem_codig,
                                  rem_desc = rem.rem_desc,
                                  rem_canti = rem.rem_canti,
                                  rem_precio = rem.rem_precio,
                                  rem_descue = rem.rem_descue,
                                  rem_impues = rem.rem_impues,
                                  rem_fec_ve = rem.rem_fec_ve
                              };
                remision = dataRem.Where(rem => rem.rem_numero == ord_numero).Where(s => s.rem_fec_ve.Month == (cmbMes.SelectedIndex + 1)).ToList();
                //remision = dataRem.Where(rem => rem.rem_numero == ord_numero).ToList();
            }
            else
            {

                // Seleccionamos únicamente las facturas que se visualizan en el grid
                for (int i = 0; i < gvFacturas.DataRowCount; i++)
                    factura.Add((viewFactura)gvFacturas.GetRow(i));

                var data = from fac in factura
                           join rem in tbl_remision on fac.ord_numero equals rem.rem_numero
                           select new viewRemision
                           {
                               rem_numero = rem.rem_numero,
                               rem_codig = rem.rem_codig,
                               rem_desc = rem.rem_desc,
                               rem_canti = rem.rem_canti,
                               rem_precio = rem.rem_precio,
                               rem_descue = rem.rem_descue,
                               rem_impues = rem.rem_impues,
                               rem_fec_ve = rem.rem_fec_ve
                           };

                remision = data.OrderBy(ord => ord.rem_numero).Where(s => s.rem_fec_ve.Month == (cmbMes.SelectedIndex + 1)).ToList();
                //remision = data.OrderBy(ord => ord.rem_numero).ToList();

                if (aoisfacturasgeneradas)
                {
                    foreach (var item in remision)
                    {
                        item.rem_fec_ve = aofecha_fact_vence_modal;
                    }
                }
            }
        }

        

        /// <summary>
        /// Crea los directorios en donde se alojaran fisicamente las facturas enviadas por correo electrónico
        /// </summary>
        private void CrearCarpetasFacturas()
        {            
            // Si no existe la carpeta con ese año y ese mes, la crea
            if (!System.IO.Directory.Exists(pathFact + "\\" + Year + "\\" + Month))
            {
                System.IO.Directory.CreateDirectory(pathFact + "\\" + Year + "\\" + Month);
            }            
        }


        private void mpxExport()
        {
            try
            {
                var aoSavcat = new SaveFileDialog { Filter = "Excel (2007) (*.xlsx)|*.xlsx|Excel (*.xls)|*.xls" };
                aoSavcat.ShowDialog();
                if (!String.IsNullOrEmpty(aoSavcat.FileName))
                {
                    string acFileName = aoSavcat.FileName;
                    string acFileExtension = new FileInfo(acFileName).Extension;

                    switch (acFileExtension)
                    {
                        case ".xls":
                            gcFacturas.ExportToXls(acFileName);
                            break;
                        case ".xlsx":
                            gcFacturas.ExportToXlsx(acFileName);
                            break;
                        default:
                            break;
                    }
                    if (XtraMessageBox.Show("¿Desea abrir el archivo exportado?", "Abrir", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(aoSavcat.FileName);
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

       

        #endregion

        #region EVENTOS

        private void frmFacturasAUD_Load(object sender, EventArgs e)
        {
            try
            {
                if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                {
                    pathTablas = Settings.Default.DirectorioTablasCZF;
                    pathFact = Settings.Default.DirectorioFacturasCZF;
                    pathTablaRemisionTemp = Settings.Default.DirectorioTablasRemisionCZF;
                    smtpCORREO = smtpCZF;
                }
                else if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CNZF)
                {
                    pathTablas = Settings.Default.DirectorioTablasCNZF;
                    pathFact = Settings.Default.DirectorioFacturasCNZF;
                    pathTablaRemisionTemp = Settings.Default.DirectorioTablasRemisionCNZF;
                    smtpCORREO = smtpCNZF;
                }

               // mlbl_smtp.Text = "SMTP: " + smtpCORREO;

                // Ocultamos los titulos de las pestañas
                xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
                //xtcTipoEnvio.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;

                // Asignamos valores iniciales a los controles
                int AnyoAct = DateTime.Now.Year;
                speAnno.Properties.MinValue = AnyoAct - 15;
                speAnno.Properties.MaxValue = AnyoAct + 1;
                speAnno.Value = AnyoAct;
                
                // Seleccionamos el mes en el que estamos
                cmbMes.SelectedIndex = DateTime.Now.Month - 1;

                // Por defecto el check Sin Formato aparecerá seleccionado
                chkSinFormat.Checked = true;

                // Verificamos que las rutas existan
                if (!VerificarRutas())
                {
                    btnImprimir.Enabled = false;
                    //btnEnviarCorreo.Enabled = false;
                    btnFiltrar.Enabled = false;
                    return;
                }

                // Consumimos las tablas DBF
                CargarDatosTablasDBF();

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
        /// Cierra el sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarFacturas();
            chkEntreMES.Enabled = true;
            chkEntreMES.CheckState = CheckState.Unchecked;
        }

        /// <summary>
        /// Imprime Facturas: Si tiene activado el Check de Impresión masiva, imprime todas las facturas visibles en el Grid, 
        /// en caso contrario solo imprime la factura seleccionada.
        /// Si tiene activado el Check Sin Formato, la factura imprime únicamente los datos (entendiéndose que se imprimirá en una hoja membretada),
        /// en caso contrario, la factura imprime todo (incluye el formato y los datos)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            String TituloReporteFactura = String.Empty;
            try
            {
                if (bsGrid.List.Count == 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("No hay facturas en este mes!", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }                

                //Solo imprime una
                if (!chkImpresionMasiva.Checked)
                {
                    if (gvFacturas.FocusedRowHandle < 0)
                    {
                        XtraMessageBox.Show("Seleccione una factura a imprimir", "Seleccione una Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    String ord_num = gvFacturas.GetFocusedRowCellValue("ord_numero").ToString();
                    GetData(ord_num);
                    TituloReporteFactura = "Imp. No. Fact: " + gvFacturas.GetFocusedRowCellValue("fac_fac_nu").ToString();
                }
                else  //Impresion Masiva
                {
                    GetData();
                    TituloReporteFactura = "Imp. Masivo de Fact.";
                }

                if (!chkSinFormat.Checked)
                {
                    if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                    {
                        String descfact = "Facturación del mes de " + cmbMes.Text + " - " + speAnno.Text;
                        Reports.rptFacturasCZF aorpt = new Reports.rptFacturasCZF(remision, descfact);
                        aorpt.DataSource = factura;
                        //aorpt.picLogo.Image = VisorFacturas.Properties.Resources.CZF_Logo;
                        frmviewer aofrmviewer = new frmviewer(aorpt);
                        aofrmviewer.Text = TituloReporteFactura;
                        aofrmviewer.MdiParent = this.MdiParent;
                        aofrmviewer.WindowState = FormWindowState.Maximized;
                        aofrmviewer.Show();
                    }
                    else
                    {
                        String descfact = txt_Mese.Text;// + " " + speAnno.Text;
                        Reports.xrFacturas aorpt = new Reports.xrFacturas(remision, cmbMes.Text, chkEntreMES.Checked, descfact);
                        aorpt.DataSource = factura;
                        aorpt.picLogo.Image = Resources.Comisión_Nacional_de_Zonas_Francas;
                        frmviewer aofrmviewer = new frmviewer(aorpt);
                        aofrmviewer.Text = TituloReporteFactura;
                        aofrmviewer.MdiParent = this.MdiParent;
                        aofrmviewer.WindowState = FormWindowState.Maximized;
                        aofrmviewer.Show();
                    }
                    
                }
                else  // SIN FORMATO
                {
                    if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                    {
                        String descfact = "Facturación del mes de " + cmbMes.Text + " - " + speAnno.Text;//<<<<<<aqui hay que tocar
                        Reports.rptFacturasSoloDatosCZF aorpt = new Reports.rptFacturasSoloDatosCZF(remision, descfact);
                        aorpt.DataSource = factura;
                        //aorpt.picLogo.Image = VisorFacturas.Properties.Resources.Comisión_Nacional_de_Zonas_Francas;
                        frmviewer aofrmviewer = new frmviewer(aorpt);
                        aofrmviewer.Text = TituloReporteFactura + " - S.F.";
                        aofrmviewer.MdiParent = this.MdiParent;
                        aofrmviewer.WindowState = FormWindowState.Maximized;
                        aofrmviewer.Show();
                    }
                    else
                    {
                        String descfact = txt_Mese.Text;// + " " + speAnno.Text;
                        Reports.xrFacturaSoloDatos aorpt = new Reports.xrFacturaSoloDatos(remision, cmbMes.Text, chkEntreMES.Checked, descfact);
                        aorpt.DataSource = factura;
                        aorpt.picLogo.Image = VisorFacturas.Properties.Resources.Comisión_Nacional_de_Zonas_Francas;
                        frmviewer aofrmviewer = new frmviewer(aorpt);
                        aofrmviewer.Text = TituloReporteFactura + " - S.F.";
                        aofrmviewer.MdiParent = this.MdiParent;
                        aofrmviewer.WindowState = FormWindowState.Maximized;
                        aofrmviewer.Show();
                    }                    
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error No: " + ex.HResult, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        
        
        /// <summary>
        /// Evento: Cuando cambia el filtro del Grid Facturas, totaliza las facturas encontradas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvFacturas_ColumnFilterChanged(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;
            gv.ViewCaption = "Total de Facturas Encontradas: " + gv.DataRowCount;
        }

        
        private void frmFacturasAUD_Resize(object sender, EventArgs e)
        {
            //if (this.Height >= 560)
            //{                
            //    groupctl_datos_correo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            //    groupctl_datos_correo.Height = 520;
            //}
            //else
            //{
            //    groupctl_datos_correo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                
            //}
        }

        private void btnexportar_Click(object sender, EventArgs e)
        {
            mpxExport();
        }

        private void btnimprimir_sobres_Click(object sender, EventArgs e)
        {
            try
            {
                List<viewClientes> aolistcli = new List<viewClientes>();

                // Recorremos las facturas que se muestran en el Grid para extraer el cliente
                // Seleccionamos únicamente las facturas que se visualizan en el grid
                for (int i = 0; i < gvFacturas.DataRowCount; i++)
                {
                    //Clientes
                    viewFactura aofact = (viewFactura)gvFacturas.GetRow(i);
                    viewClientes aocli = Clientes.FirstOrDefault(s => s.cli_cod == aofact.cli_codig);
                    if (aocli == null) { continue; }
                    aolistcli.Add(aocli);                    
                }

                // Imprimimos el reporte
                //Reports.xrsobres aorpt = new Reports.xrsobres();
                Reports.xrsobresVertical aorpt = new Reports.xrsobresVertical();
                aorpt.DataSource = aolistcli;
                //aorpt.picLogo.Image = VisorFacturas.Properties.Resources.Comisión_Nacional_de_Zonas_Francas;
                frmviewer aofrmviewer = new frmviewer(aorpt);
                aofrmviewer.Text = "Impresión de Sobres";
                aofrmviewer.MdiParent = this.MdiParent;
                aofrmviewer.WindowState = FormWindowState.Maximized;
                aofrmviewer.Show();


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void btnGenerarFactEne_Click(object sender, EventArgs e)
        {
            xdModalform myDialogform = new xdModalform();
            if (DevExpress.XtraEditors.XtraDialog.Show(myDialogform, "Parámetros para facturas", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                aoisfacturasgeneradas = true;
                aonum_fact_ini_modal = (Int32)(myDialogform.mlytctrl.Controls["modal_spenumfacturaini"] as SpinEdit).Value;
                aofecha_fact_modal = (DateTime)(myDialogform.mlytctrl.Controls["modal_dteFechaFact"] as DateEdit).DateTime;
                aofecha_fact_vence_modal = new DateTime(aofecha_fact_modal.Year, aofecha_fact_modal.Month, 20);

                int aonumfac = aonum_fact_ini_modal;
                foreach (var item in ListFacturas)
                {
                    item.fac_fac_nu = aonumfac;
                    item.fecha = aofecha_fact_modal;
                    aonumfac++;
                }

                //bsGrid.Clear();
                bsGrid.DataSource = ListFacturas.ToList();
            }
        }

        #endregion

       
        /// <summary>
        /// Aqui controlo si se muestran el campo entre meses
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkEntreMES_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit aosender = sender as CheckEdit;
            if ((aosender.EditValue != DBNull.Value) && (aosender.EditValue != null) && (Convert.ToString(aosender.EditValue) != ""))
            {                
                    switch (aosender.Checked)
                    {
                        //Entra cuando esta seleccionado
                        case true:
                        chkImpresionMasiva.CheckState = CheckState.Unchecked;
                        chkImpresionMasiva.Enabled = false;
                        //txt_Mese.Text = "";
                        txt_meses.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        break;
                        //Entra cuando esta deseleccionado
                        case false:
                        //txt_Mese.Text = "";
                        chkImpresionMasiva.Enabled = true;
                        txt_meses.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        
                        break;
                       
                    }
            }
        }

        private void mtofileFcVence(string v1, string v2)
        {
            StreamWriter escribir = new StreamWriter(@"C:\LogMesFcVen\"+ v1 + "");
        }
    }
}