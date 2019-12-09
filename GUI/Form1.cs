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

namespace QuanLySV
{
    public partial class Form1 : Form
    {
        SinhVienBLL SvBll;
        public Form1()
        {
            InitializeComponent();
            SvBll = new SinhVienBLL();
        }
        public void DisplayStudents()
        {
            DataTable table = SvBll.getAllStudents();
            dataGridView1.DataSource = table;
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            DisplayStudents();
        }

        public bool CheckData()
        {
            if(string.IsNullOrEmpty(SV_Name.Text))
            {
                MessageBox.Show("Bạn chưa nhập họ tên sinh viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SV_Name.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(Code_SV.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã số sinh viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SV_Name.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(Mail_SV.Text))
            {
                MessageBox.Show("Bạn chưa nhập email của sinh viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SV_Name.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(Phonenumber_SV.Text))
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại sinh viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SV_Name.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(Class_SV.Text))
            {
                MessageBox.Show("Bạn chưa nhập lớp mà sinh viên đang học", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SV_Name.Focus();
                return false;
            }
            //if (!dateTimePicker1.Checked)
            //{
            //    MessageBox.Show("Bạn chưa chọn ngày tháng năm sinh của sinh viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    dateTimePicker1.Focus();
            //    return false;
            //}
            if(!(Male_SV.Checked || Female_SV.Checked || Unidentified_SV.Checked))
            {
                MessageBox.Show("Bạn chưa chọn giới tính cho sinh viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //Sẽ xử lý sau
                return false;
            }
            //Xử lý Combobox sau
            return true;
        }

        public void Insert_SV_Click(object sender, EventArgs e)
        {
            if(CheckData())
            {
                SinhVien sv = new SinhVien();
                sv.HoTen = SV_Name.Text;
                sv.MSSV = Code_SV.Text;
                sv.Lop = Class_SV.Text;
                //sv.NgaySinh = DOB_SV.Text;
                sv.GioiTinh = Gender_SV.Text;
                sv.SoDT = int.Parse(Phonenumber_SV.Text);
                sv.Email = Email_SV.Text;
                //if(SvBll.InsertStudents(sv) == true)
                //{
                //    DisplayStudents();
                //}
                //else
                //{
                //    MessageBox.Show("Không thể thêm dữ liệu vào được!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }
    }
}