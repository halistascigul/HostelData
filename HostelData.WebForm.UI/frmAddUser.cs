using HostelData.Business.HostelDataBO;
using HostelData.Domain.Entities;
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
    public partial class frmAddUser : Form
    {
        public frmAddUser()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UserBO bo = new UserBO();
            User user = new User();
            user.UserName = txtName.Text;
            if (txtPassword.Text == txtRepeatPassword.Text)
            {
                user.Password = txtPassword.Text;
                if(bo.Insert(user))
                    MessageBox.Show("Yeni Kullanıcı Başarıyla Eklendi");
            }
            else
            {
                MessageBox.Show("Şifreler eşleşmiyor");
            }
           
        }
    }
}
