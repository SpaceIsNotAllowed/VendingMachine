using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VendingMachineApplication.Devices;

namespace VendingMachineApplication
{
    [Serializable]
    public partial class InputButton : GraphicalObject //Component, ISerializable
    {
        private bool _pressed;
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
        
        private InputPanel _ownerPanel = null;
        
        public  InputPanel  OwnerPanel
        {
            get
            {
                return _ownerPanel;
            }
            set
            {
                _ownerPanel = value;
            }
        }

        /*
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
                if (_Manager != null)
                    _Manager.Click += ButtonClick;
            }
        }
        */
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
            /*
            if (_Owner != null)
                _Owner.ReceiveKey(_Key);
            */
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
            //info.AddValue("v_manager", _Manager, typeof(Control));
        }

        // The special constructor is used to deserialize values.
        public InputButton(SerializationInfo info, StreamingContext context)
        {
            // Reset the property value using the GetValue method.
            _Key = (char)info.GetValue("key_value", typeof(char));
            //_Manager = (Control)info.GetValue("v_manager", typeof(Control));
        }
/*
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
        */
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                this._pressed = true;
                Repaint();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                this._pressed = false;
                Repaint();
                if (_ownerPanel != null)
                    _ownerPanel.ReceiveKey(_Key);
                else
                    MessageBox.Show("Owner not found!");
            }
        }

        public override void Repaint()
        {
            if (this._img != null)
            {
                if (Image != null)
                    Image.Dispose();

                if (_pressed)
                    Image = CopyBitmap(_img, new RectangleF(0, 0, scale * _img.Width / 2, scale * _img.Height), new RectangleF(_img.Width / 2, 0, _img.Width / 2 - 1, _img.Height));
                else
                    Image = CopyBitmap(_img, new RectangleF(0, 0, scale * _img.Width / 2, scale * _img.Height), new RectangleF(0, 0, _img.Width / 2 - 1, _img.Height));
                this.Width = Image.Width;
                this.Height = Image.Height;
            }
        }


    }
}
