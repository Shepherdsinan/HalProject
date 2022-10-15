using CrmPosHalYonetim.Entity;
using HalYonetim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrmPosHalYonetim.HksStokYonetim
{
    public class StyDepoSevkIslem
    {
        private static StyDepoSevkIslem _instance;
        public static StyDepoSevkIslem Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new StyDepoSevkIslem();
                return _instance;
            }
        }
        public bool SevkKaydet(string seri, int sira, List<DepoSevkSatir> satirlar)
        {
            SevkSil(seri, sira);
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            ent.Connection.Open();
            using (System.Data.Common.DbTransaction trn = ent.Connection.BeginTransaction())
            {
                try
                {
                    foreach (var item in satirlar)
                    {
                        ent.StySevkHareketleri.AddObject(new StySevkHareket
                        {
                            Satir = item.Satir,
                            BirimFiyat = item.Fiyat,
                            CikisDepoNo = item.CikisDepoNo,
                            GirisDepoNo = item.GirisDepoNo,
                            KasaMiktar = item.KasaMiktar,
                            KasaNo = item.Kasa.Value.ToString(),
                            Seri = seri,
                            Sira = sira,
                            StokKodu = item.StokKodu,
                            Tarih = item.Tarih,
                            ToplamTutar = item.Tutar,
                            UrunMiktar = item.Miktar,
                            StokMiktarID = item.StokMiktarID
                        });

                    }
                    ent.SaveChanges();
                    trn.Commit();
                    StyStokGirisCikisIslem islem = new StyStokGirisCikisIslem();
                    foreach (var item in satirlar)
                    {
                        var stokMiktar = ent.StyStokMiktarlar.Where(x => x.ID == item.StokMiktarID).FirstOrDefault();
                        islem.EkleCikar(false, new StyStokMiktar
                        {
                            ID = item.StokMiktarID,
                            BirimMiktar = item.Miktar,
                            CariKod = stokMiktar.CariKod,
                            StokKodu = item.StokKodu,
                            KasaMiktar = item.IadeKasami ? 0 : item.KasaMiktar,
                            IadeKasaMiktar = item.IadeKasami ? item.KasaMiktar : 0,
                            BirmFiyat = item.Fiyat,
                            DepoNo = item.CikisDepoNo
                        });


                        if (!item.IadeKasami && item.Kasa != null && !string.IsNullOrWhiteSpace(item.Kasa.Text) && item.KasaMiktar > 0)
                        {
                            StyKasaIslem.Instance.KasaMiktarHareket(false, new StyKasaMiktar
                            {
                                DepoNo = item.CikisDepoNo,
                                Tarih = item.Tarih,
                                CariKod = stokMiktar.CariKod,
                                GirisCikis = 1,
                                Miktar = item.KasaMiktar,
                                KasaNo = item.Kasa.Value.ToString()
                            });
                        }

                        if (item.IadeKasami && !string.IsNullOrWhiteSpace(item.Kasa.Text) && item.KasaMiktar > 0)
                        {
                            StyKasaIslem.Instance.KasaMiktarHareket(false, new StyKasaMiktar
                            {
                                DepoNo = item.CikisDepoNo,
                                Tarih = item.Tarih,
                                CariKod = stokMiktar.CariKod,
                                GirisCikis = 0,
                                Miktar = item.KasaMiktar,
                                KasaNo = item.Kasa.Value.ToString()
                            });
                        }

                        if (!item.IadeKasami && item.Kasa != null && !string.IsNullOrWhiteSpace(item.Kasa.Text) && item.KasaMiktar > 0)
                        {
                            StyKasaIslem.Instance.KasaMiktarHareket(true, new StyKasaMiktar
                            {
                                DepoNo = item.GirisDepoNo,
                                Tarih = item.Tarih,
                                CariKod = stokMiktar.CariKod,
                                GirisCikis = 1,
                                Miktar = item.KasaMiktar,
                                KasaNo = item.Kasa.Value.ToString()
                            });
                        }

                        if (item.IadeKasami && !string.IsNullOrWhiteSpace(item.Kasa.Text) && item.KasaMiktar > 0)
                        {
                            StyKasaIslem.Instance.KasaMiktarHareket(true, new StyKasaMiktar
                            {
                                DepoNo = item.GirisDepoNo,
                                Tarih = item.Tarih,
                                CariKod = stokMiktar.CariKod,
                                GirisCikis = 0,
                                Miktar = item.KasaMiktar,
                                KasaNo = item.Kasa.Value.ToString()
                            });
                        }
                    }


                    return true;
                }
                catch (Exception ex)
                {
                    trn.Rollback();
                    HataLog.Instance.HataLogYaz(ex);
                    return false;
                }
            }
        }
        public bool SevkSil(string seri, int sira)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                if (ent.Connection.State == System.Data.ConnectionState.Closed)
                    ent.Connection.Open();
                using (System.Data.Common.DbTransaction trn = ent.Connection.BeginTransaction())
                {
                    var getRecord = ent.StySevkHareketleri.Where(x => x.Seri == seri && x.Sira == sira).ToList();
                    if (getRecord != null)
                    {
                        try
                        {
                            foreach (var item in getRecord)
                                ent.StySevkHareketleri.DeleteObject(item);
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
        public List<StySevkHareket> SevkGetir(string seri, int sira)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                return ent.StySevkHareketleri.Where(x => x.Seri == seri && x.Sira == sira).OrderBy(x => x.Satir).ToList();
            }
            catch (Exception ex)
            {
                HataLog.Instance.HataLogYaz(ex);
                return null;
            }
        }
        public int Sira(string seri)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            int? sira = 1;
            try
            {
                sira = ent.StySevkHareketleri.Where(x => x.Seri == seri).Max(x => x.Sira);
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
        public string SonSeri()
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            string seri = "";
            try
            {
                seri = ent.StySevkHareketleri.OrderByDescending(x => x.Tarih).Select(x => x.Seri).FirstOrDefault();
            }
            catch (Exception ex)
            {
                HataLog.Instance.HataLogYaz(ex);
            }
            return seri;
        }
    }
    public class DepoSevkSatir
    {
        public int StokMiktarID { get; set; }
        public int Satir { get; set; }
        public DateTime Tarih { get; set; }
        public string CikisDepoNo { get; set; }
        public string CikisDepoAdi { get; set; }
        public string GirisDepoNo { get; set; }
        public string GirisDepoAdi { get; set; }
        public string StokKodu { get; set; }
        public string StokAdi { get; set; }
        private double _miktar;
        public double Miktar
        {
            get { return _miktar; }
            set { _miktar = value; }
        }
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
        private ComboItem _kasa;



        public ComboItem Kasa
        {
            get { return _kasa; }
            set
            {
                _kasa = value;
                if (this.Kasa != null && !string.IsNullOrWhiteSpace(this.Kasa.Text))
                {
                    _iadeKasami = new StyKasaIslem().KasaGetir(this.Kasa.Value.ToString()).Iadelimi.Value;
                }
            }
        }
        private bool _iadeKasami;

        public bool IadeKasami
        {
            get
            {

                return _iadeKasami;
            }
        }
        private double _kasaMiktar;
        public double KasaMiktar
        {
            get { return _kasaMiktar; }
            set { _kasaMiktar = value; }
        }


        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            DepoSevkSatir item = obj as DepoSevkSatir;
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
}
