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
        private List<Product> _productList = new List<Product>();
        private List<int> _priceList = new List<int>();

        public FormVendingTest()
        {
            InitializeComponent();
            cell1.Product = product1;
        }

        private void FormVendingTest_Load(object sender, EventArgs e)
        {
            this.MouseWheel += new MouseEventHandler(FormVendingTest_MouseWheel);


            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVendingTest));
            Image image = ((System.Drawing.Image)(resources.GetObject("can1")));
            
            Product p = new Product("pepsi", image);
            vendingMachine.Cell.Product = p;
            vendingMachine.Init();

            CreateCells();

            foreach (object obj in panel1.Controls)
            {
                if (obj is Product)
                {
                    _productList.Add(obj as Product);
                    _priceList.Add(0);
                }
            }
        }

        void InsertBanknote(object sender, InsertBanknoteEventArgs e)
        {
            e.Banknote.ImagePack = Properties.Resources.money as Bitmap;
            e.Banknote.Repaint();

            this.Controls.Add(e.Banknote);

            acceptor1.GetMoney(e.Banknote);
        }

        void FormVendingTest_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0) vendingMachine.Scale *= 1.1f;
            if (e.Delta > 0) vendingMachine.Scale /= 1.1f;
            this.Text = vendingMachine.Scale.ToString();
        }

        private void vendingMachineSizeChanged(object sender, EventArgs e)
        {
            this.Width = vendingMachine.Left + vendingMachine.Width + 25;
            this.Height = vendingMachine.Top + vendingMachine.Height + 25;
        }

        private void CreateCells()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVendingTest));
            Image image = new Bitmap(global::VendingMachineApplication.Properties.Resources.small_wall);//((System.Drawing.Image)(resources.GetObject("cell1.Image")));
            List<Cell> lc = vendingMachine.CreateCells(image);
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
            vendingMachine.Update();
        }

        private void buttonRandomizeClick(object sender, EventArgs e)
        {
            Random r = new Random();

            for (int i = 0; i < _priceList.Count; i++)
                _priceList[i] = r.Next() % 100;

            for (int i = 1; i < 61; i++)
            {
                Product cellProduct = vendingMachine.GetCellProduct(i);

                if (_productList != null && _productList.Count > 0)
                {
                    int index = -1;

                    if (cellProduct == null)
                    {
                        index = r.Next() % _productList.Count;
                        cellProduct = _productList[index];
                        vendingMachine.SetCellProduct(i, cellProduct);
                    }
                    else
                    {
                        for ( int j = 0; j < _productList.Count; j++ )
                            if (_productList[j].Name == cellProduct.Name)
                            {
                                index = j;
                                break;
                            }
                    }
                    vendingMachine.SetCellPrice(i, (uint)_priceList[index]);
                }
                vendingMachine.AddProductsToCell(i, r.Next() % 11);
            }
        }

        private void vendingMachineProductFallRequest(object sender, Product product)
        {
            if (product == null)
                return;
            product.Visible = true;
            this.Controls.Add(product);
            product.BringToFront();
        }

        private void vendingMachineProductRemoveRequest(object sender, Product product)
        {
            if (product == null)
                return;

            components.Remove(product);
        }

        void InsertBanknote(int value)
        {
            Banknote banknote = new Banknote(value);

            banknote.ImagePack = Properties.Resources.money as Bitmap;
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

    public class InsertBanknoteEventArgs : EventArgs
    {
        public Banknote Banknote { get; private set; }

        public InsertBanknoteEventArgs(Banknote banknote)
        {
            Banknote = banknote;
        }

        public InsertBanknoteEventArgs(int value)
        {
            Banknote = new Banknote(value);
        }
    }
}
