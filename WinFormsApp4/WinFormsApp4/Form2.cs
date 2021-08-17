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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            ketnoicsdl();
        }
        
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F1EG3ID\SQLEXPRESS;Initial Catalog=StudentManagement;Integrated Security=True");
        private void ketnoicsdl()
        {
            con.Open();
            string sql = "select * from KhoaHoc";  // lay het du lieu trong bang sinh vien
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            adapter.Fill(dt);  // đổ dữ liệu vào kho
            con.Close();  // đóng kết nối
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview

            textBox1.DataBindings.Clear();
            textBox1.DataBindings.Add("text", dataGridView1.DataSource, "MaKhoa");

            textBox3.DataBindings.Clear();
            textBox3.DataBindings.Add("text", dataGridView1.DataSource, "TenKhoa");

            textBox2.Text = dataGridView1.Rows.Count.ToString();

            textBox4.DataBindings.Clear();
            textBox4.DataBindings.Add("text", dataGridView1.DataSource, "ID");
            
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "INSERT INTO KhoaHoc (MaKhoa,TenKhoa) VALUES(@maKhoa, @tenKhoa)";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@maKhoa", textBox1.Text);
            command.Parameters.AddWithValue("@tenKhoa", textBox3.Text);
            try
            {
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
            con.Open();
            String query = "UPDATE KhoaHoc SET MaKhoa = N'" +textBox1.Text+ "', TenKhoa = N'" +textBox3.Text+ "' WHERE ID = "+ 1 + "";
            SqlCommand command = new SqlCommand(query, con);
            try
            {
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
            string query = "DELETE FROM  KhoaHoc WHERE ID = @ID";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@ID", textBox4.Text);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
