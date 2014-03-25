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
    public abstract class GraphicalObject : PictureBox
    {
        protected Bitmap _img;
        protected float scale = 1.9f;
        public double dLeft { get; private set; } // Если не вводить эти переменные, глобальный масштаб 
        public double dTop { get; private set; }  // будет меняться некорректно из-за округлений

        [Browsable(true)]
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
        /*
        public class SampleEventArgs
        {
            public SampleEventArgs(string s) { Text = s; }
            public String Text {get; private set;} // readonly
        }
        */

        public delegate void ScaleChangedEventHandler(object sender, double scale);
        public event ScaleChangedEventHandler ScaleChanged;

        public new float Scale
        {
            get
            {
                return scale;
            }
            set
            {
                if (value > 0.0)
                {
                    scale = value;
                    if (ScaleChanged != null)
                        ScaleChanged(this, scale);
                    Repaint();
                }
            }
        }
        
        // x0, y0 - точка отсчёта
        public void ChangeGlobalScale(double x0, double y0, float newScale)
        {
            dLeft = x0 + (dLeft - x0) * newScale / Scale;
            Left = (int) dLeft;
            dTop = y0 + (dTop - y0) * newScale / Scale;
            Top = (int) dTop;
            this.Scale = newScale;
        }


        protected Bitmap CopyBitmap(Bitmap source, RectangleF dest, RectangleF src)
        {
            int newWidth = (int)Math.Truncate(dest.Width);
            if (newWidth <= 0) newWidth = 1;
            int newHeight = (int)Math.Truncate(dest.Height);
            if (newHeight <= 0) newHeight = 1;
            Bitmap bmp = new Bitmap(newWidth, newHeight);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(source, dest, src, GraphicsUnit.Pixel);
            g.Dispose();
            return bmp;
        }

        abstract public void Repaint();

        public GraphicalObject() : base()
        {
            if (_img != null)
                Repaint();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.dLeft = Left;
            this.dTop = Top;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            if ((int) dLeft != Left)
                this.dLeft = Left;
            if ((int) dTop != Top)
                this.dTop  = Top;
        }
    }
}
