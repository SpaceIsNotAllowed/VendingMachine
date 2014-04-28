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
    public partial class VendingMachine : GraphicalObject
    {
        public enum State
        {
            SCellRequest,
            SChangingCellRequest,
            SRepeat,
            SPriceRequest,
            SDone,
            SMoneyRequest,
            SEmptyCell,
            SUnlock,
            SAlert
        }

        private String input = "";
        private String password = "123";
        private int account;
        private List<Cell> cellList;
        private State state;
        private Sensor sensor;
        private Display _display;
        [Browsable(true)]
        [Category("Устройства")]
        public Display Display
        {
            get
            {
                return _display;
            }
            set
            {
                _display = value;
            }
        }


        //private double CCLeft;
        //private double CCTop;

        CoinKeeper _coinKeeper;
        [Browsable(true)]
        [Category("Устройства")]
        public CoinKeeper CoinKeeper
        {
            get
            {
                return _coinKeeper;
            }
            set
            {
                _coinKeeper = value;
                /*
                if (value != null)
                {
                    _coinKeeper.Move += this.coinKeeperMove;
                    CCLeft = (int)((value.Left - this.Left) / this.Scale);
                    CCTop = (int)((value.Top - this.Top) / this.Scale);
                }
                */
            }
        }

        [Category("Устройства")]
        public Cell Cell { get; set; }

        private InputPanel inputPanel;
        private Acceptor acceptor;


        public VendingMachine()
            : base()
        {
            Init();
            this.ScaleChanged += vendingMachineScaleChanged;
            Repaint();
        }

        private void AnalyseInput()
        {
            //...
        }

        private void InitState()
        {
            //...
        }

        public void Update()
        {
            //...
        }

        public List<Cell> CreateCells(Image img)
        {
            cellList = new List<Cell>();
            for (int i = 0; i < 20; i++)
            {
                Cell c = new Cell();
                c.ImagePack = new Bitmap(img);
                c.Left = (int)(i * c.ImagePack.Width * c.Scale);
                c.Top = (int)((i / 10) * c.ImagePack.Height * c.Scale);
                c.Repaint();
                cellList.Add(c);
            }
            return cellList;
        }

        private void Init()
        {

        }

        public override void Repaint()
        {
            if (this._img != null)
            {
                if (Image != null)
                    Image.Dispose();

                Image = CopyBitmap(_img, new RectangleF(0, 0, scale * _img.Width, scale * _img.Height), new RectangleF(0, 0, _img.Width, _img.Height));

                this.Width = Image.Width;
                this.Height = Image.Height;
            }
        }

        private void vendingMachineScaleChanged(object sender, double scale)
        {
            if (CoinKeeper != null)
            {
                /*
                int left = coinKeeper.Left - this.Left;
                int top = coinKeeper.Top - this.Top;
                double q = scale / (double) coinKeeper.Scale;
                left = (int) (this.Left + left * q);
                top  = (int) (this.Top  + top  * q);
                coinKeeper.Left = left;
                coinKeeper.Top  = top;
                coinKeeper.Scale = (float)scale;*/
                /*
                double CCLeft = (coinKeeper.dLeft - this.dLeft) / coinKeeper.Scale;
                double CCTop = (coinKeeper.dTop - this.dTop) / coinKeeper.Scale;
                coinKeeper.Left = (int)(this.Left + CCLeft * scale);
                coinKeeper.Top  = (int)(this.Top  + CCTop * scale);
                coinKeeper.Scale = (float)scale;
                 */
                CoinKeeper.ChangeGlobalScale(this.dLeft, this.dTop, Scale);
                Display.ChangeGlobalScale(this.dLeft, this.dTop, Scale);
                Cell.ChangeGlobalScale(this.dLeft, this.dTop, Scale);
            }
        }
        /*
        private void coinKeeperMove(object sender, EventArgs e)
        {
            
            CoinKeeper CC = sender as CoinKeeper;
            if (CC == null) return;
            CCLeft = (int)((CC.Left - this.dLeft) * this.Scale / CC.Scale);
            CCTop = (int)((CC.Top - this.dLeft) * this.Scale / CC.Scale);
        }*/
        
    }
}
