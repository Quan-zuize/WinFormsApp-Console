using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Learn_again
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        SinhVien sv = new SinhVien();

        private void Form1_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Name");
            dt.Columns.Add("Giới Tính");
            dt.Columns.Add("Lớp Học");
            dt.Columns.Add("Điểm tổng kết");
            dt.Columns.Add("Ngày tổng kết");
            dt.Columns.Add("Xếp hạng");
            dt.Columns.Add("Thành tích");
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sv.Name = textBox1.Text;
            sv.Sex = radioButton1.Checked ? radioButton1.Text : radioButton2.Text;
            sv.Class = comboBox1.Text;
            sv.FinalGrade = Double.Parse(numericUpDown1.Value.ToString());
            sv.FinalDate = dateTimePicker1.Value;
            sv.Rank = comboBox2.Text;
            sv.Achievements = richTextBox1.Text;

            insert();
        }

        public void insert()
        {
            string message = "";
            if (String.IsNullOrWhiteSpace(sv.Name))
            {
                message += "Name is required\n";
            }
            if (String.IsNullOrEmpty(sv.Class))
            {
                message += "Class is required\n";
            }
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                message += "Sex is required\n";
            }
            if (sv.FinalGrade < 0)
            {
                message += "Final grade >= 0\n";
            }
            if (sv.FinalDate > DateTime.Now)
            {
                message += "Final date must sooner than today\n";
            }

            if (message != "")
            {
                MessageBox.Show(message);
            }
            else
            {
                DataRow dr = dt.NewRow();
                dr[0] = sv.Name;
                dr[1] = sv.Sex;
                dr[2] = sv.Class;
                dr[3] = sv.FinalGrade;
                dr[4] = sv.FinalDate;
                dr[5] = sv.Rank;
                dr[6] = sv.Achievements;

                dt.Rows.Add(dr);
            }
        }
    }
}
