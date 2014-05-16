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
    public partial class InputButton : GraphicalObject
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
                    case 'Т':  case 'С':
                    {
                        _Key = value;

                        break;
                    };
                    default: break;
                }
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

        /*
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("v_key", _Key, typeof(char));
        }

        // The special constructor is used to deserialize values.
        public InputButton(SerializationInfo info, StreamingContext context)
        {
            // Reset the property value using the GetValue method.
            _Key = (char)info.GetValue("key_value", typeof(char));
        }
         */
        override public Bitmap ImagePack
        {
            get
            {
                return _img;
            }
            set
            {
                _img = value;
                if (value == null) return;
                _img.MakeTransparent(Color.FromArgb(34 * 0x10000 + 177 * 0x100 + 76));
                this.Size = new Size((int)((double)_img.Width * _scale / 2), (int)((double)_img.Height * _scale));
            }
        }

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
            }
        }

        public override void Repaint()
        {
            if (this._img != null)
            {
                if (Image != null)
                    Image.Dispose();

                if (_pressed)
                    Image = CopyBitmap(_img, new RectangleF(0, 0, _scale * _img.Width / 2, _scale * _img.Height), new RectangleF(_img.Width / 2, 0, _img.Width / 2 - 1, _img.Height));
                else
                    Image = CopyBitmap(_img, new RectangleF(0, 0, _scale * _img.Width / 2, _scale * _img.Height), new RectangleF(0, 0, _img.Width / 2 - 1, _img.Height));
                this.Width = Image.Width;
                this.Height = Image.Height;
            }
        }


    }
}
