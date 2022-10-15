namespace CrmPosHalYonetim.HksStokYonetim
{
    partial class FrmStokTanitim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStokTanitim));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtStokKodu = new DevExpress.XtraEditors.ButtonEdit();
            this.txtStokAdi = new DevExpress.XtraEditors.ButtonEdit();
            this.cmbBirim1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cmbBirim2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cmbBirim3 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.cmbBirim4 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtBirim1 = new DevExpress.XtraEditors.TextEdit();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtBirim2 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtBirim3 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtBirim4 = new DevExpress.XtraEditors.TextEdit();
            this.cmbVergi = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.txtFiyat = new DevExpress.XtraEditors.TextEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtStokKodu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStokAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBirim1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBirim2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBirim3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBirim4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirim1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirim2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirim3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirim4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVergi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiyat.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl1.Location = new System.Drawing.Point(36, 56);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Stok Kodu";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl2.Location = new System.Drawing.Point(36, 94);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(55, 18);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Stok Adı";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl3.Location = new System.Drawing.Point(36, 170);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(98, 18);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "1.Birim/Katsayı";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl4.Location = new System.Drawing.Point(336, 133);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(33, 18);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Vergi";
            // 
            // txtStokKodu
            // 
            this.txtStokKodu.EnterMoveNextControl = true;
            this.txtStokKodu.Location = new System.Drawing.Point(144, 54);
            this.txtStokKodu.Name = "txtStokKodu";
            this.txtStokKodu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtStokKodu.Size = new System.Drawing.Size(176, 22);
            this.txtStokKodu.TabIndex = 1;
            this.txtStokKodu.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtStok_Listesi_Click);
            // 
            // txtStokAdi
            // 
            this.txtStokAdi.EnterMoveNextControl = true;
            this.txtStokAdi.Location = new System.Drawing.Point(144, 92);
            this.txtStokAdi.Name = "txtStokAdi";
            this.txtStokAdi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtStokAdi.Size = new System.Drawing.Size(377, 22);
            this.txtStokAdi.TabIndex = 2;
            this.txtStokAdi.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtStok_Listesi_Click);
            // 
            // cmbBirim1
            // 
            this.cmbBirim1.EnterMoveNextControl = true;
            this.cmbBirim1.Location = new System.Drawing.Point(144, 168);
            this.cmbBirim1.Name = "cmbBirim1";
            this.cmbBirim1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBirim1.Size = new System.Drawing.Size(176, 22);
            this.cmbBirim1.TabIndex = 5;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl5.Location = new System.Drawing.Point(36, 208);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(98, 18);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "2.Birim/Katsayı";
            // 
            // cmbBirim2
            // 
            this.cmbBirim2.EnterMoveNextControl = true;
            this.cmbBirim2.Location = new System.Drawing.Point(144, 206);
            this.cmbBirim2.Name = "cmbBirim2";
            this.cmbBirim2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBirim2.Size = new System.Drawing.Size(176, 22);
            this.cmbBirim2.TabIndex = 7;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl6.Location = new System.Drawing.Point(36, 246);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(98, 18);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "3.Birim/Katsayı";
            // 
            // cmbBirim3
            // 
            this.cmbBirim3.EnterMoveNextControl = true;
            this.cmbBirim3.Location = new System.Drawing.Point(144, 244);
            this.cmbBirim3.Name = "cmbBirim3";
            this.cmbBirim3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBirim3.Size = new System.Drawing.Size(176, 22);
            this.cmbBirim3.TabIndex = 9;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl7.Location = new System.Drawing.Point(36, 284);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(98, 18);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "4.Birim/Katsayı";
            // 
            // cmbBirim4
            // 
            this.cmbBirim4.EnterMoveNextControl = true;
            this.cmbBirim4.Location = new System.Drawing.Point(144, 282);
            this.cmbBirim4.Name = "cmbBirim4";
            this.cmbBirim4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBirim4.Size = new System.Drawing.Size(176, 22);
            this.cmbBirim4.TabIndex = 11;
            // 
            // txtBirim1
            // 
            this.txtBirim1.EnterMoveNextControl = true;
            this.txtBirim1.Location = new System.Drawing.Point(336, 168);
            this.txtBirim1.Name = "txtBirim1";
            this.txtBirim1.Size = new System.Drawing.Size(100, 22);
            this.txtBirim1.TabIndex = 6;
            // 
            // btnSil
            // 
            this.btnSil.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSil.Appearance.Options.UseFont = true;
            this.btnSil.Image = ((System.Drawing.Image)(resources.GetObject("btnSil.Image")));
            this.btnSil.Location = new System.Drawing.Point(285, 345);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(115, 25);
            this.btnSil.TabIndex = 14;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnKaydet.Appearance.Options.UseFont = true;
            this.btnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.Image")));
            this.btnKaydet.Location = new System.Drawing.Point(406, 345);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(115, 25);
            this.btnKaydet.TabIndex = 13;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl8.Location = new System.Drawing.Point(326, 170);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(6, 18);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "/";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl9.Location = new System.Drawing.Point(326, 208);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(6, 18);
            this.labelControl9.TabIndex = 0;
            this.labelControl9.Text = "/";
            // 
            // txtBirim2
            // 
            this.txtBirim2.EnterMoveNextControl = true;
            this.txtBirim2.Location = new System.Drawing.Point(336, 206);
            this.txtBirim2.Name = "txtBirim2";
            this.txtBirim2.Size = new System.Drawing.Size(100, 22);
            this.txtBirim2.TabIndex = 8;
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl10.Location = new System.Drawing.Point(326, 246);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(6, 18);
            this.labelControl10.TabIndex = 0;
            this.labelControl10.Text = "/";
            // 
            // txtBirim3
            // 
            this.txtBirim3.EnterMoveNextControl = true;
            this.txtBirim3.Location = new System.Drawing.Point(336, 244);
            this.txtBirim3.Name = "txtBirim3";
            this.txtBirim3.Size = new System.Drawing.Size(100, 22);
            this.txtBirim3.TabIndex = 10;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl11.Location = new System.Drawing.Point(326, 284);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(6, 18);
            this.labelControl11.TabIndex = 0;
            this.labelControl11.Text = "/";
            // 
            // txtBirim4
            // 
            this.txtBirim4.EnterMoveNextControl = true;
            this.txtBirim4.Location = new System.Drawing.Point(336, 282);
            this.txtBirim4.Name = "txtBirim4";
            this.txtBirim4.Size = new System.Drawing.Size(100, 22);
            this.txtBirim4.TabIndex = 12;
            // 
            // cmbVergi
            // 
            this.cmbVergi.EnterMoveNextControl = true;
            this.cmbVergi.Location = new System.Drawing.Point(375, 131);
            this.cmbVergi.Name = "cmbVergi";
            this.cmbVergi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbVergi.Size = new System.Drawing.Size(146, 22);
            this.cmbVergi.TabIndex = 4;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl12.Location = new System.Drawing.Point(-157, 245);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(98, 18);
            this.labelControl12.TabIndex = 0;
            this.labelControl12.Text = "4.Birim/Katsayı";
            // 
            // txtFiyat
            // 
            this.txtFiyat.EnterMoveNextControl = true;
            this.txtFiyat.Location = new System.Drawing.Point(144, 131);
            this.txtFiyat.Name = "txtFiyat";
            this.txtFiyat.Size = new System.Drawing.Size(176, 22);
            this.txtFiyat.TabIndex = 3;
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl13.Location = new System.Drawing.Point(36, 133);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(31, 18);
            this.labelControl13.TabIndex = 0;
            this.labelControl13.Text = "Fiyat";
            // 
            // FrmStokTanitim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 398);
            this.Controls.Add(this.txtBirim4);
            this.Controls.Add(this.txtBirim3);
            this.Controls.Add(this.txtBirim2);
            this.Controls.Add(this.txtFiyat);
            this.Controls.Add(this.txtBirim1);
            this.Controls.Add(this.cmbBirim4);
            this.Controls.Add(this.cmbBirim3);
            this.Controls.Add(this.cmbBirim2);
            this.Controls.Add(this.cmbBirim1);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtStokAdi);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.txtStokKodu);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cmbVergi);
            this.Name = "FrmStokTanitim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stok Tanıtım Kartı";
            this.Load += new System.EventHandler(this.FrmStokTanitim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtStokKodu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStokAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBirim1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBirim2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBirim3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBirim4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirim1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirim2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirim3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirim4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVergi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiyat.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ButtonEdit txtStokKodu;
        private DevExpress.XtraEditors.ButtonEdit txtStokAdi;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.ComboBoxEdit cmbBirim1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ComboBoxEdit cmbBirim2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ComboBoxEdit cmbBirim3;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.ComboBoxEdit cmbBirim4;
        private DevExpress.XtraEditors.TextEdit txtBirim1;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtBirim2;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit txtBirim3;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit txtBirim4;
        private DevExpress.XtraEditors.ComboBoxEdit cmbVergi;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.TextEdit txtFiyat;
        private DevExpress.XtraEditors.LabelControl labelControl13;
    }
}