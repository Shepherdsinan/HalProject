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
    public partial class FrmCariTanitim : XtraForm
    {
        public FrmCariTanitim()
        {
            InitializeComponent();
            this.Load += FrmCari_Load;
        }
        StyCariIslem cariIslem = new StyCariIslem();
        private void yeniEkran()
        {
            txtCariKodu.Text = "";
            txtCariAdi.Text = "";

            cmbFaturaAdresIL.Properties.Items.Clear();
            cmbFaturaAdresIlce.Properties.Items.Clear();
            cmbSevkAdresIL.Properties.Items.Clear();
            cmbSevkAdresIlce.Properties.Items.Clear();

            cmbFaturaAdresIL.Text = "";
            cmbFaturaAdresIlce.Text = "";
            cmbSevkAdresIL.Text = "";
            cmbSevkAdresIlce.Text = "";
            List<string> ilisimleri = cariIslem.FaturaILIsimleri();
            cmbFaturaAdresIL.Properties.Items.AddRange(ilisimleri.ToArray());
            cmbSevkAdresIL.Properties.Items.AddRange(ilisimleri.ToArray());
            List<string> ilceisimleri = cariIslem.FaturaIlceIsimleri();
            cmbSevkAdresIlce.Properties.Items.AddRange(ilceisimleri.ToArray());
            cmbFaturaAdresIlce.Properties.Items.AddRange(ilceisimleri.ToArray());
        }
        void FrmCari_Load(object sender, EventArgs e)
        {
            yeniEkran();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCariKodu.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Cari Kodu Girin");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCariAdi.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Cari Adı Girin");
                return;
            }
            bool sonuc = cariIslem.CariKaydet(new Entity.StyCari
            {
                Kodu = txtCariKodu.Text,
                Adi = txtCariAdi.Text,
                FaturaAdres_IL = cmbFaturaAdresIL.Text,
                FaturaAdresIlce = cmbFaturaAdresIlce.Text,
                FaturaAdres = txtFaturaAdres.Text,
                SevkAdresIL = cmbSevkAdresIL.Text,
                SevkAdresIlce = cmbSevkAdresIlce.Text,
                SevkAdres = txtSevkAdres.Text,
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
            if (string.IsNullOrWhiteSpace(txtCariKodu.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Cari Kodu Girin");
                return;
            }
            if (DevExpress.XtraEditors.XtraMessageBox.Show("Silmek İstediğinizden Eminmisiniz?", "Uyarı", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (cariIslem.CariSil(new Entity.StyCari { Kodu = txtCariKodu.Text }))
                {
                    yeniEkran();
                }
            }
        }

        private void txt_CariButton_Click(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (FrmListe frm = new FrmListe(ListeType.Cari))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.Tag != null)
                    {
                        var cari = cariIslem.CariGetir(frm.Tag.ToString());
                        if (cari != null)
                        {
                            txtCariKodu.Text = cari.Kodu;
                            txtCariAdi.Text = cari.Adi;
                            cmbFaturaAdresIL.Text = cari.FaturaAdres_IL;
                            cmbFaturaAdresIlce.Text = cari.FaturaAdresIlce;
                            txtFaturaAdres.Text = cari.FaturaAdres;
                            cmbSevkAdresIL.Text = cari.SevkAdresIL;
                            cmbSevkAdresIlce.Text = cari.SevkAdresIlce;
                            txtSevkAdres.Text = cari.SevkAdres;
                        }
                    }
                }
            }
        }
    }
}
