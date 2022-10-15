using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrmPosHalYonetim
{
    public class BildirimItem
    {
        //       int
        #region Gridde Gizlenecek
        public bool AnalizStatus { get; set; }
        public int BelgeTipi { get; set; }
        public int BildirimTuru { get; set; }
        public int GidecekIsyeriId { get; set; }
        public int GidecekYerTuruId { get; set; }
        public int MalinKodNo { get; set; }
        public int MalinTuruKodNo { get; set; }
        public int MiktarBirimId { get; set; }
        public int Sifat { get; set; }
        #endregion
        public string MalinAdi { get; set; }
        public string MalinCinsi { get; set; }
        public string MalinTuru { get; set; }
        public long KunyeNo { get; set; }
        public DateTime İlkBildirimtarihi { get; set; }
        public double SevkMiktar
        {
            get
            {
                if (SevkKunyeler != null)
                    return SevkKunyeler.Sum(x => x.SevkMiktar);
                return 0;
            }
        }
        public double MalinSatisFiyati { get; set; }
        public double KalanMiktar { get; set; }
        public double MalinMiktari { get; set; }
        public double RusumMiktari { get; set; }
        public string AracPlakaNo { get; set; }
        public string BelgeNo { get; set; }
        public string BildirimciTcKimlikVergiNo { get; set; }
        public string MalinSahibiTcKimlikVergiNo { get; set; }
        public string MiktarBirimiAd { get; set; }
        public string UreticiTcKimlikVergiNo { get; set; }

        public List<SevkMagaza> SevkKunyeler { get; set; }
    }
    public class SevkMagaza
    {
        public int Id { get; set; }
        public int IsYeriTurId { get; set; }
        public string IsYeriTuru { get; set; }
        public string GuidNo { get; set; }
        public string Magaza { get; set; }
        public string AracPlaka { get; set; }
        public string BelgeNo { get; set; }
        public double SevkMiktar { get; set; }
        public double SatisFiyat { get; set; }
        public long KunyeNo { get; set; }
        public DateTime İlkBildirimtarihi { get; set; }
        public long NihaiKunye { get; set; }
        public string UreticisininAdUnvani { get; set; }
        public int MalinCinsKodNo { get; set; }
        public string MalinSahibAdi { get; set; }
        public int UretimIlId { get; set; }
        public int UretimIlceId { get; set; }
        public int UretimBeldeId { get; set; }
        public int UretimSekli { get; set; }
        public int HksHataKodu { get; set; }
        public string HksHataAciklama { get; set; }
        public DateTime SevkTarihi { get; set; }
        public DateTime KayitTarihi { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            SevkMagaza mgz = obj as SevkMagaza;
            if (mgz == null)
            {
                return false;
            }
            if (mgz.Id == this.Id)
            {
                return true;
            }
            else
                return false;
        }
    }
    public class MagazaBelgeAracPlaka
    {
        public int ID { get; set; }
        public string AracPlaka { get; set; }
        public string BelgeNo { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            MagazaBelgeAracPlaka mgz = obj as MagazaBelgeAracPlaka;
            if (mgz == null)
            {
                return false;
            }
            if (mgz.ID == this.ID)
            {
                return true;
            }
            else
                return false;
        }
    }
    public class BildirimEtiketItem
    {
        public string AracPlaka { get; set; }
        public string BelgeNo { get; set; }
        public string BelgeTipi { get; set; }
        public string BildirimciTcKimlikVergiNo { get; set; }
        public DateTime SevkBildirimTarihi { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string BildirimTuru { get; set; }
        public string Sube { get; set; }
        public string Kunye { get; set; }
        public string NihaiKunyeNo { get; set; }
        public string MalinAdi { get; set; }
        public string MalinCinsi { get; set; }
        public double MalinMiktari { get; set; }
        public string MalinSahibiTcKimlikVergiNo { get; set; }
        public string MalinSahibAdi { get; set; }
        public double MalinSatisFiyati { get; set; }
        public double MalinSatisFiyatiMasrafDahil { get; set; }
        public string MalinTuru { get; set; }
        public string MiktarBirimiAd { get; set; }
        public string UreticiTcKimlikVergiNo { get; set; }
        public string UreticisininAdUnvani { get; set; }
        public string UretimIli { get; set; }
        public string UretimIlce { get; set; }
        public string UretimBelde { get; set; }
        public string UretimSekli { get; set; }
        public double MasrafOran { get; set; }
        public double IslemePaketlemeOran { get; set; }
        public double MagazacilikOran { get; set; }
        public double NakliyeDepolamaOran { get; set; }
        public double VergiOran { get; set; }

        public double IslemePaketlemeTutar { get; set; }
        public double MagazacilikTutar { get; set; }
        public double NakliyeDepolamaTutar { get; set; }
        public double VergiTutar { get; set; }
        public string HksHataAciklama { get; set; }

        public DateTime ilkbildirimtarihi { get; set; }
    }
}
