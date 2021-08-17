using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int timer;
        Bitmap[] bitmaps = new Bitmap[10];
        PictureBox picture = new PictureBox();
        public void getSubpic(PictureBox picSource, int x, int y, int w, int h)
        {
            int a = x, b = y, count = 0;
            Bitmap myBitmap = new Bitmap(pictureBox1.Image);
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Rectangle cloneRet = new Rectangle(x - a, y - b, w, h);
                    System.Drawing.Imaging.PixelFormat format = myBitmap.PixelFormat;
                    Bitmap cloneBitmap = myBitmap.Clone(cloneRet, format);
                    bitmaps[count] = cloneBitmap;
                    count++;
                    x += w;
                }
                y += h;
                x = a;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            int y = Convert.ToInt32(textBox2.Text);
            int h = Convert.ToInt32(pictureBox1.Height / x);
            int w = Convert.ToInt32(pictureBox1.Width / y);
            picture.Size = new Size(w, h);
            panel1.Controls.Add(picture);
            bitmaps = new Bitmap[x * y];
            getSubpic(pictureBox1, x, y, w, h);
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            timer = 0;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer == bitmaps.Length) timer = 0;
            picture.Image = bitmaps[timer];
            timer++;
        }
        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            this.Text = "keyValue " + e.KeyValue + "keyCode: " + e.KeyCode;
            if (e.KeyValue == 65 && picture.Left > 0)
            {
                picture.Left -= 10;
            }
            if (e.KeyValue == 68 && picture.Right < panel1.Width)
            {
                picture.Left += 10;
            }
            if (e.KeyValue == 87 && picture.Top > 0)
            {
                picture.Top -= 10;
            }
            if (e.KeyValue == 83 && picture.Bottom < panel1.Height)
            {
                picture.Top += 10;
            }
        }
    }
}
