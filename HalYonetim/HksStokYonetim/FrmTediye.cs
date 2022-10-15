using CrmPosHalYonetim.Entity;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrmPosHalYonetim.HksStokYonetim
{
    public partial class FrmTediye : XtraForm
    {
        public FrmTediye()
        {
            InitializeComponent();
        }
        #region Fields
        byte _belgeTipi = 2;
        List<OdemeHareket> satirlar = new List<OdemeHareket>();
        #endregion

        #region Metod
        private void OdemeTipleriYukle()
        {
            satirlar.Clear();
            foreach (var item in StyOdemeTanimIslem.Instance.Odemeler())
            {
                satirlar.Add(new OdemeHareket { OdemeTanim = item.Tanim, Aciklama = "", OdemeNo = item.No, Tutar = 0 });
            }
            gridControl1.DataSource = satirlar;
            gridView1.BestFitColumns();
        }
        private void AltToplamHesapla()
        {
            try
            {
                double yekun = 0;
                for (int i = 0; i < satirlar.Count; i++)
                {
                    if (satirlar[i].Tutar > 0)
                    {
                        yekun += satirlar[i].Tutar;
                    }
                }
                txtAltTutar.Text = yekun.ToString("n2");
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        private void txtMerkezDepo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (FrmListe frm = new FrmListe(ListeType.Depo))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.Tag != null)
                    {
                        var depo = StyDepoIslem.Instance.DepoGetir(frm.Tag.ToString());
                        if (depo != null)
                        {
                            txtMerkezDepo.Tag = depo.DepoNo;
                            txtMerkezDepo.Text = depo.DepoTanim;
                        }
                    }
                }
            }
        }
        private void txtCariKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (FrmListe frm = new FrmListe(ListeType.Cari))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.Tag != null)
                    {
                        var cari = StyCariIslem.Instance.CariGetir(frm.Tag.ToString());
                        if (cari != null)
                        {
                            txtCariKodu.Text = cari.Kodu;
                            txtCariAdi.Text = cari.Adi;
                        }
                    }
                }
            }
        }
        private void txtCariAdi_Validated(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCariAdi.Text))
            {
                txtCariKodu_ButtonClick(txtCariAdi, new DevExpress.XtraEditors.Controls.ButtonPressedEventArgs(new DevExpress.XtraEditors.Controls.EditorButton()));
            }
        }
        private void btnKaydet_Click(object sender, System.EventArgs e)
        {
            if (txtMerkezDepo.Tag == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Depo Seçimi Yapmadınız");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtCariKodu.Text) || string.IsNullOrWhiteSpace(txtCariAdi.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Cari Bilgilerinizi Kontrol Edin");
                return;
            }
            try
            {
                if (Convert.ToDouble(txtAltTutar.Text) == 0)
                {
                    return;
                }
            }
            catch
            {
                return;
            }
            StyFatura ff = new StyFatura();
            try
            {

                ff.Seri = txtSeri.Text;
                ff.Sira = Convert.ToInt32(txtSira.Text);
                ff.AraToplam = 0;
                ff.KdvToplam = 0;
                ff.Yekun = Convert.ToDouble(txtAltTutar.Text);
                ff.Tarih = Convert.ToDateTime(dtTarih.Text);
                ff.BelgeNo = "";
                ff.BelgeTipi = _belgeTipi;
                ff.DepoNo = txtMerkezDepo.Tag.ToString();
                ff.CariKod = txtCariKodu.Text;

                ff.RusumToplam = 0;
                ff.RusumKdvToplam = 0;
                ff.HammaliyeToplam = 0;
                ff.HammaliyeKdvToplam = 0;
                ff.NakliyeToplam = 0;
                ff.IadeKasaKdvTutar = 0;
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Eksik Bilgi Girişi Yapıldı.");
                return;
            }
            if (Fatura.Instance.TediyeKaydet(ff, satirlar.Where(x => x.Tutar > 0).ToList()))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Tediye Kaydedildi.");
                this.Close();
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Tediye Kaydedilemedi.");
            }
        }
        private void txtMerkezDepo_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMerkezDepo.Text))
            {
                txtMerkezDepo_ButtonClick(txtMerkezDepo, new DevExpress.XtraEditors.Controls.ButtonPressedEventArgs(new DevExpress.XtraEditors.Controls.EditorButton()));
            }
        }

        private void FrmTediye_Load(object sender, EventArgs e)
        {
            dtTarih.EditValue = DateTime.Now;
            txtSeri.Text = Fatura.Instance.SonSeri(_belgeTipi);
            OdemeTipleriYukle();
        }

        private void txtSeri_Validated(object sender, EventArgs e)
        {
            txtSira.Text = Fatura.Instance.Sira(txtSeri.Text).ToString();
        }

        private void txtSira_Validated(object sender, EventArgs e)
        {
            StyFatura ff = Fatura.Instance.TediyeGetir(txtSeri.Text, Convert.ToInt32(txtSira.Text));
            if (ff != null)
            {
                dtTarih.Text = ff.Tarih.ToString();
                txtMerkezDepo.Tag = ff.DepoNo;
                txtMerkezDepo.Text = StyDepoIslem.Instance.DepoGetir(ff.DepoNo).DepoTanim;
                txtCariKodu.Text = ff.CariKod;
                txtCariAdi.Text = StyCariIslem.Instance.CariGetir(ff.CariKod).Adi;

                gridControl1.DataSource = null;
                satirlar = Fatura.Instance.TediyeHareketGetir(ff);
                gridControl1.DataSource = satirlar;
                AltToplamHesapla();
            }
        }

        private void txtTutar_EditValueChanged(object sender, EventArgs e)
        {
            AltToplamHesapla();
        }

        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            AltToplamHesapla();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            AltToplamHesapla();
        }
    }
}
