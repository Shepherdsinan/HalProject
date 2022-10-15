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
    public partial class FrmHksBilgiVeriIndir : UserControl
    {
        public FrmHksBilgiVeriIndir()
        {
            InitializeComponent();
        }

        private void btnBasla_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                HksGuncellemeIslemi islem = new HksGuncellemeIslemi();
                if (chkSube.Checked)
                {
                    foreach (var item in islem.GuncellemeyiBaslat(GuncellemeSirasi.MagazaGuncelle))
                    {
                        lblMesaj.Text = item;
                        Application.DoEvents();
                    }
                    chkSube.Checked = false;
                }
                if (chkStok.Checked)
                {
                    foreach (var item in islem.GuncellemeyiBaslat(GuncellemeSirasi.StokGuncelle))
                    {
                        lblMesaj.Text = item;
                        Application.DoEvents();
                    }
                    chkStok.Checked = false;
                }
                if (chkBirim.Checked)
                {
                    foreach (var item in islem.GuncellemeyiBaslat(GuncellemeSirasi.BirimGuncelle))
                    {
                        lblMesaj.Text = item;
                        Application.DoEvents();
                    }
                    chkBirim.Checked = false;
                }
                if (chkStokCins.Checked)
                {
                    foreach (var item in islem.GuncellemeyiBaslat(GuncellemeSirasi.CinsGuncelle))
                    {
                        lblMesaj.Text = item;
                        Application.DoEvents();
                    }
                    chkStokCins.Checked = false;
                }
                if (chkStokUretimSekli.Checked)
                {
                    foreach (var item in islem.GuncellemeyiBaslat(GuncellemeSirasi.UretimSekliGuncelle))
                    {
                        lblMesaj.Text = item;
                        Application.DoEvents();
                    }
                    chkStokUretimSekli.Checked = false;
                }
                if (chkIl.Checked)
                {
                    foreach (var item in islem.GuncellemeyiBaslat(GuncellemeSirasi.IlGuncelle))
                    {
                        lblMesaj.Text = item;
                        Application.DoEvents();
                    }
                    chkIl.Checked = false;
                }
                if (chkIsletmeTuru.Checked)
                {
                    foreach (var item in islem.GuncellemeyiBaslat(GuncellemeSirasi.IsletmeTuruGuncelle))
                    {
                        lblMesaj.Text = item;
                        Application.DoEvents();
                    }
                    chkIsletmeTuru.Checked = false;
                }
                if (chkBildirimTurleri.Checked)
                {
                    foreach (var item in islem.GuncellemeyiBaslat(GuncellemeSirasi.BildirimGuncelle))
                    {
                        lblMesaj.Text = item;
                        Application.DoEvents();
                    }
                    chkBildirimTurleri.Checked = false;
                }
                if (chkBelge.Checked)
                {
                    foreach (var item in islem.GuncellemeyiBaslat(GuncellemeSirasi.BelgeGuncelle))
                    {
                        lblMesaj.Text = item;
                        Application.DoEvents();
                    }
                }
                lblMesaj.Text = "AKTARIM TAMAMLANDI";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            this.Cursor = Cursors.Default;
        }


    }
}
