using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;

namespace CrmPosHalYonetim.HksStokYonetim
{
    public partial class FrmStokTanitim : XtraForm
    {
        public FrmStokTanitim()
        {
            InitializeComponent();
        }
        StyStokIslem stokIslem = new StyStokIslem();
        private void yeniEkran()
        {
            txtStokKodu.Text = "";
            txtStokAdi.Text = "";
            txtFiyat.Text = "0";
            txtBirim1.Text = "0";
            txtBirim2.Text = "0";
            txtBirim3.Text = "0";
            txtBirim4.Text = "0";
            cmbBirim1.Properties.Items.Clear();
            cmbBirim2.Properties.Items.Clear();
            cmbBirim3.Properties.Items.Clear();
            cmbBirim4.Properties.Items.Clear();
            cmbVergi.Properties.Items.Clear();

            cmbBirim1.Text = "";
            cmbBirim2.Text = "";
            cmbBirim3.Text = "";
            cmbBirim4.Text = "";
            cmbVergi.Text = "";
            List<string> birimler = stokIslem.BirimIsimleri();
            cmbBirim1.Properties.Items.AddRange(birimler.ToArray());
            cmbBirim2.Properties.Items.AddRange(birimler.ToArray());
            cmbBirim3.Properties.Items.AddRange(birimler.ToArray());
            cmbBirim4.Properties.Items.AddRange(birimler.ToArray());
            cmbVergi.Properties.Items.AddRange(stokIslem.Kdvler().ToArray());
        }
        private void FrmStokTanitim_Load(object sender, EventArgs e)
        {
            yeniEkran();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStokKodu.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Stok Kodu Girin");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtStokAdi.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Stok Adı Girin");
                return;
            }
            if (cmbVergi.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Vergi Girin");
                return;
            }
            bool sonuc = stokIslem.StokKaydet(new Entity.StyStok
            {
                Kodu = txtStokKodu.Text,
                KdvOran = Convert.ToDouble(cmbVergi.Text),
                Fiyat = txtFiyat.Text == "" ? 0 : Convert.ToDouble(txtFiyat.Text),
                Adi = txtStokAdi.Text,
                Birim4 = cmbBirim4.Text,
                Birim3 = cmbBirim3.Text,
                Birim2 = cmbBirim2.Text,
                Birim1 = cmbBirim1.Text,
                Katsayi1 = txtBirim1.Text != "" ? Convert.ToDouble(txtBirim1.Text) : 0,
                Katsayi2 = txtBirim2.Text != "" ? Convert.ToDouble(txtBirim2.Text) : 0,
                Katsayi3 = txtBirim3.Text != "" ? Convert.ToDouble(txtBirim3.Text) : 0,
                Katsayi4 = txtBirim4.Text != "" ? Convert.ToDouble(txtBirim4.Text) : 0,
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
            if (string.IsNullOrWhiteSpace(txtStokKodu.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Stok Kodu Girin");
                return;
            }
            if (DevExpress.XtraEditors.XtraMessageBox.Show("Silmek İstediğinizden Eminmisiniz?", "Uyarı", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (stokIslem.StokSil(new Entity.StyStok { Kodu = txtStokKodu.Text }))
                    yeniEkran();
            }
        }
        private void txtStok_Listesi_Click(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (FrmListe frm = new FrmListe(ListeType.Stok))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.Tag != null)
                    {
                        var stok = stokIslem.StokGetir(frm.Tag.ToString());
                        if (stok != null)
                        {
                            txtStokKodu.Text = stok.Kodu;
                            cmbVergi.Text = stok.KdvOran.ToString();
                            txtStokAdi.Text = stok.Adi;
                            cmbBirim4.Text = stok.Birim4;
                            cmbBirim3.Text = stok.Birim3;
                            cmbBirim2.Text = stok.Birim2;
                            cmbBirim1.Text = stok.Birim1;
                            txtBirim1.Text = stok.Katsayi1.Value.ToString();
                            txtBirim2.Text = stok.Katsayi2.Value.ToString();
                            txtBirim3.Text = stok.Katsayi3.Value.ToString();
                            txtBirim4.Text = stok.Katsayi4.Value.ToString();
                            txtFiyat.Text = stok.Fiyat.ToString();
                        }
                    }

                }
            }
        }
    }
}
