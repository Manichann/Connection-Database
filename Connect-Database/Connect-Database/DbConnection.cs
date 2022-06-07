using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Connect_Database
{
    internal class DbConnection
    {
        public SqlConnection Conn = new SqlConnection("Data Sourse=DESKTOP-TFACJ9R\\SQLEXPRESS;Initial Catalog=testC#;Intergrated Security=True");
        public SqlDataAdapter Adapter;
        public DataSet ds;

        public void Query(String sql)
        {
            if(Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
            Conn.Open();
            try
            {
                Adapter = new SqlDataAdapter(sql, Conn);
                ds = new DataSet();
                Adapter.Fill(ds,"emp");
                Conn.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
