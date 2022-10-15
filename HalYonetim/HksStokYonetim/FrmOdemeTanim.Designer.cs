namespace CrmPosHalYonetim.HksStokYonetim
{
    partial class FrmOdemeTanim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOdemeTanim));
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.txtOdemeTanim = new DevExpress.XtraEditors.ButtonEdit();
            this.txtOdemeNo = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtOdemeTanim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOdemeNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSil
            // 
            this.btnSil.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSil.Appearance.Options.UseFont = true;
            this.btnSil.Image = ((System.Drawing.Image)(resources.GetObject("btnSil.Image")));
            this.btnSil.Location = new System.Drawing.Point(286, 104);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(101, 25);
            this.btnSil.TabIndex = 29;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnKaydet.Appearance.Options.UseFont = true;
            this.btnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.Image")));
            this.btnKaydet.Location = new System.Drawing.Point(392, 104);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(101, 25);
            this.btnKaydet.TabIndex = 28;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtOdemeTanim
            // 
            this.txtOdemeTanim.EnterMoveNextControl = true;
            this.txtOdemeTanim.Location = new System.Drawing.Point(163, 76);
            this.txtOdemeTanim.Name = "txtOdemeTanim";
            this.txtOdemeTanim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtOdemeTanim.Size = new System.Drawing.Size(330, 22);
            this.txtOdemeTanim.TabIndex = 27;
            this.txtOdemeTanim.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtOdemeNo_ButtonClick);
            // 
            // txtOdemeNo
            // 
            this.txtOdemeNo.EnterMoveNextControl = true;
            this.txtOdemeNo.Location = new System.Drawing.Point(163, 38);
            this.txtOdemeNo.Name = "txtOdemeNo";
            this.txtOdemeNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtOdemeNo.Size = new System.Drawing.Size(154, 22);
            this.txtOdemeNo.TabIndex = 26;
            this.txtOdemeNo.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtOdemeNo_ButtonClick);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl2.Location = new System.Drawing.Point(64, 78);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(94, 18);
            this.labelControl2.TabIndex = 24;
            this.labelControl2.Text = "Ödeme Tanım";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl1.Location = new System.Drawing.Point(64, 40);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(73, 18);
            this.labelControl1.TabIndex = 25;
            this.labelControl1.Text = "Ödeme No";
            // 
            // FrmOdemeTanim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 166);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtOdemeTanim);
            this.Controls.Add(this.txtOdemeNo);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "FrmOdemeTanim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ödeme Tanım";
            ((System.ComponentModel.ISupportInitialize)(this.txtOdemeTanim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOdemeNo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.ButtonEdit txtOdemeTanim;
        private DevExpress.XtraEditors.ButtonEdit txtOdemeNo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}