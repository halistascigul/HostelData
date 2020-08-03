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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserBO bo = new UserBO();
            var reader = bo.GetList();
            foreach (var item in reader)
            {
                if (item.UserName == txtUserName.Text && item.Password == txtUserPassword.Text)
                {
                    frmUserPage page = new frmUserPage();
                    page.Show();
                    this.Hide();
                }
            }
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.txtUserPassword.AutoSize = false;
            this.txtUserPassword.Size = new System.Drawing.Size(350, 50);
        }
    }
}
