using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySQLApp
{
    public partial class FormA : Form
    {
        MySqlConnection con;

        public FormA()
        {
            InitializeComponent();
        }

        private void FormA_Load(object sender, EventArgs e)
        {
            string str = "Server=localhost;User ID=root;Password=19981025;Database=t;CharSet=gbk";
            con = new MySqlConnection(str);
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
            {
                string msg = "";//错误信息
                if (textBox1.Text == "") msg += "student id is null;\n";
                if (textBox2.Text == "") msg += "student name is null;\n";
                if (textBox3.Text == "") msg += "student grade is null;\n";
                if (isIdFormat(textBox1.Text) == false) msg += "the format of student id is wrong;\n";
                if (isGradeFormat(textBox3.Text) == false) msg += "the format of student grade is wrong;\n";
                MessageBox.Show(msg);
                return;
            }
            try { 
                string strcmd = "insert into student values (" + textBox1.Text + ", '" + textBox2.Text + "' ," + textBox3.Text + ");";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                cmd.ExecuteNonQuery();
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("insert successfully");
                this.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        bool isIdFormat(string message)//判断id格式
        {
            if (Regex.IsMatch(message, @"^\d{7}$"))//message != ""
                return true;  
            else
                return false;
        }
        bool isGradeFormat(string message)//判断grade格式
        {
            if (Regex.IsMatch(message, @"^(\d{2}$)|(1\d{2}$)"))
                return true;
            else
                return false;
        }
        private void FormA_FormClosed(object sender, FormClosedEventArgs e)
        {
            con.Close();
            con.Dispose();
        }
    }
}
