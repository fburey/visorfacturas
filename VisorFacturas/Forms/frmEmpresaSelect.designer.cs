namespace VisorFacturas.Forms
{
    partial class frmEmpresaSelect
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
            this.pictureCNZF = new DevExpress.XtraEditors.PictureEdit();
            this.pictureCZF = new DevExpress.XtraEditors.PictureEdit();
            this.btn_Cancelar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCNZF.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCZF.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureCNZF
            // 
            this.pictureCNZF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureCNZF.EditValue = global::VisorFacturas.Properties.Resources.Comisión_Nacional_de_Zonas_Francas;
            this.pictureCNZF.Location = new System.Drawing.Point(276, 50);
            this.pictureCNZF.Name = "pictureCNZF";
            this.pictureCNZF.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureCNZF.Properties.ShowMenu = false;
            this.pictureCNZF.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureCNZF.Size = new System.Drawing.Size(204, 119);
            this.pictureCNZF.TabIndex = 7;
            this.pictureCNZF.Tag = "CNZF";
            this.pictureCNZF.ToolTip = "Click para seleccionar";
            this.pictureCNZF.Click += new System.EventHandler(this.picture_Click);
            // 
            // pictureCZF
            // 
            this.pictureCZF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureCZF.EditValue = global::VisorFacturas.Properties.Resources.Watermark_CZF_Logo;
            this.pictureCZF.Location = new System.Drawing.Point(33, 50);
            this.pictureCZF.Name = "pictureCZF";
            this.pictureCZF.Properties.ShowMenu = false;
            this.pictureCZF.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureCZF.Size = new System.Drawing.Size(204, 119);
            this.pictureCZF.TabIndex = 6;
            this.pictureCZF.Tag = "CZF";
            this.pictureCZF.ToolTip = "Click para seleccionar";
            this.pictureCZF.Click += new System.EventHandler(this.picture_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Appearance.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_Cancelar.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.btn_Cancelar.Appearance.Options.UseFont = true;
            this.btn_Cancelar.Appearance.Options.UseForeColor = true;
            this.btn_Cancelar.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_Cancelar.AppearancePressed.ForeColor = System.Drawing.Color.Red;
            this.btn_Cancelar.AppearancePressed.Options.UseFont = true;
            this.btn_Cancelar.AppearancePressed.Options.UseForeColor = true;
            this.btn_Cancelar.Location = new System.Drawing.Point(209, 192);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(87, 25);
            this.btn_Cancelar.TabIndex = 8;
            this.btn_Cancelar.Text = "CANCELAR";
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // frmEmpresaSelect
            // 
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Appearance.Options.UseFont = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 247);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.pictureCNZF);
            this.Controls.Add(this.pictureCZF);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(534, 280);
            this.MinimumSize = new System.Drawing.Size(526, 279);
            this.Name = "frmEmpresaSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccione la Empresa para la Transacción";
            this.Load += new System.EventHandler(this.frmEmpresaSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureCNZF.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCZF.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureCNZF;
        private DevExpress.XtraEditors.PictureEdit pictureCZF;
        private DevExpress.XtraEditors.SimpleButton btn_Cancelar;
    }
}