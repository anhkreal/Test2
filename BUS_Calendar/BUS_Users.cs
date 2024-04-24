using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Calendar;
using DTO_Calendar;

namespace BUS_Calendar
{
    public class BUS_Users
    {
        private static BUS_Users _instance;
        public static BUS_Users Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BUS_Users();
                return _instance;
            }
            private set { _instance = value; }
        }
        private BUS_Users() { }
        public DataTable getUsers()
        {
            return DAL_Users.Instance.getUsers();
        }
        public bool themUser(DTO_Users da)
        {
            return DAL_Users.Instance.themUser(da);
        }
        public bool suaUser(DTO_Users da)
        {
            return DAL_Users.Instance.suaUser(da);
        }
        public bool xoaUser(int da)
        {
            return DAL_Users.Instance.xoaUser(da);
        }
        public int timUser(string da)
        {
            return DAL_Users.Instance.FindByUserName(da);
        }
    }
}
