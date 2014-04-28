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
        public Cell()
        {
            InitializeComponent();
        }

        public Cell(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private const int MaxProducts = 10;

        private Product _product = null;
        public Product Product
        {
            get
            {
                Product p = new Product(_product); //??
                return p;
            }
            set
            {
                _product = new Product(value);
                Repaint();
            }
        }
        private int ProductCount;
        private uint ProductPrice;

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

        override public void Repaint()
        {
            if (this._img != null)
            {
                if (Image != null)
                    Image.Dispose();

                Image = CopyBitmap(_img, new RectangleF(0, 0, scale * _img.Width, scale * _img.Height), new RectangleF(0, 0, _img.Width, _img.Height));
                this.Width = Image.Width;
                this.Height = Image.Height;

                if (_product != null)
                {
                    Graphics g = Graphics.FromImage(Image);
                    //g.DrawImage(_product.ImagePack, new RectangleF(scale * (_img.Width - _product.ImagePack.Width) / 2, 0, scale * _product.ImagePack.Width, scale * _product.ImagePack.Height), new RectangleF(0, 0, _product.ImagePack.Width, _product.ImagePack.Height), GraphicsUnit.Pixel);
                    float wd = _product.ImagePack.Width, hg = _product.ImagePack.Height;
                    wd /= 1.21f;
                    hg /= 1.21f;

                    g.DrawImage(_product.ImagePack, new RectangleF(scale * (_img.Width - wd) / 2, -2 * scale, scale * wd, scale * hg), new RectangleF(0, 0, _product.ImagePack.Width, _product.ImagePack.Height), GraphicsUnit.Pixel);
                    wd *= 1.21f;
                    hg *= 1.21f;
                    g.DrawImage(_product.ImagePack, new RectangleF(scale * (_img.Width - wd) / 2, 3 * scale, scale * wd, scale * hg), new RectangleF(0, 0, _product.ImagePack.Width, _product.ImagePack.Height), GraphicsUnit.Pixel);
                    g.Dispose();
                }
            }
        }
    }
}
