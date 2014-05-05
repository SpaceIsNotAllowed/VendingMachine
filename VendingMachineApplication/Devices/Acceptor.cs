using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VendingMachineApplication.Devices;

namespace VendingMachineApplication
{
    public class Acceptor : GraphicalObject
    {
        public delegate void BanknoteApprovedEventHandler(object sender, int rating);
        public event BanknoteApprovedEventHandler BanknoteApproved;
        public event EventHandler BanknoteDenied;

          private bool isUsing;
          private Checker Checker;
          private bool fail;
          List<Banknote> BanknoteList;

          private uint account;

          public Acceptor() : base()
          {
              isUsing = false;
              fail = false;
              account = 0;
              Checker = new Checker();
              BanknoteList = new List<Banknote>();
          }

          public new void Update()
          {
              Repaint();

              if (!isUsing) return;

              Banknote banknote = null;
              if (BanknoteList.Count > 0)
                  banknote = BanknoteList[BanknoteList.Count - 1];

              if (fail)
              {
                  if (banknote != null)
                  {
                      if (banknote.imageIndex > 0)
                          banknote.imageIndex--;
                      else
                      {
                          BanknoteList.Remove(banknote);
                          banknote.Dispose();
                          isUsing = false;
                          fail = false;
                      }
                  }

                  return;
              }
              else
              {

                  if (banknote != null && banknote.imageIndex < Banknote.IMGCount)
                      banknote.imageIndex++;

                  Checker.Update();
                  int rating = Checker.GetResult();
                  if (rating == -1) return; // идёт проверка
                  if (rating == 0)
                  {
                      fail = true;
                      if (BanknoteDenied != null)
                          BanknoteDenied(this, null);
                      //MessageBox.Show("Купюра не соответствует требованиям!");
                      return;
                  }

                  account += (uint)rating;
                  isUsing = false;
                  banknote.Visible = false;
                  if (BanknoteApproved != null)
                      BanknoteApproved(this, rating);
                  //MessageBox.Show("На счёт купюроприёмника зачислено " + rating.ToString() + " рублей.");
              }
          }

          public void GetMoney(Banknote banknote)// (uint count)
          {
              if (isUsing) return;

              isUsing = true;
              BanknoteList.Add(banknote);
              banknote.Scale = this.Scale;
              banknote.Left = this.Left + (this.Width - banknote.Width) / 2;
              banknote.Top = this.Top + (int) (17 * Scale);
              SetStyle(ControlStyles.SupportsTransparentBackColor, true);
              banknote.BackColor = Color.Transparent;
              /*
              Graphics g = Graphics.FromImage(banknote.Image);
              //g.DrawImage(source, dest, src, GraphicsUnit.Pixel);
              Brush b = new SolidBrush(Color.Transparent);
              g.FillRectangle(b, 0, 0, banknote.Width - 5, banknote.Height - 5);
              g.Dispose();
              */
              banknote.BringToFront();
              //(banknote as  PictureBox).Transp


              Checker.Check(banknote);
          }

          public uint ReturnMoney()
          {
              if (isUsing) return 0;

              fail = false;
              uint result = account;
              account = 0;
              return result;
          }

          public bool Failed()
          {
              return fail;
          }
          public bool Busy()
          {
              return isUsing;
          }

          override public void Repaint()
          {
              if (this._img != null)
              {
                  if (Image != null)
                      Image.Dispose();

                  if (!isUsing)
                      Image = CopyBitmap(_img, new RectangleF(0, 0, _scale * _img.Width / 2, _scale * _img.Height), new RectangleF(_img.Width / 2, 0, _img.Width / 2 - 1, _img.Height));
                  else
                      Image = CopyBitmap(_img, new RectangleF(0, 0, _scale * _img.Width / 2, _scale * _img.Height), new RectangleF(0, 0, _img.Width / 2 - 1, _img.Height));
                  this.Width = Image.Width;
                  this.Height = Image.Height;
              }
          }
    }
}
