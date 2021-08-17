using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        List<Product> listProduct = new List<Product>();
        void createOrder()
        {
            Product p1 = new Product() { Name = "Mì gấu đỏ chua cay", Price = 2.500F, Quantity = 14 };
            Product p2 = new Product() { Name = "Mì gà sợi phở", Price = 2.500F, Quantity = 5 };
            Product p3 = new Product() { Name = "Gội rejoice 600g", Price = 89.000F, Quantity = 7 };

            listProduct.Add(p1);
            listProduct.Add(p2);
            listProduct.Add(p3);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            createOrder();
            printDocument1.PrintPage += PrintDocument1_PrintPage;
            printPreviewControl1.Document = printDocument1;
            PrintPreviewDialog pp = new PrintPreviewDialog();
            pp.Document = printDocument1;
            pp.ShowDialog();
        }

        Font f = new Font("Tahoma", 12);
        Font f2 = new Font("Tahoma", 24, FontStyle.Bold);
        Font f3 = new Font("Tahoma", 15, FontStyle.Bold);
        Pen p2 = new Pen(Color.Blue, 2);
        Pen p = new Pen(Color.Red, 3);
        Brush b = Brushes.Black;

        int i = 0;
        int k = 50;

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            i = i + k;
            g.DrawString("Hóa Đơn Bán Hàng", f2, b, 250, i);
            g.DrawString("Tên Sản phẩm", f3, b, 50, i + 60);
            g.DrawString("Số Lượng", f3, b, 400, i + 60);
            g.DrawString("Giá Tiền", f3, b, 550, i + 60);
            g.DrawString("Thành Tiền", f3, b, 670, i + 60);
            foreach (Product p in listProduct)
            {
                i = i + k;
                g.DrawString(p.Name, f, b, 50, i + 60);
                g.DrawString(p.Quantity.ToString(), f, b, 400, i + 60);
                g.DrawString(p.Price.ToString("0.0000"), f, b, 550, i + 60);
                g.DrawString("" + (p.Price * p.Quantity), f, b, 670, i + 60);
                i += 20;
                g.DrawString("----------------------------------------------------------------------------------------------------------------------", f, b, 50, i + 60);
            }
        }
    }
}
