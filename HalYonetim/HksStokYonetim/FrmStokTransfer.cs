using CrmPosHalYonetim.Entity;
using HalYonetim;
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
    public partial class FrmStokTransfer : Form
    {
        public FrmStokTransfer()
        {
            InitializeComponent();
            Load += FrmStokTransfer_Load;
        }

        #region Field
        List<DepoSevkSatir> satirlar = new List<DepoSevkSatir>();
        StyDepoIslem depoIslem = new StyDepoIslem();
        StyStokIslem stokIslem = new StyStokIslem();
        StyKasaIslem kasaIslem = new StyKasaIslem();
        StyDepoSevkIslem sevkIslem = new StyDepoSevkIslem();
        List<StyStokMiktarItem> stokMiktar = new List<StyStokMiktarItem>();
        #endregion

        #region Metod
        private void FifoUstHesapla()
        {
            double eldekiMiktar = 0;

            double iadeKasaMiktar = 0;
            double kasaMiktar = 0;


            foreach (var item in stokMiktar)
            {
                eldekiMiktar += item.GercekBirimMiktar - item.BirimMiktar;
                iadeKasaMiktar += item.GercekIadeKasaMiktar - item.IadeKasaMiktar;
                kasaMiktar += item.GercekKasaMiktar - item.KasaMiktar;
            }
            txtUstEldekiMiktar.Text = eldekiMiktar.ToString();
            txtUstIadeKasaMiktar.Text = iadeKasaMiktar.ToString();
            txtUstKasaMiktar.Text = kasaMiktar.ToString();
        }
        private bool FifoHesapla()
        {
            bool devammi = true;
            try
            {

                foreach (var styTemp in stokMiktar)
                {
                    styTemp.BirimMiktar = 0;// styTemp.GercekBirimMiktar;
                    styTemp.KasaMiktar = 0;//styTemp.GercekKasaMiktar;
                    styTemp.IadeKasaMiktar = 0;// styTemp.GercekIadeKasaMiktar;
                }

                var getGroupKayit = (from sat in satirlar
                                     where sat.StokMiktarID > 0
                                     group sat by new { sat.StokMiktarID, sat.IadeKasami } into grpItem
                                     select new { id = grpItem.Key.StokMiktarID, BirimMiktar = grpItem.Sum(x => x.Miktar), iadeKasaMiktar = grpItem.Sum(x => x.IadeKasami == true ? x.KasaMiktar : 0), KasaMiktar = grpItem.Sum(x => x.IadeKasami == false ? x.KasaMiktar : 0) }).ToList();

                foreach (var item in getGroupKayit)
                {
                    var sty = stokMiktar.Where(x => x.ID == item.id).FirstOrDefault();
                    if (sty != null)
                    {
                        double kalan = sty.GercekBirimMiktar - item.BirimMiktar;
                        if (kalan < 0)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("Fatura Miktarından Fazla Giremezsiniz.");
                            devammi = false;
                        }
                        else
                            sty.BirimMiktar += item.BirimMiktar;
                        double kalanIadeKasaMiktar = sty.GercekIadeKasaMiktar - item.iadeKasaMiktar;
                        if (kalanIadeKasaMiktar < 0)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("İade Kasa Miktarından Fazla Giremezsiniz.");
                            devammi = false;
                        }
                        else
                            sty.IadeKasaMiktar += item.iadeKasaMiktar;
                        double kalanKasaMiktar = sty.GercekKasaMiktar - item.KasaMiktar;
                        if (kalanKasaMiktar < 0)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("Kasa Miktarından Fazla Giremezsiniz.");
                            devammi = false;
                        }
                        else
                            sty.KasaMiktar += item.KasaMiktar;
                    }
                }

                FifoUstHesapla();
            }
            catch (Exception ex)
            {

            }
            return devammi;
        }
        private void SatirEkle()
        {
            int satir = 0;
            for (int i = 0; i < satirlar.Count; i++)
            {
                satirlar[i].Satir = satir;
                satir++;
            }
            if (satirlar.Count == 0)
            {
                satirlar.Add(new DepoSevkSatir { Satir = satir, Miktar = 1 });
            }
            int bosSatir = satirlar.Where(x => x.Kasa == null).Count();
            if (bosSatir == 0)
            {
                satir = satirlar.Max(x => x.Satir) + 1;
                satirlar.Add(new DepoSevkSatir { Satir = satir, Miktar = 1 });

                gridView1.FocusedColumn = gridView1.Columns["Kasa"];
                gridView1.SelectRow(0);
                gridView1.FocusedRowHandle = gridView1.FocusedRowHandle + 1;
                gridView1.SelectCell(0, gridView1.Columns["Kasa"]);

            }
            gridControl1.RefreshDataSource();
            AltToplamHesapla();
        }
        private void DepoSet(string kodu)
        {
            var depo = depoIslem.DepoGetir(kodu);
            if (depo != null)
            {
                satirlar[gridView1.FocusedRowHandle].CikisDepoNo = depo.DepoNo;
                satirlar[gridView1.FocusedRowHandle].StokAdi = depo.DepoTanim;
                satirlar[gridView1.FocusedRowHandle].KasaMiktar = 1;
                satirlar[gridView1.FocusedRowHandle].Miktar = 1;
                gridView1.FocusedColumn = gridView1.Columns["KasaMiktar"];
                gridView1.RefreshRow(gridView1.FocusedRowHandle);
            }
            else
            {
                using (FrmListe frm = new FrmListe(ListeType.Stok))
                {
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        DepoSet(frm.Tag.ToString());
                }
            }
            AltToplamHesapla();
        }
        private void AltToplamHesapla()
        {
            double toplam = 0;
            double kasaMiktar = 0;
            double birimMiktar = 0;
            for (int i = 0; i < satirlar.Count; i++)
            {
                if (satirlar[i].Kasa != null && satirlar[i].KasaMiktar > 0)
                {
                    toplam += satirlar[i].Tutar;
                    kasaMiktar += satirlar[i].KasaMiktar;
                    birimMiktar += satirlar[i].Miktar;
                }


            }
            txtAltKasaMiktar.Text = kasaMiktar.ToString("n2");
            txtAltTutar.Text = toplam.ToString("n2");
            txtAltBirimMiktar.Text = birimMiktar.ToString("n2");
        }
        private void yeniEkran()
        {
            satirlar.Clear();
            gridControl1.DataSource = null;
            gridControl1.DataSource = satirlar;

            SatirEkle();
            dtTarih.EditValue = DateTime.Now;
            txtSeri.Text = sevkIslem.SonSeri();
            txtSira.Text = sevkIslem.Sira(txtSeri.Text).ToString();
            txtMerkezDepo.Tag = null;
            txtMerkezDepo.Text = "";
            txtStokKodu.Text = "";
            txtStokAdi.Text = "";
            txtUstEldekiMiktar.Text = "";
            txtUstIadeKasaMiktar.Text = "";
            txtUstKasaMiktar.Text = "";
            txtAltBirimMiktar.Text = "";
            txtAltKasaMiktar.Text = "";
            txtAltTutar.Text = "";
            txtSeri.Focus();
        }
        #endregion
        void FrmStokTransfer_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = satirlar;
            SatirEkle();
            dtTarih.EditValue = DateTime.Now;
            txtSeri.Text = sevkIslem.SonSeri();
            var nkasalar = kasaIslem.TumKasalar();
            if (nkasalar != null)
                cmbKasa.Items.AddRange(nkasalar.Select(x => new ComboItem { Text = x.Tanim, Value = x.No }).ToArray());
            txtSeri.Focus();
            txtSeri.SelectAll();
        }
        private void txtMerkezDepo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
                            txtMerkezDepo.Tag = depo.DepoNo;
                            txtMerkezDepo.Text = depo.DepoTanim;
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
                        var stok = stokIslem.StokGetir(frm.Tag.ToString());
                        if (stok != null)
                        {
                            txtStokKodu.Text = stok.Kodu;
                            txtStokAdi.Text = stok.Adi;
                            stokMiktar.Clear();
                            foreach (var item in StyStokGirisCikisIslem.Instance.StyStokEldekiMiktar(txtMerkezDepo.Tag.ToString(), stok.Kodu))
                            {
                                stokMiktar.Add(new StyStokMiktarItem
                                {
                                    //BirimMiktar = item.BirimMiktar.HasValue ? item.BirimMiktar.Value : 0,
                                    //KasaMiktar = item.KasaMiktar.HasValue ? item.KasaMiktar.Value : 0,
                                    //IadeKasaMiktar = item.IadeKasaMiktar.HasValue ? item.IadeKasaMiktar.Value : 0,
                                    BirimMiktar = 0,
                                    KasaMiktar = 0,
                                    IadeKasaMiktar = 0,
                                    GercekBirimMiktar = item.BirimMiktar.HasValue ? item.BirimMiktar.Value : 0,
                                    GercekKasaMiktar = item.KasaMiktar.HasValue ? item.KasaMiktar.Value : 0,
                                    GercekIadeKasaMiktar = item.IadeKasaMiktar.HasValue ? item.IadeKasaMiktar.Value : 0,

                                    BirmFiyat = item.BirmFiyat.HasValue ? item.BirmFiyat.Value : 0,
                                    DepoNo = item.DepoNo,
                                    ID = item.ID,
                                    StokKodu = item.StokKodu,
                                    Tarih = item.Tarih.HasValue ? item.Tarih.Value : new DateTime(1900, 1, 1, 0, 0, 0)
                                });
                            }
                            if (stokMiktar.Count > 0)
                            {
                                FifoHesapla();
                                satirlar.Clear();
                                int satir = 0;
                                cmbBirim.Items.Clear();
                                cmbBirim.Items.AddRange(stokIslem.BirimIsimleri(stok.Kodu));
                                foreach (var item in depoIslem.TumDepoGetir())
                                {
                                    if (item.DepoNo == txtMerkezDepo.Tag.ToString())
                                        continue;
                                    ComboItem birim = null;
                                    if (stok.Birim1 != "")
                                        birim = new ComboItem { Text = stok.Birim1, Value = stok.Katsayi1 };
                                    else if (stok.Birim2 != "")
                                        birim = new ComboItem { Text = stok.Birim2, Value = stok.Katsayi2 };
                                    else if (stok.Birim3 != "")
                                        birim = new ComboItem { Text = stok.Birim3, Value = stok.Katsayi3 };
                                    else if (stok.Birim4 != "")
                                        birim = new ComboItem { Text = stok.Birim4, Value = stok.Katsayi4 }; ;

                                    satirlar.Add(new DepoSevkSatir
                                    {
                                        CikisDepoAdi = txtMerkezDepo.Text,
                                        CikisDepoNo = txtMerkezDepo.Tag.ToString(),
                                        Fiyat = 0,
                                        GirisDepoNo = item.DepoNo,
                                        GirisDepoAdi = depoIslem.DepoGetir(item.DepoNo).DepoTanim,
                                        Kasa = new ComboItem { },
                                        KasaMiktar = 0,
                                        Miktar = 0,
                                        Satir = satir++,
                                        StokAdi = stok.Adi,
                                        StokKodu = stok.Kodu,
                                        Tarih = Convert.ToDateTime(dtTarih.Text)
                                    });
                                }
                                SatirEkle();
                            }
                            else
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("Ürün Girişi Bulunamadı");
                            }
                        }
                    }
                }
            }
        }
        private void txtStokAdi_Validated(object sender, EventArgs e)
        {
            if (txtStokAdi.Text == "")
                txtStokKodu_ButtonClick(txtStokKodu, new DevExpress.XtraEditors.Controls.ButtonPressedEventArgs(new DevExpress.XtraEditors.Controls.EditorButton()));
        }
        private void txtSeri_Validated(object sender, EventArgs e)
        {
            txtSira.Text = sevkIslem.Sira(txtSeri.Text).ToString();
        }
        private void txtSira_Validated(object sender, EventArgs e)
        {
            var ff = sevkIslem.SevkGetir(txtSeri.Text, Convert.ToInt32(txtSira.Text));
            if (ff != null && ff.Count > 0)
            {
                satirlar.Clear();
                foreach (var item in ff)
                {
                    satirlar.Add(new DepoSevkSatir
                    {
                        CikisDepoAdi = depoIslem.DepoGetir(item.CikisDepoNo).DepoTanim,
                        CikisDepoNo = item.CikisDepoNo,
                        Fiyat = item.BirimFiyat.Value,
                        KasaMiktar = item.KasaMiktar.Value,
                        Kasa = kasaIslem.ComboKasaGetir(item.KasaNo),
                        StokKodu = item.StokKodu,
                        Miktar = item.UrunMiktar.Value,
                        StokMiktarID = 0,
                        Satir = item.Satir.Value,
                        GirisDepoAdi = depoIslem.DepoGetir(item.GirisDepoNo).DepoTanim,
                        GirisDepoNo = item.GirisDepoNo,
                        StokAdi = stokIslem.StokGetir(item.StokKodu).Adi,
                        Tarih = item.Tarih.Value
                    });
                }
                dtTarih.Text = ff[0].Tarih.ToString();
                txtMerkezDepo.Tag = ff[0].CikisDepoNo;
                txtMerkezDepo.Text = depoIslem.DepoGetir(ff[0].CikisDepoNo).DepoTanim;
                txtStokKodu.Text = ff[0].StokKodu;
                txtStokAdi.Text = stokIslem.StokGetir(ff[0].StokKodu).Adi;
                gridControl1.DataSource = null;
                gridControl1.DataSource = satirlar;
                SatirEkle();
                AltToplamHesapla();
            }
            SatirEkle();
        }
        private void txtMerkezDepo_Validated(object sender, EventArgs e)
        {
            if (txtMerkezDepo.Tag == null)
                txtMerkezDepo_ButtonClick(txtMerkezDepo, new DevExpress.XtraEditors.Controls.ButtonPressedEventArgs(new DevExpress.XtraEditors.Controls.EditorButton()));
        }
        private void txtMiktar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if ((gridView1.FocusedColumn == clmBirimMiktar && e.KeyCode == Keys.F10) || (e.KeyCode == Keys.Enter && gridView1.FocusedColumn == clmBirimMiktar && satirlar[gridView1.FocusedRowHandle].StokMiktarID == 0))
                {
                    if (satirlar[gridView1.FocusedRowHandle].Kasa != null && satirlar[gridView1.FocusedRowHandle].Kasa.Value == null)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Lütfen Kasa Seçin");
                        gridView1.FocusedColumn = gridView1.Columns["Kasa"];
                        return;
                    }
                    using (FrmStokEldekiMiktar frm = new FrmStokEldekiMiktar(stokMiktar.Where(x => (x.GercekBirimMiktar - x.BirimMiktar) > 0).ToList()))
                    {
                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            StyStokMiktarItem stk = frm.Tag as StyStokMiktarItem;
                            if (stk != null)
                            {
                                satirlar[gridView1.FocusedRowHandle].StokMiktarID = stk.ID;
                                gridView1.SetFocusedRowCellValue(clmFiyat, stk.BirmFiyat);
                                if (!FifoHesapla())
                                {
                                    gridView1.SetFocusedRowCellValue(clmBirimMiktar, 0);
                                    gridView1.SetFocusedRowCellValue(clmKasaMiktar, 0);
                                    gridView1.SetFocusedRowCellValue(clmFiyat, 0);
                                    gridView1.FocusedColumn = clmBirimMiktar;
                                    satirlar[gridView1.FocusedRowHandle].StokMiktarID = 0;
                                }
                                else
                                    AltToplamHesapla();
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                HataLog.Instance.HataLogYaz(ex);
            }
        }
        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (!FifoHesapla())
            {
                gridView1.SetFocusedRowCellValue(clmBirimMiktar, 0);
                gridView1.SetFocusedRowCellValue(clmKasaMiktar, 0);
                gridView1.SetFocusedRowCellValue(clmFiyat, 0);
                gridView1.FocusedColumn = clmBirimMiktar;
                satirlar[gridView1.FocusedRowHandle].StokMiktarID = 0;
            }
            AltToplamHesapla();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (sevkIslem.SevkKaydet(txtSeri.Text, Convert.ToInt32(txtSira.Text), satirlar.Where(x => x.Miktar > 0 && x.KasaMiktar > 0).ToList()))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Kaydetme İşlemi Başarılı");
                this.Close();
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Kaydetme İşlemi Başarısız");
            }
        }
    }
    public class StyStokMiktarItem
    {
        public int ID { get; set; }
        public string DepoNo { get; set; }
        public string StokKodu { get; set; }
        public DateTime Tarih { get; set; }
        public double BirmFiyat { get; set; }
        public double BirimMiktar { get; set; }
        public double IadeKasaMiktar { get; set; }
        public double KasaMiktar { get; set; }
        public double GercekBirimMiktar { get; set; }
        public double GercekIadeKasaMiktar { get; set; }
        public double GercekKasaMiktar { get; set; }

    }
}
