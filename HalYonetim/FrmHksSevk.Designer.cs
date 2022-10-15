namespace HalYonetim
{
    partial class FrmHksSevk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHksSevk));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnKalanMiktarEsitle = new DevExpress.XtraEditors.SimpleButton();
            this.dtSonTarih = new DevExpress.XtraEditors.DateEdit();
            this.dtIlkTarih = new DevExpress.XtraEditors.DateEdit();
            this.btnSevk = new DevExpress.XtraEditors.SimpleButton();
            this.btnListele = new DevExpress.XtraEditors.SimpleButton();
            this.cmbKunyeTuru = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtSonTarih.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSonTarih.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIlkTarih.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIlkTarih.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKunyeTuru.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1270, 662);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(4, 106);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1262, 552);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnKalanMiktarEsitle);
            this.panelControl1.Controls.Add(this.dtSonTarih);
            this.panelControl1.Controls.Add(this.dtIlkTarih);
            this.panelControl1.Controls.Add(this.btnSevk);
            this.panelControl1.Controls.Add(this.btnListele);
            this.panelControl1.Controls.Add(this.cmbKunyeTuru);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1264, 96);
            this.panelControl1.TabIndex = 3;
            // 
            // btnKalanMiktarEsitle
            // 
            this.btnKalanMiktarEsitle.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKalanMiktarEsitle.Appearance.Options.UseFont = true;
            this.btnKalanMiktarEsitle.Appearance.Options.UseTextOptions = true;
            this.btnKalanMiktarEsitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnKalanMiktarEsitle.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnKalanMiktarEsitle.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnKalanMiktarEsitle.Image = ((System.Drawing.Image)(resources.GetObject("btnKalanMiktarEsitle.Image")));
            this.btnKalanMiktarEsitle.Location = new System.Drawing.Point(1010, 2);
            this.btnKalanMiktarEsitle.Name = "btnKalanMiktarEsitle";
            this.btnKalanMiktarEsitle.Size = new System.Drawing.Size(126, 92);
            this.btnKalanMiktarEsitle.TabIndex = 9;
            this.btnKalanMiktarEsitle.Text = "Kalan Miktarı Eşitle";
            this.btnKalanMiktarEsitle.Click += new System.EventHandler(this.btnKalanMiktarEsitle_Click);
            // 
            // dtSonTarih
            // 
            this.dtSonTarih.EditValue = null;
            this.dtSonTarih.Location = new System.Drawing.Point(305, 59);
            this.dtSonTarih.Name = "dtSonTarih";
            this.dtSonTarih.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtSonTarih.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtSonTarih.Size = new System.Drawing.Size(166, 22);
            this.dtSonTarih.TabIndex = 8;
            // 
            // dtIlkTarih
            // 
            this.dtIlkTarih.EditValue = null;
            this.dtIlkTarih.Location = new System.Drawing.Point(133, 59);
            this.dtIlkTarih.Name = "dtIlkTarih";
            this.dtIlkTarih.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtIlkTarih.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtIlkTarih.Size = new System.Drawing.Size(166, 22);
            this.dtIlkTarih.TabIndex = 8;
            // 
            // btnSevk
            // 
            this.btnSevk.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSevk.Appearance.Options.UseFont = true;
            this.btnSevk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSevk.Image = ((System.Drawing.Image)(resources.GetObject("btnSevk.Image")));
            this.btnSevk.Location = new System.Drawing.Point(1136, 2);
            this.btnSevk.Name = "btnSevk";
            this.btnSevk.Size = new System.Drawing.Size(126, 92);
            this.btnSevk.TabIndex = 7;
            this.btnSevk.Text = "Sevk Et";
            this.btnSevk.Visible = false;
            this.btnSevk.Click += new System.EventHandler(this.btnSevk_Click);
            // 
            // btnListele
            // 
            this.btnListele.Image = ((System.Drawing.Image)(resources.GetObject("btnListele.Image")));
            this.btnListele.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnListele.Location = new System.Drawing.Point(487, 56);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(83, 29);
            this.btnListele.TabIndex = 6;
            this.btnListele.Click += new System.EventHandler(this.btnListele_Click);
            // 
            // cmbKunyeTuru
            // 
            this.cmbKunyeTuru.EditValue = "Referans";
            this.cmbKunyeTuru.EnterMoveNextControl = true;
            this.cmbKunyeTuru.Location = new System.Drawing.Point(133, 23);
            this.cmbKunyeTuru.Margin = new System.Windows.Forms.Padding(4);
            this.cmbKunyeTuru.Name = "cmbKunyeTuru";
            this.cmbKunyeTuru.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbKunyeTuru.Properties.Items.AddRange(new object[] {
            "Seçiniz...",
            "Referans",
            "Nihai Tüketim"});
            this.cmbKunyeTuru.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbKunyeTuru.Size = new System.Drawing.Size(166, 22);
            this.cmbKunyeTuru.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Location = new System.Drawing.Point(53, 62);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(32, 16);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Tarih";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Location = new System.Drawing.Point(53, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(73, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Künye Türü";
            // 
            // FrmHksSevk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmHksSevk";
            this.Size = new System.Drawing.Size(1270, 662);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtSonTarih.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtSonTarih.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIlkTarih.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIlkTarih.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKunyeTuru.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbKunyeTuru;
        private DevExpress.XtraEditors.SimpleButton btnListele;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnSevk;
        private DevExpress.XtraEditors.DateEdit dtSonTarih;
        private DevExpress.XtraEditors.DateEdit dtIlkTarih;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnKalanMiktarEsitle;

    }
}
