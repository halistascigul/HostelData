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
    public partial class frmUpdatePassword : Form
    {
        public frmUpdatePassword()
        {
            InitializeComponent();
        }

        UserBO bo = new UserBO();
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var model = bo.GetByUserName(txtUserName.Text);
                if (model.Password == txtOldPassword.Text)
                {
                    model.UserName = txtUserName.Text;
                    model.Password = txtNewPassword.Text;
                    if (bo.Update(model))
                        MessageBox.Show("Güncelleme Başarılı");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Güncellemede Beklenmedik Bir Hata Oluştu");
            }

        }
    }
}
