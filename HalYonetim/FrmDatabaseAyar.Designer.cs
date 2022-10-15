namespace HalYonetim
{
    partial class FrmDatabaseAyar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDatabaseAyar));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.cmbOturumAcmaSekli = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.txtSifre = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.category = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rwSunucuAdi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rwVeritabani = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rwOturumAcmaSekli = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rwKullaniciAdi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rwSifre = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOturumAcmaSekli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.vGridControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(593, 440);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // vGridControl1
            // 
            this.vGridControl1.BandsInterval = 1;
            this.vGridControl1.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.vGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridControl1.Location = new System.Drawing.Point(3, 43);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.OptionsView.FixedLineWidth = 1;
            this.vGridControl1.RecordWidth = 381;
            this.vGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cmbOturumAcmaSekli,
            this.txtSifre});
            this.vGridControl1.RowHeaderWidth = 156;
            this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.category,
            this.rwSunucuAdi,
            this.rwVeritabani,
            this.rwOturumAcmaSekli,
            this.rwKullaniciAdi,
            this.rwSifre});
            this.vGridControl1.Size = new System.Drawing.Size(587, 394);
            this.vGridControl1.TabIndex = 1;
            // 
            // cmbOturumAcmaSekli
            // 
            this.cmbOturumAcmaSekli.AutoHeight = false;
            this.cmbOturumAcmaSekli.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbOturumAcmaSekli.Items.AddRange(new object[] {
            "SQL",
            "WINDOWS"});
            this.cmbOturumAcmaSekli.Name = "cmbOturumAcmaSekli";
            this.cmbOturumAcmaSekli.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // txtSifre
            // 
            this.txtSifre.AutoHeight = false;
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            // 
            // category
            // 
            this.category.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.category.AppearanceCell.Options.UseFont = true;
            this.category.Name = "category";
            this.category.Properties.Caption = "Veritabanı Bağlantı Bilgileri";
            // 
            // rwSunucuAdi
            // 
            this.rwSunucuAdi.Name = "rwSunucuAdi";
            this.rwSunucuAdi.Properties.Caption = "Sunucu Adı";
            this.rwSunucuAdi.Properties.FieldName = "SunucuAdi";
            // 
            // rwVeritabani
            // 
            this.rwVeritabani.Name = "rwVeritabani";
            this.rwVeritabani.Properties.Caption = "Veritabani";
            this.rwVeritabani.Properties.FieldName = "Veritabani";
            // 
            // rwOturumAcmaSekli
            // 
            this.rwOturumAcmaSekli.Name = "rwOturumAcmaSekli";
            this.rwOturumAcmaSekli.Properties.Caption = "Oturum Açma Şekli";
            this.rwOturumAcmaSekli.Properties.FieldName = "OturumAcmaSekli";
            this.rwOturumAcmaSekli.Properties.RowEdit = this.cmbOturumAcmaSekli;
            // 
            // rwKullaniciAdi
            // 
            this.rwKullaniciAdi.Name = "rwKullaniciAdi";
            this.rwKullaniciAdi.Properties.Caption = "Kullanıcı Adı";
            this.rwKullaniciAdi.Properties.FieldName = "KullaniciAdi";
            // 
            // rwSifre
            // 
            this.rwSifre.Name = "rwSifre";
            this.rwSifre.Properties.Caption = "Şifre";
            this.rwSifre.Properties.FieldName = "Sifre";
            this.rwSifre.Properties.RowEdit = this.txtSifre;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(587, 34);
            this.panelControl1.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton1.Location = new System.Drawing.Point(2, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(47, 30);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // FrmDatabaseAyar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmDatabaseAyar";
            this.Size = new System.Drawing.Size(593, 440);
            this.Load += new System.EventHandler(this.FrmDatabaseAyar_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOturumAcmaSekli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmbOturumAcmaSekli;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtSifre;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow category;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rwSunucuAdi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rwVeritabani;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rwOturumAcmaSekli;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rwKullaniciAdi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rwSifre;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}
