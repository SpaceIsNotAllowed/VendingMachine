using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineApplication
{
    public class Product
    {
        private String _Name;
        private Image _Image;
        
        public String Name
        {
            get
            {
                return _Name;
            }
        }
        public Image Image
        {
            get
            {
                return _Image;
            }
        }

        public VendingMachineApplication.Devices.Cell Cell
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Product(String name, Image image)
        {
            _Name = name;
            _Image = image;
        }

        public Product(Product p)
        {
            this._Name = p.Name;
            this._Image = p.Image;
        }
    }
}
