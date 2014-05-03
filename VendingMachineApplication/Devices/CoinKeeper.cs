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
    public partial class CoinKeeper : GraphicalObject
    {
        public CoinKeeper() : base()
        {
            Init();
        }

        private bool _closed;
        private uint _account;

        private void Init()
        {
            _account = 0;
            _closed = true;

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

                if (!_closed)
                    Image = CopyBitmap(_img, new RectangleF(0, 0, _scale * _img.Width / 2, _scale * _img.Height), new RectangleF(_img.Width / 2, 0, _img.Width / 2 - 1, _img.Height));
                else
                    Image = CopyBitmap(_img, new RectangleF(0, 0, _scale * _img.Width / 2, _scale * _img.Height), new RectangleF(0, 0, _img.Width / 2 - 1, _img.Height));
                this.Width = Image.Width;
                this.Height = Image.Height;
            }
        }

        private void Open(object sender, MouseEventArgs e)
        {
            _closed = false;
            Repaint();
        }

        private void Close(object sender, MouseEventArgs e)
        {
            _closed = true;
            Repaint();
        }

        public uint ReturnMoney()
        {
            uint result = _account;
            _account = 0;
            return result;
        }

        public void GetMoney(uint count)
        {
            _account += count;
        }
    }
}
