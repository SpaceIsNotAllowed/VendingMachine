using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendingMachineApplication.UnitTesting
{
    public partial class FormDisplayTest : Form
    {
        public FormDisplayTest()
        {
            InitializeComponent();
        }

        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof(TextBox)) return;
            switch ((sender as TextBox).Name)
            {
                case "MainInfo": display.MainInfo = MainInfo.Text; break;
                case "MoneyInfo": display.MoneyInfo = MoneyInfo.Text; break;
                case "InputInfo": display.InputInfo = InputInfo.Text; break;
                default: break;
            }
        }

        private void FormDisplayTest_Load(object sender, EventArgs e)
        {
            this.MouseWheel += new MouseEventHandler(FormDisplayTest_MouseWheel);
            display.MainInfo = MainInfo.Text;
            display.MoneyInfo = MoneyInfo.Text;
            display.InputInfo = InputInfo.Text;
        }

        void FormDisplayTest_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0) display.Scale *= 1.1f;
            if (e.Delta > 0) display.Scale /= 1.1f;
        }

        private void displaySizeChanged(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof(Display)) return;
            this.Width = (sender as Display).Right + 25;
            this.Height = (sender as Display).Bottom + 47;
            if (this.Height < MoneyInfo.Bottom + 47) this.Height = MoneyInfo.Bottom + 47;
        }

        private void display1_SizeChanged(object sender, EventArgs e)
        {

        }
    }
}
