using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Calendar;

namespace DAL_Calendar
{
    public class DAL_GroupMeeting : DBQuanLy
    {
        private static DAL_GroupMeeting _instance;
        public static DAL_GroupMeeting Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new DAL_GroupMeeting();
                return _instance;
            }
            private set { _instance = value; }
        }
        private DAL_GroupMeeting() { }
        public DataTable getGroupMeeting()
        {
            _conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from GroupMeeting", _conn);
            DataTable tmp = new DataTable();
            da.Fill(tmp);
            DataTable dtGroupMeeting = new DataTable();
            try
            {
               // string query = "select * from GroupMeeting";
                //SqlCommand sql = new SqlCommand(query, _conn);
                //SqlDataReader r = sql.ExecuteReader();  // record list
                dtGroupMeeting.Columns.AddRange(new DataColumn[]
                {
                new DataColumn{ColumnName = "G_ID", DataType = typeof(int)},
                new DataColumn{ColumnName = "Title", DataType = typeof(string)},
                new DataColumn{ColumnName = "Username", DataType = typeof(string)},
                });
                //while (r.Read())
                foreach(DataRow dr in tmp.Rows)
                {
                    int id = Int16.Parse(dr["G_ID"].ToString());
                    //string query1 = "select * from Appointment where A_ID = " + r["A_ID"].ToString();
                    //string query2 = "select * from Users where U_ID = " + r["U_ID"].ToString();
                    //SqlCommand sql1 = new SqlCommand(query1, _conn);
                    //SqlCommand sql2 = new SqlCommand(query2, _conn);
                    //SqlDataReader r1 = sql1.ExecuteReader();
                    //SqlDataReader r2 = sql2.ExecuteReader();
                    //r1.Read(); r2.Read();
                    //dtGroupMeeting.Rows.Add(id, r1["Title"].ToString(), r2["Username"].ToString());
                    SqlDataAdapter da1 = new SqlDataAdapter("select Title from Appointment where A_ID = " + dr["A_ID"].ToString(), _conn);
                    DataTable tmp1 = new DataTable();
                    da1.Fill(tmp1);
                    SqlDataAdapter da2 = new SqlDataAdapter("select Username from Users where U_ID = " + dr["U_ID"].ToString(), _conn);
                    DataTable tmp2 = new DataTable();
                    da2.Fill(tmp2);
                    string t = (tmp1.Rows[0])["Title"].ToString();
                    string n = (tmp2.Rows[0])["Username"].ToString();
                    dtGroupMeeting.Rows.Add(id, t, n);
            }
            }
            catch (Exception ex)
            {
                
            }
            _conn.Close();
            return dtGroupMeeting;
        }
        public bool themGroupMeeting(DTO_GroupMeeting g)
        {
            try
            {
                _conn.Open();
                string sql = string.Format("insert GroupMeeting values ('{0}', '{1}')", g.A_ID, g.U_ID);
                SqlCommand cmd = new SqlCommand(sql, _conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool suaGroupMeeting(DTO_GroupMeeting g)
        {
            try
            {
                _conn.Open();
                string sql = string.Format("update GroupMeeting set A_ID = {0}, U_ID = {1} where G_ID = {2}", g.A_ID , g.U_ID, g.G_ID);
                SqlCommand cmd = new SqlCommand(sql, _conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool xoaGroupMeeting(int g)
        {
            try
            {
                _conn.Open();
                string sql = string.Format("delete from GroupMeeting where G_ID = {0}", g);
                SqlCommand cmd = new SqlCommand(sql, _conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public int FindByUserNameAppointment(int u, int a)
        {
            try
            {
                _conn.Open();
                string sql = string.Format("select * from GroupMeeting where U_ID = {0} and A_ID = {1}", u, a);
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    return Int16.Parse(r["G_ID"].ToString());
                }
                return -1;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _conn.Close();
            }
            return -1;
        }
    }
}
