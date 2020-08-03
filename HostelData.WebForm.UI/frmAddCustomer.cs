using HostelData.Business.HostelDataBO;
using HostelData.Core.Model;
using HostelData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HostelData.WebForm.UI
{
    public partial class frmAddCustomer : Form
    {
        public frmAddCustomer()
        {
            InitializeComponent();
        }
        CustomerBO bo = new CustomerBO();
        private void btnSave_Click(object sender, EventArgs e)
        {

            Customer customer = new Customer
            {
                Name = txtName.Text,
                Surname = txtSurname.Text,
                Gender = cmbGender.Text,
                Phone = mskPhone.Text,
                Email = txtEmail.Text,
                IdentityNumber = Convert.ToInt64(txtIdentityNumber.Text),
                RoomNumber = Convert.ToInt32(txtRoomNumber.Text),
                Pay = Convert.ToDecimal(txtPay.Text),
                EntryDate = Convert.ToDateTime(dtpEntryDate.Value),
                ReleaseDate = Convert.ToDateTime(dtpReleaseDate.Value)
            };
            if (bo.Insert(customer))
                MessageBox.Show("Müşteri eklendi");
        }

        private void dtpReleaseDate_ValueChanged(object sender, EventArgs e)
        {
            int pay;
            DateTime entry = Convert.ToDateTime(dtpEntryDate.Text);
            DateTime release = Convert.ToDateTime(dtpReleaseDate.Text);

            TimeSpan difference = release - entry;
            label11.Text = difference.TotalDays.ToString();
            pay = Convert.ToInt32(label11.Text) * 75; //Günlük 75 lira
            txtPay.Text = pay.ToString();
        }

        private void btn101_Click(object sender, EventArgs e)
        {
            txtRoomNumber.Text = ((Button)sender).Text;
        }

        private void frmAddCustomer_Load(object sender, EventArgs e)
        {
            List<Button> rooms = new List<Button> { btn101, btn102, btn103, btn104, btn201, btn202, btn203, btn204, btn301, btn302, btn303, btn304, btn401, btn402, btn403, btn404, btn501, btn502, btn503, btn504 };
            var list = bo.GetListInHostel();
            foreach (var item in list)
            {
                foreach (var room in rooms)
                {
                    if (room.Text == item.RoomNumber.ToString())
                    {
                        room.BackColor = Color.Red;
                        room.Enabled = false;
                    }
                }                
            }
        }

        private void txtIdentityNumber_Validated(object sender, EventArgs e)
        {
            if (txtIdentityNumber.TextLength < 11)
            {
                MessageBox.Show("Eksik TC Numarası girdiniz.");
            }
        }
    }
}
