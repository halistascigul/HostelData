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
    public partial class frmUserPage : Form
    {
        public frmUserPage()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void frmUserPage_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddCustomer frm = new frmAddCustomer();
            frm.Show();
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomers frm = new frmCustomers();
            frm.Show();
        }

        private void stockInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockInvoice si = new frmStockInvoice();
            si.Show();
        }

        private void safeBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSafeBox safeBox = new frmSafeBox();
            safeBox.Show();
        }

        private void noticesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNotices notices = new frmNotices();
            notices.Show();
        }

        private void updatePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdatePassword password = new frmUpdatePassword();
            password.Show();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "Çıkış", MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                frmMainPage login = new frmMainPage();
                this.Close();
                login.Show();
            }
        }

        private void kullanıcıEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUser frm = new frmAddUser();
            frm.Show();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            frmProductSale frm = new frmProductSale();
            frm.Show();
        }
    }
}
