using System;
using System.Collections.Generic;
using System.Linq;
using CrmPosHalYonetim.HksUrunService;
using CrmPosHalYonetim.HksBildirimService;
using CrmPosHalYonetim.Entity;
using CrmPosHalYonetim.HksGenelService;
using CrmPosHalYonetim;

namespace HalYonetim
{
    public class ServisYonetimi
    {
        private static ServisYonetimi _instance;

        public static ServisYonetimi Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ServisYonetimi();
                return _instance;
            }
        }

        public static String UserName { get { return Settings.Instance.VgNo; } }
        public static String Password { get { return Settings.Instance.Sifre; } }
        public static String ServicePassword { get { return Settings.Instance.WbServiceSifre; } }
        public static class Genel
        {
            public static string GetErrorCode(string _code)
            {
                string returnMessage = "";
                switch (_code)
                {
                    case "GTBWSRV0000002":
                        returnMessage = "İşlem başarısız";
                        break;
                    case "GTBGLB00000001":
                        returnMessage = "Beklenmeyen hata oluştu";
                        break;
                    case "GTBGLB00000011":
                        returnMessage = "Kullanıcı bilgileri yanlış";
                        break;
                    case "GTBGLB00000012":
                        returnMessage = "Kullanıcı belli bir süre bloklandı.";
                        break;
                    case "GTBGLB00000013":
                        returnMessage = "Kullanıcı bilgilerinden en az biri boş.";
                        break;
                    case "GTBGLB00000014":
                        returnMessage = "Kullanıcı servis şifresi geçici olarak iptal edilmiştir.";
                        break;
                    case "GTBGLB00000015":
                        returnMessage = "Kullanıcı birimi istek gönderilen servis için yetkili değil.";
                        break;
                    default:
                        returnMessage = "Hal Hata kodu :" + _code + "\r\nLütfen Mehmet Dumanlı ile iletişime geçiniz.\r\nİletişim Bilgileri Tel:(0312)201-68-31 \r\nE-Mail Adresi :m.dumanli@gtb.gov.tr";
                        break;
                }
                return returnMessage;
            }

            public static List<HKSIL> GetIlListesi(bool guncelleme)
            {
                List<HKSIL> result = new List<HKSIL>();
                if (guncelleme)
                {
                    try
                    {
                        using (GenelServiceClient proxy = new GenelServiceClient())
                        {

                            IllerIstek istek = new IllerIstek();
                            string islemKodu = "";
                            IllerCevap cevap = new IllerCevap();
                            List<CrmPosHalYonetim.HksGenelService.ErrorModel> error = proxy.GenelServisIller(istek, Password, ServicePassword, UserName, out islemKodu, out cevap);
                            result.AddRange(cevap.Iller.Select(x => new HKSIL { Adi = x.IlAdi, ID = x.Id }).ToArray());
                        }
                    }
                    catch (Exception ex)
                    {
                        HataLog.Instance.HataLogYaz(ex);
                    }
                }
                else
                {
                    try
                    {
                        using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
                        {
                            foreach (var item in ent.HKSIller)
                                result.Add(new HKSIL { Adi = item.Adi, ID = item.ID });
                            if (result.Count == 0)
                                GetIlListesi(true);
                        }
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Veritabanı Bağlantısı Kurulamadı.\r\n" + ex.Message);
                    }
                }
                return result;
            }

            public static List<HKSIlce> GetIlceListesi(int ilId, bool guncelleme)
            {
                List<HKSIlce> result = new List<HKSIlce>();
                if (guncelleme)
                {
                    try
                    {
                        using (GenelServiceClient proxy = new GenelServiceClient())
                        {
                            IlcelerIstek istek = new IlcelerIstek() { IlId = ilId };
                            IlcelerCevap cevap = new IlcelerCevap();
                            string islemKodu = "";
                            List<CrmPosHalYonetim.HksGenelService.ErrorModel> error = proxy.GenelServisIlceler(istek, Password, ServicePassword, UserName, out islemKodu, out cevap);
                            result.AddRange(cevap.Ilceler.Select(x => new HKSIlce { Adi = x.IlceAdi, ID = x.Id }).ToArray());
                        }
                    }
                    catch (Exception ex)
                    {
                        HataLog.Instance.HataLogYaz(ex);
                    }
                }
                else
                {
                    try
                    {
                        using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
                        {
                            foreach (var item in ent.HKSIlceler)
                                result.Add(new HKSIlce { Adi = item.Adi, ID = item.ID });
                            if (result.Count == 0)
                                GetIlceListesi(ilId, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Veritabanı Bağlantısı Kurulamadı.\r\n" + ex.Message);
                    }
                }
                return result;
            }

            public static List<HKSBelde> GetBeldeListesi(int ilceId)
            {
                List<HKSBelde> result = new List<HKSBelde>();
                try
                {
                    using (GenelServiceClient proxy = new GenelServiceClient())
                    {
                        BeldelerIstek istek = new BeldelerIstek() { IlceId = ilceId };
                        string islemkodu = "";
                        BeldelerCevap cevap = new BeldelerCevap();
                        List<CrmPosHalYonetim.HksGenelService.ErrorModel> error = proxy.GenelServisBeldeler(istek, Password, ServicePassword, UserName, out islemkodu, out cevap);
                        result.AddRange(cevap.Beldeler.Select(x => new HKSBelde { Adi = x.BeldeAdi, ID = x.Id }).ToArray());
                    }
                }
                catch (Exception ex)
                {
                    HataLog.Instance.HataLogYaz(ex);
                }
                return result;
            }

            public static List<HKSSube> GetSubeListesi(bool guncelleme)
            {
                List<HKSSube> result = new List<HKSSube>();
                if (guncelleme)
                {
                    try
                    {
                        using (GenelServiceClient proxy = new GenelServiceClient())
                        {
                            SubelerIstek istek = new SubelerIstek() { TcKimlikVergiNo = UserName };
                            SubelerCevap cevap = new SubelerCevap();
                            string islemkodu = "";
                            List<CrmPosHalYonetim.HksGenelService.ErrorModel> error = proxy.GenelServisSubeler(istek, Password, ServicePassword, UserName, out islemkodu, out cevap);
                            result.AddRange(cevap.Subeler.Select(x => new HKSSube { Adres = x.Adres, IlceID = x.IlceId, IlID = x.IlId, SubeAdi = x.SubeAdi, IsYeriTuru = x.IsyeriTuru, BeldeID = x.BeldeId, ID = x.Id }).ToArray());
                        }
                    }
                    catch (Exception ex)
                    {
                        HataLog.Instance.HataLogYaz(ex);
                    }
                }
                else
                {
                    try
                    {
                        using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
                        {
                            foreach (var item in ent.HKSSubeler)
                                result.Add(new HKSSube { Adres = item.Adres, ID = item.ID, SubeAdi = string.IsNullOrWhiteSpace(item.SubeAdi) ? item.Adres : item.SubeAdi, IsYeriTuru = item.IsYeriTuru ?? 0, IlID = item.IlID ?? 0, IlceID = item.IlceID ?? 0 });
                            if (result.Count == 0)
                                GetSubeListesi(true);
                        }
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Veritabanı Bağlantısı Kurulamadı.\r\n" + ex.Message);
                    }
                }
                return result;
            }

            public static List<HKSCins> GetUrunCinsListesi(bool guncelleme)
            {
                List<HKSCins> result = new List<HKSCins>();
                if (guncelleme)
                {
                    try
                    {
                        using (UrunServiceClient proxy = new UrunServiceClient())
                        {
                            UrunCinsleriIstek istek = new UrunCinsleriIstek() { UrunId = 0 };
                            UrunCinsleriCevap cevap = new UrunCinsleriCevap();
                            string islemkodu = "";
                            List<CrmPosHalYonetim.HksUrunService.ErrorModel> error = proxy.UrunServiceUrunCinsleri(istek, Password, ServicePassword, UserName, out islemkodu, out cevap);
                            result.AddRange(cevap.UrunCinsleri.Select(x => new HKSCins { CinsAdi = x.UrunCinsiAdi, ID = x.Id, Ithalmi = x.Ithalmi, UretimSekliID = x.UretimSekliId, UrunAdi = x.UrunCinsiAdi, UrunID = x.UrunId, UrunKodu = x.UrunKodu }).ToArray());
                        }
                    }
                    catch (Exception ex)
                    {
                        HataLog.Instance.HataLogYaz(ex);
                    }
                }
                else
                {
                    try
                    {
                        using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
                        {
                            foreach (var item in ent.HKSCinsler)
                                result.Add(new HKSCins { ID = item.ID, UretimSekliID = item.UretimSekliID.HasValue ? item.UretimSekliID.Value : 0, CinsAdi = item.CinsAdi, UrunKodu = item.UrunAdi, Ithalmi = item.Ithalmi.Value, UrunID = item.UrunID.Value });
                            if (result.Count == 0)
                                GetUrunCinsListesi(true);
                        }
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Veritabanı Bağlantısı Kurulamadı.\r\n" + ex.Message);
                    }
                }
                return result;
            }

            public static List<HKSUretimSekli> GetUrunUretimListesi(bool guncelleme)
            {
                List<HKSUretimSekli> result = new List<HKSUretimSekli>();
                if (guncelleme)
                {
                    try
                    {
                        using (UrunServiceClient proxy = new UrunServiceClient())
                        {
                            UretimSekilleriIstek istek = new UretimSekilleriIstek();
                            UretimSekilleriCevap cevap = new UretimSekilleriCevap();
                            string IslemKodu = "";
                            List<CrmPosHalYonetim.HksUrunService.ErrorModel> error = proxy.UrunServiceUretimSekilleri(istek, Password, ServicePassword, UserName, out IslemKodu, out cevap);
                            result.AddRange(cevap.UretimSekilleri.Select(x => new HKSUretimSekli { ID = x.Id, UretimSekliAdi = x.UretimSekliAdi }).ToArray());
                        }
                    }
                    catch (Exception ex)
                    {
                        HataLog.Instance.HataLogYaz(ex);
                    }
                }
                else
                {
                    try
                    {
                        using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
                        {
                            foreach (var item in ent.HKSUretimSekilleri)
                                result.Add(new HKSUretimSekli { UretimSekliAdi = item.UretimSekliAdi, ID = item.ID });
                            if (result.Count == 0)
                                GetUrunUretimListesi(true);
                        }
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Veritabanı Bağlantısı Kurulamadı.\r\n" + ex.Message);
                    }
                }
                return result;
            }

            public static List<HKSBildirim> GetBildirimTuruListesi(bool guncelleme)
            {
                List<HKSBildirim> result = new List<HKSBildirim>();
                string islemKodu = "";
                if (guncelleme)
                {
                    try
                    {
                        using (BildirimServiceClient proxy = new BildirimServiceClient())
                        {
                            BildirimTurleriIstek istek = new BildirimTurleriIstek();
                            BildirimTurleriCevap cevap;
                            var getResult = proxy.BildirimServisBildirimTurleri(istek, Settings.Instance.Sifre, Settings.Instance.WbServiceSifre, Settings.Instance.VgNo, out islemKodu, out cevap);
                            result = cevap.BildirimTurleri.Select(x => new HKSBildirim { Adi = x.BildirimTuruAdi, ID = x.Id }).ToList();
                        }
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("HKS Servisine Bağlanılamadı.\r\n" + ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
                        {
                            foreach (var item in ent.HKSBildirimler)
                                result.Add(new HKSBildirim { ID = item.ID, Adi = item.Adi });
                            if (result.Count == 0)
                                GetBildirimTuruListesi(true);
                        }
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Veritabanı Bağlantısı Kurulamadı.\r\n" + ex.Message);
                    }
                }
                return result;
            }

            public static List<HKSStok> GetUrunListesi(bool guncelleme)
            {
                List<HKSStok> result = new List<HKSStok>();
                if (guncelleme)
                {
                    try
                    {
                        using (UrunServiceClient proxy = new UrunServiceClient())
                        {
                            UrunlerIstek istek = new UrunlerIstek();
                            UrunlerCevap cevap = new UrunlerCevap();
                            string IslemKodu = "";
                            List<CrmPosHalYonetim.HksUrunService.ErrorModel> error = proxy.UrunServiceUrunler(istek, Password, ServicePassword, UserName, out IslemKodu, out cevap);
                            result.AddRange(cevap.Urunler.Select(x => new HKSStok { Adi = x.UrunAdi, ID = x.Id }).ToArray());
                        }
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("HKS Servisine Bağlanılamadı.\r\n" + ex.Message);
                        HataLog.Instance.HataLogYaz(ex);
                    }
                }
                else
                {
                    try
                    {
                        using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
                        {
                            foreach (var item in ent.HKSStoklar)
                                result.Add(new HKSStok { ID = item.ID, Adi = item.Adi });
                            if (result.Count == 0)
                                GetUrunListesi(true);
                        }
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Veritabanı Bağlantısı Kurulamadı.\r\n" + ex.Message);
                    }
                }
                return result;
            }

            public static List<HKSBirim> GetUrunBirimListesi(bool guncelleme)
            {
                List<HKSBirim> result = new List<HKSBirim>();
                if (guncelleme)
                {
                    try
                    {
                        using (UrunServiceClient proxy = new UrunServiceClient())
                        {
                            UrunBirimleriIstek istek = new UrunBirimleriIstek();
                            UrunBirimleriCevap cevap = new UrunBirimleriCevap();
                            string IslemKodu = "";
                            List<CrmPosHalYonetim.HksUrunService.ErrorModel> error = proxy.UrunServiceUrunBirimleri(istek, Password, ServicePassword, UserName, out IslemKodu, out cevap);
                            result.AddRange(cevap.UrunBirimleri.Select(x => new HKSBirim { Adi = x.UrunBirimAdi, ID = x.Id }).ToArray());
                        }
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("HKS Servisine Bağlanılamadı.\r\n" + ex.Message);
                        HataLog.Instance.HataLogYaz(ex);
                    }
                }
                else
                {
                    try
                    {
                        using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
                        {
                            result.AddRange(ent.HKSBirimler.ToArray());
                            if (result.Count == 0)
                                GetUrunBirimListesi(true);
                        }
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Veritabanı Bağlantısı Kurulamadı.\r\n" + ex.Message);
                    }
                }
                return result;
            }

            public static List<HKSIsletme> GetIsletmeTuruListesi(bool guncelleme)
            {
                List<HKSIsletme> result = new List<HKSIsletme>();
                if (guncelleme)
                {
                    try
                    {
                        using (GenelServiceClient proxy = new GenelServiceClient())
                        {

                            IsletmeTurleriIstek istek = new IsletmeTurleriIstek();
                            IsletmeTurleriCevap cevap = new IsletmeTurleriCevap();
                            string islemKodu = "";
                            proxy.GenelServisIsletmeTurleri(istek, Password, ServicePassword, UserName, out islemKodu, out cevap);
                            result.AddRange(cevap.IsletmeTurleri.Select(x => new HKSIsletme { ID = x.Id, Adi = x.IsletmeTuruAdi }));
                        }
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("HKS Servisine Bağlanılamadı.\r\n" + ex.Message);
                        HataLog.Instance.HataLogYaz(ex);
                    }
                }
                else
                {
                    try
                    {
                        using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
                        {
                            result.AddRange(ent.HKSIsletmeler.ToArray());
                            if (result.Count == 0)
                                GetIsletmeTuruListesi(true);
                        }
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Veritabanı Bağlantısı Kurulamadı.\r\n" + ex.Message);
                    }
                }
                return result;
            }

            public static List<HKSBelge> GetBelgeListesi(bool guncelleme)
            {
                List<HKSBelge> result = new List<HKSBelge>();
                string islemKodu = "";
                if (guncelleme)
                {
                    try
                    {
                        using (BildirimServiceClient proxy = new BildirimServiceClient())
                        {
                            BelgeTipleriIstek istek = new BelgeTipleriIstek();
                            BelgeTipleriCevap cevap;
                            var getResult = proxy.BildirimServisBelgeTipleriListesi(istek, Settings.Instance.Sifre, Settings.Instance.WbServiceSifre, Settings.Instance.VgNo, out islemKodu, out cevap);
                            result.AddRange(cevap.BelgeTipleri.Select(x => new HKSBelge { Belge = x.BelgeTipiAdi, ID = x.Id }).ToArray());
                        }
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("HKS Servisine Bağlanılamadı.\r\n" + ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
                        {
                            result.AddRange(ent.HKSBelgeler.ToArray());
                            if (result.Count == 0)
                                GetBelgeListesi(true);
                        }
                    }
                    catch (Exception ex)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Veritabanı Bağlantısı Kurulamadı.\r\n" + ex.Message);
                    }
                }
                return result;
            }

            public static IkinciKisiBilgileriDTO GetIkinciKisiBilgileri()
            {
                IkinciKisiBilgileriDTO result = new IkinciKisiBilgileriDTO();
                result.YurtDisiMi = false;
                result.TcKimlikVergiNo = Settings.Instance.VgNo;
                result.Eposta = Settings.Instance.Eposta;
                result.AdSoyad = Settings.Instance.AdSoyad;
                result.CepTel = Settings.Instance.CepTel;
                //SifatDTO item = ((List<SifatDTO>)bsIkinciKisiSifat.DataSource)[cmbIkinciKisiSifati.SelectedIndex];
                result.KisiSifat = Settings.Instance.Sifat2ID; //Settings.Instance.SifatID; //item.Id; Market ID

                return result;
            }

            public static BildirimciBilgileriDTO GetBildirimciBilgileri()
            {
                BildirimciBilgileriDTO result = new BildirimciBilgileriDTO();
                result.KisiSifat = Settings.Instance.SifatID;
                return result;
            }

            public static BildirimMalBilgileriDTO GetMalBilgileri(BildirimItem srg, SevkMagaza mgz)
            {
                BildirimMalBilgileriDTO result = new BildirimMalBilgileriDTO();

                result.GelenUlkeId = 201;
                result.MalinCinsiId = mgz.MalinCinsKodNo;
                result.MalinKodNo = srg.MalinKodNo;
                //result.MalinSatisFiyat = srg.MalinSatisFiyati;
                result.MiktarBirimId = srg.MiktarBirimId;
                result.MalinMiktari = Convert.ToDouble(mgz.SevkMiktar);
                result.AnalizeGonderilecekMi = srg.AnalizStatus;
                return result;
            }

            public static List<BildirimSorguDTO> GetBildirim(long kunye, DateTime bsTarih, DateTime btTarih, int kunyeTuru, BildirimServiceClient proxy)
            {
                if (proxy == null)
                {
                    proxy = new BildirimServiceClient();
                }
                List<BildirimSorguDTO> result = new List<BildirimSorguDTO>();
                BildirimSorguCevap cevap = null;
                BildirimSorguIstek criteria = null;
                string islemKodu = "";
                if (kunye != 0)
                    criteria = new BildirimSorguIstek { KunyeNo = kunye };
                else
                    criteria = new BildirimSorguIstek()
                    {
                        KunyeTuru = kunyeTuru,//cmbKunyeTuru.SelectedIndex + 1,
                        KunyeNo = kunye,
                        BaslangicTarihi = bsTarih,
                        BitisTarihi = btTarih,
                        KalanMiktariSifirdanBuyukOlanlar = false
                    };

                BildirimSorguIstek istek = criteria;

                try
                {
                    var getResult = proxy.BildirimServisBildirimciyeYapilanBildirimListesi(istek, Settings.Instance.Sifre, Settings.Instance.WbServiceSifre, Settings.Instance.VgNo, out islemKodu, out cevap);
                }
                catch (Exception ex)
                {
                    HataLog.Instance.HataLogYaz(ex);
                    //DevExpress.XtraEditors.XtraMessageBox.Show(string.Format("Servisten Cevap Alınamıyor.Hata Mesajı\r\n{0}", ex.Message));
                }
                finally
                {

                }

                if (cevap != null)
                {
                    if ((cevap.HataKodu > 0))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(string.Format("Hata Kodu : {0}, Hata Mesajı : {1}", cevap.HataKodu, cevap.Mesaj));
                    }
                    else
                    {
                        result = cevap.Bildirimler;
                    }
                }
                else
                {
                    if (cevap.HataKodu != 0)
                        DevExpress.XtraEditors.XtraMessageBox.Show(string.Format("Hata Kodu : {0}, Hata Mesajı : {1}", cevap.HataKodu, cevap.Mesaj));
                    else
                        DevExpress.XtraEditors.XtraMessageBox.Show(islemKodu);
                }

                return result;
            }

            public static MalinGidecekYerBilgileriDTO GetMalinGidecekYerBilgileri(HKSSube mgz, string aracPlaka, int isletmeTuru, string belgeNo, int belgeTipi)
            {
                MalinGidecekYerBilgileriDTO result = new MalinGidecekYerBilgileriDTO();
                result.AracPlakaNo = aracPlaka;
                result.GidecekIsyeriId = mgz.ID;
                result.GidecekUlkeId = 201;
                result.GidecekYerBeldeId = 0;
                result.GidecekYerIlceId = mgz.IlceID.Value;
                result.GidecekYerIlId = mgz.IlID.Value;
                result.GidecekYerIsletmeTuruId = isletmeTuru;
                result.BelgeNo = belgeNo;
                result.BelgeTipi = belgeTipi;
                return result;
            }

            public static ReferansKunyeCevap KunyeSorgula(DateTime bsTarihi, DateTime btTarih, UrunDTO urun)
            {
                ReferansKunyeCevap cevap = null;
                string islemKodu = "";
                try
                {
                    using (BildirimServiceClient proxy = new BildirimServiceClient())
                    {
                        ReferansKunyeIstek istek = new ReferansKunyeIstek()
                        {
                            MalinSahibiTcKimlikVergiNo = Settings.Instance.VgNo,
                            KunyeNo = 0,
                            KalanMiktariSifirdanBuyukOlanlar = true,
                            BaslangicTarihi = bsTarihi,
                            BitisTarihi = btTarih,
                            KisiSifat = Settings.Instance.SifatID,
                            UrunId = urun.Id,
                        };
                        var getResult = proxy.BildirimServisReferansKunyeler(istek, Settings.Instance.Sifre, Settings.Instance.WbServiceSifre, Settings.Instance.VgNo, out islemKodu, out cevap);
                    }
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("HKS Servisine Bağlanılamadı.\r\n" + ex.Message);

                }
                return cevap;
            }

            public static BildirimSorguCevap TumKunyeSorgula(DateTime bsTarihi, DateTime btTarih, byte kunyeTuru, long kunye = 0)
            {
                BildirimSorguCevap cevap = null;
                string islemKodu = "";
                try
                {
                    using (BildirimServiceClient proxy = new BildirimServiceClient())
                    {
                        BildirimSorguIstek istek = new BildirimSorguIstek()
                        {
                            BaslangicTarihi = bsTarihi,
                            BitisTarihi = btTarih,
                            KunyeNo = kunye,
                            KunyeTuru = kunyeTuru,
                            KalanMiktariSifirdanBuyukOlanlar = true,
                            UniqueId = "",
                            Sifat = Settings.Instance.SifatID

                        };
                        List<CrmPosHalYonetim.HksBildirimService.ErrorModel> getResult = proxy.BildirimServisBildirimciyeYapilanBildirimListesi(istek, Settings.Instance.Sifre, Settings.Instance.WbServiceSifre, Settings.Instance.VgNo, out islemKodu, out cevap);
                    }
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("HKS Servisine Bağlanılamadı.\r\n" + ex.Message);

                }
                return cevap;
            }

            public static BildirimEtiketCevap EtiketListesi(string aracPlaka, string belgeNo, DateTime tarih)
            {
                BildirimEtiketCevap cevap = null;
                string islemKodu = "";
                try
                {
                    using (BildirimServiceClient proxy = new BildirimServiceClient())
                    {
                        BildirimEtiketIstek istek = new BildirimEtiketIstek()
                        {
                            AracPlakaNo = aracPlaka,
                            BelgeNo = belgeNo,
                            BildirimTarihi = tarih,
                            MalinSahibiTcKimlikNo = UserName,
                        };
                        List<CrmPosHalYonetim.HksBildirimService.ErrorModel> getResult = proxy.BildirimServisBildirimEtiket(istek, Settings.Instance.Sifre, Settings.Instance.WbServiceSifre, Settings.Instance.VgNo, out islemKodu, out cevap);
                    }
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("HKS Servisine Bağlanılamadı.\r\n" + ex.Message);

                }
                return cevap;
            }
        }
    }
}
