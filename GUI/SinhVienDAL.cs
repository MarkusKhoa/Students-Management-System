using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace QuanLySV
{
    class SinhVienDAL
    {
        DataConnection dc;
        SqlDataAdapter dataAdapter;
        SqlCommand cmd;
        Form1 act;
        public SinhVienDAL()
        {
            dc = new DataConnection();

        }
        public DataTable SelectAllStudents()
        {
            //Tạo câu lệnh để lấy toàn bộ thông tin của sinh viên
            string sql = "SELECT * FROM SINHVIEN";
            //Mở 1 kết nối
            SqlConnection sqlCon = dc.ConnectData();
            //Khởi tạo đối tượng cho lớp SQLAdapter
            dataAdapter = new SqlDataAdapter(sql, sqlCon);
            //Mở kết nối
            sqlCon.Open();
            //Đổ dữ liệu vào Database
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            //Ngắt kết nối
            sqlCon.Close();
            return table;
        }
        public bool InsertSinhVien(SinhVien sv)
        {
            SqlConnection con = dc.ConnectData();
            string sql = "INSERT INTO SINHVIEN(HoTen, MSSV, Lop, NgaySinh, Email, GioiTinh, SoDT, MaVung) VALUES (@HoTen, @MSSV, @Lop, @NgaySinh, @Email, @GioiTinh, @SoDT, @MaVung)";
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = sv.HoTen;
                cmd.Parameters.Add("@MSSV", SqlDbType.NVarChar).Value = sv.MSSV;
                cmd.Parameters.Add("@Lop", SqlDbType.NVarChar).Value = sv.Lop;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = sv.NgaySinh;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = sv.Email;
                cmd.Parameters.Add("@SoDT", SqlDbType.Int).Value = sv.SoDT;
                if (act.Male_SV.Checked)
                {
                    cmd.Parameters.AddWithValue("@GioiTinh", "Nam");
                }
                if (act.Female_SV.Checked)
                {
                    cmd.Parameters.AddWithValue("@GioiTinh", "Nữ");
                }
                if (act.Unidentified_SV.Checked)
                {
                    cmd.Parameters.AddWithValue("@GioiTinh", "Chưa xác định");
                }
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                e.ToString();
                return false;
            }
            return true;
        }
        public bool UpdateSinhVien(SinhVien sv)
        {
            string sql = "UPDATE SINHVIEN SET HoTen = @HoTen, MSSV = @MSSV, Lop = @Lop, NgaySinh = @NgaySinh, Email = @Email, SoDT = @SoDT ";
            SqlConnection con = dc.ConnectData();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = sv.HoTen;
                cmd.Parameters.Add("@MSSV", SqlDbType.NVarChar).Value = sv.MSSV;
                cmd.Parameters.Add("@Lop", SqlDbType.NVarChar).Value = sv.Lop;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = sv.NgaySinh;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = sv.Email;
                if (act.Male_SV.Checked)
                {
                    cmd.Parameters.AddWithValue("@Gender", "Nam");
                }
                else if (act.Female_SV.Checked)
                {
                    cmd.Parameters.AddWithValue("@Gender", "Nữ");
                }
                else if (act.Unidentified_SV.Checked)
                {
                    cmd.Parameters.AddWithValue("@Gender", "Chưa xác định");
                }
                cmd.Parameters.Add("@SoDT", SqlDbType.Int).Value = sv.SoDT;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                e.ToString();
                return false;
            }
            return true;
        }
        public bool DeleteSinhVien(SinhVien sv)
        {
            string sql = "DELETE SINHVIEN WHERE MSSV = @MSSV";
            SqlConnection con = dc.ConnectData();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MSSV", SqlDbType.NVarChar).Value = sv.MSSV;

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                e.ToString();
                return false;
            }
            return true;
        }
    }
}