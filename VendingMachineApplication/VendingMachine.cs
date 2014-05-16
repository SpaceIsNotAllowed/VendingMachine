﻿using System;
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
            //...
        }

        private void InitState()
        {
            if (_state == State.SCellRequest || _state == State.SChangingCellRequest ||
                _state == State.SRepeat || _state == State.SPriceRequest)
            {
                Display.InputInfo = "";
                //msgtime = 0;
                Panel.Unlock();
            }
            
            switch (_state)
            {
                case State.SUnlock:
                {
                    Panel.Unlock();
                    _state = State.SCellRequest;
                    Display.MainInfo = "Введите номер ячейки: ";
                } break;
                case State.SCellRequest:
                    Display.MainInfo = "Введите номер ячейки: ";
                break;
                case State.SChangingCellRequest:
                    Display.MainInfo = "Ячейка: ";
                break;
                case State.SRepeat:
                    Display.MainInfo = "Повторите ввод:";
                break;
                case State.SPriceRequest:
                    Display.MainInfo = "Цена товара:";
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

            if (Acceptor != null)
            {
                Acceptor.Update();
                uint money = Acceptor.ReturnMoney();
                if (money > 0)
                {
                    Account += money;
                    // MessageBox.Show(money.ToString() + " рублей зачислено на счёт!");
                    // и так видно
                }
            }

            if (Display != null)
            {
                if (_input.Length > 2)
                    Display.InputInfo = _input.Substring(_input.Length - 2, 2);
                else
                    Display.InputInfo = _input;
                Display.MoneyInfo = Account.ToString() + " p.";
            }

            
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
            _password = "##1**";
            _state = State.SCellRequest;
            
            Account = 0;

            InitState();
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
