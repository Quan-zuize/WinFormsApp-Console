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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            showBox();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F1EG3ID\SQLEXPRESS;Initial Catalog=Learn_again;Integrated Security=True");

        public void csdl()
        {
            con.Open();
            string sql = "select tblOrder.Id,tblProduct.Name,Quantity,Note,CusName,CusMobile,CusAddress from tblOrder inner join tblProduct On tblOrder.ProductId = tblProduct.Id";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void showBox()
        {
            con.Open();
            string sql = "Select * from tblProduct";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            con.Close();
        }

        private void add()
        {
            con.Open();
            using var command = new SqlCommand();
            command.Connection = con;
            
            string sql = "Select Id from tblProduct where Name = @ProductName";
            command.CommandText = sql;
            command.Parameters.AddWithValue("@ProductName", comboBox1.Text);
            var ProductId = command.ExecuteScalar();

            string sqlinsert = "insert into tblorder(productid, quantity, note, cusname, cusmobile, cusaddress) values (@productid,@quantity,@note,@custname,@custmobile, @custaddress) ";
            SqlCommand com = new SqlCommand(sqlinsert, con);

            com.Parameters.AddWithValue("@productid", $"{ProductId}");
            com.Parameters.AddWithValue("@quantity", textBox3.Text);
            com.Parameters.AddWithValue("@note", textBox5.Text);
            com.Parameters.AddWithValue("@custname", textBox1.Text);
            com.Parameters.AddWithValue("@custmobile", textBox2.Text);
            com.Parameters.AddWithValue("@custaddress", textBox4.Text);

            com.ExecuteNonQuery();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            csdl();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string message = "";
            if (Int32.Parse(textBox3.Text) < 0)
                message += "Quantity must be greater than 0\n";
            if (String.IsNullOrEmpty(comboBox1.SelectedValue.ToString()))
                message += "Product name is required\n";
            if (String.IsNullOrWhiteSpace(textBox1.Text))
                message += "Customer's name is empty\n";
            if (String.IsNullOrWhiteSpace(textBox2.Text))
                message += "Customer's phone number is empty\n";
            if (String.IsNullOrWhiteSpace(textBox4.Text))
                message += "Customer's address is empty\n";

            if (message != "")
            {
                MessageBox.Show(message);
            }
            else
            {
                add();
                csdl();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will close down the whole application. Confirm?", "Close Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show("The application has been closed successfully.", "Application Closed!", MessageBoxButtons.OK);
                this.Dispose();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
