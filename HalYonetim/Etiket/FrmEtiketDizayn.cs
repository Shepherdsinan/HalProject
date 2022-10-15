using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CrmPosHalYonetim;

namespace HalYonetim.Etiket
{
    public partial class FrmEtiketDizayn : UserControl
    {
        public FrmEtiketDizayn()
        {
            InitializeComponent();
            designerControl1.cmdSave.CustomAction += new EventHandler(cmdSave_CustomAction);
            this.Load += new EventHandler(FrmEtiketDizayn_Load);
        }
        string etiketDosyaYolu = Application.StartupPath + "\\HksEtiket.repx";
        void FrmEtiketDizayn_Load(object sender, EventArgs e)
        {
            FastReport.Report invoice = null;
            if (File.Exists(etiketDosyaYolu))
            {
                invoice = FastReport.Report.FromFile(etiketDosyaYolu);
            }
            else
            {
                invoice = new FastReport.Report();
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = new BildirimEtiketItem();
            invoice.RegisterData(bs, "HksEtiket", 10);
            invoice.GetDataSource("HksEtiket").Enabled = true;
            invoice.FileName = etiketDosyaYolu;
            designerControl1.Report = invoice;
            designerControl1.RefreshLayout();
        }

        void cmdSave_CustomAction(object sender, EventArgs e)
        {
            designerControl1.Report.Save(etiketDosyaYolu);
        }
    }
}
