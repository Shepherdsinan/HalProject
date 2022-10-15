namespace CrmPosHalYonetim.HksStokYonetim
{
    partial class FrmCariTanitim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCariTanitim));
            this.txtCariAdi = new DevExpress.XtraEditors.ButtonEdit();
            this.txtCariKodu = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txtFaturaAdres = new DevExpress.XtraEditors.TextEdit();
            this.cmbFaturaAdresIlce = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbFaturaAdresIL = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtSevkAdres = new DevExpress.XtraEditors.TextEdit();
            this.cmbSevkAdresIlce = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.cmbSevkAdresIL = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtCariAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCariKodu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFaturaAdres.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFaturaAdresIlce.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFaturaAdresIL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSevkAdres.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSevkAdresIlce.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSevkAdresIL.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCariAdi
            // 
            this.txtCariAdi.EnterMoveNextControl = true;
            this.txtCariAdi.Location = new System.Drawing.Point(123, 64);
            this.txtCariAdi.Name = "txtCariAdi";
            this.txtCariAdi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtCariAdi.Size = new System.Drawing.Size(377, 22);
            this.txtCariAdi.TabIndex = 1;
            this.txtCariAdi.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txt_CariButton_Click);
            // 
            // txtCariKodu
            // 
            this.txtCariKodu.EnterMoveNextControl = true;
            this.txtCariKodu.Location = new System.Drawing.Point(123, 26);
            this.txtCariKodu.Name = "txtCariKodu";
            this.txtCariKodu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtCariKodu.Size = new System.Drawing.Size(176, 22);
            this.txtCariKodu.TabIndex = 0;
            this.txtCariKodu.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txt_CariButton_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl2.Location = new System.Drawing.Point(15, 66);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 18);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Cari Adı";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl1.Location = new System.Drawing.Point(15, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(66, 18);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Cari Kodu";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnSil);
            this.panelControl1.Controls.Add(this.btnKaydet);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 507);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(746, 43);
            this.panelControl1.TabIndex = 7;
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.txtFaturaAdres);
            this.groupControl2.Controls.Add(this.cmbFaturaAdresIlce);
            this.groupControl2.Controls.Add(this.cmbFaturaAdresIL);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl2.Location = new System.Drawing.Point(0, 119);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(746, 194);
            this.groupControl2.TabIndex = 10;
            this.groupControl2.Text = "Fatura Adresi";
            // 
            // txtFaturaAdres
            // 
            this.txtFaturaAdres.EnterMoveNextControl = true;
            this.txtFaturaAdres.Location = new System.Drawing.Point(123, 119);
            this.txtFaturaAdres.Name = "txtFaturaAdres";
            this.txtFaturaAdres.Properties.AutoHeight = false;
            this.txtFaturaAdres.Size = new System.Drawing.Size(579, 53);
            this.txtFaturaAdres.TabIndex = 2;
            // 
            // cmbFaturaAdresIlce
            // 
            this.cmbFaturaAdresIlce.EnterMoveNextControl = true;
            this.cmbFaturaAdresIlce.Location = new System.Drawing.Point(123, 82);
            this.cmbFaturaAdresIlce.Name = "cmbFaturaAdresIlce";
            this.cmbFaturaAdresIlce.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFaturaAdresIlce.Size = new System.Drawing.Size(247, 22);
            this.cmbFaturaAdresIlce.TabIndex = 1;
            // 
            // cmbFaturaAdresIL
            // 
            this.cmbFaturaAdresIL.EnterMoveNextControl = true;
            this.cmbFaturaAdresIL.Location = new System.Drawing.Point(123, 45);
            this.cmbFaturaAdresIL.Name = "cmbFaturaAdresIL";
            this.cmbFaturaAdresIL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFaturaAdresIL.Size = new System.Drawing.Size(247, 22);
            this.cmbFaturaAdresIL.TabIndex = 0;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl5.Location = new System.Drawing.Point(30, 137);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(51, 18);
            this.labelControl5.TabIndex = 3;
            this.labelControl5.Text = "ADRES";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl4.Location = new System.Drawing.Point(30, 82);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(32, 18);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "İLÇE";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl3.Location = new System.Drawing.Point(30, 47);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(11, 18);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "İL";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.txtSevkAdres);
            this.groupControl1.Controls.Add(this.cmbSevkAdresIlce);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.cmbSevkAdresIL);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 313);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(746, 194);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Sevk Adresi";
            // 
            // txtSevkAdres
            // 
            this.txtSevkAdres.EnterMoveNextControl = true;
            this.txtSevkAdres.Location = new System.Drawing.Point(123, 120);
            this.txtSevkAdres.Name = "txtSevkAdres";
            this.txtSevkAdres.Properties.AutoHeight = false;
            this.txtSevkAdres.Size = new System.Drawing.Size(579, 53);
            this.txtSevkAdres.TabIndex = 2;
            // 
            // cmbSevkAdresIlce
            // 
            this.cmbSevkAdresIlce.EnterMoveNextControl = true;
            this.cmbSevkAdresIlce.Location = new System.Drawing.Point(123, 83);
            this.cmbSevkAdresIlce.Name = "cmbSevkAdresIlce";
            this.cmbSevkAdresIlce.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSevkAdresIlce.Size = new System.Drawing.Size(247, 22);
            this.cmbSevkAdresIlce.TabIndex = 1;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl8.Location = new System.Drawing.Point(30, 137);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(51, 18);
            this.labelControl8.TabIndex = 3;
            this.labelControl8.Text = "ADRES";
            // 
            // cmbSevkAdresIL
            // 
            this.cmbSevkAdresIL.EnterMoveNextControl = true;
            this.cmbSevkAdresIL.Location = new System.Drawing.Point(123, 46);
            this.cmbSevkAdresIL.Name = "cmbSevkAdresIL";
            this.cmbSevkAdresIL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSevkAdresIL.Size = new System.Drawing.Size(247, 22);
            this.cmbSevkAdresIL.TabIndex = 0;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl7.Location = new System.Drawing.Point(30, 85);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(32, 18);
            this.labelControl7.TabIndex = 3;
            this.labelControl7.Text = "İLÇE";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl6.Location = new System.Drawing.Point(30, 48);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(11, 18);
            this.labelControl6.TabIndex = 3;
            this.labelControl6.Text = "İL";
            // 
            // btnSil
            // 
            this.btnSil.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSil.Appearance.Options.UseFont = true;
            this.btnSil.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSil.Image = ((System.Drawing.Image)(resources.GetObject("btnSil.Image")));
            this.btnSil.Location = new System.Drawing.Point(514, 2);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(115, 39);
            this.btnSil.TabIndex = 1;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnKaydet.Appearance.Options.UseFont = true;
            this.btnKaydet.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.Image")));
            this.btnKaydet.Location = new System.Drawing.Point(629, 2);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(115, 39);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // FrmCari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 550);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.txtCariAdi);
            this.Controls.Add(this.txtCariKodu);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "FrmCari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cari Tantım Kartı";
            ((System.ComponentModel.ISupportInitialize)(this.txtCariAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCariKodu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFaturaAdres.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFaturaAdresIlce.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFaturaAdresIL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSevkAdres.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSevkAdresIlce.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSevkAdresIL.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ButtonEdit txtCariAdi;
        private DevExpress.XtraEditors.ButtonEdit txtCariKodu;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TextEdit txtFaturaAdres;
        private DevExpress.XtraEditors.ComboBoxEdit cmbFaturaAdresIlce;
        private DevExpress.XtraEditors.ComboBoxEdit cmbFaturaAdresIL;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtSevkAdres;
        private DevExpress.XtraEditors.ComboBoxEdit cmbSevkAdresIlce;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.ComboBoxEdit cmbSevkAdresIL;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
    }
}