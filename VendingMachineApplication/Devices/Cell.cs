using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineApplication.Devices
{
    public partial class Cell : Component
    {
        public Cell()
        {
            InitializeComponent();
        }

        public Cell(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public VendingMachineApplication.VendingMachine VendingMachine
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        private const int MaxProducts = 10;
        private Product Product;
        private int ProductCount;
        private uint ProductPrice;

        public Product GetProduct()
        {
            Product p = new Product(Product); //??
            return p;
        }

        public void AddProduct()
        {
            if (ProductCount < MaxProducts) ProductCount++;
        }

        public void ChangeProduct(Product value)
        {
            Product = value;
        }

        public void SetPrice(uint price)
        {
            ProductPrice = price % 100;
        }
    }
}
