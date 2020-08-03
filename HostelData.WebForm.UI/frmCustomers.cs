using HostelData.Business.HostelDataBO;
using HostelData.Core.Model;
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
    public partial class frmCustomers : Form
    {
        public frmCustomers()
        {
            InitializeComponent();
        }
        public Customer SelectedCustomer { get; set; }
        public int SelectedId { get; set; }

        CustomerBO bo = new CustomerBO();
        public void RefreshCustomers()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bo.GetList();
        }

        public void RefreshText()
        {
            txtName.Clear();
            txtSurname.Clear();
            cmbGender.Text = "";
            mskPhone.Clear();
            txtEmail.Clear();
            txtIdentityNumber.Clear();
            txtRoomNumber.Clear();
            txtPay.Clear();
            dtpEntryDate.Text = "";
            dtpReleaseDate.Text = "";
            txtSearch.Clear();
        }

        public void dgvViewSetting(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 45, 45);
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv.Columns["Name"].HeaderText = "Adı";
            dgv.Columns["Surname"].HeaderText = "Soyadı";
            dgv.Columns["Gender"].HeaderText = "Cinsiyet";
            dgv.Columns["Phone"].HeaderText = "Telefon No";
            dgv.Columns["Email"].HeaderText = "Mail";
            dgv.Columns["IdentityNumber"].HeaderText = "TC Kimlik No";
            dgv.Columns["RoomNumber"].HeaderText = "Oda No";
            dgv.Columns["Pay"].HeaderText = "Oda Ücreti";
            dgv.Columns["EntryDate"].HeaderText = "Giriş Tarihi";
            dgv.Columns["ReleaseDate"].HeaderText = "Çıkış Tarihi";
            dgv.Columns["SoldToast"].HeaderText = "Tost Ad.";
            dgv.Columns["SoldHamburger"].HeaderText = "Hamburger Ad.";
            dgv.Columns["SoldChips"].HeaderText = "Cips Ad.";
            dgv.Columns["SoldCola"].HeaderText = "Kola Ad.";
            dgv.Columns["SoldFanta"].HeaderText = "Fanta Ad.";
            dgv.Columns["SoldSoda"].HeaderText = "Soda Ad.";
            dgv.Columns["TotalAmount"].HeaderText = "AburCubur Toplam Fiyat";
            dgv.Columns["TotalPay"].Visible = false;
            dgv.Columns["Created"].Visible = false;
            dgv.Columns["Updated"].Visible = false;
            dgv.Columns["IsActive"].Visible = false;
            dgv.Columns["IsDeleted"].Visible = false;
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            RefreshCustomers();
            dgvViewSetting(dataGridView1);
            lblOldRecords.Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectedCustomer = dataGridView1.Rows[e.RowIndex].DataBoundItem as Customer;
                SelectedId = SelectedCustomer.Id;
                txtName.Text = SelectedCustomer.Name;
                txtSurname.Text = SelectedCustomer.Surname;
                cmbGender.Text = SelectedCustomer.Gender;
                mskPhone.Text = SelectedCustomer.Phone;
                txtEmail.Text = SelectedCustomer.Email;
                txtIdentityNumber.Text = SelectedCustomer.IdentityNumber.ToString();
                txtRoomNumber.Text = SelectedCustomer.RoomNumber.ToString();
                txtPay.Text = (SelectedCustomer.Pay + SelectedCustomer.TotalAmount).ToString();
                dtpEntryDate.Value = SelectedCustomer.EntryDate;
                dtpReleaseDate.Value = SelectedCustomer.ReleaseDate;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshText();
            RefreshCustomers();
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnClear.Enabled = true;
            lblOldRecords.Visible = false;
            dgvViewSetting(dataGridView1);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (SelectedId > 0)
            {
                var customer = bo.GetById(SelectedId);
                customer.Name = txtName.Text;
                customer.Surname = txtSurname.Text;
                customer.Gender = cmbGender.Text;
                customer.Phone = mskPhone.Text;
                customer.Email = txtEmail.Text;
                customer.IdentityNumber = Convert.ToInt64(txtIdentityNumber.Text);
                customer.RoomNumber = Convert.ToInt32(txtRoomNumber.Text);
                customer.Pay = Convert.ToDecimal(txtPay.Text);
                customer.EntryDate = dtpEntryDate.Value;
                customer.ReleaseDate = dtpReleaseDate.Value;
                bo.Update(customer);
                RefreshCustomers();
            }
            dgvViewSetting(dataGridView1);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Müşterinin kaydını silmek istediğinizden emin misiniz?", "SİL", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                bo.Delete(SelectedId);
                MessageBox.Show("Müşteri silindi");
            }
            RefreshCustomers();
            dgvViewSetting(dataGridView1);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            RefreshText();
            dgvViewSetting(dataGridView1);
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            RefreshText();
            dataGridView1.DataSource = bo.GetCustomersArchive();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnClear.Enabled = false;
            lblOldRecords.Visible = true;
            dgvViewSetting(dataGridView1);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bo.GetList().Where(x => x.Name.Contains(txtSearch.Text)).ToList();
            dgvViewSetting(dataGridView1);
        }
    }
}
