using DevExpress.XtraEditors;
using System;

namespace CrmPosHalYonetim.HksStokYonetim
{
    public partial class FrmOdemeTanim : XtraForm
    {
        public FrmOdemeTanim()
        {
            InitializeComponent();
        }
        StyOdemeTanimIslem odemeIslem = new StyOdemeTanimIslem();
        private void yeniEkran()
        {
            txtOdemeNo.Text = "";
            txtOdemeTanim.Text = "";
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOdemeNo.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ödeme No Girin");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtOdemeTanim.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ödeme Tanım Girin");
                return;
            }
            bool sonuc = odemeIslem.OdemeKaydet(new Entity.StyOdemeTanim
            {
                No = txtOdemeNo.Text,
                Tanim = txtOdemeTanim.Text,
            });
            if (sonuc)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Kaydetme Başarılı");
                yeniEkran();
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Kaydetme Başarısız. Lütfen hata loglarından kontrol edin");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOdemeNo.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ödeme No Girin");
                return;
            }
            if (DevExpress.XtraEditors.XtraMessageBox.Show("Silmek İstediğinizden Eminmisiniz?", "Uyarı", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (odemeIslem.OdemeSil(new Entity.StyOdemeTanim { No = txtOdemeNo.Text }))
                    yeniEkran();

            }
        }

        private void txtOdemeNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (FrmListe frm = new FrmListe(ListeType.Odeme))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.Tag != null)
                    {
                        var odeme = odemeIslem.OdemeGetir(frm.Tag.ToString());
                        if (odeme != null)
                        {
                            txtOdemeNo.Text = odeme.No;
                            txtOdemeTanim.Text = odeme.Tanim;
                        }
                    }
                }
            }
        }
    }
}
