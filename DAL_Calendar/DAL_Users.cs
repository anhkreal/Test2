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
    public class DAL_Users : DBQuanLy
    {
        private static DAL_Users _instance;

        public static DAL_Users Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new DAL_Users();
                return _instance;
            }
            private set { _instance = value; }
        }

        private DAL_Users() { }

        public DataTable getUsers()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Users", _conn);
            DataTable dtUsers = new DataTable();
            da.Fill(dtUsers);
            return dtUsers;
        }
        public bool themUser(DTO_Users u)
        {
            try
            {
                _conn.Open();
                string sql = string.Format("insert Users values ('{0}')", u.Username);
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
        public bool suaUser(DTO_Users u)
        {
            try
            {
                _conn.Open();
                string sql = string.Format("update Users set Username = '{0}' where U_ID = {1}",u.Username, u.U_ID);
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
        public bool xoaUser(int u)
        {
            try
            {
                _conn.Open();
                string sql = string.Format("delete from Users where U_ID = {0}", u);
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
        public int FindByUserName(string u)
        {
            try
            {
                _conn.Open();
                string sql = string.Format("select * from Users where Username = '{0}'", u);
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader r = cmd.ExecuteReader();
                while(r.Read())
                {
                    return Int16.Parse(r["U_ID"].ToString());
                }
                return -1;
            }
            catch(Exception ex)
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
