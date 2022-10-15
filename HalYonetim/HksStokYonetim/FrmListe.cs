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

namespace CrmPosHalYonetim.HksStokYonetim
{
    public partial class FrmListe : XtraForm
    {
        public FrmListe(ListeType listeType)
        {
            InitializeComponent();
            _listeType = listeType;
            this.Load += FrmListe_Load;
        }
        public string ParametreNo { get; set; }

        void FrmListe_Load(object sender, EventArgs e)
        {
            ListeYukle();
        }

        private void ListeYukle()
        {
            try
            {
                HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity();
                gridControl1.DataSource = null;
                switch (_listeType)
                {
                    case ListeType.Stok:
                        gridControl1.DataSource = ent.StyStoklar.Select(x => new { x.Kodu, x.Adi, x.Fiyat }).ToList();
                        gridView1.BestFitColumns();
                        break;
                    case ListeType.Cari:
                        gridControl1.DataSource = ent.StyCariler.Select(x => new { x.Kodu, x.Adi, x.FaturaAdres, x.SevkAdres }).ToList();
                        gridView1.BestFitColumns();
                        break;
                    case ListeType.Depo:
                        gridControl1.DataSource = string.IsNullOrWhiteSpace(ParametreNo) ? ent.StyDepolar.Select(x => new { x.DepoNo, x.DepoTanim }).ToList() : ent.StyDepolar.Where(x => x.DepoNo != ParametreNo).Select(x => new { x.DepoNo, x.DepoTanim }).ToList();
                        gridView1.BestFitColumns();
                        break;
                    case ListeType.Kasa:
                        gridControl1.DataSource = ent.StyKasalar.Select(x => new { x.No, x.Tanim, x.Iadelimi }).ToList();
                        gridView1.BestFitColumns();
                        break;
                    case ListeType.Odeme:
                        gridControl1.DataSource = ent.StyOdemeTanimlari.Select(x => new { x.No, x.Tanim }).ToList();
                        gridView1.BestFitColumns();
                        break;
                }
            }
            catch (Exception ex)
            {
                HataLog.Instance.HataLogYaz(ex);
            }
        }
        ListeType _listeType = ListeType.Stok;

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            this.Tag = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[0]);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridView1_DoubleClick(gridView1, null);
            }
            else if (e.Alt && e.KeyCode == Keys.E)
            {
                switch (_listeType)
                {
                    case ListeType.Stok:
                        using (FrmStokTanitim frmStok = new FrmStokTanitim())
                        {
                            frmStok.ShowDialog();
                        }
                        break;
                    case ListeType.Cari:
                        using (FrmCariTanitim frmCari = new FrmCariTanitim())
                        {
                            frmCari.ShowDialog();
                        }
                        break;
                    case ListeType.Depo:
                        using (FrmDepoTanitim frmDepo = new FrmDepoTanitim())
                        {
                            frmDepo.ShowDialog();
                        }
                        break;
                    case ListeType.Kasa:
                        using (FrmKasaTanim frmKasa = new FrmKasaTanim())
                        {
                            frmKasa.ShowDialog();
                        }
                        break;
                    case ListeType.Odeme:
                        using (FrmOdemeTanim frmOdeme = new FrmOdemeTanim())
                        {
                            frmOdeme.ShowDialog();
                        }
                        break;
                }
                ListeYukle();

            }
        }
    }
    public enum ListeType : byte
    {
        Stok = 0,
        Cari = 1,
        Depo = 2,
        Kasa = 3,
        Odeme = 4
    }
}
