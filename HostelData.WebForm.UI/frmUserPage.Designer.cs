namespace HostelData.WebForm.UI
{
    partial class frmUserPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hesapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kullanıcıEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noticesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.safeBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bilgiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menüToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.btnUpdatePassword = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnInvoices = new System.Windows.Forms.Button();
            this.btnStockInvoice = new System.Windows.Forms.Button();
            this.btnSafeBox = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnSale = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.exitToolStripMenuItem1.Text = "Çıkış";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // hesapToolStripMenuItem
            // 
            this.hesapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updatePasswordToolStripMenuItem,
            this.kullanıcıEkleToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.hesapToolStripMenuItem.Name = "hesapToolStripMenuItem";
            this.hesapToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.hesapToolStripMenuItem.Text = "Hesap";
            // 
            // updatePasswordToolStripMenuItem
            // 
            this.updatePasswordToolStripMenuItem.Name = "updatePasswordToolStripMenuItem";
            this.updatePasswordToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.updatePasswordToolStripMenuItem.Text = "Şifre Değiştir";
            this.updatePasswordToolStripMenuItem.Click += new System.EventHandler(this.updatePasswordToolStripMenuItem_Click);
            // 
            // kullanıcıEkleToolStripMenuItem
            // 
            this.kullanıcıEkleToolStripMenuItem.Name = "kullanıcıEkleToolStripMenuItem";
            this.kullanıcıEkleToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.kullanıcıEkleToolStripMenuItem.Text = "Kullanıcı Ekle";
            this.kullanıcıEkleToolStripMenuItem.Click += new System.EventHandler(this.kullanıcıEkleToolStripMenuItem_Click);
            // 
            // noticesToolStripMenuItem
            // 
            this.noticesToolStripMenuItem.Name = "noticesToolStripMenuItem";
            this.noticesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.noticesToolStripMenuItem.Text = "Duyurular";
            this.noticesToolStripMenuItem.Click += new System.EventHandler(this.noticesToolStripMenuItem_Click);
            // 
            // safeBoxToolStripMenuItem
            // 
            this.safeBoxToolStripMenuItem.Name = "safeBoxToolStripMenuItem";
            this.safeBoxToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.safeBoxToolStripMenuItem.Text = "Kasa";
            this.safeBoxToolStripMenuItem.Click += new System.EventHandler(this.safeBoxToolStripMenuItem_Click);
            // 
            // stockInvoiceToolStripMenuItem
            // 
            this.stockInvoiceToolStripMenuItem.Name = "stockInvoiceToolStripMenuItem";
            this.stockInvoiceToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.stockInvoiceToolStripMenuItem.Text = "Stok-Fatura";
            this.stockInvoiceToolStripMenuItem.Click += new System.EventHandler(this.stockInvoiceToolStripMenuItem_Click);
            // 
            // bilgiToolStripMenuItem
            // 
            this.bilgiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stockInvoiceToolStripMenuItem,
            this.safeBoxToolStripMenuItem,
            this.noticesToolStripMenuItem});
            this.bilgiToolStripMenuItem.Name = "bilgiToolStripMenuItem";
            this.bilgiToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.bilgiToolStripMenuItem.Text = "Bilgi";
            // 
            // customersToolStripMenuItem
            // 
            this.customersToolStripMenuItem.Name = "customersToolStripMenuItem";
            this.customersToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.customersToolStripMenuItem.Text = "Müşteriler";
            this.customersToolStripMenuItem.Click += new System.EventHandler(this.customersToolStripMenuItem_Click);
            // 
            // addCustomerToolStripMenuItem
            // 
            this.addCustomerToolStripMenuItem.Name = "addCustomerToolStripMenuItem";
            this.addCustomerToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.addCustomerToolStripMenuItem.Text = "Müşteri Ekle";
            this.addCustomerToolStripMenuItem.Click += new System.EventHandler(this.addCustomerToolStripMenuItem_Click);
            // 
            // menüToolStripMenuItem
            // 
            this.menüToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCustomerToolStripMenuItem,
            this.customersToolStripMenuItem});
            this.menüToolStripMenuItem.Name = "menüToolStripMenuItem";
            this.menüToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menüToolStripMenuItem.Text = "Menü";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(418, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(374, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAddCustomer.Location = new System.Drawing.Point(29, 45);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(117, 69);
            this.btnAddCustomer.TabIndex = 27;
            this.btnAddCustomer.TabStop = false;
            this.btnAddCustomer.Text = "Müşteri Ekle";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.addCustomerToolStripMenuItem_Click);
            // 
            // btnUpdatePassword
            // 
            this.btnUpdatePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUpdatePassword.Location = new System.Drawing.Point(31, 277);
            this.btnUpdatePassword.Name = "btnUpdatePassword";
            this.btnUpdatePassword.Size = new System.Drawing.Size(117, 69);
            this.btnUpdatePassword.TabIndex = 24;
            this.btnUpdatePassword.TabStop = false;
            this.btnUpdatePassword.Text = "Şifre Güncelle";
            this.btnUpdatePassword.UseVisualStyleBackColor = true;
            this.btnUpdatePassword.Click += new System.EventHandler(this.updatePasswordToolStripMenuItem_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExit.Location = new System.Drawing.Point(322, 277);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(117, 69);
            this.btnExit.TabIndex = 23;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "Çıkış";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // btnInvoices
            // 
            this.btnInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnInvoices.Location = new System.Drawing.Point(170, 277);
            this.btnInvoices.Name = "btnInvoices";
            this.btnInvoices.Size = new System.Drawing.Size(117, 69);
            this.btnInvoices.TabIndex = 21;
            this.btnInvoices.TabStop = false;
            this.btnInvoices.Text = "Duyurular";
            this.btnInvoices.UseVisualStyleBackColor = true;
            this.btnInvoices.Click += new System.EventHandler(this.noticesToolStripMenuItem_Click);
            // 
            // btnStockInvoice
            // 
            this.btnStockInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStockInvoice.Location = new System.Drawing.Point(29, 163);
            this.btnStockInvoice.Name = "btnStockInvoice";
            this.btnStockInvoice.Size = new System.Drawing.Size(117, 69);
            this.btnStockInvoice.TabIndex = 20;
            this.btnStockInvoice.TabStop = false;
            this.btnStockInvoice.Text = "Stok-Fatura Giderleri";
            this.btnStockInvoice.UseVisualStyleBackColor = true;
            this.btnStockInvoice.Click += new System.EventHandler(this.stockInvoiceToolStripMenuItem_Click);
            // 
            // btnSafeBox
            // 
            this.btnSafeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSafeBox.Location = new System.Drawing.Point(170, 163);
            this.btnSafeBox.Name = "btnSafeBox";
            this.btnSafeBox.Size = new System.Drawing.Size(117, 69);
            this.btnSafeBox.TabIndex = 19;
            this.btnSafeBox.TabStop = false;
            this.btnSafeBox.Text = "Kasa Durumu";
            this.btnSafeBox.UseVisualStyleBackColor = true;
            this.btnSafeBox.Click += new System.EventHandler(this.safeBoxToolStripMenuItem_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCustomers.Location = new System.Drawing.Point(170, 45);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(117, 69);
            this.btnCustomers.TabIndex = 18;
            this.btnCustomers.TabStop = false;
            this.btnCustomers.Text = "Müşteriler";
            this.btnCustomers.UseVisualStyleBackColor = true;
            this.btnCustomers.Click += new System.EventHandler(this.customersToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menüToolStripMenuItem,
            this.bilgiToolStripMenuItem,
            this.hesapToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(628, 24);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnSale
            // 
            this.btnSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSale.Location = new System.Drawing.Point(322, 163);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(117, 69);
            this.btnSale.TabIndex = 19;
            this.btnSale.TabStop = false;
            this.btnSale.Text = "Ürün Satış";
            this.btnSale.UseVisualStyleBackColor = true;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // frmUserPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 380);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.btnUpdatePassword);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnInvoices);
            this.Controls.Add(this.btnStockInvoice);
            this.Controls.Add(this.btnSale);
            this.Controls.Add(this.btnSafeBox);
            this.Controls.Add(this.btnCustomers);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserPage";
            this.Text = "Ana Sayfa";
            this.Load += new System.EventHandler(this.frmUserPage_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hesapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updatePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noticesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem safeBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockInvoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bilgiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menüToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Button btnUpdatePassword;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnInvoices;
        private System.Windows.Forms.Button btnStockInvoice;
        private System.Windows.Forms.Button btnSafeBox;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kullanıcıEkleToolStripMenuItem;
        private System.Windows.Forms.Button btnSale;
    }
}