using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VendingMachineApplication.Devices;

namespace VendingMachineApplication
{
    public partial class FormVendingTest : Form
    {
        public FormVendingTest()
        {
            InitializeComponent();
            cell1.Product = product1;
        }

        FormChooseAction formChooseAction = null;

        private void FormVendingTest_Load(object sender, EventArgs e)
        {
            this.MouseWheel += new MouseEventHandler(FormVendingTest_MouseWheel);


            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVendingTest));
            Image image = ((System.Drawing.Image)(resources.GetObject("can1")));
            
            Product p = new Product("pepsi", image);
            vendingMachine1.Cell.Product = p;
            vendingMachine1.Init();
            
            formChooseAction = new FormChooseAction();
            formChooseAction.Show();
            formChooseAction.BringToFront();
            formChooseAction.OnInsertBanknoteClick += InsertBanknote;
            
            //delegate void InsertBanknoteHandler(object sender, InsertBanknoteEventArgs e);
        }

        void InsertBanknote(object sender, InsertBanknoteEventArgs e)
        {
            e.Banknote.ImagePack = Properties.Resources._10rub as Bitmap;
            e.Banknote.Repaint();

            this.Controls.Add(e.Banknote);

            acceptor1.GetMoney(e.Banknote);
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

        private void button1_Click(object sender, EventArgs e)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVendingTest));
            Image image = ((System.Drawing.Image)(resources.GetObject("cell1.Image")));
            List<Cell> lc = vendingMachine1.CreateCells(image); 
            foreach (Cell c in lc)
            {
                this.Controls.Add(c);
                c.Show();
                c.Repaint();
                c.BringToFront();
                
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            vendingMachine1.Update();
        }


    }

}
