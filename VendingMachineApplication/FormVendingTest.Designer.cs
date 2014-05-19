namespace VendingMachineApplication
{
    partial class FormVendingTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVendingTest));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.buttonRandomize = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.product7 = new VendingMachineApplication.Product();
            this.product6 = new VendingMachineApplication.Product();
            this.product5 = new VendingMachineApplication.Product();
            this.product4 = new VendingMachineApplication.Product();
            this.product3 = new VendingMachineApplication.Product();
            this.product2 = new VendingMachineApplication.Product();
            this.product1 = new VendingMachineApplication.Product();
            this.cell1 = new VendingMachineApplication.Devices.Cell(this.components);
            this.buttonInsert10 = new System.Windows.Forms.Button();
            this.buttonInsert50 = new System.Windows.Forms.Button();
            this.buttonInsert100 = new System.Windows.Forms.Button();
            this.buttonInsert500 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.acceptor1 = new VendingMachineApplication.Acceptor();
            this.myPanel1 = new VendingMachineApplication.InputPanel();
            this.display = new VendingMachineApplication.Display();
            this.coinKeeper1 = new VendingMachineApplication.CoinKeeper();
            this.vendingMachine1 = new VendingMachineApplication.VendingMachine();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.product7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.product6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.product5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.product4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.product3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.product2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.product1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cell1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acceptor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.display)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coinKeeper1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendingMachine1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // buttonRandomize
            // 
            this.buttonRandomize.Location = new System.Drawing.Point(6, 125);
            this.buttonRandomize.Name = "buttonRandomize";
            this.buttonRandomize.Size = new System.Drawing.Size(164, 25);
            this.buttonRandomize.TabIndex = 9;
            this.buttonRandomize.Text = "Загрузить автомат";
            this.buttonRandomize.UseVisualStyleBackColor = true;
            this.buttonRandomize.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.product7);
            this.panel1.Controls.Add(this.product6);
            this.panel1.Controls.Add(this.product5);
            this.panel1.Controls.Add(this.product4);
            this.panel1.Controls.Add(this.product3);
            this.panel1.Controls.Add(this.product2);
            this.panel1.Controls.Add(this.product1);
            this.panel1.Controls.Add(this.cell1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 646);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(691, 84);
            this.panel1.TabIndex = 10;
            this.panel1.Visible = false;
            // 
            // product7
            // 
            this.product7.BackColor = System.Drawing.Color.Transparent;
            this.product7.Image = ((System.Drawing.Image)(resources.GetObject("product7.Image")));
            this.product7.ImagePack = global::VendingMachineApplication.Properties.Resources.can7;
            this.product7.Location = new System.Drawing.Point(235, 12);
            this.product7.Name = "product7";
            this.product7.Scale = 1F;
            this.product7.Size = new System.Drawing.Size(31, 57);
            this.product7.TabIndex = 14;
            this.product7.TabStop = false;
            // 
            // product6
            // 
            this.product6.BackColor = System.Drawing.Color.Transparent;
            this.product6.Image = ((System.Drawing.Image)(resources.GetObject("product6.Image")));
            this.product6.ImagePack = global::VendingMachineApplication.Properties.Resources.can6;
            this.product6.Location = new System.Drawing.Point(199, 12);
            this.product6.Name = "product6";
            this.product6.Scale = 1F;
            this.product6.Size = new System.Drawing.Size(30, 59);
            this.product6.TabIndex = 13;
            this.product6.TabStop = false;
            // 
            // product5
            // 
            this.product5.BackColor = System.Drawing.Color.Transparent;
            this.product5.Image = ((System.Drawing.Image)(resources.GetObject("product5.Image")));
            this.product5.ImagePack = global::VendingMachineApplication.Properties.Resources.can5;
            this.product5.Location = new System.Drawing.Point(162, 12);
            this.product5.Name = "product5";
            this.product5.Scale = 1F;
            this.product5.Size = new System.Drawing.Size(31, 57);
            this.product5.TabIndex = 12;
            this.product5.TabStop = false;
            // 
            // product4
            // 
            this.product4.BackColor = System.Drawing.Color.Transparent;
            this.product4.Image = ((System.Drawing.Image)(resources.GetObject("product4.Image")));
            this.product4.ImagePack = global::VendingMachineApplication.Properties.Resources.can41;
            this.product4.Location = new System.Drawing.Point(125, 12);
            this.product4.Name = "product4";
            this.product4.Scale = 1F;
            this.product4.Size = new System.Drawing.Size(31, 57);
            this.product4.TabIndex = 11;
            this.product4.TabStop = false;
            // 
            // product3
            // 
            this.product3.BackColor = System.Drawing.Color.Transparent;
            this.product3.Image = ((System.Drawing.Image)(resources.GetObject("product3.Image")));
            this.product3.ImagePack = global::VendingMachineApplication.Properties.Resources.can3;
            this.product3.Location = new System.Drawing.Point(88, 12);
            this.product3.Name = "product3";
            this.product3.Scale = 1F;
            this.product3.Size = new System.Drawing.Size(31, 57);
            this.product3.TabIndex = 10;
            this.product3.TabStop = false;
            // 
            // product2
            // 
            this.product2.BackColor = System.Drawing.Color.Transparent;
            this.product2.Image = ((System.Drawing.Image)(resources.GetObject("product2.Image")));
            this.product2.ImagePack = global::VendingMachineApplication.Properties.Resources.can2;
            this.product2.Location = new System.Drawing.Point(49, 12);
            this.product2.Name = "product2";
            this.product2.Scale = 1F;
            this.product2.Size = new System.Drawing.Size(33, 57);
            this.product2.TabIndex = 9;
            this.product2.TabStop = false;
            // 
            // product1
            // 
            this.product1.BackColor = System.Drawing.Color.Transparent;
            this.product1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.product1.Image = ((System.Drawing.Image)(resources.GetObject("product1.Image")));
            this.product1.ImagePack = global::VendingMachineApplication.Properties.Resources.Product11;
            this.product1.Location = new System.Drawing.Point(12, 12);
            this.product1.Name = "product1";
            this.product1.Scale = 1F;
            this.product1.Size = new System.Drawing.Size(31, 57);
            this.product1.TabIndex = 8;
            this.product1.TabStop = false;
            this.product1.Visible = false;
            // 
            // cell1
            // 
            this.cell1.BackColor = System.Drawing.Color.Transparent;
            this.cell1.CellNumber = 0;
            this.cell1.Image = ((System.Drawing.Image)(resources.GetObject("cell1.Image")));
            this.cell1.ImagePack = global::VendingMachineApplication.Properties.Resources.small_wall;
            this.cell1.Location = new System.Drawing.Point(650, 0);
            this.cell1.Name = "cell1";
            this.cell1.Product = null;
            this.cell1.ProductPrice = ((uint)(1u));
            this.cell1.Scale = 1F;
            this.cell1.Size = new System.Drawing.Size(29, 82);
            this.cell1.TabIndex = 4;
            this.cell1.TabStop = false;
            this.cell1.Visible = false;
            // 
            // buttonInsert10
            // 
            this.buttonInsert10.Location = new System.Drawing.Point(6, 19);
            this.buttonInsert10.Name = "buttonInsert10";
            this.buttonInsert10.Size = new System.Drawing.Size(80, 47);
            this.buttonInsert10.TabIndex = 11;
            this.buttonInsert10.Text = "Пополнить баланс на 10 рублей";
            this.buttonInsert10.UseVisualStyleBackColor = true;
            this.buttonInsert10.Click += new System.EventHandler(this.buttonInsertBanknoteClick);
            // 
            // buttonInsert50
            // 
            this.buttonInsert50.Location = new System.Drawing.Point(92, 19);
            this.buttonInsert50.Name = "buttonInsert50";
            this.buttonInsert50.Size = new System.Drawing.Size(78, 47);
            this.buttonInsert50.TabIndex = 12;
            this.buttonInsert50.Text = "Пополнить баланс на 50 рублей";
            this.buttonInsert50.UseVisualStyleBackColor = true;
            this.buttonInsert50.Click += new System.EventHandler(this.buttonInsertBanknoteClick);
            // 
            // buttonInsert100
            // 
            this.buttonInsert100.Location = new System.Drawing.Point(6, 72);
            this.buttonInsert100.Name = "buttonInsert100";
            this.buttonInsert100.Size = new System.Drawing.Size(80, 47);
            this.buttonInsert100.TabIndex = 13;
            this.buttonInsert100.Text = "Пополнить баланс на 100 рублей";
            this.buttonInsert100.UseVisualStyleBackColor = true;
            this.buttonInsert100.Click += new System.EventHandler(this.buttonInsertBanknoteClick);
            // 
            // buttonInsert500
            // 
            this.buttonInsert500.Location = new System.Drawing.Point(95, 72);
            this.buttonInsert500.Name = "buttonInsert500";
            this.buttonInsert500.Size = new System.Drawing.Size(75, 47);
            this.buttonInsert500.TabIndex = 14;
            this.buttonInsert500.Text = "Пополнить баланс на 500 рублей";
            this.buttonInsert500.UseVisualStyleBackColor = true;
            this.buttonInsert500.Click += new System.EventHandler(this.buttonInsertBanknoteClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonInsert10);
            this.groupBox1.Controls.Add(this.buttonInsert500);
            this.groupBox1.Controls.Add(this.buttonRandomize);
            this.groupBox1.Controls.Add(this.buttonInsert100);
            this.groupBox1.Controls.Add(this.buttonInsert50);
            this.groupBox1.Location = new System.Drawing.Point(493, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 161);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Действия пользователя";
            // 
            // acceptor1
            // 
            this.acceptor1.BackColor = System.Drawing.Color.Transparent;
            this.acceptor1.Image = ((System.Drawing.Image)(resources.GetObject("acceptor1.Image")));
            this.acceptor1.ImagePack = global::VendingMachineApplication.Properties.Resources.acceptor2;
            this.acceptor1.Location = new System.Drawing.Point(508, 401);
            this.acceptor1.Name = "acceptor1";
            this.acceptor1.Scale = 1F;
            this.acceptor1.Size = new System.Drawing.Size(62, 64);
            this.acceptor1.TabIndex = 7;
            this.acceptor1.TabStop = false;
            // 
            // myPanel1
            // 
            this.myPanel1.Location = new System.Drawing.Point(510, 266);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.PanelScale = 1D;
            this.myPanel1.Size = new System.Drawing.Size(60, 118);
            this.myPanel1.TabIndex = 6;
            // 
            // display
            // 
            this.display.BackColor = System.Drawing.Color.Transparent;
            this.display.Image = ((System.Drawing.Image)(resources.GetObject("display.Image")));
            this.display.ImagePack = global::VendingMachineApplication.Properties.Resources.display;
            this.display.InputInfo = "";
            this.display.Location = new System.Drawing.Point(414, 172);
            this.display.Name = "display";
            this.display.Scale = 1F;
            this.display.Size = new System.Drawing.Size(156, 88);
            this.display.TabIndex = 3;
            this.display.TabStop = false;
            // 
            // coinKeeper1
            // 
            this.coinKeeper1.BackColor = System.Drawing.Color.Transparent;
            this.coinKeeper1.Image = ((System.Drawing.Image)(resources.GetObject("coinKeeper1.Image")));
            this.coinKeeper1.ImagePack = global::VendingMachineApplication.Properties.Resources.coin_keeper1;
            this.coinKeeper1.Location = new System.Drawing.Point(523, 486);
            this.coinKeeper1.Name = "coinKeeper1";
            this.coinKeeper1.Scale = 1F;
            this.coinKeeper1.Size = new System.Drawing.Size(47, 36);
            this.coinKeeper1.TabIndex = 1;
            this.coinKeeper1.TabStop = false;
            // 
            // vendingMachine1
            // 
            this.vendingMachine1.Acceptor = this.acceptor1;
            this.vendingMachine1.BackColor = System.Drawing.Color.Transparent;
            this.vendingMachine1.Cell = this.cell1;
            this.vendingMachine1.CoinKeeper = this.coinKeeper1;
            this.vendingMachine1.Display = this.display;
            this.vendingMachine1.Image = ((System.Drawing.Image)(resources.GetObject("vendingMachine1.Image")));
            this.vendingMachine1.ImagePack = global::VendingMachineApplication.Properties.Resources.box2;
            this.vendingMachine1.Location = new System.Drawing.Point(12, 12);
            this.vendingMachine1.Name = "vendingMachine1";
            this.vendingMachine1.Panel = this.myPanel1;
            this.vendingMachine1.Scale = 1F;
            this.vendingMachine1.Size = new System.Drawing.Size(576, 709);
            this.vendingMachine1.TabIndex = 2;
            this.vendingMachine1.TabStop = false;
            this.vendingMachine1.VendingState = VendingMachineApplication.VendingMachine.State.SCellRequest;
            this.vendingMachine1.ProductRemoveRequest += new VendingMachineApplication.VendingMachine.ProductManagementEventHandler(this.vendingMachine1_ProductRemoveRequest);
            this.vendingMachine1.ProductFallRequest += new VendingMachineApplication.VendingMachine.ProductManagementEventHandler(this.vendingMachine1_ProductFallRequest);
            this.vendingMachine1.SizeChanged += new System.EventHandler(this.vendingMachine1_SizeChanged);
            // 
            // FormVendingTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 730);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.acceptor1);
            this.Controls.Add(this.myPanel1);
            this.Controls.Add(this.display);
            this.Controls.Add(this.coinKeeper1);
            this.Controls.Add(this.vendingMachine1);
            this.Name = "FormVendingTest";
            this.Text = "FormVendingTest";
            this.Load += new System.EventHandler(this.FormVendingTest_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.product7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.product6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.product5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.product4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.product3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.product2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.product1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cell1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acceptor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.display)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coinKeeper1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendingMachine1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CoinKeeper coinKeeper1;
        private VendingMachine vendingMachine1;
        private Display display;
        private Devices.Cell cell1;
        private InputPanel myPanel1;
        private Acceptor acceptor1;
        private System.Windows.Forms.Timer timer;
        private Product product1;
        private System.Windows.Forms.Button buttonRandomize;
        private System.Windows.Forms.Panel panel1;
        private Product product2;
        private Product product3;
        private Product product4;
        private Product product5;
        private Product product6;
        private Product product7;
        private System.Windows.Forms.Button buttonInsert10;
        private System.Windows.Forms.Button buttonInsert50;
        private System.Windows.Forms.Button buttonInsert100;
        private System.Windows.Forms.Button buttonInsert500;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}