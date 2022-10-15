using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrmPosHalYonetim.Entity;

namespace HalYonetim
{
    public partial class FrmFirmaAyar : UserControl
    {
        public FrmFirmaAyar()
        {
            InitializeComponent();
        }

        FirmaBilgisi firma = new FirmaBilgisi();
        List<ComboBoxItem> sifatlar = new List<ComboBoxItem>();
        /// <summary>
        /// 0:Liste 1:Kaydet 2:Sil
        /// </summary>
        /// <param name="tip"></param>
        private void KaydetSilListele(byte tip)
        {
            using (HKSDBEntities ent = GetDatabaseDbSettings.Instance.GetEntity())
            {
                switch (tip)
                {
                    case 0:
                        firma = ent.FirmaBilgileri.FirstOrDefault();
                        if (firma == null)
                        {
                            firma = new FirmaBilgisi() { EPosta = "", Gsm = "", ID = 0, ServisSifresi = "", Sifat1 = 0, Sifre = "", TcVgNo = "", Unvani = "" };
                        }
                        //rwEPosta.Properties.Value = firma.EPosta;
                        //rwGsm.Properties.Value = firma.Gsm;
                        rwID.Properties.Value = firma.ID;
                        rwServisSifresi.Properties.Value = firma.ServisSifresi != "" ? firma.ServisSifresi.DecryptString() : "";
                        rwSifati.Properties.Value = sifatlar.Where(x => x.Value.ToString() == firma.Sifat1.ToString()).FirstOrDefault();
                        rwSifre.Properties.Value = firma.Sifre != "" ? firma.Sifre.DecryptString() : "";
                        rwTcVgNo.Properties.Value = firma.TcVgNo;
                        //rwUnvani.Properties.Value = firma.Unvani;
                        rwID.Properties.Value = firma.ID;
                        //rwSifati2.Properties.Value = sifatlar.Where(x => x.Value.ToString() == firma.Sifat2.ToString()).FirstOrDefault();
                        break;
                    case 1:
                        //firma.EPosta = rwEPosta.Properties.Value.ToString();
                        //firma.Gsm = rwGsm.Properties.Value.ToString();
                        firma.ID = Convert.ToInt32(rwID.Properties.Value);
                        firma.ServisSifresi = rwServisSifresi.Properties.Value.ToString() != "" ? rwServisSifresi.Properties.Value.ToString().EncryptData() : "";
                        firma.Sifat1 = Convert.ToInt32((rwSifati.Properties.Value as ComboBoxItem).Value);
                        firma.Sifre = rwSifre.Properties.Value.ToString() != "" ? rwSifre.Properties.Value.ToString().EncryptData() : "";
                        firma.TcVgNo = rwTcVgNo.Properties.Value.ToString();
                        //firma.Unvani = rwUnvani.Properties.Value.ToString();
                        firma.ID = Convert.ToInt32(rwID.Properties.Value);
                        //firma.Sifat2 = Convert.ToInt32((rwSifati2.Properties.Value as ComboBoxItem).Value);
                        if (firma != null)
                        {
                            var getItem = ent.FirmaBilgileri.Where(x => x.ID == firma.ID).FirstOrDefault();
                            if (getItem != null)
                            {
                                getItem.EPosta = firma.EPosta;
                                getItem.Gsm = firma.Gsm;
                                getItem.ServisSifresi = firma.ServisSifresi;
                                getItem.Sifat1 = firma.Sifat1;
                                getItem.Sifat2 = firma.Sifat2;
                                getItem.Sifre = firma.Sifre;
                                getItem.TcVgNo = firma.TcVgNo;
                                getItem.Unvani = firma.Unvani;
                            }
                            else
                            {
                                ent.AddToFirmaBilgileri(firma);
                            }
                            try
                            {
                                ent.SaveChanges();
                                Settings.Instance.LoadData();
                                DevExpress.XtraEditors.XtraMessageBox.Show("Kaydetme İşleminiz Başarılı.");
                            }
                            catch (Exception ex)
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                            }
                        }
                        break;
                    case 2:

                        if (firma.ID > 0)
                        {
                            var getitem = ent.FirmaBilgileri.Where(x => x.ID == firma.ID).FirstOrDefault();
                            if (getitem != null)
                            {
                                ent.DeleteObject(getitem);
                                try
                                {
                                    ent.SaveChanges();
                                    DevExpress.XtraEditors.XtraMessageBox.Show("Silme İşleminiz Başarılı.");
                                    KaydetSilListele(0);
                                }
                                catch (Exception ex)
                                {
                                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                                }
                            }
                        }
                        break;

                }
            }
        }

        private void FrmFirmaAyar_Load(object sender, EventArgs e)
        {
            sifatlar.AddRange(new ComboBoxItem[] { new ComboBoxItem { Value = 0, Text = "Seçiniz..." }, new ComboBoxItem { Value = 9, Text = "Depo/Tasnif ve Ambalaj" }, new ComboBoxItem { Value = 19, Text = "Hastane" }, new ComboBoxItem { Value = 2, Text = "İhracat" }, new ComboBoxItem { Value = 3, Text = "İthalat" }, new ComboBoxItem { Value = 5, Text = "Komisyoncu" }, new ComboBoxItem { Value = 13, Text = "Lokanta" }, new ComboBoxItem { Value = 8, Text = "Manav" }, new ComboBoxItem { Value = 7, Text = "Market" }, new ComboBoxItem { Value = 12, Text = "Otel" }, new ComboBoxItem { Value = 11, Text = "Pazarcı" }, new ComboBoxItem { Value = 1, Text = "Sanayici" }, new ComboBoxItem { Value = 20, Text = "Tüccar (Hal Dışı)" }, new ComboBoxItem { Value = 6, Text = "Tüccar (Hal İçi)" }, new ComboBoxItem { Value = 4, Text = "Üretici" }, new ComboBoxItem { Value = 10, Text = "Üretici Örgütü" }, new ComboBoxItem { Value = 15, Text = "Yemek Fabrikası" }, new ComboBoxItem { Value = 14, Text = "Yurt" } });
            cmbSifat.Items.AddRange(sifatlar.ToArray());
            KaydetSilListele(0);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            KaydetSilListele(1);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            KaydetSilListele(0);
            Settings.Instance.LoadData();
        }
    }
}
