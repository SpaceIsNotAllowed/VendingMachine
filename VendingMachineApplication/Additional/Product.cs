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
                //this.Image = image.Clone() as Image;
                ImagePack = new Bitmap(image);
            Repaint();
        }

        public Product(Product p)
        {
            if (p == null) return;
            this.Name = p.Name;

            if (p.Image != null)
                this.Image = p.Image.Clone() as Image;

            //if (p.Image != null)
            //    this.Image = p.Image.Clone() as Image;
            //else
                if (p.ImagePack != null)
                    this.ImagePack = new Bitmap(p.ImagePack);
                Repaint();
        }

        public Product()
        {

        }
        /*
        public override void Repaint()
        {
            //base.Repaint();
        }*/

    }
}
