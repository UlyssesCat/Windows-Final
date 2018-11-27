using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.pictureBox1.MouseWheel += new MouseEventHandler(PictureBox1_MouseWheel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strlogogpath = MapPath(@"C:\Users\91950\Pictures\Saved Pictures\1.jpg");
            string strimgpath = MapPath(@"C:\Users\91950\Pictures\Saved Pictures\2.jpg");
            //using (Bitmap bitmap = new Bitmap(strimgpath))
            //{
            //    using (Graphics g = Graphics.FromImage(bitmap))
            //    {
            //        g.DrawImage(Image.FromFile(strlogogpath), new Point(5, 5));
            //        bitmap.Save(@"C:\Users\91950\Pictures\Saved Pictures\3.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
            //    }
            //}
            CombinImage(strlogogpath, strimgpath);
        }
        public static string MapPath(string strPath)
        {
            strPath = strPath.Replace("/", "\\");
            if (strPath.StartsWith("\\"))
            {
                strPath = strPath.TrimStart('\\');
            }
            return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
        }

        public static Image CombinImage(string sourceImg, string destImg)
        {
            Image imgBack = System.Drawing.Image.FromFile(sourceImg);     //相框图片  
            Image img = System.Drawing.Image.FromFile(destImg);        //照片图片



            //从指定的System.Drawing.Image创建新的System.Drawing.Graphics        
            Graphics g = Graphics.FromImage(imgBack);

            g.DrawImage(imgBack, 0, 0, 148, 124);      // g.DrawImage(imgBack, 0, 0, 相框宽, 相框高); 
            g.FillRectangle(System.Drawing.Brushes.Black, 16, 16, (int)112 + 2, ((int)73 + 2));//相片四周刷一层黑色边框



            //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高);
            g.DrawImage(img, 17, 17, 112, 73);
            GC.Collect();
            imgBack.Save(@"E:/1.jpg");
            return imgBack;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();

            openfile.InitialDirectory = @"C:\Users\91950\Pictures\Saved Pictures";

            if (openfile.ShowDialog() == DialogResult.OK && (openfile.FileName != ""))
            {
                pictureBox1.ImageLocation = openfile.FileName;
                textBox1.Text = System.IO.Path.GetFileName(openfile.FileName);
            }

            openfile.Dispose();
        }

        private void PictureBox1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                this.pictureBox1.Width += 10;
                this.pictureBox1.Height += 10;
            }
            else
            {
                this.Text = "Mouse Wheeled Down";
                this.pictureBox1.Width -= 10;
                this.pictureBox1.Height -= 10;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.pictureBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Width += 1;
            this.pictureBox1.Height += 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Width -= 1;
            this.pictureBox1.Height -= 1;
        }
    }
}
