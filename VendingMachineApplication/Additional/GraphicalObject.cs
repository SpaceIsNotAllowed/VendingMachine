using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendingMachineApplication.Devices
{
    public class GraphicalObject : PictureBox
    {
        protected Bitmap _img;
        protected float scale = 1.9f;

       // [Browsable(true)]
        public Bitmap ImagePack
        {
            get
            {
                return _img;
            }
            set
            {
                _img = value;
                if (value == null) return;
                _img.MakeTransparent(Color.FromArgb(34 * 0x10000 + 177 * 0x100 + 76));
            }
        }
        public new float Scale
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

        protected Bitmap CopyBitmap(Bitmap source, RectangleF dest, RectangleF src)
        {
            Bitmap bmp = new Bitmap((int)Math.Truncate(dest.Width), (int)Math.Truncate(dest.Height));
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(source, dest, src, GraphicsUnit.Pixel);
            g.Dispose();
            return bmp;
        }

        virtual public void Repaint()
        {
        }

        public GraphicalObject() : base() {}

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }
    }
}
