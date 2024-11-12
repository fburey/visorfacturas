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
using System.Data.OleDb;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using VisorFacturas.Datasets;
using VisorFacturas.Forms;
using VisorFacturas.Properties;
using VisorFacturas.Clases;
using VisorFacturas.Util;
using VisorFacturas.Enums;

namespace VisorFacturas.Forms
{
    public partial class frmActivoFijo : DevExpress.XtraEditors.XtraForm
    {
        public frmActivoFijo(tblUser pocurrentuser)
        {
            InitializeComponent();
            this.moCurrentUser = pocurrentuser;
        }

        #region DECLARACIÓN E INSTANCIA DE VARIABLES GLOBALES

        // Usuario Actual
        tblUser moCurrentUser;

        // Cadena de conexion
        string mocadenaconexOLEDB;

        // Consultas SQL
        //string nurestring = "99";
        //string SqlEmpleadoCZF = "SELECT TSECCION.dir, TSECCION.d, TSECCION.c, TSECCION.codigo, TSECCION.nombre, TSECCION.descrip FROM TSECCION WHERE TSECCION.d == '01' OR TSECCION.d == '99' order by TSECCION.c ";
        string SqlEmpleadoCZF = "SELECT TSECCION.dir, TSECCION.d, TSECCION.c, TSECCION.codigo, TSECCION.nombre, TSECCION.descrip, NVL(CLI.descrip, '') AS Depart FROM TSECCION LEFT JOIN TSUBDIR AS CLI ON TSECCION.c = CLI.codigo and TSECCION.d = CLI.dir WHERE TSECCION.d == '01' order by TSECCION.c";//"SELECT TSECCION.dir, TSECCION.d, TSECCION.c, TSECCION.codigo, TSECCION.nombre, TSECCION.descrip FROM TSECCION WHERE TSECCION.d == '01' order by TSECCION.c";
        string SqlEmpleadoCNZF = "SELECT TSECCION.dir, TSECCION.d, TSECCION.c, TSECCION.codigo, TSECCION.nombre, TSECCION.descrip, 'Depart' AS Depart FROM TSECCION WHERE TSECCION.d != '99' order by TSECCION.c";
        
        string SqlSelect_depart = "SELECT TSUBDIR.dir, TSUBDIR.codigo, TSUBDIR.descrip FROM TSUBDIR WHERE TSUBDIR.dir != '99'";
        string SqlSelect_Bienes = "SELECT BIENES.bi_cuecont, BIENES.bi_ubic1, BIENES.bi_ubic2, BIENES.bi_ubic3, BIENES.bi_art, BIENES.bi_codsec, BIENES.bi_descrip, BIENES.bi_marca, BIENES.bi_modelo, BIENES.bi_serie, BIENES.bi_valor, BIENES.bi_depacu, BIENES.bi_saldo, BIENES.bi_vidautl, BIENES.bi_cantdep, BIENES.bi_depmes FROM BIENES order by  BIENES.bi_ubic1";
        //string SqlSelect_BienesCZF = "SELECT DISTINCT BIENES.bi_cuecont, BIENES.bi_ubic1, BIENES.bi_ubic2, BIENES.bi_ubic3, BIENES.bi_art, BIENES.bi_codsec, BIENES.bi_descrip, BIENES.bi_marca, BIENES.bi_modelo, BIENES.bi_serie, BIENES.bi_valor, BIENES.bi_depacu, BIENES.bi_saldo, BIENES.bi_vidautl, BIENES.bi_cantdep, BIENES.bi_depmes FROM BIENES WHERE BIENES.bi_ubic1 == '01' OR BIENES.bi_ubic1 == '99' order by  BIENES.bi_ubic1";
        string SqlSelect_BienesCZF = "SELECT BIENES.bi_cuecont, BIENES.bi_ubic1, BIENES.bi_ubic2, BIENES.bi_ubic3, BIENES.bi_art, BIENES.bi_codsec, BIENES.bi_descrip, BIENES.bi_marca, BIENES.bi_modelo, BIENES.bi_serie, BIENES.bi_valor, BIENES.bi_depacu, BIENES.bi_saldo, BIENES.bi_vidautl, BIENES.bi_cantdep, BIENES.bi_depmes FROM BIENES WHERE BIENES.bi_ubic1 == '01' OR BIENES.bi_ubic1 == '99' order by  BIENES.bi_ubic1";

        dsModel.BIENESDataTable tbl_BIENES = new dsModel.BIENESDataTable();
        dsModel.TSECCIONDataTable tbl_EMPLEADO = new dsModel.TSECCIONDataTable();
        dsModel.TSUBDIRDataTable tbl_DEPART = new dsModel.TSUBDIRDataTable();

        //DataAdapters
        OleDbDataAdapter adapter;

        //Commands
        OleDbCommand command;

        // Listas y objetos
        List<viewEmpleados> ListEmpleados;      // Para reporte
        List<viewBIENES> ListBienes;
        viewEmpleados EmpleadoSelect;           // Para reporte
        List<viewBIENES> ListBienesAll;         // Para reporte
        List<viewEmpleados> ListEmpleadosConBienes; // Para reporte

        #endregion

        #region FUNCIONES Y MÉTODOS

        /// <summary>
        /// Verifica si las rutas a los archivos .DBF existen
        /// </summary>
        /// <returns></returns>
        private Boolean VerificarRutas(String poruta)
        {
            // Verificamos si existe la ruta de los Activos Fijos
            if (!System.IO.Directory.Exists(poruta))
            {
                MessageBox.Show("Verifique la ruta de los archivos de datos: \n\n" + poruta, "La ruta no existe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }            
            return true;
        }

        /// <summary>
        /// Mandamos a cargar los datos de las tablas DBF
        /// </summary>
        private void mpxCargarDatosTablasDBF()
        {
            //Mandamos a cargar BIENES
            using (OleDbConnection dbConn = new OleDbConnection(mocadenaconexOLEDB))
            {
                try
                {
                    dbConn.Open();

                    // Cargamos los Empleados a la tabla del DATASET: TSECTION
                    if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                    {
                        command = new OleDbCommand(SqlEmpleadoCZF, dbConn);

                        command.CommandType = CommandType.Text;
                        adapter = new OleDbDataAdapter(command);
                        adapter.Fill(tbl_EMPLEADO);

                        // Cargamos los departamentos a la tabla del dataset: TSUBDIR
                        command = new OleDbCommand(SqlSelect_depart, dbConn);
                        command.CommandType = CommandType.Text;
                        adapter = new OleDbDataAdapter(command);
                        adapter.Fill(tbl_DEPART);

                        // Cargamos los bienes a la tabla del dataset: BIENES
                        command = new OleDbCommand(SqlSelect_BienesCZF, dbConn);
                        command.CommandType = CommandType.Text;
                        adapter = new OleDbDataAdapter(command);
                        adapter.Fill(tbl_BIENES);
                    }
                    else
                    {
                        command = new OleDbCommand(SqlEmpleadoCNZF, dbConn);

                        command.CommandType = CommandType.Text;
                        adapter = new OleDbDataAdapter(command);
                        adapter.Fill(tbl_EMPLEADO);

                        // Cargamos los departamentos a la tabla del dataset: TSUBDIR
                        command = new OleDbCommand(SqlSelect_depart, dbConn);
                        command.CommandType = CommandType.Text;
                        adapter = new OleDbDataAdapter(command);
                        adapter.Fill(tbl_DEPART);

                        // Cargamos los bienes a la tabla del dataset: BIENES
                        command = new OleDbCommand(SqlSelect_Bienes, dbConn);
                        command.CommandType = CommandType.Text;
                        adapter = new OleDbDataAdapter(command);
                        adapter.Fill(tbl_BIENES);
                    }


                    if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                    {
                        // Llenamos el Grid Empleados
                        ListEmpleados = (from emp in tbl_EMPLEADO.AsQueryable()
                                             //join dep in tbl_DEPART.AsQueryable() on emp.c equals dep.codigo
                                             //join dep in tbl_DEPART.AsQueryable() on new { X1 = dep.codigo, X2 = m.uidemplea } equals new { X1 = aoemp.uidcia, X2 = aoemp.uidemplea }
                                         select new viewEmpleados
                                         {
                                             c_codigo = (emp.c + emp.codigo),
                                             nombre = emp.nombre,
                                             cargo = emp.descrip,
                                             c = emp.c,
                                             codigo = emp.codigo,
                                             //departamento = dep.descrip,
                                             departamento = emp.Depart,
                                             d = emp.d
                                         }).ToList();
                    }
                    else
                    {
                        // Llenamos el Grid Empleados
                        ListEmpleados = (from emp in tbl_EMPLEADO.AsQueryable()
                                         join dep in tbl_DEPART.AsQueryable() on emp.c equals dep.codigo
                                             //join dep in tbl_DEPART.AsQueryable() on new { X1 = dep.codigo, X2 = m.uidemplea } equals new { X1 = aoemp.uidcia, X2 = aoemp.uidemplea }
                                         select new viewEmpleados
                                         {
                                             c_codigo = (emp.c + emp.codigo),
                                             nombre = emp.nombre,
                                             cargo = emp.descrip,
                                             c = emp.c,
                                             codigo = emp.codigo,
                                             departamento = dep.descrip,
                                             //departamento = emp.Depart,
                                             d = emp.d
                                         }).ToList();
                    }
                        

                    bndsrc_Emplea.DataSource = ListEmpleados;

                    // Llenamos todos los Activos Fijos en una lista para impresión masiva de Bienes x Empleado
                    ListBienesAll = (from b in tbl_BIENES.AsQueryable()
                                     //where b.bi_ubic2.Contains(EmpleadoSelect.c) && b.bi_ubic3.Contains(EmpleadoSelect.codigo)
                                     select new viewBIENES {
                                         bicodigo = (b.bi_ubic1.Trim() + "-" + b.bi_ubic2.Trim() + "-" + b.bi_ubic3.Trim() + "-" + b.bi_art.Trim() + "-" + b.bi_codsec.Trim()),
                                         bi_descrip = b.bi_descrip,
                                         bi_marca = b.bi_marca,
                                         bi_modelo = b.bi_modelo,
                                         bi_serie = b.bi_serie,
                                         bi_cuecont = b.bi_cuecont, 
                                         bi_codemp = (b.bi_ubic2.Trim() + b.bi_ubic3.Trim()),
                                         bi_valor = b.bi_valor,
                                         bi_depacu = b.bi_depacu,
                                         bi_saldo = b.bi_saldo,
                                         bi_vidautl = b.bi_vidautl,
                                         bi_cantdep = b.bi_cantdep,
                                         bi_depmes = b.bi_depmes,
                                     }).ToList();

                    dbConn.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir la base de datos" + ex.Message);
                }
            }
        }

        /// <summary>
        /// Cargarmos Bienes
        /// </summary>
        private void mpxCargarBienes()
        {
            //string SqlSelect_Bienes = "SELECT (BIENES.bi_ubic1 + '-'+ BIENES.bi_ubic2 + '-'+  BIENES.bi_ubic3+ '-'+  BIENES.bi_art+ '-'+  BIENES.bi_codsec) as bicodigo, BIENES.bi_descrip, BIENES.bi_marca, BIENES.bi_modelo, BIENES.bi_serie FROM BIENES WHERE BIENES.bi_ubic2 = '" + c_c + "' and BIENES.bi_ubic3 = '" + c_codigo + "' order by  BIENES.bi_ubic1"; //and BIENES.bi_ubic1 != '" + nurestring + "'";
            using (OleDbConnection dbConnBienes = new OleDbConnection(mocadenaconexOLEDB))
            {
                try
                {
                    dbConnBienes.Open();

                    ListBienes = (from b in tbl_BIENES.AsQueryable()
                                  where b.bi_ubic2.Contains(EmpleadoSelect.c) && b.bi_ubic3.Contains(EmpleadoSelect.codigo)
                                  orderby b.bi_ubic1 ascending
                                  select new viewBIENES
                                  {
                                      bicodigo = (b.bi_ubic1.Trim() + "-" + b.bi_ubic2.Trim() + "-" + b.bi_ubic3.Trim() + "-" + b.bi_art.Trim() + "-" + b.bi_codsec.Trim()),
                                      bi_descrip = b.bi_descrip,
                                      bi_marca = b.bi_marca,
                                      bi_modelo = b.bi_modelo,
                                      bi_serie = b.bi_serie,
                                      bi_cuecont = b.bi_cuecont,
                                      bi_codemp = (b.bi_ubic2.Trim() + b.bi_ubic3.Trim()),
                                      bi_valor = b.bi_valor,
                                      bi_depacu = b.bi_depacu,
                                      bi_saldo = b.bi_saldo,
                                      bi_vidautl = b.bi_vidautl,
                                      bi_cantdep = b.bi_cantdep,
                                      bi_depmes = b.bi_depmes
                                  }).ToList();

                    bndsrc_Bienes.DataSource = ListBienes;
                    dbConnBienes.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir la base de datos" + ex.Message);
                }
            }
        }

        #endregion

        #region EVENTOS
        
        private void XtraForm1_Load(object sender, EventArgs e)
        {
            String aorutadiractfij = "";
            if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
            {
                mocadenaconexOLEDB = String.Format(@"Provider=VFPOLEDB.1;Data Source={0}; Extended Properties = dBase IV", Settings.Default.DirectorioActivosFijosCZF);
                aorutadiractfij = Settings.Default.DirectorioActivosFijosCZF;
            }
            else if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CNZF)
            {
                mocadenaconexOLEDB = String.Format(@"Provider=VFPOLEDB.1;Data Source={0}; Extended Properties = dBase IV", Settings.Default.DirectorioActivosFijosCNZF);
                aorutadiractfij = Settings.Default.DirectorioActivosFijosCNZF;
            }            

            // Verificamos la ruta de la BD
            if (!VerificarRutas(aorutadiractfij))
            {
                //Navegador de Empleados
                clsApp.mfxDtanavGetBtn(mEmpleado_ctlnav, "mvxPrintAFMasivos").Enabled = false;
                clsApp.mfxDtanavGetBtn(mEmpleado_ctlnav, "mvxPrintEmp").Enabled = false;
                clsApp.mfxDtanavGetBtn(mEmpleado_ctlnav, "mvxBuscar").Enabled = false;

                //Navegador de Activos
                clsApp.mfxDtanavGetBtn(mActivos_ctlnav, "mvxPrint").Enabled = false;
                return;
            }

            //Mandamos a cargar los empleados
            mpxCargarDatosTablasDBF();
        }
            

        /// <summary>
        /// Aqui controlamos los botones accion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mEmpleado_ctlnav_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            switch (e.Button.ButtonType)
            {
                case NavigatorButtonType.First:
                    e.Handled = false;
                    break;
                case NavigatorButtonType.Last:
                    e.Handled = false;
                    break;
                case NavigatorButtonType.Next:
                    e.Handled = false;
                    break;
                case NavigatorButtonType.Prev:
                    e.Handled = false;
                    break;
                case NavigatorButtonType.Custom:
                    string aoAccRow = e.Button.Tag.ToString();
                    switch (aoAccRow)
                    {
                        case "mvxPrintEmp":                            
                            // Imprime la lista de los Empleados
                            string mcEscNic = Application.StartupPath + @"\Archivo\EscNic.png";
                            string mnNumCia = Application.StartupPath + @"\Archivo\LogCiaCNZF.png";
                            Reports.rptEmpleadoLst aorpt = new Reports.rptEmpleadoLst(mcEscNic, mnNumCia);
                            aorpt.DataSource = ListEmpleados;
                            frmviewer aofrmviewer = new frmviewer(aorpt);
                            aofrmviewer.Text = "Listado de Empleados";
                            aofrmviewer.MdiParent = this.MdiParent;
                            aofrmviewer.WindowState = FormWindowState.Maximized;
                            aofrmviewer.Show();
                            break;

                        case "mvxPrintAFMasivos":
                            // Imprime la lista de los Activos Fijos Asignados a cada empleado
                            ListEmpleadosConBienes = new List<viewEmpleados>();
                            ListEmpleados.ForEach(delegate(viewEmpleados item) 
                            {
                                if (ListBienesAll.Where(s => s.bi_codemp.Contains(item.c_codigo)).Count() > 0)
                                    ListEmpleadosConBienes.Add(item);
                            });

                            if (ListEmpleadosConBienes != null && !mchkincluirmontos.Checked && !mchkincluirCTA.Checked)
                            {                                
                                if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                                {
                                    Reports.CZF.rptBienesAll aorpt2 = new Reports.CZF.rptBienesAll(ListBienesAll);
                                    aorpt2.DataSource = ListEmpleadosConBienes;
                                    frmviewer aofrmviewer2 = new frmviewer(aorpt2);
                                    aofrmviewer2.Text = "Listado de Bienes por Empleado";
                                    aofrmviewer2.MdiParent = this.MdiParent;
                                    aofrmviewer2.WindowState = FormWindowState.Maximized;
                                    aofrmviewer2.Show();
                                }
                                else
                                {
                                    Reports.rptBienesAll aorpt2 = new Reports.rptBienesAll(ListBienesAll);
                                    aorpt2.DataSource = ListEmpleadosConBienes;
                                    frmviewer aofrmviewer2 = new frmviewer(aorpt2);
                                    aofrmviewer2.Text = "Listado de Bienes por Empleado";
                                    aofrmviewer2.MdiParent = this.MdiParent;
                                    aofrmviewer2.WindowState = FormWindowState.Maximized;
                                    aofrmviewer2.Show();
                                }

                            }
                            else if (ListEmpleadosConBienes != null && mchkincluirmontos.Checked && !mchkincluirCTA.Checked)
                            {
                                if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                                {
                                    Reports.CZF.rptBienesAllconMontos aorpt2 = new Reports.CZF.rptBienesAllconMontos(ListBienesAll);
                                    aorpt2.DataSource = ListEmpleadosConBienes;
                                    frmviewer aofrmviewer2 = new frmviewer(aorpt2);
                                    aofrmviewer2.Text = "Listado de Bienes por Empleado";
                                    aofrmviewer2.MdiParent = this.MdiParent;
                                    aofrmviewer2.WindowState = FormWindowState.Maximized;
                                    aofrmviewer2.Show();
                                }
                                else
                                {
                                    Reports.CNZF.rptBienesAllconMontos aorpt2 = new Reports.CNZF.rptBienesAllconMontos(ListBienesAll);
                                    aorpt2.DataSource = ListEmpleadosConBienes;
                                    frmviewer aofrmviewer2 = new frmviewer(aorpt2);
                                    aofrmviewer2.Text = "Listado de Bienes por Empleado";
                                    aofrmviewer2.MdiParent = this.MdiParent;
                                    aofrmviewer2.WindowState = FormWindowState.Maximized;
                                    aofrmviewer2.Show();
                                }

                            }
                            else if(ListEmpleadosConBienes != null && !mchkincluirmontos.Checked && mchkincluirCTA.Checked)
                            {
                                if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                                {
                                    Reports.CZF.rptBienesAllCTA aorpt2 = new Reports.CZF.rptBienesAllCTA(ListBienesAll);
                                    aorpt2.DataSource = ListEmpleadosConBienes;
                                    frmviewer aofrmviewer2 = new frmviewer(aorpt2);
                                    aofrmviewer2.Text = "Listado de Bienes por Empleado";
                                    aofrmviewer2.MdiParent = this.MdiParent;
                                    aofrmviewer2.WindowState = FormWindowState.Maximized;
                                    aofrmviewer2.Show();
                                }
                                else
                                {
                                    Reports.CNZF.rptBienesAllCTA aorpt2 = new Reports.CNZF.rptBienesAllCTA(ListBienesAll);
                                    aorpt2.DataSource = ListEmpleadosConBienes;
                                    frmviewer aofrmviewer2 = new frmviewer(aorpt2);
                                    aofrmviewer2.Text = "Listado de Bienes por Empleado";
                                    aofrmviewer2.MdiParent = this.MdiParent;
                                    aofrmviewer2.WindowState = FormWindowState.Maximized;
                                    aofrmviewer2.Show();
                                }
                                
                            }
                            else if (ListEmpleadosConBienes != null && mchkincluirmontos.Checked && mchkincluirCTA.Checked)
                            {
                                if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                                {
                                    Reports.CZF.rptBienesAllconMontosCTA aorpt2 = new Reports.CZF.rptBienesAllconMontosCTA(ListBienesAll);
                                    aorpt2.DataSource = ListEmpleadosConBienes;
                                    frmviewer aofrmviewer2 = new frmviewer(aorpt2);
                                    aofrmviewer2.Text = "Listado de Bienes por Empleado";
                                    aofrmviewer2.MdiParent = this.MdiParent;
                                    aofrmviewer2.WindowState = FormWindowState.Maximized;
                                    aofrmviewer2.Show();
                                }
                                else
                                {
                                    Reports.CNZF.rptBienesAllconMontosCTA aorpt2 = new Reports.CNZF.rptBienesAllconMontosCTA(ListBienesAll);
                                    aorpt2.DataSource = ListEmpleadosConBienes;
                                    frmviewer aofrmviewer2 = new frmviewer(aorpt2);
                                    aofrmviewer2.Text = "Listado de Bienes por Empleado";
                                    aofrmviewer2.MdiParent = this.MdiParent;
                                    aofrmviewer2.WindowState = FormWindowState.Maximized;
                                    aofrmviewer2.Show();
                                }

                            }
                            else
                            {
                                XtraMessageBox.Show("No hay Empleados que tenga algún Activo Fijo Asignado", "Activos Fijos sin Asignar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            break;
                        case "mvxBuscar":
                            try
                            {
                                EmpleadoSelect = (viewEmpleados)gridView1.GetRow(gridView1.FocusedRowHandle);

                                if (EmpleadoSelect != null)
                                {   
                                    //Aqui cambio el nombre al leabel
                                    lblComent.Text = EmpleadoSelect.nombre;

                                    //Aqui mando a cargar el Grid de Bienes      
                                    mpxCargarBienes();
                                }
                                else
                                {
                                    XtraMessageBox.Show("No se selecciono ningun registro", "No hay seleccion",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show(ex.Message);
                            }                           
                            break;
                        case "mvxSalir":
                            Close();
                            break;
                    }
                    break;
            }


        }
       
        /// <summary>
        /// Aqui controlo el navegador de bienes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mActivos_ctlnav_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            switch (e.Button.ButtonType)
            {
                case NavigatorButtonType.First:
                    e.Handled = false;
                    break;
                case NavigatorButtonType.Last:
                    e.Handled = false;
                    break;
                case NavigatorButtonType.Next:
                    e.Handled = false;
                    break;
                case NavigatorButtonType.Prev:
                    e.Handled = false;
                    break;
                case NavigatorButtonType.Custom:
                    string aoAccRow = e.Button.Tag.ToString();
                    switch (aoAccRow)
                    {
                        case "mvxPrint":
                            mvxPrintDetail();
                            break;
                        case "mvxBuscar":
                            break;
                    }
                    break;
            }
        }

        private void mvxPrintDetail() {
            // verificamos si la tabla está vacia
            if (gridView2.DataRowCount == 0)
            {
                XtraMessageBox.Show("No hay datos que mostrar", "Generando Reporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //var aoDtaSrc = new DataTable();
            //for (int i = 0; i < gridView2.DataRowCount; i++)
            //  //  aoDtaSrc.Add((mpxclientprtlst_cpt)mgrvformmain.GetRow(i));
            //aoDtaSrc.AsDataView(gridView2.GetRow(i));

            string mcEscNic = Application.StartupPath + @"\Archivo\EscNic.png";
            string mnNumCia = Application.StartupPath + @"\Archivo\LogCiaCNZF.png";

            if (mchkincluirmontos.Checked && !mchkincluirCTA.Checked)
            {
                
                if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                {
                    Reports.CZF.rptBienesconMontos aorpt = new Reports.CZF.rptBienesconMontos(EmpleadoSelect, mcEscNic, mnNumCia);//(moctx.mstcia.Find(moclscnfapp.mouidcia.Value));                                 
                    aorpt.DataSource = ListBienes;
                    //aorpt.mpxsettitle(string.Empty);
                    frmviewer aofrmviewer = new frmviewer(aorpt);
                    aofrmviewer.Text = "AF con Montos - " + EmpleadoSelect.c_codigo.Trim();
                    aofrmviewer.MdiParent = this.MdiParent;
                    aofrmviewer.WindowState = FormWindowState.Maximized;
                    aofrmviewer.Show();
                }
                else
                {
                    Reports.rptBienesconMontos aorpt = new Reports.rptBienesconMontos(EmpleadoSelect, mcEscNic, mnNumCia);//(moctx.mstcia.Find(moclscnfapp.mouidcia.Value));                                 
                    aorpt.DataSource = ListBienes;
                    //aorpt.mpxsettitle(string.Empty);
                    frmviewer aofrmviewer = new frmviewer(aorpt);
                    aofrmviewer.Text = "AF con Montos - " + EmpleadoSelect.c_codigo.Trim();
                    aofrmviewer.MdiParent = this.MdiParent;
                    aofrmviewer.WindowState = FormWindowState.Maximized;
                    aofrmviewer.Show();
                }
            }
            else if (!mchkincluirmontos.Checked && mchkincluirCTA.Checked)
            {

                if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                {
                    Reports.CZF.rptBienesCTA aorpt = new Reports.CZF.rptBienesCTA(EmpleadoSelect, mcEscNic, mnNumCia);//(moctx.mstcia.Find(moclscnfapp.mouidcia.Value));                                 
                    aorpt.DataSource = ListBienes;
                    //aorpt.mpxsettitle(string.Empty);
                    frmviewer aofrmviewer = new frmviewer(aorpt);
                    aofrmviewer.Text = "AF con Montos - " + EmpleadoSelect.c_codigo.Trim();
                    aofrmviewer.MdiParent = this.MdiParent;
                    aofrmviewer.WindowState = FormWindowState.Maximized;
                    aofrmviewer.Show();
                }
                else
                {
                    Reports.CNZF.rptBienesCTA aorpt = new Reports.CNZF.rptBienesCTA(EmpleadoSelect, mcEscNic, mnNumCia);//(moctx.mstcia.Find(moclscnfapp.mouidcia.Value));                                 
                    aorpt.DataSource = ListBienes;
                    //aorpt.mpxsettitle(string.Empty);
                    frmviewer aofrmviewer = new frmviewer(aorpt);
                    aofrmviewer.Text = "AF con Montos - " + EmpleadoSelect.c_codigo.Trim();
                    aofrmviewer.MdiParent = this.MdiParent;
                    aofrmviewer.WindowState = FormWindowState.Maximized;
                    aofrmviewer.Show();
                }
            }
            else if (mchkincluirmontos.Checked && mchkincluirCTA.Checked)
            {

                if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                {
                    Reports.CZF.rptBienesconMontosCTA aorpt = new Reports.CZF.rptBienesconMontosCTA(EmpleadoSelect, mcEscNic, mnNumCia);//(moctx.mstcia.Find(moclscnfapp.mouidcia.Value));                                 
                    aorpt.DataSource = ListBienes;
                    //aorpt.mpxsettitle(string.Empty);
                    frmviewer aofrmviewer = new frmviewer(aorpt);
                    aofrmviewer.Text = "AF con Montos - " + EmpleadoSelect.c_codigo.Trim();
                    aofrmviewer.MdiParent = this.MdiParent;
                    aofrmviewer.WindowState = FormWindowState.Maximized;
                    aofrmviewer.Show();
                }
                else
                {
                    Reports.CNZF.rptBienesconMontosCTA aorpt = new Reports.CNZF.rptBienesconMontosCTA(EmpleadoSelect, mcEscNic, mnNumCia);//(moctx.mstcia.Find(moclscnfapp.mouidcia.Value));                                 
                    aorpt.DataSource = ListBienes;
                    //aorpt.mpxsettitle(string.Empty);
                    frmviewer aofrmviewer = new frmviewer(aorpt);
                    aofrmviewer.Text = "AF con Montos - " + EmpleadoSelect.c_codigo.Trim();
                    aofrmviewer.MdiParent = this.MdiParent;
                    aofrmviewer.WindowState = FormWindowState.Maximized;
                    aofrmviewer.Show();
                }
            }
            else
            {
                if (moCurrentUser.idEmpresa == (Int16)clsAppEnum.MvxEmpresaSistema.CZF)
                {
                    Reports.CZF.rptBienes aorpt = new Reports.CZF.rptBienes(EmpleadoSelect, mcEscNic, mnNumCia);//(moctx.mstcia.Find(moclscnfapp.mouidcia.Value));                                 
                    aorpt.DataSource = ListBienes;
                    aorpt.mpxsettitle(string.Empty);
                    frmviewer aofrmviewer = new frmviewer(aorpt);
                    aofrmviewer.Text = "AF - " + EmpleadoSelect.c_codigo.Trim();
                    aofrmviewer.MdiParent = this.MdiParent;
                    aofrmviewer.WindowState = FormWindowState.Maximized;
                    aofrmviewer.Show();
                }
                else
                {
                    Reports.CNZF.rptBienes aorpt = new Reports.CNZF.rptBienes(EmpleadoSelect, mcEscNic, mnNumCia);//(moctx.mstcia.Find(moclscnfapp.mouidcia.Value));                                 
                    aorpt.DataSource = ListBienes;
                    aorpt.mpxsettitle(string.Empty);
                    frmviewer aofrmviewer = new frmviewer(aorpt);
                    aofrmviewer.Text = "AF - " + EmpleadoSelect.c_codigo.Trim();
                    aofrmviewer.MdiParent = this.MdiParent;
                    aofrmviewer.WindowState = FormWindowState.Maximized;
                    aofrmviewer.Show();
                }
                
            }            
        }

        private void GridArea_EditValueChanged(object sender, EventArgs e)
        {
             GridLookUpEdit aosender = (GridLookUpEdit)sender;
            if ((aosender.EditValue != System.DBNull.Value) && aosender.EditValue != null)
            {
                var po = aosender.Text;
            }
        }

        #endregion
    }
}