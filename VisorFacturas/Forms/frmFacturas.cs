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

namespace VisorFacturas.Forms
{
    public partial class frmFacturas : DevExpress.XtraEditors.XtraForm
    {
        public frmFacturas(tblUser paCurrentUser)
        {
            InitializeComponent();
            this.moCurrentUser = paCurrentUser;
        }

        #region "DECLARACION E INSTANCIA DE VARIABLES GLOBALES"

        // Usuario del sistema
        tblUser moCurrentUser;

        // Cadena de Conexion 
        String mocadenaconexOLEDB;

        /* Variables de Correo Electrónico */
        String smtpCZF = "ns.czf.com.ni";
        String smtpCNZF = "mail.cnzf.gob.ni";
        String smtpCORREO;

        /* Variables para el envio de correos */
        String NombreRemitenteCNZF = "Ramona Blanco Lezama";
        String CorreoremitenteCNZF = "rblanco@cnzf.gob.ni";
        //String NombreRemitenteCNZF = "Ariel Davila";
        //String CorreoremitenteCNZF = "adavila@czf.com.ni";
        String NombreRemitenteCZF = "";
        String CorreoremitenteCZF = "";

        //Rutas de Directorios
        String pathTablas; // = Settings.Default.DirectorioTablasCNZF;
        String pathFact; // = Settings.Default.DirectorioFacturasCNZF;
        String pathTablaRemisionTemp; // = Settings.Default.DirectorioTablasRemisionCNZF;
        //String pathEmail = Settings.Default.DirectorioCorreos;

        String sqlClientesCZF = "SELECT cli_cod, cli_nom, (cli_direc1 + ' ' + cli_direc2) AS cli_dir FROM CLIENTE";

        String sqlClientesCNZF = "SELECT cli_cod, cli_nom, (cli_direc1 + ' ' + cli_direc2) AS cli_dir, cli_email1, cli_email2, cli_ruc FROM CLIENTE";
        String sqlFacturas = "SELECT cli_codig, fecha, ord_numero, fac_fac_nu, fac_tasa, fac_amo_do, fac_dolcor, tipo, fac_amount, fac_pagado, fac_pag_do FROM FACTURA WHERE fac_amo_do > 0 AND tipo == '1' order by fac_fac_nu ASC";                
        String sqlRemision = "Select DISTINCT rem_numero, rem_codig, (rem_desc1 + ' ' + rem_desc2) AS rem_desc, rem_canti, rem_precio, rem_impues, rem_descue, rem_fec_ve From REMISION ORDER BY rem_numero ASC";        

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
        
        #endregion

        #region "FUNCIONES Y MÉTODOS"

        /// <summary>
        /// Verifica si las rutas a los archivos .DBF existen
        /// </summary>
        /// <returns></returns>
        private Boolean VerificarRutas()
        {
            if (!System.IO.Directory.Exists(pathTablas))
            {
                XtraMessageBox.Show("Verifique la ruta de los archivos de datos: \n\n" + pathTablas, "La ruta no existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!System.IO.Directory.Exists(pathTablaRemisionTemp))
            {
                XtraMessageBox.Show("Verifique la ruta de los archivos de datos: \n\n" + pathTablaRemisionTemp, "La ruta no existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!System.IO.Directory.Exists(pathFact))
            {
                System.IO.Directory.CreateDirectory(pathFact);
            }

            return true;
        }

        /// <summary>
        /// Carga los datos de las tablas de Visual Fox Pro y los datos los guardamos en las tablas del dataset del proyecto
        /// </summary>
        private void CargarDatosTablasDBF()
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
                                  cli_ruc = cli.cli_ruc
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
                DateTime fechaini = new DateTime((int)speAnno.Value, (cmbMes.SelectedIndex + 1), 1);
                DateTime fechafin = fechaini.AddMonths(1).AddDays(-1);

                IEnumerable<viewFactura> data = from fac in tbl_facturas.AsEnumerable()
                                                join client in tbl_clientes.AsEnumerable() on fac.cli_codig equals client.cli_cod
                                                where (fac.fecha >= fechaini && fac.fecha <= fechafin)
                                                select new viewFactura
                                                {
                                                    cli_codig = fac.cli_codig,
                                                    cli_nom = client.cli_nom,
                                                    ord_numero = fac.ord_numero,
                                                    fecha = fac.fecha,
                                                    fac_fac_nu = fac.fac_fac_nu,
                                                    fac_tasa = fac.fac_tasa,
                                                    fac_amo_do = fac.fac_amo_do,
                                                    fac_dolcor = fac.fac_dolcor,
                                                    tipo = fac.tipo,
                                                    cli_dir = client.cli_dir,
                                                    cli_ruc = client.cli_ruc,
                                                    fac_amount = fac.fac_amount,
                                                    fac_pagado = fac.fac_pagado,
                                                    fac_pag_do = fac.fac_pag_do
                                                };


                ListFacturas = data.OrderBy(s => s.fac_fac_nu).ToList();
                bsGrid.DataSource = ListFacturas;
                gvFacturas.ViewCaption = "Total de Facturas Encontradas: " + gvFacturas.DataRowCount; //+ bsGrid.List.Count;

                VerificarDuplicados();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error No: " + ex.HResult, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //SmtpClient server = new SmtpClient(smtpCORREO);
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(From, NameFrom);
                             
                foreach (var t in to)
                {
                    if (!String.IsNullOrEmpty(t))
                    {
                        mail.To.Add(new MailAddress(t));
                    }
                }

                // Se pregunta si tiene activado el check de Copia del Remitente
                if (mchk_copia_remitente.Checked)
                {
                    // Si lo tiene activo, se agregara el correo del remitente en CC del correo
                    mail.CC.Add(new MailAddress(From));
                    // Y se desactiva la notificación
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.Never;
                }
                else
                {
                    // Únicamente se activa la notificación de llegada de correo
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                }
                

                mail.Subject = Subject;
                mail.Body = Message;

                if (Attachements != null)
                {
                    foreach (var attach in Attachements)
                    {
                        if (!String.IsNullOrEmpty(attach))
                        {
                            mail.Attachments.Add(new Attachment(attach));
                        }

                    }
                }

                //server.Send(mail);
                //mail.Dispose();

                using (var serv = new SmtpClient())
                {
                    serv.Host = smtpCORREO; //"ns.czf.com.ni";// "mail.cnzf.gob.ni";// smtpCORREO;
                    serv.EnableSsl = false;
                    serv.Port = 25;
                    serv.DeliveryFormat = SmtpDeliveryFormat.International;
                    serv.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //serv.UseDefaultCredentials = false;
                    //serv.Credentials = new NetworkCredential("adavila@czf.com.ni", "Fender22.", "czf.com.ni");
                    serv.Send(mail);
                }
                
            }
            catch (FormatException fex)
            {
                String msg_fex = "La dirección del correo electrónico  es incorrecta";
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

            if (String.IsNullOrEmpty(txtCuerpo.Text.Trim()))
            {
                isValid = false;
                dxErrProv.SetError(txtCuerpo, "No deje vacío este campo!");
                dxErrProv.SetIconAlignment(txtCuerpo, ErrorIconAlignment.MiddleRight);
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
        /// Verifica las facturas que estén repetidas, en caso de que encuentre repetidas, imprime un mensaje de ALERTA
        /// </summary>
        private void VerificarDuplicados() {
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
        /// Rellena los datos por defecto del correo
        /// </summary>
        private void LlenarDatosCorreo(int num)
        {           

            String TituloMensaje = string.Empty;
            if (num == 0) //AQUÍ ENTRA SI ES FACTURA
            {
                TituloMensaje = "AVISO DE COBRO DEL MES DE " + cmbMes.Text.ToUpper() + " " + speAnno.Text;
                txtCuerpo.Text = "Estimados Señores" + Environment.NewLine + Environment.NewLine + "Se les envía por este medio el " + TituloMensaje +
                " para su debida cancelación, recuerden que el vencimiento de la factura son los 20 de cada mes. Para gozar de los " +
                "beneficios que otorga el Régimen hay que tener al día sus pagos." + Environment.NewLine + Environment.NewLine +
                "Favor hacer caso omiso si está factura ya fue cancelada." + Environment.NewLine + Environment.NewLine + "Saludos!";
                
            }
            else if(num == 1) //AQUÍ ENTRA SI ES COMUNICADO
            {
                TituloMensaje = "";
                txtCuerpo.Text = "";                
            }

            if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
            {
                txtNombreRem.Text = NombreRemitenteCZF;
                txtCorreoRem.Text = CorreoremitenteCZF;
            }
            else
            {
                txtNombreRem.Text = NombreRemitenteCNZF;
                txtCorreoRem.Text = CorreoremitenteCNZF;
            }
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

        #endregion

        #region "EVENTOS"

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
                        Reports.xrFacturas aorpt = new Reports.xrFacturas(remision, cmbMes.Text);
                        aorpt.DataSource = factura;
                        aorpt.picLogo.Image = VisorFacturas.Properties.Resources.Comisión_Nacional_de_Zonas_Francas;
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
                        String descfact = "Facturación del mes de " + cmbMes.Text + " - " + speAnno.Text;
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
                        Reports.xrFacturaSoloDatos aorpt = new Reports.xrFacturaSoloDatos(remision, cmbMes.Text);
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
            if (chkAviso.Checked)
                btnAdjun.Enabled = true;
            else
                btnAdjun.Enabled = false;

            // Se activa por defecto la CC al remitente
            mchk_copia_remitente.Checked = true;
            mchk_copia_remitente.Visible = true;

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

                        //// Correos de prueba
                        //LstCorreosIndiv.Items.Add("wmejia@czf.com.ni");
                        //LstCorreosIndiv.Items.Add("restrada@czf.com.ni");
                        //LstCorreosIndiv.Items.Add("davilaandres95@gmail.com");

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
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error No: " + ex.HResult, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                String PathAttach = string.Empty;

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
                        // Ruta de la factura
                        PathAttach = pathFact + "\\" + Year + "\\" + Month + "\\" + CodClienteSelect + "-" + cliente_selected.cli_nom.Trim() + ".pdf";
                    }
                    else if (chkAviso.Checked)
                    {
                        PathAttach = txtAdjuntar.Text;
                    }

                    if(PathAttach == string.Empty)
                    {
                        XtraMessageBox.Show("No hay una ruta seleccionada", "Seleccione un archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Listado de correos: Permito 5 correos, aunque solo ingrese dos correos
                    String[] CorreosCli = new String[5];                    

                    // Añadimos los correos que están en la Lista
                    for (int i = 0; i < LstCorreosIndiv.Items.Count; i++)
                    {
                        CorreosCli[i] = LstCorreosIndiv.Items[i].ToString().Trim();
                    }

                    if (!String.IsNullOrEmpty(CorreosCli[0]) || !String.IsNullOrEmpty(CorreosCli[1]))
                    {
                        if (!chkAviso.Checked)
                        {
                            // obtenemos la factura seleccionada
                            viewFactura fac_selected = (viewFactura)bsGrid.Current;
                            GetData(fac_selected.ord_numero);

                            // Creamos el reporte pero no  lo imprimimos
                            Reports.xrFacturas aorpt = new Reports.xrFacturas(remision, cmbMes.Text);
                            aorpt.DataSource = factura;
                            aorpt.picLogo.Image = VisorFacturas.Properties.Resources.Comisión_Nacional_de_Zonas_Francas;
                            // Exportamos el reporte en PDF
                            aorpt.ExportToPdf(PathAttach);
                            aorpt.Dispose();

                            Asunto = txtAsunto.Text + " - " + cliente_selected.cli_nom;
                        }
                        else
                        {
                            Asunto = txtAsunto.Text;
                        }


                        // Adjuntamos el archivo que exportamos en PDF
                        adjuntos[0] = PathAttach;
                        // Enviamos el correo
                        EnviarCorreo(txtCorreoRem.Text.Trim(), txtNombreRem.Text, CorreosCli, Asunto, txtCuerpo.Text, adjuntos);
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
                                // Ruta de la factura
                                PathAttach = pathFact + "\\" + Year + "\\" + Month + "\\" + CodClienteSelect + "-" + cliente_selected.cli_nom.Trim() + ".pdf";
                            }
                            else if (chkAviso.Checked)
                            {
                                PathAttach = txtAdjuntar.Text;
                            }

                            if (PathAttach == string.Empty)
                            {
                                XtraMessageBox.Show("No hay una ruta seleccionada", "Seleccione un archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            if (!chkAviso.Checked)
                            {
                                ////Verificamos que tenga factura en este mes para enviar
                                GetData(fac.ord_numero);
                                if (factura.ToList().Count() > 0)
                                {
                                    //Creamos el reporte, sin imprimirlo
                                    Reports.xrFacturas aorpt = new Reports.xrFacturas(remision, cmbMes.Text);
                                    aorpt.DataSource = factura;
                                    aorpt.picLogo.Image = VisorFacturas.Properties.Resources.Comisión_Nacional_de_Zonas_Francas;
                                    // Exportamos el reporte en formato PDF
                                    aorpt.ExportToPdf(PathAttach);
                                    aorpt.Dispose();
                                    // Adjuntamos el archivo PDF en la variable adjuntos (type Array String)
                                    adjuntos[0] = PathAttach;
                                    // Asunto + nombre del cliente
                                    Asunto = Asunto = txtAsunto.Text + " - " + cliente_selected.cli_nom;
                                    // Enviamos el correo
                                    EnviarCorreo(txtCorreoRem.Text.Trim(), txtNombreRem.Text, CorreosCli, Asunto, txtCuerpo.Text, adjuntos);
                                    //Console.WriteLine("Factura Nº " + i.ToString() + " enviada!");
                                    
                                }                                
                            }
                            else
                            {
                                // Adjuntamos el archivo PDF en la variable adjuntos (type Array String)
                                adjuntos[0] = PathAttach;
                                // Enviamos el correo
                                EnviarCorreo(txtCorreoRem.Text.Trim(), txtNombreRem.Text, CorreosCli, txtAsunto.Text, txtCuerpo.Text, adjuntos);
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
                    txtAsunto.Text = "";
                    txtCuerpo.Text = "";
                    xtraTabControl1.SelectedTabPage = xtpCapturaErr;
                    XtraMessageBox.Show("Los correos han sido enviados, exceptos a los clientes que están en el siguiente listado", "Envío exitoso pero con algunos errores", MessageBoxButtons.OK, MessageBoxIcon.Warning);                    
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


        #endregion

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
    }
}