using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HalYonetim
{

    public enum DbSettingsEnum : byte
    {
        SunucuAdi = 0,
        Veritabani = 1,
        OturumAcmaSekli = 2,
        KullaniciAdi = 3,
        Sifre = 4
    }

    public class DbSettings
    {
        private static DbSettings _instance;
        public static DbSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DbSettings();
                    _instance.tumKayitlar = new Dictionary<DbSettingsEnum, string>();
                }
                return _instance;
            }
        }
        Dictionary<DbSettingsEnum, string> tumKayitlar = null;
        private string _path;
        public string Path
        {
            get { return string.Format("{0}\\HksDbSettings.ini", Application.StartupPath); ; }
        }

        public string GetValue(DbSettingsEnum info)
        {
            ItemControl();
            string result = string.Empty;
            if (_instance.tumKayitlar.ContainsKey(info))
                result = _instance.tumKayitlar[info];
            return result;
        }
        private void ItemControl()
        {
            if (tumKayitlar != null && tumKayitlar.Count <= 0)
            {
                Load();
            }
        }
        public void Load()
        {
            if (File.Exists(_instance.Path))
            {

                _instance.tumKayitlar.Clear();
                using (StreamReader reader = new StreamReader(_instance.Path))
                {
                    while (reader.Peek() != -1)
                    {
                        string[] readValue = reader.ReadLine().Split(';');
                        if (Enum.GetNames(typeof(DbSettingsEnum)).Where(x => x.Equals(readValue[0])).Count() > 0)
                        {
                            _instance.AddItems((DbSettingsEnum)Enum.Parse(typeof(DbSettingsEnum), readValue[0]), readValue[1]);
                        }
                    }
                }
            }
            
        }
        public void AddItems(DbSettingsEnum item, string value)
        {
            if (_instance.tumKayitlar.ContainsKey(item))
                _instance.tumKayitlar[item] = value;
            else
                _instance.tumKayitlar.Add(item, value);
        }

        public void Save()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_instance.Path))
                {
                    foreach (KeyValuePair<DbSettingsEnum, string> item in _instance.tumKayitlar)
                    {
                        writer.WriteLine(string.Format("{0};{1}", item.Key, item.Value));
                    }
                }

            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }
    }
}
