using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace sqlConnection
{
    public partial class FrmDraw : Form
    {
        public FrmDraw()
        {
            InitializeComponent();
        }
        Graphics g = null;
        Font f1 = new Font("Tahoma", 14, FontStyle.Bold);
        Font f2 = new Font("Tahoma", 20, FontStyle.Bold);
        Brush b = Brushes.Black;
        private PrintPreviewDialog printPreviewDialog1;
        private PrintPreviewControl printPreviewControl1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private Button button1;
        Pen p = new Pen(Color.Blue, 20);

        int x = 30;
        int y = 50;
        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //throw new NotImplementedException();
            g = e.Graphics;
            g.DrawString("In nhiều lần trên 1 hàng", f1, b, x, 100);
            for (int i = 0; i < 6; i++)
            {
                g.DrawString("Quân", f1, b, x, 200);
                x += 60;
            }

            g.DrawString("In nhiều lần trên 1 cột", f1, b, 50, 300);
            for (int i = 0; i < 6; i++)
            {
                g.DrawString("Quân", f1, b, 50, y+300);
                y += 50;
            }

            /*  g.DrawString("In nhiều lần trên đường chéo", f1, b, 50, 700);
              for (int i = 0; i < 6; i++)
              {
                  g.DrawString("Quân", f1, b, x, y + 300);
                  y += 50;
                  x += 60;
              }*/
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDraw));
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printPreviewControl1
            // 
            this.printPreviewControl1.Location = new System.Drawing.Point(472, 53);
            this.printPreviewControl1.Name = "printPreviewControl1";
            this.printPreviewControl1.Size = new System.Drawing.Size(328, 283);
            this.printPreviewControl1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(210, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 102);
            this.button1.TabIndex = 1;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmDraw
            // 
            this.ClientSize = new System.Drawing.Size(968, 393);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.printPreviewControl1);
            this.Name = "FrmDraw";
            this.Load += new System.EventHandler(this.FrmDraw_Load);
            this.ResumeLayout(false);

        }

        private void FrmDraw_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Document = printDocument1;
            printDocument1.PrintPage += PrintDocument1_PrintPage;
            printPreviewDialog1.Show();
            printPreviewDialog1.Document = printDocument1;
        }
    }
}
