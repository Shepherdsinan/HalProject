using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HalYonetim
{
    public partial class FrmUserControl : XtraForm
    {
        public FrmUserControl()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmUserControl_Load);
        }

        void FrmUserControl_Load(object sender, EventArgs e)
        {
            panelControl1.Controls.Add(new FrmDatabaseAyar() { Dock = DockStyle.Fill });
        }
    }
}
