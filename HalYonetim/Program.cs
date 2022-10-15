using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HalYonetim
{

    static class Program
    {
        public static DevExpress.LookAndFeel.DefaultLookAndFeel look = new DevExpress.LookAndFeel.DefaultLookAndFeel();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            look.LookAndFeel.SkinName = "Office 2010 Black";
            //DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.UserSkins.BonusSkins.Register();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!System.IO.File.Exists(DbSettings.Instance.Path))
            {
                using (FrmUserControl frm = new FrmUserControl())
                {
                    frm.ShowDialog();
                }
            }
            DbSettings.Instance.Load();
            ProgramAyarlari.Instance.Load();
            using (CrmPosHalYonetim.Entity.HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
            {
                try
                {
                    if (!ent.DatabaseExists())
                    {
                        ent.CreateDatabase();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                
            }
            Application.Run(new FrmMain());
        }
    }
}
