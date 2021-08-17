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

namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ketnoicsdl();
            showBox();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F1EG3ID\SQLEXPRESS;Initial Catalog=QuanLySinhVien;Integrated Security=True");

        private void ketnoicsdl()
        {
            con.Open();
            string sql = "select * from SinhVien";  // lay het du lieu trong bang sinh vien
            SqlDataAdapter adapter = new SqlDataAdapter(sql,con); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            adapter.Fill(dt);  // đổ dữ liệu vào kho
            con.Close();  // đóng kết nối
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
        }
        private void showBox()
        {
            con.Open();
            string sql = "select * from LopHoc";  // lay het du lieu trong bang sinh vien
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con); //chuyen du lieu ve
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "className";
            comboBox1.ValueMember = "classID";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            String insert = "INSERT INTO SinhVien (name,age,email,classID) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "'," + Convert.ToInt32(comboBox1.SelectedValue) + ")";
            SqlCommand command = new SqlCommand(insert, con);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show("Error : "+se);
            }
            finally
            {
                con.Close();
            }
            
        }
    }
}
