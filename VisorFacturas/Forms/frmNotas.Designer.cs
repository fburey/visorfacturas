
namespace VisorFacturas.Forms
{
    partial class frmNotas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotas));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.Master_grd = new DevExpress.XtraGrid.GridControl();
            this.Master_grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btn_Agregar = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btn_Editar = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btn_View = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btn_Eliminar = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btm_ViewPrevia = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btn_Salir = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.mMaster_bndsrc = new System.Windows.Forms.BindingSource(this.components);
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCont = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNum_nota = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNum_Mes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNom_Mes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConcepto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConceptoR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontoLetra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colElaborado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRevisado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAutorizado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMoneda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsimmon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.pdfViewer1 = new DevExpress.XtraPdfViewer.PdfViewer();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Master_grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Master_grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMaster_bndsrc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.pdfViewer1);
            this.layoutControl1.Controls.Add(this.btn_View);
            this.layoutControl1.Controls.Add(this.btn_Editar);
            this.layoutControl1.Controls.Add(this.btn_Agregar);
            this.layoutControl1.Controls.Add(this.Master_grd);
            this.layoutControl1.Controls.Add(this.btn_Eliminar);
            this.layoutControl1.Controls.Add(this.btm_ViewPrevia);
            this.layoutControl1.Controls.Add(this.btn_Salir);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1181, 578);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem8,
            this.layoutControlGroup1,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1181, 578);
            this.Root.TextVisible = false;
            // 
            // Master_grd
            // 
            this.Master_grd.DataSource = this.mMaster_bndsrc;
            this.Master_grd.Location = new System.Drawing.Point(12, 107);
            this.Master_grd.MainView = this.Master_grv;
            this.Master_grd.Name = "Master_grd";
            this.Master_grd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEdit1});
            this.Master_grd.Size = new System.Drawing.Size(951, 459);
            this.Master_grd.TabIndex = 4;
            this.Master_grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Master_grv});
            // 
            // Master_grv
            // 
            this.Master_grv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colTipo,
            this.colCodigo,
            this.colRuc,
            this.colConcepto,
            this.colConceptoR,
            this.colMontoLetra,
            this.colRevisado,
            this.colAutorizado,
            this.colEstado,
            this.colMoneda,
            this.colCont,
            this.colNum_nota,
            this.colFecha,
            this.colAnno,
            this.colNum_Mes,
            this.colNom_Mes,
            this.colCliente,
            this.colMonto,
            this.colsimmon,
            this.colElaborado});
            this.Master_grv.GridControl = this.Master_grd;
            this.Master_grv.GroupCount = 2;
            this.Master_grv.Name = "Master_grv";
            this.Master_grv.OptionsView.ShowGroupPanel = false;
            this.Master_grv.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colAnno, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colNum_Mes, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.Master_grd;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 95);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(955, 0);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(955, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(955, 463);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btn_Agregar.Appearance.Options.UseFont = true;
            this.btn_Agregar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btn_Agregar.Location = new System.Drawing.Point(24, 45);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(126, 46);
            this.btn_Agregar.StyleController = this.layoutControl1;
            this.btn_Agregar.TabIndex = 5;
            this.btn_Agregar.Text = "Agregar";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btn_Agregar;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(130, 50);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(130, 50);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(130, 50);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // btn_Editar
            // 
            this.btn_Editar.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btn_Editar.Appearance.Options.UseFont = true;
            this.btn_Editar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.btn_Editar.Location = new System.Drawing.Point(154, 45);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(126, 46);
            this.btn_Editar.StyleController = this.layoutControl1;
            this.btn_Editar.TabIndex = 6;
            this.btn_Editar.Text = "Editar";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btn_Editar;
            this.layoutControlItem3.Location = new System.Drawing.Point(130, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(130, 50);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(130, 50);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(130, 50);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // btn_View
            // 
            this.btn_View.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btn_View.Appearance.Options.UseFont = true;
            this.btn_View.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.ImageOptions.Image")));
            this.btn_View.Location = new System.Drawing.Point(284, 45);
            this.btn_View.Name = "btn_View";
            this.btn_View.Size = new System.Drawing.Size(126, 46);
            this.btn_View.StyleController = this.layoutControl1;
            this.btn_View.TabIndex = 7;
            this.btn_View.Text = "Visualizar";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btn_View;
            this.layoutControlItem4.Location = new System.Drawing.Point(260, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(130, 50);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(130, 50);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(130, 50);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btn_Eliminar.Appearance.Options.UseFont = true;
            this.btn_Eliminar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton31.ImageOptions.Image")));
            this.btn_Eliminar.Location = new System.Drawing.Point(414, 45);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(126, 46);
            this.btn_Eliminar.StyleController = this.layoutControl1;
            this.btn_Eliminar.TabIndex = 7;
            this.btn_Eliminar.Text = "Eliminar";
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btn_Eliminar;
            this.layoutControlItem5.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem5.Location = new System.Drawing.Point(390, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(130, 50);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(130, 50);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(130, 50);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "layoutControlItem4";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // btm_ViewPrevia
            // 
            this.btm_ViewPrevia.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btm_ViewPrevia.Appearance.Options.UseFont = true;
            this.btm_ViewPrevia.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton32.ImageOptions.Image")));
            this.btm_ViewPrevia.Location = new System.Drawing.Point(544, 45);
            this.btm_ViewPrevia.Name = "btm_ViewPrevia";
            this.btm_ViewPrevia.Size = new System.Drawing.Size(126, 46);
            this.btm_ViewPrevia.StyleController = this.layoutControl1;
            this.btm_ViewPrevia.TabIndex = 7;
            this.btm_ViewPrevia.Text = "Vista previa";
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btm_ViewPrevia;
            this.layoutControlItem6.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem6.Location = new System.Drawing.Point(520, 0);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(130, 50);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(130, 50);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(130, 50);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "layoutControlItem4";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // btn_Salir
            // 
            this.btn_Salir.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btn_Salir.Appearance.Options.UseFont = true;
            this.btn_Salir.ImageOptions.Image = global::VisorFacturas.Properties.Resources.TraExt_btn;
            this.btn_Salir.Location = new System.Drawing.Point(674, 45);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(126, 46);
            this.btn_Salir.StyleController = this.layoutControl1;
            this.btn_Salir.TabIndex = 7;
            this.btn_Salir.Text = "Salir";
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btn_Salir;
            this.layoutControlItem7.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem7.Location = new System.Drawing.Point(650, 0);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(130, 50);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(130, 50);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(130, 50);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "layoutControlItem4";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // mMaster_bndsrc
            // 
            this.mMaster_bndsrc.DataSource = typeof(VisorFacturas.DataNota.dbo_pro_lst_NotasDC_Result);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colTipo
            // 
            this.colTipo.FieldName = "Tipo";
            this.colTipo.Name = "colTipo";
            // 
            // colCont
            // 
            this.colCont.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCont.AppearanceCell.Options.UseFont = true;
            this.colCont.AppearanceCell.Options.UseTextOptions = true;
            this.colCont.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCont.Caption = "Contador";
            this.colCont.FieldName = "Cont";
            this.colCont.MaxWidth = 70;
            this.colCont.MinWidth = 70;
            this.colCont.Name = "colCont";
            this.colCont.Visible = true;
            this.colCont.VisibleIndex = 0;
            this.colCont.Width = 91;
            // 
            // colNum_nota
            // 
            this.colNum_nota.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNum_nota.AppearanceHeader.Options.UseFont = true;
            this.colNum_nota.AppearanceHeader.Options.UseTextOptions = true;
            this.colNum_nota.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNum_nota.Caption = "# Nota";
            this.colNum_nota.FieldName = "Num_nota";
            this.colNum_nota.MaxWidth = 70;
            this.colNum_nota.MinWidth = 70;
            this.colNum_nota.Name = "colNum_nota";
            this.colNum_nota.Visible = true;
            this.colNum_nota.VisibleIndex = 1;
            this.colNum_nota.Width = 70;
            // 
            // colFecha
            // 
            this.colFecha.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colFecha.AppearanceHeader.Options.UseFont = true;
            this.colFecha.AppearanceHeader.Options.UseTextOptions = true;
            this.colFecha.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFecha.Caption = "Fecha";
            this.colFecha.FieldName = "Fecha";
            this.colFecha.MaxWidth = 80;
            this.colFecha.MinWidth = 80;
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 2;
            this.colFecha.Width = 80;
            // 
            // colAnno
            // 
            this.colAnno.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colAnno.AppearanceHeader.Options.UseFont = true;
            this.colAnno.AppearanceHeader.Options.UseTextOptions = true;
            this.colAnno.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAnno.Caption = "Año";
            this.colAnno.FieldName = "Anno";
            this.colAnno.MaxWidth = 50;
            this.colAnno.MinWidth = 50;
            this.colAnno.Name = "colAnno";
            this.colAnno.Visible = true;
            this.colAnno.VisibleIndex = 3;
            this.colAnno.Width = 50;
            // 
            // colNum_Mes
            // 
            this.colNum_Mes.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNum_Mes.AppearanceHeader.Options.UseFont = true;
            this.colNum_Mes.AppearanceHeader.Options.UseTextOptions = true;
            this.colNum_Mes.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNum_Mes.Caption = "Mes";
            this.colNum_Mes.FieldName = "Num_Mes";
            this.colNum_Mes.FieldNameSortGroup = "Num_Mes";
            this.colNum_Mes.MaxWidth = 50;
            this.colNum_Mes.MinWidth = 50;
            this.colNum_Mes.Name = "colNum_Mes";
            this.colNum_Mes.Width = 50;
            // 
            // colNom_Mes
            // 
            this.colNom_Mes.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNom_Mes.AppearanceHeader.Options.UseFont = true;
            this.colNom_Mes.AppearanceHeader.Options.UseTextOptions = true;
            this.colNom_Mes.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNom_Mes.Caption = "Mes";
            this.colNom_Mes.FieldName = "Nom_Mes";
            this.colNom_Mes.MaxWidth = 60;
            this.colNom_Mes.MinWidth = 60;
            this.colNom_Mes.Name = "colNom_Mes";
            this.colNom_Mes.Width = 60;
            // 
            // colCodigo
            // 
            this.colCodigo.FieldName = "Codigo";
            this.colCodigo.Name = "colCodigo";
            // 
            // colCliente
            // 
            this.colCliente.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCliente.AppearanceHeader.Options.UseFont = true;
            this.colCliente.AppearanceHeader.Options.UseTextOptions = true;
            this.colCliente.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCliente.Caption = "Cliente";
            this.colCliente.FieldName = "Cliente";
            this.colCliente.MaxWidth = 300;
            this.colCliente.MinWidth = 300;
            this.colCliente.Name = "colCliente";
            this.colCliente.Visible = true;
            this.colCliente.VisibleIndex = 3;
            this.colCliente.Width = 300;
            // 
            // colRuc
            // 
            this.colRuc.FieldName = "Ruc";
            this.colRuc.Name = "colRuc";
            // 
            // colConcepto
            // 
            this.colConcepto.FieldName = "Concepto";
            this.colConcepto.Name = "colConcepto";
            // 
            // colConceptoR
            // 
            this.colConceptoR.FieldName = "ConceptoR";
            this.colConceptoR.Name = "colConceptoR";
            // 
            // colMonto
            // 
            this.colMonto.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMonto.AppearanceHeader.Options.UseFont = true;
            this.colMonto.AppearanceHeader.Options.UseTextOptions = true;
            this.colMonto.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMonto.Caption = "Monto";
            this.colMonto.ColumnEdit = this.repositoryItemSpinEdit1;
            this.colMonto.FieldName = "Monto";
            this.colMonto.MaxWidth = 120;
            this.colMonto.MinWidth = 120;
            this.colMonto.Name = "colMonto";
            this.colMonto.Visible = true;
            this.colMonto.VisibleIndex = 4;
            this.colMonto.Width = 120;
            // 
            // colMontoLetra
            // 
            this.colMontoLetra.FieldName = "MontoLetra";
            this.colMontoLetra.Name = "colMontoLetra";
            // 
            // colElaborado
            // 
            this.colElaborado.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colElaborado.AppearanceHeader.Options.UseFont = true;
            this.colElaborado.AppearanceHeader.Options.UseTextOptions = true;
            this.colElaborado.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colElaborado.Caption = "Elaborado Por";
            this.colElaborado.FieldName = "Elaborado";
            this.colElaborado.MaxWidth = 200;
            this.colElaborado.MinWidth = 200;
            this.colElaborado.Name = "colElaborado";
            this.colElaborado.Visible = true;
            this.colElaborado.VisibleIndex = 6;
            this.colElaborado.Width = 200;
            // 
            // colRevisado
            // 
            this.colRevisado.FieldName = "Revisado";
            this.colRevisado.Name = "colRevisado";
            // 
            // colAutorizado
            // 
            this.colAutorizado.FieldName = "Autorizado";
            this.colAutorizado.Name = "colAutorizado";
            // 
            // colEstado
            // 
            this.colEstado.FieldName = "Estado";
            this.colEstado.Name = "colEstado";
            // 
            // colMoneda
            // 
            this.colMoneda.FieldName = "Moneda";
            this.colMoneda.Name = "colMoneda";
            // 
            // colsimmon
            // 
            this.colsimmon.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colsimmon.AppearanceHeader.Options.UseFont = true;
            this.colsimmon.AppearanceHeader.Options.UseTextOptions = true;
            this.colsimmon.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colsimmon.Caption = "Moneda";
            this.colsimmon.FieldName = "simmon";
            this.colsimmon.MaxWidth = 60;
            this.colsimmon.MinWidth = 60;
            this.colsimmon.Name = "colsimmon";
            this.colsimmon.Visible = true;
            this.colsimmon.VisibleIndex = 5;
            this.colsimmon.Width = 60;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit1.MaskSettings.Set("mask", "n2");
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            this.repositoryItemSpinEdit1.UseMaskAsDisplayFormat = true;
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.Location = new System.Drawing.Point(967, 107);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.Size = new System.Drawing.Size(202, 459);
            this.pdfViewer1.TabIndex = 8;
            this.pdfViewer1.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.PageLevel;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.pdfViewer1;
            this.layoutControlItem8.Location = new System.Drawing.Point(955, 95);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(206, 463);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(804, 95);
            this.layoutControlGroup1.Text = "Acciones";
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(804, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(357, 95);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 578);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmNotas";
            this.Text = "frmNotas";
            this.Load += new System.EventHandler(this.frmNotas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Master_grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Master_grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mMaster_bndsrc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btn_View;
        private DevExpress.XtraEditors.SimpleButton btn_Editar;
        private DevExpress.XtraEditors.SimpleButton btn_Agregar;
        private DevExpress.XtraGrid.GridControl Master_grd;
        private DevExpress.XtraGrid.Views.Grid.GridView Master_grv;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton btn_Eliminar;
        private DevExpress.XtraEditors.SimpleButton btm_ViewPrevia;
        private DevExpress.XtraEditors.SimpleButton btn_Salir;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private System.Windows.Forms.BindingSource mMaster_bndsrc;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colTipo;
        private DevExpress.XtraGrid.Columns.GridColumn colCont;
        private DevExpress.XtraGrid.Columns.GridColumn colNum_nota;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colAnno;
        private DevExpress.XtraGrid.Columns.GridColumn colNum_Mes;
        private DevExpress.XtraGrid.Columns.GridColumn colNom_Mes;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colRuc;
        private DevExpress.XtraGrid.Columns.GridColumn colConcepto;
        private DevExpress.XtraGrid.Columns.GridColumn colConceptoR;
        private DevExpress.XtraGrid.Columns.GridColumn colMonto;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoLetra;
        private DevExpress.XtraGrid.Columns.GridColumn colElaborado;
        private DevExpress.XtraGrid.Columns.GridColumn colRevisado;
        private DevExpress.XtraGrid.Columns.GridColumn colAutorizado;
        private DevExpress.XtraGrid.Columns.GridColumn colEstado;
        private DevExpress.XtraGrid.Columns.GridColumn colMoneda;
        private DevExpress.XtraGrid.Columns.GridColumn colsimmon;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}