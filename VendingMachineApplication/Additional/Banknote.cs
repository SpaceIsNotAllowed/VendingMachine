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
        private BanknoteRating _rating;

        public const int IMG_COUNT = 13;
        private int _imageIndex = 0;

        public Banknote() : base()
        {
            _rating = BanknoteRating.Unknown;
        }

        public Banknote(int value) : base()
        {
            switch (value)
            {
                case (int)BanknoteRating.Ten:
                    _rating = BanknoteRating.Ten;
                break;
                case (int)BanknoteRating.Fifty:
                    _rating = BanknoteRating.Fifty;
                break;
                case (int)BanknoteRating.OneHundred:
                    _rating = BanknoteRating.OneHundred;
                break;
                default:
                    _rating = BanknoteRating.Unknown;
                break;
            }
            Repaint();
        }

        public Banknote(BanknoteRating rating)
            : base()
        {
            this._rating = rating;
        }

        public int Value
        {
            get
            {
                switch (_rating)
                {
                    case BanknoteRating.Ten:        return 10;
                    case BanknoteRating.Fifty:      return 50;
                    case BanknoteRating.OneHundred: return 100;
                    default: return 0;
                }
            }
        }

        public int ImageIndex
        {
            get
            {
                return _imageIndex;
            }
            set
            {
                if (value < 0)
                {
                    _imageIndex = (value % IMG_COUNT) + IMG_COUNT + 1;
                } else

                if (value > IMG_COUNT)
                {
                    _imageIndex = value % IMG_COUNT;
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

                int banknoteindex = 0;
                switch (_rating)
                {
                    case BanknoteRating.Ten: banknoteindex = 0; break;
                    case BanknoteRating.Fifty: banknoteindex = 1; break;
                    case BanknoteRating.OneHundred: banknoteindex = 2; break;
                    case BanknoteRating.Unknown: banknoteindex = 3; break;
                }

                Image = CopyBitmap(_img,
                                        new RectangleF(0, 0, _scale * _img.Width / IMG_COUNT, _scale * (_img.Height / 4)),
                                        new RectangleF((_imageIndex * _img.Width) / IMG_COUNT, _img.Height * banknoteindex / 4, _img.Width / IMG_COUNT - 5, _img.Height / 4)
                                  );

                this.Width = Image.Width;
                this.Height = Image.Height;
            }
        }
    }
}
