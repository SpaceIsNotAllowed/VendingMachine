using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VendingMachineApplication.Devices;

namespace VendingMachineApplication
{
    public partial class CoinKeeper : GraphicalObject//: PictureBox
    {
        public CoinKeeper() : base()
        {
           // InitializeComponent();
           
            Init();
        }
        /*
        public CoinKeeper(IContainer container)
        {
            container.Add(this);
           // InitializeComponent();
            Init();
        }
        */

        private bool Closed;
        private uint Account;

        /*
        private float scale = 1.9f;
        private Bitmap _img;

        public float Scale
        {
            get
            {
                return scale;
            }
            set
            {
                if (value > 0.0)
                    scale = value;
                Repaint();
            }
        }
        
        [Browsable(true)]
        [Bindable(true)]
        [Localizable(true)]
        public Bitmap ImagePack
        {
            get
            {
                return _img;
            }
            set
            {
                _img = value;
                _img.MakeTransparent(Color.FromArgb(34 * 0x10000 + 177 * 0x100 + 76));
            }
        }

        protected Bitmap CopyBitmap(Bitmap source, RectangleF dest, RectangleF src)
        {
            Bitmap bmp = new Bitmap((int)Math.Truncate(dest.Width), (int)Math.Truncate(dest.Height));
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(source, dest, src, GraphicsUnit.Pixel);
            g.Dispose();
            return bmp;
        }
        */
/*
        public VendingMachine VendingMachine
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
        */
        private void Init()
        {
            Account = 0;
            Closed = true;

            if (this._img != null)
                Repaint();

            MouseDown += Open;
            MouseUp += Close;
        }

        override public void Repaint()
        {
            if (this._img != null)
            {
                if (Image != null)
                    Image.Dispose();

                if (!Closed)
                    Image = CopyBitmap(_img, new RectangleF(0, 0, scale * _img.Width / 2, scale * _img.Height), new RectangleF(_img.Width / 2, 0, _img.Width / 2 - 1, _img.Height));
                else
                    Image = CopyBitmap(_img, new RectangleF(0, 0, scale * _img.Width / 2, scale * _img.Height), new RectangleF(0, 0, _img.Width / 2 - 1, _img.Height));
                this.Width = Image.Width;
                this.Height = Image.Height;
            }
        }

        private void Open(object sender, MouseEventArgs e)
        {
            Closed = false;
            Repaint();
        }

        private void Close(object sender, MouseEventArgs e)
        {
            Closed = true;
            Repaint();
        }

        public uint ReturnMoney()
        {
            uint result = Account;
            Account = 0;
            return result;
        }

        public void GetMoney(uint count)
        {
            Account += count;
        }
    }
}
