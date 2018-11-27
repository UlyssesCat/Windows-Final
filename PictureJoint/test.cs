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
    public partial class test : Form
    {
        Image imgOut1;
        Image imgOut2;
        Image img1;
        Image img2;//原图，输出图
        Bitmap mapOut1;
        Bitmap mapOut2;
        Bitmap map1;
        Bitmap map2;//原图，输出图
        int width1;
        int height1;//画布长宽
        int width2;
        int height2;//画布长宽

        Graphics g1;
        Graphics g2;
        public test()
        {
            InitializeComponent();
            this.pictureBox1.MouseWheel += new MouseEventHandler(PictureBox1_MouseWheel);
            this.pictureBox2.MouseWheel += new MouseEventHandler(PictureBox2_MouseWheel);

            img1 = Image.FromFile("1.jpg");
            map1 = new Bitmap(img1);

            img2 = Image.FromFile("2.jpg");
            map2 = new Bitmap(img2);

            

            width1 = img1.Width;
            height1 = img1.Height;//画布长宽
            //调整picturebox适配原图不行  要适配原图缩小版
            width2 = img2.Width;
            height2 = img2.Height;//画布长宽

            mapOut1 = new Bitmap(width1, height1);
            mapOut2 = new Bitmap(width2, height2);

            g1 = Graphics.FromImage(mapOut1);
            g1.FillRectangle(Brushes.Blue, new Rectangle(0, 0, width1, height1));
            g1.DrawImage(map1, 0, 0, width1, height1);
       
            g2 = Graphics.FromImage(mapOut2);
            g2.FillRectangle(Brushes.Yellow, new Rectangle(0, 0, width2, height2));
            g2.DrawImage(map2, 0, 0, width2, height2);

            imgOut1 = mapOut1;
            imgOut2 = mapOut2;

            pictureBox1.Image = Image.FromHbitmap(mapOut1.GetHbitmap());
            pictureBox2.Image = Image.FromHbitmap(mapOut2.GetHbitmap());
        }

        private void test_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //imgOut.Save("3.jpg");
        }



        int mouseX, mouseY, picX, picY = 0;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseX = Cursor.Position.X;
            mouseY = Cursor.Position.Y;
            picX = this.pictureBox1.Left;
            picY = this.pictureBox1.Top;
            //MessageBox.Show(" " + mouseX + " " + mouseY + " "+ picX + " "+ picY);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int y = Cursor.Position.Y - mouseY + picY;
            int x = Cursor.Position.X - mouseX + picX;
            if (e.Button == MouseButtons.Left)
            {
                this.pictureBox1.Top = y;
                this.pictureBox1.Left = x;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseX = 0;
            mouseY = 0;
            if (this.pictureBox1.Location.X < 0)
            {
                this.pictureBox1.Left = 0;

            }
            if (this.pictureBox1.Location.Y < 0)
            {
                this.pictureBox1.Top = 0;
            }
            if ((this.pictureBox1.Left + this.pictureBox1.Width) > this.ClientSize.Width)
            {
                this.pictureBox1.Left = this.ClientSize.Width - this.pictureBox1.Width;
            }
            if ((this.pictureBox1.Top + this.pictureBox1.Height) > this.ClientSize.Height)
            {
                this.pictureBox1.Top = this.ClientSize.Height - this.pictureBox1.Height;
            }

        }

        private void PictureBox1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                if (e.Delta > 0)
                {
                    this.pictureBox1.Width += 1;
                    this.pictureBox1.Height += 1;
                }
                else
                {
                    if (this.pictureBox1.Width > 1 && this.pictureBox1.Height > 1)
                    {
                        this.pictureBox1.Width -= 1;
                        this.pictureBox1.Height -= 1;
                    }
                }
            }
            else
            {
                if (e.Delta > 0)
                {
                    this.pictureBox1.Width += 10;
                    this.pictureBox1.Height += 10;
                }
                else
                {
                    if (this.pictureBox1.Width > 10 && this.pictureBox1.Height > 10)
                    {
                        this.pictureBox1.Width -= 10;
                        this.pictureBox1.Height -= 10;
                    }
                }
            }
            

        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseX = Cursor.Position.X;
            mouseY = Cursor.Position.Y;
            picX = this.pictureBox2.Left;
            picY = this.pictureBox2.Top;
        }

        int flag = 1;
        private void button2_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                this.pictureBox2.BringToFront();
                flag = 1;
            }
            else
            {
                this.pictureBox1.BringToFront();
                flag = 0;
            }
            
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            int y = Cursor.Position.Y - mouseY + picY;
            int x = Cursor.Position.X - mouseX + picX;
            if (e.Button == MouseButtons.Left)
            {
                this.pictureBox2.Top = y;
                this.pictureBox2.Left = x;
            }
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseX = 0;
            mouseY = 0;
            if (this.pictureBox2.Location.X < 0)
            {
                this.pictureBox2.Left = 0;

            }
            if (this.pictureBox2.Location.Y < 0)
            {
                this.pictureBox2.Top = 0;
            }
            if ((this.pictureBox2.Left + this.pictureBox2.Width) > this.ClientSize.Width)
            {
                this.pictureBox2.Left = this.ClientSize.Width - this.pictureBox2.Width;
            }
            if ((this.pictureBox2.Top + this.pictureBox2.Height) > this.ClientSize.Height)
            {
                this.pictureBox2.Top = this.ClientSize.Height - this.pictureBox2.Height;
            }

        }

        private void PictureBox2_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                if (e.Delta > 0)
                {
                    this.pictureBox2.Width += 1;
                    this.pictureBox2.Height += 1;
                }
                else
                {
                    if (this.pictureBox2.Width > 1 && this.pictureBox2.Height > 1)
                    {
                        this.pictureBox2.Width -= 1;
                        this.pictureBox2.Height -= 1;
                    }
                }
            }
            else
            {
                if (e.Delta > 0)
                {
                    this.pictureBox2.Width += 10;
                    this.pictureBox2.Height += 10;
                }
                else
                {
                    if (this.pictureBox2.Width > 10 && this.pictureBox2.Height > 10)
                    {
                        this.pictureBox2.Width -= 10;
                        this.pictureBox2.Height -= 10;
                    }
                }
            }
        }
    }
}
