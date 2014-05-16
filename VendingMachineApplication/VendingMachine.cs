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

        private String _input = "";
        private String _password = "*123#";
        
        public uint Account { get; private set; }

        private List<Cell> cellList;

        private Product FallingFood = null;
        
        public State VendingState //посмотреть имя в ПЗ
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                InitState();
            }
        }

        private State _state;
        private Sensor _sensor;
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

        public InputPanel Panel { get; set; }


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
                _coinKeeper.Click += this.coinKeeperClick;
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

        [Category("Устройства")]
        public Acceptor Acceptor { get; set; }


        public VendingMachine()
            : base()
        {

            this.ScaleChanged += vendingMachineScaleChanged;
        }

        private void AnalyseInput()
        {
            if (_input.Contains(_password))
            {
                _input = _input.Replace(_password, "");
                // переход в режим администратора
                VendingState = State.SChangingCellRequest;
                return;
            }

            if (_input.Contains('С'))
            {
                CoinKeeper.GetMoney(Account);
                Account = 0;
                _input = _input.Replace("С", "");
            }

            if (_input.Contains('Т'))
            {
                _input = _input.Replace("Т", "");

                int cellNumber = 0;
                if (!int.TryParse(Display.InputInfo, out cellNumber) || cellNumber < 1 || cellNumber > 60)
                    return;
                cellNumber--;

                if (cellList[cellNumber].ProductCount < 1)
                {
                    VendingState = State.SEmptyCell;
                    return;
                }

                if (Account < cellList[cellNumber].ProductPrice)
                {
                    VendingState = State.SMoneyRequest;
                    return;
                }

                if (FallingFood == null)
                {
                    FallingFood = cellList[cellNumber].RemoveProduct();//!!!
                    Account -= cellList[cellNumber].ProductPrice;
                    //VendingState = State. //?

                    //int xpos = cell % 10;
                    //int ypos = 5 - cell / 10;
                    
                    //count[cell]--;
                    //VendingMachineMoney -= price[cell];
                    //FallingFood = new TProduct(type[cell], 60 + xpos * 30, 470 - ypos * 80, 550);
                    //state = 4;
                    //InitState();
                    //ShowAll();
                    return;
                }
            }

            //if (input.Length() == 0) return;

            if (string.IsNullOrEmpty(_input)) return;

            if (_input[_input.Length - 1] == '#' &&
                    (VendingState == State.SChangingCellRequest || VendingState == State.SRepeat || VendingState == State.SPriceRequest)
                )
            {
                _input = _input.Replace("#", "");

                int num = 0;

                if (_state == State.SChangingCellRequest || _state == State.SRepeat)
                {
                    if (!int.TryParse(Display.InputInfo, out num) || num < 1 || num > 60)
                    {
                        VendingState = State.SRepeat;
                        return;
                    }
                    num--;

                    VendingState = State.SPriceRequest;
                    return;
                }
                else
                {
                    if (!int.TryParse(Display.InputInfo, out num)) return;

                    if (cellList != null)
                        cellList[/*...*/1].ProductPrice = (uint)num;

                    VendingState = State.SChangingCellRequest;

                    //MessageBox.Show("В ячейке " + AnsiString(cell + 1) + " установлена цена " + AnsiString(price[cell]) + " р.");

                }
                return;
            }

            if (_input[_input.Length - 1] == '*')
            {
                if (VendingState == State.SChangingCellRequest || VendingState == State.SRepeat)
                {
                    VendingState = State.SCellRequest;
                    _input = _input.Replace("*", "");
                    return;
                }

                if (VendingState == State.SPriceRequest)
                {
                    VendingState = State.SChangingCellRequest;
                    _input = _input.Replace("*", "");
                    return;
                }
            }
        }

        private void InitState()
        {
            if (VendingState == State.SCellRequest || VendingState == State.SChangingCellRequest ||
                VendingState == State.SRepeat || VendingState == State.SPriceRequest)
            {
                Display.InputInfo = "";
                //msgtime = 0;
                Panel.Unlock();
            }

            switch (VendingState)
            {
                case State.SUnlock:
                {
                    Panel.Unlock();
                    VendingState = State.SCellRequest;
                } break;
                case State.SCellRequest:
                    _input = "";
                    Display.MainInfo = "Введите номер ячейки: ";
                    Display.InputInfo = "";
                    Display.MoneyInfo = Account.ToString() + " р.";
                break;
                case State.SChangingCellRequest:
                    _input = "";
                    Display.MainInfo = "Ячейка: ";
                    Display.InputInfo = "";
                    Display.MoneyInfo = "";
                break;
                case State.SRepeat:
                    _input = "";
                    Display.MainInfo = "Повторите ввод:";
                    Display.InputInfo = "";
                break;
                case State.SPriceRequest:
                    _input = "";
                    Display.MainInfo = "Цена товара:";
                    Display.InputInfo = "";
                break;

                case State.SDone:
                {
                    Display.MainInfo = "Приятного аппетита!";
                    //msgtime = MTIME;
                    Panel.Lock();
                } break;
                case State.SMoneyRequest:
                {
                    Display.MainInfo = "Недостаточно средств.";
                    //msgtime = MTIME;
                    Panel.Lock();
                } break;
                case State.SEmptyCell:
                {
                    Display.MainInfo = "Ячейка пуста.";
                    //msgtime = MTIME;
                    Panel.Lock();
                } break;
                case State.SAlert:
                {
                    Display.MainInfo = "Тревога!";
                    Panel.Lock();
                } break;
            }
        }

        public new void Update()
        {
            if (Panel != null)
            {
                _input += Panel.Input;
            }

            if (Display != null)
            {
                Display.InputInfo = _input;
                Display.MoneyInfo = Account.ToString() + " p.";
            }

            if (Acceptor != null)
            {
                Acceptor.Update();
                uint money = Acceptor.ReturnMoney();
                if (money > 0)
                    Account += money;
            }

            AnalyseInput();
        }

        public List<Cell> CreateCells(Image img)
        {
            cellList = new List<Cell>();
            for (int i = 0; i < 60; i++)
            {
                Cell c = new Cell();
                c.ImagePack = new Bitmap(img);
                c.Scale = this.Scale;
                c.Left = this.Left + (int)(26 * Scale + (i % 10) * c.ImagePack.Width * c.Scale);
                c.Top = this.Top + (int)(42 * Scale + (i / 10) * c.ImagePack.Height * c.Scale);
                c.Repaint();
                c.BringToFront();
                cellList.Add(c); 
            }
            return cellList;
        }

        public void Init()
        {
            _input = "";
            VendingState = State.SCellRequest;
            
            Account = 0;

        }

        public override void Repaint()
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

        private void vendingMachineScaleChanged(object sender, double scale)
        {
            if (CoinKeeper != null)
            {
                if (cellList != null)
                    foreach (Cell cell in cellList)
                        cell.ChangeGlobalScale(this.dLeft, this.dTop, Scale);

                CoinKeeper.ChangeGlobalScale(this.dLeft, this.dTop, Scale);
                Display.ChangeGlobalScale(this.dLeft, this.dTop, Scale);
                Cell.ChangeGlobalScale(this.dLeft, this.dTop, Scale);
                if (Acceptor != null)
                    Acceptor.ChangeGlobalScale(this.dLeft, this.dTop, Scale);
                if (Panel != null)
                {
                    Panel.PanelScale = Scale;
                    Panel.Location = new Point((int)((510f - dLeft) * Scale + dLeft), (int)((266f - dTop) * Scale + dTop));
                    
                    //Panel.ChangeGlobalScale(this.dLeft, this.dTop, Scale);
                }
            }
        }

        private void coinKeeperClick(object sender, EventArgs e)
        {
            MessageBox.Show("Получено от автомата " + _coinKeeper.ReturnMoney().ToString() + " р.");
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
