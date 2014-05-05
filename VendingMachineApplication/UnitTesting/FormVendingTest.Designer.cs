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
            this.button1 = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.product1 = new VendingMachineApplication.Product();
            this.acceptor1 = new VendingMachineApplication.Acceptor();
            this.myPanel1 = new VendingMachineApplication.MyPanel();
            this.cell1 = new VendingMachineApplication.Devices.Cell(this.components);
            this.display = new VendingMachineApplication.Display();
            this.coinKeeper1 = new VendingMachineApplication.CoinKeeper();
            this.vendingMachine1 = new VendingMachineApplication.VendingMachine();
            ((System.ComponentModel.ISupportInitialize)(this.product1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acceptor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cell1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.display)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coinKeeper1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendingMachine1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(604, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // product1
            // 
            this.product1.BackColor = System.Drawing.Color.Transparent;
            this.product1.Image = ((System.Drawing.Image)(resources.GetObject("product1.Image")));
            this.product1.ImagePack = global::VendingMachineApplication.Properties.Resources.can1;
            this.product1.Location = new System.Drawing.Point(604, 152);
            this.product1.Name = "product1";
            this.product1.Scale = 1F;
            this.product1.Size = new System.Drawing.Size(31, 57);
            this.product1.TabIndex = 8;
            this.product1.TabStop = false;
            // 
            // acceptor1
            // 
            this.acceptor1.BackColor = System.Drawing.Color.Transparent;
            this.acceptor1.Image = ((System.Drawing.Image)(resources.GetObject("acceptor1.Image")));
            this.acceptor1.ImagePack = global::VendingMachineApplication.Properties.Resources.acceptor;
            this.acceptor1.Location = new System.Drawing.Point(508, 401);
            this.acceptor1.Name = "acceptor1";
            this.acceptor1.Scale = 1F;
            this.acceptor1.Size = new System.Drawing.Size(62, 65);
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
            // cell1
            // 
            this.cell1.BackColor = System.Drawing.Color.Transparent;
            this.cell1.Image = ((System.Drawing.Image)(resources.GetObject("cell1.Image")));
            this.cell1.ImagePack = global::VendingMachineApplication.Properties.Resources.small_wall;
            this.cell1.Location = new System.Drawing.Point(604, 64);
            this.cell1.Name = "cell1";
            this.cell1.Product = null;
            this.cell1.ProductPrice = ((uint)(0u));
            this.cell1.Scale = 1F;
            this.cell1.Size = new System.Drawing.Size(29, 82);
            this.cell1.TabIndex = 4;
            this.cell1.TabStop = false;
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
            this.coinKeeper1.ImagePack = global::VendingMachineApplication.Properties.Resources.coin_keeper;
            this.coinKeeper1.Location = new System.Drawing.Point(523, 486);
            this.coinKeeper1.Name = "coinKeeper1";
            this.coinKeeper1.Scale = 1F;
            this.coinKeeper1.Size = new System.Drawing.Size(47, 37);
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
            this.vendingMachine1.ImagePack = global::VendingMachineApplication.Properties.Resources.box;
            this.vendingMachine1.Location = new System.Drawing.Point(12, 12);
            this.vendingMachine1.Name = "vendingMachine1";
            this.vendingMachine1.Panel = this.myPanel1;
            this.vendingMachine1.Scale = 1F;
            this.vendingMachine1.Size = new System.Drawing.Size(576, 709);
            this.vendingMachine1.TabIndex = 2;
            this.vendingMachine1.TabStop = false;
            this.vendingMachine1.SizeChanged += new System.EventHandler(this.vendingMachine1_SizeChanged);
            // 
            // FormVendingTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(691, 730);
            this.Controls.Add(this.product1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.acceptor1);
            this.Controls.Add(this.myPanel1);
            this.Controls.Add(this.cell1);
            this.Controls.Add(this.display);
            this.Controls.Add(this.coinKeeper1);
            this.Controls.Add(this.vendingMachine1);
            this.Name = "FormVendingTest";
            this.Text = "FormVendingTest";
            this.Load += new System.EventHandler(this.FormVendingTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.product1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acceptor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cell1)).EndInit();
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
        private System.Windows.Forms.Button button1;
        private MyPanel myPanel1;
        private Acceptor acceptor1;
        private System.Windows.Forms.Timer timer;
        private Product product1;
    }
}