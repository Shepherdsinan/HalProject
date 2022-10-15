using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrmPosHalYonetim.Entity;
using HalYonetim;

namespace CrmPosHalYonetim
{
    public partial class FrmBildirimListesi : UserControl
    {
        public FrmBildirimListesi()
        {
            InitializeComponent();
        }

        private void FrmBildirimListesi_Load(object sender, EventArgs e)
        {
            dtTarih.EditValue = DateTime.Now;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            DateTime tarih = Convert.ToDateTime(dtTarih.Text);
            gridControl1.DataSource = (from hksSevk in ent.HksSevkler
                                       join il in ent.HKSIller on hksSevk.UretimIlId equals il.ID
                                       join ilce in ent.HKSIlceler on hksSevk.UretimIlceId equals ilce.ID
                                       join belde in ent.HKSBeldeler on hksSevk.UretimBeldeId equals belde.ID
                                       join belgeTipi in ent.HKSBelgeler on hksSevk.BelgeTipi equals belgeTipi.ID
                                       join bildirim in ent.HKSBildirimler on hksSevk.BildirimTuru equals bildirim.ID
                                       join hkssube in ent.HKSSubeler on hksSevk.GidecekIsyeriId equals hkssube.ID
                                       join hksStok in ent.HKSStoklar on hksSevk.MalinKodNo equals hksStok.ID
                                       where hksSevk.BildirimTarihi >= tarih

                                       select new BildirimEtiketItem
                                       {
                                           AracPlaka = hksSevk.AracPlakaNo,
                                           BelgeNo = hksSevk.BelgeNo,
                                           BelgeTipi = belgeTipi.Belge,
                                           BildirimciTcKimlikVergiNo = hksSevk.BildirimciTcKimlikVergiNo,
                                           SevkBildirimTarihi = hksSevk.BildirimTarihi.Value,
                                           BildirimTuru = bildirim.Adi,
                                           HksHataAciklama = hksSevk.HksHataAciklama,
                                           Kunye = hksSevk.KunyeNo,
                                           MalinAdi = hksSevk.MalinAdi,
                                           MalinCinsi = hksSevk.MalinCinsi,
                                           MalinMiktari = hksSevk.MalinMiktari.Value,
                                           MalinSahibAdi = hksSevk.MalinSahibAdi,
                                           MalinSahibiTcKimlikVergiNo = hksSevk.MalinSahibiTcKimlikVergiNo,
                                           MalinSatisFiyati = hksSevk.MalinSatisFiyati.Value,
                                           MalinTuru = hksSevk.MalinTuru,
                                           MiktarBirimiAd = hksSevk.MiktarBirimiAd,
                                           NihaiKunyeNo = hksSevk.NihaiKunyeNo,
                                           Sube = hkssube.SubeAdi,
                                           UreticisininAdUnvani = hksSevk.UreticisininAdUnvani,
                                           UreticiTcKimlikVergiNo = hksSevk.UreticiTcKimlikVergiNo,
                                           UretimBelde = belde.Adi,
                                           UretimIlce = ilce.Adi,
                                           UretimIli = il.Adi,
                                           UretimSekli = hksSevk.MalinTuru,
                                           KayitTarihi = hksSevk.KayitTarihi.HasValue ? hksSevk.KayitTarihi.Value : new DateTime(1900, 1, 1),
                                           MasrafOran = hksStok.MasrafOrani.HasValue ? hksStok.MasrafOrani.Value : 0,
                                           IslemePaketlemeOran = hksStok.IslemePaketlemeOran.HasValue ? hksStok.IslemePaketlemeOran.Value : 0,
                                           MagazacilikOran = hksStok.MagazacilikOran.HasValue ? hksStok.MagazacilikOran.Value : 0,
                                           NakliyeDepolamaOran = hksStok.NakliyeDepolamaOran.HasValue ? hksStok.NakliyeDepolamaOran.Value : 0,
                                           VergiOran = hksStok.VergiOran.HasValue ? hksStok.VergiOran.Value : 0,
                                           ilkbildirimtarihi = hksSevk.ilkBildirimTarihi.Value
                                       }

                                       ).OrderByDescending(x => x.SevkBildirimTarihi).ToList();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Execl dosyaları (*.xls)|*.xls";
                dlg.FilterIndex = 0;
                dlg.RestoreDirectory = true;
                dlg.CreatePrompt = true;
                dlg.Title = "Excel Dosyasına Çıkart";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    gridView1.ExportToXls(dlg.FileName);
                }
            }
        }

        private void btnEtiketBastir_Click(object sender, EventArgs e)
        {
            List<BildirimEtiketItem> etiketItems = new List<BildirimEtiketItem>();
            foreach (var item in gridView1.GetSelectedRows())
            {
                BildirimEtiketItem seciliItem = gridView1.GetRow(item) as BildirimEtiketItem;
                if (seciliItem != null)
                {
                    if (seciliItem.MasrafOran > 0)
                        seciliItem.MalinSatisFiyatiMasrafDahil = ((seciliItem.MasrafOran + 100) / 100) * seciliItem.MalinSatisFiyati;
                    if (seciliItem.IslemePaketlemeOran > 0)
                        seciliItem.IslemePaketlemeTutar = ((seciliItem.IslemePaketlemeOran + 100) / 100) * seciliItem.MalinSatisFiyati;
                    if (seciliItem.MagazacilikOran > 0)
                        seciliItem.MagazacilikTutar = ((seciliItem.MagazacilikOran + 100) / 100) * seciliItem.MalinSatisFiyati;
                    if (seciliItem.NakliyeDepolamaOran > 0)
                        seciliItem.NakliyeDepolamaTutar = ((seciliItem.NakliyeDepolamaOran + 100) / 100) * seciliItem.MalinSatisFiyati;
                    if (seciliItem.VergiOran > 0)
                        seciliItem.VergiTutar = ((seciliItem.VergiOran + 100) / 100) * seciliItem.MalinSatisFiyati;


                    etiketItems.Add(seciliItem);
                }
            }
            string etiketDosyaYolu = Application.StartupPath + "\\HksEtiket.repx";
            FastReport.Report report = FastReport.Report.FromFile(etiketDosyaYolu);
            BindingSource bs = new BindingSource();
            bs.DataSource = etiketItems;
            report.RegisterData(bs, "HksEtiket", 10);
            report.GetDataSource("HksEtiket").Enabled = true;

            if (!string.IsNullOrWhiteSpace(ProgramAyarlari.Instance.GetValue(ProgramSettingsEnum.EtiketYazicisi)))
            {
                report.PrintSettings.Printer = ProgramAyarlari.Instance.GetValue(ProgramSettingsEnum.EtiketYazicisi);
                report.PrintSettings.ShowDialog = false;
            }
            else
                report.PrintSettings.ShowDialog = true;
            report.Prepare();
            report.Print();
        }
    }



}
