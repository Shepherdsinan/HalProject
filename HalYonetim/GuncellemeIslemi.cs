using CrmPosHalYonetim.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HalYonetim
{
    public class HksGuncellemeIslemi
    {
        public IEnumerable<string> GuncellemeyiBaslat(GuncellemeSirasi tip)
        {
            switch (tip)
            {
                case GuncellemeSirasi.UretimSekliGuncelle:
                    foreach (var item in UretimSekliGuncelle())
                        yield return item;
                    break;
                case GuncellemeSirasi.BildirimGuncelle:
                    foreach (var item in BildirimGuncelle())
                        yield return item;
                    break;
                case GuncellemeSirasi.BirimGuncelle:
                    foreach (var item in BirimGuncelle())
                        yield return item;
                    break;
                case GuncellemeSirasi.StokGuncelle:
                    foreach (var item in StokGuncelle())
                        yield return item;
                    break;
                case GuncellemeSirasi.CinsGuncelle:
                    foreach (var item in CinsGuncelle())
                        yield return item;
                    break;
                case GuncellemeSirasi.MagazaGuncelle:
                    foreach (var item in MagazaGuncelle())
                        yield return item;
                    break;
                case GuncellemeSirasi.BelgeGuncelle:
                    foreach (var item in BelgeGuncelle())
                        yield return item;
                    break;
                case GuncellemeSirasi.IsletmeTuruGuncelle:
                    foreach (var item in IsletmeTuruGuncelle())
                        yield return item;
                    break;
                case GuncellemeSirasi.IlGuncelle:
                    foreach (var item in IlGuncelle())
                        yield return item;
                    break;
                
            }
        }
        #region Insert Update
        private IEnumerable<string> BirimGuncelle()
        {
            yield return "Birim Güncelleniyor...";
            List<HKSBirim> list = ServisYonetimi.Genel.GetUrunBirimListesi(true);
            using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
            {
                foreach (var item in list)
                {
                    var getRecord = ent.HKSBirimler.Where(x => x.ID == item.ID).FirstOrDefault();
                    if (getRecord != null)
                        getRecord.Adi = item.Adi;
                    else
                        ent.AddToHKSBirimler(new HKSBirim { ID = item.ID, Adi = item.Adi });
                    ent.SaveChanges();
                    yield return item.Adi;
                }
            }
        }
        private IEnumerable<string> BildirimGuncelle()
        {
            yield return "Bildirim Güncelleniyor...";
            List<HKSBildirim> list = ServisYonetimi.Genel.GetBildirimTuruListesi(true);
            using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
            {
                foreach (var item in list)
                {
                    var getRecord = ent.HKSBildirimler.Where(x => x.ID == item.ID).FirstOrDefault();
                    if (getRecord != null)
                        getRecord.Adi = item.Adi;
                    else
                        ent.AddToHKSBildirimler(new HKSBildirim { ID = item.ID, Adi = item.Adi });
                    ent.SaveChanges();
                    yield return item.Adi;
                }
            }
        }
        private IEnumerable<string> UretimSekliGuncelle()
        {
            yield return "Üretim Bilgileri Güncelleniyor...";
            List<HKSUretimSekli> list = ServisYonetimi.Genel.GetUrunUretimListesi(true);
            using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
            {
                foreach (var item in list)
                {
                    var getRecord = ent.HKSUretimSekilleri.Where(x => x.ID == item.ID).FirstOrDefault();
                    if (getRecord != null)
                    {
                        getRecord.UretimSekliAdi = item.UretimSekliAdi;
                    }
                    else
                    {
                        ent.AddToHKSUretimSekilleri(new HKSUretimSekli { ID = item.ID, UretimSekliAdi = item.UretimSekliAdi });
                    }
                    ent.SaveChanges();
                    yield return item.UretimSekliAdi;
                }
            }
        }
        private IEnumerable<string> StokGuncelle()
        {
            yield return "Stok Güncelleniyor...";
            List<HKSStok> list = ServisYonetimi.Genel.GetUrunListesi(true);
            using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
            {
                foreach (var item in list)
                {
                    var getRecord = ent.HKSStoklar.Where(x => x.ID == item.ID).FirstOrDefault();
                    if (getRecord != null)
                    {
                        getRecord.Adi = item.Adi;
                    }
                    else
                    {
                        ent.AddToHKSStoklar(new HKSStok { ID = item.ID, Adi = item.Adi });
                    }
                    ent.SaveChanges();
                    yield return item.Adi;
                }
            }
        }
        private IEnumerable<string> CinsGuncelle()
        {
            yield return "Stok Cinsi Güncelleniyor...";
            List<HKSCins> list = ServisYonetimi.Genel.GetUrunCinsListesi(true);
            using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
            {
                foreach (var item in list)
                {
                    var getRecord = ent.HKSCinsler.Where(x => x.ID == item.ID).FirstOrDefault();
                    if (getRecord != null)
                    {
                        getRecord.CinsAdi = item.UrunAdi;
                        getRecord.Ithalmi = item.Ithalmi;
                        getRecord.UretimSekliID = item.UretimSekliID;
                        getRecord.UrunAdi = item.UrunAdi;
                        getRecord.UrunKodu = item.UrunKodu;
                        getRecord.UrunID = item.UrunID;

                    }
                    else
                    {
                        ent.AddToHKSCinsler(new HKSCins { ID = item.ID, UrunID = item.UrunID, UrunAdi = item.UrunAdi, UretimSekliID = item.UretimSekliID, Ithalmi = item.Ithalmi, CinsAdi = item.UrunAdi, UrunKodu = item.UrunKodu });
                    }
                    ent.SaveChanges();
                    yield return item.UrunAdi;
                }
            }
        }
        private IEnumerable<string> MagazaGuncelle()
        {
            yield return "Şube Güncelleniyor...";
            List<HKSSube> list = ServisYonetimi.Genel.GetSubeListesi(true);
            using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
            {
                foreach (var item in list)
                {
                    var getRecord = ent.HKSSubeler.Where(x => x.ID == item.ID).FirstOrDefault();
                    if (getRecord != null)
                    {                        
                        getRecord.Adres = item.Adres;
                        getRecord.BeldeID = item.BeldeID;
                        getRecord.IlceID = item.IlceID;
                        getRecord.IlID = item.IlID;
                        getRecord.IsYeriTuru = item.IsYeriTuru;
                        getRecord.SubeAdi = item.SubeAdi;
                    }
                    else
                    {                   

                        ent.AddToHKSSubeler(new HKSSube
                        {
                            ID = item.ID,
                            Adres = item.Adres,
                            BeldeID = item.BeldeID,
                            IlceID = item.IlceID,
                            IlID = item.IlID,
                            IsYeriTuru = item.IsYeriTuru,
                            SubeAdi = item.SubeAdi
                        });
                    }          
                   

                    ent.SaveChanges();
                    yield return item.SubeAdi;
                }
            }
        }
        private IEnumerable<string> IsletmeTuruGuncelle()
        {
            yield return "İşletme Türleri Güncelleniyor...";
            List<HKSIsletme> list = ServisYonetimi.Genel.GetIsletmeTuruListesi(true);
            using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
            {
                foreach (var item in list)
                {
                    var getRecord = ent.HKSIsletmeler.Where(x => x.ID == item.ID).FirstOrDefault();
                    if (getRecord != null)
                    {
                        getRecord.Adi = item.Adi;
                    }
                    else
                    {
                        ent.AddToHKSIsletmeler(new HKSIsletme { ID = item.ID, Adi = item.Adi });
                    }
                    ent.SaveChanges();
                    yield return item.Adi;
                }
            }
        }
        private IEnumerable<string> BelgeGuncelle()
        {
            yield return "Belge Türleri Güncelleniyor...";
            List<HKSBelge> list = ServisYonetimi.Genel.GetBelgeListesi(true);
            using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
            {
                foreach (var item in list)
                {
                    var getRecord = ent.HKSBelgeler.Where(x => x.ID == item.ID).FirstOrDefault();
                    if (getRecord != null)
                        getRecord.Belge = item.Belge;
                    else
                        ent.AddToHKSBelgeler(new HKSBelge { ID = item.ID, Belge = item.Belge });
                    ent.SaveChanges();
                    yield return item.Belge;
                }
            }
        }
        private IEnumerable<string> IlGuncelle()
        {
            yield return "İller,İlçeler ve Beldeler Güncelleniyor...";
            List<HKSIL> list = ServisYonetimi.Genel.GetIlListesi(true);
            using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
            {
                foreach (var item in list)
                {
                    var getRecord = ent.HKSIller.Where(x => x.ID == item.ID).FirstOrDefault();
                    if (getRecord != null)
                        getRecord.Adi = item.Adi;
                    else
                        ent.AddToHKSIller(new HKSIL { ID = item.ID, Adi = item.Adi });
                    ent.SaveChanges();
                    IlceGuncelle(item.ID);
                    yield return item.Adi;
                }
            }
        }
        private void IlceGuncelle(int id)
        {
            List<HKSIlce> list = ServisYonetimi.Genel.GetIlceListesi(id, true);
            using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
            {
                foreach (var item in list)
                {
                    int ilceID = 0;
                    var getRecord = ent.HKSIlceler.Where(x => x.ID == item.ID).FirstOrDefault();
                    if (getRecord != null)
                    {
                        getRecord.Adi = item.Adi;
                        ilceID = getRecord.ID;
                        ent.SaveChanges();
                    }
                    else
                    {
                        HKSIlce ilce = new HKSIlce { ID = item.ID, Adi = item.Adi };
                        ent.AddToHKSIlceler(ilce);
                        ent.SaveChanges();
                        ilceID = ilce.ID;
                    }
                    List<HKSBelde> beldeList = ServisYonetimi.Genel.GetBeldeListesi(ilceID);
                    foreach (var belde in beldeList)
                    {
                        var getBelde = ent.HKSBeldeler.Where(x => x.ID == belde.ID).FirstOrDefault();
                        if (getBelde != null)
                            getRecord.Adi = belde.Adi;
                        else
                            ent.AddToHKSBeldeler(new HKSBelde { Adi = belde.Adi, ID = belde.ID });
                        ent.SaveChanges();
                    }
                }
            }
        }
        #endregion
    }
    public enum GuncellemeSirasi : byte
    {
        UretimSekliGuncelle = 0,
        BildirimGuncelle = 1,
        BirimGuncelle = 2,
        StokGuncelle = 3,
        CinsGuncelle = 4,
        MagazaGuncelle = 5,
        BelgeGuncelle = 6,
        IsletmeTuruGuncelle = 7,
        IlGuncelle = 8,
    }
}
