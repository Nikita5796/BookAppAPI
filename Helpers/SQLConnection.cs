using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace demoAuthApp.Helpers
{
    public class SQLConnection
    {
        public SqlConnection GetConnection()
        {
            string str = "data source=NIKITAT-MSD2\\SQLEXPRESS2014; initial catalog=BookAppDB; integrated security=true";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            return con;
        }
    }
}
