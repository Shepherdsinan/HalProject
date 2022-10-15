namespace CrmPosHalYonetim.HksStokYonetim
{
    partial class FrmKasaTanim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKasaTanim));
            this.txtKasaTanim = new DevExpress.XtraEditors.ButtonEdit();
            this.txtKasaNo = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKasaTanim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKasaNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtKasaTanim
            // 
            this.txtKasaTanim.EnterMoveNextControl = true;
            this.txtKasaTanim.Location = new System.Drawing.Point(139, 86);
            this.txtKasaTanim.Name = "txtKasaTanim";
            this.txtKasaTanim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtKasaTanim.Size = new System.Drawing.Size(377, 22);
            this.txtKasaTanim.TabIndex = 20;
            this.txtKasaTanim.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txt_KasaButton_Click);
            // 
            // txtKasaNo
            // 
            this.txtKasaNo.EnterMoveNextControl = true;
            this.txtKasaNo.Location = new System.Drawing.Point(139, 48);
            this.txtKasaNo.Name = "txtKasaNo";
            this.txtKasaNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtKasaNo.Size = new System.Drawing.Size(176, 22);
            this.txtKasaNo.TabIndex = 19;
            this.txtKasaNo.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txt_KasaButton_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl2.Location = new System.Drawing.Point(31, 88);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(79, 18);
            this.labelControl2.TabIndex = 17;
            this.labelControl2.Text = "Kasa Tanım";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl1.Location = new System.Drawing.Point(31, 50);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 18);
            this.labelControl1.TabIndex = 18;
            this.labelControl1.Text = "Kasa No";
            // 
            // btnSil
            // 
            this.btnSil.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSil.Appearance.Options.UseFont = true;
            this.btnSil.Image = ((System.Drawing.Image)(resources.GetObject("btnSil.Image")));
            this.btnSil.Location = new System.Drawing.Point(280, 114);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(115, 25);
            this.btnSil.TabIndex = 22;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnKaydet.Appearance.Options.UseFont = true;
            this.btnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.Image")));
            this.btnKaydet.Location = new System.Drawing.Point(401, 114);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(115, 25);
            this.btnKaydet.TabIndex = 21;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(321, 50);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.checkEdit1.Properties.Appearance.Options.UseFont = true;
            this.checkEdit1.Properties.Caption = "İadelimi";
            this.checkEdit1.Size = new System.Drawing.Size(75, 22);
            this.checkEdit1.TabIndex = 23;
            // 
            // FrmKasaTanim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 187);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtKasaTanim);
            this.Controls.Add(this.txtKasaNo);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "FrmKasaTanim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kasa Tanım";
            ((System.ComponentModel.ISupportInitialize)(this.txtKasaTanim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKasaNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.ButtonEdit txtKasaTanim;
        private DevExpress.XtraEditors.ButtonEdit txtKasaNo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
    }
}