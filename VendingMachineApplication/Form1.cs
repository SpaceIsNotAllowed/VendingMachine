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
            textBox1.Text += inputPanel.Input;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //throw new VendingMachineApplication.Devices.Sensor.MyException();
            /*
            inputPanel.Buttons[0] = inputButton1;
            for (int i = 0; i < 12; i++ )
                if (inputPanel.Buttons[i] != null)
                {
                    inputPanel.Buttons[i].OwnerPanel = inputPanel;
                    if (i < 10)
                        inputPanel.Buttons[i].Key = (char)('0' + i);
                    if (i == 11)
                        inputPanel.Buttons[i].Key = '*';
                    if (i == 12)
                        inputPanel.Buttons[i].Key = '#';
                }*/
        }

        private void coinKeeper2_Click(object sender, EventArgs e)
        {
            //textBox2.Text += "\n\r" + coinKeeper.ReturnMoney().ToString();
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
            //banknote1.Scale *= 1.1f;
            for (int i = 0; i < inputPanel.Buttons.Length; i++)
                if (inputPanel.Buttons[i] != null)
                    inputPanel.Buttons[i].Scale *= 1.1f;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            coinKeeper.Scale /= 1.1f;
            //banknote1.Scale /= 1.1f;
            for (int i = 0; i < inputPanel.Buttons.Length; i++)
                if (inputPanel.Buttons[i] != null)
                    inputPanel.Buttons[i].Scale /= 1.1f;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //banknote1.imageIndex--;
            //Text = banknote1.imageIndex.ToString();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //banknote1.imageIndex++;
            //Text = banknote1.imageIndex.ToString();
        }
    }
}
