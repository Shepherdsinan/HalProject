using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CrmPosHalYonetim.HksStokYonetim
{
    public partial class FrmKasaTanim : XtraForm
    {
        public FrmKasaTanim()
        {
            InitializeComponent();
        }
        StyKasaIslem kasaIslem = new StyKasaIslem();
        private void yeniEkran()
        {
            txtKasaNo.Text = "";
            txtKasaTanim.Text = "";
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKasaNo.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Kasa No Girin");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtKasaTanim.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Kasa Tanım Girin");
                return;
            }
            bool sonuc = kasaIslem.KasaKaydet(new Entity.StyKasa
            {
                No = txtKasaNo.Text,
                Tanim = txtKasaTanim.Text,
                Iadelimi = checkEdit1.Checked
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
            if (string.IsNullOrWhiteSpace(txtKasaNo.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Kasa No Girin");
                return;
            }
            if (DevExpress.XtraEditors.XtraMessageBox.Show("Silmek İstediğinizden Eminmisiniz?", "Uyarı", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (kasaIslem.KasaSil(new Entity.StyKasa { No = txtKasaNo.Text }))
                    yeniEkran();

            }
        }

        private void txt_KasaButton_Click(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (FrmListe frm = new FrmListe(ListeType.Kasa))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.Tag != null)
                    {
                        var kasa = kasaIslem.KasaGetir(frm.Tag.ToString());
                        if (kasa != null)
                        {
                            txtKasaNo.Text = kasa.No;
                            txtKasaTanim.Text = kasa.Tanim;
                            checkEdit1.Checked = kasa.Iadelimi.Value;
                        }
                    }
                }
            }
        }
    }
}
