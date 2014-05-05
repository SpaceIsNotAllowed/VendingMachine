using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendingMachineApplication
{
    public partial class FormChooseAction : Form
    {
        public FormChooseAction()
        {
            InitializeComponent();
        }

        public delegate void InsertBanknoteHandler(object sender, InsertBanknoteEventArgs e);
        public event InsertBanknoteHandler OnInsertBanknoteClick;

        private void buttonInsertMoney_Click(object sender, EventArgs e)
        {
            int value = 0;
            switch (comboBoxBanknotes.SelectedIndex)
            {
                case 0: value = 10; break;
                case 1: value = 50; break;
                case 2: value = 100; break;
                case 3: value = 500; break;
                default: value = 123; break;
            }

            if (OnInsertBanknoteClick != null)
                OnInsertBanknoteClick(this, new InsertBanknoteEventArgs(value));
        }
    }

    public class InsertBanknoteEventArgs : EventArgs
    {
        public Banknote Banknote { get; private set; }

        public InsertBanknoteEventArgs(Banknote banknote)
        {
            Banknote = banknote;
        }

        public InsertBanknoteEventArgs(int value)
        {
            Banknote = new Banknote(value);
        }
    }
}
