using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Learn_again
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            showBox();
            csdl();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F1EG3ID\SQLEXPRESS;Initial Catalog=Learn_again;Integrated Security=True");

        public void csdl()
        {
            con.Open();
            string sql = "select MaSP,TenSP,tblNhanHieu.TenNH,NgaySX,NgayHH,DonVi,DonGia,GhiChu from tblMatHang inner join tblNhanHieu On tblMatHang.MaNH = tblNhanHieu.MaNH";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dgvDanhSach.DataSource = dt;

            textBox1.DataBindings.Clear();
            textBox1.DataBindings.Add("text", dgvDanhSach.DataSource, "MaSP");

            textBox2.DataBindings.Clear();
            textBox2.DataBindings.Add("text", dgvDanhSach.DataSource, "TenSP");

            comboBox1.DataBindings.Clear();
            comboBox1.DataBindings.Add("text", dgvDanhSach.DataSource, "TenNH");

            dateTimePicker1.DataBindings.Clear();
            dateTimePicker1.DataBindings.Add("text", dgvDanhSach.DataSource, "NgaySX");

            dateTimePicker2.DataBindings.Clear();
            dateTimePicker2.DataBindings.Add("text", dgvDanhSach.DataSource, "NgayHH");

            textBox3.DataBindings.Clear();
            textBox3.DataBindings.Add("text", dgvDanhSach.DataSource, "DonVi");

            textBox4.DataBindings.Clear();
            textBox4.DataBindings.Add("text", dgvDanhSach.DataSource, "DonGia");

            richTextBox1.DataBindings.Clear();
            richTextBox1.DataBindings.Add("text", dgvDanhSach.DataSource, "GhiChu");
        }
        string action;
        public void able()
        {
            button1.Enabled = true;
            button2.Enabled = true;
        }
        public void disalbe()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            grbChiTiet.Text = "Chi tiết";
        }
        private void showBox()
        {
            con.Open();
            string sql = "Select * from tblNhanHieu";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "TenNH";
            comboBox1.ValueMember = "MaNH";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            con.Close();
        }

        public void ClearAllText(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else
                    ClearAllText(c);
            }
            comboBox1.Text = "";
            richTextBox1.Text = "";
        }

        private void add()
        {
            string sql = "INSERT INTO tblMatHang(MaSP,TenSP ,MaNH, NgaySX, NgayHH, DonVi,DonGia,GhiChu) values (@MaSP,@TenSP,@MaNH,@NgaySX,@NgayHH, @DonVi,@DonGia,@GhiChu) ";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@MaSP", textBox1.Text);
            com.Parameters.AddWithValue("@TenSP", textBox2.Text);
            com.Parameters.AddWithValue("@MaNH", comboBox1.SelectedValue);
            com.Parameters.AddWithValue("@NgaySX", dateTimePicker1.Value);
            com.Parameters.AddWithValue("@NgayHH", dateTimePicker2.Value);
            com.Parameters.AddWithValue("@DonVi", textBox3.Text);
            com.Parameters.AddWithValue("@DonGia", Decimal.Parse(textBox4.Text));
            com.Parameters.AddWithValue("@GhiChu", richTextBox1.Text);

            try
            {
                con.Open();
                com.ExecuteNonQuery();
                MessageBox.Show("Insert Successfully");
                con.Close();
                csdl();
            }
            catch (SqlException se)
            {
                MessageBox.Show("Error Generated. Details: " + se.ToString());
            }
        }

        private void update()
        {
            string query = "UPDATE tblMatHang SET TenSP = N'" + textBox2.Text + "', MaNH = N'" + comboBox1.SelectedValue + "'," +
                " NgaySX ='" + Convert.ToDateTime(dateTimePicker1.Text) + "', NgayHH = N'" + Convert.ToDateTime(dateTimePicker2.Text) +
                "',DonVi = '" + textBox3.Text + "',DonGia = '" + textBox4.Text + "',GhiChu = '" + richTextBox1.Text + "' WHERE MaSP = @MaSP";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@MaSP", textBox1.Text);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully");
                con.Close();
                csdl();
            }
            catch (SqlException se)
            {
                MessageBox.Show("Error Generated. Details: " + se.ToString());
            }
        }

        private void delete()
        {
            string query = "DELETE FROM tblMatHang WHERE MaSP = @MaSP";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@MaSP", textBox1.Text);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully");
                con.Close();
                csdl();
            }
            catch (SqlException se)
            {
                MessageBox.Show("Error Generated. Details: " + se.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            grbChiTiet.Text = "THÊM MẶT HÀNG";
            ClearAllText(this);
            able();
            button4.Enabled = false;
            button5.Enabled = false;
            action = "thêm";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            grbChiTiet.Text = "CẬP NHẬT MẶT HÀNG";
            ClearAllText(this);
            able();
            button3.Enabled = false;
            button5.Enabled = false;
            action = "sửa";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            grbChiTiet.Text = "XOÁ MẶT HÀNG";
            ClearAllText(this);
            able();
            button4.Enabled = false;
            button3.Enabled = false;
            action = "xóa";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will close down the whole application. Confirm?", "Close Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show("The application has been closed successfully.", "Application Closed!", MessageBoxButtons.OK);
                this.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (action)
            {
                case "thêm":
                    add();
                    confirm();
                    break;
                case "sửa":
                    update();
                    confirm();
                    break;
                case "xóa":
                    delete();
                    confirm();
                    break;
                default:
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            confirm();
        }

        public void confirm()
        {
            disalbe();
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }
    }
}
