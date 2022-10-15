using CrmPosHalYonetim.Entity;
using HalYonetim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrmPosHalYonetim.HksStokYonetim
{
    public class StyCariIslem
    {
        private static StyCariIslem _instance;
        public static StyCariIslem Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new StyCariIslem();
                return _instance;
            }
        }
        public bool CariKaydet(StyCari cari)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                var getCari = ent.StyCariler.Where(x => x.Kodu == cari.Kodu).FirstOrDefault();
                if (getCari == null)
                {
                    ent.StyCariler.AddObject(cari);
                    ent.SaveChanges();
                    return true;
                }
                else
                {
                    getCari.Adi = cari.Adi;
                    getCari.FaturaAdres = cari.FaturaAdres;
                    getCari.FaturaAdres_IL = cari.FaturaAdres_IL;
                    getCari.FaturaAdresIlce = cari.FaturaAdresIlce;
                    getCari.SevkAdres = cari.SevkAdres;
                    getCari.SevkAdresIL = cari.SevkAdresIL;
                    getCari.SevkAdresIlce = cari.SevkAdresIlce;

                    ent.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                HataLog.Instance.HataLogYaz(ex);
                return false;
            }
        }
        public bool CariSil(StyCari cari)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                var getCari = ent.StyCariler.Where(x => x.Kodu == cari.Kodu).FirstOrDefault();
                if (getCari != null)
                {
                    ent.StyCariler.DeleteObject(getCari);
                    ent.SaveChanges();
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {
                HataLog.Instance.HataLogYaz(ex);
                return false;
            }
        }
        public StyCari CariGetir(string cariKodu)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                var getCari = ent.StyCariler.Where(x => x.Kodu == cariKodu).FirstOrDefault();
                if (getCari != null)
                {
                    return getCari;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                HataLog.Instance.HataLogYaz(ex);
                return null;
            }
        }
        public List<string> FaturaILIsimleri()
        {
            List<string> sonuc = new List<string>();
            try
            {
                HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
                var faturaIller = ent.StyCariler.GroupBy(x => new { x.FaturaAdres_IL }).Select(x => x.Key);
                foreach (var item in faturaIller)
                {
                    if (!sonuc.Contains(item.FaturaAdres_IL))
                        sonuc.Add(item.FaturaAdres_IL);
                }
                var sevkIller = ent.StyCariler.GroupBy(x => new { x.SevkAdresIL }).Select(x => x.Key);
                foreach (var item in sevkIller)
                {
                    if (!sonuc.Contains(item.SevkAdresIL))
                        sonuc.Add(item.SevkAdresIL);
                }
            }
            catch (Exception ex)
            {
                HataLog.Instance.HataLogYaz(ex);
            }
            return sonuc;
        }
        public List<string> FaturaIlceIsimleri()
        {
            List<string> sonuc = new List<string>();
            try
            {
                HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
                var faturaIlceIsimleri = ent.StyCariler.GroupBy(x => new { x.FaturaAdresIlce }).Select(x => x.Key);
                foreach (var item in faturaIlceIsimleri)
                {
                    if (!sonuc.Contains(item.FaturaAdresIlce))
                        sonuc.Add(item.FaturaAdresIlce);
                }
                var sevkIlceIsimleri = ent.StyCariler.GroupBy(x => new { x.SevkAdresIlce }).Select(x => x.Key);
                foreach (var item in sevkIlceIsimleri)
                {
                    if (!sonuc.Contains(item.SevkAdresIlce))
                        sonuc.Add(item.SevkAdresIlce);
                }
            }
            catch (Exception ex)
            {
                HataLog.Instance.HataLogYaz(ex);
            }
            return sonuc;
        }

    }
}
