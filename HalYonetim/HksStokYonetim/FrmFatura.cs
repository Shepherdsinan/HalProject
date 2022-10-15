using CrmPosHalYonetim.Entity;
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
    public partial class FrmFatura : XtraForm
    {
        #region Field
        List<FaturaSatir> satirlar = new List<FaturaSatir>();
        StyDepoIslem depoIslem = new StyDepoIslem();
        StyCariIslem cariIslem = new StyCariIslem();
        StyStokIslem stokIslem = new StyStokIslem();
        StyKasaIslem kasaIslem = new StyKasaIslem();
        Fatura fatura = new Fatura();
        byte _tip = 0;
        #endregion

        #region Metod
        private void SatirEkle()
        {
            int satir = 1;
            for (int i = 0; i < satirlar.Count; i++)
            {
                satirlar[i].Satir = satir;
                satir++;
            }
            if (satirlar.Count == 0)
            {
                satirlar.Add(new FaturaSatir { Satir = satir, Miktar = 1 });
            }
            int bosSatir = _tip == 1 ? satirlar.Where(x => x.KasaTutar == 0 && x.IadeKasaTutar == 0).Count() : satirlar.Where(x => string.IsNullOrWhiteSpace(x.StokKodu)).Count();
            if (bosSatir == 0)
            {
                satir = satirlar.Max(x => x.Satir) + 1;
                satirlar.Add(new FaturaSatir { Satir = satir, Miktar = 1 });
                if (_tip == 1)
                {
                    gridView1.FocusedColumn = gridView1.Columns["Kasa"];
                    gridView1.SelectRow(satir);
                    gridView1.FocusedRowHandle = gridView1.FocusedRowHandle + 1;
                    gridView1.SelectCell(satir, gridView1.Columns["Kasa"]);
                }
                else
                {
                    gridView1.FocusedColumn = gridView1.Columns["StokKodu"];
                    gridView1.SelectRow(satir);
                    gridView1.FocusedRowHandle = gridView1.FocusedRowHandle + 1;
                    gridView1.SelectCell(satir, gridView1.Columns["StokKodu"]);
                }
            }
            gridControl1.RefreshDataSource();
            AltToplamHesapla();
        }
        private void StokSet(string kodu)
        {
            var stok = stokIslem.StokGetir(kodu);
            if (stok != null)
            {
                satirlar[gridView1.FocusedRowHandle].StokKodu = stok.Kodu;
                satirlar[gridView1.FocusedRowHandle].StokAdi = stok.Adi;
                satirlar[gridView1.FocusedRowHandle].Miktar = 1;
                satirlar[gridView1.FocusedRowHandle].Fiyat = stok.Fiyat.Value;
                cmbBirim.Items.Clear();
                cmbBirim.Items.AddRange(stokIslem.BirimIsimleri(stok.Kodu));
                satirlar[gridView1.FocusedRowHandle].Vergi = new ComboItem { Value = stok.KdvOran, Text = stok.KdvOran.ToString() };
                if (stok.Birim1 != "")
                    satirlar[gridView1.FocusedRowHandle].Birim = new ComboItem { Text = stok.Birim1, Value = stok.Katsayi1 };
                else if (stok.Birim2 != "")
                    satirlar[gridView1.FocusedRowHandle].Birim = new ComboItem { Text = stok.Birim2, Value = stok.Katsayi2 };
                else if (stok.Birim3 != "")
                    satirlar[gridView1.FocusedRowHandle].Birim = new ComboItem { Text = stok.Birim3, Value = stok.Katsayi3 };
                else if (stok.Birim4 != "")
                    satirlar[gridView1.FocusedRowHandle].Birim = new ComboItem { Text = stok.Birim4, Value = stok.Katsayi4 }; ;
                gridView1.FocusedColumn = gridView1.Columns["Miktar"];
                gridView1.RefreshRow(gridView1.FocusedRowHandle);
            }
            else
            {
                using (FrmListe frm = new FrmListe(ListeType.Stok))
                {
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        StokSet(frm.Tag.ToString());
                }
            }
            AltToplamHesapla();
        }
        private void AltToplamHesapla()
        {
            double araToplam = 0;
            double kdv = 0;
            double yekun = 0;
            double iadeKasaToplam = 0;
            for (int i = 0; i < satirlar.Count; i++)
            {
                if (_tip == 0 && satirlar[i].Vergi != null)
                {
                    double kdvOran = Convert.ToDouble(satirlar[i].Vergi.Value);
                    satirlar[i].VergiTutar = satirlar[i].Tutar * ((100 + kdvOran) / 100) - satirlar[i].Tutar;
                    kdv += satirlar[i].VergiTutar;

                    araToplam += satirlar[i].Tutar;
                    iadeKasaToplam += satirlar[i].IadeKasaTutar;
                    yekun += araToplam + kdv + iadeKasaToplam;
                }
                if (_tip == 1)
                {
                    araToplam += satirlar[i].KasaTutar + satirlar[i].IadeKasaTutar;
                    iadeKasaToplam += satirlar[i].IadeKasaTutar;
                    yekun += satirlar[i].KasaTutar + satirlar[i].IadeKasaTutar;
                }
            }
            txtAraToplam.Text = araToplam.ToString("n2");
            txtkdvToplam.Text = kdv.ToString("n2");
            txtAltIadeKasaTutar.Text = iadeKasaToplam.ToString("n2");
            txtYekun.Text = yekun.ToString("n2");
        }
        /// <summary>
        ///tip=0:Alış Faturası tip=1:Kasa İade Faturası 
        /// </summary>
        /// <param name="tip"></param>
        public FrmFatura(byte tip)
        {
            InitializeComponent();
            this.Load += FrmFatura_Load;
            _tip = tip;
            if (_tip == 1)
            {
                cmbNI.SelectedIndex = _tip;
                cmbNI.Enabled = false;
            }
        }
        private void yeniEkran()
        {
            satirlar.Clear();
            gridControl1.DataSource = null;
            gridControl1.DataSource = satirlar;

            SatirEkle();
            dtTarih.EditValue = DateTime.Now;
            txtSeri.Text = fatura.SonSeri(_tip);
            txtSira.Text = fatura.Sira(txtSeri.Text).ToString();
            txtBelgeNo.Text = "";
            cmbNI.SelectedIndex = 0;
            txtDepo.Tag = null;
            txtDepo.Text = "";
            txtCariKodu.Text = "";
            txtCariAdi.Text = "";
            txtRusumTutar.Text = "";
            txtRusumKdv.Text = "";
            txtHammaliyeTutar.Text = "";
            txtHammaliyeKdvTutar.Text = "";
            txtNakliyeTutar.Text = "";
            txtUstIadeKasaKdvTutar.Text = "";
            txtUstIadeKasaKdvTutar.Text = "";
            txtSeri.Focus();
        }
        #endregion

        void FrmFatura_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = satirlar;
            SatirEkle();
            dtTarih.EditValue = DateTime.Now;
            txtSeri.Text = fatura.SonSeri(_tip);
            if (_tip == 1)
            {
                lblHammaliyeKdvTutar.Visible = false;
                lblHammaliyeTutar.Visible = false;
                lblNakliyeTutar.Visible = false;
                lblRusumKdv.Visible = false;
                lblRusumTutar.Visible = false;
                lblUstIadeKasaKdvTutar.Visible = false;

                txtHammaliyeKdvTutar.Visible = false;
                txtHammaliyeTutar.Visible = false;
                txtNakliyeTutar.Visible = false;
                txtRusumKdv.Visible = false;
                txtRusumTutar.Visible = false;
                txtUstIadeKasaKdvTutar.Visible = false;

                clmFiyat.Visible = false;
                clmMiktar.Visible = false;
                clmStokAdi.Visible = false;
                clmStokBirim.Visible = false;
                clmStokKodu.Visible = false;
                clmTutar.Visible = false;
                clmVergi.Visible = false;
            }
            else
            {
                //cmbBirim.Items.AddRange(stokIslem.BirimIsimleri().ToArray());
                cmbVergi.Items.AddRange(stokIslem.Kdvler().Select(x => new ComboItem { Value = x, Text = x.ToString() }).ToArray());
            }
            var nkasalar = kasaIslem.Kasalar(false);
            var ikasalar = kasaIslem.Kasalar(true);
            if (nkasalar != null)
                cmbKasa.Items.AddRange(nkasalar.Select(x => new ComboItem { Text = x.Tanim, Value = x.No }).ToArray());
            if (ikasalar != null)
                cmbIadeKasa.Items.AddRange(ikasalar.Select(x => new ComboItem { Text = x.Tanim, Value = x.No }).ToArray());
            txtSeri.Focus();
            txtSeri.SelectAll();
        }
        private void txtDepo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (FrmListe frm = new FrmListe(ListeType.Depo))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.Tag != null)
                    {
                        var depo = depoIslem.DepoGetir(frm.Tag.ToString());
                        if (depo != null)
                        {
                            txtDepo.Tag = depo.DepoNo;
                            txtDepo.Text = depo.DepoTanim;
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
                        var cari = cariIslem.CariGetir(frm.Tag.ToString());
                        if (cari != null)
                        {
                            txtCariKodu.Text = cari.Kodu;
                            txtCariAdi.Text = cari.Adi;
                        }
                    }
                }
            }
        }
        private void txtStokKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (FrmListe frm = new FrmListe(ListeType.Stok))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.Tag != null)
                    {
                        StokSet(frm.Tag.ToString());
                    }
                }
            }
        }
        private void txtIadeKasaTutar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridView1_KeyDown(gridView1, new KeyEventArgs(Keys.Down));
            }
        }
        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                SatirEkle();
            else if (e.Alt && e.KeyCode == Keys.D)
                btnSatirSil_Click(null, null);
            else if (e.Alt && e.KeyCode == Keys.K)
                btnKaydet_Click(null, null);
        }
        private void txtStokKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridView1.FocusedColumn = gridView1.Columns["StokAdi"];
                gridView1.FocusedColumn = gridView1.Columns["StokKodu"];
                string kod = gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridView1.Columns["StokKodu"]);
                if (!string.IsNullOrWhiteSpace(kod))
                    StokSet(kod);

            }
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == gridView1.Columns["Tutar"] || e.Column == gridView1.Columns["Miktar"] || e.Column == gridView1.Columns["Fiyat"])
            {
                AltToplamHesapla();
            }

        }
        private void txtSeri_Validated(object sender, EventArgs e)
        {
            txtSira.Text = fatura.Sira(txtSeri.Text).ToString();
        }
        private void txtSira_Validated(object sender, EventArgs e)
        {
            StyFatura ff = fatura.FaturaGetir(txtSeri.Text, Convert.ToInt32(txtSira.Text));
            if (ff != null)
            {
                dtTarih.Text = ff.Tarih.ToString();
                txtBelgeNo.Text = ff.BelgeNo;
                cmbNI.SelectedIndex = ff.BelgeTipi.Value;
                txtDepo.Tag = ff.DepoNo;
                txtDepo.Text = depoIslem.DepoGetir(ff.DepoNo).DepoTanim;
                txtCariKodu.Text = ff.CariKod;
                txtCariAdi.Text = cariIslem.CariGetir(ff.CariKod).Adi;
                txtRusumTutar.Text = ff.RusumToplam.ToString();
                txtRusumKdv.Text = ff.RusumKdvToplam.ToString();
                txtHammaliyeTutar.Text = ff.HammaliyeToplam.ToString();
                txtHammaliyeKdvTutar.Text = ff.HammaliyeKdvToplam.ToString();
                txtNakliyeTutar.Text = ff.NakliyeToplam.ToString();
                txtUstIadeKasaKdvTutar.Text = ff.IadeKasaKdvTutar.ToString();
                gridControl1.DataSource = null;
                satirlar = fatura.FaturaHareketGetir(ff);
                gridControl1.DataSource = satirlar;
                SatirEkle();
                AltToplamHesapla();
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtDepo.Tag == null)
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
                if (Convert.ToDouble(txtAraToplam.Text) == 0)
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
                ff.AraToplam = Convert.ToDouble(txtAraToplam.Text);
                ff.KdvToplam = Convert.ToDouble(txtkdvToplam.Text);
                ff.Yekun = Convert.ToDouble(txtYekun.Text);
                ff.Tarih = Convert.ToDateTime(dtTarih.Text);
                ff.BelgeNo = txtBelgeNo.Text;
                ff.BelgeTipi = (byte)cmbNI.SelectedIndex;
                ff.DepoNo = txtDepo.Tag.ToString();
                ff.CariKod = txtCariKodu.Text;

                ff.RusumToplam = string.IsNullOrWhiteSpace(txtRusumTutar.Text) ? 0 : Convert.ToDouble(txtRusumTutar.Text);
                ff.RusumKdvToplam = string.IsNullOrWhiteSpace(txtRusumKdv.Text) ? 0 : Convert.ToDouble(txtRusumKdv.Text);
                ff.HammaliyeToplam = string.IsNullOrWhiteSpace(txtHammaliyeTutar.Text) ? 0 : Convert.ToDouble(txtHammaliyeTutar.Text);
                ff.HammaliyeKdvToplam = string.IsNullOrWhiteSpace(txtHammaliyeKdvTutar.Text) ? 0 : Convert.ToDouble(txtHammaliyeKdvTutar.Text);
                ff.NakliyeToplam = string.IsNullOrWhiteSpace(txtNakliyeTutar.Text) ? 0 : Convert.ToDouble(txtNakliyeTutar.Text);
                ff.IadeKasaKdvTutar = string.IsNullOrWhiteSpace(txtUstIadeKasaKdvTutar.Text) ? 0 : Convert.ToDouble(txtUstIadeKasaKdvTutar.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eksik Bilgi Girişi Yapıldı.");
                return;
            }
            if (fatura.FaturaKaydet(ff, satirlar, _tip))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Fatura Kaydedildi.");
                yeniEkran();
            }
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSira.Text))
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Silmek İstediğinize Eminmisiniz?", "Uyarı", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (fatura.FaturaSil(new StyFatura { Seri = txtSeri.Text, Sira = Convert.ToInt32(txtSira.Text) }))
                        yeniEkran();
                }

            }
        }
        private void txtDepo_Validated(object sender, EventArgs e)
        {
            if (txtDepo.Tag == null)
            {
                txtDepo_ButtonClick(txtDepo, new DevExpress.XtraEditors.Controls.ButtonPressedEventArgs(new DevExpress.XtraEditors.Controls.EditorButton()));
            }
        }
        private void txtCariAdi_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCariAdi.Text))
            {
                txtCariKodu_ButtonClick(txtCariAdi, new DevExpress.XtraEditors.Controls.ButtonPressedEventArgs(new DevExpress.XtraEditors.Controls.EditorButton()));
            }
        }
        private void btnSatirSil_Click(object sender, EventArgs e)
        {
            try
            {
                var satir = satirlar[gridView1.FocusedRowHandle];
                satirlar.Remove(satir);
                SatirEkle();
            }
            catch
            {

            }
        }
    }
}
