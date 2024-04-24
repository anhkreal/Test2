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
    public class DAL_Appointment : DBQuanLy
    {
        private static DAL_Appointment _instance;
        public static DAL_Appointment Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DAL_Appointment();
                return _instance;
            }
            private set { _instance = value; }
        }
        private DAL_Appointment() { }
        public DataTable getAppointment()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Appointment", _conn);
            DataTable dtAppointment = new DataTable();
            da.Fill(dtAppointment);
            return dtAppointment;
        }
        public bool themAppointment(DTO_Appointment a)
        {
            try
            {
                _conn.Open();
                string sql = string.Format("insert Appointment values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", 
                    a.Title, a.StartTime.ToString("yyyy-MM-dd HH:mm:ss"), a.FinishTime.ToString("yyyy-MM-dd HH:mm:ss"), a.LocationAddress, a.EnableAlarm ? '1' : '0', a.GapTime);
                Console.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, _conn);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("exception");
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool suaAppointment(DTO_Appointment a)
        {
            try
            {
                _conn.Open();
                string sql = string.Format("update Appointment set Title = '{0}', StartTime = '{1}', FinishTime = '{2}', LocationAddress = '{3}', EnableAlarm = '{4}', GapTime = '{5}' where A_ID = {6}", 
                    a.Title, a.StartTime.ToString("yyyy-MM-dd HH:mm:ss"), a.FinishTime.ToString("yyyy-MM-dd HH:mm:ss"), a.LocationAddress, a.EnableAlarm, a.GapTime, a.A_ID);
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
        public bool xoaAppointment(int a)
        {
            try
            {
                _conn.Open();
                string sql = string.Format("delete from Appointment where A_ID = {0}", a);
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
        public int FindByTitle(string t)
        {
            try
            {
                _conn.Open();
                string sql = string.Format("select * from Appointment where Title = '{0}'", t);
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    return Int16.Parse(r["A_ID"].ToString());
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
