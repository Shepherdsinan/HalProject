using CrmPosHalYonetim.Entity;
using HalYonetim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrmPosHalYonetim.HksStokYonetim
{
    public class StyKasaIslem
    {
        private static StyKasaIslem _instance;
        public static StyKasaIslem Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new StyKasaIslem();
                return _instance;
            }
        }
        public bool KasaKaydet(StyKasa kasa)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                var getKasa = ent.StyKasalar.Where(x => x.No == kasa.No).FirstOrDefault();
                if (getKasa == null)
                {
                    ent.StyKasalar.AddObject(kasa);
                    ent.SaveChanges();
                    return true;
                }
                else
                {
                    getKasa.Tanim = kasa.Tanim;
                    getKasa.Iadelimi = kasa.Iadelimi;
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
        public bool KasaSil(StyKasa kasa)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                var getKasa = ent.StyKasalar.Where(x => x.No == kasa.No).FirstOrDefault();
                if (getKasa != null)
                {
                    ent.StyKasalar.DeleteObject(getKasa);
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
        public StyKasa KasaGetir(string kasaNo)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                var getDepo = ent.StyKasalar.Where(x => x.No == kasaNo).FirstOrDefault();
                if (getDepo != null)
                {
                    return getDepo;
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
        public ComboItem ComboKasaGetir(string kasaNo)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                var getKasa = ent.StyKasalar.Where(x => x.No == kasaNo).FirstOrDefault();
                if (getKasa != null)
                {
                    return new ComboItem { Text = getKasa.Tanim, Value = getKasa.No };
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
        public List<StyKasa> Kasalar(bool iade)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                var getDepo = ent.StyKasalar.Where(x => x.Iadelimi == iade).ToList();
                if (getDepo != null)
                {
                    return getDepo;
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
        public List<StyKasa> TumKasalar()
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                var getDepo = ent.StyKasalar.ToList();
                if (getDepo != null)
                {
                    return getDepo;
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
        public bool KasaMiktarHareket(bool giris, StyKasaMiktar kasa)
        {
            bool sonuc = false;
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                if (giris)
                {
                    DateTime bsTarih = new DateTime(kasa.Tarih.Value.Year, kasa.Tarih.Value.Month, kasa.Tarih.Value.Day, 0, 0, 0);
                    DateTime btTarih = new DateTime(kasa.Tarih.Value.Year, kasa.Tarih.Value.Month, kasa.Tarih.Value.Day, 23, 59, 59);

                    var getRecord = ent.StyKasaMiktarlar.Where(x => x.Tarih >= bsTarih && x.Tarih <= btTarih && x.DepoNo == kasa.DepoNo && x.KasaNo == kasa.KasaNo && x.CariKod == kasa.CariKod && x.GirisCikis == 0).FirstOrDefault();
                    if (getRecord == null)
                    {
                        ent.StyKasaMiktarlar.AddObject(new StyKasaMiktar
                        {
                            DepoNo = kasa.DepoNo,
                            Tarih = kasa.Tarih,
                            CariKod = kasa.CariKod,
                            KasaNo = kasa.KasaNo,
                            GirisCikis = 0,
                            Miktar = kasa.Miktar,
                        });
                    }
                    else
                    {
                        getRecord.Miktar += kasa.Miktar;
                    }
                    ent.SaveChanges();
                }
                else
                {
                    DateTime bsTarih = new DateTime(kasa.Tarih.Value.Year, kasa.Tarih.Value.Month, kasa.Tarih.Value.Day, 0, 0, 0);
                    DateTime btTarih = new DateTime(kasa.Tarih.Value.Year, kasa.Tarih.Value.Month, kasa.Tarih.Value.Day, 23, 59, 59);

                    var getRecord = ent.StyKasaMiktarlar.Where(x => x.Tarih >= bsTarih && x.Tarih <= btTarih && x.DepoNo == kasa.DepoNo && x.KasaNo == kasa.KasaNo && x.CariKod == kasa.CariKod && x.GirisCikis == 1).FirstOrDefault();
                    if (getRecord == null)
                    {
                        ent.StyKasaMiktarlar.AddObject(new StyKasaMiktar
                        {
                            DepoNo = kasa.DepoNo,
                            Tarih = kasa.Tarih,
                            CariKod = kasa.CariKod,
                            KasaNo = kasa.KasaNo,
                            GirisCikis = 1,
                            Miktar = kasa.Miktar,
                        });
                    }
                    else
                    {
                        getRecord.Miktar += kasa.Miktar;
                    }
                    ent.SaveChanges();
                }
                sonuc = true;
            }
            catch (Exception ex)
            {
                HataLog.Instance.HataLogYaz(ex);
                return false;
            }
            return sonuc;
        }
        public double KasaEnvanter(string depoNo)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                var getKasa = (from ks in ent.StyKasalar
                               join ksHar in ent.StyKasaMiktarlar on ks.No equals ksHar.KasaNo
                               where ksHar.DepoNo == depoNo && ks.Iadelimi == false
                               group ksHar by ksHar.GirisCikis into grp
                               select new { GirisCikis = grp.Key, Miktar = grp.Sum(x => x.Miktar) }).ToList();
                if (getKasa.Count > 0)
                    return getKasa.Sum(x => x.GirisCikis == 0 ? x.Miktar : x.Miktar * -1).Value;
                else
                    return 0;

            }
            catch (Exception ex)
            {
                HataLog.Instance.HataLogYaz(ex);
                return 0;
            }
        }
        public double IadeKasaEnvanter(string depoNo)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                var getKasa = (from ks in ent.StyKasalar
                               join ksHar in ent.StyKasaMiktarlar on ks.No equals ksHar.KasaNo
                               where ksHar.DepoNo == depoNo && ks.Iadelimi == true
                               group ksHar by ksHar.GirisCikis into grp
                               select new { GirisCikis = grp.Key, Miktar = grp.Sum(x => x.Miktar) }).ToList();
                if (getKasa.Count > 0)
                    return getKasa.Sum(x => x.GirisCikis == 0 ? x.Miktar : x.Miktar * -1).Value;
                else
                    return 0;

            }
            catch (Exception ex)
            {
                HataLog.Instance.HataLogYaz(ex);
                return 0;
            }
        }

    }
}
