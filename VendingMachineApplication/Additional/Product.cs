using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineApplication.Devices;

namespace VendingMachineApplication
{
    public class Product : GraphicalObject
    {
        public new String Name { get; set; }

        /*
        public Image Image { }
        {
            get
            {
                return _Image;
            }
        }*/

        public Product(String name, Image image)
        {
            Name = name;
            if (image != null)
                ImagePack = new Bitmap(image);
            //Image = image;
        }

        public Product(Product p)
        {
            if (p == null) return;
            this.Name = p.Name;
            if (p.ImagePack != null)
                this.ImagePack = new Bitmap(p.ImagePack);

        }

        public Product()
        {

        }

    }
}
