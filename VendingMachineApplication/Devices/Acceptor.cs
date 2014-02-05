using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendingMachineApplication
{
    class Acceptor : PictureBox
    {
          private bool isUsed;
          private Checker Checker;
          private bool fail;
          List<Banknote> BanknoteList;

          private uint account;

          Acceptor(int x0, int y0)
          {

          }

          public void Update() {}
          public void GetMoney(uint count) { }
          public uint ReturnMoney()
          {
              uint result = account;
              account = 0;
              return result;
          }
          public bool Failed()
          {
              return fail; //??
          }
          public bool Busy() //??
          {
              return isUsed;
          }
    }
}
