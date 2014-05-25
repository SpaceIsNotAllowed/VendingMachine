using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesUnit
{
    public partial class Display : GraphicalObject
    {
        private String _mainInfo, _inputInfo, _moneyInfo;

        public Display()
        {
            _mainInfo = "";
            _inputInfo = "";
            _moneyInfo = "";
        }

        [Category("Отображаемая информация")]
        public String MainInfo
        {
            set
            {
                _mainInfo = value;
                Repaint();
            }
        }

        [Category("Отображаемая информация")]
        public String InputInfo
        {
            get
            {
                return _inputInfo;
            }
            set
            {
                string tmp = "";
                tmp = value;
                if (tmp != null)
                {
                    tmp = tmp.Replace("С", "");
                    tmp = tmp.Replace("Т", "");
                    tmp = tmp.Replace("*", "");
                    tmp = tmp.Replace("#", "");
                }
                _inputInfo = tmp;
                if (_inputInfo == null)
                    _inputInfo = "";
                if (_inputInfo.Length > 2)
                    _inputInfo = _inputInfo.Substring(_inputInfo.Length - 2, 2);
                Repaint();
            }
        }

        [Category("Отображаемая информация")]
        public String MoneyInfo
        {
            set
            {
                _moneyInfo = value;
                Repaint();
            }
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

                Graphics g = Graphics.FromImage(Image);

                SolidBrush drawBrush = new SolidBrush(Color.White);

                int mainFontSize = 10;
                int inputFontSize = 7;
                int moneyFontSize = 25;

                PointF mainDrawPoint = new PointF(5.0F * _scale * 1, 5.0F * _scale);
                PointF inputDrawPoint = new PointF(5.0F * _scale * mainFontSize / inputFontSize, 25.0F * _scale);
                PointF moneyDrawPoint = new PointF(5.0F * _scale * mainFontSize / moneyFontSize, 45.0F * _scale);

                Font mainDrawFont = new Font("Times New Roman", mainFontSize * _scale);
                Font inputDrawFont = new Font("Times New Roman", inputFontSize * _scale);
                Font moneyDrawFont = new Font("Times New Roman", moneyFontSize * _scale);

                g.DrawString(_mainInfo, mainDrawFont, drawBrush, mainDrawPoint);
                g.DrawString(_inputInfo, inputDrawFont, drawBrush, inputDrawPoint);
                g.DrawString(_moneyInfo, moneyDrawFont, drawBrush, moneyDrawPoint);

                g.Dispose();
            }
        }
    }
}
