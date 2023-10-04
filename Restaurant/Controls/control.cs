using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Controls
{
    internal class control
    {
        string mainConn = ConfigurationManager.ConnectionStrings["restaurantCONN"].ConnectionString;
        SqlConnection conn;

        public SqlConnection getConnetion()
        {
            return conn;
        }
        public control()
        {
            conn = new SqlConnection(mainConn);
        }

        public DataTable getData(string query)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool execute(string query)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                int r = cmd.ExecuteNonQuery();
                conn.Close();
                return r > 0;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }
    }
}
