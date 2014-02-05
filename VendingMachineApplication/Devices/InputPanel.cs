using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private InputButton[] _Buttons = new InputButton[] { new InputButton(), new InputButton(), new InputButton(), 
                                                            new InputButton(), new InputButton(), new InputButton(),
                                                            new InputButton(), new InputButton(), new InputButton(),
                                                            new InputButton(), new InputButton(), new InputButton()};
        [Browsable(true)]
        [ReadOnly(false)]
        public InputButton[] Buttons
        {
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

        private void InitButtons()
        {
            for (int i = 0; i < 12; i++)
            {
                Buttons[i].Owner = this;
                Buttons[i].Key = (char)(i < 10 ? ('0' + i) : (i == 10 ? '*' : '#'));
            } 
        }

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


    }
}
