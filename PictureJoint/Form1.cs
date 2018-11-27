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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            files = new string[2];
        }
        string[] files;
        private void button1_Click(object sender, EventArgs e)
        {
            try { 
                OpenFileDialog openfile = new OpenFileDialog();
                openfile.Multiselect = true;
                openfile.InitialDirectory = @"C:\Users\91950\Pictures\Saved Pictures";
                if (openfile.ShowDialog() == DialogResult.OK && (openfile.FileNames[0] != "") && (openfile.FileNames[1] != "")){
                 
                    pictureBox1.ImageLocation = openfile.FileNames[0];
                    pictureBox2.ImageLocation = openfile.FileNames[1];

                    this.files[0] = openfile.FileNames[0];
                    this.files[1] = openfile.FileNames[1];
                }
                openfile.Dispose();
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            int h1 = this.pictureBox1.Image.Height;
            int w1 = this.pictureBox1.Image.Width;
            int h2 = this.pictureBox2.Image.Height;
            int w2 = this.pictureBox2.Image.Width;
            int[] hw = { h1, w1, h2, w2 };
            JointForm jointForm = new JointForm(hw,files);
            jointForm.Show();
        }
    }
}
