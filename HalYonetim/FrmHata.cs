using DevExpress.XtraEditors;
using System;

namespace CrmPosHalYonetim
{
    public partial class FrmHata : XtraForm
    {
        public FrmHata()
        {
            InitializeComponent();
        }
        public string HataliKunyeler { get; set; }
        private void FrmHata_Load(object sender, EventArgs e)
        {
            txtHatali.Text = HataliKunyeler;
        }
    }
}
