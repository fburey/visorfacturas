
namespace VisorFacturas.Forms
{
    partial class modal_frmVerificadas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(modal_frmVerificadas));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gcFacturasV = new DevExpress.XtraGrid.GridControl();
            this.bsVerificacion = new System.Windows.Forms.BindingSource(this.components);
            this.gvFacturasV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tipomoneda_ricmb = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.tipofactura_ricmb = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.toolbarFormControl1 = new DevExpress.XtraBars.ToolbarForm.ToolbarFormControl();
            this.toolbarFormManager1 = new DevExpress.XtraBars.ToolbarForm.ToolbarFormManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcFacturasV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVerificacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFacturasV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipomoneda_ricmb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipofactura_ricmb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolbarFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolbarFormManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gcFacturasV);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 31);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(703, 470);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gcFacturasV
            // 
            this.gcFacturasV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcFacturasV.DataSource = this.bsVerificacion;
            this.gcFacturasV.Location = new System.Drawing.Point(12, 12);
            this.gcFacturasV.MainView = this.gvFacturasV;
            this.gcFacturasV.Name = "gcFacturasV";
            this.gcFacturasV.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.tipomoneda_ricmb,
            this.tipofactura_ricmb});
            this.gcFacturasV.Size = new System.Drawing.Size(679, 446);
            this.gcFacturasV.TabIndex = 11;
            this.gcFacturasV.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFacturasV});
            // 
            // bsVerificacion
            // 
            this.bsVerificacion.DataSource = typeof(VisorFacturas.Clases.viewVerificadas);
            // 
            // gvFacturasV
            // 
            this.gvFacturasV.Appearance.FooterPanel.BackColor = System.Drawing.Color.Moccasin;
            this.gvFacturasV.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.Moccasin;
            this.gvFacturasV.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvFacturasV.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Blue;
            this.gvFacturasV.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gvFacturasV.Appearance.FooterPanel.Options.UseFont = true;
            this.gvFacturasV.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gvFacturasV.GridControl = this.gcFacturasV;
            this.gvFacturasV.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "cli_nom", null, "(Cliente: Recuento={0})")});
            this.gvFacturasV.Name = "gvFacturasV";
            this.gvFacturasV.OptionsBehavior.Editable = false;
            this.gvFacturasV.OptionsFind.AllowFindPanel = false;
            this.gvFacturasV.OptionsView.ColumnAutoWidth = false;
            this.gvFacturasV.OptionsView.ShowAutoFilterRow = true;
            this.gvFacturasV.OptionsView.ShowFooter = true;
            this.gvFacturasV.OptionsView.ShowGroupPanel = false;
            this.gvFacturasV.OptionsView.ShowViewCaption = true;
            this.gvFacturasV.ViewCaption = "Total de Facturas Encontradas:";
            this.gvFacturasV.ViewCaptionHeight = 25;
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
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(703, 470);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcFacturasV;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(683, 450);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // toolbarFormControl1
            // 
            this.toolbarFormControl1.Location = new System.Drawing.Point(0, 0);
            this.toolbarFormControl1.Manager = this.toolbarFormManager1;
            this.toolbarFormControl1.Name = "toolbarFormControl1";
            this.toolbarFormControl1.Size = new System.Drawing.Size(703, 31);
            this.toolbarFormControl1.TabIndex = 1;
            this.toolbarFormControl1.TabStop = false;
            this.toolbarFormControl1.TitleItemLinks.Add(this.barButtonItem1);
            this.toolbarFormControl1.TitleItemLinks.Add(this.barButtonItem2);
            this.toolbarFormControl1.ToolbarForm = this;
            // 
            // toolbarFormManager1
            // 
            this.toolbarFormManager1.DockControls.Add(this.barDockControlTop);
            this.toolbarFormManager1.DockControls.Add(this.barDockControlBottom);
            this.toolbarFormManager1.DockControls.Add(this.barDockControlLeft);
            this.toolbarFormManager1.DockControls.Add(this.barDockControlRight);
            this.toolbarFormManager1.Form = this;
            this.toolbarFormManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2});
            this.toolbarFormManager1.MaxItemId = 2;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 31);
            this.barDockControlTop.Manager = this.toolbarFormManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(703, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 501);
            this.barDockControlBottom.Manager = this.toolbarFormManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(703, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.toolbarFormManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 470);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(703, 31);
            this.barDockControlRight.Manager = this.toolbarFormManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 470);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Exportar";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.barButtonItem2.Caption = "Imprimir";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // modal_frmVerificadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 501);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.toolbarFormControl1);
            this.Name = "modal_frmVerificadas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturas que no cumplen con el parametro de fecha de vencimiento";
            this.ToolbarFormControl = this.toolbarFormControl1;
            this.Load += new System.EventHandler(this.modal_frmVerificadas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcFacturasV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVerificacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFacturasV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipomoneda_ricmb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipofactura_ricmb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolbarFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolbarFormManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl gcFacturasV;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFacturasV;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox tipomoneda_ricmb;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox tipofactura_ricmb;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource bsVerificacion;
        private DevExpress.XtraBars.ToolbarForm.ToolbarFormControl toolbarFormControl1;
        private DevExpress.XtraBars.ToolbarForm.ToolbarFormManager toolbarFormManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
    }
}