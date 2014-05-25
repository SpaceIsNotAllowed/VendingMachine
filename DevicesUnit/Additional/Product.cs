using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesUnit
{
    public class Product : GraphicalObject
    {
        public String Name { get; set; }

        public Product() { }

        public Product(String name, Image image)
        {
            Name = name;
            if (image != null)
                ImagePack = new Bitmap(image);
            Repaint();
        }

        public Product(Product p)
        {
            if (p == null) return;
            this.Name = p.Name;

            if (p.Image != null)
                this.Image = p.Image.Clone() as Image;

            if (p.ImagePack != null)
                this.ImagePack = new Bitmap(p.ImagePack);
            Repaint();
        }
    }
}
