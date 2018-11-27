using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MySQLApp
{
    public partial class Form1 : Form
    {
        public static DataSet ds;
        MySqlConnection con;

        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string str = "Server=localhost;User ID=root;Password=19981025;Database=t;CharSet=gbk";
            con = new MySqlConnection(str);
            con.Open();
            ds = new DataSet("Book");
            string strcmd = "select * from student";
            MySqlCommand cmd = new MySqlCommand(strcmd, con);
            MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
            ada.Fill(ds);//查询结果填充数据集
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormA fA = new FormA();
            fA.ShowDialog();
            if (fA.DialogResult == DialogResult.OK)
            {
                string strcmd = "select * from student";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                ds.Clear();
                ada.Fill(ds);//查询结果填充数据集
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.CurrentRow.Index;
            string stuID = this.dataGridView1.Rows[index].Cells["stuID"].Value.ToString();
            string stuName = this.dataGridView1.Rows[index].Cells["stuName"].Value.ToString();
            string stuGrade = this.dataGridView1.Rows[index].Cells["stuGrade"].Value.ToString();
            if (MessageBox.Show("Delete student ["+stuID+" "+stuName+"] ?", "Confirm Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string strcmd = "delete from student where stuID =  "+stuID+";";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                cmd.ExecuteNonQuery();

                strcmd = "select * from student";
                cmd = new MySqlCommand(strcmd, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                ds.Clear();
                ada.Fill(ds);//查询结果填充数据集
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.CurrentRow.Index;
            string stuID = this.dataGridView1.Rows[index].Cells["stuID"].Value.ToString();
            string stuName = this.dataGridView1.Rows[index].Cells["stuName"].Value.ToString();
            string stuGrade = this.dataGridView1.Rows[index].Cells["stuGrade"].Value.ToString();

            FormC fC = new FormC(stuID,stuName,stuGrade);
            fC.ShowDialog();
            if (fC.DialogResult == DialogResult.OK)
            {
                string strcmd = "select * from student";
                MySqlCommand cmd = new MySqlCommand(strcmd, con);
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                ds.Clear();
                ada.Fill(ds);//查询结果填充数据集
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string s1 = comboBox1.Text;
            string s2 = textBox1.Text;
            string scmd = "";
            if (s1=="stuID"||s1=="stuGrade")
            {
                scmd = "select * from student where " + s1 + " = " + s2 + " ;";
                if (checkBox1.Checked==true) scmd = "select * from student where " + s1 + " like '%" + s2 + "%' ;";

            }
            if(s1=="stuName")
            {
                scmd = "select * from student where " + s1 + " = '" + s2 + "' ;";
                if (checkBox1.Checked == true) scmd = "select * from student where " + s1 + " like '%" + s2 + "%' ;";

            }
            if (s2 == "") scmd = "select * from book";
            MySqlCommand cmd = new MySqlCommand(scmd, con);
            cmd.ExecuteNonQuery();
            ds.Clear();
            MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
            ada.Fill(ds);//查询结果填充数据集
        }
    }
}
