using CrmPosHalYonetim.HksStokYonetim;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CrmPosHalYonetim.Rapor
{
    public partial class FrmRaporGoruntule : Form
    {
        public FrmRaporGoruntule(string query)
        {
            InitializeComponent();
            _query = query;
            this.Load += FrmRaporGoruntule_Load;
        }
        string _query = "";
        void FrmRaporGoruntule_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = DataLayer.GetLayer.FillData(_query);
        }

        private void exceleAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Excel Dosyası (*.xls)|*.xls";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    gridControl1.ExportToXls(dlg.FileName);
                }
            }

        }

        private void pdfeAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Acrobat Reader |*.Pdf";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    gridControl1.ExportToXls(dlg.FileName);
                }
            }
        }
    }
}
