using CrmPosHalYonetim.Entity;
using HalYonetim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrmPosHalYonetim.HksStokYonetim
{
    public class StyStokGirisCikisIslem
    {
        private static StyStokGirisCikisIslem _instance;
        public static StyStokGirisCikisIslem Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new StyStokGirisCikisIslem();
                return _instance;
            }
        }
        /// <summary>
        /// girisSevk true ise giriş false sevk
        /// </summary>
        /// <param name="ent"></param>
        /// <param name="girisSevk"></param>
        /// <param name="stokKodu"></param>
        /// <param name="birimMiktar"></param>
        /// <param name="kasaMiktar"></param>
        /// <param name="iadeKasaMiktar"></param>
        /// <returns></returns>
        public bool EkleCikar(bool girisSevk, StyStokMiktar styMiktar)
        {
            bool sonuc = false;
            try
            {
                using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
                {
                    if (girisSevk)
                    {
                        DateTime bsTarih = new DateTime(styMiktar.Tarih.Value.Year, styMiktar.Tarih.Value.Month, styMiktar.Tarih.Value.Day, 0, 0, 0);
                        DateTime btTarih = new DateTime(styMiktar.Tarih.Value.Year, styMiktar.Tarih.Value.Month, styMiktar.Tarih.Value.Day, 23, 59, 59);

                        var getRecord = ent.StyStokMiktarlar.Where(x => x.Tarih >= bsTarih && x.Tarih <= btTarih && x.DepoNo == styMiktar.DepoNo && x.CariKod == styMiktar.CariKod && x.BirmFiyat == styMiktar.BirmFiyat && x.StokKodu == styMiktar.StokKodu).FirstOrDefault();
                        if (getRecord == null)
                        {
                            ent.StyStokMiktarlar.AddObject(new StyStokMiktar
                            {
                                BirimMiktar = styMiktar.BirimMiktar,
                                StokKodu = styMiktar.StokKodu,
                                DepoNo = styMiktar.DepoNo,
                                Tarih = styMiktar.Tarih,
                                CariKod = styMiktar.CariKod,
                                BirmFiyat = styMiktar.BirmFiyat,
                                IadeKasaMiktar = styMiktar.IadeKasaMiktar,
                                KasaMiktar = styMiktar.KasaMiktar
                            });
                        }
                        else
                        {
                            getRecord.BirimMiktar += styMiktar.BirimMiktar;
                            if (styMiktar.IadeKasaMiktar > 0)
                                getRecord.IadeKasaMiktar += styMiktar.IadeKasaMiktar;
                            if (styMiktar.KasaMiktar > 0)
                                getRecord.KasaMiktar += styMiktar.KasaMiktar;
                        }
                        ent.SaveChanges();
                    }
                    else
                    {
                        var getRecord = styMiktar.ID > 0 ? ent.StyStokMiktarlar.Where(x => x.ID == styMiktar.ID).FirstOrDefault() : ent.StyStokMiktarlar.Where(x => x.StokKodu == styMiktar.StokKodu && x.CariKod == styMiktar.CariKod && x.DepoNo == styMiktar.DepoNo).FirstOrDefault();
                        if (getRecord != null)
                        {
                            getRecord.BirimMiktar -= styMiktar.BirimMiktar;
                            if (styMiktar.IadeKasaMiktar > 0)
                                getRecord.IadeKasaMiktar -= styMiktar.IadeKasaMiktar;
                            if (styMiktar.KasaMiktar > 0)
                                getRecord.KasaMiktar -= styMiktar.KasaMiktar;
                            ent.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HataLog.Instance.HataLogYaz(ex);
            }
            return sonuc;
        }
        public List<StyStokMiktar> StyStokEldekiMiktar(string depo, string stok)
        {
            List<StyStokMiktar> sonuc = new List<StyStokMiktar>();
            try
            {
                using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
                {
                    var getRecord = ent.StyStokMiktarlar.Where(x => x.StokKodu == stok && x.DepoNo == depo && x.BirimMiktar > 0).OrderBy(x => x.Tarih).ToList();
                    if (getRecord.Count > 0)
                    {
                        foreach (var item in getRecord)
                            sonuc.Add(item);
                    }
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
