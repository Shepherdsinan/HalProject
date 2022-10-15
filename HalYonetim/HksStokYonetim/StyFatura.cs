using CrmPosHalYonetim.Entity;
using HalYonetim;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrmPosHalYonetim.HksStokYonetim
{
    public class Fatura
    {
        private static Fatura _instance;
        public static Fatura Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Fatura();
                return _instance;
            }
        }
        #region Fatura
        public bool FaturaKaydet(StyFatura fatura, List<FaturaSatir> satirlar, byte tip)
        {
            FaturaSil(fatura);
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            ent.Connection.Open();
            using (System.Data.Common.DbTransaction trn = ent.Connection.BeginTransaction())
            {
                try
                {
                    ent.StyFaturalar.AddObject(fatura);
                    ent.SaveChanges();
                    foreach (var item in satirlar)
                    {
                        if (tip == 1)
                        {
                            if (item.IadeKasaTutar > 0 || item.KasaTutar > 0)
                            {
                                ent.StyFaturaHareketleri.AddObject(new StyFaturaHareket
                                {
                                    Birim = "",
                                    FatRec = fatura.ID,
                                    Fiyat = 0,
                                    IadeKasaFiyat = item.IadeKasaFiyat,
                                    IadeKasaMiktar = item.IadeKasaMiktar,
                                    IadeKasaNo = item.IadeKasa != null ? item.IadeKasa.Value.ToString() : "",
                                    IadeKasaTutar = item.IadeKasaTutar,
                                    KasaFiyat = item.KasaFiyat,
                                    KasaMiktar = item.KasaMiktar,
                                    KasaNo = item.Kasa != null ? item.Kasa.Value.ToString() : "",
                                    KasaTutar = item.KasaTutar,
                                    KdvOran = 0,
                                    KdvTutar = 0,
                                    Miktar = 0,
                                    StokKodu = "",
                                    Tutar = 0,
                                });
                            }

                        }
                        else if (!string.IsNullOrWhiteSpace(item.StokKodu) && !string.IsNullOrWhiteSpace(item.StokAdi))
                        {
                            ent.StyFaturaHareketleri.AddObject(new StyFaturaHareket
                            {
                                Birim = item.Birim.Text,
                                IcerikMiktar = Convert.ToDouble(item.Birim.Value),
                                FatRec = fatura.ID,
                                Fiyat = item.Fiyat,
                                IadeKasaFiyat = item.IadeKasaFiyat,
                                IadeKasaMiktar = item.IadeKasaMiktar,
                                IadeKasaNo = item.IadeKasa != null ? item.IadeKasa.Value.ToString() : "",
                                IadeKasaTutar = item.IadeKasaTutar,
                                KasaFiyat = item.KasaFiyat,
                                KasaMiktar = item.KasaMiktar,
                                KasaNo = item.Kasa != null ? item.Kasa.Value.ToString() : "",
                                KasaTutar = item.KasaTutar,
                                KdvOran = item.Vergi != null ? Convert.ToDouble(item.Vergi.Value) : 0,
                                KdvTutar = item.VergiTutar,
                                Miktar = item.Miktar,
                                StokKodu = item.StokKodu,
                                Tutar = item.Tutar,
                            });
                        }
                    }
                    ent.SaveChanges();
                    trn.Commit();

                    foreach (var item in satirlar)
                    {
                        if (!string.IsNullOrWhiteSpace(item.StokKodu) && !string.IsNullOrWhiteSpace(item.StokAdi))
                        {
                            StyStokGirisCikisIslem.Instance.EkleCikar(fatura.BelgeTipi == 0 ? true : false, new StyStokMiktar
                            {
                                BirimMiktar = Convert.ToDouble(item.Birim.Value) * item.Miktar,
                                DepoNo = fatura.DepoNo,
                                StokKodu = item.StokKodu,
                                CariKod = fatura.CariKod,
                                IadeKasaMiktar = item.IadeKasaMiktar,
                                KasaMiktar = item.KasaMiktar,
                                BirmFiyat = item.Fiyat,
                                Tarih = fatura.Tarih
                            });
                        }
                        if (item.Kasa != null && !string.IsNullOrWhiteSpace(item.Kasa.Text) && item.KasaMiktar > 0)
                        {
                            StyKasaIslem.Instance.KasaMiktarHareket(fatura.BelgeTipi == 0 ? true : false, new StyKasaMiktar
                            {
                                DepoNo = fatura.DepoNo,
                                Tarih = fatura.Tarih,
                                CariKod = fatura.CariKod,
                                GirisCikis = fatura.BelgeTipi,
                                Miktar = item.KasaMiktar,
                                KasaNo = item.Kasa.Value.ToString()
                            });
                        }
                        if (item.IadeKasa != null && !string.IsNullOrWhiteSpace(item.IadeKasa.Text) && item.IadeKasaMiktar > 0)
                        {
                            StyKasaIslem.Instance.KasaMiktarHareket(fatura.BelgeTipi == 0 ? true : false, new StyKasaMiktar
                            {
                                DepoNo = fatura.DepoNo,
                                Tarih = fatura.Tarih,
                                CariKod = fatura.CariKod,
                                GirisCikis = fatura.BelgeTipi,
                                Miktar = item.IadeKasaMiktar,
                                KasaNo = item.IadeKasa.Value.ToString()
                            });
                        }
                    }


                    return true;
                }
                catch (Exception ex)
                {
                    HataLog.Instance.HataLogYaz(ex);
                    if (trn != null)
                    {
                        trn.Rollback();
                    }
                    return false;
                }
            }
        }
        public bool FaturaSil(StyFatura fatura)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                if (ent.Connection.State == System.Data.ConnectionState.Closed)
                    ent.Connection.Open();
                using (System.Data.Common.DbTransaction trn = ent.Connection.BeginTransaction())
                {
                    var getRecord = ent.StyFaturalar.Where(x => x.Seri == fatura.Seri && x.Sira == fatura.Sira).FirstOrDefault();
                    if (getRecord != null)
                    {
                        var getHareket = ent.StyFaturaHareketleri.Where(x => x.FatRec == getRecord.ID).ToList();
                        try
                        {
                            foreach (var item in getHareket)
                            {
                                ent.StyFaturaHareketleri.DeleteObject(item);
                            }
                            ent.StyFaturalar.DeleteObject(getRecord);
                            ent.SaveChanges();
                            trn.Commit();
                            foreach (var item in getHareket)
                            {

                                StyStokGirisCikisIslem.Instance.EkleCikar(false, new StyStokMiktar
                                {
                                    BirimMiktar = Convert.ToDouble(item.IcerikMiktar) * item.Miktar,
                                    DepoNo = fatura.DepoNo,
                                    StokKodu = item.StokKodu,
                                    IadeKasaMiktar = item.IadeKasaMiktar,
                                    KasaMiktar = item.KasaMiktar,
                                    BirmFiyat = item.Fiyat,
                                    Tarih = fatura.Tarih
                                });

                                if (item.KasaMiktar > 0)
                                {
                                    StyKasaIslem.Instance.KasaMiktarHareket(false, new StyKasaMiktar
                                    {
                                        DepoNo = fatura.DepoNo,
                                        Tarih = fatura.Tarih,
                                        CariKod = fatura.CariKod,
                                        GirisCikis = fatura.BelgeTipi,
                                        Miktar = item.KasaMiktar,
                                        KasaNo = item.KasaNo.ToString()
                                    });
                                }
                                if (item.IadeKasaMiktar > 0)
                                {
                                    StyKasaIslem.Instance.KasaMiktarHareket(false, new StyKasaMiktar
                                    {
                                        DepoNo = fatura.DepoNo,
                                        Tarih = fatura.Tarih,
                                        CariKod = fatura.CariKod,
                                        GirisCikis = fatura.BelgeTipi,
                                        Miktar = item.IadeKasaMiktar,
                                        KasaNo = item.IadeKasaNo
                                    });
                                }
                            }


                            return true;
                        }
                        catch (Exception ex)
                        {
                            trn.Rollback();
                            HataLog.Instance.HataLogYaz(ex);
                        }
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                HataLog.Instance.HataLogYaz(ex);
                return false;
            }
        }
        public StyFatura FaturaGetir(string seri, int sira)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                StyFatura getFatura = ent.StyFaturalar.Where(x => x.Seri == seri && x.Sira == sira).FirstOrDefault();
                if (getFatura != null)
                {
                    return getFatura;
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
        public List<FaturaSatir> FaturaHareketGetir(StyFatura fatura)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            List<FaturaSatir> sonuc = new List<FaturaSatir>();
            try
            {
                var getFatura = ent.StyFaturaHareketleri.Where(x => x.FatRec == fatura.ID).OrderBy(x => x.ID).ToList();
                int satir = 1;
                foreach (var item in getFatura)
                {

                    FaturaSatir har = new FaturaSatir
                    {
                        Birim = new ComboItem { Text = item.Birim, Value = item.IcerikMiktar },
                        StokKodu = item.StokKodu,
                        Miktar = item.Miktar.Value,
                        VergiTutar = item.KdvTutar.Value,
                        Vergi = new ComboItem { Text = item.KdvOran.ToString(), Value = item.KdvOran },

                        KasaMiktar = item.KasaMiktar.Value,
                        Fiyat = item.Fiyat.Value,

                        IadeKasaFiyat = item.IadeKasaFiyat.Value,
                        IadeKasaMiktar = item.IadeKasaMiktar.Value,
                        KasaFiyat = item.KasaFiyat.Value,
                        Satir = satir,

                    };
                    if (!string.IsNullOrWhiteSpace(item.StokKodu))
                    {
                        har.StokAdi = new StyStokIslem().StokGetir(item.StokKodu).Adi;
                    }

                    if (item.KasaNo != "")
                    {
                        har.Kasa = new ComboItem
                        {
                            Value = item.KasaNo,
                            Text = new StyKasaIslem().KasaGetir(item.KasaNo).Tanim
                        };
                    }
                    else
                        har.Kasa = new ComboItem { Text = "", Value = "" };
                    if (item.IadeKasaNo != "")
                    {
                        har.IadeKasa = new ComboItem
                        {
                            Value = item.IadeKasaNo,
                            Text = new StyKasaIslem().KasaGetir(item.IadeKasaNo).Tanim
                        };
                    }
                    else
                        har.IadeKasa = new ComboItem { Text = "", Value = "" };
                    sonuc.Add(har);

                }
            }
            catch (Exception ex)
            {
                HataLog.Instance.HataLogYaz(ex);
            }

            return sonuc;
        }
        #endregion

        #region Tediye

        public bool TediyeKaydet(StyFatura fatura, List<OdemeHareket> satirlar)
        {
            TediyeSil(fatura);
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            ent.Connection.Open();
            using (System.Data.Common.DbTransaction trn = ent.Connection.BeginTransaction())
            {
                try
                {
                    ent.StyFaturalar.AddObject(fatura);
                    ent.SaveChanges();
                    foreach (var item in satirlar)
                    {
                        ent.StyOdemeHareketleri.AddObject(new StyOdemeHareket
                        {
                            FatRec = fatura.ID,
                            Aciklama = item.Aciklama,
                            OdemeNo = item.OdemeNo,
                            Tutar = item.Tutar
                        });
                    }
                    ent.SaveChanges();
                    trn.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    HataLog.Instance.HataLogYaz(ex);
                    if (trn != null)
                    {
                        trn.Rollback();
                    }
                    return false;
                }
            }
        }
        public bool TediyeSil(StyFatura fatura)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                if (ent.Connection.State == System.Data.ConnectionState.Closed)
                    ent.Connection.Open();
                using (System.Data.Common.DbTransaction trn = ent.Connection.BeginTransaction())
                {
                    var getRecord = ent.StyFaturalar.Where(x => x.Seri == fatura.Seri && x.Sira == fatura.Sira).FirstOrDefault();
                    if (getRecord != null)
                    {
                        var getHareket = ent.StyOdemeHareketleri.Where(x => x.FatRec == getRecord.ID).ToList();
                        try
                        {
                            foreach (var item in getHareket)
                                ent.StyOdemeHareketleri.DeleteObject(item);
                            ent.StyFaturalar.DeleteObject(getRecord);
                            ent.SaveChanges();
                            trn.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            trn.Rollback();
                            HataLog.Instance.HataLogYaz(ex);
                        }
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                HataLog.Instance.HataLogYaz(ex);
                return false;
            }
        }
        public StyFatura TediyeGetir(string seri, int sira)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                StyFatura getFatura = ent.StyFaturalar.Where(x => x.Seri == seri && x.Sira == sira).FirstOrDefault();
                if (getFatura != null)
                {
                    return getFatura;
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
        public List<OdemeHareket> TediyeHareketGetir(StyFatura fatura)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            List<OdemeHareket> sonuc = new List<OdemeHareket>();
            try
            {
                var getFatura = ent.StyOdemeHareketleri.Where(x => x.FatRec == fatura.ID).OrderBy(x => x.ID).ToList();

                foreach (var item in getFatura)
                {
                    OdemeHareket har = new OdemeHareket
                    {
                        Tutar = item.Tutar.Value,
                        OdemeNo = item.OdemeNo,
                        Aciklama = item.Aciklama,
                        OdemeTanim = StyOdemeTanimIslem.Instance.OdemeGetir(item.OdemeNo).Tanim,
                    };
                    sonuc.Add(har);
                }
            }
            catch (Exception ex)
            {
                HataLog.Instance.HataLogYaz(ex);
            }

            return sonuc;
        }
        #endregion
        public int Sira(string seri)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            int? sira = 1;
            try
            {
                sira = ent.StyFaturalar.Where(x => x.Seri == seri).Max(x => x.Sira);
                if (sira == null)
                {
                    sira = 0;
                }
                sira++;
            }
            catch
            {
                sira = 1;
            }
            return sira.Value;
        }
        public string SonSeri(byte tip)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            string seri = "";
            try
            {
                seri = ent.StyFaturalar.Where(x => x.BelgeTipi == tip).OrderByDescending(x => x.Tarih).Select(x => x.Seri).FirstOrDefault();
            }
            catch (Exception ex)
            {
                HataLog.Instance.HataLogYaz(ex);
            }
            return seri;
        }
    }
    public class FaturaSatir
    {
        public int Satir { get; set; }
        public string StokKodu { get; set; }
        public string StokAdi { get; set; }
        public ComboItem Vergi { get; set; }
        private double _vergiTutar;

        public double VergiTutar
        {
            get
            {
                return _vergiTutar;
            }
            set { _vergiTutar = value; }
        }
        private double _miktar;
        public double Miktar
        {
            get { return _miktar; }
            set { _miktar = value; }
        }
        public ComboItem Birim { get; set; }
        private double _fiyat;
        public double Fiyat
        {
            get { return _fiyat; }
            set { _fiyat = value; }
        }
        public double Tutar
        {
            get
            {
                return _miktar * _fiyat;
            }
        }
        public ComboItem Kasa { get; set; }
        private double _kasaMiktar;
        public double KasaMiktar
        {
            get { return _kasaMiktar; }
            set { _kasaMiktar = value; }
        }
        private double _kasaFiyat;
        public double KasaFiyat
        {
            get { return _kasaFiyat; }
            set { _kasaFiyat = value; }
        }
        public double KasaTutar
        {
            get { return _kasaMiktar * _kasaFiyat; }
        }
        public ComboItem IadeKasa { get; set; }
        private double _iadeKasaMiktar;
        public double IadeKasaMiktar
        {
            get { return _iadeKasaMiktar; }
            set { _iadeKasaMiktar = value; }
        }
        private double _iadeKasaFiyat;
        public double IadeKasaFiyat
        {
            get { return _iadeKasaFiyat; }
            set { _iadeKasaFiyat = value; }
        }
        public double IadeKasaTutar
        {
            get { return IadeKasaMiktar * _iadeKasaFiyat; }
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            FaturaSatir item = obj as FaturaSatir;
            if (item == null)
                return false;
            if (item.Satir == this.Satir)
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public class OdemeHareket
    {
        public string OdemeNo { get; set; }
        public string OdemeTanim { get; set; }
        public double Tutar { get; set; }
        public string Aciklama { get; set; }
    }
}
