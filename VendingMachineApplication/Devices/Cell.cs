using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineApplication.Devices
{
    public partial class Cell : GraphicalObject
    {
        private const int MaxProducts = 10;
        private uint _productPrice;
        private Product _product = null;

        public Cell()
        {
            InitializeComponent();
        }

        public Cell(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public Product Product
        {
            get
            {

                Product p = null;
                if (_product != null) 
                    p = new Product(_product);
                return p;
            }
            set
            {
                _product = new Product(value);
                Repaint();
            }
        }

        public int ProductCount { get; private set; }

        public uint ProductPrice
        {
            get
            {
                 return _productPrice;
            }
            set
            {
                _productPrice = value % 100;
            }
        }

        public void AddProduct(int count = 1)
        {
            if (_product == null)
                return;

            ProductCount += count;

            if (ProductCount > MaxProducts)
                ProductCount = MaxProducts;
        }

        public Product RemoveProduct()
        {
            if (ProductCount == 0)
                return null;

            ProductCount--;
            return Product;
        }

        public void ChangeProduct(Product value)
        {
            Product = value;
        }

        override public void Repaint()
        {
            if (this._img != null)
            {
                if (Image != null)
                    Image.Dispose();

                Image = CopyBitmap(_img, new RectangleF(0, 0, _scale * _img.Width, _scale * _img.Height), new RectangleF(0, 0, _img.Width, _img.Height));
                this.Width = Image.Width;
                this.Height = Image.Height;

                if (_product != null && _product.ImagePack != null)
                {
                    Graphics g = Graphics.FromImage(Image);
                    //g.DrawImage(_product.ImagePack, new RectangleF(scale * (_img.Width - _product.ImagePack.Width) / 2, 0, scale * _product.ImagePack.Width, scale * _product.ImagePack.Height), new RectangleF(0, 0, _product.ImagePack.Width, _product.ImagePack.Height), GraphicsUnit.Pixel);
                    float wd = _product.ImagePack.Width, hg = _product.ImagePack.Height;
                    wd /= 1.21f;
                    hg /= 1.21f;
                    wd /= 1.21f;
                    hg /= 1.21f;

                    g.DrawImage(_product.ImagePack, new RectangleF(_scale * (_img.Width - wd) / 2, -2 * _scale, _scale * wd, _scale * hg), new RectangleF(0, 0, _product.ImagePack.Width, _product.ImagePack.Height), GraphicsUnit.Pixel);
                    wd *= 1.21f;
                    hg *= 1.21f;
                    g.DrawImage(_product.ImagePack, new RectangleF(_scale * (_img.Width - wd) / 2, 3 * _scale, _scale * wd, _scale * hg), new RectangleF(0, 0, _product.ImagePack.Width, _product.ImagePack.Height), GraphicsUnit.Pixel);
                    g.Dispose();
                }
            }
        }
    }
}
