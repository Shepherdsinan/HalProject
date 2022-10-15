using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CrmPosHalYonetim;
using DevExpress.XtraGrid.Views.Grid;
using System.Linq;
using CrmPosHalYonetim.HksBildirimService;
using CrmPosHalYonetim.Entity;
using System.Configuration;

namespace HalYonetim
{
    public partial class FrmHksSevk : UserControl
    {
        public FrmHksSevk()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmBildirimListesi_Load);
        }
        List<BildirimItem> items = new List<BildirimItem>();
        List<MagazaBelgeAracPlaka> MagazaBelgeAracPlakalari = new List<MagazaBelgeAracPlaka>();
        string hataliKunyeler = "";
        #region Metod
        private void GetListele(DateTime ilkTarih, DateTime sonTarih)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                items.Clear();
                DateTime baslangicTarihi = ilkTarih;
                DateTime bitisTarihi = sonTarih;
                var sonuc = ServisYonetimi.Genel.TumKunyeSorgula(baslangicTarihi, bitisTarihi, Convert.ToByte(cmbKunyeTuru.SelectedIndex), Convert.ToInt64(0));
                if (sonuc != null && sonuc.Bildirimler != null)
                {
                    gridControl1.DataSource = null;
                    foreach (var x in sonuc.Bildirimler)
                    {
                        items.Add(new BildirimItem
                        {
                            AnalizStatus = x.AnalizStatus,
                            AracPlakaNo = x.AracPlakaNo,
                            BelgeNo = x.BelgeNo,
                            BelgeTipi = x.BelgeTipi,
                            BildirimciTcKimlikVergiNo = x.BildirimciTcKimlikVergiNo,
                            BildirimTuru = x.BildirimTuru,
                            GidecekIsyeriId = x.GidecekIsyeriId,
                            GidecekYerTuruId = x.GidecekYerTuruId,
                            KalanMiktar = x.KalanMiktar,
                            KunyeNo = x.KunyeNo,
                            MalinAdi = x.MalinAdi,
                            MalinCinsi = x.MalinCinsi,
                            //MalinCinsKodNo = x.MalinCinsKodNo,
                            MalinKodNo = x.MalinKodNo,
                            MalinMiktari = x.MalinMiktari,
                            MalinSahibiTcKimlikVergiNo = x.MalinSahibiTcKimlikVergiNo,
                            MalinSatisFiyati = x.MalinSatisFiyati,
                            MalinTuru = x.MalinTuru,
                            MalinTuruKodNo = x.MalinTuruKodNo,
                            MiktarBirimiAd = x.MiktarBirimiAd,
                            MiktarBirimId = x.MiktarBirimId,
                            RusumMiktari = x.RusumMiktari,
                            Sifat = x.Sifat,
                            UreticiTcKimlikVergiNo = x.UreticiTcKimlikVergiNo,
                            İlkBildirimtarihi = x.BildirimTarihi,
                        });
                    }
                    gridControl1.DataSource = items;
                    gridView1.Columns["AnalizStatus"].Visible = false;
                    gridView1.Columns["BelgeTipi"].Visible = false;
                    gridView1.Columns["BildirimTuru"].Visible = false;
                    gridView1.Columns["GidecekIsyeriId"].Visible = false;
                    gridView1.Columns["GidecekYerTuruId"].Visible = false;
                    //gridView1.Columns["MalinCinsKodNo"].Visible = false;
                    gridView1.Columns["MalinKodNo"].Visible = false;
                    gridView1.Columns["MalinTuruKodNo"].Visible = false;
                    gridView1.Columns["MiktarBirimId"].Visible = false;
                    gridView1.Columns["Sifat"].Visible = false;
                    for (int i = 0; i < gridView1.Columns.Count; i++)
                    {
                        if (gridView1.Columns[i].FieldName != "SevkMiktar")
                            gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                    }
                    gridView1.BestFitColumns();
                }
            }
            catch (Exception ex)
            {

            }
            this.Cursor = Cursors.Default;
        }
        private BildirimKayitIstek BuildSingleIstek(BildirimItem srg, SevkMagaza sevkMagaza, HKSSube mgz, string aracPlaka, string belgeNo)
        {
            BildirimKayitIstek result = new BildirimKayitIstek()
            {
                BildirimciBilgileri = ServisYonetimi.Genel.GetBildirimciBilgileri(),
                BildirimTuru = 196,//Sevk Etme
                IkinciKisiBilgileri = ServisYonetimi.Genel.GetIkinciKisiBilgileri(),
                ReferansBildirimKunyeNo = Convert.ToInt64(srg.KunyeNo),
                BildirimMalBilgileri = ServisYonetimi.Genel.GetMalBilgileri(srg, sevkMagaza),
            };
            //19 Perakende Satiş Yeri
            //207 İrsaliye
            result.MalinGidecekYerBilgileri = ServisYonetimi.Genel.GetMalinGidecekYerBilgileri(mgz, aracPlaka, 19, belgeNo, 207);
            return result;
        }
        private void HaleGonder(List<SevkMagaza> mgz, BildirimItem siparis)
        {
            List<BildirimKayitCevap> cevap = null;
            List<BildirimKayitIstek> istekList = new List<BildirimKayitIstek>();
            string islemKodu = "";

            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();

            istekList.Clear();
            foreach (var item in mgz)
            {
                HKSSube sube = ent.HKSSubeler.Where(x => x.ID == item.Id).FirstOrDefault();
                item.GuidNo = Guid.NewGuid().ToString();
                item.AracPlaka = item.AracPlaka;
                item.BelgeNo = item.BelgeNo;
                var singleIstek = this.BuildSingleIstek(siparis, item, sube, item.AracPlaka, item.BelgeNo);
                singleIstek.UniqueId = item.GuidNo;
                istekList.Add(singleIstek);
            }
            if (istekList.Count > 0)
            {
                using (BildirimServiceClient proxy = new BildirimServiceClient())
                {
                    var getResult = proxy.BildirimServisBildirimKaydet(istekList, Settings.Instance.Sifre, Settings.Instance.WbServiceSifre, Settings.Instance.VgNo, out islemKodu, out cevap);
                    if (getResult.Count > 0)
                    {
                        //yield return "Hata Kodları Yazılıyor...";
                    }
                }
            }

            if (cevap == null)
            {
                //yield return "Hks'den Bilgi Alınamadı.";
            }
            else if (cevap != null)
            {

                foreach (var item in cevap)
                {
                    if (item != null)
                    {
                        var getItem = mgz.Where(x => x.GuidNo == item.UniqueId).FirstOrDefault();
                        if (getItem != null && item.HataKodu == 0)
                        {
                            getItem.KayitTarihi = item.KayitTarihi;
                            getItem.UreticisininAdUnvani = item.UreticisininAdUnvani;
                            getItem.MalinCinsKodNo = item.MalinKodNo;
                            getItem.MalinSahibAdi = item.MalinSahibAdi;
                            getItem.UretimIlId = item.UretimIlId;
                            getItem.UretimIlceId = item.UretimIlceId;
                            getItem.UretimBeldeId = item.UretimBeldeId;
                            getItem.UretimSekli = item.UretimSekli;
                            //getItem.NihaiKunye = item.YeniKunyeNo;
                            getItem.HksHataAciklama = "Nihai Künye Oluşturuldu";
                            getItem.NihaiKunye = item.YeniKunyeNo;
                            getItem.KunyeNo = siparis.KunyeNo;
                            getItem.HksHataKodu = item.HataKodu;
                            ent.HksSevkler.AddObject(new HksSevk
                            {
                                KayitTarihi = getItem.KayitTarihi,
                                AracPlakaNo = getItem.AracPlaka,
                                GidecekIsyeriId = getItem.Id,
                                BelgeNo = getItem.BelgeNo,
                                BelgeTipi = siparis.BelgeTipi,
                                BildirimciTcKimlikVergiNo = siparis.BildirimciTcKimlikVergiNo,
                                BildirimTarihi = DateTime.Now,
                                BildirimTuru = 196,
                                HksHataAciklama = getItem.HksHataAciklama,
                                HksHataKodu = getItem.HksHataKodu,
                                KunyeNo = siparis.KunyeNo.ToString(),
                                MalinAdi = siparis.MalinAdi,
                                MalinCinsi = siparis.MalinCinsi,
                                MalinCinsKodNo = getItem.MalinCinsKodNo,
                                MalinKodNo = siparis.MalinKodNo,
                                MalinMiktari = getItem.SevkMiktar,
                                MalinSahibAdi = getItem.MalinSahibAdi,
                                MalinSahibiTcKimlikVergiNo = siparis.MalinSahibiTcKimlikVergiNo,
                                MalinSatisFiyati = getItem.SatisFiyat,
                                MalinTuru = siparis.MalinTuru,
                                MalinTuruKodNo = siparis.MalinTuruKodNo,
                                MiktarBirimiAd = siparis.MiktarBirimiAd,
                                MiktarBirimId = siparis.MiktarBirimId,
                                NihaiKunyeNo = getItem.NihaiKunye.ToString(),
                                RusumMiktari = siparis.RusumMiktari,
                                Sifat = siparis.Sifat,
                                UniqueId = getItem.GuidNo,
                                UreticisininAdUnvani = getItem.UreticisininAdUnvani,
                                UreticiTcKimlikVergiNo = siparis.UreticiTcKimlikVergiNo,
                                UretimBeldeId = getItem.UretimBeldeId,
                                UretimIlceId = getItem.UretimIlceId,
                                UretimIlId = getItem.UretimIlId,
                                UretimSekli = getItem.UretimSekli,
                                ilkBildirimTarihi = getItem.İlkBildirimtarihi
                                
                            });
                            ent.SaveChanges();
                        }
                        else
                        {
                            getItem.HksHataKodu = item.HataKodu;
                            getItem.HksHataAciklama = string.Format("{0}", item.Mesaj);
                            hataliKunyeler += "Ürün Adı :" + siparis.MalinAdi + " Künye :" + getItem.KunyeNo + " Hata Açıklama :" + getItem.HksHataAciklama;
                        }
                    }
                }
            }
        }
        #endregion
        void FrmBildirimListesi_Load(object sender, EventArgs e)
        {
            dtIlkTarih.EditValue = DateTime.Now.AddMonths(-2);
            dtSonTarih.EditValue = DateTime.Now;
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            GetListele(Convert.ToDateTime(dtIlkTarih.Text), Convert.ToDateTime(dtSonTarih.Text));
        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            GetListele(Convert.ToDateTime(dtIlkTarih.Text), Convert.ToDateTime(dtSonTarih.Text));
        }
        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gridView1.FocusedColumn.FieldName == "SevkMiktar" && cmbKunyeTuru.SelectedIndex == 1)
            {
                var getKunye = gridView1.GetRow(gridView1.FocusedRowHandle) as BildirimItem;
                using (FrmMagazaSevk frmMgz = new FrmMagazaSevk(getKunye.MalinAdi, getKunye.MalinSatisFiyati, getKunye.KalanMiktar, getKunye.İlkBildirimtarihi))
                {
                    if (getKunye.SevkKunyeler != null && getKunye.SevkKunyeler.Count > 0)
                        frmMgz.Magazalar.AddRange(getKunye.SevkKunyeler.ToArray());
                    if (MagazaBelgeAracPlakalari.Count > 0)
                        frmMgz.MagazaBelgeAracPlakalari.AddRange(MagazaBelgeAracPlakalari.ToArray());
                    if (frmMgz.ShowDialog() == DialogResult.OK)
                    {
                        if (getKunye.SevkKunyeler == null)
                            getKunye.SevkKunyeler = new List<SevkMagaza>();
                        else
                            getKunye.SevkKunyeler.Clear();
                        getKunye.SevkKunyeler.AddRange(frmMgz.Magazalar.Where(x => x.AracPlaka != "" && x.BelgeNo != "" && x.SevkMiktar > 0).ToArray());
                        MagazaBelgeAracPlakalari.Clear();
                        MagazaBelgeAracPlakalari.AddRange(frmMgz.MagazaBelgeAracPlakalari.ToArray());
                    }
                }
                gridView1.FocusedRowHandle += +1;
                var count = items.Sum(x => x.SevkMiktar);
                if (count > 0)
                    btnSevk.Visible = true;
                else
                    btnSevk.Visible = false;
            }
        }
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                BildirimItem row = View.GetRow(e.RowHandle) as BildirimItem;
                if (row.SevkMiktar > 0)
                {
                    e.Appearance.BackColor = Color.LawnGreen;
                    e.Appearance.BackColor2 = Color.SeaShell;
                    e.HighPriority = true;
                }
            }
        }
        private void btnSevk_Click(object sender, EventArgs e)
        {
            //using (FrmMagazaSevk frmMgz = new FrmMagazaSevk())
            //{
            //    if (frmMgz.ShowDialog() == DialogResult.OK)
            //    {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                hataliKunyeler = "";
                foreach (var halitem in items.Where(x => x.SevkMiktar > 0).ToList())
                {
                    if (halitem.SevkKunyeler != null)
                        HaleGonder(halitem.SevkKunyeler, halitem);
                }
                if (!string.IsNullOrWhiteSpace(hataliKunyeler))
                {
                    using (FrmHata frm = new FrmHata())
                    {
                        frm.HataliKunyeler = hataliKunyeler;
                        frm.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                HataLog.Instance.HataLogYaz(ex);
            }
            this.Cursor = Cursors.Default;
            MessageBox.Show("Sevk İşlemi Tamamlandı");
            //    }
            //}
        }

        private void btnKalanMiktarEsitle_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            List<HKSSube> subeler = new List<HKSSube>();
            using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
            {
                if (MagazaBelgeAracPlakalari.Count > 0)
                {
                    subeler = (from magaza in MagazaBelgeAracPlakalari
                               join sube in ent.HKSSubeler on magaza.ID equals sube.ID
                               select sube).ToList();
                }

            }
            for (int i = 0; i < items.Count; i++)
            {

                var getKunye = gridView1.GetRow(i) as BildirimItem;
                using (FrmMagazaSevk frmMgz = new FrmMagazaSevk(getKunye.MalinAdi, getKunye.MalinSatisFiyati, getKunye.KalanMiktar, getKunye.İlkBildirimtarihi))
                {
                    frmMgz.Subeler = subeler;
                    frmMgz.Otomatik = true;
                    
                    if (getKunye.SevkKunyeler != null && getKunye.SevkKunyeler.Count > 0)
                        frmMgz.Magazalar.AddRange(getKunye.SevkKunyeler.ToArray());
                    if (MagazaBelgeAracPlakalari.Count > 0)
                        frmMgz.MagazaBelgeAracPlakalari.AddRange(MagazaBelgeAracPlakalari.ToArray());
                    if (frmMgz.ShowDialog() == DialogResult.OK)
                    {
                        if (getKunye.SevkKunyeler == null)
                            getKunye.SevkKunyeler = new List<SevkMagaza>();
                        else
                            getKunye.SevkKunyeler.Clear();
                        getKunye.SevkKunyeler.AddRange(frmMgz.Magazalar.Where(x => x.AracPlaka != "" && x.BelgeNo != "" && x.SevkMiktar > 0).ToArray());
                        MagazaBelgeAracPlakalari.Clear();
                        MagazaBelgeAracPlakalari.AddRange(frmMgz.MagazaBelgeAracPlakalari.ToArray());
                    }
                }
                gridView1.FocusedRowHandle = i;
                gridView1.SelectRow(i);
            }
            this.Cursor = Cursors.Default;
        }
    }
}
