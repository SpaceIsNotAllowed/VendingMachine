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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        //    Button 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text += inputPanel1.Input;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            inputPanel1.Buttons[1].Manager = button1;
            inputPanel1.Buttons[2].Manager = button2;
            inputPanel1.Buttons[3].Manager = button3;
            inputPanel1.Buttons[4].Manager = button4;
            inputPanel1.Buttons[5].Manager = button5;
            inputPanel1.Buttons[6].Manager = button6;
            inputPanel1.Buttons[7].Manager = button7;
            inputPanel1.Buttons[8].Manager = button8;
            inputPanel1.Buttons[9].Manager = button9;
            inputPanel1.Buttons[0].Manager = button11;
            inputPanel1.Buttons[10].Manager = button10;
            inputPanel1.Buttons[11].Manager = button12;
        }

        private void coinKeeper2_Click(object sender, EventArgs e)
        {
           // textBox2.Text += "\n\r" + coinKeeper2.ReturnMoney().ToString();
            textBox2.Text = "Получена сдача: " + coinKeeper.ReturnMoney().ToString() + Environment.NewLine + textBox2.Text;
        }

        private void coinKeeper2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            coinKeeper.GetMoney(1);
            coinKeeper.Width  += 20;
            coinKeeper.Height += 20;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            coinKeeper.Scale *= 1.1f;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            coinKeeper.Scale /= 1.1f;
        }
    }
}
