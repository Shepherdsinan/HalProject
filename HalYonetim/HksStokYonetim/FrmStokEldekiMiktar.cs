using CrmPosHalYonetim.Entity;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CrmPosHalYonetim.HksStokYonetim
{
    public partial class FrmStokEldekiMiktar : XtraForm
    {
        List<StyStokMiktarItem> stokMiktar = new List<StyStokMiktarItem>();
        public FrmStokEldekiMiktar(List<StyStokMiktarItem> stk)
        {
            InitializeComponent();
            stokMiktar = stk;
            this.Load += FrmStokEldekiMiktar_Load;
        }
        void FrmStokEldekiMiktar_Load(object sender, EventArgs e)
        {
            foreach (var item in stokMiktar)
            {
                if (item.BirimMiktar == 0)
                {
                    item.BirimMiktar = item.GercekBirimMiktar;
                }
                if (item.KasaMiktar == 0)
                {
                    item.KasaMiktar = item.GercekKasaMiktar;
                }
                if (item.IadeKasaMiktar == 0)
                {
                    item.IadeKasaMiktar = item.GercekIadeKasaMiktar;
                }
            }
            gridControl1.DataSource = stokMiktar;
            gridView1.Columns["ID"].Visible = false;
            gridView1.Columns["DepoNo"].Visible = false;
            gridView1.Columns["StokKodu"].Visible = false;
            gridView1.Columns["GercekBirimMiktar"].Visible = false;
            gridView1.Columns["GercekKasaMiktar"].Visible = false;
            gridView1.Columns["GercekIadeKasaMiktar"].Visible = false;
        }
        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                gridView1_DoubleClick(gridView1, null);
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            this.Tag = gridView1.GetRow(gridView1.FocusedRowHandle);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
