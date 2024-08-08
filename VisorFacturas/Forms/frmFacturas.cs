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
    public partial class frmFacturas : DevExpress.XtraEditors.XtraForm
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

        public frmFacturas(tblUser paCurrentUser)
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
                command = new OleDbCommand(sqlFacturas, con);
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
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error No: " + ex.HResult, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga las facturas conforme al mes y año especificados
        /// </summary>
        private void CargarFacturas()
        {
            try
            {
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
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error No: " + ex.HResult, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// Función que se encarga de enviar correo a VARIOS destinatarios
        /// </summary>
        /// <param name="From"></param>
        /// <param name="NameFrom"></param>
        /// <param name="to"></param>
        /// <param name="Subject"></param>
        /// <param name="Message"></param>
        /// <param name="Attachements"></param>
        private void EnviarCorreo(String From, String NameFrom, String[] to, String Subject, String Message, String[] Attachements = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                // creamos el objeto mail
                mail.From = new MailAddress(From, NameFrom);
                mail.Subject = Subject.Trim();

                // Agregamos los destinatarios
                foreach (var t in to)
                {
                    if (!String.IsNullOrEmpty(t))                    
                        mail.To.Add(new MailAddress(t));                    
                }

                // Agregamos los archivos adjuntos (en caso de que hubieran)
                if (Attachements != null)
                {
                    foreach (var attach in Attachements)
                    {
                        if (!String.IsNullOrEmpty(attach))
                            mail.Attachments.Add(new Attachment(attach));
                    }
                }

                // Pregunta si NO es un envio de correo de notificación de error (Clientes que no se le pudo enviar el correo)
                if (isErrorSendMail == false)
                {
                    // Se pregunta si tiene activado el check de Copia del Remitente
                    if (mchk_copia_remitente.Checked)
                    {
                        // Si lo tiene activo, se agregara el correo del remitente en CC del correo
                        mail.CC.Add(new MailAddress(correoRemitent));
                        //mail.CC.Add(new MailAddress(From)); //correoRemitent
                        // Y se desactiva la notificación
                        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.Never;
                    }
                    else
                    {
                        // Únicamente se activa la notificación de llegada de correo
                        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                    }
                }

                /*********************************************************************************************************************/
                /*                                                CUERPO DEL MENSAJE                                                 */
                /*********************************************************************************************************************/
                // Si el parámetro Mensaje viene vacío, entonces tomamos lo que esta escrito en el campo de texto Mensaje
                if (String.IsNullOrEmpty(Message))
                {
                    // Preguntamos qué pestaña del cuerpo del mensaje se está mostrando actualmente
                    if (xtcCuerpoMail.SelectedTabPage == xtpTextoNormal)  // ******* TEXTO NORMAL
                    {
                        mail.Body = txtCuerpo.Text.Trim();
                    }
                    else // ******************************************************** TEXTO ENRIQUECIDO
                    {
                        RichEditMailMessageExporter exporter = new RichEditMailMessageExporter(mrtxt_cuerpoMail, mail);
                        exporter.Export();
                    }
                }
                else
                    mail.Body = Message;

                #region CUERPO DEL MENSAJE - A como estaba antes
                // Para mientras, el envio de facturas se hará por HTML, debido a que en el cuerpo del mensaje se inserta una imagen.
                // Este tipo de mensaje HTML se creó temporalmente, hasta que se dé la orden de quitar la circular del cuerpo del mensaje
                // El mensaje html solo afecta al envío de facturas. Para los envios de Aviso, se hace como antes (utilizando el campo de texto CUERPO)
                //if (htmlView != null)
                //{
                //    mail.Body = "";
                //    mail.AlternateViews.Add(htmlView);
                //}
                //else
                //{
                //    mail.Body = Message;
                //}
                #endregion


                using (var mailSender = new SmtpClient())
                {
                    mailSender.Host = smtpCORREO; //"ns.czf.com.ni";// "mail.cnzf.gob.ni";// smtpCORREO;


                    mailSender.UseDefaultCredentials = false;
                    mailSender.Port = 25;
                    mailSender.Credentials = new System.Net.NetworkCredential(From, UserPass);
                    ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) { return true; };
                    mailSender.DeliveryFormat = SmtpDeliveryFormat.International;
                    mailSender.DeliveryMethod = SmtpDeliveryMethod.Network;
                    mailSender.EnableSsl = true;

                    mailSender.Send(mail);
                }

            }
            catch (FormatException)
            {
                String msg_fex = "La dirección del correo electrónico es incorrecta";
                // Agregamos un registro al listado de capturas de errores
                ListClientes_Err.Add(new viewClientes()
                {
                    cli_nom = cliente_selected.cli_nom,
                    cli_email1 = cliente_selected.cli_email1,
                    cli_email2 = cliente_selected.cli_email2,
                    cli_dir = msg_fex // El campo dir se usara para escribir el mensaje del error
                });
                //XtraMessageBox.Show(msg_fex, "Error No: " + fex.HResult, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ListClientes_Err.Add(new viewClientes()
                {
                    cli_nom = cliente_selected.cli_nom,
                    cli_email1 = cliente_selected.cli_email1,
                    cli_email2 = cliente_selected.cli_email2,
                    cli_dir = ex.Message // El campo dir se usara para escribir el mensaje del error
                });
                //XtraMessageBox.Show(ex.Message, "Error No: " + ex.HResult, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
               
        /// <summary>
        /// Función que se encarga de validar los datos del formulario de Correo
        /// </summary>
        /// <returns></returns>
        private Boolean VerificarDatos()
        {
            Boolean isValid = true;

            dxErrProv.ClearErrors();

            if (String.IsNullOrEmpty(txtNombreRem.Text.Trim()))
            {
                isValid = false;
                dxErrProv.SetError(txtNombreRem, "No deje vacío este campo!");
                dxErrProv.SetIconAlignment(txtNombreRem, ErrorIconAlignment.MiddleRight);
            }

            if (String.IsNullOrEmpty(txtCorreoRem.Text.Trim()))
            {
                isValid = false;
                dxErrProv.SetError(txtCorreoRem, "No deje vacío este campo!");
                dxErrProv.SetIconAlignment(txtCorreoRem, ErrorIconAlignment.MiddleRight);
            }

            if (String.IsNullOrEmpty(txtAsunto.Text.Trim()))
            {
                isValid = false;
                dxErrProv.SetError(txtAsunto, "No deje vacío este campo!");
                dxErrProv.SetIconAlignment(txtAsunto, ErrorIconAlignment.MiddleRight);
            }

            if (xtcCuerpoMail.SelectedTabPage == xtpTextoNormal)
            {
                if (String.IsNullOrEmpty(txtCuerpo.Text.Trim()))
                {
                    isValid = false;
                    dxErrProv.SetError(txtCuerpo, "No deje vacío este campo!");
                    dxErrProv.SetIconAlignment(txtCuerpo, ErrorIconAlignment.TopLeft);
                }
            }
            else
            {
                if (mrtxt_cuerpoMail.Document.IsEmpty)
                {
                    isValid = false;
                    dxErrProv.SetError(mrtxt_cuerpoMail, "No deje vacío este campo!");
                    dxErrProv.SetIconAlignment(mrtxt_cuerpoMail, ErrorIconAlignment.TopLeft);
                }
            }

            return isValid;
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

        

        /// <summary>
        /// Rellena los datos por defecto del correo
        /// </summary>
        private void LlenarDatosCorreo(int num)
        {           

            String TituloMensaje = string.Empty;
            String TituloMensaje_cuerpo = string.Empty;
            //String Cuerpo_Html = string.Empty;
            //String font_style = "font-family: Arial, Helvetica, sans-serif;";
            //String Ruta_imagen = pathTablaRemisionTemp + @"\circular.jpg";
            String Ruta_archivo_body_default = pathTablaRemisionTemp + @"\body-msg-default.docx";
            htmlView = null;
            img = null;

            if (num == 0) //AQUÍ ENTRA SI ES FACTURA
            {
                //TituloMensaje = "AVISO DE COBRO " + cmbMes.Text.ToUpper() + " " + speAnno.Text;
                TituloMensaje_cuerpo = "Aviso de Cobro " + cmbMes.Text + " " + speAnno.Text;
                TituloMensaje = TituloMensaje_cuerpo.ToUpper();
                txtCuerpo.Text = "Estimados Señores" + Environment.NewLine + Environment.NewLine + "Se les envía por este medio el " + TituloMensaje_cuerpo +
                " para su debida cancelación, recuerden que el vencimiento de la factura son los 10 de cada mes. Para gozar de los " +
                "beneficios que otorga el Régimen hay que tener al día sus pagos." + Environment.NewLine + Environment.NewLine +
                "Favor hacer caso omiso si esta factura ya fue cancelada." + Environment.NewLine + Environment.NewLine + "Saludos!";

                if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CNZF)
                {
                    //// Este codigo es para crear el cuerpo del mensaje en Formato HTML
                    //Cuerpo_Html += String.Format(@"<h4 style=""{0}"">Estimados Señores</h4>", font_style);
                    //Cuerpo_Html += String.Format(@"<p style=""{0}"">Se les envía por este medio el <b>{1}</b> para su ", font_style, TituloMensaje_cuerpo);
                    //Cuerpo_Html += String.Format(@"debida cancelación, recuerden que el vencimiento de la factura son los 10 de cada mes. Para gozar de los ");
                    //Cuerpo_Html += String.Format(@"beneficios que otorga el Régimen hay que tener al día sus pagos.</p>");
                    //Cuerpo_Html += String.Format(@"<p style=""{0}"">Favor hacer caso omiso si esta factura ya fue cancelada.</p>", font_style);
                    //Cuerpo_Html += String.Format(@"<p style=""{0}"">Un cordial saludo!</p>", font_style);
                    //Cuerpo_Html += String.Format(@"<img src='cid:imagen_circular' style=""width:70%;height:70%"">");

                    //htmlView = AlternateView.CreateAlternateViewFromString(Cuerpo_Html, Encoding.UTF8, MediaTypeNames.Text.Html);

                    //// Creamos el recurso a incrustar. El ID de la imagen que le asignamos (arbitrario) está referenciado desde el código HTML como origen de la imagen
                    //img = new LinkedResource(Ruta_imagen, MediaTypeNames.Image.Jpeg);
                    //img.ContentId = "imagen_circular";

                    //// Lo incrustamos en la vista HTML...
                    //htmlView.LinkedResources.Add(img);

                    // Lo pegamos en el Rich Text Editor
                    mrtxt_cuerpoMail.LoadDocument(Ruta_archivo_body_default);
                    mrtxt_cuerpoMail.Document.RtfText = mrtxt_cuerpoMail.Document.RtfText.Replace("<Mes><Year>", cmbMes.Text + " " + speAnno.Value.ToString());

                    // Mostramos la pestaña donde se encuentra el Rich Control
                    xtcCuerpoMail.SelectedTabPage = xtpTextoEnriquecido;
                    xtpTextoNormal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                    
                }
                else
                {
                    // Mostramos la pestaña donde se encuentra el Texto Normal                    
                    xtpTextoNormal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    xtcCuerpoMail.SelectedTabPage = xtpTextoNormal;
                }
            }
            else if(num == 1) //AQUÍ ENTRA SI ES COMUNICADO
            {
                TituloMensaje = "";
                txtCuerpo.Text = "";

                // Mostramos la pestaña donde se encuentra el Texto Normal                    
                xtpTextoNormal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                xtcCuerpoMail.SelectedTabPage = xtpTextoNormal;
            }

            txtNombreRem.Text = moCurrentUser.fullname;
            txtCorreoRem.Text = "impresora@cnzf.gob.ni";// moCurrentUser.email; //"impresora@cnzf.gob.ni";//
            UserCorreo = "impresora@cnzf.gob.ni";
            UserPass = "CnzF_cnzf4dm1ni$tr@Print.";
            //if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
            //{
            //    txtNombreRem.Text = NombreRemitenteCZF;
            //    txtCorreoRem.Text = CorreoremitenteCZF;
            //}
            //else
            //{
            //    txtNombreRem.Text = NombreRemitenteCNZF;
            //    txtCorreoRem.Text = CorreoremitenteCNZF;
            //}
            txtAsunto.Text = TituloMensaje;
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

        private void mpxAvisoClientesSinEnvioFact(List<viewClientes> listClientes_Err)
        {
            String nombreRemitent = moCurrentUser.fullname;
            correoRemitent = moCurrentUser.email;
            String titulocorreo;
            String cuerpocorreo;
            String[] arrayAdjuntos = new String[1];
            arrayAdjuntos[0] = pathFact + "\\" + Year + "\\" + Month + "\\" + "reporte_clientes_sin_facturas_" + DateTime.Now.ToString("yyyy_MM_dd") + "_" + DateTime.Now.ToString("HHmm") + ".pdf";

            String[] CorreosDestinos = new String[2];
            CorreosDestinos[0] = new Util.clslistusers().GetUserSystem(@"zfrancas\dgonzalez", null).email;
            CorreosDestinos[1] = new Util.clslistusers().GetUserSystem(@"zfrancas\rsblanco", null).email;
            CorreosDestinos[2] = new Util.clslistusers().GetUserSystem(@"zfrancas\aaviles", null).email;
            CorreosDestinos[3] = new Util.clslistusers().GetUserSystem(@"zfrancas\wmejia", null).email;
            //CorreosDestinos[0] = new Util.clslistusers().GetUserSystem(@"zfrancas\adavila", null).email;

            //Creamos el reporte, sin imprimirlo
            String TituloRpt;
            if (chkAviso.Checked)
            {
                titulocorreo = "Clientes sin recibir correo de Aviso";
                TituloRpt = "Listado de Clientes que no recibieron el Correo de Aviso";
                cuerpocorreo = "Este es un correo emitido por el sistema 'VisorFacturas'." + Environment.NewLine + Environment.NewLine +
                                  "En el envío masivo del correo de Aviso a clientes, el sistema detectó algunos conflictos con los correos de algunos clientes. Por favor revisar el archivo adjunto." + Environment.NewLine + Environment.NewLine +
                                  "Usuario que imprimió: " + moCurrentUser.fullname + "   Fecha/Hora: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            }
            else
            {
                titulocorreo = "Aviso de Clientes sin factura de " + cmbMes.Text + " " + speAnno.Text;
                TituloRpt = "Listado de Clientes sin factura de " + cmbMes.Text + " " + speAnno.Text;
                cuerpocorreo = "Este es un correo emitido por el sistema 'VisorFacturas'." + Environment.NewLine + Environment.NewLine +
                                   "En el envío masivo de facturas a clientes, el sistema detectó algunos conflictos con los correos de algunos clientes. Por favor revisar el archivo adjunto." + Environment.NewLine + Environment.NewLine +
                                   "Usuario que imprimió: " + moCurrentUser.fullname + "   Fecha/Hora: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            }


            Reports.CNZF.xrclientsinfact aorpt = new Reports.CNZF.xrclientsinfact(TituloRpt);
            aorpt.DataSource = listClientes_Err;
            //aorpt.picLogo.Image = VisorFacturas.Properties.Resources.Comisión_Nacional_de_Zonas_Francas;
            // Exportamos el reporte en formato PDF
            aorpt.ExportToPdf(arrayAdjuntos[0]);
            aorpt.Dispose();
            // Adjuntamos el archivo PDF en la variable adjuntos (type Array String)

            // Enviamos el correo
            isErrorSendMail = true; //UserCorreo
            //EnviarCorreo(correoRemitent, nombreRemitent, CorreosDestinos, titulocorreo, cuerpocorreo, arrayAdjuntos);
            EnviarCorreo(UserCorreo, nombreRemitent, CorreosDestinos, titulocorreo, cuerpocorreo, arrayAdjuntos);

        }

        #endregion

        #region EVENTOS

        private void frmFacturas_Load(object sender, EventArgs e)
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

                mlbl_smtp.Text = "SMTP: " + smtpCORREO;

                // Ocultamos los titulos de las pestañas
                xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
                xtcTipoEnvio.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;

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
                    btnEnviarCorreo.Enabled = false;
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
        /// Evento que redirecciona del tab Facturas al Tab Correos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnviarCorreo_Click(object sender, EventArgs e)
        {
            if ((bsGrid.List.Count == 0) && (!chkAviso.Checked))
            {
                XtraMessageBox.Show("No hay facturas en este mes!", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtAdjuntar.Text = string.Empty;
            //btnAdjun.Enabled = true;

            if (chkAviso.Checked)
                btnAdjun.Enabled = true;
            else
                btnAdjun.Enabled = false;

            // Se activa por defecto la CC al remitente
            mchk_copia_remitente.Checked = true;
            mchk_copia_remitente.Visible = true;
            mchk_copia_remitente.Enabled = false;

            try
            {
                // Si va a imprimir Facturas masivas
                if (chkImpresionMasiva.Checked)
                {
                    List<viewClientes> ClientesFiltrados = new List<viewClientes>();
                    for (int i = 0; i < gvFacturas.DataRowCount; i++)
                    {
                        // Obtenemos la factura
                        viewFactura fac = (viewFactura)gvFacturas.GetRow(i);
                        // Agregamos el cliente
                        ClientesFiltrados.Add(Clientes.Where(s => s.cli_cod.Contains(fac.cli_codig)).FirstOrDefault());
                    }

                    bsClientes.DataSource = ClientesFiltrados;                    
                    xtcTipoEnvio.SelectedTabPage = xtpEnvioMasivo;

                }
                else
                {
                    // Si solo va a imprimir una Factura
                    if (gvFacturas.FocusedRowHandle < 0)// && (!chkAviso.Checked))
                    {
                        XtraMessageBox.Show("Seleccione una factura para enviar por correo", "Seleccione una Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Seleccionamos los datos del cliente de la factura seleccionada
                    viewFactura fact_select = (viewFactura)bsGrid.Current;
                    CodClienteSelect = fact_select.cli_codig;

                    cliente_selected = Clientes.Where(s => s.cli_cod.Contains(CodClienteSelect)).FirstOrDefault();
                    //var Cliente = from cli in tbl_clientes.AsQueryable() 
                    //                    where cli.cli_cod.Contains(CodClienteSelect)
                    //                    select new viewClientes {
                    //                        cli_cod = cli.cli_cod,
                    //                        cli_nom = cli.cli_nom,
                    //                        cli_dir = cli.cli_dir,
                    //                        cli_email1 = cli.cli_email1,
                    //                        cli_email2 = cli.cli_email2
                    //                    };

                    LstCorreosIndiv.Items.Clear();
                    if (cliente_selected != null)
                    {
                        if (!String.IsNullOrEmpty(cliente_selected.cli_email1))
                            LstCorreosIndiv.Items.Add(cliente_selected.cli_email1.Trim());

                        if (!String.IsNullOrEmpty(cliente_selected.cli_email2))
                            LstCorreosIndiv.Items.Add(cliente_selected.cli_email2.Trim());

                        // Correos de prueba
                        //LstCorreosIndiv.Items.Add("wmejia@czf.com.ni");
                        //LstCorreosIndiv.Items.Add("davilaandres95@gmail.com");
                        //LstCorreosIndiv.Items.Add("restrada.czf.com.ni");

                    }
                    txtEnvioIndividual.Text = cliente_selected.cli_nom;
                    xtcTipoEnvio.SelectedTabPage = xtpEnvioIndividual;
                }

                if (!chkAviso.Checked)
                    LlenarDatosCorreo(0);
                else
                    LlenarDatosCorreo(1);

                dxErrProv.ClearErrors();
                xtraTabControl1.SelectedTabPage = xtpCorreos;
                txtNombreRem.Focus();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error No: " + ex.HResult, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se encarga de enviar las facturas. Si tiene activado el Check Facturas Masivas, las facturas se les envía a su respectivo cliente.
        /// En caso contrario, solo enviará la factura que tenga seleccionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!VerificarDatos())
                {
                    XtraMessageBox.Show("Hay algunos campos que debe ingresar!", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!chkImpresionMasiva.Checked)
                {
                    if (LstCorreosIndiv.Items.Count == 0)
                    {
                        XtraMessageBox.Show("Este Cliente no tiene registrado algún correo.\n", "No se puede enviar correo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                DialogResult result = XtraMessageBox.Show("¿Está seguro que desea enviar los correos electrónicos?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Si presiono la tecla NO, sale del evento, en caso contrario continua
                if (result == DialogResult.No)
                    return;

                // Ruta de la factura
                String PathAttach_Fact = string.Empty;
                String PathAttach_Adjunto = string.Empty;
                isErrorSendMail = false;

                // Verificamos si existen las carpetas en donde se alojaran las facturas
                Month = cmbMes.Text;
                Year = speAnno.Value.ToString();
                CrearCarpetasFacturas();

                // listado de archivos adjuntos. MAX: 5
                String[] adjuntos = new String[5];

                // Limpiamos el Binding source de la tabla captura de errores
                if (bsClientes_err.Count > 0) { bsClientes_err.Clear(); }

                // Inicializamos la variable
                ListClientes_Err = new List<viewClientes>();

                // Variable para el Asunto del correo
                String Asunto = "";

                // Si solo Imprime una Factura
                if (!chkImpresionMasiva.Checked)
                {
                    #region ENVIO DE CORREO DE UN SOLO CLIENTE                    

                    // Codigo del cliente
                    CodClienteSelect = cliente_selected.cli_cod;

                    if (!chkAviso.Checked)
                    {
                        // Ruta de la factura (Exigida)
                        PathAttach_Fact = pathFact + "\\" + Year + "\\" + Month + "\\" + CodClienteSelect + "-" + cliente_selected.cli_nom.Trim() + ".pdf";
                        // Ruta del Adjunto (Opcional)
                        PathAttach_Adjunto = txtAdjuntar.Text;

                        if (PathAttach_Fact == string.Empty)
                        {
                            XtraMessageBox.Show("Ha ocurrido un problema al crear la ruta de las facturas. Favor comunicarse con soporte técnico!", "Problemas con la ruta de las Facturas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else if (chkAviso.Checked)
                    {
                        // Ruta del Adjunto (Exigida)
                        PathAttach_Adjunto = txtAdjuntar.Text;
                        //if (PathAttach_Adjunto == string.Empty)
                        //{
                        //    XtraMessageBox.Show("No hay una ruta seleccionada", "Seleccione un archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //    return;
                        //}
                    }                    

                    // Listado de correos: Permito 5 correos, aunque solo ingrese dos correos
                    String[] CorreosCli = new String[5];

                    // Añadimos los correos que están en la Lista
                    for (int i = 0; i < LstCorreosIndiv.Items.Count; i++)
                    {
                        CorreosCli[i] = LstCorreosIndiv.Items[i].ToString().ToLower().Trim();
                    }

                    if (!String.IsNullOrEmpty(CorreosCli[0]) || !String.IsNullOrEmpty(CorreosCli[1]))
                    {
                        if (!chkAviso.Checked)
                        {
                            // obtenemos la factura seleccionada
                            viewFactura fac_selected = (viewFactura)bsGrid.Current;
                            GetData(fac_selected.ord_numero);

                            // Creamos el reporte pero no  lo imprimimos
                            Reports.xrFacturas aorpt = new Reports.xrFacturas(remision, cmbMes.Text, false, string.Empty);
                            aorpt.DataSource = factura;
                            aorpt.picLogo.Image = VisorFacturas.Properties.Resources.Comisión_Nacional_de_Zonas_Francas;
                            // Exportamos el reporte en PDF
                            aorpt.ExportToPdf(PathAttach_Fact);
                            aorpt.Dispose();

                            Asunto = txtAsunto.Text + " - " + cliente_selected.cli_nom;

                            // Adjuntamos el archivo que exportamos en PDF
                            adjuntos[0] = PathAttach_Fact;
                            // Verificamos si existe un adjunto mas
                            if (!String.IsNullOrEmpty(PathAttach_Adjunto))
                            {
                                adjuntos[1] = PathAttach_Adjunto;
                            }
                        }
                        else
                        {
                            Asunto = txtAsunto.Text;
                            adjuntos[0] = PathAttach_Adjunto;
                        }
                        
                        // Enviamos el correo
                        EnviarCorreo(txtCorreoRem.Text.Trim(), txtNombreRem.Text, CorreosCli, Asunto, ""/*txtCuerpo.Text*/, adjuntos);
                    }
                    else
                    {
                        // Agregamos un registro al listado de capturas de errores
                        ListClientes_Err.Add(new viewClientes()
                        {
                            cli_nom = cliente_selected.cli_nom,
                            cli_email1 = cliente_selected.cli_email1,
                            cli_email2 = cliente_selected.cli_email2,
                            cli_dir = "Este cliente no tiene digitado sus correos electrónicos." // El campo dir se usara para escribir el mensaje del error
                        });
                    }
                    

                    #endregion
                }
                else
                {
                    #region ENVIO MASIVO DE CORREOS ELECTRÓNICOS                    

                    //// Si Imprime varias facturas
                    // Por si ya estaba abierto, cerramos el splash form
                    if (mspsmForm.IsSplashFormVisible) { mspsmForm.CloseWaitForm(); }

                    //Formulario de espera abierto
                    mspsmForm.ShowWaitForm();
                    mspsmForm.SetWaitFormCaption("Enviando las Facturas...");
                    int ancountertotal = gvFacturas.RowCount;
                    int ancounterposition = 0;

                    for (int i = 0; i < gvFacturas.DataRowCount; i++)
                    {
                        // Aumentamos el porcentaje de progreso
                        ancounterposition++;
                        mspsmForm.SetWaitFormDescription(String.Format("Progreso de envío de facturas: {0:n2}% ", ((decimal)ancounterposition / (decimal)ancountertotal) * (decimal)100));

                        //if (i == 262)
                        //{
                        //    Console.WriteLine("");
                        //}

                        // Obtenemos la factura
                        viewFactura fac = (viewFactura)gvFacturas.GetRow(i);
                        //Obtenemos el cliente de la Factura
                        cliente_selected = Clientes.Where(s => s.cli_cod.Contains(fac.cli_codig)).FirstOrDefault();

                        // Listado de correos: Permito 5 correos, aunque solo ingrese dos correos
                        String[] CorreosCli = new String[5];

                        // Verificamos que no estén nulos o vacios los campos correos
                        if (!String.IsNullOrEmpty(cliente_selected.cli_email1))
                            CorreosCli[0] = cliente_selected.cli_email1.Trim();

                        if (!String.IsNullOrEmpty(cliente_selected.cli_email2))
                            CorreosCli[1] = cliente_selected.cli_email2.Trim();
                        
                        //Verificamos que el cliente tenga el Check de Enviar (ESTO SE QUITÓ PERO QUEDA POR SI SE RETOMA)
                        //bool enviar;
                        //Boolean.TryParse(gvCorreos.GetRowCellValue(i, "enviar").ToString(), out enviar);
                        //if (enviar)
                        //{

                        // Validamos que tenga algun correo válido. Si no tiene ninguno, no se envía el correo a este cliente ni se crea el archivo PDF de la factura
                        if (!String.IsNullOrEmpty(CorreosCli[0]) || !String.IsNullOrEmpty(CorreosCli[1]))
                        {
                            // Codigo del cliente
                            CodClienteSelect = cliente_selected.cli_cod.Trim();

                            if (!chkAviso.Checked)
                            {
                                // Ruta de la factura (Es obligatoria, por eso se valida)
                                PathAttach_Fact = pathFact + "\\" + Year + "\\" + Month + "\\" + CodClienteSelect + "-" + cliente_selected.cli_nom.Trim() + ".pdf";
                                // Ruta del Adjunto (Opcional)
                                PathAttach_Adjunto = txtAdjuntar.Text;

                                if (PathAttach_Fact == string.Empty)
                                {
                                    XtraMessageBox.Show("Ha ocurrido un problema al crear la ruta de las facturas. Favor comunicarse con soporte técnico!", "Problemas con la ruta de las Facturas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            else if (chkAviso.Checked)
                            {
                                // Ruta del Adjunto (Es obligatoria, por eso se valida)
                                PathAttach_Adjunto = txtAdjuntar.Text;
                                //if (PathAttach_Adjunto == string.Empty)
                                //{
                                //    XtraMessageBox.Show("No hay una ruta seleccionada", "Seleccione un archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //    return;
                                //}
                            }

                            //if (PathAttach_Fact == string.Empty)
                            //{
                            //    XtraMessageBox.Show("No hay una ruta seleccionada", "Seleccione un archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //    return;
                            //}
                            if (!chkAviso.Checked)
                            {
                                ////Verificamos que tenga factura en este mes para enviar
                                GetData(fac.ord_numero);
                                if (factura.ToList().Count() > 0)
                                {
                                    //Creamos el reporte, sin imprimirlo
                                    Reports.xrFacturas aorpt = new Reports.xrFacturas(remision, cmbMes.Text, false, string.Empty);
                                    aorpt.DataSource = factura;
                                    aorpt.picLogo.Image = VisorFacturas.Properties.Resources.Comisión_Nacional_de_Zonas_Francas;
                                    // Exportamos el reporte en formato PDF
                                    aorpt.ExportToPdf(PathAttach_Fact);
                                    aorpt.Dispose();
                                    // Adjuntamos el archivo PDF en la variable adjuntos (type Array String)
                                    adjuntos[0] = PathAttach_Fact;
                                    // Verificamos si existe un adjunto mas
                                    if (!String.IsNullOrEmpty(PathAttach_Adjunto))
                                    {
                                        adjuntos[1] = PathAttach_Adjunto;
                                    }

                                    // Asunto + nombre del cliente
                                    Asunto = Asunto = txtAsunto.Text + " - " + cliente_selected.cli_nom;
                                    // Enviamos el correo
                                    EnviarCorreo(txtCorreoRem.Text.Trim(), txtNombreRem.Text, CorreosCli, Asunto, ""/*txtCuerpo.Text*/, adjuntos);
                                    //Console.WriteLine("Factura Nº " + i.ToString() + " enviada!");
                                    
                                }                                
                            }
                            else
                            {
                                // Adjuntamos el archivo PDF en la variable adjuntos (type Array String)
                                adjuntos[0] = PathAttach_Adjunto;
                                // Enviamos el correo
                                EnviarCorreo(txtCorreoRem.Text.Trim(), txtNombreRem.Text, CorreosCli, txtAsunto.Text, ""/*txtCuerpo.Text*/, adjuntos);
                            }

                        }
                        else
                        {
                            // Agregamos un registro al listado de capturas de errores
                            ListClientes_Err.Add(new viewClientes() {
                                cli_nom = cliente_selected.cli_nom,
                                cli_email1 = cliente_selected.cli_email1,
                                cli_email2 = cliente_selected.cli_email2,
                                cli_dir = "Este cliente no tiene digitado sus correos electrónicos." // El campo dir se usara para escribir el mensaje del error
                            });
                        }

                        //} // end del if que pregunta si tiene marcada la casilla de Enviar (ESTO SE QUITO, PERO SE DEJA POR SI SE RETOMA)
                    } // end del for que recorre las facturas

                    #endregion 

                } // end del if que pregunta si es Envío Individual o Masivo

                if (mspsmForm.IsSplashFormVisible)
                    mspsmForm.CloseWaitForm();

                bsClientes_err.DataSource = ListClientes_Err;
                if (ListClientes_Err.Count > 0)
                {
                    // Si tiene activado envio masivo, y la lista de errores es menor que la lista de facturas (clientes), quiere decir que 
                    // algunas facturas se enviaron pero otras no
                    if (chkImpresionMasiva.Checked && ListClientes_Err.Count < gvFacturas.DataRowCount)
                    {
                        txtAsunto.Text = "";
                        txtCuerpo.Text = "";
                        xtraTabControl1.SelectedTabPage = xtpCapturaErr;
                        XtraMessageBox.Show("Los correos han sido enviados, exceptos a los clientes que están en el siguiente listado", "Envío exitoso pero con algunos errores", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        // Enviamos un correo a David Gonzalez y Ramona Blanco indicando cuales fueron los clientes a los que el sistema no pudo enviarles el correo                        
                        mpxAvisoClientesSinEnvioFact(ListClientes_Err);
                    }
                    else
                    {
                        txtAsunto.Text = "";
                        txtCuerpo.Text = "";
                        xtraTabControl1.SelectedTabPage = xtpCapturaErr;
                        XtraMessageBox.Show("Los correos no se pudieron enviar. Por favor revise el siguiente listado.", "Han ocurrido algunos errores", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        mpxAvisoClientesSinEnvioFact(ListClientes_Err);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Todos los Correos electrónicos se enviaron correctamente", "Envío exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAsunto.Text = "";
                    txtCuerpo.Text = "";
                    xtraTabControl1.SelectedTabPage = xtpFacturas;
                }              
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error No: " + ex.HResult, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        /// <summary>
        /// Evento que redirecciona del Tab Correo al Tab Facturas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPage = xtpFacturas;
            mrtxt_cuerpoMail.CreateNewDocument();
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

        
        private void frmFacturas_Resize(object sender, EventArgs e)
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

        private void btnAdjun_Click(object sender, EventArgs e)
        {
            OpenFileDialog examinar = new OpenFileDialog();
            if (examinar.ShowDialog() == DialogResult.OK)
            {
                txtAdjuntar.Text = examinar.FileName;
            }
            else
                txtAdjuntar.Text = string.Empty;
        }

        private void btnimprimir_err_Click(object sender, EventArgs e)
        {
            if (mcapterr_gv.RowCount > 0)
            {
                mcapterr_gc.ShowRibbonPrintPreview();
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

        private void mrtxt_cuerpoMail_DocumentLoaded(object sender, EventArgs e)
        {
            mrtxt_cuerpoMail.Document.DefaultCharacterProperties.FontSize = 10;
            mrtxt_cuerpoMail.Document.DefaultCharacterProperties.FontName = "Arial";
            mrtxt_cuerpoMail.Document.DefaultCharacterProperties.ForeColor = Color.Black;

            mrtxt_cuerpoMail.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            mrtxt_cuerpoMail.Options.VerticalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            mrtxt_cuerpoMail.Options.HorizontalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            mrtxt_cuerpoMail.Options.VerticalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            mrtxt_cuerpoMail.Views.SimpleView.Padding = new DevExpress.Portable.PortablePadding(10);
            mrtxt_cuerpoMail.Margin = new Padding(0);
            mrtxt_cuerpoMail.Padding = new Padding(0);
            mrtxt_cuerpoMail.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
        }
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