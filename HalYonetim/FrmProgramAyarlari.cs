using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace HalYonetim
{
    public partial class FrmProgramAyarlari : UserControl
    {
        public FrmProgramAyarlari()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmProgramAyarlari_Load);
        }

        void FrmProgramAyarlari_Load(object sender, EventArgs e)
        {
            cmbMagazalar.Items.AddRange(ServisYonetimi.Genel.GetSubeListesi(false).Select(x => x.SubeAdi).ToArray());
            foreach (String printer in PrinterSettings.InstalledPrinters)
                cmbYaziciListesi.Items.Add(printer);
            try
            {
                for (int i = 1; i < vGridControl1.Rows.Count; i++)
                    if (!string.IsNullOrEmpty(vGridControl1.Rows[i].Properties.FieldName))
                        vGridControl1.Rows[i].Properties.Value = (ProgramAyarlari.Instance.GetValue((ProgramSettingsEnum)Enum.Parse(typeof(ProgramSettingsEnum), vGridControl1.Rows[i].Properties.FieldName)));
            }
            catch (Exception ex)
            {

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 1; i < vGridControl1.Rows.Count; i++)
                    if (vGridControl1.Rows[i].Properties.Value != null)
                        ProgramAyarlari.Instance.AddItems((ProgramSettingsEnum)Enum.Parse(typeof(ProgramSettingsEnum), vGridControl1.Rows[i].Properties.FieldName), vGridControl1.Rows[i].Properties.Value.ToString());
                ProgramAyarlari.Instance.Save();
                DevExpress.XtraEditors.XtraMessageBox.Show("Kaydetme İşlemi Tamamlandı");
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Bir Hata Oluştu\r\n" + ex.Message);
            }
        }
    }
}
