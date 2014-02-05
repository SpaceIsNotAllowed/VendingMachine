using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendingMachineApplication
{
    [Serializable]
    public partial class InputButton : Component, ISerializable
    {
        private char _Key = '0';
        
        public  char  Key
        {
            get
            {
                return _Key;
            }
            set
            {
                switch (value)
                {
                    case '0':  case '1':  case '2':
                    case '3':  case '4':  case '5':
                    case '6':  case '7':  case '8':
                    case '9':  case '*':  case '#':
                    {
                        _Key = value;
                        break;
                    };
                    default: break;
                }
            }
        }

        private InputPanel _Owner = null;
        public  InputPanel  Owner
        {
            get
            {
                return _Owner;
            }
            set
            {
                _Owner = value;
            }
        }

        private Control _Manager = null;
        public  Control  Manager
        {
            get
            {
                return _Manager;
            }
            set
            {
                _Manager = value;
                _Manager.Click += ButtonClick;
            }
        }

        public InputButton()
        {
            InitializeComponent();
        }

        public InputButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }



        private void ButtonClick(object sender, EventArgs e)
        {
            _Owner.ReceiveKey(_Key);
            
        }
/*
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
        */
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            info.AddValue("v_key", _Key, typeof(char));
            info.AddValue("v_manager", _Manager, typeof(Control));
        }

        // The special constructor is used to deserialize values.
        public InputButton(SerializationInfo info, StreamingContext context)
        {
            // Reset the property value using the GetValue method.
            _Key = (char)info.GetValue("key_value", typeof(char));
            _Manager = (Control)info.GetValue("v_manager", typeof(Control));
        }

        public InputPanel InputPanel
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
