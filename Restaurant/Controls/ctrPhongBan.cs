using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Restaurant.Modals;
using RJCodeAdvance.RJControls;

namespace Restaurant.Controls
{
    internal class ctrPhongBan
    {
        string mainConn = ConfigurationManager.ConnectionStrings["restaurantCONN"].ConnectionString;
        SqlConnection conn;

        public SqlConnection getConnetion()
        {
            return conn;
        }
        public ctrPhongBan()
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
            } catch (Exception ex)
            {
                return null;
            }
        }

        public SqlDataReader getDataReader(string query)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rd = cmd.ExecuteReader();
                conn.Close();
                return rd;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public List<Modals.PhongBan> getDataList()
        {
            try
            {
                string query = "select * from PhongBan";
                List<Modals.PhongBan> lst = new List<PhongBan>();
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Modals.PhongBan row = new Modals.PhongBan();
                    row.SoBan1 = rd["SoBan"].ToString();
                    row.Tang1 = rd["Tang"].ToString();
                    row.Loai1 = rd["Loai"].ToString();
                    lst.Add(row);
                }
                return lst;
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
