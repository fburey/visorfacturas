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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFacturas));
            this.mspsmForm = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::DxSAFRHH.inv.forms.frmWaitForm), true, true);
            this.btnGenerarFactEne = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl3 = new DevExpress.XtraLayout.LayoutControl();
            this.txt_Mese = new DevExpress.XtraEditors.TextEdit();
            this.chkEntreMES = new DevExpress.XtraEditors.CheckEdit();
            this.gcFacturas = new DevExpress.XtraGrid.GridControl();
            this.bsGrid = new System.Windows.Forms.BindingSource(this.components);
            this.gvFacturas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colfac_fac_nu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcli_nom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcli_codig = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfechaVence = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colord_numero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfac_tasa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfac_amo_do = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfac_amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfac_dolcor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcli_regimen1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tipomoneda_ricmb = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.tipofactura_ricmb = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.btnFiltrar = new DevExpress.XtraEditors.SimpleButton();
            this.btnSalir = new DevExpress.XtraEditors.SimpleButton();
            this.btnexportar = new DevExpress.XtraEditors.SimpleButton();
            this.btnimprimir_sobres = new DevExpress.XtraEditors.SimpleButton();
            this.btnEnviarCorreo = new DevExpress.XtraEditors.SimpleButton();
            this.chkAviso = new DevExpress.XtraEditors.CheckEdit();
            this.speAnno = new DevExpress.XtraEditors.SpinEdit();
            this.cmbMes = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnImprimir = new DevExpress.XtraEditors.SimpleButton();
            this.chkSinFormat = new DevExpress.XtraEditors.CheckEdit();
            this.chkImpresionMasiva = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem35 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txt_meses = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtpFacturas = new DevExpress.XtraTab.XtraTabPage();
            this.xtpCorreos = new DevExpress.XtraTab.XtraTabPage();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.mlbl_smtp = new DevExpress.XtraEditors.LabelControl();
            this.mrtxt_cuerpoMail = new DevExpress.XtraRichEdit.RichEditControl();
            this.LstCorreosIndiv = new DevExpress.XtraEditors.ListBoxControl();
            this.txtNombreRem = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtEnvioIndividual = new DevExpress.XtraEditors.TextEdit();
            this.mchk_copia_remitente = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.gcCorreos = new DevExpress.XtraGrid.GridControl();
            this.bsClientes = new System.Windows.Forms.BindingSource(this.components);
            this.gvCorreos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colcli_nom1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcli_cod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcli_dir = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcli_email1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcli_email2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcli_regimen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.controlNavigator1 = new DevExpress.XtraEditors.ControlNavigator();
            this.miglForm2424 = new DevExpress.Utils.ImageCollection(this.components);
            this.txtCorreoRem = new DevExpress.XtraEditors.TextEdit();
            this.btnEnviar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtAsunto = new DevExpress.XtraEditors.TextEdit();
            this.btnVolver = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtCuerpo = new DevExpress.XtraEditors.MemoEdit();
            this.txtAdjuntar = new DevExpress.XtraEditors.TextEdit();
            this.btnAdjun = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup12 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup13 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem10 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup14 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.xtcCuerpoMail = new DevExpress.XtraLayout.TabbedControlGroup();
            this.xtpTextoEnriquecido = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem33 = new DevExpress.XtraLayout.LayoutControlItem();
            this.xtpTextoNormal = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem34 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup15 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.xtcTipoEnvio = new DevExpress.XtraLayout.TabbedControlGroup();
            this.xtpEnvioMasivo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem9 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.xtpEnvioIndividual = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem31 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem32 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.xtpCapturaErr = new DevExpress.XtraTab.XtraTabPage();
            this.btnimprimir_err = new DevExpress.XtraEditors.SimpleButton();
            this.btnVolver2 = new DevExpress.XtraEditors.SimpleButton();
            this.mcapterr_gc = new DevExpress.XtraGrid.GridControl();
            this.bsClientes_err = new System.Windows.Forms.BindingSource(this.components);
            this.mcapterr_gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.mcapterr_gv_colcli_nom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mcapterr_gv_colcli_email1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mcapterr_gv_colcli_email2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mcapterr_gv_colcli_dir = new DevExpress.XtraGrid.Columns.GridColumn();
            this.memoEdit2 = new DevExpress.XtraEditors.MemoEdit();
            this.bsCorreos = new System.Windows.Forms.BindingSource(this.components);
            this.dxErrProv = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.bsVerificacion = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).BeginInit();
            this.layoutControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Mese.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEntreMES.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFacturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFacturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipomoneda_ricmb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipofactura_ricmb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAviso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speAnno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSinFormat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkImpresionMasiva.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_meses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtpFacturas.SuspendLayout();
            this.xtpCorreos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LstCorreosIndiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreRem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnvioIndividual.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mchk_copia_remitente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCorreos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCorreos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.miglForm2424)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorreoRem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAsunto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCuerpo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdjuntar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtcCuerpoMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtpTextoEnriquecido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtpTextoNormal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtcTipoEnvio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtpEnvioMasivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtpEnvioIndividual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            this.xtpCapturaErr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mcapterr_gc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClientes_err)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mcapterr_gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCorreos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrProv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVerificacion)).BeginInit();
            this.SuspendLayout();
            // 
            // mspsmForm
            // 
            this.mspsmForm.ClosingDelay = 500;
            // 
            // btnGenerarFactEne
            // 
            this.btnGenerarFactEne.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarFactEne.Appearance.Options.UseFont = true;
            this.btnGenerarFactEne.Appearance.Options.UseTextOptions = true;
            this.btnGenerarFactEne.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnGenerarFactEne.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGenerarFactEne.ImageOptions.SvgImage")));
            this.btnGenerarFactEne.Location = new System.Drawing.Point(2, 644);
            this.btnGenerarFactEne.Name = "btnGenerarFactEne";
            this.btnGenerarFactEne.Size = new System.Drawing.Size(207, 36);
            this.btnGenerarFactEne.StyleController = this.layoutControl3;
            this.btnGenerarFactEne.TabIndex = 14;
            this.btnGenerarFactEne.Text = "Generar Facturas Enero";
            this.btnGenerarFactEne.Visible = false;
            this.btnGenerarFactEne.Click += new System.EventHandler(this.btnGenerarFactEne_Click);
            // 
            // layoutControl3
            // 
            this.layoutControl3.Controls.Add(this.txt_Mese);
            this.layoutControl3.Controls.Add(this.chkEntreMES);
            this.layoutControl3.Controls.Add(this.gcFacturas);
            this.layoutControl3.Controls.Add(this.btnGenerarFactEne);
            this.layoutControl3.Controls.Add(this.btnFiltrar);
            this.layoutControl3.Controls.Add(this.btnSalir);
            this.layoutControl3.Controls.Add(this.btnexportar);
            this.layoutControl3.Controls.Add(this.btnimprimir_sobres);
            this.layoutControl3.Controls.Add(this.btnEnviarCorreo);
            this.layoutControl3.Controls.Add(this.chkAviso);
            this.layoutControl3.Controls.Add(this.speAnno);
            this.layoutControl3.Controls.Add(this.cmbMes);
            this.layoutControl3.Controls.Add(this.btnImprimir);
            this.layoutControl3.Controls.Add(this.chkSinFormat);
            this.layoutControl3.Controls.Add(this.chkImpresionMasiva);
            this.layoutControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl3.Location = new System.Drawing.Point(0, 0);
            this.layoutControl3.Name = "layoutControl3";
            this.layoutControl3.Root = this.layoutControlGroup2;
            this.layoutControl3.Size = new System.Drawing.Size(972, 682);
            this.layoutControl3.TabIndex = 12;
            this.layoutControl3.Text = "layoutControl3";
            // 
            // txt_Mese
            // 
            this.txt_Mese.Location = new System.Drawing.Point(14, 299);
            this.txt_Mese.Name = "txt_Mese";
            this.txt_Mese.Size = new System.Drawing.Size(183, 20);
            this.txt_Mese.StyleController = this.layoutControl3;
            this.txt_Mese.TabIndex = 16;
            // 
            // chkEntreMES
            // 
            this.chkEntreMES.Enabled = false;
            this.chkEntreMES.Location = new System.Drawing.Point(14, 272);
            this.chkEntreMES.Name = "chkEntreMES";
            this.chkEntreMES.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEntreMES.Properties.Appearance.Options.UseFont = true;
            this.chkEntreMES.Properties.Caption = "Varios Meses";
            this.chkEntreMES.Size = new System.Drawing.Size(183, 23);
            this.chkEntreMES.StyleController = this.layoutControl3;
            this.chkEntreMES.TabIndex = 15;
            this.chkEntreMES.CheckedChanged += new System.EventHandler(this.chkEntreMES_CheckedChanged);
            // 
            // gcFacturas
            // 
            this.gcFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcFacturas.DataSource = this.bsGrid;
            this.gcFacturas.Location = new System.Drawing.Point(213, 2);
            this.gcFacturas.MainView = this.gvFacturas;
            this.gcFacturas.Name = "gcFacturas";
            this.gcFacturas.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.tipomoneda_ricmb,
            this.tipofactura_ricmb});
            this.gcFacturas.Size = new System.Drawing.Size(757, 678);
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
            this.gvFacturas.Appearance.FooterPanel.BackColor = System.Drawing.Color.Moccasin;
            this.gvFacturas.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.Moccasin;
            this.gvFacturas.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvFacturas.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Blue;
            this.gvFacturas.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gvFacturas.Appearance.FooterPanel.Options.UseFont = true;
            this.gvFacturas.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gvFacturas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colfac_fac_nu,
            this.colcli_nom,
            this.colcli_codig,
            this.colfecha,
            this.colfechaVence,
            this.colord_numero,
            this.colfac_tasa,
            this.colfac_amo_do,
            this.colfac_amount,
            this.colfac_dolcor,
            this.colcli_regimen1,
            this.coltipo});
            this.gvFacturas.GridControl = this.gcFacturas;
            this.gvFacturas.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "cli_nom", null, "(Cliente: Recuento={0})")});
            this.gvFacturas.Name = "gvFacturas";
            this.gvFacturas.OptionsBehavior.Editable = false;
            this.gvFacturas.OptionsFind.AllowFindPanel = false;
            this.gvFacturas.OptionsView.ColumnAutoWidth = false;
            this.gvFacturas.OptionsView.ShowAutoFilterRow = true;
            this.gvFacturas.OptionsView.ShowFooter = true;
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
            // colfechaVence
            // 
            this.colfechaVence.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colfechaVence.AppearanceHeader.Options.UseFont = true;
            this.colfechaVence.AppearanceHeader.Options.UseTextOptions = true;
            this.colfechaVence.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colfechaVence.Caption = "Fecha Ven.";
            this.colfechaVence.FieldName = "fechaVence";
            this.colfechaVence.Name = "colfechaVence";
            this.colfechaVence.Width = 100;
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
            this.colfac_amo_do.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "fac_amo_do", "U$ {0:#,0.00}")});
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
            this.colfac_amount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "fac_amount", "C$ {0:#,0.00}")});
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
            // colcli_regimen1
            // 
            this.colcli_regimen1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colcli_regimen1.AppearanceHeader.Options.UseFont = true;
            this.colcli_regimen1.AppearanceHeader.Options.UseTextOptions = true;
            this.colcli_regimen1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colcli_regimen1.Caption = "Régimen";
            this.colcli_regimen1.FieldName = "cli_regimen";
            this.colcli_regimen1.Name = "colcli_regimen1";
            this.colcli_regimen1.Visible = true;
            this.colcli_regimen1.VisibleIndex = 9;
            this.colcli_regimen1.Width = 115;
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
            // btnFiltrar
            // 
            this.btnFiltrar.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.Appearance.Options.UseFont = true;
            this.btnFiltrar.Appearance.Options.UseTextOptions = true;
            this.btnFiltrar.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnFiltrar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltrar.ImageOptions.Image")));
            this.btnFiltrar.Location = new System.Drawing.Point(73, 105);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(129, 42);
            this.btnFiltrar.StyleController = this.layoutControl3;
            this.btnFiltrar.TabIndex = 3;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Appearance.Options.UseFont = true;
            this.btnSalir.Appearance.Options.UseTextOptions = true;
            this.btnSalir.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnSalir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.ImageOptions.Image")));
            this.btnSalir.Location = new System.Drawing.Point(14, 528);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(183, 36);
            this.btnSalir.StyleController = this.layoutControl3;
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnexportar
            // 
            this.btnexportar.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexportar.Appearance.Options.UseFont = true;
            this.btnexportar.Appearance.Options.UseTextOptions = true;
            this.btnexportar.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnexportar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnexportar.ImageOptions.Image")));
            this.btnexportar.Location = new System.Drawing.Point(14, 488);
            this.btnexportar.Name = "btnexportar";
            this.btnexportar.Size = new System.Drawing.Size(183, 36);
            this.btnexportar.StyleController = this.layoutControl3;
            this.btnexportar.TabIndex = 11;
            this.btnexportar.Text = "Exportar";
            this.btnexportar.Click += new System.EventHandler(this.btnexportar_Click);
            // 
            // btnimprimir_sobres
            // 
            this.btnimprimir_sobres.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnimprimir_sobres.Appearance.Options.UseFont = true;
            this.btnimprimir_sobres.Appearance.Options.UseTextOptions = true;
            this.btnimprimir_sobres.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnimprimir_sobres.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnimprimir_sobres.ImageOptions.Image")));
            this.btnimprimir_sobres.Location = new System.Drawing.Point(14, 408);
            this.btnimprimir_sobres.Name = "btnimprimir_sobres";
            this.btnimprimir_sobres.Size = new System.Drawing.Size(183, 36);
            this.btnimprimir_sobres.StyleController = this.layoutControl3;
            this.btnimprimir_sobres.TabIndex = 12;
            this.btnimprimir_sobres.Text = "Visualizar Sobres";
            this.btnimprimir_sobres.Click += new System.EventHandler(this.btnimprimir_sobres_Click);
            // 
            // btnEnviarCorreo
            // 
            this.btnEnviarCorreo.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviarCorreo.Appearance.Options.UseFont = true;
            this.btnEnviarCorreo.Appearance.Options.UseTextOptions = true;
            this.btnEnviarCorreo.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnEnviarCorreo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviarCorreo.ImageOptions.Image")));
            this.btnEnviarCorreo.Location = new System.Drawing.Point(14, 448);
            this.btnEnviarCorreo.Name = "btnEnviarCorreo";
            this.btnEnviarCorreo.Size = new System.Drawing.Size(183, 36);
            this.btnEnviarCorreo.StyleController = this.layoutControl3;
            this.btnEnviarCorreo.TabIndex = 10;
            this.btnEnviarCorreo.Text = "Enviar Correo";
            this.btnEnviarCorreo.Click += new System.EventHandler(this.btnEnviarCorreo_Click);
            // 
            // chkAviso
            // 
            this.chkAviso.Location = new System.Drawing.Point(14, 245);
            this.chkAviso.Name = "chkAviso";
            this.chkAviso.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAviso.Properties.Appearance.Options.UseFont = true;
            this.chkAviso.Properties.Caption = "Enviar aviso";
            this.chkAviso.Size = new System.Drawing.Size(183, 23);
            this.chkAviso.StyleController = this.layoutControl3;
            this.chkAviso.TabIndex = 13;
            // 
            // speAnno
            // 
            this.speAnno.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.speAnno.Location = new System.Drawing.Point(84, 35);
            this.speAnno.Name = "speAnno";
            this.speAnno.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.speAnno.Properties.Appearance.Options.UseFont = true;
            this.speAnno.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.speAnno.Properties.IsFloatValue = false;
            this.speAnno.Properties.MaskSettings.Set("mask", "d");
            this.speAnno.Properties.UseMaskAsDisplayFormat = true;
            this.speAnno.Size = new System.Drawing.Size(118, 26);
            this.speAnno.StyleController = this.layoutControl3;
            this.speAnno.TabIndex = 6;
            // 
            // cmbMes
            // 
            this.cmbMes.Location = new System.Drawing.Point(84, 72);
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
            this.cmbMes.Size = new System.Drawing.Size(118, 26);
            this.cmbMes.StyleController = this.layoutControl3;
            this.cmbMes.TabIndex = 5;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Appearance.Options.UseFont = true;
            this.btnImprimir.Appearance.Options.UseTextOptions = true;
            this.btnImprimir.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnImprimir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.ImageOptions.Image")));
            this.btnImprimir.Location = new System.Drawing.Point(14, 368);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(183, 36);
            this.btnImprimir.StyleController = this.layoutControl3;
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "Visualizar Facturas";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // chkSinFormat
            // 
            this.chkSinFormat.Location = new System.Drawing.Point(14, 218);
            this.chkSinFormat.Name = "chkSinFormat";
            this.chkSinFormat.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSinFormat.Properties.Appearance.Options.UseFont = true;
            this.chkSinFormat.Properties.Caption = "Sin Formato";
            this.chkSinFormat.Size = new System.Drawing.Size(183, 23);
            this.chkSinFormat.StyleController = this.layoutControl3;
            this.chkSinFormat.TabIndex = 9;
            // 
            // chkImpresionMasiva
            // 
            this.chkImpresionMasiva.Location = new System.Drawing.Point(14, 191);
            this.chkImpresionMasiva.Name = "chkImpresionMasiva";
            this.chkImpresionMasiva.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkImpresionMasiva.Properties.Appearance.Options.UseFont = true;
            this.chkImpresionMasiva.Properties.Caption = "Impresión Masiva";
            this.chkImpresionMasiva.Size = new System.Drawing.Size(183, 23);
            this.chkImpresionMasiva.StyleController = this.layoutControl3;
            this.chkImpresionMasiva.TabIndex = 6;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem28,
            this.layoutControlItem29,
            this.layoutControlGroup3,
            this.layoutControlGroup4,
            this.layoutControlGroup5,
            this.emptySpaceItem4});
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Size = new System.Drawing.Size(972, 682);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem28
            // 
            this.layoutControlItem28.Control = this.btnGenerarFactEne;
            this.layoutControlItem28.Location = new System.Drawing.Point(0, 642);
            this.layoutControlItem28.Name = "layoutControlItem28";
            this.layoutControlItem28.Size = new System.Drawing.Size(211, 40);
            this.layoutControlItem28.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem28.TextVisible = false;
            this.layoutControlItem28.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.Control = this.gcFacturas;
            this.layoutControlItem29.Location = new System.Drawing.Point(211, 0);
            this.layoutControlItem29.Name = "layoutControlItem29";
            this.layoutControlItem29.Size = new System.Drawing.Size(761, 682);
            this.layoutControlItem29.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem29.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem19,
            this.layoutControlItem18,
            this.layoutControlItem17,
            this.emptySpaceItem1});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup3.Size = new System.Drawing.Size(211, 156);
            this.layoutControlGroup3.Text = "Filtros";
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.btnFiltrar;
            this.layoutControlItem19.Location = new System.Drawing.Point(64, 75);
            this.layoutControlItem19.MaxSize = new System.Drawing.Size(133, 46);
            this.layoutControlItem19.MinSize = new System.Drawing.Size(133, 46);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(133, 46);
            this.layoutControlItem19.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem19.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem19.TextVisible = false;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem18.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem18.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem18.Control = this.cmbMes;
            this.layoutControlItem18.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem18.MaxSize = new System.Drawing.Size(0, 40);
            this.layoutControlItem18.MinSize = new System.Drawing.Size(101, 30);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(197, 35);
            this.layoutControlItem18.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem18.Spacing = new DevExpress.XtraLayout.Utils.Padding(20, 0, 0, 0);
            this.layoutControlItem18.Text = "Mes:";
            this.layoutControlItem18.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem18.TextSize = new System.Drawing.Size(50, 20);
            this.layoutControlItem18.TextToControlDistance = 5;
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.layoutControlItem17.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem17.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem17.Control = this.speAnno;
            this.layoutControlItem17.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem17.MaxSize = new System.Drawing.Size(197, 40);
            this.layoutControlItem17.MinSize = new System.Drawing.Size(197, 40);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(197, 40);
            this.layoutControlItem17.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem17.Spacing = new DevExpress.XtraLayout.Utils.Padding(20, 0, 0, 0);
            this.layoutControlItem17.Text = "Año:";
            this.layoutControlItem17.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem17.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem17.TextSize = new System.Drawing.Size(50, 20);
            this.layoutControlItem17.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 75);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(64, 46);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem20,
            this.layoutControlItem21,
            this.layoutControlItem22,
            this.layoutControlItem35,
            this.txt_meses});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 156);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(211, 177);
            this.layoutControlGroup4.Text = "Indicadores";
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.chkImpresionMasiva;
            this.layoutControlItem20.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(187, 27);
            this.layoutControlItem20.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem20.TextVisible = false;
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.chkSinFormat;
            this.layoutControlItem21.Location = new System.Drawing.Point(0, 27);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(187, 27);
            this.layoutControlItem21.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem21.TextVisible = false;
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.chkAviso;
            this.layoutControlItem22.Location = new System.Drawing.Point(0, 54);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(187, 27);
            this.layoutControlItem22.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem22.TextVisible = false;
            // 
            // layoutControlItem35
            // 
            this.layoutControlItem35.Control = this.chkEntreMES;
            this.layoutControlItem35.Location = new System.Drawing.Point(0, 81);
            this.layoutControlItem35.Name = "layoutControlItem35";
            this.layoutControlItem35.Size = new System.Drawing.Size(187, 27);
            this.layoutControlItem35.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem35.TextVisible = false;
            // 
            // txt_meses
            // 
            this.txt_meses.Control = this.txt_Mese;
            this.txt_meses.Location = new System.Drawing.Point(0, 108);
            this.txt_meses.Name = "txt_meses";
            this.txt_meses.Size = new System.Drawing.Size(187, 24);
            this.txt_meses.TextSize = new System.Drawing.Size(0, 0);
            this.txt_meses.TextVisible = false;
            this.txt_meses.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem23,
            this.layoutControlItem24,
            this.layoutControlItem25,
            this.layoutControlItem26,
            this.layoutControlItem27});
            this.layoutControlGroup5.Location = new System.Drawing.Point(0, 333);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Size = new System.Drawing.Size(211, 245);
            this.layoutControlGroup5.Text = "Acciones";
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.btnImprimir;
            this.layoutControlItem23.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem23.MaxSize = new System.Drawing.Size(0, 40);
            this.layoutControlItem23.MinSize = new System.Drawing.Size(176, 40);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(187, 40);
            this.layoutControlItem23.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem23.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem23.TextVisible = false;
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.Control = this.btnimprimir_sobres;
            this.layoutControlItem24.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new System.Drawing.Size(187, 40);
            this.layoutControlItem24.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem24.TextVisible = false;
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.Control = this.btnEnviarCorreo;
            this.layoutControlItem25.Location = new System.Drawing.Point(0, 80);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(187, 40);
            this.layoutControlItem25.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem25.TextVisible = false;
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.Control = this.btnexportar;
            this.layoutControlItem26.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new System.Drawing.Size(187, 40);
            this.layoutControlItem26.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem26.TextVisible = false;
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.Control = this.btnSalir;
            this.layoutControlItem27.Location = new System.Drawing.Point(0, 160);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(187, 40);
            this.layoutControlItem27.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem27.TextVisible = false;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 578);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(211, 64);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
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
            this.xtraTabControl1.Size = new System.Drawing.Size(974, 719);
            this.xtraTabControl1.TabIndex = 12;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtpFacturas,
            this.xtpCorreos,
            this.xtpCapturaErr});
            // 
            // xtpFacturas
            // 
            this.xtpFacturas.Controls.Add(this.layoutControl3);
            this.xtpFacturas.Name = "xtpFacturas";
            this.xtpFacturas.Size = new System.Drawing.Size(972, 682);
            this.xtpFacturas.Text = "Facturas";
            // 
            // xtpCorreos
            // 
            this.xtpCorreos.Controls.Add(this.layoutControl1);
            this.xtpCorreos.Name = "xtpCorreos";
            this.xtpCorreos.Size = new System.Drawing.Size(971, 677);
            this.xtpCorreos.Text = "Correos";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.mlbl_smtp);
            this.layoutControl1.Controls.Add(this.mrtxt_cuerpoMail);
            this.layoutControl1.Controls.Add(this.LstCorreosIndiv);
            this.layoutControl1.Controls.Add(this.txtNombreRem);
            this.layoutControl1.Controls.Add(this.labelControl9);
            this.layoutControl1.Controls.Add(this.labelControl4);
            this.layoutControl1.Controls.Add(this.txtEnvioIndividual);
            this.layoutControl1.Controls.Add(this.mchk_copia_remitente);
            this.layoutControl1.Controls.Add(this.labelControl8);
            this.layoutControl1.Controls.Add(this.labelControl5);
            this.layoutControl1.Controls.Add(this.gcCorreos);
            this.layoutControl1.Controls.Add(this.controlNavigator1);
            this.layoutControl1.Controls.Add(this.txtCorreoRem);
            this.layoutControl1.Controls.Add(this.btnEnviar);
            this.layoutControl1.Controls.Add(this.labelControl6);
            this.layoutControl1.Controls.Add(this.txtAsunto);
            this.layoutControl1.Controls.Add(this.btnVolver);
            this.layoutControl1.Controls.Add(this.labelControl1);
            this.layoutControl1.Controls.Add(this.txtCuerpo);
            this.layoutControl1.Controls.Add(this.txtAdjuntar);
            this.layoutControl1.Controls.Add(this.btnAdjun);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(777, 542);
            this.layoutControl1.TabIndex = 13;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // mlbl_smtp
            // 
            this.mlbl_smtp.Location = new System.Drawing.Point(12, 391);
            this.mlbl_smtp.Name = "mlbl_smtp";
            this.mlbl_smtp.Size = new System.Drawing.Size(33, 13);
            this.mlbl_smtp.StyleController = this.layoutControl1;
            this.mlbl_smtp.TabIndex = 19;
            this.mlbl_smtp.Text = "SMTP: ";
            // 
            // mrtxt_cuerpoMail
            // 
            this.mrtxt_cuerpoMail.Location = new System.Drawing.Point(21, 324);
            this.mrtxt_cuerpoMail.Name = "mrtxt_cuerpoMail";
            this.mrtxt_cuerpoMail.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            this.mrtxt_cuerpoMail.Size = new System.Drawing.Size(314, 124);
            this.mrtxt_cuerpoMail.TabIndex = 18;
            this.mrtxt_cuerpoMail.Text = "richEditControl1";
            this.mrtxt_cuerpoMail.DocumentLoaded += new System.EventHandler(this.mrtxt_cuerpoMail_DocumentLoaded);
            // 
            // LstCorreosIndiv
            // 
            this.LstCorreosIndiv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LstCorreosIndiv.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.LstCorreosIndiv.Appearance.Options.UseFont = true;
            this.LstCorreosIndiv.Cursor = System.Windows.Forms.Cursors.Default;
            this.LstCorreosIndiv.Location = new System.Drawing.Point(462, 137);
            this.LstCorreosIndiv.Name = "LstCorreosIndiv";
            this.LstCorreosIndiv.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.LstCorreosIndiv.Size = new System.Drawing.Size(238, 185);
            this.LstCorreosIndiv.StyleController = this.layoutControl1;
            this.LstCorreosIndiv.TabIndex = 5;
            // 
            // txtNombreRem
            // 
            this.txtNombreRem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreRem.EditValue = "qwerty";
            this.txtNombreRem.Location = new System.Drawing.Point(18, 87);
            this.txtNombreRem.Name = "txtNombreRem";
            this.txtNombreRem.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreRem.Properties.Appearance.Options.UseFont = true;
            this.txtNombreRem.Size = new System.Drawing.Size(399, 24);
            this.txtNombreRem.StyleController = this.layoutControl1;
            this.txtNombreRem.TabIndex = 2;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(462, 114);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(238, 15);
            this.labelControl9.StyleController = this.layoutControl1;
            this.labelControl9.TabIndex = 4;
            this.labelControl9.Text = "Correos Electrónicos:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(18, 60);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(236, 23);
            this.labelControl4.StyleController = this.layoutControl1;
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Nombre del Remitente:";
            // 
            // txtEnvioIndividual
            // 
            this.txtEnvioIndividual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnvioIndividual.Location = new System.Drawing.Point(462, 84);
            this.txtEnvioIndividual.Name = "txtEnvioIndividual";
            this.txtEnvioIndividual.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnvioIndividual.Properties.Appearance.Options.UseFont = true;
            this.txtEnvioIndividual.Properties.ReadOnly = true;
            this.txtEnvioIndividual.Size = new System.Drawing.Size(238, 21);
            this.txtEnvioIndividual.StyleController = this.layoutControl1;
            this.txtEnvioIndividual.TabIndex = 3;
            // 
            // mchk_copia_remitente
            // 
            this.mchk_copia_remitente.Location = new System.Drawing.Point(258, 60);
            this.mchk_copia_remitente.Name = "mchk_copia_remitente";
            this.mchk_copia_remitente.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mchk_copia_remitente.Properties.Appearance.Options.UseFont = true;
            this.mchk_copia_remitente.Properties.Caption = "C.C. Remitente";
            this.mchk_copia_remitente.Size = new System.Drawing.Size(159, 23);
            this.mchk_copia_remitente.StyleController = this.layoutControl1;
            this.mchk_copia_remitente.TabIndex = 17;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(462, 61);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(238, 15);
            this.labelControl8.StyleController = this.layoutControl1;
            this.labelControl8.TabIndex = 1;
            this.labelControl8.Text = "Envío de Correo Electrónico a:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(18, 115);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(399, 19);
            this.labelControl5.StyleController = this.layoutControl1;
            this.labelControl5.TabIndex = 1;
            this.labelControl5.Text = "Correo del Remitente:";
            // 
            // gcCorreos
            // 
            this.gcCorreos.DataSource = this.bsClientes;
            this.gcCorreos.Location = new System.Drawing.Point(462, 97);
            this.gcCorreos.MainView = this.gvCorreos;
            this.gcCorreos.Name = "gcCorreos";
            this.gcCorreos.Size = new System.Drawing.Size(238, 342);
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
            this.colcli_email2,
            this.colcli_regimen});
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
            this.colcli_nom1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colcli_nom1.AppearanceHeader.Options.UseFont = true;
            this.colcli_nom1.AppearanceHeader.Options.UseTextOptions = true;
            this.colcli_nom1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
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
            this.colcli_cod.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colcli_cod.AppearanceHeader.Options.UseFont = true;
            this.colcli_cod.AppearanceHeader.Options.UseTextOptions = true;
            this.colcli_cod.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colcli_cod.Caption = "Código";
            this.colcli_cod.FieldName = "cli_cod";
            this.colcli_cod.Name = "colcli_cod";
            this.colcli_cod.Visible = true;
            this.colcli_cod.VisibleIndex = 1;
            this.colcli_cod.Width = 140;
            // 
            // colcli_dir
            // 
            this.colcli_dir.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colcli_dir.AppearanceHeader.Options.UseFont = true;
            this.colcli_dir.AppearanceHeader.Options.UseTextOptions = true;
            this.colcli_dir.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colcli_dir.Caption = "Dirección";
            this.colcli_dir.FieldName = "cli_dir";
            this.colcli_dir.Name = "colcli_dir";
            // 
            // colcli_email1
            // 
            this.colcli_email1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colcli_email1.AppearanceHeader.Options.UseFont = true;
            this.colcli_email1.AppearanceHeader.Options.UseTextOptions = true;
            this.colcli_email1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colcli_email1.Caption = "Correo N°1";
            this.colcli_email1.FieldName = "cli_email1";
            this.colcli_email1.Name = "colcli_email1";
            this.colcli_email1.Visible = true;
            this.colcli_email1.VisibleIndex = 2;
            this.colcli_email1.Width = 180;
            // 
            // colcli_email2
            // 
            this.colcli_email2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colcli_email2.AppearanceHeader.Options.UseFont = true;
            this.colcli_email2.AppearanceHeader.Options.UseTextOptions = true;
            this.colcli_email2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colcli_email2.Caption = "Correo N°2";
            this.colcli_email2.FieldName = "cli_email2";
            this.colcli_email2.Name = "colcli_email2";
            this.colcli_email2.Visible = true;
            this.colcli_email2.VisibleIndex = 3;
            this.colcli_email2.Width = 180;
            // 
            // colcli_regimen
            // 
            this.colcli_regimen.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colcli_regimen.AppearanceHeader.Options.UseFont = true;
            this.colcli_regimen.AppearanceHeader.Options.UseTextOptions = true;
            this.colcli_regimen.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colcli_regimen.Caption = "Regimen";
            this.colcli_regimen.FieldName = "cli_regimen";
            this.colcli_regimen.Name = "colcli_regimen";
            this.colcli_regimen.Visible = true;
            this.colcli_regimen.VisibleIndex = 4;
            this.colcli_regimen.Width = 117;
            // 
            // controlNavigator1
            // 
            this.controlNavigator1.Buttons.Append.Visible = false;
            this.controlNavigator1.Buttons.CancelEdit.Visible = false;
            this.controlNavigator1.Buttons.Edit.Visible = false;
            this.controlNavigator1.Buttons.EndEdit.Visible = false;
            this.controlNavigator1.Buttons.First.ImageIndex = 3;
            this.controlNavigator1.Buttons.ImageList = this.miglForm2424;
            this.controlNavigator1.Buttons.Last.ImageIndex = 2;
            this.controlNavigator1.Buttons.Next.ImageIndex = 1;
            this.controlNavigator1.Buttons.NextPage.Visible = false;
            this.controlNavigator1.Buttons.Prev.ImageIndex = 0;
            this.controlNavigator1.Buttons.PrevPage.Visible = false;
            this.controlNavigator1.Buttons.Remove.Visible = false;
            this.controlNavigator1.Location = new System.Drawing.Point(462, 61);
            this.controlNavigator1.Name = "controlNavigator1";
            this.controlNavigator1.NavigatableControl = this.gcCorreos;
            this.controlNavigator1.Size = new System.Drawing.Size(218, 32);
            this.controlNavigator1.StyleController = this.layoutControl1;
            this.controlNavigator1.TabIndex = 12;
            this.controlNavigator1.Text = "controlNavigator1";
            this.controlNavigator1.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
            // 
            // miglForm2424
            // 
            this.miglForm2424.ImageSize = new System.Drawing.Size(24, 24);
            this.miglForm2424.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("miglForm2424.ImageStream")));
            this.miglForm2424.InsertImage(global::VisorFacturas.Properties.Resources.button_blue_arrow_left_24x24, "button_blue_arrow_left_24x24", typeof(global::VisorFacturas.Properties.Resources), 0);
            this.miglForm2424.Images.SetKeyName(0, "button_blue_arrow_left_24x24");
            this.miglForm2424.InsertImage(global::VisorFacturas.Properties.Resources.button_blue_arrow_right_24x24, "button_blue_arrow_right_24x24", typeof(global::VisorFacturas.Properties.Resources), 1);
            this.miglForm2424.Images.SetKeyName(1, "button_blue_arrow_right_24x24");
            this.miglForm2424.InsertImage(global::VisorFacturas.Properties.Resources.button_blue_goto_next_24x24, "button_blue_goto_next_24x24", typeof(global::VisorFacturas.Properties.Resources), 2);
            this.miglForm2424.Images.SetKeyName(2, "button_blue_goto_next_24x24");
            this.miglForm2424.InsertImage(global::VisorFacturas.Properties.Resources.button_blue_goto_previous_24x24, "button_blue_goto_previous_24x24", typeof(global::VisorFacturas.Properties.Resources), 3);
            this.miglForm2424.Images.SetKeyName(3, "button_blue_goto_previous_24x24");
            this.miglForm2424.InsertImage(global::VisorFacturas.Properties.Resources.button_circle_blue_first_24x24, "button_circle_blue_first_24x24", typeof(global::VisorFacturas.Properties.Resources), 4);
            this.miglForm2424.Images.SetKeyName(4, "button_circle_blue_first_24x24");
            this.miglForm2424.InsertImage(global::VisorFacturas.Properties.Resources.button_circle_blue_last_24x24, "button_circle_blue_last_24x24", typeof(global::VisorFacturas.Properties.Resources), 5);
            this.miglForm2424.Images.SetKeyName(5, "button_circle_blue_last_24x24");
            this.miglForm2424.InsertImage(global::VisorFacturas.Properties.Resources.button_circle_blue_left_24x24, "button_circle_blue_left_24x24", typeof(global::VisorFacturas.Properties.Resources), 6);
            this.miglForm2424.Images.SetKeyName(6, "button_circle_blue_left_24x24");
            this.miglForm2424.InsertImage(global::VisorFacturas.Properties.Resources.button_circle_blue_right_24x24, "button_circle_blue_right_24x24", typeof(global::VisorFacturas.Properties.Resources), 7);
            this.miglForm2424.Images.SetKeyName(7, "button_circle_blue_right_24x24");
            this.miglForm2424.InsertImage(global::VisorFacturas.Properties.Resources.print_24x24, "print_24x24", typeof(global::VisorFacturas.Properties.Resources), 8);
            this.miglForm2424.Images.SetKeyName(8, "print_24x24");
            this.miglForm2424.InsertImage(global::VisorFacturas.Properties.Resources.TraFin_btn, "TraFin_btn", typeof(global::VisorFacturas.Properties.Resources), 9);
            this.miglForm2424.Images.SetKeyName(9, "TraFin_btn");
            this.miglForm2424.Images.SetKeyName(10, "print_masivo.png");
            this.miglForm2424.Images.SetKeyName(11, "print_masivo32_1.png");
            this.miglForm2424.Images.SetKeyName(12, "print_masivo32_2.png");
            this.miglForm2424.Images.SetKeyName(13, "TraExt_btn.png");
            // 
            // txtCorreoRem
            // 
            this.txtCorreoRem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCorreoRem.Location = new System.Drawing.Point(18, 138);
            this.txtCorreoRem.Name = "txtCorreoRem";
            this.txtCorreoRem.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreoRem.Properties.Appearance.Options.UseFont = true;
            this.txtCorreoRem.Size = new System.Drawing.Size(399, 24);
            this.txtCorreoRem.StyleController = this.layoutControl1;
            this.txtCorreoRem.TabIndex = 3;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviar.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Appearance.Options.UseFont = true;
            this.btnEnviar.Appearance.Options.UseTextOptions = true;
            this.btnEnviar.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnEnviar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviar.ImageOptions.Image")));
            this.btnEnviar.Location = new System.Drawing.Point(168, 391);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(103, 38);
            this.btnEnviar.StyleController = this.layoutControl1;
            this.btnEnviar.TabIndex = 11;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(18, 166);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(399, 19);
            this.labelControl6.StyleController = this.layoutControl1;
            this.labelControl6.TabIndex = 4;
            this.labelControl6.Text = "Asunto:";
            // 
            // txtAsunto
            // 
            this.txtAsunto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAsunto.EditValue = "";
            this.txtAsunto.Location = new System.Drawing.Point(18, 189);
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAsunto.Properties.Appearance.Options.UseFont = true;
            this.txtAsunto.Size = new System.Drawing.Size(399, 24);
            this.txtAsunto.StyleController = this.layoutControl1;
            this.txtAsunto.TabIndex = 5;
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolver.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Appearance.Options.UseFont = true;
            this.btnVolver.Appearance.Options.UseTextOptions = true;
            this.btnVolver.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnVolver.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnVolver.ImageOptions.Image")));
            this.btnVolver.Location = new System.Drawing.Point(254, 391);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(103, 38);
            this.btnVolver.StyleController = this.layoutControl1;
            this.btnVolver.TabIndex = 13;
            this.btnVolver.Text = "Volver";
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(18, 217);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(93, 22);
            this.labelControl1.StyleController = this.layoutControl1;
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Adjuntar:";
            // 
            // txtCuerpo
            // 
            this.txtCuerpo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCuerpo.Location = new System.Drawing.Point(21, 324);
            this.txtCuerpo.Name = "txtCuerpo";
            this.txtCuerpo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuerpo.Properties.Appearance.Options.UseFont = true;
            this.txtCuerpo.Size = new System.Drawing.Size(314, 124);
            this.txtCuerpo.StyleController = this.layoutControl1;
            this.txtCuerpo.TabIndex = 7;
            // 
            // txtAdjuntar
            // 
            this.txtAdjuntar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdjuntar.EditValue = "";
            this.txtAdjuntar.Enabled = false;
            this.txtAdjuntar.Location = new System.Drawing.Point(18, 243);
            this.txtAdjuntar.Name = "txtAdjuntar";
            this.txtAdjuntar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdjuntar.Properties.Appearance.Options.UseFont = true;
            this.txtAdjuntar.Size = new System.Drawing.Size(399, 24);
            this.txtAdjuntar.StyleController = this.layoutControl1;
            this.txtAdjuntar.TabIndex = 15;
            // 
            // btnAdjun
            // 
            this.btnAdjun.Location = new System.Drawing.Point(115, 217);
            this.btnAdjun.Name = "btnAdjun";
            this.btnAdjun.Size = new System.Drawing.Size(86, 22);
            this.btnAdjun.StyleController = this.layoutControl1;
            this.btnAdjun.TabIndex = 16;
            this.btnAdjun.Text = "Examinar";
            this.btnAdjun.Click += new System.EventHandler(this.btnAdjun_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup12,
            this.layoutControlGroup15,
            this.splitterItem1});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(777, 542);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup12
            // 
            this.layoutControlGroup12.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup13,
            this.layoutControlGroup14,
            this.layoutControlItem16,
            this.layoutControlItem15,
            this.layoutControlItem34,
            this.emptySpaceItem5,
            this.emptySpaceItem2});
            this.layoutControlGroup12.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup12.Name = "layoutControlGroup12";
            this.layoutControlGroup12.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.layoutControlGroup12.Size = new System.Drawing.Size(435, 542);
            this.layoutControlGroup12.Text = "Datos del Correo";
            // 
            // layoutControlGroup13
            // 
            this.layoutControlGroup13.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlGroup13.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup13.ExpandButtonVisible = true;
            this.layoutControlGroup13.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.emptySpaceItem10,
            this.layoutControlItem10,
            this.layoutControlItem11,
            this.layoutControlItem14});
            this.layoutControlGroup13.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup13.Name = "layoutControlGroup13";
            this.layoutControlGroup13.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup13.Size = new System.Drawing.Size(409, 238);
            this.layoutControlGroup13.Text = "Encabezado del Correo";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtNombreRem;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 27);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(403, 28);
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.labelControl4;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(0, 27);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(240, 27);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(240, 27);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.labelControl5;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 55);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(0, 23);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(160, 23);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(403, 23);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtCorreoRem;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 78);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(403, 28);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.labelControl6;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 106);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(0, 23);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(60, 23);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(403, 23);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtAsunto;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 129);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(403, 28);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.labelControl1;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 157);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(97, 26);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(97, 26);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(97, 26);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // emptySpaceItem10
            // 
            this.emptySpaceItem10.AllowHotTrack = false;
            this.emptySpaceItem10.Location = new System.Drawing.Point(187, 157);
            this.emptySpaceItem10.Name = "emptySpaceItem10";
            this.emptySpaceItem10.Size = new System.Drawing.Size(216, 26);
            this.emptySpaceItem10.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.btnAdjun;
            this.layoutControlItem10.Location = new System.Drawing.Point(97, 157);
            this.layoutControlItem10.MaxSize = new System.Drawing.Size(90, 26);
            this.layoutControlItem10.MinSize = new System.Drawing.Size(90, 26);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(90, 26);
            this.layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.txtAdjuntar;
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 183);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(403, 28);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem14.Control = this.mchk_copia_remitente;
            this.layoutControlItem14.Location = new System.Drawing.Point(240, 0);
            this.layoutControlItem14.MaxSize = new System.Drawing.Size(163, 27);
            this.layoutControlItem14.MinSize = new System.Drawing.Size(163, 27);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(163, 27);
            this.layoutControlItem14.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem14.TextVisible = false;
            // 
            // layoutControlGroup14
            // 
            this.layoutControlGroup14.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlGroup14.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup14.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.xtcCuerpoMail});
            this.layoutControlGroup14.Location = new System.Drawing.Point(0, 238);
            this.layoutControlGroup14.Name = "layoutControlGroup14";
            this.layoutControlGroup14.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup14.Size = new System.Drawing.Size(409, 215);
            this.layoutControlGroup14.Text = "Cuerpo del Correo";
            // 
            // xtcCuerpoMail
            // 
            this.xtcCuerpoMail.Location = new System.Drawing.Point(0, 0);
            this.xtcCuerpoMail.Name = "xtcCuerpoMail";
            this.xtcCuerpoMail.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.xtcCuerpoMail.SelectedTabPage = this.xtpTextoEnriquecido;
            this.xtcCuerpoMail.Size = new System.Drawing.Size(403, 188);
            this.xtcCuerpoMail.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.xtpTextoNormal,
            this.xtpTextoEnriquecido});
            // 
            // xtpTextoEnriquecido
            // 
            this.xtpTextoEnriquecido.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem33});
            this.xtpTextoEnriquecido.Location = new System.Drawing.Point(0, 0);
            this.xtpTextoEnriquecido.Name = "xtpTextoEnriquecido";
            this.xtpTextoEnriquecido.Size = new System.Drawing.Size(397, 159);
            this.xtpTextoEnriquecido.Text = "Texto Enriquecido";
            // 
            // layoutControlItem33
            // 
            this.layoutControlItem33.Control = this.mrtxt_cuerpoMail;
            this.layoutControlItem33.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem33.Name = "layoutControlItem33";
            this.layoutControlItem33.Size = new System.Drawing.Size(397, 159);
            this.layoutControlItem33.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem33.TextVisible = false;
            // 
            // xtpTextoNormal
            // 
            this.xtpTextoNormal.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem13});
            this.xtpTextoNormal.Location = new System.Drawing.Point(0, 0);
            this.xtpTextoNormal.Name = "xtpTextoNormal";
            this.xtpTextoNormal.Size = new System.Drawing.Size(397, 159);
            this.xtpTextoNormal.Text = "Texto Normal";
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.txtCuerpo;
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(397, 159);
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextVisible = false;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.btnEnviar;
            this.layoutControlItem16.Location = new System.Drawing.Point(195, 453);
            this.layoutControlItem16.MaxSize = new System.Drawing.Size(107, 42);
            this.layoutControlItem16.MinSize = new System.Drawing.Size(107, 42);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(107, 42);
            this.layoutControlItem16.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem16.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem16.TextVisible = false;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.btnVolver;
            this.layoutControlItem15.Location = new System.Drawing.Point(302, 453);
            this.layoutControlItem15.MaxSize = new System.Drawing.Size(107, 42);
            this.layoutControlItem15.MinSize = new System.Drawing.Size(107, 42);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(107, 42);
            this.layoutControlItem15.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextVisible = false;
            // 
            // layoutControlItem34
            // 
            this.layoutControlItem34.Control = this.mlbl_smtp;
            this.layoutControlItem34.Location = new System.Drawing.Point(0, 453);
            this.layoutControlItem34.Name = "layoutControlItem34";
            this.layoutControlItem34.Size = new System.Drawing.Size(37, 17);
            this.layoutControlItem34.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem34.TextVisible = false;
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(0, 470);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(37, 25);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(37, 453);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(158, 42);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup15
            // 
            this.layoutControlGroup15.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.xtcTipoEnvio});
            this.layoutControlGroup15.Location = new System.Drawing.Point(445, 0);
            this.layoutControlGroup15.Name = "layoutControlGroup15";
            this.layoutControlGroup15.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup15.Size = new System.Drawing.Size(332, 542);
            this.layoutControlGroup15.Text = "Listado de Correos";
            // 
            // xtcTipoEnvio
            // 
            this.xtcTipoEnvio.Location = new System.Drawing.Point(0, 0);
            this.xtcTipoEnvio.Name = "xtcTipoEnvio";
            this.xtcTipoEnvio.SelectedTabPage = this.xtpEnvioMasivo;
            this.xtcTipoEnvio.Size = new System.Drawing.Size(326, 515);
            this.xtcTipoEnvio.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.xtpEnvioMasivo,
            this.xtpEnvioIndividual});
            // 
            // xtpEnvioMasivo
            // 
            this.xtpEnvioMasivo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.emptySpaceItem9});
            this.xtpEnvioMasivo.Location = new System.Drawing.Point(0, 0);
            this.xtpEnvioMasivo.Name = "xtpEnvioMasivo";
            this.xtpEnvioMasivo.Size = new System.Drawing.Size(302, 468);
            this.xtpEnvioMasivo.Text = "Envío Masivo";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.controlNavigator1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(222, 36);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(222, 36);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(222, 36);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcCorreos;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 36);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(302, 432);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem9
            // 
            this.emptySpaceItem9.AllowHotTrack = false;
            this.emptySpaceItem9.Location = new System.Drawing.Point(222, 0);
            this.emptySpaceItem9.Name = "emptySpaceItem9";
            this.emptySpaceItem9.Size = new System.Drawing.Size(80, 36);
            this.emptySpaceItem9.TextSize = new System.Drawing.Size(0, 0);
            // 
            // xtpEnvioIndividual
            // 
            this.xtpEnvioIndividual.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem12,
            this.layoutControlItem30,
            this.layoutControlItem31,
            this.layoutControlItem32,
            this.emptySpaceItem3});
            this.xtpEnvioIndividual.Location = new System.Drawing.Point(0, 0);
            this.xtpEnvioIndividual.Name = "xtpEnvioIndividual";
            this.xtpEnvioIndividual.Size = new System.Drawing.Size(302, 468);
            this.xtpEnvioIndividual.Text = "Envío Individual";
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.labelControl8;
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem12.MaxSize = new System.Drawing.Size(0, 23);
            this.layoutControlItem12.MinSize = new System.Drawing.Size(219, 23);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(302, 23);
            this.layoutControlItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // layoutControlItem30
            // 
            this.layoutControlItem30.Control = this.txtEnvioIndividual;
            this.layoutControlItem30.Location = new System.Drawing.Point(0, 23);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Size = new System.Drawing.Size(302, 30);
            this.layoutControlItem30.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem30.TextVisible = false;
            // 
            // layoutControlItem31
            // 
            this.layoutControlItem31.Control = this.labelControl9;
            this.layoutControlItem31.Location = new System.Drawing.Point(0, 53);
            this.layoutControlItem31.MaxSize = new System.Drawing.Size(0, 23);
            this.layoutControlItem31.MinSize = new System.Drawing.Size(154, 23);
            this.layoutControlItem31.Name = "layoutControlItem31";
            this.layoutControlItem31.Size = new System.Drawing.Size(302, 23);
            this.layoutControlItem31.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem31.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem31.TextVisible = false;
            // 
            // layoutControlItem32
            // 
            this.layoutControlItem32.Control = this.LstCorreosIndiv;
            this.layoutControlItem32.Location = new System.Drawing.Point(0, 76);
            this.layoutControlItem32.MaxSize = new System.Drawing.Size(0, 235);
            this.layoutControlItem32.MinSize = new System.Drawing.Size(54, 235);
            this.layoutControlItem32.Name = "layoutControlItem32";
            this.layoutControlItem32.Size = new System.Drawing.Size(302, 235);
            this.layoutControlItem32.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem32.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem32.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 311);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(302, 157);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.Location = new System.Drawing.Point(435, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(10, 542);
            // 
            // xtpCapturaErr
            // 
            this.xtpCapturaErr.Controls.Add(this.btnimprimir_err);
            this.xtpCapturaErr.Controls.Add(this.btnVolver2);
            this.xtpCapturaErr.Controls.Add(this.mcapterr_gc);
            this.xtpCapturaErr.Controls.Add(this.memoEdit2);
            this.xtpCapturaErr.Name = "xtpCapturaErr";
            this.xtpCapturaErr.Size = new System.Drawing.Size(971, 677);
            this.xtpCapturaErr.Text = "Captura de Errores";
            // 
            // btnimprimir_err
            // 
            this.btnimprimir_err.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnimprimir_err.Appearance.Options.UseFont = true;
            this.btnimprimir_err.Appearance.Options.UseTextOptions = true;
            this.btnimprimir_err.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnimprimir_err.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnimprimir_err.ImageOptions.Image")));
            this.btnimprimir_err.Location = new System.Drawing.Point(917, 10);
            this.btnimprimir_err.Name = "btnimprimir_err";
            this.btnimprimir_err.Size = new System.Drawing.Size(165, 58);
            this.btnimprimir_err.TabIndex = 15;
            this.btnimprimir_err.Text = "Imprimir Listado";
            this.btnimprimir_err.Click += new System.EventHandler(this.btnimprimir_err_Click);
            // 
            // btnVolver2
            // 
            this.btnVolver2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver2.Appearance.Options.UseFont = true;
            this.btnVolver2.Appearance.Options.UseTextOptions = true;
            this.btnVolver2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnVolver2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnVolver2.ImageOptions.Image")));
            this.btnVolver2.Location = new System.Drawing.Point(765, 10);
            this.btnVolver2.Name = "btnVolver2";
            this.btnVolver2.Size = new System.Drawing.Size(144, 58);
            this.btnVolver2.TabIndex = 14;
            this.btnVolver2.Text = "Volver";
            this.btnVolver2.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // mcapterr_gc
            // 
            this.mcapterr_gc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mcapterr_gc.DataSource = this.bsClientes_err;
            this.mcapterr_gc.Location = new System.Drawing.Point(9, 53);
            this.mcapterr_gc.MainView = this.mcapterr_gv;
            this.mcapterr_gc.Name = "mcapterr_gc";
            this.mcapterr_gc.Size = new System.Drawing.Size(759, 480);
            this.mcapterr_gc.TabIndex = 3;
            this.mcapterr_gc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.mcapterr_gv});
            // 
            // bsClientes_err
            // 
            this.bsClientes_err.DataSource = typeof(VisorFacturas.Clases.viewClientes);
            // 
            // mcapterr_gv
            // 
            this.mcapterr_gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.mcapterr_gv_colcli_nom,
            this.mcapterr_gv_colcli_email1,
            this.mcapterr_gv_colcli_email2,
            this.mcapterr_gv_colcli_dir});
            this.mcapterr_gv.GridControl = this.mcapterr_gc;
            this.mcapterr_gv.Name = "mcapterr_gv";
            this.mcapterr_gv.OptionsBehavior.ReadOnly = true;
            this.mcapterr_gv.OptionsView.ColumnAutoWidth = false;
            this.mcapterr_gv.OptionsView.ShowGroupPanel = false;
            // 
            // mcapterr_gv_colcli_nom
            // 
            this.mcapterr_gv_colcli_nom.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.mcapterr_gv_colcli_nom.AppearanceHeader.Options.UseFont = true;
            this.mcapterr_gv_colcli_nom.AppearanceHeader.Options.UseTextOptions = true;
            this.mcapterr_gv_colcli_nom.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.mcapterr_gv_colcli_nom.Caption = "Cliente";
            this.mcapterr_gv_colcli_nom.FieldName = "cli_nom";
            this.mcapterr_gv_colcli_nom.Name = "mcapterr_gv_colcli_nom";
            this.mcapterr_gv_colcli_nom.Visible = true;
            this.mcapterr_gv_colcli_nom.VisibleIndex = 0;
            this.mcapterr_gv_colcli_nom.Width = 250;
            // 
            // mcapterr_gv_colcli_email1
            // 
            this.mcapterr_gv_colcli_email1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.mcapterr_gv_colcli_email1.AppearanceHeader.Options.UseFont = true;
            this.mcapterr_gv_colcli_email1.AppearanceHeader.Options.UseTextOptions = true;
            this.mcapterr_gv_colcli_email1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.mcapterr_gv_colcli_email1.Caption = "Correo Nº 1";
            this.mcapterr_gv_colcli_email1.FieldName = "cli_email1";
            this.mcapterr_gv_colcli_email1.Name = "mcapterr_gv_colcli_email1";
            this.mcapterr_gv_colcli_email1.Visible = true;
            this.mcapterr_gv_colcli_email1.VisibleIndex = 1;
            this.mcapterr_gv_colcli_email1.Width = 175;
            // 
            // mcapterr_gv_colcli_email2
            // 
            this.mcapterr_gv_colcli_email2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.mcapterr_gv_colcli_email2.AppearanceHeader.Options.UseFont = true;
            this.mcapterr_gv_colcli_email2.AppearanceHeader.Options.UseTextOptions = true;
            this.mcapterr_gv_colcli_email2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.mcapterr_gv_colcli_email2.Caption = "Correo Nº 2";
            this.mcapterr_gv_colcli_email2.FieldName = "cli_email2";
            this.mcapterr_gv_colcli_email2.Name = "mcapterr_gv_colcli_email2";
            this.mcapterr_gv_colcli_email2.Visible = true;
            this.mcapterr_gv_colcli_email2.VisibleIndex = 2;
            this.mcapterr_gv_colcli_email2.Width = 175;
            // 
            // mcapterr_gv_colcli_dir
            // 
            this.mcapterr_gv_colcli_dir.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.mcapterr_gv_colcli_dir.AppearanceHeader.Options.UseFont = true;
            this.mcapterr_gv_colcli_dir.AppearanceHeader.Options.UseTextOptions = true;
            this.mcapterr_gv_colcli_dir.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.mcapterr_gv_colcli_dir.Caption = "Captura de Error";
            this.mcapterr_gv_colcli_dir.FieldName = "cli_dir";
            this.mcapterr_gv_colcli_dir.Name = "mcapterr_gv_colcli_dir";
            this.mcapterr_gv_colcli_dir.Visible = true;
            this.mcapterr_gv_colcli_dir.VisibleIndex = 3;
            this.mcapterr_gv_colcli_dir.Width = 600;
            // 
            // memoEdit2
            // 
            this.memoEdit2.EditValue = "El listado muestra errores que ocurrieron en el envío masivo de facturas:\r\n* Nota" +
    ": Los Clientes que están en este listado no recibieron correo electrónico:";
            this.memoEdit2.Location = new System.Drawing.Point(14, 15);
            this.memoEdit2.Name = "memoEdit2";
            this.memoEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.memoEdit2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.memoEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.memoEdit2.Properties.Appearance.Options.UseFont = true;
            this.memoEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.memoEdit2.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.memoEdit2.Size = new System.Drawing.Size(773, 60);
            this.memoEdit2.TabIndex = 2;
            // 
            // dxErrProv
            // 
            this.dxErrProv.ContainerControl = this;
            // 
            // frmFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 893);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "frmFacturas";
            this.Text = "Visor de Facturas";
            this.Load += new System.EventHandler(this.frmFacturas_Load);
            this.Resize += new System.EventHandler(this.frmFacturas_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).EndInit();
            this.layoutControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_Mese.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEntreMES.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFacturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFacturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipomoneda_ricmb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipofactura_ricmb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAviso.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speAnno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSinFormat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkImpresionMasiva.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_meses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtpFacturas.ResumeLayout(false);
            this.xtpCorreos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LstCorreosIndiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreRem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnvioIndividual.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mchk_copia_remitente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCorreos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCorreos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.miglForm2424)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCorreoRem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAsunto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCuerpo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdjuntar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtcCuerpoMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtpTextoEnriquecido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtpTextoNormal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtcTipoEnvio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtpEnvioMasivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtpEnvioIndividual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            this.xtpCapturaErr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mcapterr_gc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClientes_err)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mcapterr_gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCorreos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrProv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVerificacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnSalir;
        private DevExpress.XtraEditors.SimpleButton btnImprimir;
        private DevExpress.XtraGrid.GridControl gcFacturas;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFacturas;
        private DevExpress.XtraEditors.SpinEdit speAnno;
        private DevExpress.XtraEditors.SimpleButton btnFiltrar;
        private DevExpress.XtraEditors.ComboBoxEdit cmbMes;
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
        private DevExpress.XtraEditors.TextEdit txtAsunto;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton btnEnviar;
        private DevExpress.XtraGrid.GridControl gcCorreos;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCorreos;
        private System.Windows.Forms.BindingSource bsCorreos;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrProv;
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
        private DevExpress.XtraEditors.SimpleButton btnimprimir_sobres;
        private DevExpress.XtraEditors.CheckEdit chkAviso;
        private DevExpress.XtraEditors.SimpleButton btnAdjun;
        private DevExpress.XtraEditors.TextEdit txtAdjuntar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ControlNavigator controlNavigator1;
        private DevExpress.XtraSplashScreen.SplashScreenManager mspsmForm;
        private DevExpress.XtraTab.XtraTabPage xtpCapturaErr;
        private DevExpress.XtraGrid.GridControl mcapterr_gc;
        private DevExpress.XtraGrid.Views.Grid.GridView mcapterr_gv;
        private DevExpress.XtraEditors.MemoEdit memoEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn mcapterr_gv_colcli_nom;
        private DevExpress.XtraGrid.Columns.GridColumn mcapterr_gv_colcli_dir;
        private DevExpress.XtraGrid.Columns.GridColumn mcapterr_gv_colcli_email1;
        private DevExpress.XtraGrid.Columns.GridColumn mcapterr_gv_colcli_email2;
        private DevExpress.XtraEditors.SimpleButton btnimprimir_err;
        private DevExpress.XtraEditors.SimpleButton btnVolver2;
        private System.Windows.Forms.BindingSource bsClientes_err;
        private DevExpress.XtraEditors.CheckEdit mchk_copia_remitente;
        private DevExpress.XtraEditors.SimpleButton btnGenerarFactEne;
        private DevExpress.XtraLayout.LayoutControl layoutControl3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem28;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem29;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraEditors.ListBoxControl LstCorreosIndiv;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtEnvioIndividual;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup12;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup13;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem9;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.TabbedControlGroup xtcTipoEnvio;
        private DevExpress.XtraLayout.LayoutControlGroup xtpEnvioMasivo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlGroup xtpEnvioIndividual;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem30;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem31;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem32;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.TabbedControlGroup xtcCuerpoMail;
        private DevExpress.XtraLayout.LayoutControlGroup xtpTextoNormal;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlGroup xtpTextoEnriquecido;
        private DevExpress.XtraRichEdit.RichEditControl mrtxt_cuerpoMail;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem33;
        private DevExpress.Utils.ImageCollection miglForm2424;
        private DevExpress.XtraGrid.Columns.GridColumn colcli_regimen;
        private DevExpress.XtraGrid.Columns.GridColumn colcli_regimen1;
        private DevExpress.XtraEditors.LabelControl mlbl_smtp;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem34;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraEditors.CheckEdit chkEntreMES;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem35;
        private DevExpress.XtraEditors.TextEdit txt_Mese;
        private DevExpress.XtraLayout.LayoutControlItem txt_meses;
        private DevExpress.XtraGrid.Columns.GridColumn colfechaVence;
        private System.Windows.Forms.BindingSource bsVerificacion;
    }
}