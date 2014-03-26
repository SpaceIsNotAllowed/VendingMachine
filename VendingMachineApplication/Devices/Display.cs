using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineApplication.Devices;

namespace VendingMachineApplication
{
    public partial class Display : GraphicalObject
    {
        #region Конструкторы

        public Display()
        {
            Init();
        }

        #endregion

        private void Init()
        {
            //...
        }

        private void Update() // убрать?
        {
            Repaint();
        }

        private Image Background;
        private String _MainInfo, _InputInfo, _MoneyInfo;

        #region Свойства

        public String MainInfo
        {
            set
            {
                _MainInfo = value;
                Update();
            }
        }

        public String InputInfo
        {
            get
            {
                return _InputInfo; //??
            }
            set
            {
                _InputInfo = value;
                if (_InputInfo.Length > 2)
                    _InputInfo = _InputInfo.Remove(2);
                Update();
            }
        }

        public String MoneyInfo
        {
            set
            {
                _MoneyInfo = value;
                Update();
            }
        }

        #endregion

        override public void Repaint()
        {
            if (this._img != null)
            {
                if (Image != null)
                    Image.Dispose();

                Image = CopyBitmap(_img, new RectangleF(0, 0, scale * _img.Width, scale * _img.Height), new RectangleF(0, 0, _img.Width, _img.Height));
                this.Width = Image.Width;
                this.Height = Image.Height;

                Graphics g = Graphics.FromImage(Image);

                SolidBrush drawBrush = new SolidBrush(Color.White);

                int mainFontSize = 10;
                int inputFontSize = 7;
                int moneyFontSize = 25;

                PointF mainDrawPoint = new PointF(5.0F * scale * 1, 5.0F * scale);
                PointF inputDrawPoint = new PointF(5.0F * scale * mainFontSize / inputFontSize, 25.0F * scale);
                PointF moneyDrawPoint = new PointF(5.0F * scale * mainFontSize / moneyFontSize, 45.0F * scale);

                Font mainDrawFont = new Font("Times New Roman", mainFontSize * scale);
                Font inputDrawFont = new Font("Times New Roman", inputFontSize * scale);
                Font moneyDrawFont = new Font("Times New Roman", moneyFontSize * scale);

                g.DrawString(_MainInfo, mainDrawFont, drawBrush, mainDrawPoint);
                g.DrawString(_InputInfo, inputDrawFont, drawBrush, inputDrawPoint);
                g.DrawString(_MoneyInfo, moneyDrawFont, drawBrush, moneyDrawPoint);

                //g.DrawString("Hello!", new Font(FontFamily , new SolidBrush(Color.White), new PointF(0, 0));
                g.Dispose();
            }
        }

    }
}
