namespace VisorFacturas.Forms
{
    partial class frmMDI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMDI));
            this.xtabmdiman_Main = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.ribbonMain = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbi_visorfactura = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Salir = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_ActivosAsignados = new DevExpress.XtraBars.BarButtonItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.bbi_SistInf = new DevExpress.XtraBars.BarButtonItem();
            this.btnmenuCam = new DevExpress.XtraBars.BarButtonItem();
            this.milcImage3232 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribPag_Facturas = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribpag_ActivosFijo = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribpag_Reportes = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribpag_estilos = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.xtabmdiman_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.milcImage3232)).BeginInit();
            this.SuspendLayout();
            // 
            // xtabmdiman_Main
            // 
            this.xtabmdiman_Main.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeader;
            this.xtabmdiman_Main.MdiParent = this;
            this.xtabmdiman_Main.PageRemoved += new DevExpress.XtraTabbedMdi.MdiTabPageEventHandler(this.xtabmdiman_Main_PageRemoved);
            // 
            // ribbonMain
            // 
            this.ribbonMain.ExpandCollapseItem.Id = 0;
            this.ribbonMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonMain.ExpandCollapseItem,
            this.bbi_visorfactura,
            this.bbi_Salir,
            this.bbi_ActivosAsignados,
            this.skinRibbonGalleryBarItem1,
            this.bbi_SistInf,
            this.btnmenuCam});
            this.ribbonMain.LargeImages = this.milcImage3232;
            this.ribbonMain.Location = new System.Drawing.Point(0, 0);
            this.ribbonMain.MaxItemId = 10;
            this.ribbonMain.Name = "ribbonMain";
            this.ribbonMain.PageHeaderItemLinks.Add(this.btnmenuCam);
            this.ribbonMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribPag_Facturas,
            this.ribpag_ActivosFijo,
            this.ribpag_Reportes,
            this.ribpag_estilos});
            this.ribbonMain.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonMain.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonMain.ShowToolbarCustomizeItem = false;
            this.ribbonMain.Size = new System.Drawing.Size(884, 126);
            this.ribbonMain.Toolbar.ShowCustomizeItem = false;
            this.ribbonMain.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbi_visorfactura
            // 
            this.bbi_visorfactura.Caption = "Visor de Facturas";
            this.bbi_visorfactura.Id = 2;
            this.bbi_visorfactura.ImageOptions.LargeImageIndex = 31;
            this.bbi_visorfactura.LargeWidth = 100;
            this.bbi_visorfactura.Name = "bbi_visorfactura";
            this.bbi_visorfactura.Tag = "frmFacturas";
            this.bbi_visorfactura.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_visorfactura_ItemClick);
            // 
            // bbi_Salir
            // 
            this.bbi_Salir.Caption = "Salir del Sistema";
            this.bbi_Salir.Id = 3;
            this.bbi_Salir.ImageOptions.LargeImageIndex = 32;
            this.bbi_Salir.Name = "bbi_Salir";
            this.bbi_Salir.Tag = "SalirSistema";
            this.bbi_Salir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_visorfactura_ItemClick);
            // 
            // bbi_ActivosAsignados
            // 
            this.bbi_ActivosAsignados.Caption = "Activos Asignados";
            this.bbi_ActivosAsignados.Id = 4;
            this.bbi_ActivosAsignados.ImageOptions.LargeImageIndex = 27;
            this.bbi_ActivosAsignados.LargeWidth = 100;
            this.bbi_ActivosAsignados.Name = "bbi_ActivosAsignados";
            this.bbi_ActivosAsignados.Tag = "frmConsulta1";
            this.bbi_ActivosAsignados.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_visorfactura_ItemClick);
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.Id = 5;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // bbi_SistInf
            // 
            this.bbi_SistInf.Caption = "Sistema de Información";
            this.bbi_SistInf.Id = 6;
            this.bbi_SistInf.ImageOptions.LargeImageIndex = 2;
            this.bbi_SistInf.Name = "bbi_SistInf";
            this.bbi_SistInf.Tag = "frmSistInf";
            this.bbi_SistInf.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_visorfactura_ItemClick);
            // 
            // btnmenuCam
            // 
            this.btnmenuCam.Caption = "barButtonItem1";
            this.btnmenuCam.Id = 9;
            this.btnmenuCam.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnmenuCam.ImageOptions.Image")));
            this.btnmenuCam.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnmenuCam.ImageOptions.LargeImage")));
            this.btnmenuCam.Name = "btnmenuCam";
            this.btnmenuCam.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnmenuCam_ItemClick);
            // 
            // milcImage3232
            // 
            this.milcImage3232.ImageSize = new System.Drawing.Size(32, 32);
            this.milcImage3232.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("milcImage3232.ImageStream")));
            this.milcImage3232.Images.SetKeyName(0, "archive_32x32");
            this.milcImage3232.Images.SetKeyName(1, "vendor_32x32");
            this.milcImage3232.Images.SetKeyName(2, "shipment_32x32");
            this.milcImage3232.Images.SetKeyName(3, "tool_ruler_32x32");
            this.milcImage3232.Images.SetKeyName(4, "archive020_32x32");
            this.milcImage3232.Images.SetKeyName(5, "Bodega_32x32");
            this.milcImage3232.Images.SetKeyName(6, "EmpLoy_btn.png");
            this.milcImage3232.Images.SetKeyName(7, "Holday020_btn.png");
            this.milcImage3232.Images.SetKeyName(8, "JobPos_btn.png");
            this.milcImage3232.Images.SetKeyName(9, "MarEmp020_btn.png");
            this.milcImage3232.Images.SetKeyName(10, "OrgAni_btn.png");
            this.milcImage3232.Images.SetKeyName(11, "BenLab_btn.png");
            this.milcImage3232.Images.SetKeyName(12, "GenDed_btn.png");
            this.milcImage3232.Images.SetKeyName(13, "GenIng_btn.png");
            this.milcImage3232.Images.SetKeyName(14, "OtrIng_btn.png");
            this.milcImage3232.Images.SetKeyName(15, "cash (2).png");
            this.milcImage3232.Images.SetKeyName(16, "check-list (2).png");
            this.milcImage3232.Images.SetKeyName(17, "check-list (5).png");
            this.milcImage3232.Images.SetKeyName(18, "check-list (8).png");
            this.milcImage3232.Images.SetKeyName(19, "check-mark (2).png");
            this.milcImage3232.Images.SetKeyName(20, "invoice (2).png");
            this.milcImage3232.Images.SetKeyName(21, "invoice (5).png");
            this.milcImage3232.Images.SetKeyName(22, "invoice (9).png");
            this.milcImage3232.Images.SetKeyName(23, "invoice (12).png");
            this.milcImage3232.Images.SetKeyName(24, "invoice (15).png");
            this.milcImage3232.Images.SetKeyName(25, "invoice (18).png");
            this.milcImage3232.Images.SetKeyName(26, "notepad (2).png");
            this.milcImage3232.Images.SetKeyName(27, "notepad (5).png");
            this.milcImage3232.Images.SetKeyName(28, "notepad (8).png");
            this.milcImage3232.Images.SetKeyName(29, "notepad (11).png");
            this.milcImage3232.Images.SetKeyName(30, "notepad (14).png");
            this.milcImage3232.Images.SetKeyName(31, "notepad (17).png");
            this.milcImage3232.Images.SetKeyName(32, "TraExt_btn.png");
            // 
            // ribPag_Facturas
            // 
            this.ribPag_Facturas.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup3,
            this.ribbonPageGroup5,
            this.ribbonPageGroup2});
            this.ribPag_Facturas.Name = "ribPag_Facturas";
            this.ribPag_Facturas.Text = "Facturas";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbi_visorfactura);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Vista de Facturas";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup3.ItemLinks.Add(this.bbi_ActivosAsignados, true);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Visor de Activos Fijos";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.bbi_SistInf);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "Reportes";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup2.ItemLinks.Add(this.bbi_Salir);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Visible = false;
            // 
            // ribpag_ActivosFijo
            // 
            this.ribpag_ActivosFijo.Name = "ribpag_ActivosFijo";
            this.ribpag_ActivosFijo.Text = "Activo Fijo";
            this.ribpag_ActivosFijo.Visible = false;
            // 
            // ribpag_Reportes
            // 
            this.ribpag_Reportes.Name = "ribpag_Reportes";
            this.ribpag_Reportes.Text = "Reportes";
            this.ribpag_Reportes.Visible = false;
            // 
            // ribpag_estilos
            // 
            this.ribpag_estilos.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.ribpag_estilos.Name = "ribpag_estilos";
            this.ribpag_estilos.Text = "Estilos";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Estilos del sistema";
            // 
            // frmMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.ribbonMain);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmMDI.IconOptions.Icon")));
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(886, 593);
            this.Name = "frmMDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SISTEMA DE CONSULTAS DBF";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMDI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtabmdiman_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.milcImage3232)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtabmdiman_Main;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonMain;
        private DevExpress.XtraBars.BarButtonItem bbi_visorfactura;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribPag_Facturas;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.Utils.ImageCollection milcImage3232;
        private DevExpress.XtraBars.BarButtonItem bbi_Salir;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribpag_ActivosFijo;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem bbi_ActivosAsignados;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribpag_estilos;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem bbi_SistInf;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribpag_Reportes;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem btnmenuCam;
    }
}