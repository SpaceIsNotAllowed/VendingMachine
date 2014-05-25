﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevicesUnit
{
    public class GraphicalObject : PictureBox
    {
        protected Bitmap _img;
        protected float _scale = 1.0f;
        public double _dLeft { get; private set; } // Если не вводить эти переменные, глобальный масштаб 
        public double _dTop { get; private set; }  // будет меняться некорректно из-за округлений

        public GraphicalObject()
            : base()
        {
            if (_img != null)
                Repaint();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this._dLeft = Left;
            this._dTop = Top;
        }

        [Category("Свойства устройства")]
        virtual public Bitmap ImagePack
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
                this.Size = new Size((int)((double)_img.Width * _scale), (int)((double)_img.Height * _scale));
            }
        }

        public delegate void ScaleChangedEventHandler(object sender, double scale);
        [Category("События устройства")]
        public event ScaleChangedEventHandler ScaleChanged;
        [Category("Свойства устройства")]
        public new float Scale
        {
            get
            {
                return _scale;
            }
            set
            {
                if (value > 0.0)
                {
                    _scale = value;
                    if (ScaleChanged != null)
                        ScaleChanged(this, _scale);
                    Repaint();
                }
            }
        }
        
        // x0, y0 - точка отсчёта
        public void ChangeGlobalScale(double x0, double y0, float newScale)
        {
            _dLeft = x0 + (_dLeft - x0) * newScale / Scale;
            Left = (int) _dLeft;
            _dTop = y0 + (_dTop - y0) * newScale / Scale;
            Top = (int) _dTop;
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

        virtual public void Repaint()
        {
            if (this._img != null)
            {
                if (Image != null)
                    Image.Dispose();

                Image = CopyBitmap(_img, new RectangleF(0, 0, _scale * _img.Width, _scale * _img.Height), new RectangleF(0, 0, _img.Width, _img.Height));
                this.Width = Image.Width;
                this.Height = Image.Height;
            }
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
            if ((int) _dLeft != Left)
                this._dLeft = Left;
            if ((int) _dTop != Top)
                this._dTop  = Top;
        }
    }
}