namespace CrmPosHalYonetim.HksStokYonetim
{
    partial class FrmDepoTanitim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDepoTanitim));
            this.txtDepoTanim = new DevExpress.XtraEditors.ButtonEdit();
            this.txtDepoNo = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepoTanim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepoNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDepoTanim
            // 
            this.txtDepoTanim.EnterMoveNextControl = true;
            this.txtDepoTanim.Location = new System.Drawing.Point(133, 74);
            this.txtDepoTanim.Name = "txtDepoTanim";
            this.txtDepoTanim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDepoTanim.Size = new System.Drawing.Size(377, 22);
            this.txtDepoTanim.TabIndex = 6;
            this.txtDepoTanim.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txt_DepoButton_Click);
            // 
            // txtDepoNo
            // 
            this.txtDepoNo.EnterMoveNextControl = true;
            this.txtDepoNo.Location = new System.Drawing.Point(133, 36);
            this.txtDepoNo.Name = "txtDepoNo";
            this.txtDepoNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDepoNo.Size = new System.Drawing.Size(176, 22);
            this.txtDepoNo.TabIndex = 5;
            this.txtDepoNo.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txt_DepoButton_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl2.Location = new System.Drawing.Point(25, 76);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(81, 18);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Depo Tanım";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelControl1.Location = new System.Drawing.Point(25, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 18);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Depo No";
            // 
            // btnSil
            // 
            this.btnSil.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSil.Appearance.Options.UseFont = true;
            this.btnSil.Image = ((System.Drawing.Image)(resources.GetObject("btnSil.Image")));
            this.btnSil.Location = new System.Drawing.Point(274, 102);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(115, 25);
            this.btnSil.TabIndex = 16;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnKaydet.Appearance.Options.UseFont = true;
            this.btnKaydet.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.Image")));
            this.btnKaydet.Location = new System.Drawing.Point(395, 102);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(115, 25);
            this.btnKaydet.TabIndex = 15;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // FrmDepoTanitim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 162);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtDepoTanim);
            this.Controls.Add(this.txtDepoNo);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "FrmDepoTanitim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Depo Tanıtım Kartı";
            this.Load += new System.EventHandler(this.FrmDepoTanitim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDepoTanim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepoNo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ButtonEdit txtDepoTanim;
        private DevExpress.XtraEditors.ButtonEdit txtDepoNo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
    }
}