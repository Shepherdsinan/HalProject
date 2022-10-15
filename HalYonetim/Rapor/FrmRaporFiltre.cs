using CrmPosHalYonetim.HksStokYonetim;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CrmPosHalYonetim.Rapor
{
    public partial class FrmRaporFiltre : XtraForm
    {
        public FrmRaporFiltre(string rapor_dosyasi)
        {
            InitializeComponent();
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            this.Load += FrmRaporFiltre_Load;
            _rapor_dosyasi = rapor_dosyasi;
        }
        private void RaporOku()
        {
            if (File.Exists(_rapor_dosyasi) == true)
            {
                StreamReader sr = new StreamReader(_rapor_dosyasi, System.Text.Encoding.Default);
                string line = "";
                string[] ozellik;
                string tip;
                string alanad;
                liste.Clear();
                while (sr.Peek() > -1)
                {
                    line = sr.ReadLine();
                    _orjinal_sql += (line + " ");
                    if (line.IndexOf("@") > -1)
                    {
                        ozellik = line.Split(new char[] { '@' });
                        tip = ozellik[1];
                        alanad = ozellik[2];
                        if (liste.Contains(new RaporFiltre { Text = alanad }) == false)
                        {
                            liste.Add(new RaporFiltre
                            {
                                Text = alanad,
                                Tip = tip,
                                Value = null
                            });
                        }
                    }
                }
                sr.Close();
            }
        }
        void FrmRaporFiltre_Load(object sender, EventArgs e)
        {
            RaporOku();
            gridControl1.DataSource = liste;
            gridView1.Columns["Tip"].Visible = false;
            gridView1.Columns["Text"].OptionsColumn.AllowEdit = false;
            if (liste.Count == 0)
            {
                btnRaporAl_Click(null, null);
            }
        }
        private string _rapor_dosyasi;
        private string _rapor_sql;
        private string _orjinal_sql;
        List<RaporFiltre> filters = new List<RaporFiltre>();
        List<RaporFiltre> liste = new List<RaporFiltre>();
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            RaporFiltre ff = gridView1.GetRow(gridView1.FocusedRowHandle) as RaporFiltre;
            if (ff != null)
            {
                switch (ff.Tip)
                {
                    case "D":
                        this.dtTarih.Mask.EditMask = "g";
                        this.dtTarih.Mask.EditMask = "g";
                        gridView1.Columns["Value"].ColumnEdit = dtTarih;
                        break;
                    case "T":
                        gridView1.Columns["Value"].ColumnEdit = txtText;
                        break;
                    case "KS":
                    case "CR":
                    case "DP":
                    case "S":
                        gridView1.Columns["Value"].ColumnEdit = btnListe;
                        break;
                }
            }
        }

        private void btnRaporAl_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in liste)
                {
                    if (item.Value != null)
                    {
                        string prm = "@" + item.Tip + "@" + item.Text + "@";
                        switch (item.Tip)
                        {
                            case "D":
                                _orjinal_sql = _orjinal_sql.Replace(prm, Convert.ToDateTime(item.Value).ToString("yyyy-MM-dd"));
                                break;
                            case "KS":
                            case "CR":
                            case "DP":
                            case "S":
                                _orjinal_sql = _orjinal_sql.Replace(prm, item.Value.ToString());
                                break;
                        }
                    }
                    else if (item.Value == null && item.Tip == "D")
                    {
                        string prm = "@" + item.Tip + "@" + item.Text + "@";
                        _orjinal_sql = _orjinal_sql.Replace(prm, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59).ToString("yyyy-MM-dd"));
                    }
                    else if (item.Value == null)
                    {
                        string prm = "@" + item.Tip + "@" + item.Text + "@";
                        switch (item.Tip)
                        {
                            case "T":
                            case "KS":
                            case "CR":
                            case "DP":
                            case "S":
                                _orjinal_sql = _orjinal_sql.Replace(prm, "%%%");
                                break;
                        }

                        break;
                    }

                }
            }
            catch (Exception ex)
            {

            }

            using (FrmRaporGoruntule frm2 = new FrmRaporGoruntule(_orjinal_sql))
            {
                frm2.ShowDialog();
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnListe_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            RaporFiltre ff = gridView1.GetRow(gridView1.FocusedRowHandle) as RaporFiltre;
            FrmListe frm = null;
            if (ff != null)
            {
                switch (ff.Tip)
                {
                    case "KS":
                        frm = new FrmListe(ListeType.Kasa);
                        break;
                    case "CR":
                        frm = new FrmListe(ListeType.Cari);
                        break;
                    case "DP":
                        frm = new FrmListe(ListeType.Depo);
                        break;
                    case "S":
                        frm = new FrmListe(ListeType.Stok);
                        break;
                }
                if (frm != null)
                {
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.FocusedColumn, frm.Tag);
                    }
                }
            }
        }

    }
    public class RaporFiltre
    {
        public string Text { get; set; }
        public object Value { get; set; }
        public string Tip { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            RaporFiltre item = obj as RaporFiltre;
            if (item == null)
                return false;
            if (this.Text == item.Text)
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
