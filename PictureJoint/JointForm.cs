using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureJoint
{
    public partial class JointForm : Form
    {
        static int[] hw = new int[4];
        static string[] files = new string[2];
        public JointForm(int[] hw2,string[] files2)
        {
            InitializeComponent();
            for(int i = 0; i < 4; i++)
            {
                hw[i] = hw2[i];
            }
            for (int i = 0; i < 2; i++)
            {
                files[i] = files2[i];
            }
        }
        PictureBox pictureBox1;
        PictureBox pictureBox2;
        private void JointForm_Load(object sender, EventArgs e)
        {
            pictureBox1 = new PictureBox();
            pictureBox1.Height = 600;//hw[0];
            pictureBox1.Width = 800;// hw[1];
            pictureBox1.ImageLocation = files[0];
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.BackColor = Color.White;
            panel1.Controls.Add(pictureBox1);
            pictureBox1.Location = new Point(0, 0);

            pictureBox2 = new PictureBox();
            pictureBox2.Height = 600;//hw[2];
            pictureBox2.Width = 800;//hw[3];
            pictureBox2.ImageLocation = files[1];
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.BackColor = Color.Black;
            panel1.Controls.Add(pictureBox2);
            pictureBox1.Location = new Point(0, 0);//(1920- pictureBox2.Width, 1080- pictureBox2.Height);


        }

        int flag = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (flag == 0) {
                pictureBox2.BringToFront();
                pictureBox1.SendToBack();
                flag = 1;
            }
            else
            {
                pictureBox1.BringToFront();
                pictureBox2.SendToBack();
                flag = 0;
            }
           
        }
    }
}
