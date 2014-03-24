using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendingMachineApplication
{

    public partial class InputPanel : Component
    {
        private String _input = "";

        public String Input
        {
            get
            {
                String result = _input;
                _input = "";
                return result;
            }

        }

        private InputButton[] _Buttons = new InputButton[12];/* { new InputButton(), new InputButton(), new InputButton(), 
                                                             new InputButton(), new InputButton(), new InputButton(),
                                                             new InputButton(), new InputButton(), new InputButton(),
                                                             new InputButton(), new InputButton(), new InputButton()};*/
        [Browsable(true)]
        [ReadOnly(false)]
        public InputButton[] Buttons
        {
            set
            {
                for (int i = 0; i < value.Length && i < 12; i++)
                {
                    _Buttons[i] = value[i];
                    if (_Buttons[i] != null)
                    {
                        _Buttons[i].OwnerPanel = this;
                        _Buttons[i].Key = giveKey(i);
                    }
                }
            }
            get
            {
                return _Buttons;
            }
        }

        public void ReceiveKey(char value)
        {
            _input += value;
        }
        
        public InputPanel()
        {
            InitializeComponent();
            InitButtons();
        }

        public InputPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            InitButtons();
        }

        private char giveKey(int buttonNumber)
        {
            return (char)(buttonNumber < 10 ? ('0' + buttonNumber) : (buttonNumber == 10 ? '*' : '#'));
        }

        private void InitButtons()
        {
            for (int i = 0; i < 12; i++)
            {
                //Buttons[i].Owner = this;
                if (Buttons[i] != null)
                {
                    Buttons[i].OwnerPanel = this;
                    Buttons[i].Key = (char)(i < 10 ? ('0' + i) : (i == 10 ? '*' : '#'));
                }
            } 
        }
        /*
        public VendingMachine VendingMachine
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
        */

    }
}
