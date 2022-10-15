using CrmPosHalYonetim.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HalYonetim
{
    public class Settings
    {
        private static Settings _instance;
        public static Settings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Settings();
                    _instance.LoadData();
                }
                return _instance;
            }
        }

        public void LoadData()
        {
            using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
            {
                var getItem = ent.FirmaBilgileri.FirstOrDefault();
                if (getItem != null)
                {
                    _instance.VgNo = getItem.TcVgNo;
                    _instance.WbServiceSifre = getItem.ServisSifresi.DecryptString();
                    _instance.Sifre = getItem.Sifre.DecryptString();
                    _instance.AdSoyad = getItem.Unvani;
                    _instance.CepTel = getItem.Gsm;
                    _instance.Eposta = getItem.EPosta;
                    _instance.SifatID = getItem.Sifat1.Value;
                    _instance.Sifat2ID = getItem.Sifat2.HasValue ? getItem.Sifat2.Value : getItem.Sifat1.Value;
                }
            }
        }

        public string VgNo { get; set; }
        public string Sifre { get; set; }
        public string WbServiceSifre { get; set; }
        public string Eposta { get; set; }
        public string AdSoyad { get; set; }
        public string CepTel { get; set; }
        public int SifatID { get; set; }
        public int Sifat2ID { get; set; }
    }
}
