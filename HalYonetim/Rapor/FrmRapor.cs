using CrmPosHalYonetim.Rapor;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CrmPosHalYonetim
{
    public partial class FrmRapor : XtraForm
    {
        public FrmRapor()
        {
            InitializeComponent();
            this.Load += FrmRapor_Load;
        }

        void FrmRapor_Load(object sender, EventArgs e)
        {
            foreach (var item in RaporYonetimi.Get.GetFileNameList())
            {
                ListViewItem lwitem = new ListViewItem { Text = item, Tag = string.Format("{0}\\{1}.sql", RaporYonetimi.RaporKlasoru, item), ImageIndex = 0 };
                listView1.Items.Add(lwitem);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                object value = listView1.SelectedItems[0].Tag;
                if (value != null)
                {
                    FrmRaporFiltre frm = new FrmRaporFiltre(value.ToString());
                    frm.ShowDialog();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    public class RaporYonetimi
    {
        static RaporYonetimi _instance;

        public static RaporYonetimi Get
        {
            get
            {
                if (_instance == null)
                    _instance = new RaporYonetimi();
                return _instance;
            }
        }
        public static string RaporKlasoru = Path.Combine(Application.StartupPath, "Reporlar");
        public string[] GetFileNameList()
        {
            if (!Directory.Exists(RaporKlasoru))
                Directory.CreateDirectory(RaporKlasoru);
            DirectoryInfo folder = new DirectoryInfo(RaporKlasoru);
            return folder.GetFiles("*.sql").Select(x => x.Name.Split('.')[0]).ToArray<string>();

        }
    }
}
