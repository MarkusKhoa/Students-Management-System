using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QuanLySV
{
    class SinhVienBLL
    {
        SinhVienDAL SvDal;
        public SinhVienBLL()
        {
            SvDal = new SinhVienDAL();
        }
        //Lấy toàn bộ dữ liệu của cac sinh viên
        public DataTable getAllStudents()
        {
            return SvDal.SelectAllStudents();
        }
        public bool InsertStudents(SinhVien sv)
        {
            return SvDal.InsertSinhVien(sv);
        }
        public bool UpdateStudents(SinhVien sv)
        {
            return SvDal.UpdateSinhVien(sv);
        }
        public bool DeleteSinhVien(SinhVien sv)
        {
            return SvDal.DeleteSinhVien(sv);
        }
    }
}
