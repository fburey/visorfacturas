namespace VisorFacturas.Reports
{
    partial class rptEmpleadoLst
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptEmpleadoLst));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.mpicboxLogCia = new DevExpress.XtraReports.UI.XRPictureBox();
            this.mpicboxEscNic = new DevExpress.XtraReports.UI.XRPictureBox();
            this.mtblHeaTit = new DevExpress.XtraReports.UI.XRTable();
            this.mtblrowHeaTit010 = new DevExpress.XtraReports.UI.XRTableRow();
            this.mtblcelTit010 = new DevExpress.XtraReports.UI.XRTableCell();
            this.mtblrowHeaTit020 = new DevExpress.XtraReports.UI.XRTableRow();
            this.mtblcelTit020 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.mtblHeaCol = new DevExpress.XtraReports.UI.XRTable();
            this.mtblrowHeaCol010 = new DevExpress.XtraReports.UI.XRTableRow();
            this.mtblrowHeaCol010_celcoddepart = new DevExpress.XtraReports.UI.XRTableCell();
            this.mtblrowHeaCol010_celdscdepart = new DevExpress.XtraReports.UI.XRTableCell();
            this.mtblrowHeaCol010_celdscestcnf = new DevExpress.XtraReports.UI.XRTableCell();
            this.mtblrowHeaCol010_celdscdepart_rto = new DevExpress.XtraReports.UI.XRTableCell();
            this.mreport_bndsrc = new System.Windows.Forms.BindingSource(this.components);
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.mxrppaginfFchPrt = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.mxrppaginfPagNum = new DevExpress.XtraReports.UI.XRPageInfo();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtblHeaTit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtblHeaCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mreport_bndsrc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.Detail.HeightF = 20F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable2
            // 
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(786.0001F, 20F);
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell10,
            this.xrTableCell2});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 0.4085106170778644D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "c_codigo")});
            this.xrTableCell7.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 0, 0, 0, 100F);
            this.xrTableCell7.StylePriority.UseFont = false;
            this.xrTableCell7.StylePriority.UsePadding = false;
            this.xrTableCell7.Weight = 0.16555194741975729D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "nombre")});
            this.xrTableCell8.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 0, 0, 0, 100F);
            this.xrTableCell8.StylePriority.UseFont = false;
            this.xrTableCell8.StylePriority.UsePadding = false;
            this.xrTableCell8.Weight = 0.83274832380490393D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "cargo")});
            this.xrTableCell10.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 0, 0, 0, 100F);
            this.xrTableCell10.StylePriority.UseFont = false;
            this.xrTableCell10.StylePriority.UsePadding = false;
            this.xrTableCell10.Weight = 0.8034295120117918D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "departamento")});
            this.xrTableCell2.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 0, 0, 0, 100F);
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.StylePriority.UsePadding = false;
            this.xrTableCell2.Weight = 0.62134682325571455D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 23.66667F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 19.79167F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.mpicboxLogCia,
            this.mpicboxEscNic,
            this.mtblHeaTit,
            this.mtblHeaCol});
            this.PageHeader.HeightF = 110.3333F;
            this.PageHeader.Name = "PageHeader";
            // 
            // mpicboxLogCia
            // 
            this.mpicboxLogCia.Image = ((System.Drawing.Image)(resources.GetObject("mpicboxLogCia.Image")));
            this.mpicboxLogCia.LocationFloat = new DevExpress.Utils.PointFloat(691F, 0F);
            this.mpicboxLogCia.Name = "mpicboxLogCia";
            this.mpicboxLogCia.SizeF = new System.Drawing.SizeF(95F, 75F);
            this.mpicboxLogCia.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // mpicboxEscNic
            // 
            this.mpicboxEscNic.Image = ((System.Drawing.Image)(resources.GetObject("mpicboxEscNic.Image")));
            this.mpicboxEscNic.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.mpicboxEscNic.Name = "mpicboxEscNic";
            this.mpicboxEscNic.SizeF = new System.Drawing.SizeF(95F, 75F);
            this.mpicboxEscNic.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // mtblHeaTit
            // 
            this.mtblHeaTit.LocationFloat = new DevExpress.Utils.PointFloat(95.00002F, 0F);
            this.mtblHeaTit.Name = "mtblHeaTit";
            this.mtblHeaTit.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.mtblrowHeaTit010,
            this.mtblrowHeaTit020,
            this.xrTableRow6});
            this.mtblHeaTit.SizeF = new System.Drawing.SizeF(596F, 75F);
            // 
            // mtblrowHeaTit010
            // 
            this.mtblrowHeaTit010.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.mtblcelTit010});
            this.mtblrowHeaTit010.Name = "mtblrowHeaTit010";
            this.mtblrowHeaTit010.Weight = 1.0000000254313153D;
            // 
            // mtblcelTit010
            // 
            this.mtblcelTit010.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.mtblcelTit010.Name = "mtblcelTit010";
            this.mtblcelTit010.StylePriority.UseFont = false;
            this.mtblcelTit010.StylePriority.UseTextAlignment = false;
            this.mtblcelTit010.Text = "Comisión Nacional de Zonas Francas";
            this.mtblcelTit010.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.mtblcelTit010.Weight = 3D;
            // 
            // mtblrowHeaTit020
            // 
            this.mtblrowHeaTit020.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.mtblcelTit020});
            this.mtblrowHeaTit020.Name = "mtblrowHeaTit020";
            this.mtblrowHeaTit020.Weight = 0.999999974568685D;
            // 
            // mtblcelTit020
            // 
            this.mtblcelTit020.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.mtblcelTit020.Name = "mtblcelTit020";
            this.mtblcelTit020.StylePriority.UseFont = false;
            this.mtblcelTit020.StylePriority.UseTextAlignment = false;
            this.mtblcelTit020.Text = "Listado de Empleados";
            this.mtblcelTit020.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.mtblcelTit020.Weight = 3D;
            // 
            // xrTableRow6
            // 
            this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell6});
            this.xrTableRow6.Name = "xrTableRow6";
            this.xrTableRow6.Weight = 0.999999974568685D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.StylePriority.UseFont = false;
            this.xrTableCell6.StylePriority.UseTextAlignment = false;
            this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell6.Weight = 3D;
            // 
            // mtblHeaCol
            // 
            this.mtblHeaCol.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.mtblHeaCol.LocationFloat = new DevExpress.Utils.PointFloat(0F, 75F);
            this.mtblHeaCol.Name = "mtblHeaCol";
            this.mtblHeaCol.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.mtblrowHeaCol010});
            this.mtblHeaCol.SizeF = new System.Drawing.SizeF(786.0001F, 32.71602F);
            this.mtblHeaCol.StylePriority.UseFont = false;
            // 
            // mtblrowHeaCol010
            // 
            this.mtblrowHeaCol010.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.mtblrowHeaCol010_celcoddepart,
            this.mtblrowHeaCol010_celdscdepart,
            this.mtblrowHeaCol010_celdscestcnf,
            this.mtblrowHeaCol010_celdscdepart_rto});
            this.mtblrowHeaCol010.Name = "mtblrowHeaCol010";
            this.mtblrowHeaCol010.Weight = 1D;
            // 
            // mtblrowHeaCol010_celcoddepart
            // 
            this.mtblrowHeaCol010_celcoddepart.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.mtblrowHeaCol010_celcoddepart.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.mtblrowHeaCol010_celcoddepart.Name = "mtblrowHeaCol010_celcoddepart";
            this.mtblrowHeaCol010_celcoddepart.StylePriority.UseBorders = false;
            this.mtblrowHeaCol010_celcoddepart.StylePriority.UseFont = false;
            this.mtblrowHeaCol010_celcoddepart.StylePriority.UseTextAlignment = false;
            this.mtblrowHeaCol010_celcoddepart.Text = "Código";
            this.mtblrowHeaCol010_celcoddepart.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.mtblrowHeaCol010_celcoddepart.Weight = 0.59815923406488414D;
            // 
            // mtblrowHeaCol010_celdscdepart
            // 
            this.mtblrowHeaCol010_celdscdepart.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.mtblrowHeaCol010_celdscdepart.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.mtblrowHeaCol010_celdscdepart.Name = "mtblrowHeaCol010_celdscdepart";
            this.mtblrowHeaCol010_celdscdepart.StylePriority.UseBorders = false;
            this.mtblrowHeaCol010_celdscdepart.StylePriority.UseFont = false;
            this.mtblrowHeaCol010_celdscdepart.StylePriority.UseTextAlignment = false;
            this.mtblrowHeaCol010_celdscdepart.Text = "Nombre del Empleado";
            this.mtblrowHeaCol010_celdscdepart.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.mtblrowHeaCol010_celdscdepart.Weight = 3.0088206837074525D;
            // 
            // mtblrowHeaCol010_celdscestcnf
            // 
            this.mtblrowHeaCol010_celdscestcnf.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.mtblrowHeaCol010_celdscestcnf.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.mtblrowHeaCol010_celdscestcnf.Name = "mtblrowHeaCol010_celdscestcnf";
            this.mtblrowHeaCol010_celdscestcnf.StylePriority.UseBorders = false;
            this.mtblrowHeaCol010_celdscestcnf.StylePriority.UseFont = false;
            this.mtblrowHeaCol010_celdscestcnf.StylePriority.UseTextAlignment = false;
            this.mtblrowHeaCol010_celdscestcnf.Text = "Cargo";
            this.mtblrowHeaCol010_celdscestcnf.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.mtblrowHeaCol010_celdscestcnf.Weight = 2.9028884741300152D;
            // 
            // mtblrowHeaCol010_celdscdepart_rto
            // 
            this.mtblrowHeaCol010_celdscdepart_rto.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.mtblrowHeaCol010_celdscdepart_rto.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.mtblrowHeaCol010_celdscdepart_rto.Name = "mtblrowHeaCol010_celdscdepart_rto";
            this.mtblrowHeaCol010_celdscdepart_rto.StylePriority.UseBorders = false;
            this.mtblrowHeaCol010_celdscdepart_rto.StylePriority.UseFont = false;
            this.mtblrowHeaCol010_celdscdepart_rto.StylePriority.UseTextAlignment = false;
            this.mtblrowHeaCol010_celdscdepart_rto.Text = "Área";
            this.mtblrowHeaCol010_celdscdepart_rto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.mtblrowHeaCol010_celdscdepart_rto.Weight = 2.2450011996383124D;
            // 
            // mreport_bndsrc
            // 
            this.mreport_bndsrc.DataSource = typeof(VisorFacturas.Clases.viewEmpleados);
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.PageFooter.HeightF = 29.16667F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(786F, 29.16667F);
            this.xrTable1.StylePriority.UseBorders = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell3,
            this.xrTableCell4,
            this.xrTableCell5});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.mxrppaginfFchPrt});
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Weight = 1D;
            // 
            // mxrppaginfFchPrt
            // 
            this.mxrppaginfFchPrt.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.mxrppaginfFchPrt.Format = "{0:dd/MM/yyyy    hh:mm tt}";
            this.mxrppaginfFchPrt.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 9.166662F);
            this.mxrppaginfFchPrt.Name = "mxrppaginfFchPrt";
            this.mxrppaginfFchPrt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.mxrppaginfFchPrt.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.mxrppaginfFchPrt.SizeF = new System.Drawing.SizeF(242F, 20.00001F);
            this.mxrppaginfFchPrt.StylePriority.UseBorders = false;
            this.mxrppaginfFchPrt.StylePriority.UseTextAlignment = false;
            this.mxrppaginfFchPrt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.mxrppaginfFchPrt.Visible = false;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Weight = 0.80216281104633835D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.mxrppaginfPagNum});
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Weight = 1.1978371889536617D;
            // 
            // mxrppaginfPagNum
            // 
            this.mxrppaginfPagNum.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right;
            this.mxrppaginfPagNum.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.mxrppaginfPagNum.Format = "Página {0} de {1}";
            this.mxrppaginfPagNum.LocationFloat = new DevExpress.Utils.PointFloat(26.79176F, 9.166654F);
            this.mxrppaginfPagNum.Name = "mxrppaginfPagNum";
            this.mxrppaginfPagNum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.mxrppaginfPagNum.SizeF = new System.Drawing.SizeF(277.0415F, 20.00001F);
            this.mxrppaginfPagNum.StylePriority.UseBorders = false;
            this.mxrppaginfPagNum.StylePriority.UseTextAlignment = false;
            this.mxrppaginfPagNum.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // rptEmpleadoLst
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.PageFooter});
            this.DataSource = this.mreport_bndsrc;
            this.Margins = new System.Drawing.Printing.Margins(31, 33, 24, 20);
            this.Version = "17.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtblHeaTit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mtblHeaCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mreport_bndsrc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        internal DevExpress.XtraReports.UI.XRPictureBox mpicboxLogCia;
        internal DevExpress.XtraReports.UI.XRPictureBox mpicboxEscNic;
        internal DevExpress.XtraReports.UI.XRTable mtblHeaTit;
        internal DevExpress.XtraReports.UI.XRTableRow mtblrowHeaTit010;
        internal DevExpress.XtraReports.UI.XRTableCell mtblcelTit010;
        internal DevExpress.XtraReports.UI.XRTableRow mtblrowHeaTit020;
        internal DevExpress.XtraReports.UI.XRTableCell mtblcelTit020;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow6;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        internal DevExpress.XtraReports.UI.XRTable mtblHeaCol;
        internal DevExpress.XtraReports.UI.XRTableRow mtblrowHeaCol010;
        internal DevExpress.XtraReports.UI.XRTableCell mtblrowHeaCol010_celcoddepart;
        internal DevExpress.XtraReports.UI.XRTableCell mtblrowHeaCol010_celdscdepart;
        internal DevExpress.XtraReports.UI.XRTableCell mtblrowHeaCol010_celdscestcnf;
        internal DevExpress.XtraReports.UI.XRTableCell mtblrowHeaCol010_celdscdepart_rto;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell10;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private System.Windows.Forms.BindingSource mreport_bndsrc;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        internal DevExpress.XtraReports.UI.XRPageInfo mxrppaginfFchPrt;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        internal DevExpress.XtraReports.UI.XRPageInfo mxrppaginfPagNum;
    }
}
