using DevicesUnit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace VendingMachineApplication
{
    public partial class VendingMachine : GraphicalObject
    {
        const int MSGTIME = 20;
        private int _repeattime = 0;
        private bool _timerun = false;

        private List<Cell> _cellList;
        private int _cellNum = -1; // номер изменяемой ячейки

        private String _input = "";
        private String _password = "*123#";

        private Product _fallingFood = null;
        private int _foodSpeed = 0;

        private State _state;

        public VendingMessages Messages { get; set; }

        public uint Account { get; private set; }

        public delegate void ProductManagementEventHandler(object sender, Product product);
        public event ProductManagementEventHandler ProductRemoveRequest;
        public event ProductManagementEventHandler ProductFallRequest;

        public State State
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

        [Category("Устройства")]
        public Sensor Sensor { get; set; }

        [Category("Устройства")]
        public Display Display { get; set; }

        [Category("Устройства")]
        public Cell Cell { get; set; }

        [Category("Устройства")]
        public InputPanel InputPanel { get; set; }

        [Category("Устройства")]
        public Acceptor Acceptor { get; set; }

        CoinKeeper _coinKeeper;
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
            }
        }

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
                State = State.SChangingCellRequest;
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
                    State = State.SEmptyCell;
                    return;
                }

                if (Account < _cellList[cellNumber].ProductPrice)
                {
                    State = State.SMoneyRequest;
                    return;
                }

                if (_fallingFood == null)
                {
                    _fallingFood = _cellList[cellNumber].RemoveProduct();//!!!
                    _fallingFood.Left = _cellList[cellNumber].Left + (_cellList[cellNumber].Width - _fallingFood.Image.Width) / 2;
                    _fallingFood.Top = _cellList[cellNumber].Top + (_cellList[cellNumber].Height - _fallingFood.Image.Height) / 2;
                    _fallingFood.Scale = this.Scale;
                    _foodSpeed = 1;
                    if (ProductFallRequest != null)
                        ProductFallRequest(this, _fallingFood);

                    Account -= _cellList[cellNumber].ProductPrice;
                    State = State.SDone;

                    return;
                }
            }

            if (string.IsNullOrEmpty(_input)) return;

            if (_input[_input.Length - 1] == '#' &&
                    (State == State.SChangingCellRequest || State == State.SRepeat || State == State.SPriceRequest)
                )
            {
                _input = _input.Replace("#", "");

                int num = 0;

                if (_state == State.SChangingCellRequest || _state == State.SRepeat)
                {
                    if (!int.TryParse(Display.InputInfo, out num) || (_cellList != null && (num < 1 || num > _cellList.Count)))
                    {
                        State = State.SRepeat;
                        return;
                    }
                    num--;
                    _cellNum = num;

                    State = State.SPriceRequest;
                    return;
                }
                else
                {
                    if (!int.TryParse(Display.InputInfo, out num)) return;

                    if (_cellList != null && _cellNum >= 0 && _cellNum < _cellList.Count)
                        _cellList[_cellNum].ProductPrice = (uint)num;

                    State = State.SChangingCellRequest;
                }
                return;
            }

            if (_input[_input.Length - 1] == '*')
            {
                if (State == State.SChangingCellRequest || State == State.SRepeat)
                {
                    State = State.SCellRequest;
                    _input = _input.Replace("*", "");
                    return;
                }

                if (State == State.SPriceRequest)
                {
                    State = State.SChangingCellRequest;
                    _input = _input.Replace("*", "");
                    return;
                }
            }
        }

        private void InitState()
        {
            if (State == State.SCellRequest || State == State.SChangingCellRequest ||
                State == State.SRepeat || State == State.SPriceRequest)
            {
                Display.InputInfo = "";
                //msgtime = 0;
                InputPanel.UnLock();
            }

            switch (State)
            {
                case State.SUnlock:
                {
                    InputPanel.UnLock();
                    State = State.SCellRequest;
                } break;
                case State.SCellRequest:
                    if (_fallingFood != null)
                    {
                        if (ProductRemoveRequest != null)
                            ProductRemoveRequest(this, _fallingFood);
                        _fallingFood.Dispose();
                        _fallingFood = null;
                    }
                    InputPanel.UnLock();
                    //_input = "";
                    Display.MainInfo = Messages.MCellRequest;
                    //Display.InputInfo = "";
                    Display.MoneyInfo = Account.ToString() + Messages.MCurrency;
                break;
                case State.SChangingCellRequest:
                    _input = "";
                    Display.MainInfo = Messages.MChangingCellRequest;
                    Display.InputInfo = "";
                    Display.MoneyInfo = "";
                    _cellNum = -1;
                break;
                case State.SRepeat:
                    _input = "";
                    Display.MainInfo = Messages.MRepeat;
                    Display.InputInfo = "";
                    _cellNum = -1;
                break;
                case State.SPriceRequest:
                    _input = "";
                    Display.MainInfo = Messages.MPriceRequest;
                    Display.InputInfo = "";
                break;

                case State.SDone:
                {
                    Display.MainInfo = Messages.MDone;
                    _repeattime = MSGTIME;
                    _timerun = true;
                    InputPanel.Lock();
                } break;
                case State.SMoneyRequest:
                {
                    Display.MainInfo = Messages.MMoneyRequest;
                    _repeattime = MSGTIME;
                    _timerun = true;
                    InputPanel.Lock();
                } break;
                case State.SEmptyCell:
                {
                    Display.MainInfo = Messages.MEmptyCell;
                    _repeattime = MSGTIME;
                    _timerun = true;
                    InputPanel.Lock();
                } break;
                case State.SAlert:
                {
                    Display.MainInfo = Messages.MAlert;
                    InputPanel.Lock();
                } break;
            }
        }

        public new void Update()
        {
            if (_repeattime >= 0 && _timerun)
            {
                _repeattime--;
                if (_fallingFood != null)
                {
                    if (_fallingFood.Top < this.Top + _scale * 450)
                        _fallingFood.Top += _foodSpeed;
                    else
                        if (_fallingFood.Visible)
                            _fallingFood.Visible = false;
                }
                _foodSpeed += 5;
            }
            if (_repeattime < 0 && _timerun)
            {
                _timerun = false;
                if (_state == State.SDone || _state == State.SEmptyCell || _state == State.SMoneyRequest)
                {
                    _state = State.SCellRequest;
                    InitState();
                }
            }

            if (InputPanel != null)
            {
                _input += InputPanel.Input;
            }

            if (Display != null)
            {
                Display.InputInfo = _input;
                Display.MoneyInfo = Account.ToString() + Messages.MCurrency;
            }

            if (Acceptor != null)
            {
                Acceptor.Update();
                uint money = Acceptor.ReturnMoney();
                if (money > 0)
                    Account += money;
            }

            if (Sensor != null)
            {
                Sensor.Update();

                if (Sensor.Warns() && State != State.SAlert)
                    State = State.SAlert;

                if (!Sensor.Warns() && State == State.SAlert)
                    State = State.SUnlock;
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
            State = State.SCellRequest;
            
            Account = 0;
        }

        private void vendingMachineScaleChanged(object sender, double scale)
        {
            if (CoinKeeper != null)
            {
                if (_cellList != null)
                    foreach (Cell cell in _cellList)
                        cell.ChangeGlobalScale(this._dLeft, this._dTop, Scale);


                if (_fallingFood != null)
                    _fallingFood.ChangeGlobalScale(this._dLeft, this._dTop, Scale);

                CoinKeeper.ChangeGlobalScale(this._dLeft, this._dTop, Scale);
                Display.ChangeGlobalScale(this._dLeft, this._dTop, Scale);
                Cell.ChangeGlobalScale(this._dLeft, this._dTop, Scale);
                if (Acceptor != null)
                    Acceptor.ChangeGlobalScale(this._dLeft, this._dTop, Scale);
                if (InputPanel != null)
                {
                    InputPanel.PanelScale = Scale;
                    InputPanel.Location = new Point((int)((510f - _dLeft) * Scale + _dLeft), (int)((266f - _dTop) * Scale + _dTop));
                }
            }
        }

        private void coinKeeperClick(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(string.Format(Messages.MReceivedFormatString, _coinKeeper.ReturnMoney().ToString()));
            }
            catch
            {
                MessageBox.Show((new VendingMessages()).MReceivedFormatString);
            }
        }

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

        public Product GetCellProduct(int cellNumber)
        {
            if (cellNumber < 1 || _cellList == null || _cellList.Count < cellNumber)
                return null;

            cellNumber--;
            return _cellList[cellNumber].Product;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (Sensor != null)
                if (e.X > 0 && e.X < this.Width / 1.73 && e.Y > this.Height * 0.8)
                    Sensor.HasObject = true;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (Sensor != null)
                Sensor.HasObject = false;
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

        private void ApplyField(XmlNode node, ref string dest)
        {
            if (node != null && !string.IsNullOrEmpty(node.InnerText))
                dest = node.InnerText;
        }

        public void ApplyLanguage(string xml)
        {
            if (string.IsNullOrEmpty(xml))
                return;

            var doc = new XmlDocument();
            doc.Load(new StringReader(xml));

            if (doc == null || doc.FirstChild == null)
                return;

            var messages = doc.FirstChild;

            VendingMessages data = new VendingMessages();
            ApplyField(messages["CellRequest"], ref data.MCellRequest);
            ApplyField(messages["Currency"],    ref data.MCurrency);
            ApplyField(messages["ChangingCellRequest"], ref data.MChangingCellRequest);
            ApplyField(messages["Repeat"], ref data.MRepeat);
            ApplyField(messages["PriceRequest"], ref data.MPriceRequest);
            ApplyField(messages["Done"], ref data.MDone);
            ApplyField(messages["MoneyRequest"], ref data.MMoneyRequest);
            ApplyField(messages["EmptyCell"], ref data.MEmptyCell);
            ApplyField(messages["Alert"], ref data.MAlert);
            ApplyField(messages["ReceivedFormatString"], ref data.MReceivedFormatString);

            this.Messages = data;
            State = State;
        }

        public string GetSettingsXml()
        {
            string pattern =
            @"<VendingMessages>
		        <CellRequest>{0}</CellRequest>
		        <Currency>{1}</Currency>
		        <ChangingCellRequest>{2}</ChangingCellRequest>
		        <Repeat>{3}</Repeat>
		        <PriceRequest>{4}</PriceRequest>
		        <Done>{5}</Done>
		        <MoneyRequest>{6}</MoneyRequest>
		        <EmptyCell>{7}</EmptyCell>
		        <Alert>{8}</Alert>
		        <ReceivedFormatString>{9}</ReceivedFormatString>
	        </VendingMessages>";
            return string.Format(pattern,
                                    Messages.MCellRequest,
                                    Messages.MCurrency,
                                    Messages.MChangingCellRequest,
                                    Messages.MRepeat,
                                    Messages.MPriceRequest,
                                    Messages.MDone,
                                    Messages.MMoneyRequest,
                                    Messages.MEmptyCell,
                                    Messages.MAlert,
                                    Messages.MReceivedFormatString
                                );
        }
    }

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

    public class VendingMessages
    {
        public string MCellRequest;
        public string MCurrency;
        public string MChangingCellRequest;
        public string MRepeat;
        public string MPriceRequest;
        public string MDone;
        public string MMoneyRequest;
        public string MEmptyCell;
        public string MAlert;
        public string MReceivedFormatString;

        public VendingMessages()
        {
            MCellRequest = "Введите номер ячейки: ";
            MCurrency = " р.";
            MChangingCellRequest = "Ячейка: ";
            MRepeat = "Повторите ввод:";
            MPriceRequest = "Цена товара:";
            MDone = "Приятного аппетита!";
            MMoneyRequest = "Недостаточно средств.";
            MEmptyCell = "Ячейка пуста.";
            MAlert = "Тревога!";
            MReceivedFormatString = "Получено от автомата {0} р.";
        }
    }
}
