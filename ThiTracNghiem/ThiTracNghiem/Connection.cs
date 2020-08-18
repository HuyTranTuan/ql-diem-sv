using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ThiTracNghiem
{
    class Connection
    {
        private SqlConnection Conn;
        private SqlCommand cmd;
        private SqlDataReader dt;
        private string _error;
        public static SqlConnection sql(string servername)
        {
            Program.constr = "Data Source="+servername+ ";Initial Catalog=QL_DSV;Persist Security Info=True;User ID=sa;Password=123456";
            SqlConnection Conn = new SqlConnection(Program.constr);
            return Conn;
        }
        

    }
}
