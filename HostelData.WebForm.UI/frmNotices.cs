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
    public partial class frmNotices : Form
    {
        public frmNotices()
        {
            InitializeComponent();
        }
        public Notice SelectedNotice { get; set; }
        public int SelectedId { get; set; }

        UserBO bo = new UserBO();

        NoticeBO nbo = new NoticeBO();
        public void dgvViewSetting(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(45, 45, 45);
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv.Columns["UserName"].HeaderText = "Kullanıcı Adı";
            dgv.Columns["NoticeText"].HeaderText = "Duyuru  Notu";
            dgv.Columns["Created"].Visible = false;
            dgv.Columns["Updated"].Visible = false;
            dgv.Columns["IsActive"].Visible = false;
            dgv.Columns["IsDeleted"].Visible = false;
        }
        public void RefreshNotice()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = nbo.GetList().OrderByDescending(x => x.Created).ToList();
            dgvViewSetting(dataGridView1);
        }
        public void Clear()
        {
            cmbUserName.Text = "";
            cmbUserName.Enabled = true;
            txtNotice.Clear();
        }
        private void frmNotices_Load(object sender, EventArgs e)
        {
            var reader = bo.GetUserName();
            foreach (var item in reader)
            {
                cmbUserName.Items.Add(item.UserName);
            }
            RefreshNotice();
            dgvViewSetting(dataGridView1);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbUserName.Text == "")
            {
                cmbUserName.Focus();
                MessageBox.Show("Kullanıcı Adı Boş Bırakılamaz!");
            }
            else if (txtNotice.Text == "")
            {
                txtNotice.Focus();
                MessageBox.Show("Duyuru Kısmı Boş Bırakılamaz!");
            }
            else
            {
                Notice notice = new Notice
                {
                    UserName = cmbUserName.Text,
                    NoticeText = txtNotice.Text,
                };
                if (nbo.Insert(notice))
                    MessageBox.Show("Duyuru başarıyla eklendi");
                RefreshNotice();
                dgvViewSetting(dataGridView1);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Duyuruyu silmek istediğinizden emin misiniz?", "SİL", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                nbo.Delete(SelectedId);
                RefreshNotice();
            }
            dgvViewSetting(dataGridView1);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectedNotice = dataGridView1.Rows[e.RowIndex].DataBoundItem as Notice;
                SelectedId = SelectedNotice.Id;
                cmbUserName.Text = SelectedNotice.UserName;
                txtNotice.Text = SelectedNotice.NoticeText;
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (SelectedNotice == null)
            {
                MessageBox.Show("Hiçbir Duyuruyu seçmediniz");
            }
            else
            {
                SelectedNotice.UserName = cmbUserName.Text;
                SelectedNotice.NoticeText = txtNotice.Text;
                nbo.Update(SelectedNotice);
                RefreshNotice();
            }
            dgvViewSetting(dataGridView1);
        }
    }
}
