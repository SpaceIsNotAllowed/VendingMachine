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
        List<Product> productList = new List<Product>();

        private void FormVendingTest_Load(object sender, EventArgs e)
        {
            this.MouseWheel += new MouseEventHandler(FormVendingTest_MouseWheel);


            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVendingTest));
            Image image = ((System.Drawing.Image)(resources.GetObject("can1")));
            
            Product p = new Product("pepsi", image);
            vendingMachine1.Cell.Product = p;
            vendingMachine1.Init();
            /*
            formChooseAction = new FormChooseAction();
            formChooseAction.Show();
            formChooseAction.BringToFront();
            formChooseAction.OnInsertBanknoteClick += InsertBanknote;
            */
            CreateCells();

            foreach (object obj in panel1.Controls)
            {
                if (obj is Product)
                    productList.Add(obj as Product);
            }
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


        private void CreateCells()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVendingTest));
            Image image = new Bitmap(global::VendingMachineApplication.Properties.Resources.small_wall);//((System.Drawing.Image)(resources.GetObject("cell1.Image")));
            List<Cell> lc = vendingMachine1.CreateCells(image);
            if (lc == null)
                return;
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



        private void button2_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            for (int i = 1; i < 61; i++)
            {
                if (productList != null && productList.Count > 0)
                    vendingMachine1.SetCellProduct(i, productList[r.Next() % productList.Count]);
                vendingMachine1.AddProductsToCell(i, r.Next() % 11);
                vendingMachine1.SetCellPrice(i, (uint)(r.Next() % 100));
            }
        }

        private void vendingMachine1_ProductFallRequest(object sender, Product product)
        {
            if (product == null)
                return;
            product.Visible = true;
            this.Controls.Add(product);
            product.BringToFront();
        }

        private void vendingMachine1_ProductRemoveRequest(object sender, Product product)
        {

            if (product == null)
                return;

            components.Remove(product);
        }

        void InsertBanknote(int value)
        {
            Banknote banknote = new Banknote(value);

            banknote.ImagePack = Properties.Resources._10rub as Bitmap;
            banknote.Repaint();
            this.Controls.Add(banknote);
            if (!acceptor1.GetMoney(banknote))
                this.Controls.Remove(banknote);
        }

        private void buttonInsertBanknoteClick(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b == null)
                return;

            switch (b.Name)
            {
                case "buttonInsert10": InsertBanknote(10); break;
                case "buttonInsert50": InsertBanknote(50); break;
                case "buttonInsert100": InsertBanknote(100); break;
                case "buttonInsert500": InsertBanknote(500); break;
                default: break;
            }
            
        }


    }

}
