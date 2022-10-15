namespace CrmPosHalYonetim.HksStokYonetim
{
    partial class FrmKasaTransfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKasaTransfer));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clmKasa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbKasa = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.clmKasaMiktar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtMiktar = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.clmCariKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCariKodu = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.clmCariAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCariAdi = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtGirisIadeKasaMiktar = new DevExpress.XtraEditors.TextEdit();
            this.txtCikisIadeKasaMiktar = new DevExpress.XtraEditors.TextEdit();
            this.txtGirisKasaMiktar = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtCikisKasaMiktar = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblHammaliyeTutar = new DevExpress.XtraEditors.LabelControl();
            this.lblRusumKdv = new DevExpress.XtraEditors.LabelControl();
            this.txtCikisDepo = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtGirisDepo = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKasa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMiktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCariKodu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCariAdi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGirisIadeKasaMiktar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCikisIadeKasaMiktar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGirisKasaMiktar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCikisKasaMiktar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCikisDepo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGirisDepo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnKaydet, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.gridControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.13629F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.3399F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.688013F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1208, 609);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Appearance.Options.UseFont = true;
            this.btnKaydet.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.Image")));
            this.btnKaydet.Location = new System.Drawing.Point(1086, 552);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(119, 54);
            this.btnKaydet.TabIndex = 6;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Location = new System.Drawing.Point(3, 83);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.txtMiktar,
            this.cmbKasa,
            this.btnCariKodu,
            this.btnCariAdi});
            this.gridControl1.Size = new System.Drawing.Size(1202, 462);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Preview.Options.UseTextOptions = true;
            this.gridView1.Appearance.Preview.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clmKasa,
            this.clmKasaMiktar,
            this.clmCariKodu,
            this.clmCariAdi});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowRowSizing = true;
            this.gridView1.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView1.OptionsDetail.AllowOnlyOneMasterRowExpanded = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsSelection.InvertSelection = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 25;
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            // 
            // clmKasa
            // 
            this.clmKasa.Caption = "Kasa";
            this.clmKasa.ColumnEdit = this.cmbKasa;
            this.clmKasa.FieldName = "Kasa";
            this.clmKasa.Name = "clmKasa";
            this.clmKasa.Visible = true;
            this.clmKasa.VisibleIndex = 2;
            this.clmKasa.Width = 211;
            // 
            // cmbKasa
            // 
            this.cmbKasa.AutoHeight = false;
            this.cmbKasa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbKasa.Name = "cmbKasa";
            this.cmbKasa.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // clmKasaMiktar
            // 
            this.clmKasaMiktar.Caption = "Kasa Adet";
            this.clmKasaMiktar.ColumnEdit = this.txtMiktar;
            this.clmKasaMiktar.FieldName = "KasaMiktar";
            this.clmKasaMiktar.Name = "clmKasaMiktar";
            this.clmKasaMiktar.Visible = true;
            this.clmKasaMiktar.VisibleIndex = 3;
            this.clmKasaMiktar.Width = 258;
            // 
            // txtMiktar
            // 
            this.txtMiktar.AutoHeight = false;
            this.txtMiktar.DisplayFormat.FormatString = "n2";
            this.txtMiktar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMiktar.Mask.EditMask = "n2";
            this.txtMiktar.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMiktar.Name = "txtMiktar";
            // 
            // clmCariKodu
            // 
            this.clmCariKodu.Caption = "Cari Kodu";
            this.clmCariKodu.ColumnEdit = this.btnCariKodu;
            this.clmCariKodu.FieldName = "CariKodu";
            this.clmCariKodu.Name = "clmCariKodu";
            this.clmCariKodu.Visible = true;
            this.clmCariKodu.VisibleIndex = 0;
            this.clmCariKodu.Width = 120;
            // 
            // btnCariKodu
            // 
            this.btnCariKodu.AutoHeight = false;
            this.btnCariKodu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnCariKodu.Name = "btnCariKodu";
            this.btnCariKodu.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnCariKodu_ButtonClick);
            // 
            // clmCariAdi
            // 
            this.clmCariAdi.Caption = "Cari Adı";
            this.clmCariAdi.ColumnEdit = this.btnCariAdi;
            this.clmCariAdi.FieldName = "CariAdi";
            this.clmCariAdi.Name = "clmCariAdi";
            this.clmCariAdi.Visible = true;
            this.clmCariAdi.VisibleIndex = 1;
            this.clmCariAdi.Width = 161;
            // 
            // btnCariAdi
            // 
            this.btnCariAdi.AutoHeight = false;
            this.btnCariAdi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnCariAdi.Name = "btnCariAdi";
            this.btnCariAdi.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnCariAdi_ButtonClick);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtGirisIadeKasaMiktar);
            this.panelControl1.Controls.Add(this.txtCikisIadeKasaMiktar);
            this.panelControl1.Controls.Add(this.txtGirisKasaMiktar);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.txtCikisKasaMiktar);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.lblHammaliyeTutar);
            this.panelControl1.Controls.Add(this.lblRusumKdv);
            this.panelControl1.Controls.Add(this.txtCikisDepo);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtGirisDepo);
            this.panelControl1.Controls.Add(this.labelControl12);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1202, 73);
            this.panelControl1.TabIndex = 0;
            // 
            // txtGirisIadeKasaMiktar
            // 
            this.txtGirisIadeKasaMiktar.Enabled = false;
            this.txtGirisIadeKasaMiktar.EnterMoveNextControl = true;
            this.txtGirisIadeKasaMiktar.Location = new System.Drawing.Point(586, 35);
            this.txtGirisIadeKasaMiktar.Name = "txtGirisIadeKasaMiktar";
            this.txtGirisIadeKasaMiktar.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.txtGirisIadeKasaMiktar.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtGirisIadeKasaMiktar.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtGirisIadeKasaMiktar.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtGirisIadeKasaMiktar.Properties.DisplayFormat.FormatString = "n2";
            this.txtGirisIadeKasaMiktar.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtGirisIadeKasaMiktar.Properties.Mask.EditMask = "n2";
            this.txtGirisIadeKasaMiktar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtGirisIadeKasaMiktar.Size = new System.Drawing.Size(174, 22);
            this.txtGirisIadeKasaMiktar.TabIndex = 39;
            // 
            // txtCikisIadeKasaMiktar
            // 
            this.txtCikisIadeKasaMiktar.Enabled = false;
            this.txtCikisIadeKasaMiktar.EnterMoveNextControl = true;
            this.txtCikisIadeKasaMiktar.Location = new System.Drawing.Point(586, 6);
            this.txtCikisIadeKasaMiktar.Name = "txtCikisIadeKasaMiktar";
            this.txtCikisIadeKasaMiktar.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.txtCikisIadeKasaMiktar.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtCikisIadeKasaMiktar.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtCikisIadeKasaMiktar.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtCikisIadeKasaMiktar.Properties.DisplayFormat.FormatString = "n2";
            this.txtCikisIadeKasaMiktar.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCikisIadeKasaMiktar.Properties.Mask.EditMask = "n2";
            this.txtCikisIadeKasaMiktar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCikisIadeKasaMiktar.Size = new System.Drawing.Size(174, 22);
            this.txtCikisIadeKasaMiktar.TabIndex = 39;
            // 
            // txtGirisKasaMiktar
            // 
            this.txtGirisKasaMiktar.Enabled = false;
            this.txtGirisKasaMiktar.EnterMoveNextControl = true;
            this.txtGirisKasaMiktar.Location = new System.Drawing.Point(986, 35);
            this.txtGirisKasaMiktar.Name = "txtGirisKasaMiktar";
            this.txtGirisKasaMiktar.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.txtGirisKasaMiktar.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtGirisKasaMiktar.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtGirisKasaMiktar.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtGirisKasaMiktar.Properties.DisplayFormat.FormatString = "n2";
            this.txtGirisKasaMiktar.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtGirisKasaMiktar.Properties.Mask.EditMask = "n2";
            this.txtGirisKasaMiktar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtGirisKasaMiktar.Size = new System.Drawing.Size(174, 22);
            this.txtGirisKasaMiktar.TabIndex = 40;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl3.Location = new System.Drawing.Point(766, 37);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(204, 18);
            this.labelControl3.TabIndex = 42;
            this.labelControl3.Text = "Giriş Depo İadesiz Kasa Miktar";
            // 
            // txtCikisKasaMiktar
            // 
            this.txtCikisKasaMiktar.Enabled = false;
            this.txtCikisKasaMiktar.EnterMoveNextControl = true;
            this.txtCikisKasaMiktar.Location = new System.Drawing.Point(986, 6);
            this.txtCikisKasaMiktar.Name = "txtCikisKasaMiktar";
            this.txtCikisKasaMiktar.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.txtCikisKasaMiktar.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.txtCikisKasaMiktar.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.txtCikisKasaMiktar.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtCikisKasaMiktar.Properties.DisplayFormat.FormatString = "n2";
            this.txtCikisKasaMiktar.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCikisKasaMiktar.Properties.Mask.EditMask = "n2";
            this.txtCikisKasaMiktar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCikisKasaMiktar.Size = new System.Drawing.Size(174, 22);
            this.txtCikisKasaMiktar.TabIndex = 40;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl2.Location = new System.Drawing.Point(390, 37);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(188, 18);
            this.labelControl2.TabIndex = 43;
            this.labelControl2.Text = "Giriş Depo İade Kasa Miktari";
            // 
            // lblHammaliyeTutar
            // 
            this.lblHammaliyeTutar.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblHammaliyeTutar.Location = new System.Drawing.Point(766, 8);
            this.lblHammaliyeTutar.Name = "lblHammaliyeTutar";
            this.lblHammaliyeTutar.Size = new System.Drawing.Size(206, 18);
            this.lblHammaliyeTutar.TabIndex = 42;
            this.lblHammaliyeTutar.Text = "Çıkış Depo İadesiz Kasa Miktar";
            // 
            // lblRusumKdv
            // 
            this.lblRusumKdv.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblRusumKdv.Location = new System.Drawing.Point(390, 8);
            this.lblRusumKdv.Name = "lblRusumKdv";
            this.lblRusumKdv.Size = new System.Drawing.Size(190, 18);
            this.lblRusumKdv.TabIndex = 43;
            this.lblRusumKdv.Text = "Çıkış Depo İade Kasa Miktari";
            // 
            // txtCikisDepo
            // 
            this.txtCikisDepo.EnterMoveNextControl = true;
            this.txtCikisDepo.Location = new System.Drawing.Point(135, 6);
            this.txtCikisDepo.Name = "txtCikisDepo";
            this.txtCikisDepo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F10), serializableAppearanceObject1, "", null, null, true)});
            this.txtCikisDepo.Size = new System.Drawing.Size(216, 22);
            this.txtCikisDepo.TabIndex = 34;
            this.txtCikisDepo.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtCikisDepo_ButtonClick);
            this.txtCikisDepo.Validated += new System.EventHandler(this.txtCikisDepo_Validated);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl1.Location = new System.Drawing.Point(23, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(71, 18);
            this.labelControl1.TabIndex = 36;
            this.labelControl1.Text = "Giriş Depo";
            // 
            // txtGirisDepo
            // 
            this.txtGirisDepo.EnterMoveNextControl = true;
            this.txtGirisDepo.Location = new System.Drawing.Point(135, 35);
            this.txtGirisDepo.Name = "txtGirisDepo";
            this.txtGirisDepo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F10), serializableAppearanceObject2, "", null, null, true)});
            this.txtGirisDepo.Size = new System.Drawing.Size(216, 22);
            this.txtGirisDepo.TabIndex = 35;
            this.txtGirisDepo.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtGirisDepo_ButtonClick);
            this.txtGirisDepo.Validated += new System.EventHandler(this.txtGirisDepo_Validated);
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl12.Location = new System.Drawing.Point(23, 8);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(73, 18);
            this.labelControl12.TabIndex = 37;
            this.labelControl12.Text = "Çıkış Depo";
            // 
            // FrmKasaTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 609);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmKasaTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Depolar Arası Kasa Transfer";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKasa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMiktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCariKodu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCariAdi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGirisIadeKasaMiktar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCikisIadeKasaMiktar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGirisKasaMiktar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCikisKasaMiktar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCikisDepo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGirisDepo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ButtonEdit txtCikisDepo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ButtonEdit txtGirisDepo;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn clmKasa;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmbKasa;
        private DevExpress.XtraGrid.Columns.GridColumn clmKasaMiktar;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtMiktar;
        private DevExpress.XtraEditors.TextEdit txtCikisIadeKasaMiktar;
        private DevExpress.XtraEditors.TextEdit txtCikisKasaMiktar;
        private DevExpress.XtraEditors.LabelControl lblHammaliyeTutar;
        private DevExpress.XtraEditors.LabelControl lblRusumKdv;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.TextEdit txtGirisIadeKasaMiktar;
        private DevExpress.XtraEditors.TextEdit txtGirisKasaMiktar;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn clmCariKodu;
        private DevExpress.XtraGrid.Columns.GridColumn clmCariAdi;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnCariKodu;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnCariAdi;

    }
}