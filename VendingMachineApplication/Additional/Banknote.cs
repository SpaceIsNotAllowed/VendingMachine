using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineApplication
{
    public enum BanknoteRating
    {
        Ten, Fifty, OneHundred 
    }

    public class Banknote
    {
        private BanknoteRating rating;

        Banknote(BanknoteRating rating)
        {
            this.rating = rating;
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
    }
}
