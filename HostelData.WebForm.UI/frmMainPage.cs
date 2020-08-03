using HostelData.Business.HostelDataBO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostelData.WebForm.UI
{
    public partial class frmMainPage : Form
    {
        public frmMainPage()
        {
            InitializeComponent();
        }
        private void girişToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
                Application.Exit();
        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsAbout about = new frmUsAbout();
            about.Show();
        }

        private void frmMainPage_Load(object sender, EventArgs e)
        {
            NoticeBO bo = new NoticeBO();
            rtbLastNotice.Text = bo.GetLastNotice();
            if (String.IsNullOrEmpty(rtbLastNotice.Text))
            {
                rtbLastNotice.Visible = false;
                label1.Visible = false;
            }
        }
    }
}
