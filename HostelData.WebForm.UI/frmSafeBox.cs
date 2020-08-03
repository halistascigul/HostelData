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
    public partial class frmSafeBox : Form
    {
        public frmSafeBox()
        {
            InitializeComponent();
        }
        InvoiceBO bo = new InvoiceBO();

        StockBO sbo = new StockBO();

        CustomerBO cbo = new CustomerBO();
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int staff = Convert.ToInt16(txtAmountStaff.Text);
            decimal pay = Convert.ToDecimal(txtPay.Text);
            lblPayStaff.Text = (staff * pay).ToString();

            decimal result = Convert.ToDecimal(lblSafeBoxTotal.Text) - (Convert.ToDecimal(lblPayStaff.Text) + Convert.ToDecimal(lblFood.Text) + Convert.ToDecimal(lblBeverage.Text) + Convert.ToDecimal(lblElectric.Text) + Convert.ToDecimal(lblWater.Text) + Convert.ToDecimal(lblWarm.Text) + Convert.ToDecimal(lblInternet.Text));
            if (result < 0)
            {
                lblResult.ForeColor = Color.Red;
            }
            else
            {
                lblResult.ForeColor = Color.Green;
            }
            lblResult.Text = result.ToString();
        }

        private void frmSafeBox_Load(object sender, EventArgs e)
        {
            lblFood.Text = sbo.TotalFood().ToString();
            lblBeverage.Text = sbo.TotalBeverage().ToString();
            lblElectric.Text = bo.TotalElectrical().ToString();
            lblWater.Text = bo.TotalWater().ToString();
            lblWarm.Text = bo.TotalWater().ToString();
            lblInternet.Text = bo.TotalInternet().ToString();
            lblSafeBoxTotal.Text = (cbo.TotalPay() - sbo.TotalPaidFood() - sbo.TotalPaidBeverage() - bo.TotalPaidElectrical() - bo.TotalPaidWater() - bo.TotalPaidWarm() - bo.TotalPaidInternet()+cbo.TotalAmount()).ToString();
        }
    }
}
