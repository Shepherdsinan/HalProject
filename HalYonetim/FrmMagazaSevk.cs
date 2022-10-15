using CrmPosHalYonetim.Entity;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using HalYonetim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CrmPosHalYonetim
{
    public partial class FrmMagazaSevk : XtraForm
    {
        public FrmMagazaSevk(string urunAdi, double satisFiyat, double miktar,DateTime ilkbildirimtarihi)
        {
            InitializeComponent();
            Magazalar = new List<SevkMagaza>();
            MagazaBelgeAracPlakalari = new List<MagazaBelgeAracPlaka>();
            _defaultSatisFiyat = satisFiyat;
            _defaultMiktar = miktar;
            lblUrunAdi.Text = urunAdi;
            txtMiktar.Text = miktar.ToString();
            _defaultilkbildirimtarihi = ilkbildirimtarihi;

        }
        public bool Otomatik { get; set; }
        public List<HKSSube> Subeler { get; set; }
        private double _defaultSatisFiyat = 0;
        private double _defaultMiktar = 0;
        private DateTime _defaultilkbildirimtarihi;
        public List<SevkMagaza> Magazalar { get; set; }
        public List<MagazaBelgeAracPlaka> MagazaBelgeAracPlakalari { get; set; }
        private void FrmMagazaSevk_Load(object sender, EventArgs e)
        {
            using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
            {
                var dagiticigelmesin = new List<int> { 71850 };
                var magaza = Subeler != null && Subeler.Count > 0 ? Subeler : ent.HKSSubeler.OrderBy(x => x.SubeAdi).Where(x => !dagiticigelmesin.Contains(x.ID)).ToList();
                // double sevkMiktar = Math.Round(_defaultMiktar / magaza.Count, 2);
                string aracPlaka = "";
                string belgeNo = "";
                
                foreach (var item in magaza)
                {
                    belgeNo = item.BelgeNoSubeSevk;
                    var getPlaka = MagazaBelgeAracPlakalari.Where(x => x.ID == item.ID).FirstOrDefault();
                    if (getPlaka == null)
                    {
                        if (!Otomatik)
                        {
                            var sevkPlaka = ent.HksSevkler.Where(x => x.GidecekIsyeriId == item.ID).OrderByDescending(x => x.BildirimTarihi).Select(x => x.AracPlakaNo).FirstOrDefault();
                            if (sevkPlaka != null)
                                aracPlaka = sevkPlaka;
                            else
                                aracPlaka = "";
                        }

                    }
                    else
                    {
                        aracPlaka = getPlaka.AracPlaka;
                        belgeNo = getPlaka.BelgeNo;
                    }
                    double sevkMiktar = 0;
                    if (Otomatik)
                    {
                        sevkMiktar = _defaultMiktar;
                    }
                    
                    SevkMagaza mgz = new SevkMagaza
                    {

                        AracPlaka = aracPlaka,
                        BelgeNo = belgeNo,
                        Id = item.ID,
                        IsYeriTurId = item.IsYeriTuru.Value,
                        IsYeriTuru = ent.HKSIsletmeler.Where(x => x.ID == item.IsYeriTuru).Select(x => x.Adi).FirstOrDefault(),
                        Magaza = item.SubeAdi,
                        KunyeNo = 0,
                        NihaiKunye = 0,
                        SatisFiyat = _defaultSatisFiyat,
                        SevkMiktar = sevkMiktar,
                        İlkBildirimtarihi = _defaultilkbildirimtarihi,
                        SevkTarihi = DateTime.Now,
                        KayitTarihi = DateTime.Now
                        

                    };
                    if (!Magazalar.Contains(mgz))
                    {
                        Magazalar.Add(mgz);
                    }
                }
            }
            gridControl1.DataSource = Magazalar;
            if (!Otomatik)
            {
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    switch (gridView1.Columns[i].FieldName)
                    {
                        case "IsYeriTuru":
                        case "Magaza":
                            gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                            break;
                        case "AracPlaka":
                        case "BelgeNo":
                        case "SevkMiktar":

                            gridView1.Columns[i].Visible = true;
                            break;
                        default:
                            gridView1.Columns[i].Visible = false;
                            break;
                    }
                }

            }
            gridView1.Columns["SevkMiktar"].Summary.Add(DevExpress.Data.SummaryItemType.Sum);

            if (Otomatik)
            {
                var count = Magazalar.Where(x => x.AracPlaka != "" && x.BelgeNo != "" && x.SevkMiktar > 0 && x.SatisFiyat > 0).ToList();
                if (count.Count > 0)
                {
                    simpleButton1_Click(null, null);
                }
            }
            else
                gridView1.BestFitColumns();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var count = Magazalar.Where(x => x.AracPlaka != "" && x.BelgeNo != "" && x.SevkMiktar > 0 && x.SatisFiyat > 0).ToList();
            if (count.Count > 0)
            {
                MagazaBelgeAracPlakalari.Clear();
                foreach (var item in Magazalar.Where(x => x.AracPlaka != "" && x.BelgeNo != "" && x.SevkMiktar > 0 && x.SatisFiyat > 0).ToList())
                    MagazaBelgeAracPlakalari.Add(new MagazaBelgeAracPlaka { AracPlaka = item.AracPlaka, BelgeNo = item.BelgeNo, ID = item.Id });
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }

        }

        private void btnPlakaDagit_Click(object sender, EventArgs e)
        {
            var getPlaka = gridView1.GetRow(gridView1.FocusedRowHandle) as SevkMagaza;
            if (getPlaka != null)
            {
                foreach (var item in Magazalar)
                    item.AracPlaka = getPlaka.AracPlaka;
                gridControl1.RefreshDataSource();
            }
        }
        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            //if (e.FocusedColumn.FieldName == "SevkMiktar")
            //{
            //    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, e.FocusedColumn).ToString() == "0")
            //    {
            //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, e.FocusedColumn, "");
            //    }
            //    gridView1.SelectCell(gridView1.FocusedRowHandle, e.FocusedColumn);
            //}
           
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                txtMiktar.Text = (_defaultMiktar - Magazalar.Where(x => x.AracPlaka != "" && x.BelgeNo != "").Sum(x => x.SevkMiktar)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var getBelgeNo = gridView1.GetRow(gridView1.FocusedRowHandle) as SevkMagaza;
            if (getBelgeNo != null)
            {
                foreach (var item in Magazalar)
                    item.BelgeNo = getBelgeNo.BelgeNo;
                gridControl1.RefreshDataSource();
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            gridView1.SelectCell(gridView1.FocusedRowHandle, gridView1.Columns["SevkMiktar"]);

            
        }

        private void gridView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                gridView1.FocusedRowHandle = gridView1.FocusedRowHandle + 1;
                gridView1.FocusedColumn = gridView1.Columns["SevkMiktar"];
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            var getsevkmiktar = gridView1.GetRow(gridView1.FocusedRowHandle) as SevkMagaza;
            if (getsevkmiktar != null)
            {
                foreach (var item in Magazalar)
                    item.SevkMiktar = getsevkmiktar.SevkMiktar;
                gridControl1.RefreshDataSource();
            }
        }
               
        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            //BeginInvoke(new Action(() =>
            //{
            //    if (gridView1.FocusedColumn.FieldName == "BelgeNo" )
            //    {
            //        var editor = (gridView1.ActiveEditor as TextEdit);
            //        editor.Select(editor.Text.Length,0);
            //    }

            //    gridView1.ActiveEditor.SelectAll();
            //}
            //));
            GridView view = sender as GridView;
            if (view.ActiveEditor is TextEdit)
                view.ActiveEditor.MouseUp += ActiveEditor_MouseUp;
        }

        private void ActiveEditor_MouseUp(object sender, MouseEventArgs e)
        {
            TextEdit edit = sender as TextEdit;
            edit.MouseUp -= ActiveEditor_MouseUp;

            switch (gridView1.FocusedColumn.FieldName)
            {
                case "BelgeNo":
                    edit.Select(edit.Text.Length, 0);
                    break;
                default:
                    edit.SelectAll();
                    break;
            }

        }
    }
}
