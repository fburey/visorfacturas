namespace VisorFacturas.Forms
{
    partial class frmFacturas
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnexportar = new DevExpress.XtraEditors.SimpleButton();
            this.btnEnviarCorreo = new DevExpress.XtraEditors.SimpleButton();
            this.chkSinFormat = new DevExpress.XtraEditors.CheckEdit();
            this.chkImpresionMasiva = new DevExpress.XtraEditors.CheckEdit();
            this.btnSalir = new DevExpress.XtraEditors.SimpleButton();
            this.btnImprimir = new DevExpress.XtraEditors.SimpleButton();
            this.gcFacturas = new DevExpress.XtraGrid.GridControl();
            this.bsGrid = new System.Windows.Forms.BindingSource(this.components);
            this.gvFacturas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colfac_fac_nu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcli_nom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcli_codig = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colord_numero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfac_tasa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfac_amo_do = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfac_amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfac_dolcor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tipomoneda_ricmb = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.tipofactura_ricmb = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.speAnno = new DevExpress.XtraEditors.SpinEdit();
            this.btnFiltrar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbMes = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtpFacturas = new DevExpress.XtraTab.XtraTabPage();
            this.xtpCorreos = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.xtcTipoEnvio = new DevExpress.XtraTab.XtraTabControl();
            this.xtpEnvioMasivo = new DevExpress.XtraTab.XtraTabPage();
            this.gcCorreos = new DevExpress.XtraGrid.GridControl();
            this.bsClientes = new System.Windows.Forms.BindingSource(this.components);
            this.gvCorreos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colcli_nom1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcli_cod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcli_dir = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcli_email1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcli_email2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtpEnvioIndividual = new DevExpress.XtraTab.XtraTabPage();
            this.LstCorreosIndiv = new DevExpress.XtraEditors.ListBoxControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtEnvioIndividual = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.groupctl_datos_correo = new DevExpress.XtraEditors.GroupControl();
            this.btnVolver = new DevExpress.XtraEditors.SimpleButton();
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnEnviar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtCuerpo = new DevExpress.XtraEditors.MemoEdit();
            this.txtNombreRem = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtCorreoRem = new DevExpress.XtraEditors.TextEdit();
            this.txtAsunto = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.bsCorreos = new System.Windows.Forms.BindingSource(this.components);
            this.dxErrProv = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSinFormat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkImpresionMasiva.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFacturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFacturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipomoneda_ricmb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipofactura_ricmb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speAnno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtpFacturas.SuspendLayout();
            this.xtpCorreos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtcTipoEnvio)).BeginInit();
            this.xtcTipoEnvio.SuspendLayout();
            this.xtpEnvioMasivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCorreos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCorreos)).BeginInit();
            this.xtpEnvioIndividual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LstCorreosIndiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnvioIndividual.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupctl_datos_correo)).BeginInit();
            this.groupctl_datos_correo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCuerpo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreRem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorreoRem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAsunto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCorreos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrProv)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupControl2.Controls.Add(this.btnexportar);
            this.groupControl2.Controls.Add(this.btnEnviarCorreo);
            this.groupControl2.Controls.Add(this.chkSinFormat);
            this.groupControl2.Controls.Add(this.chkImpresionMasiva);
            this.groupControl2.Controls.Add(this.btnSalir);
            this.groupControl2.Controls.Add(this.btnImprimir);
            this.groupControl2.Location = new System.Drawing.Point(3, 154);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(205, 458);
            this.groupControl2.TabIndex = 11;
            this.groupControl2.Text = "Acciones";
            // 
            // btnexportar
            // 
            this.btnexportar.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexportar.Appearance.Options.UseFont = true;
            this.btnexportar.Appearance.Options.UseTextOptions = true;
            this.btnexportar.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnexportar.ImageOptions.Image = global::VisorFacturas.Properties.Resources.export_spreadsheet_32x32;
            this.btnexportar.Location = new System.Drawing.Point(18, 210);
            this.btnexportar.Name = "btnexportar";
            this.btnexportar.Size = new System.Drawing.Size(160, 54);
            this.btnexportar.TabIndex = 11;
            this.btnexportar.Text = "Exportar";
            this.btnexportar.Click += new System.EventHandler(this.btnexportar_Click);
            // 
            // btnEnviarCorreo
            // 
            this.btnEnviarCorreo.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviarCorreo.Appearance.Options.UseFont = true;
            this.btnEnviarCorreo.Appearance.Options.UseTextOptions = true;
            this.btnEnviarCorreo.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnEnviarCorreo.ImageOptions.Image = global::VisorFacturas.Properties.Resources.send_32x32;
            this.btnEnviarCorreo.Location = new System.Drawing.Point(18, 150);
            this.btnEnviarCorreo.Name = "btnEnviarCorreo";
            this.btnEnviarCorreo.Size = new System.Drawing.Size(160, 54);
            this.btnEnviarCorreo.TabIndex = 10;
            this.btnEnviarCorreo.Text = "Enviar Correo";
            this.btnEnviarCorreo.Click += new System.EventHandler(this.btnEnviarCorreo_Click);
            // 
            // chkSinFormat
            // 
            this.chkSinFormat.Location = new System.Drawing.Point(18, 56);
            this.chkSinFormat.Name = "chkSinFormat";
            this.chkSinFormat.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSinFormat.Properties.Appearance.Options.UseFont = true;
            this.chkSinFormat.Properties.Caption = "Sin Formato";
            this.chkSinFormat.Size = new System.Drawing.Size(160, 23);
            this.chkSinFormat.TabIndex = 9;
            // 
            // chkImpresionMasiva
            // 
            this.chkImpresionMasiva.Location = new System.Drawing.Point(18, 22);
            this.chkImpresionMasiva.Name = "chkImpresionMasiva";
            this.chkImpresionMasiva.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkImpresionMasiva.Properties.Appearance.Options.UseFont = true;
            this.chkImpresionMasiva.Properties.Caption = "Impresión Masiva";
            this.chkImpresionMasiva.Size = new System.Drawing.Size(160, 23);
            this.chkImpresionMasiva.TabIndex = 6;
            // 
            // btnSalir
            // 
            this.btnSalir.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Appearance.Options.UseFont = true;
            this.btnSalir.Appearance.Options.UseTextOptions = true;
            this.btnSalir.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnSalir.ImageOptions.Image = global::VisorFacturas.Properties.Resources.TraExt_btn;
            this.btnSalir.Location = new System.Drawing.Point(18, 270);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(160, 54);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Appearance.Options.UseFont = true;
            this.btnImprimir.Appearance.Options.UseTextOptions = true;
            this.btnImprimir.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnImprimir.ImageOptions.Image = global::VisorFacturas.Properties.Resources.printer_32x32;
            this.btnImprimir.Location = new System.Drawing.Point(18, 90);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(160, 54);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // gcFacturas
            // 
            this.gcFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcFacturas.DataSource = this.bsGrid;
            this.gcFacturas.Location = new System.Drawing.Point(214, 3);
            this.gcFacturas.MainView = this.gvFacturas;
            this.gcFacturas.Name = "gcFacturas";
            this.gcFacturas.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.tipomoneda_ricmb,
            this.tipofactura_ricmb});
            this.gcFacturas.Size = new System.Drawing.Size(904, 565);
            this.gcFacturas.TabIndex = 10;
            this.gcFacturas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFacturas});
            // 
            // bsGrid
            // 
            this.bsGrid.DataSource = typeof(VisorFacturas.Clases.viewFactura);
            // 
            // gvFacturas
            // 
            this.gvFacturas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colfac_fac_nu,
            this.colcli_nom,
            this.colcli_codig,
            this.colfecha,
            this.colord_numero,
            this.colfac_tasa,
            this.colfac_amo_do,
            this.colfac_amount,
            this.colfac_dolcor,
            this.coltipo});
            this.gvFacturas.GridControl = this.gcFacturas;
            this.gvFacturas.Name = "gvFacturas";
            this.gvFacturas.OptionsBehavior.Editable = false;
            this.gvFacturas.OptionsView.ColumnAutoWidth = false;
            this.gvFacturas.OptionsView.ShowAutoFilterRow = true;
            this.gvFacturas.OptionsView.ShowGroupPanel = false;
            this.gvFacturas.OptionsView.ShowViewCaption = true;
            this.gvFacturas.ViewCaption = "Total de Facturas Encontradas:";
            this.gvFacturas.ViewCaptionHeight = 25;
            this.gvFacturas.ColumnFilterChanged += new System.EventHandler(this.gvFacturas_ColumnFilterChanged);
            // 
            // colfac_fac_nu
            // 
            this.colfac_fac_nu.AppearanceCell.Options.UseTextOptions = true;
            this.colfac_fac_nu.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colfac_fac_nu.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colfac_fac_nu.AppearanceHeader.Options.UseFont = true;
            this.colfac_fac_nu.AppearanceHeader.Options.UseTextOptions = true;
            this.colfac_fac_nu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colfac_fac_nu.Caption = "# Factura";
            this.colfac_fac_nu.FieldName = "fac_fac_nu";
            this.colfac_fac_nu.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colfac_fac_nu.Name = "colfac_fac_nu";
            this.colfac_fac_nu.Visible = true;
            this.colfac_fac_nu.VisibleIndex = 0;
            this.colfac_fac_nu.Width = 90;
            // 
            // colcli_nom
            // 
            this.colcli_nom.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colcli_nom.AppearanceHeader.Options.UseFont = true;
            this.colcli_nom.AppearanceHeader.Options.UseTextOptions = true;
            this.colcli_nom.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colcli_nom.Caption = "Cliente";
            this.colcli_nom.FieldName = "cli_nom";
            this.colcli_nom.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colcli_nom.Name = "colcli_nom";
            this.colcli_nom.Visible = true;
            this.colcli_nom.VisibleIndex = 1;
            this.colcli_nom.Width = 260;
            // 
            // colcli_codig
            // 
            this.colcli_codig.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colcli_codig.AppearanceHeader.Options.UseFont = true;
            this.colcli_codig.AppearanceHeader.Options.UseTextOptions = true;
            this.colcli_codig.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colcli_codig.Caption = "Cód. Cliente";
            this.colcli_codig.FieldName = "cli_codig";
            this.colcli_codig.Name = "colcli_codig";
            this.colcli_codig.Visible = true;
            this.colcli_codig.VisibleIndex = 2;
            this.colcli_codig.Width = 130;
            // 
            // colfecha
            // 
            this.colfecha.AppearanceCell.Options.UseTextOptions = true;
            this.colfecha.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colfecha.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colfecha.AppearanceHeader.Options.UseFont = true;
            this.colfecha.AppearanceHeader.Options.UseTextOptions = true;
            this.colfecha.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colfecha.Caption = "Fecha";
            this.colfecha.FieldName = "fecha";
            this.colfecha.Name = "colfecha";
            this.colfecha.Visible = true;
            this.colfecha.VisibleIndex = 3;
            this.colfecha.Width = 100;
            // 
            // colord_numero
            // 
            this.colord_numero.AppearanceCell.Options.UseTextOptions = true;
            this.colord_numero.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colord_numero.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colord_numero.AppearanceHeader.Options.UseFont = true;
            this.colord_numero.AppearanceHeader.Options.UseTextOptions = true;
            this.colord_numero.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colord_numero.Caption = "# Orden";
            this.colord_numero.FieldName = "ord_numero";
            this.colord_numero.Name = "colord_numero";
            this.colord_numero.Visible = true;
            this.colord_numero.VisibleIndex = 4;
            // 
            // colfac_tasa
            // 
            this.colfac_tasa.AppearanceCell.Options.UseTextOptions = true;
            this.colfac_tasa.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colfac_tasa.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colfac_tasa.AppearanceHeader.Options.UseFont = true;
            this.colfac_tasa.AppearanceHeader.Options.UseTextOptions = true;
            this.colfac_tasa.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colfac_tasa.Caption = "Tasa";
            this.colfac_tasa.FieldName = "fac_tasa";
            this.colfac_tasa.Name = "colfac_tasa";
            this.colfac_tasa.Visible = true;
            this.colfac_tasa.VisibleIndex = 5;
            this.colfac_tasa.Width = 90;
            // 
            // colfac_amo_do
            // 
            this.colfac_amo_do.AppearanceCell.Options.UseTextOptions = true;
            this.colfac_amo_do.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colfac_amo_do.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colfac_amo_do.AppearanceHeader.Options.UseFont = true;
            this.colfac_amo_do.AppearanceHeader.Options.UseTextOptions = true;
            this.colfac_amo_do.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colfac_amo_do.Caption = "Monto Total U$";
            this.colfac_amo_do.DisplayFormat.FormatString = "#,0.00";
            this.colfac_amo_do.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colfac_amo_do.FieldName = "fac_amo_do";
            this.colfac_amo_do.Name = "colfac_amo_do";
            this.colfac_amo_do.Visible = true;
            this.colfac_amo_do.VisibleIndex = 6;
            this.colfac_amo_do.Width = 120;
            // 
            // colfac_amount
            // 
            this.colfac_amount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colfac_amount.AppearanceHeader.Options.UseFont = true;
            this.colfac_amount.AppearanceHeader.Options.UseTextOptions = true;
            this.colfac_amount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colfac_amount.Caption = "Monto Total C$";
            this.colfac_amount.DisplayFormat.FormatString = "#,0.00";
            this.colfac_amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colfac_amount.FieldName = "fac_amount";
            this.colfac_amount.Name = "colfac_amount";
            this.colfac_amount.Visible = true;
            this.colfac_amount.VisibleIndex = 7;
            this.colfac_amount.Width = 120;
            // 
            // colfac_dolcor
            // 
            this.colfac_dolcor.AppearanceCell.Options.UseTextOptions = true;
            this.colfac_dolcor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colfac_dolcor.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colfac_dolcor.AppearanceHeader.Options.UseFont = true;
            this.colfac_dolcor.AppearanceHeader.Options.UseTextOptions = true;
            this.colfac_dolcor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colfac_dolcor.Caption = "Moneda Factura";
            this.colfac_dolcor.FieldName = "fac_dolcor";
            this.colfac_dolcor.Name = "colfac_dolcor";
            this.colfac_dolcor.Visible = true;
            this.colfac_dolcor.VisibleIndex = 8;
            this.colfac_dolcor.Width = 100;
            // 
            // coltipo
            // 
            this.coltipo.AppearanceCell.Options.UseTextOptions = true;
            this.coltipo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coltipo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.coltipo.AppearanceHeader.Options.UseFont = true;
            this.coltipo.AppearanceHeader.Options.UseTextOptions = true;
            this.coltipo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coltipo.Caption = "Tipo";
            this.coltipo.FieldName = "tipo";
            this.coltipo.Name = "coltipo";
            this.coltipo.Width = 76;
            // 
            // tipomoneda_ricmb
            // 
            this.tipomoneda_ricmb.AutoHeight = false;
            this.tipomoneda_ricmb.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tipomoneda_ricmb.Name = "tipomoneda_ricmb";
            // 
            // tipofactura_ricmb
            // 
            this.tipofactura_ricmb.AutoHeight = false;
            this.tipofactura_ricmb.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tipofactura_ricmb.Name = "tipofactura_ricmb";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.speAnno);
            this.groupControl1.Controls.Add(this.btnFiltrar);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.cmbMes);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(205, 145);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "Filtros";
            // 
            // speAnno
            // 
            this.speAnno.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.speAnno.Location = new System.Drawing.Point(67, 66);
            this.speAnno.Name = "speAnno";
            this.speAnno.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.speAnno.Properties.Appearance.Options.UseFont = true;
            this.speAnno.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.speAnno.Properties.IsFloatValue = false;
            this.speAnno.Properties.Mask.EditMask = "N00";
            this.speAnno.Size = new System.Drawing.Size(111, 26);
            this.speAnno.TabIndex = 6;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.Appearance.Options.UseFont = true;
            this.btnFiltrar.Appearance.Options.UseTextOptions = true;
            this.btnFiltrar.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnFiltrar.ImageOptions.Image = global::VisorFacturas.Properties.Resources.filter_32x32;
            this.btnFiltrar.Location = new System.Drawing.Point(69, 98);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(109, 37);
            this.btnFiltrar.TabIndex = 3;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(18, 37);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(33, 19);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Mes:";
            // 
            // cmbMes
            // 
            this.cmbMes.Location = new System.Drawing.Point(67, 34);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMes.Properties.Appearance.Options.UseFont = true;
            this.cmbMes.Properties.Appearance.Options.UseTextOptions = true;
            this.cmbMes.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.cmbMes.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cmbMes.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cmbMes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbMes.Properties.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.cmbMes.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbMes.Size = new System.Drawing.Size(111, 26);
            this.cmbMes.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(18, 69);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(35, 19);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Año:";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.AppearancePage.Header.Font = new System.Drawing.Font("Century", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtraTabControl1.AppearancePage.Header.Options.UseFont = true;
            this.xtraTabControl1.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Century", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtraTabControl1.AppearancePage.HeaderActive.Options.UseFont = true;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 1);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtpFacturas;
            this.xtraTabControl1.Size = new System.Drawing.Size(1127, 616);
            this.xtraTabControl1.TabIndex = 12;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtpFacturas,
            this.xtpCorreos});
            // 
            // xtpFacturas
            // 
            this.xtpFacturas.Controls.Add(this.gcFacturas);
            this.xtpFacturas.Controls.Add(this.groupControl2);
            this.xtpFacturas.Controls.Add(this.groupControl1);
            this.xtpFacturas.Name = "xtpFacturas";
            this.xtpFacturas.Size = new System.Drawing.Size(1121, 576);
            this.xtpFacturas.Text = "Facturas";
            // 
            // xtpCorreos
            // 
            this.xtpCorreos.Controls.Add(this.panelControl3);
            this.xtpCorreos.Controls.Add(this.splitterControl1);
            this.xtpCorreos.Controls.Add(this.panelControl2);
            this.xtpCorreos.Name = "xtpCorreos";
            this.xtpCorreos.Size = new System.Drawing.Size(1121, 576);
            this.xtpCorreos.Text = "Correos";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.groupControl4);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(660, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(461, 576);
            this.panelControl3.TabIndex = 0;
            // 
            // groupControl4
            // 
            this.groupControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl4.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupControl4.AppearanceCaption.Options.UseFont = true;
            this.groupControl4.Controls.Add(this.xtcTipoEnvio);
            this.groupControl4.Location = new System.Drawing.Point(6, 5);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(452, 563);
            this.groupControl4.TabIndex = 13;
            this.groupControl4.Text = "Listado de Correos";
            // 
            // xtcTipoEnvio
            // 
            this.xtcTipoEnvio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtcTipoEnvio.Location = new System.Drawing.Point(5, 29);
            this.xtcTipoEnvio.Name = "xtcTipoEnvio";
            this.xtcTipoEnvio.SelectedTabPage = this.xtpEnvioMasivo;
            this.xtcTipoEnvio.Size = new System.Drawing.Size(443, 529);
            this.xtcTipoEnvio.TabIndex = 12;
            this.xtcTipoEnvio.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtpEnvioMasivo,
            this.xtpEnvioIndividual});
            // 
            // xtpEnvioMasivo
            // 
            this.xtpEnvioMasivo.Controls.Add(this.gcCorreos);
            this.xtpEnvioMasivo.Name = "xtpEnvioMasivo";
            this.xtpEnvioMasivo.Size = new System.Drawing.Size(437, 501);
            this.xtpEnvioMasivo.Text = "Envío Masivo";
            // 
            // gcCorreos
            // 
            this.gcCorreos.DataSource = this.bsClientes;
            this.gcCorreos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCorreos.Location = new System.Drawing.Point(0, 0);
            this.gcCorreos.MainView = this.gvCorreos;
            this.gcCorreos.Name = "gcCorreos";
            this.gcCorreos.Size = new System.Drawing.Size(437, 501);
            this.gcCorreos.TabIndex = 11;
            this.gcCorreos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCorreos});
            // 
            // bsClientes
            // 
            this.bsClientes.DataSource = typeof(VisorFacturas.Clases.viewClientes);
            // 
            // gvCorreos
            // 
            this.gvCorreos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colcli_nom1,
            this.colcli_cod,
            this.colcli_dir,
            this.colcli_email1,
            this.colcli_email2});
            this.gvCorreos.GridControl = this.gcCorreos;
            this.gvCorreos.Name = "gvCorreos";
            this.gvCorreos.OptionsBehavior.AutoPopulateColumns = false;
            this.gvCorreos.OptionsBehavior.Editable = false;
            this.gvCorreos.OptionsView.ColumnAutoWidth = false;
            this.gvCorreos.OptionsView.ShowAutoFilterRow = true;
            this.gvCorreos.OptionsView.ShowGroupPanel = false;
            this.gvCorreos.PreviewFieldName = "cli_desc";
            this.gvCorreos.ViewCaption = "Total de Facturas Encontradas:";
            this.gvCorreos.ViewCaptionHeight = 25;
            // 
            // colcli_nom1
            // 
            this.colcli_nom1.Caption = "Cliente";
            this.colcli_nom1.FieldName = "cli_nom";
            this.colcli_nom1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colcli_nom1.Name = "colcli_nom1";
            this.colcli_nom1.Visible = true;
            this.colcli_nom1.VisibleIndex = 0;
            this.colcli_nom1.Width = 250;
            // 
            // colcli_cod
            // 
            this.colcli_cod.Caption = "Código";
            this.colcli_cod.FieldName = "cli_cod";
            this.colcli_cod.Name = "colcli_cod";
            this.colcli_cod.Visible = true;
            this.colcli_cod.VisibleIndex = 1;
            this.colcli_cod.Width = 140;
            // 
            // colcli_dir
            // 
            this.colcli_dir.Caption = "Dirección";
            this.colcli_dir.FieldName = "cli_dir";
            this.colcli_dir.Name = "colcli_dir";
            // 
            // colcli_email1
            // 
            this.colcli_email1.Caption = "Correo N°1";
            this.colcli_email1.FieldName = "cli_email1";
            this.colcli_email1.Name = "colcli_email1";
            this.colcli_email1.Visible = true;
            this.colcli_email1.VisibleIndex = 2;
            this.colcli_email1.Width = 180;
            // 
            // colcli_email2
            // 
            this.colcli_email2.Caption = "Correo N°2";
            this.colcli_email2.FieldName = "cli_email2";
            this.colcli_email2.Name = "colcli_email2";
            this.colcli_email2.Visible = true;
            this.colcli_email2.VisibleIndex = 3;
            this.colcli_email2.Width = 180;
            // 
            // xtpEnvioIndividual
            // 
            this.xtpEnvioIndividual.Controls.Add(this.LstCorreosIndiv);
            this.xtpEnvioIndividual.Controls.Add(this.labelControl9);
            this.xtpEnvioIndividual.Controls.Add(this.txtEnvioIndividual);
            this.xtpEnvioIndividual.Controls.Add(this.labelControl8);
            this.xtpEnvioIndividual.Name = "xtpEnvioIndividual";
            this.xtpEnvioIndividual.Size = new System.Drawing.Size(437, 501);
            this.xtpEnvioIndividual.Text = "Envío Individual";
            // 
            // LstCorreosIndiv
            // 
            this.LstCorreosIndiv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LstCorreosIndiv.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.LstCorreosIndiv.Appearance.Options.UseFont = true;
            this.LstCorreosIndiv.Cursor = System.Windows.Forms.Cursors.Default;
            this.LstCorreosIndiv.Location = new System.Drawing.Point(20, 123);
            this.LstCorreosIndiv.Name = "LstCorreosIndiv";
            this.LstCorreosIndiv.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.LstCorreosIndiv.Size = new System.Drawing.Size(383, 159);
            this.LstCorreosIndiv.TabIndex = 5;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(20, 98);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(150, 19);
            this.labelControl9.TabIndex = 4;
            this.labelControl9.Text = "Correos Electrónicos:";
            // 
            // txtEnvioIndividual
            // 
            this.txtEnvioIndividual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnvioIndividual.Location = new System.Drawing.Point(20, 45);
            this.txtEnvioIndividual.Name = "txtEnvioIndividual";
            this.txtEnvioIndividual.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnvioIndividual.Properties.Appearance.Options.UseFont = true;
            this.txtEnvioIndividual.Properties.ReadOnly = true;
            this.txtEnvioIndividual.Size = new System.Drawing.Size(383, 26);
            this.txtEnvioIndividual.TabIndex = 3;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(20, 20);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(215, 19);
            this.labelControl8.TabIndex = 1;
            this.labelControl8.Text = "Envío de Correo Electrónico a:";
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(655, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 576);
            this.splitterControl1.TabIndex = 1;
            this.splitterControl1.TabStop = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.groupctl_datos_correo);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(655, 576);
            this.panelControl2.TabIndex = 0;
            // 
            // groupctl_datos_correo
            // 
            this.groupctl_datos_correo.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupctl_datos_correo.AppearanceCaption.Options.UseFont = true;
            this.groupctl_datos_correo.Controls.Add(this.btnVolver);
            this.groupctl_datos_correo.Controls.Add(this.progressPanel1);
            this.groupctl_datos_correo.Controls.Add(this.labelControl4);
            this.groupctl_datos_correo.Controls.Add(this.btnEnviar);
            this.groupctl_datos_correo.Controls.Add(this.labelControl5);
            this.groupctl_datos_correo.Controls.Add(this.txtCuerpo);
            this.groupctl_datos_correo.Controls.Add(this.txtNombreRem);
            this.groupctl_datos_correo.Controls.Add(this.labelControl7);
            this.groupctl_datos_correo.Controls.Add(this.txtCorreoRem);
            this.groupctl_datos_correo.Controls.Add(this.txtAsunto);
            this.groupctl_datos_correo.Controls.Add(this.labelControl6);
            this.groupctl_datos_correo.Location = new System.Drawing.Point(3, 5);
            this.groupctl_datos_correo.Name = "groupctl_datos_correo";
            this.groupctl_datos_correo.Size = new System.Drawing.Size(646, 546);
            this.groupctl_datos_correo.TabIndex = 12;
            this.groupctl_datos_correo.Text = "Datos del Correo";
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Appearance.Options.UseFont = true;
            this.btnVolver.Appearance.Options.UseTextOptions = true;
            this.btnVolver.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnVolver.ImageOptions.Image = global::VisorFacturas.Properties.Resources.prev_32x32;
            this.btnVolver.Location = new System.Drawing.Point(383, 465);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(115, 61);
            this.btnVolver.TabIndex = 13;
            this.btnVolver.Text = "Volver";
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // progressPanel1
            // 
            this.progressPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressPanel1.AppearanceCaption.Options.UseFont = true;
            this.progressPanel1.AppearanceDescription.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressPanel1.AppearanceDescription.Options.UseFont = true;
            this.progressPanel1.BarAnimationElementThickness = 2;
            this.progressPanel1.Caption = "Enviando Correos...";
            this.progressPanel1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.progressPanel1.Description = "Enviados: 0 de 0. (0%)";
            this.progressPanel1.Location = new System.Drawing.Point(8, 468);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new System.Drawing.Size(234, 58);
            this.progressPanel1.TabIndex = 12;
            this.progressPanel1.Text = "Caption";
            this.progressPanel1.Visible = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(16, 43);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(165, 19);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Nombre del Remitente:";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviar.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Appearance.Options.UseFont = true;
            this.btnEnviar.Appearance.Options.UseTextOptions = true;
            this.btnEnviar.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnEnviar.ImageOptions.Image = global::VisorFacturas.Properties.Resources.send_32x32;
            this.btnEnviar.Location = new System.Drawing.Point(513, 465);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(115, 61);
            this.btnEnviar.TabIndex = 11;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(16, 101);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(156, 19);
            this.labelControl5.TabIndex = 1;
            this.labelControl5.Text = "Correo del Remitente:";
            // 
            // txtCuerpo
            // 
            this.txtCuerpo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCuerpo.Location = new System.Drawing.Point(16, 242);
            this.txtCuerpo.Name = "txtCuerpo";
            this.txtCuerpo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuerpo.Properties.Appearance.Options.UseFont = true;
            this.txtCuerpo.Size = new System.Drawing.Size(612, 217);
            this.txtCuerpo.TabIndex = 7;
            // 
            // txtNombreRem
            // 
            this.txtNombreRem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreRem.EditValue = "qwerty";
            this.txtNombreRem.Location = new System.Drawing.Point(16, 68);
            this.txtNombreRem.Name = "txtNombreRem";
            this.txtNombreRem.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreRem.Properties.Appearance.Options.UseFont = true;
            this.txtNombreRem.Size = new System.Drawing.Size(612, 24);
            this.txtNombreRem.TabIndex = 2;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(16, 217);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(145, 19);
            this.labelControl7.TabIndex = 6;
            this.labelControl7.Text = "Cuerpo del Mensaje:";
            // 
            // txtCorreoRem
            // 
            this.txtCorreoRem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCorreoRem.Location = new System.Drawing.Point(16, 126);
            this.txtCorreoRem.Name = "txtCorreoRem";
            this.txtCorreoRem.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreoRem.Properties.Appearance.Options.UseFont = true;
            this.txtCorreoRem.Size = new System.Drawing.Size(612, 24);
            this.txtCorreoRem.TabIndex = 3;
            // 
            // txtAsunto
            // 
            this.txtAsunto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAsunto.EditValue = "";
            this.txtAsunto.Location = new System.Drawing.Point(16, 184);
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAsunto.Properties.Appearance.Options.UseFont = true;
            this.txtAsunto.Size = new System.Drawing.Size(612, 24);
            this.txtAsunto.TabIndex = 5;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(16, 159);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(56, 19);
            this.labelControl6.TabIndex = 4;
            this.labelControl6.Text = "Asunto:";
            // 
            // dxErrProv
            // 
            this.dxErrProv.ContainerControl = this;
            // 
            // frmFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 616);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "frmFacturas";
            this.Text = "Visor de Facturas";
            this.Load += new System.EventHandler(this.frmFacturas_Load);
            this.Resize += new System.EventHandler(this.frmFacturas_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkSinFormat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkImpresionMasiva.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFacturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFacturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipomoneda_ricmb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipofactura_ricmb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speAnno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtpFacturas.ResumeLayout(false);
            this.xtpCorreos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtcTipoEnvio)).EndInit();
            this.xtcTipoEnvio.ResumeLayout(false);
            this.xtpEnvioMasivo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCorreos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCorreos)).EndInit();
            this.xtpEnvioIndividual.ResumeLayout(false);
            this.xtpEnvioIndividual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LstCorreosIndiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnvioIndividual.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupctl_datos_correo)).EndInit();
            this.groupctl_datos_correo.ResumeLayout(false);
            this.groupctl_datos_correo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCuerpo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreRem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorreoRem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAsunto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCorreos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrProv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnSalir;
        private DevExpress.XtraEditors.SimpleButton btnImprimir;
        private DevExpress.XtraGrid.GridControl gcFacturas;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFacturas;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SpinEdit speAnno;
        private DevExpress.XtraEditors.SimpleButton btnFiltrar;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cmbMes;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.BindingSource bsGrid;
        private DevExpress.XtraEditors.CheckEdit chkImpresionMasiva;
        private DevExpress.XtraEditors.CheckEdit chkSinFormat;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtpFacturas;
        private DevExpress.XtraTab.XtraTabPage xtpCorreos;
        private DevExpress.XtraEditors.SimpleButton btnEnviarCorreo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtCorreoRem;
        private DevExpress.XtraEditors.TextEdit txtNombreRem;
        private DevExpress.XtraEditors.MemoEdit txtCuerpo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtAsunto;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton btnEnviar;
        private DevExpress.XtraEditors.GroupControl groupctl_datos_correo;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraGrid.GridControl gcCorreos;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCorreos;
        private System.Windows.Forms.BindingSource bsCorreos;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrProv;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
        private DevExpress.XtraTab.XtraTabControl xtcTipoEnvio;
        private DevExpress.XtraTab.XtraTabPage xtpEnvioMasivo;
        private DevExpress.XtraTab.XtraTabPage xtpEnvioIndividual;
        private DevExpress.XtraEditors.TextEdit txtEnvioIndividual;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.ListBoxControl LstCorreosIndiv;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.SimpleButton btnVolver;
        private DevExpress.XtraGrid.Columns.GridColumn colcli_codig;
        private DevExpress.XtraGrid.Columns.GridColumn colcli_nom;
        private DevExpress.XtraGrid.Columns.GridColumn colord_numero;
        private DevExpress.XtraGrid.Columns.GridColumn colfecha;
        private DevExpress.XtraGrid.Columns.GridColumn colfac_fac_nu;
        private DevExpress.XtraGrid.Columns.GridColumn colfac_tasa;
        private DevExpress.XtraGrid.Columns.GridColumn colfac_amo_do;
        private DevExpress.XtraGrid.Columns.GridColumn colfac_dolcor;
        private DevExpress.XtraGrid.Columns.GridColumn coltipo;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox tipomoneda_ricmb;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox tipofactura_ricmb;
        private System.Windows.Forms.BindingSource bsClientes;
        private DevExpress.XtraGrid.Columns.GridColumn colcli_cod;
        private DevExpress.XtraGrid.Columns.GridColumn colcli_nom1;
        private DevExpress.XtraGrid.Columns.GridColumn colcli_dir;
        private DevExpress.XtraGrid.Columns.GridColumn colcli_email1;
        private DevExpress.XtraGrid.Columns.GridColumn colcli_email2;
        private DevExpress.XtraGrid.Columns.GridColumn colfac_amount;
        private DevExpress.XtraEditors.SimpleButton btnexportar;
    }
}