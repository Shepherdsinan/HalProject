namespace CrmPosHalYonetim
{
    partial class FrmHata
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
            this.txtHatali = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtHatali
            // 
            this.txtHatali.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHatali.Location = new System.Drawing.Point(0, 0);
            this.txtHatali.Multiline = true;
            this.txtHatali.Name = "txtHatali";
            this.txtHatali.Size = new System.Drawing.Size(868, 649);
            this.txtHatali.TabIndex = 0;
            // 
            // FrmHata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 649);
            this.Controls.Add(this.txtHatali);
            this.Name = "FrmHata";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gönderilemeyen Künyeler";
            this.Load += new System.EventHandler(this.FrmHata_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHatali;

    }
}