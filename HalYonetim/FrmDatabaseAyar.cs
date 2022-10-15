using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HalYonetim
{
    public partial class FrmDatabaseAyar : UserControl
    {
        public FrmDatabaseAyar()
        {
            InitializeComponent();
        }

        private void FrmDatabaseAyar_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < vGridControl1.Rows.Count; i++)
                if (!string.IsNullOrEmpty(vGridControl1.Rows[i].Properties.FieldName))
                    vGridControl1.Rows[i].Properties.Value = (DbSettings.Instance.GetValue((DbSettingsEnum)Enum.Parse(typeof(DbSettingsEnum), vGridControl1.Rows[i].Properties.FieldName)));
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 1; i < vGridControl1.Rows.Count; i++)
                    if (vGridControl1.Rows[i].Properties.Value != null)
                        DbSettings.Instance.AddItems((DbSettingsEnum)Enum.Parse(typeof(DbSettingsEnum), vGridControl1.Rows[i].Properties.FieldName), vGridControl1.Rows[i].Properties.Value.ToString());
                DbSettings.Instance.Save();
                DevExpress.XtraEditors.XtraMessageBox.Show("Kaydetme İşlemi Tamamlandı");
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Bir Hata Oluştu\r\n" + ex.Message);
            }
        }

    }
}
