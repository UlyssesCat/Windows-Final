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
   
    public partial class FormC : Form
    {
        MySqlConnection con;
        string a = "";
        string b = "";
        string c = "";
        public FormC(string stuID,string stuName,string stuGrade)
        {
            InitializeComponent();
            a = stuID;
            b = stuName;
            c = stuGrade;
        }

        private void FormC_Load(object sender, EventArgs e)
        {
            string str = "Server=localhost;User ID=root;Password=19981025;Database=t;CharSet=gbk";
            con = new MySqlConnection(str);
            con.Open();

            textBox1.Text = a;
            textBox2.Text = b;
            textBox3.Text = c;
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
            if (textBox1.Equals(a) && textBox2.Equals(b) && textBox3.Equals(c))
            {
                if (MessageBox.Show("未改动,是否直接退出修改界面", "Confirm Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                try { 
                    string strcmd = "update student set stuName =  '" + textBox2.Text + "', stuGrade = " + textBox3.Text + " where stuID = " + textBox1.Text + ";";
                    MySqlCommand cmd = new MySqlCommand(strcmd, con);
                    cmd.ExecuteNonQuery();
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("updata successfully");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
    }
}
