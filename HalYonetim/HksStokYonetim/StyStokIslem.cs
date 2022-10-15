using CrmPosHalYonetim.Entity;
using HalYonetim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrmPosHalYonetim.HksStokYonetim
{
    public class StyStokIslem
    {
        private static StyStokIslem _instance;
        public static StyStokIslem Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new StyStokIslem();
                return _instance;
            }
        }
        public bool StokKaydet(StyStok stok)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                var getStok = ent.StyStoklar.Where(x => x.Kodu == stok.Kodu).FirstOrDefault();
                if (getStok == null)
                {
                    ent.StyStoklar.AddObject(stok);
                    ent.SaveChanges();
                    return true;
                }
                else
                {
                    getStok.Fiyat = stok.Fiyat;
                    getStok.Adi = stok.Adi;
                    getStok.Birim1 = stok.Birim1;
                    getStok.Birim2 = stok.Birim2;
                    getStok.Birim3 = stok.Birim3;
                    getStok.Birim4 = stok.Birim4;
                    getStok.Katsayi1 = stok.Katsayi1;
                    getStok.Katsayi2 = stok.Katsayi2;
                    getStok.Katsayi3 = stok.Katsayi3;
                    getStok.Katsayi4 = stok.Katsayi4;
                    getStok.KdvOran = stok.KdvOran;
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
        public bool StokSil(StyStok stok)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                var getStok = ent.StyStoklar.Where(x => x.Kodu == stok.Kodu).FirstOrDefault();
                if (getStok != null)
                {
                    ent.StyStoklar.DeleteObject(getStok);
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
        public StyStok StokGetir(string stokKodu)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                var getStok = ent.StyStoklar.Where(x => x.Kodu == stokKodu).FirstOrDefault();
                if (getStok != null)
                {
                    return getStok;
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
        public List<string> BirimIsimleri()
        {
            List<string> sonuc = new List<string>();
            try
            {
                HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
                var birimler = ent.StyStoklar.GroupBy(x => new { x.Birim1, x.Birim2, x.Birim3, x.Birim4 }).Select(x => x.Key);
                foreach (var item in birimler)
                {
                    if (!string.IsNullOrWhiteSpace(item.Birim1) && !sonuc.Contains(item.Birim1))
                        sonuc.Add(item.Birim1);
                    if (!string.IsNullOrWhiteSpace(item.Birim2) && !sonuc.Contains(item.Birim2))
                        sonuc.Add(item.Birim2);
                    if (!string.IsNullOrWhiteSpace(item.Birim3) && !sonuc.Contains(item.Birim3))
                        sonuc.Add(item.Birim3);
                    if (!string.IsNullOrWhiteSpace(item.Birim4) && !sonuc.Contains(item.Birim4))
                        sonuc.Add(item.Birim4);
                }
            }
            catch (Exception ex)
            {
                HataLog.Instance.HataLogYaz(ex);
            }
            return sonuc;
        }
        public List<ComboItem> BirimIsimleri(string stokKodu)
        {
            List<ComboItem> sonuc = new List<ComboItem>();
            try
            {
                HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
                var item = ent.StyStoklar.Where(x => x.Kodu == stokKodu).Select(x => new { x.Birim1, x.Katsayi1, x.Birim2, x.Katsayi2, x.Birim3, x.Katsayi3, x.Birim4, x.Katsayi4 }).FirstOrDefault();

                if (!string.IsNullOrWhiteSpace(item.Birim1))
                    sonuc.Add(new ComboItem { Text = item.Birim1, Value = item.Katsayi1 });
                if (!string.IsNullOrWhiteSpace(item.Birim2))
                    sonuc.Add(new ComboItem { Text = item.Birim2, Value = item.Katsayi2 });
                if (!string.IsNullOrWhiteSpace(item.Birim3))
                    sonuc.Add(new ComboItem { Text = item.Birim3, Value = item.Katsayi3 });
                if (!string.IsNullOrWhiteSpace(item.Birim4))
                    sonuc.Add(new ComboItem { Text = item.Birim4, Value = item.Katsayi4 });

            }
            catch (Exception ex)
            {
                HataLog.Instance.HataLogYaz(ex);
            }
            return sonuc;
        }
        public List<double> Kdvler()
        {
            List<double> sonuc = new List<double>();
            try
            {
                HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
                var birimler = ent.StyStoklar.GroupBy(x => new { x.KdvOran }).Select(x => x.Key);
                foreach (var item in birimler)
                {
                    if (!sonuc.Contains(item.KdvOran.Value))
                        sonuc.Add(item.KdvOran.Value);
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
