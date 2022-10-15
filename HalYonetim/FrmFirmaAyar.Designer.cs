namespace HalYonetim
{
    partial class FrmFirmaAyar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFirmaAyar));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.cmbSifat = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.txtSifre = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.category = new DevExpress.XtraVerticalGrid.Rows.CategoryRow();
            this.rwTcVgNo = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rwSifati = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rwSifre = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rwServisSifresi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rwID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSifat)).BeginInit();
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
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(628, 560);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // vGridControl1
            // 
            this.vGridControl1.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.vGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridControl1.Location = new System.Drawing.Point(4, 53);
            this.vGridControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.RecordWidth = 508;
            this.vGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cmbSifat,
            this.txtSifre});
            this.vGridControl1.RowHeaderWidth = 208;
            this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.category,
            this.rwTcVgNo,
            this.rwSifati,
            this.rwSifre,
            this.rwServisSifresi,
            this.rwID});
            this.vGridControl1.Size = new System.Drawing.Size(620, 503);
            this.vGridControl1.TabIndex = 1;
            // 
            // cmbSifat
            // 
            this.cmbSifat.AutoHeight = false;
            this.cmbSifat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSifat.Name = "cmbSifat";
            this.cmbSifat.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // txtSifre
            // 
            this.txtSifre.AutoHeight = false;
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            // 
            // category
            // 
            this.category.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.category.Appearance.Options.UseFont = true;
            this.category.Name = "category";
            this.category.Properties.Caption = "Firma Bilgileri";
            // 
            // rwTcVgNo
            // 
            this.rwTcVgNo.Name = "rwTcVgNo";
            this.rwTcVgNo.Properties.Caption = "T.C. Kimlik / Vergi No";
            this.rwTcVgNo.Properties.FieldName = "TcVgNo";
            // 
            // rwSifati
            // 
            this.rwSifati.Name = "rwSifati";
            this.rwSifati.Properties.Caption = "Firma Sıfat";
            this.rwSifati.Properties.FieldName = "Sifati";
            this.rwSifati.Properties.RowEdit = this.cmbSifat;
            // 
            // rwSifre
            // 
            this.rwSifre.Name = "rwSifre";
            this.rwSifre.Properties.Caption = "Şifre";
            this.rwSifre.Properties.FieldName = "Sifre";
            this.rwSifre.Properties.RowEdit = this.txtSifre;
            // 
            // rwServisSifresi
            // 
            this.rwServisSifresi.Name = "rwServisSifresi";
            this.rwServisSifresi.Properties.Caption = "Servis Şifresi";
            this.rwServisSifresi.Properties.FieldName = "ServisSifresi";
            this.rwServisSifresi.Properties.RowEdit = this.txtSifre;
            // 
            // rwID
            // 
            this.rwID.Name = "rwID";
            this.rwID.Properties.FieldName = "ID";
            this.rwID.Visible = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(4, 4);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(620, 41);
            this.panelControl1.TabIndex = 2;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButton2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.Image")));
            this.simpleButton2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton2.Location = new System.Drawing.Point(65, 2);
            this.simpleButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(63, 37);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton1.Location = new System.Drawing.Point(2, 2);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(63, 37);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // FrmFirmaAyar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmFirmaAyar";
            this.Size = new System.Drawing.Size(628, 560);
            this.Load += new System.EventHandler(this.FrmFirmaAyar_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSifat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSifre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmbSifat;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtSifre;
        private DevExpress.XtraVerticalGrid.Rows.CategoryRow category;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rwTcVgNo;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rwSifati;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rwSifre;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rwServisSifresi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rwID;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}
