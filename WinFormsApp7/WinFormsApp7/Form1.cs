using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form new_mdi_child1 = new Form();
            new_mdi_child1.Text = "Form1";
            new_mdi_child1.BackColor = Color.Beige;
            new_mdi_child1.MdiParent = this;
            new_mdi_child1.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Form new_mdi_child2 = new Form();
            new_mdi_child2.Text = "Form2";
            new_mdi_child2.BackColor = Color.BlueViolet;
            new_mdi_child2.MdiParent = this;
            new_mdi_child2.Show();
        }
    }
}
