using CrmPosHalYonetim.Entity;
using HalYonetim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrmPosHalYonetim.HksStokYonetim
{
    public class StyDepoIslem
    {
        private static StyDepoIslem _instance;
        public static StyDepoIslem Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new StyDepoIslem();
                return _instance;
            }
        }
        public bool DepoKaydet(StyDepo depo)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                var getDepo = ent.StyDepolar.Where(x => x.DepoNo == depo.DepoNo).FirstOrDefault();
                if (getDepo == null)
                {
                    ent.StyDepolar.AddObject(depo);
                    ent.SaveChanges();
                    return true;
                }
                else
                {
                    getDepo.DepoTanim = depo.DepoTanim;
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
        public bool DepoSil(StyDepo depo)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                var getDepo = ent.StyDepolar.Where(x => x.DepoNo == depo.DepoNo).FirstOrDefault();
                if (getDepo != null)
                {
                    ent.StyDepolar.DeleteObject(getDepo);
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
        public StyDepo DepoGetir(string depoNo)
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                var getDepo = ent.StyDepolar.Where(x => x.DepoNo == depoNo).FirstOrDefault();
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
        public List<StyDepo> TumDepoGetir()
        {
            HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
            try
            {
                var getDepo = ent.StyDepolar.ToList();
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
    }
}
