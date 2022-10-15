using CrmPosHalYonetim.Entity;
using DevExpress.XtraEditors;
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
    public partial class FrmKasaTransfer : XtraForm
    {
        public FrmKasaTransfer()
        {
            InitializeComponent();
            this.Load += FrmKasaTransfer_Load;
        }
        #region Field
        StyDepoIslem depoIslem = new StyDepoIslem();
        StyKasaIslem kasaIslem = new StyKasaIslem();
        List<KasaTransferItem> satirlar = new List<KasaTransferItem>();
        #endregion

        #region Metod
        private void SatirEkle()
        {
            int satir = 0;
            for (int i = 0; i < satirlar.Count; i++)
            {
                satirlar[i].Satir = satir;
                satir++;
            }
            if (satirlar.Count == 0)
                satirlar.Add(new KasaTransferItem { Satir = satir, KasaMiktar = 1 });
            int bosSatir = satirlar.Where(x => x.Kasa == null).Count();
            if (bosSatir == 0)
            {
                satir = satirlar.Max(x => x.Satir) + 1;
                satirlar.Add(new KasaTransferItem { Satir = satir, KasaMiktar = 1 });

                gridView1.FocusedColumn = gridView1.Columns["Kasa"];
                gridView1.SelectRow(0);
                gridView1.FocusedRowHandle = gridView1.FocusedRowHandle + 1;
                gridView1.SelectCell(0, gridView1.Columns["Kasa"]);
            }
            gridControl1.RefreshDataSource();
        }
        #endregion
        void FrmKasaTransfer_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = satirlar;
            var nkasalar = kasaIslem.TumKasalar();
            if (nkasalar != null)
                cmbKasa.Items.AddRange(nkasalar.Select(x => new ComboItem { Text = x.Tanim, Value = x.No }).ToArray());
            SatirEkle();
        }
        private void txtCikisDepo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (FrmListe frm = new FrmListe(ListeType.Depo))
            {
                frm.ParametreNo = txtGirisDepo.Tag != null ? txtGirisDepo.Tag.ToString() : "";
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.Tag != null)
                    {
                        var depo = depoIslem.DepoGetir(frm.Tag.ToString());
                        if (depo != null)
                        {
                            txtCikisDepo.Tag = depo.DepoNo;
                            txtCikisDepo.Text = depo.DepoTanim;
                            txtCikisIadeKasaMiktar.Text = StyKasaIslem.Instance.IadeKasaEnvanter(depo.DepoNo).ToString();
                            txtCikisKasaMiktar.Text = StyKasaIslem.Instance.KasaEnvanter(depo.DepoNo).ToString();

                        }
                    }
                }
            }
        }
        private void txtCikisDepo_Validated(object sender, EventArgs e)
        {
            if (txtCikisDepo.Tag == null)
                txtCikisDepo_ButtonClick(txtCikisDepo, new DevExpress.XtraEditors.Controls.ButtonPressedEventArgs(new DevExpress.XtraEditors.Controls.EditorButton()));
        }
        private void txtGirisDepo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (FrmListe frm = new FrmListe(ListeType.Depo))
            {
                frm.ParametreNo = txtCikisDepo.Tag != null ? txtCikisDepo.Tag.ToString() : "";
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.Tag != null)
                    {
                        var depo = depoIslem.DepoGetir(frm.Tag.ToString());
                        if (depo != null)
                        {
                            txtGirisDepo.Tag = depo.DepoNo;
                            txtGirisDepo.Text = depo.DepoTanim;
                            txtGirisIadeKasaMiktar.Text = StyKasaIslem.Instance.IadeKasaEnvanter(depo.DepoNo).ToString();
                            txtGirisKasaMiktar.Text = StyKasaIslem.Instance.KasaEnvanter(depo.DepoNo).ToString();
                        }
                    }
                }
            }
        }
        private void txtGirisDepo_Validated(object sender, EventArgs e)
        {
            if (txtGirisDepo.Tag == null)
                txtGirisDepo_ButtonClick(txtGirisDepo, new DevExpress.XtraEditors.Controls.ButtonPressedEventArgs(new DevExpress.XtraEditors.Controls.EditorButton()));
        }
        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                SatirEkle();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtCikisDepo.Tag == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Lütfen Çıkış Deposu Seçin.");
                return;
            }
            else if (txtGirisDepo.Tag == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Lütfen Giriş Deposu Seçin.");
            }
            foreach (var item in satirlar)
            {
                if (item.Kasa != null && !string.IsNullOrWhiteSpace(item.Kasa.Text) && item.KasaMiktar > 0)
                {
                    item.CikisDepoNo = txtCikisDepo.Tag.ToString();
                    item.GirisDepoNo = txtGirisDepo.Tag.ToString();

                    StyKasaIslem.Instance.KasaMiktarHareket(false, new StyKasaMiktar
                    {
                        DepoNo = item.CikisDepoNo,
                        Tarih = DateTime.Now,
                        CariKod = item.CariKodu,
                        GirisCikis = 1,
                        Miktar = item.KasaMiktar,
                        KasaNo = item.Kasa.Value.ToString()
                    });


                    StyKasaIslem.Instance.KasaMiktarHareket(true, new StyKasaMiktar
                    {
                        DepoNo = item.GirisDepoNo,
                        Tarih = DateTime.Now,
                        CariKod = item.CariKodu,
                        GirisCikis = 1,
                        Miktar = item.KasaMiktar,
                        KasaNo = item.Kasa.Value.ToString()
                    });
                }
            }
            DevExpress.XtraEditors.XtraMessageBox.Show("Kaydetme İşlemi Tamam");
            this.Close();
        }
        private void btnCariKodu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (FrmListe frm = new FrmListe(ListeType.Cari))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.Tag != null)
                    {
                        var cari = StyCariIslem.Instance.CariGetir(frm.Tag.ToString());
                        if (cari != null)
                        {
                            satirlar[gridView1.FocusedRowHandle].CariKodu = cari.Kodu;
                            satirlar[gridView1.FocusedRowHandle].CariAdi = cari.Adi;
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "CariKodu", cari.Kodu);
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "CariAdi", cari.Adi);
                            gridView1.FocusedColumn = gridView1.Columns["Kasa"];
                        }
                    }
                }
            }
        }
        private void btnCariAdi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (FrmListe frm = new FrmListe(ListeType.Cari))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.Tag != null)
                    {
                        var cari = StyCariIslem.Instance.CariGetir(frm.Tag.ToString());
                        if (cari != null)
                        {
                            satirlar[gridView1.FocusedRowHandle].CariKodu = cari.Kodu;
                            satirlar[gridView1.FocusedRowHandle].CariAdi = cari.Adi;
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "CariKodu", cari.Kodu);
                            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "CariAdi", cari.Adi);
                            gridView1.FocusedColumn = gridView1.Columns["Kasa"];
                        }
                    }
                }
            }
        }
    }
    public class KasaTransferItem
    {
        public int Satir { get; set; }
        public string CariKodu { get; set; }
        public string CariAdi { get; set; }
        public ComboItem Kasa { get; set; }
        public double KasaMiktar { get; set; }
        public string GirisDepoNo { get; set; }
        public string CikisDepoNo { get; set; }
    }
}
