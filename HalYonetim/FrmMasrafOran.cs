using CrmPosHalYonetim.Entity;
using DevExpress.XtraEditors;
using HalYonetim;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CrmPosHalYonetim
{
    public partial class FrmMasrafOran : XtraForm
    {
        public FrmMasrafOran()
        {
            InitializeComponent();
        }

        private void FrmMasrafOran_Load(object sender, EventArgs e)
        {
            using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
            {
                gridControl1.DataSource = ent.HKSStoklar.ToList();
                gridView1.Columns["ID"].Visible = false;
                gridView1.BestFitColumns();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
            {
                try
                {
                    foreach (var item in (gridControl1.DataSource as List<HKSStok>).Where(x => x.MasrafOrani > 0).ToList())
                    {
                        var stok = ent.HKSStoklar.Where(x => x.ID == item.ID).FirstOrDefault();
                        if (stok != null)
                        {
                            stok.MasrafOrani = item.MasrafOrani;
                            stok.IslemePaketlemeOran = item.IslemePaketlemeOran;
                            stok.MagazacilikOran = item.MagazacilikOran;
                            stok.NakliyeDepolamaOran = item.NakliyeDepolamaOran;
                            stok.VergiOran = item.VergiOran;
                            ent.SaveChanges();
                        }
                    }
                    MessageBox.Show("Kaydetme İşlemi Başarılı");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir Hata Oluştu");
                    HataLog.Instance.HataLogYaz(ex);
                }
            }
        }
    }
}
