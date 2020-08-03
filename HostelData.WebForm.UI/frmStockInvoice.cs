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
    public partial class frmStockInvoice : Form
    {
        public frmStockInvoice()
        {
            InitializeComponent();
        }
        public Stock SelectedStock { get; set; }
        public int SelectedStockId { get; set; }
        public Invoice SelectedInvoice { get; set; }
        public int SelectedInvoiceId { get; set; }

        StockBO sbo = new StockBO();

        InvoiceBO ibo = new InvoiceBO();
        public void dgvViewSetting(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 45, 45);
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public void dgvStockRefresh()
        {
            dgvStock.DataSource = null;
            dgvStock.DataSource = sbo.GetList();

            //Aburcubur
            dgvStock.Columns["TotalBeverage"].Visible = false;
            dgvStock.Columns["TotalFood"].Visible = false;
            dgvStock.Columns["Created"].Visible = false;
            dgvStock.Columns["Updated"].Visible = false;
            dgvStock.Columns["IsActive"].Visible = false;
            dgvStock.Columns["IsDeleted"].Visible = false;
            dgvStock.Columns["Cola"].HeaderText = "Kola Faturası";
            dgvStock.Columns["Toast"].HeaderText = "Tost Faturası";
            dgvStock.Columns["Chips"].HeaderText = "Cips Faturası";
            dgvStock.Columns["Hamburger"].HeaderText = "Hamburger Faturası";
            dgvStock.Columns["Fanta"].HeaderText = "Fanta Faturası";
            dgvStock.Columns["Soda"].HeaderText = "Soda Faturası";
        }
        public void dgvInvoiceRefresh()
        {
            dgvInvoice.DataSource = null;
            dgvInvoice.DataSource = ibo.GetList();
            //Faturalar
            dgvInvoice.Columns["TotalElectrical"].Visible = false;
            dgvInvoice.Columns["TotalWater"].Visible = false;
            dgvInvoice.Columns["TotalWarm"].Visible = false;
            dgvInvoice.Columns["TotalInternet"].Visible = false;
            dgvInvoice.Columns["Created"].Visible = false;
            dgvInvoice.Columns["Updated"].Visible = false;
            dgvInvoice.Columns["IsActive"].Visible = false;
            dgvInvoice.Columns["IsDeleted"].Visible = false;
            dgvInvoice.Columns["Electrical"].HeaderText = "Elektrik Faturası";
            dgvInvoice.Columns["Water"].HeaderText = "Su Faturası";
            dgvInvoice.Columns["Warm"].HeaderText = "Doğalgaz Faturası";
            dgvInvoice.Columns["Internet"].HeaderText = "İnternet Faturası";
        }
        public void ClearStockText()
        {
            txtToast.Clear();
            txtHamburger.Clear();
            txtChips.Text = "";
            txtCola.Clear();
            txtFanta.Clear();
            txtSoda.Clear();
            dtpStockDate.Text = "";
        }
        public void ClearInvoiceText()
        {
            txtElectrical.Clear();
            txtWater.Clear();
            txtWarm.Clear();
            txtInternet.Clear();
            dtpStockDate.Text = "";
        }
        private void frmStockInvoice_Load(object sender, EventArgs e)
        {
            dgvStockRefresh();
            dgvInvoiceRefresh();
            dgvViewSetting(dgvStock);
            dgvViewSetting(dgvInvoice);
        }

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectedStock = dgvStock.Rows[e.RowIndex].DataBoundItem as Stock;
                SelectedStockId = SelectedStock.Id;
                txtToast.Text = SelectedStock.Toast.ToString();
                txtHamburger.Text = SelectedStock.Hamburger.ToString();
                txtChips.Text = SelectedStock.Chips.ToString();
                txtCola.Text = SelectedStock.Cola.ToString();
                txtFanta.Text = SelectedStock.Fanta.ToString();
                txtSoda.Text = SelectedStock.Soda.ToString();
                dtpStockDate.Value = SelectedStock.Created;
            }
        }

        private void dgvInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectedInvoice = dgvInvoice.Rows[e.RowIndex].DataBoundItem as Invoice;
                SelectedInvoiceId = SelectedInvoice.Id;
                txtElectrical.Text = SelectedInvoice.Electrical.ToString();
                txtWater.Text = SelectedInvoice.Water.ToString();
                txtWarm.Text = SelectedInvoice.Warm.ToString();
                txtInternet.Text = SelectedInvoice.Internet.ToString();
                dtpInvoiceDate.Value = SelectedInvoice.Created;
            }
        }

        private void btnStockUpdate_Click(object sender, EventArgs e)
        {
            var stock = sbo.GetById(SelectedStockId);
            if (stock.Id > 0)
            {
                stock.Toast = Convert.ToInt32(txtToast.Text);
                stock.Hamburger = Convert.ToInt32(txtHamburger.Text);
                stock.Chips = Convert.ToInt32(txtChips.Text);
                stock.Cola = Convert.ToInt32(txtCola.Text);
                stock.Fanta = Convert.ToInt32(txtFanta.Text);
                stock.Soda = Convert.ToInt32(txtSoda.Text);
                if (sbo.Update(stock))
                    MessageBox.Show("Güncelleme Başarılı");

                dgvStockRefresh();
            }
            else
            {
                MessageBox.Show("Öncelikle aşağıdan güncellenecek bir kayıt seçiniz");
            }

        }

        private void txtStockClear_Click(object sender, EventArgs e)
        {
            ClearStockText();
        }

        private void txtInvoiceClear_Click(object sender, EventArgs e)
        {
            ClearInvoiceText();
        }

        private void btnStockSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtChips.Text) && String.IsNullOrEmpty(txtToast.Text) && String.IsNullOrEmpty(txtHamburger.Text) && String.IsNullOrEmpty(txtCola.Text) && String.IsNullOrEmpty(txtFanta.Text) && String.IsNullOrEmpty(txtSoda.Text))
            {
                MessageBox.Show("Kayıt giriniz");
            }
            else
            {
                Stock stock = new Stock();
                stock.Toast = Convert.ToInt32(txtToast.Text);
                stock.Hamburger = Convert.ToInt32(txtHamburger.Text);
                stock.Chips = Convert.ToInt32(txtChips.Text);
                stock.Cola = Convert.ToInt32(txtCola.Text);
                stock.Fanta = Convert.ToInt32(txtFanta.Text);
                stock.Soda = Convert.ToInt32(txtSoda.Text);
                stock.Created = dtpStockDate.Value;
                if (sbo.Insert(stock))
                    MessageBox.Show("Kayıt Başarılı");

                dgvStockRefresh();
            }
        }

        private void btnStockPay_Click(object sender, EventArgs e)
        {
            if (sbo.Delete(SelectedStockId))
                MessageBox.Show("Ödendi olarak işaretlendi");
            else
                MessageBox.Show("Öncelikle bir kayıt seçiniz");

            dgvStockRefresh();
        }

        private void btnStockPay_MouseHover(object sender, EventArgs e)
        {
            ToolTip exp = new ToolTip();
            exp.SetToolTip(btnStockPay, "Ödemek istediğiniz faturayı öncelikle aşağıdaki ekrandan seçmeniz gerekmektedir!!!");
        }

        private void btnInvoiceUpdate_Click(object sender, EventArgs e)
        {
            var invoice = ibo.GetById(SelectedInvoiceId);
            if (invoice.Id > 0)
            {
                invoice.Electrical = Convert.ToDecimal(txtElectrical.Text);
                invoice.Water = Convert.ToDecimal(txtWater.Text);
                invoice.Warm = Convert.ToDecimal(txtWarm.Text);
                invoice.Internet = Convert.ToDecimal(txtInternet.Text);
                if (ibo.Update(invoice))
                    MessageBox.Show("Güncelleme Başarılı");

                dgvInvoiceRefresh();
            }
            else
            {
                MessageBox.Show("Öncelikle aşağıdan güncellenecek bir kayıt seçiniz");
            }
        }

        private void txtInvoiceSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtElectrical.Text) && String.IsNullOrEmpty(txtWater.Text) && String.IsNullOrEmpty(txtWarm.Text) && String.IsNullOrEmpty(txtInternet.Text))
            {
                MessageBox.Show("Kayıt giriniz");
            }
            else
            {
                Invoice invoice = new Invoice();
                invoice.Electrical = Convert.ToDecimal(txtElectrical.Text);
                invoice.Water = Convert.ToDecimal(txtWater.Text);
                invoice.Warm = Convert.ToDecimal(txtWarm.Text);
                invoice.Internet = Convert.ToDecimal(txtInternet.Text);
                invoice.Created = dtpInvoiceDate.Value;
                if (ibo.Insert(invoice))
                    MessageBox.Show("Kayıt Başarılı");

                dgvInvoiceRefresh();
            }

        }

        private void btnInvoicePay_Click(object sender, EventArgs e)
        {
            if (ibo.Delete(SelectedInvoiceId))
                MessageBox.Show("Ödendi olarak işaretlendi");
            else
                MessageBox.Show("Öncelikle bir kayıt seçiniz");

            dgvInvoiceRefresh();
        }
    }
}
