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
    public class BUS_GroupMeeting
    {
        private static BUS_GroupMeeting _instance;
        public static BUS_GroupMeeting Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BUS_GroupMeeting();
                return _instance;
            }
            private set { _instance = value; }
        }
        private BUS_GroupMeeting() { }
        public DataTable getGroupMeeting()
        {
            return DAL_GroupMeeting.Instance.getGroupMeeting();
        }
        public bool themGroupMeeting(DTO_GroupMeeting da)
        {
            return DAL_GroupMeeting.Instance.themGroupMeeting(da);
        }
        public bool suaGroupMeeting(DTO_GroupMeeting da)
        {
            return DAL_GroupMeeting.Instance.suaGroupMeeting(da);
        }
        public bool xoaGroupMeeting(int da)
        {
            return DAL_GroupMeeting.Instance.xoaGroupMeeting(da);
        }
        public int timGroupMeeting(int u, int t)
        {
            return DAL_GroupMeeting.Instance.FindByUserNameAppointment(u, t);
        }
    }
}
