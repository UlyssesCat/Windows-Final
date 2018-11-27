using CalculatorDLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
        double para1 = 0;
        double para2 = 0;
        bool c = false;
        string sign ="";

        private void button0_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "0";
            if (sign == "/")
            {
                textBox1.Clear();
                MessageBox.Show("除数不能为零", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "1";
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "2";
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "3";
            textBox1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "4";
            textBox1.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "5";
            textBox1.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "6";
            textBox1.Focus();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "7";
            textBox1.Focus();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "8";
            textBox1.Focus();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "9";
            textBox1.Focus();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0) textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length-1);
            textBox1.Focus();
        }

        private void buttonA_Click(object sender, EventArgs e)
        {
            c = true;
            para1 = double.Parse(textBox1.Text);
            sign = "+";
            textBox1.Focus();
        }

        private void buttonB_Click(object sender, EventArgs e)
        {
            c = true;
            para1 = double.Parse(textBox1.Text);
            sign = "-";
            textBox1.Focus();
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            c = true;
            para1 = double.Parse(textBox1.Text);
            sign = "*";
            textBox1.Focus();
        }

        private void buttonD_Click(object sender, EventArgs e)
        {
          
            c = true;
            para1 = double.Parse(textBox1.Text);
            sign = "/";
            textBox1.Focus();
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            textBox1.Text += ".";
            textBox1.Focus();
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            //switch (d)
            //{
            //    case "+": a = b + double.Parse(textBox1.Text); break;
            //    case "-": a = b - double.Parse(textBox1.Text); break;
            //    case "*": a = b * double.Parse(textBox1.Text); break;
            //    case "/": a = b / double.Parse(textBox1.Text); break;
            //}
            //textBox1.Text = a + "";


            
            CalHelper calHelper = new CalHelper();
            para2 = double.Parse(textBox1.Text);
            switch (sign)
            {
                case "+": textBox1.Text = "" + calHelper.Add(para1, para2); break;
                case "-": textBox1.Text = "" + calHelper.Subtract(para1, para2); break;
                case "*": textBox1.Text = "" + calHelper.Multiply(para1, para2); break;
                case "/": textBox1.Text = "" + calHelper.Divide(para1, para2); break;
            }
            c = true;
            textBox1.Focus();
         
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            para1 = 0;
            para2 = 0;
            c = false;
            sign = "";
            textBox1.Text = "";
            textBox1.Focus();
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad0) this.button0_Click(sender, e);
            if (e.KeyCode == Keys.NumPad1) this.button1_Click(sender, e);
            if (e.KeyCode == Keys.NumPad2) this.button2_Click(sender, e);
            if (e.KeyCode == Keys.NumPad3) this.button3_Click(sender, e);
            if (e.KeyCode == Keys.NumPad4) this.button4_Click(sender, e);
            if (e.KeyCode == Keys.NumPad5) this.button5_Click(sender, e);
            if (e.KeyCode == Keys.NumPad6) this.button6_Click(sender, e);
            if (e.KeyCode == Keys.NumPad7) this.button7_Click(sender, e);
            if (e.KeyCode == Keys.NumPad8) this.button8_Click(sender, e);
            if (e.KeyCode == Keys.NumPad9) this.button9_Click(sender, e);
            if (e.KeyCode == Keys.Decimal) this.buttonDot_Click(sender, e);
            if (e.KeyCode == Keys.Add) this.buttonA_Click(sender, e);
            if (e.KeyCode == Keys.Subtract) this.buttonB_Click(sender, e);
            if (e.KeyCode == Keys.Multiply) this.buttonC_Click(sender, e);
            if (e.KeyCode == Keys.Divide) this.buttonD_Click(sender, e);
            if (e.KeyCode == Keys.Enter) this.buttonEqual_Click(sender, e);
            if (e.KeyCode == Keys.Back) this.buttonDel_Click(sender, e);
        }
    }
}
