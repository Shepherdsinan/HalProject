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
    public partial class FrmDepoTanitim : XtraForm
    {
        public FrmDepoTanitim()
        {
            InitializeComponent();
        }
        StyDepoIslem depoIslem = new StyDepoIslem();

        private void yeniEkran()
        {
            txtDepoNo.Text = "";
            txtDepoTanim.Text = "";
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDepoNo.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Depo No Girin");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDepoTanim.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Depo Tanım Girin");
                return;
            }
            bool sonuc = depoIslem.DepoKaydet(new Entity.StyDepo
            {
                DepoNo = txtDepoNo.Text,
                DepoTanim = txtDepoTanim.Text,
            });
            if (sonuc)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Kaydetme Başarılı");
                yeniEkran();
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Kaydetme Başarısız. Lütfen hata loglarından kontrol edin");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDepoNo.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Depo No Girin");
                return;
            }
            if (DevExpress.XtraEditors.XtraMessageBox.Show("Silmek İstediğinizden Eminmisiniz?", "Uyarı", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (depoIslem.DepoSil(new Entity.StyDepo { DepoNo = txtDepoNo.Text }))
                {
                    yeniEkran();
                }
            }
        }

        private void FrmDepoTanitim_Load(object sender, EventArgs e)
        {

        }

        private void txt_DepoButton_Click(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (FrmListe frm = new FrmListe(ListeType.Depo))
            {
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.Tag != null)
                    {
                        var depo = depoIslem.DepoGetir(frm.Tag.ToString());
                        if (depo != null)
                        {
                            txtDepoNo.Text = depo.DepoNo;
                            txtDepoTanim.Text = depo.DepoTanim;
                        }
                    }
                }
            }
        }
    }
}
