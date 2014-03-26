using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendingMachineApplication
{
    public partial class FormVendingTest : Form
    {
        public FormVendingTest()
        {
            InitializeComponent();
            //vendingMachine1.coinKeeper = new CoinKeeper();
            vendingMachine1.coinKeeper = coinKeeper1;
            //vendingMachine1.coinKeeper.Left = 100;
            //vendingMachine1.coinKeeper.Top = 100;

        }

        private void FormVendingTest_Load(object sender, EventArgs e)
        {
            this.MouseWheel += new MouseEventHandler(FormVendingTest_MouseWheel);
        }

        void FormVendingTest_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0) vendingMachine1.Scale *= 1.1f;
            if (e.Delta > 0) vendingMachine1.Scale /= 1.1f;
            this.Text = vendingMachine1.Scale.ToString();
        }

        private void vendingMachine1_ScaleChanged(object sender, double scale)
        {
            
        }

        private void vendingMachine1_SizeChanged(object sender, EventArgs e)
        {
            this.Width = vendingMachine1.Left + vendingMachine1.Width + 25;
            this.Height = vendingMachine1.Top + vendingMachine1.Height + 25;
        }
    }

}
