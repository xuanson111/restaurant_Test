using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Controls
{
    internal class ctrMonAn
    {
        string strConn = ConfigurationManager.ConnectionStrings["restaurantCONN"].ConnectionString;
        private SqlConnection conn;
        public ctrMonAn()
        {
            conn = new SqlConnection(strConn);
        }

        public SqlConnection GetConnection()
        {
            return conn;
        }

        public DataTable getData(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                conn.Close();
                return dt;
            } catch(Exception ex)
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
