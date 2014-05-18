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

        const int MSGTIME = 20;
        private int repeattime = 0;
        private bool timerun = false;

        private int cellNum = -1; // номер изменяемой ячейки

        private String _input = "";
        private String _password = "*123#";
        
        public uint Account { get; private set; }

        private List<Cell> _cellList;
        private Product FallingFood = null;
        private int foodSpeed = 0;

        public delegate void ProductManagementEventHandler(object sender, Product product);
        public event ProductManagementEventHandler ProductRemoveRequest;
        public event ProductManagementEventHandler ProductFallRequest;


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

                if (_cellList[cellNumber].ProductCount < 1)
                {
                    VendingState = State.SEmptyCell;
                    return;
                }

                if (Account < _cellList[cellNumber].ProductPrice)
                {
                    VendingState = State.SMoneyRequest;
                    return;
                }

                if (FallingFood == null)
                {
                    FallingFood = _cellList[cellNumber].RemoveProduct();//!!!
                    FallingFood.Left = _cellList[cellNumber].Left + (_cellList[cellNumber].Width - FallingFood.Image.Width) / 2;
                    FallingFood.Top = _cellList[cellNumber].Top + (_cellList[cellNumber].Height - FallingFood.Image.Height) / 2;
                    FallingFood.Scale = this.Scale;
                    foodSpeed = 1;
                    if (ProductFallRequest != null)
                        ProductFallRequest(this, FallingFood);
                    //components.Add(FallingFood);


                    Account -= _cellList[cellNumber].ProductPrice;
                    VendingState = State.SDone;

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
                    if (!int.TryParse(Display.InputInfo, out num) || (_cellList != null && (num < 1 || num > _cellList.Count)))
                    {
                        VendingState = State.SRepeat;
                        return;
                    }
                    num--;
                    cellNum = num;

                    VendingState = State.SPriceRequest;
                    return;
                }
                else
                {
                    if (!int.TryParse(Display.InputInfo, out num)) return;

                    if (_cellList != null && cellNum >= 0 && cellNum < _cellList.Count)
                        _cellList[cellNum].ProductPrice = (uint)num;

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
                    if (FallingFood != null)
                    {
                        if (ProductRemoveRequest != null)
                            ProductRemoveRequest(this, FallingFood);
                        FallingFood.Dispose();
                        FallingFood = null;
                    }
                    Panel.Unlock();
                    //_input = "";
                    Display.MainInfo = "Введите номер ячейки: ";
                    //Display.InputInfo = "";
                    Display.MoneyInfo = Account.ToString() + " р.";
                break;
                case State.SChangingCellRequest:
                    _input = "";
                    Display.MainInfo = "Ячейка: ";
                    Display.InputInfo = "";
                    Display.MoneyInfo = "";
                    cellNum = -1;
                break;
                case State.SRepeat:
                    _input = "";
                    Display.MainInfo = "Повторите ввод:";
                    Display.InputInfo = "";
                    cellNum = -1;
                break;
                case State.SPriceRequest:
                    _input = "";
                    Display.MainInfo = "Цена товара:";
                    Display.InputInfo = "";
                break;

                case State.SDone:
                {
                    Display.MainInfo = "Приятного аппетита!";
                    repeattime = MSGTIME;
                    timerun = true;
                    Panel.Lock();
                } break;
                case State.SMoneyRequest:
                {
                    Display.MainInfo = "Недостаточно средств.";
                    repeattime = MSGTIME;
                    timerun = true;
                    Panel.Lock();
                } break;
                case State.SEmptyCell:
                {
                    Display.MainInfo = "Ячейка пуста.";
                    repeattime = MSGTIME;
                    timerun = true;
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
            if (repeattime >= 0 && timerun)
            {
                repeattime--;
                if (FallingFood != null)
                {
                    if (FallingFood.Top < this.Top + _scale * 450)
                        FallingFood.Top += foodSpeed;
                    else
                        if (FallingFood.Visible)
                            FallingFood.Visible = false;
                }
                foodSpeed += 5;
            }
            if (repeattime < 0 && timerun)
            {
                timerun = false;
                if (_state == State.SDone || _state == State.SEmptyCell || _state == State.SMoneyRequest)
                {
                    _state = State.SCellRequest;
                    InitState();
                }
            }

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
            if (_cellList != null)
                return null;

            _cellList = new List<Cell>();
            for (int i = 0; i < 60; i++)
            {
                Cell c = new Cell() { CellNumber = i + 1 };
                c.ImagePack = new Bitmap(img);
                
                c.Scale = this.Scale;
                c.Left = this.Left + (int)(26 * Scale + (i % 10) * (c.ImagePack.Width) * c.Scale);
                c.Top = this.Top + (int)(42 * Scale + (i / 10) * (c.ImagePack.Height) * c.Scale);
                c.Repaint();
                c.BringToFront();
                _cellList.Add(c); 
            }
            return _cellList;
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
                if (_cellList != null)
                    foreach (Cell cell in _cellList)
                        cell.ChangeGlobalScale(this.dLeft, this.dTop, Scale);


                if (FallingFood != null)
                    FallingFood.ChangeGlobalScale(this.dLeft, this.dTop, Scale);

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

        public void AddProductsToCell(int cellNumber, int count)
        {
            if (cellNumber < 1 || _cellList == null || _cellList.Count < cellNumber)
                return;

            cellNumber--;
            _cellList[cellNumber].AddProduct(count);
        }

        public void SetCellPrice(int cellNumber, uint value)
        {
            if (cellNumber < 1 || _cellList == null || _cellList.Count < cellNumber)
                return;

            cellNumber--;
            _cellList[cellNumber].ProductPrice = value;
        }

        public void SetCellProduct(int cellNumber, Product product)
        {
            if (cellNumber < 1 || _cellList == null || _cellList.Count < cellNumber)
                return;

            cellNumber--;
            _cellList[cellNumber].Product = product;
        }

    }
}
