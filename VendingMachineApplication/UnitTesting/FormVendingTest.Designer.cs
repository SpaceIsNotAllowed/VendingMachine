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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVendingTest));
            this.coinKeeper1 = new VendingMachineApplication.CoinKeeper();
            this.vendingMachine1 = new VendingMachineApplication.VendingMachine();
            ((System.ComponentModel.ISupportInitialize)(this.coinKeeper1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendingMachine1)).BeginInit();
            this.SuspendLayout();
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
            this.vendingMachine1.BackColor = System.Drawing.Color.Transparent;
            this.vendingMachine1.coinKeeper = this.coinKeeper1;
            this.vendingMachine1.Image = ((System.Drawing.Image)(resources.GetObject("vendingMachine1.Image")));
            this.vendingMachine1.ImagePack = global::VendingMachineApplication.Properties.Resources.box;
            this.vendingMachine1.Location = new System.Drawing.Point(12, 12);
            this.vendingMachine1.Name = "vendingMachine1";
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
            this.ClientSize = new System.Drawing.Size(596, 730);
            this.Controls.Add(this.coinKeeper1);
            this.Controls.Add(this.vendingMachine1);
            this.Name = "FormVendingTest";
            this.Text = "FormVendingTest";
            this.Load += new System.EventHandler(this.FormVendingTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.coinKeeper1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendingMachine1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CoinKeeper coinKeeper1;
        private VendingMachine vendingMachine1;
    }
}