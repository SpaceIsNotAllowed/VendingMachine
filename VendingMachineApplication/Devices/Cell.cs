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
        private const int MAX_PRODUCTS = 10;
        private uint _productPrice;
        private Product _product = null;
        
        public int ProductCount { get; private set; }
        public int CellNumber { get; set; }

        public uint ProductPrice
        {
            get
            {
                return _productPrice;
            }
            set
            {
                _productPrice = value % 100;
                Repaint();
            }
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

        public Cell()
        {
            InitializeComponent();

            CellNumber = 0;
            ProductCount = 0;
        }

        public Cell(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            CellNumber = 0;
            ProductCount = 0;
        }

        public void AddProduct(int count = 1)
        {
            if (_product == null)
                return;

            ProductCount += count;

            if (ProductCount > MAX_PRODUCTS)
                ProductCount = MAX_PRODUCTS;
            Repaint();
        }

        public Product RemoveProduct()
        {
            if (ProductCount == 0)
                return null;

            ProductCount--;
            Repaint();
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

                Graphics g = null;

                if (_product != null && _product.ImagePack != null && ProductCount > 0)
                {
                    g = Graphics.FromImage(Image);
                    float wd = _product.ImagePack.Width, hg = _product.ImagePack.Height;
                    wd /= 1.21f;
                    hg /= 1.21f;

                    if (ProductCount > 1)
                    {
                        wd /= 1.21f;
                        hg /= 1.21f;

                        g.DrawImage(_product.ImagePack, new RectangleF(_scale * (_img.Width - wd) / 2, -2 * _scale, _scale * wd, _scale * hg), new RectangleF(0, 0, _product.ImagePack.Width, _product.ImagePack.Height), GraphicsUnit.Pixel);

                        wd *= 1.21f;
                        hg *= 1.21f;
                    }
                    
                    g.DrawImage(_product.ImagePack, new RectangleF(_scale * (_img.Width - wd) / 2, 3 * _scale, _scale * wd, _scale * hg), new RectangleF(0, 0, _product.ImagePack.Width, _product.ImagePack.Height), GraphicsUnit.Pixel);
                    
                    g.Dispose();
                }

                g = Graphics.FromImage(Image);
                int textFontSize = 7;
                SolidBrush textDrawBrush = new SolidBrush(Color.DarkRed);
                PointF textDrawPoint = new PointF(1F * _scale, 62.0F * _scale);
                Font textDrawFont = new Font("Times New Roman", textFontSize * _scale, FontStyle.Bold);
                g.DrawString(CellNumber.ToString("D2"), textDrawFont, textDrawBrush, textDrawPoint);

                textDrawBrush = new SolidBrush(Color.DarkBlue);
                textDrawPoint = new PointF(15F * _scale, 69.0F * _scale);
                textDrawFont = new Font("Times New Roman", textFontSize * _scale, FontStyle.Bold);
                g.DrawString(ProductPrice.ToString("D2"), textDrawFont, textDrawBrush, textDrawPoint);

                g.Dispose();
            }
        }
    }
}
