using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineApplication.Devices;

namespace VendingMachineApplication
{
    public enum BanknoteRating
    {
        Ten = 10,
        Fifty = 50,
        OneHundred = 100,
        Unknown = -1
    }

    public class Banknote : GraphicalObject
    {
        private BanknoteRating rating;

        public Banknote() : base()
        {
            rating = BanknoteRating.Unknown;
            ImagePack = Properties.Resources._10rub as Bitmap;//
        }

        public Banknote(int value) : base()
        {
            switch (value)
            {
                case (int)BanknoteRating.Ten:
                    rating = BanknoteRating.Ten;
                    ImagePack = Properties.Resources._10rub as Bitmap;
                break;
                case (int)BanknoteRating.Fifty:
                    rating = BanknoteRating.Fifty;
                    ImagePack = Properties.Resources._10rub as Bitmap;//
                break;
                case (int)BanknoteRating.OneHundred:
                    rating = BanknoteRating.OneHundred;
                    ImagePack = Properties.Resources._10rub as Bitmap;//
                break;
                default:
                    rating = BanknoteRating.Unknown;
                    ImagePack = Properties.Resources._10rub as Bitmap;//
                break;
            }
            Repaint();
        }

        public Banknote(BanknoteRating rating)
            : base()
        {
            this.rating = rating;
            ImagePack = Properties.Resources._10rub as Bitmap;
            // switch (rating)...
        }

        public int Value
        {
            get
            {
                switch (rating)
                {
                    case BanknoteRating.Ten:        return 10;
                    case BanknoteRating.Fifty:      return 50;
                    case BanknoteRating.OneHundred: return 100;
                    default: return 0;
                }
            }
        }

        public const int IMGCount = 13;
        private int _imageIndex = 0;
        public int imageIndex
        {
            get
            {
                return _imageIndex;
            }
            set
            {
                if (value < 0)
                {
                    //_imageIndex = (value % IMGCount) + IMGCount;
                    _imageIndex = (value % IMGCount) + IMGCount + 1;
                } else
                //if (value >= IMGCount)
                if (value > IMGCount)
                {
                    _imageIndex = value % IMGCount;
                } else
                    _imageIndex = value;
                Repaint();
            }
        }

        public override void Repaint()
        {
            if (this._img != null)
            {
                if (Image != null)
                    Image.Dispose();

                Image = CopyBitmap(_img,
                                        new RectangleF(0, 0, _scale * _img.Width / IMGCount, _scale * _img.Height),
                                        new RectangleF((_imageIndex * _img.Width) / IMGCount, 0, _img.Width / IMGCount - 5, _img.Height)
                                  );
                //CopyBitmap(_img, new RectangleF(0, 0, _img.Width / 12, IMGCount
                this.Width = Image.Width;
                this.Height = Image.Height;
                
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
        
        internal Acceptor Acceptor
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
