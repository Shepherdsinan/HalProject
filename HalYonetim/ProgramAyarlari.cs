using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HalYonetim
{
    public enum ProgramSettingsEnum : byte
    {
        Magaza = 0,
        EtiketYazicisi = 1,
    }

    public class ProgramAyarlari
    {
        private static ProgramAyarlari _instance;
        public static ProgramAyarlari Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProgramAyarlari();
                    _instance.tumKayitlar = new Dictionary<ProgramSettingsEnum, string>();
                }
                return _instance;
            }
        }
        Dictionary<ProgramSettingsEnum, string> tumKayitlar = null;
        private string _path;
        public string Path
        {
            get { return string.Format("{0}\\HksProgramSettings.ini", Application.StartupPath); ; }
        }
        public string GetValue(ProgramSettingsEnum info)
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
                        if (Enum.GetNames(typeof(ProgramSettingsEnum)).Where(x => x.Equals(readValue[0])).Count() > 0)
                        {
                            _instance.AddItems((ProgramSettingsEnum)Enum.Parse(typeof(ProgramSettingsEnum), readValue[0]), readValue[1]);
                        }
                    }
                }
            }

        }
        public void AddItems(ProgramSettingsEnum item, string value)
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
                    foreach (KeyValuePair<ProgramSettingsEnum, string> item in _instance.tumKayitlar)
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
