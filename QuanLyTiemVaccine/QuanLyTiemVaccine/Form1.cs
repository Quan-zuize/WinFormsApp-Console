using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QRCoder;

namespace QuanLyTiemVaccine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            ketnoicsdl();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F1EG3ID\SQLEXPRESS;Initial Catalog=VaccinTreat;Integrated Security=True");
        string id;
        private void ketnoicsdl()
        {
            //con.Open();
            //string sql = "select * from Vaccine";  
            //SqlDataAdapter adapter = new SqlDataAdapter(sql,con);
            //DataTable table = new DataTable();
            //table.Clear();
            //adapter.Fill(table);  
            //con.Close();  
            //dataGridView1.DataSource = table;
            DataSet1.VaccineDataTable ds= new DataSet1.VaccineDataTable();
            DataSet1TableAdapters.VaccineTableAdapter adapter = new DataSet1TableAdapters.VaccineTableAdapter();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds;

            textBox1.DataBindings.Clear();
            textBox1.DataBindings.Add("text", dataGridView1.DataSource, "Name");

            textBox2.DataBindings.Clear();
            textBox2.DataBindings.Add("text", dataGridView1.DataSource, "Code");

            textBox3.DataBindings.Clear();
            textBox3.DataBindings.Add("text", dataGridView1.DataSource, "CCCD");

            dateTimePicker1.DataBindings.Clear();
            dateTimePicker1.DataBindings.Add("text", dataGridView1.DataSource, "NgayTiem");

            textBox4.DataBindings.Clear();
            textBox4.DataBindings.Add("text", dataGridView1.DataSource, "Gmail");

            textBox5.DataBindings.Clear();
            textBox5.DataBindings.Add("text", dataGridView1.DataSource, "Address");
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Vaccine SET Name = N'" + textBox1.Text + "', Code = N'" + textBox2.Text + "'," +
                " NgayTiem ='" + Convert.ToDateTime(dateTimePicker1.Text) + "', CCCD = N'" + textBox3.Text + "',Gmail = '" + textBox4.Text + "',Address = '" + textBox5.Text + "' WHERE Id = " + id + "";
            SqlCommand command = new SqlCommand(query, con);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully");
                con.Close();
                ketnoicsdl();
            }
            catch (SqlException se)
            {
                MessageBox.Show("Error Generated. Details: " + se.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text + ", " + textBox2.Text + ", " + textBox3.Text + ", " + dateTimePicker1.Text + ", " + textBox4.Text + ", " + textBox5.Text;
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(str, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            pictureBox1.Image = code.GetGraphic(4, Color.Black, Color.White, false);
            toolStripStatusLabel1.Text = "Đã Gen mã QR";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            id = row.Cells[0].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Vaccine (Name,Code,NgayTiem,CCCD,Gmail,Address) VALUES('" + textBox1.Text + "',N'" + textBox2.Text + "',N'" + textBox3.Text + "','" + Convert.ToDateTime(dateTimePicker1.Text) + "',N'" + textBox4.Text + "','" + textBox5.Text + "')";
            SqlCommand command = new SqlCommand(query, con);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Inserted Successfully");
                con.Close();
                ketnoicsdl();
            }
            catch (SqlException se)
            {
                MessageBox.Show("Error Generated. Details: " + se.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            printDocument1.PrintPage += PrintDocument1_PrintPage;
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = printDocument1;
            ppd.ShowDialog();
        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font f = new Font("Tahoma", 12);
            Font f2 = new Font("Times New Roman", 24, FontStyle.Bold);
            Font f3 = new Font("Tahoma", 15, FontStyle.Bold);
            Pen p2 = new Pen(Color.Blue, 2);
            Pen p = new Pen(Color.Red, 3);
            Brush b = Brushes.Black;
            int y = 60;

            g.DrawString("Giấy chứng nhận tiêm phòng Vacin", f2, b, 150, y);
            g.DrawString("Mã bệnh nhân: " + textBox2.Text, f3, b, 50, y + 50);
            g.DrawString("Họ và Tên: " + textBox1.Text, f3, b, 50, y + 110);
            g.DrawString("Số CMNN: " + textBox3.Text, f3, b, 50, y + 160);
            g.DrawString("Ngày tiêm: " + dateTimePicker1.Text, f3, b, 50, y + 210);
            g.DrawString("Email: " + textBox4.Text, f3, b, 50, y + 260);
            g.DrawString("Địa chỉ: " + textBox5.Text, f3, b, 50, y + 310);
            g.DrawImage(pictureBox1.Image, 600, 120);
        }
    }
}
