using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = Int32.Parse(textBox1.Text);
            string a = "", c;
            int i = 0, k;
            do
            {
                k = n % 2;
                c = k.ToString();
                a = c + a;
                n = n / 2;
                i++;
            } while (n != 0);
            textBox2.Text = a;
    }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
            textBox2.ResetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
