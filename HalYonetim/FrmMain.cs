using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HalYonetim.Etiket;
using CrmPosHalYonetim;
using CrmPosHalYonetim.HksStokYonetim;

namespace HalYonetim
{
    public partial class FrmMain : XtraForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnSatis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.Controls.Clear();
            panelControl1.Controls.Add(new FrmHksBildirim() { Dock = DockStyle.Fill });
        }

        private void btnSevkFaturası_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.Controls.Clear();
            panelControl1.Controls.Add(new FrmHksBildirim() { Dock = DockStyle.Fill });
        }

        private void btnFirmaAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.Controls.Clear();
            panelControl1.Controls.Add(new FrmFirmaAyar() { Dock = DockStyle.Fill });
        }

        private void btnVeritabaniBaglanti_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.Controls.Clear();
            panelControl1.Controls.Add(new FrmDatabaseAyar() { Dock = DockStyle.Fill });
        }

        private void btnHaldenVeriAl_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.Controls.Clear();
            panelControl1.Controls.Add(new FrmHksBilgiVeriIndir() { Dock = DockStyle.Fill });
        }

        private void btnKünyeBilgisi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.Controls.Clear();
            panelControl1.Controls.Add(new FrmHksSevk() { Dock = DockStyle.Fill });
        }

        private void btnEtiketTasarim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.Controls.Clear();
            panelControl1.Controls.Add(new FrmEtiketDizayn() { Dock = DockStyle.Fill });
        }

        private void btnEtiketYazdir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.Controls.Clear();
            panelControl1.Controls.Add(new FrmEtiketYazdir() { Dock = DockStyle.Fill });
        }

        private void btnProgramAyarlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.Controls.Clear();
            panelControl1.Controls.Add(new FrmProgramAyarlari() { Dock = DockStyle.Fill });
        }

        private void btnSevkBildirimListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.Controls.Clear();
            panelControl1.Controls.Add(new FrmBildirimListesi() { Dock = DockStyle.Fill });
        }

        private void btnStokMasrafOran_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmMasrafOran frm = new FrmMasrafOran())
            {
                frm.ShowDialog();
            }
        }

        private void btnStokTanitimKarti_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmStokTanitim frm = new FrmStokTanitim())
            {
                frm.ShowDialog();
            }
        }

        private void btnCariTanitimKarti_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmCariTanitim frm = new FrmCariTanitim())
            {
                frm.ShowDialog();
            }
        }

        private void btnDepo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmDepoTanitim frm = new FrmDepoTanitim())
            {
                frm.ShowDialog();
            }
        }

        private void btnFatura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmFatura frm = new FrmFatura(0))
            {
                frm.ShowDialog();
            }
        }

        private void btnKasaTanim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmKasaTanim frm = new FrmKasaTanim())
            {
                frm.ShowDialog();
            }
        }

        private void btnIadeKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmFatura frm = new FrmFatura(1))
            {
                frm.ShowDialog();
            }
        }

        private void btnSevk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmStokTransfer frm = new FrmStokTransfer())
            {
                frm.ShowDialog();
            }
        }

        private void btnDepolarArasiKasaTransfer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmKasaTransfer frm = new FrmKasaTransfer())
            {
                frm.ShowDialog();
            }
        }

        private void btnRapor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmRapor frm = new FrmRapor())
            {
                frm.ShowDialog();
            }
        }

        private void btnOdemeTanim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmOdemeTanim frm = new FrmOdemeTanim())
            {
                frm.ShowDialog();
            }
        }

        private void btnTediye_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FrmTediye frm = new FrmTediye())
            {
                frm.ShowDialog();
            }
        }

    }
}
