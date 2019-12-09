using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLySV
{
    class DataConnection
    {
        string ConnectionStr;
        public DataConnection()
        {
            ConnectionStr = "Data Source = DESKTOP\\SQLEXPRESS; Initial Catalog = QLSV; Integrated Security = true;";
        }
        public SqlConnection ConnectData()
        {
            return new SqlConnection(ConnectionStr);
        }
    }
}
