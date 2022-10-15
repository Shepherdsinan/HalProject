using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrmPosHalYonetim.HksBildirimService;
using CrmPosHalYonetim;

namespace HalYonetim
{
    public partial class FrmEtiketYazdir : UserControl
    {
        public FrmEtiketYazdir()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmEtiketYazdir_Load);
        }
        string etiketDosyaYolu = Application.StartupPath + "\\HksEtiket.repx";
        void FrmEtiketYazdir_Load(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(etiketDosyaYolu))
            {
                btnYazdir.Enabled = false;
                DevExpress.XtraEditors.XtraMessageBox.Show("Etiket Tasarımınızı Yaptıktan Sonra Etiket Basabilirsiniz.");
            }
            dtTarih.EditValue = DateTime.Now;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            GetListele();
        }
        private void GetListele()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DateTime baslangicTarihi = Convert.ToDateTime(dtTarih.Text);
                DateTime bitisTarihi = DateTime.Now;
                var sonuc = ServisYonetimi.Genel.EtiketListesi(txtPlaka.Text, txtBelge.Text, Convert.ToDateTime(dtTarih.Text));
                if (sonuc != null && sonuc.Kunyeler != null)
                {
                    gridControl1.DataSource = null;
                    gridControl1.DataSource = sonuc.Kunyeler;
                    //gridControl1.DataSource = !string.IsNullOrWhiteSpace(ProgramAyarlari.Instance.GetValue(ProgramSettingsEnum.Magaza)) ? sonuc.Kunyeler.Where(x => x.IsletmeAdi == ProgramAyarlari.Instance.GetValue(ProgramSettingsEnum.Magaza)).ToList() : sonuc.Kunyeler;
                    for (int i = 0; i < gridView1.Columns.Count; i++)
                    {
                        if (gridView1.Columns[i].FieldName.Contains("id") || gridView1.Columns[i].FieldName.Contains("Id"))
                            gridView1.Columns[i].Visible = false;
                    }
                    gridView1.BestFitColumns();
                }
            }
            catch (Exception ex)
            {

            }
            this.Cursor = Cursors.Default;
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                //List<BildirimEtiketItem> etiketItems = new List<BildirimEtiketItem>();
                //foreach (var item in gridView1.GetSelectedRows())
                //{
                //    BildirimEtiketDTO seciliItem = gridView1.GetRow(item) as CrmPosHalYonetim.HksBildirimService.BildirimEtiketDTO;
                //    if (seciliItem != null)
                //        etiketItems.Add(new BildirimEtiketItem { Bildirim = new CrmPosHalYonetim.HksBildirimService.BildirimEtiketDTO { IsletmeAdi = seciliItem.IsletmeAdi, KayitTarihi = seciliItem.KayitTarihi, MalinAdi = seciliItem.MalinAdi, MalinAlisFiyat = seciliItem.MalinAlisFiyat, MalinCinsAdi = seciliItem.MalinCinsAdi, MalinKunyeNo = seciliItem.MalinKunyeNo, MalinMiktar = seciliItem.MalinMiktar, MiktarBirimAd = seciliItem.MiktarBirimAd, UreticisininAdUnvani = seciliItem.UreticisininAdUnvani, UretimSekliAdi = seciliItem.UretimSekliAdi, UretimTarihi = seciliItem.UretimTarihi, UretimYeri = seciliItem.UretimYeri } });
                //}

                //FastReport.Report report = FastReport.Report.FromFile(etiketDosyaYolu);
                //BindingSource bs = new BindingSource();
                //bs.DataSource = etiketItems;
                //report.RegisterData(bs, "HksEtiket", 10);
                //report.GetDataSource("HksEtiket").Enabled = true;

                //if (!string.IsNullOrWhiteSpace(ProgramAyarlari.Instance.GetValue(ProgramSettingsEnum.EtiketYazicisi)))
                //{
                //    report.PrintSettings.Printer = ProgramAyarlari.Instance.GetValue(ProgramSettingsEnum.EtiketYazicisi);
                //    report.PrintSettings.ShowDialog = false;
                //}
                //else
                //    report.PrintSettings.ShowDialog = true;
                //report.Prepare();
                //report.Print();
            }
        }
    }
}
