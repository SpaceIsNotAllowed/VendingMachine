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

          private bool _isUsed;
          private bool _fail;
          private uint _account;
          private List<Banknote> _banknoteList;
          private Checker _checker;

          public Acceptor() : base()
          {
              _isUsed = false;
              _fail = false;
              _account = 0;
              _checker = new Checker();
              _banknoteList = new List<Banknote>();
          }

          public new void Update()
          {
              Repaint();

              if (!_isUsed) return;

              Banknote banknote = null;
              if (_banknoteList.Count > 0)
                  banknote = _banknoteList[_banknoteList.Count - 1];

              if (_fail)
              {
                  if (banknote != null)
                  {
                      if (banknote.ImageIndex > 0)
                          banknote.ImageIndex--;
                      else
                      {
                          _banknoteList.Remove(banknote);
                          banknote.Dispose();
                          _isUsed = false;
                          _fail = false;
                      }
                  }

                  return;
              }
              else
              {

                  if (banknote != null && banknote.ImageIndex < Banknote.IMG_COUNT)
                      banknote.ImageIndex++;

                  _checker.Update();
                  int rating = _checker.GetResult();
                  if (rating == -1) return; // идёт проверка
                  if (rating == 0)
                  {
                      _fail = true;
                      if (BanknoteDenied != null)
                          BanknoteDenied(this, null);

                      return;
                  }

                  _account += (uint)rating;
                  _isUsed = false;
                  banknote.Visible = false;
                  if (BanknoteApproved != null)
                      BanknoteApproved(this, rating);
              }
          }

          public bool GetMoney(Banknote banknote)
          {
              if (_isUsed) return false;

              _isUsed = true;
              _banknoteList.Add(banknote);
              banknote.Scale = this.Scale;
              banknote.Left = this.Left + (this.Width - banknote.Width) / 2;
              banknote.Top = this.Top + (int) (17 * Scale);
              SetStyle(ControlStyles.SupportsTransparentBackColor, true);
              banknote.BackColor = Color.Transparent;

              banknote.BringToFront();
              _checker.Check(banknote);
              return true;
          }

          public uint ReturnMoney()
          {
              if (_isUsed) return 0;

              _fail = false;
              uint result = _account;
              _account = 0;
              return result;
          }

          public bool Failed()
          {
              return _fail;
          }
          public bool isBusy()
          {
              return _isUsed;
          }

          override public void Repaint()
          {
              if (this._img != null)
              {
                  if (Image != null)
                      Image.Dispose();

                  if (!_isUsed)
                      Image = CopyBitmap(_img, new RectangleF(0, 0, _scale * _img.Width / 2, _scale * _img.Height), new RectangleF(_img.Width / 2, 0, _img.Width / 2 - 1, _img.Height));
                  else
                      Image = CopyBitmap(_img, new RectangleF(0, 0, _scale * _img.Width / 2, _scale * _img.Height), new RectangleF(0, 0, _img.Width / 2 - 1, _img.Height));
                  this.Width = Image.Width;
                  this.Height = Image.Height;
              }
          }
    }
}
