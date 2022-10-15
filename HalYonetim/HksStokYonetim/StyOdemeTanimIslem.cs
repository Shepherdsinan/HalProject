using CrmPosHalYonetim.Entity;
using HalYonetim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrmPosHalYonetim.HksStokYonetim
{

    public class StyOdemeTanimIslem
    {
        private static StyOdemeTanimIslem _instance;
        public static StyOdemeTanimIslem Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new StyOdemeTanimIslem();
                return _instance;
            }
        }
        public bool OdemeKaydet(StyOdemeTanim odeme)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                var getKasa = ent.StyOdemeTanimlari.Where(x => x.No == odeme.No).FirstOrDefault();
                if (getKasa == null)
                {
                    ent.StyOdemeTanimlari.AddObject(odeme);
                    ent.SaveChanges();
                    return true;
                }
                else
                {
                    getKasa.Tanim = odeme.Tanim;
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
        public bool OdemeSil(StyOdemeTanim kasa)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                var getKasa = ent.StyOdemeTanimlari.Where(x => x.No == kasa.No).FirstOrDefault();
                if (getKasa != null)
                {
                    ent.StyOdemeTanimlari.DeleteObject(getKasa);
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
        public StyOdemeTanim OdemeGetir(string odemeNo)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                var getOdeme = ent.StyOdemeTanimlari.Where(x => x.No == odemeNo).FirstOrDefault();
                if (getOdeme != null)
                {
                    return getOdeme;
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

        public List<StyOdemeTanim> Odemeler()
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                var getOdeme = ent.StyOdemeTanimlari.ToList();
                if (getOdeme != null)
                {
                    return getOdeme;
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
    }
}
