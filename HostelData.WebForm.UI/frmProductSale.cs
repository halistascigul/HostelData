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
    public partial class frmProductSale : Form
    {
        public frmProductSale()
        {
            InitializeComponent();
        }

        private void frmProductSale_Load(object sender, EventArgs e)
        {
            RoomBO rbo = new RoomBO();
            var roomList = rbo.GetList();
            foreach (var item in roomList)
            {
                cmbRoomNumber.Items.Add(item.RoomNumber);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CustomerBO cbo = new CustomerBO();
            float totalAmount;
            float productPrice;
            switch (cmbProductName.Text)
            {
                case "Tost":
                    productPrice = 5; // birim fiyatı 5 tl
                    totalAmount = productPrice * (Convert.ToInt16(txtProductQuantity.Text));
                    txtTotalAmount.Text = totalAmount.ToString() + " " + "TL";
                    break;
                case "Hamburger":
                    productPrice = 7.5f; // birim fiyatı 7,5 tl
                    totalAmount = productPrice * (Convert.ToInt16(txtProductQuantity.Text));
                    txtTotalAmount.Text = totalAmount.ToString() + " " + "TL";
                    break;
                case "Cips":
                    productPrice = 6;// birim fiyatı 6 tl
                    totalAmount = productPrice * (Convert.ToInt16(txtProductQuantity.Text));
                    txtTotalAmount.Text = totalAmount.ToString() + " " + "TL";
                    break;
                case "Kola":
                    productPrice = 5;// birim fiyatı 5 tl
                    totalAmount = productPrice * (Convert.ToInt16(txtProductQuantity.Text));
                    txtTotalAmount.Text = totalAmount.ToString() + " " + "TL";
                    break;
                case "Fanta":
                    productPrice = 5;// birim fiyatı 5 tl
                    totalAmount = productPrice * (Convert.ToInt16(txtProductQuantity.Text));
                    txtTotalAmount.Text = totalAmount.ToString() + " " + "TL";
                    break;
                case "Soda":
                    productPrice = 4;// birim fiyatı 4 tl
                    totalAmount = productPrice * (Convert.ToInt16(txtProductQuantity.Text));
                    txtTotalAmount.Text = totalAmount.ToString() + " " + "TL";
                    break;
            }
            var customer = cbo.GetByRoomNumber(Convert.ToInt32(cmbRoomNumber.Text));
            switch (cmbProductName.Text)
            {
                case "Tost":
                    customer.SoldToast = Convert.ToByte(txtProductQuantity.Text);
                    break;
                case "Hamburger":
                    customer.SoldHamburger = Convert.ToByte(txtProductQuantity.Text);
                    break;
                case "Cips":
                    customer.SoldChips = Convert.ToByte(txtProductQuantity.Text);
                    break;
                case "Kola":
                    customer.SoldCola = Convert.ToByte(txtProductQuantity.Text);
                    break;
                case "Fanta":
                    customer.SoldFanta = Convert.ToByte(txtProductQuantity.Text);
                    break;
                case "Soda":
                    customer.SoldSoda = Convert.ToByte(txtProductQuantity.Text);
                    break;
            }

            if (cbo.AddProduct(customer))
            {
                MessageBox.Show("Ürün satışı başarılı");
            }
            else
                MessageBox.Show("Bu odada müşteri yok");
        }

        CustomerBO cbo = new CustomerBO();
        private void cmbRoomNumber_SelectedIndexChanged(object sender, EventArgs e)//TODO: BUNU YAP SANA HELAL HALİS :)
        {
            lvProducts.Items.Clear();
            var product = cbo.GetProductsOfCustomer(Convert.ToInt32(cmbRoomNumber.Text));

            lvProducts.Items.Add(product.Id.ToString());
            lvProducts.Items[0].SubItems.Add(product.SoldToast.ToString());
            lvProducts.Items[0].SubItems.Add(product.SoldHamburger.ToString());
            lvProducts.Items[0].SubItems.Add(product.SoldChips.ToString());
            lvProducts.Items[0].SubItems.Add(product.SoldCola.ToString());
            lvProducts.Items[0].SubItems.Add(product.SoldFanta.ToString());
            lvProducts.Items[0].SubItems.Add(product.SoldSoda.ToString());
        }
    }
}
