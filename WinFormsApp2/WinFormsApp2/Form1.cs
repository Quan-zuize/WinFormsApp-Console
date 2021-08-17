using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }
        private Graphics g;

        int i = 0;
        Pen p = new Pen(Color.Blue, 5);
        Brush b = Brushes.Blue;
        private void Form1_Load(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.Black);
            if (i > 100) { i = 0; g.Clear(Color.Black); }
            if (g != null)
            {
                g.DrawEllipse(p, 200, 200, i, i);
            }
            i+=10;
        }
    }
}
