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

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ketnoicsdl();
        }   

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F1EG3ID\SQLEXPRESS;Initial Catalog=StudentManagement;Integrated Security=True");
        private void ketnoicsdl()
        {
            con.Open();
            string sql = "select * from Sinh_Vien";  // lay het du lieu trong bang sinh vien
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            adapter.Fill(dt);  // đổ dữ liệu vào kho
            con.Close();  // đóng kết nối
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview

            textBox1.DataBindings.Clear();
            textBox1.DataBindings.Add("text", dataGridView1.DataSource, "MaSV");

            textBox2.DataBindings.Clear();
            textBox2.DataBindings.Add("text", dataGridView1.DataSource, "HoSV");

            textBox3.DataBindings.Clear();
            textBox3.DataBindings.Add("text", dataGridView1.DataSource, "TenSV");

            dateTimePicker1.DataBindings.Clear();
            dateTimePicker1.DataBindings.Add("text", dataGridView1.DataSource, "NgaySinh");

            textBox4.DataBindings.Clear();
            textBox4.DataBindings.Add("text", dataGridView1.DataSource, "GioiTinh");

            textBox5.DataBindings.Clear();
            textBox5.DataBindings.Add("text", dataGridView1.DataSource, "MaKhoa");
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Sinh_Vien (MaSV,HoSV,TenSV,NgaySinh,GioiTinh,MaKhoa) VALUES('" + textBox1.Text + "',N'" + textBox2.Text + "',N'" + textBox3.Text + "','" + Convert.ToDateTime(dateTimePicker1.Text) + "',N'" + textBox4.Text + "','" + textBox5.Text + "')";
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

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Sinh_Vien SET HoSV = N'" + textBox2.Text + "', TenSV = N'" + textBox3.Text + "'," +
                " NgaySinh ='" + Convert.ToDateTime(dateTimePicker1.Text) + "', GioiTinh = N'" + textBox4.Text + "',MaKhoa = '" + textBox5.Text + "' WHERE MaSV = " + textBox1.Text + "";
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

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM  Sinh_Vien WHERE MaSV ='" + textBox1.Text + "'";
            SqlCommand command = new SqlCommand(query, con);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully");
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
            Environment.Exit(0);
        }
    }
}
