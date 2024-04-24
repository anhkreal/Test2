using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Calendar
{
    public class DTO_Appointment
    {
        private int _A_ID;
        private string _Title;
        private DateTime _StartTime;
        private DateTime _FinishTime;
        private string _LocationAddress;
        private bool _EnableAlarm;
        private TimeSpan _GapTime;

        public int A_ID
        {
            get { return _A_ID; }
            set { _A_ID = value; }
        }
        public string Title
        {   get { return _Title; } 
            set { _Title = value; } 
        }
        public DateTime StartTime
        {
            get { return _StartTime; }
            set { _StartTime = value; }
        }
        public DateTime FinishTime
        {
            get { return _FinishTime; }
            set { _FinishTime = value; }
        }
        public string LocationAddress
        {
            get { return _LocationAddress; }
            set { _LocationAddress = value; }
        }
        public bool EnableAlarm
        {
            get { return _EnableAlarm; }
            set { _EnableAlarm = value; }
        }
        public TimeSpan GapTime
        {
            get { return _GapTime; }
            set { _GapTime = value; }
        }
        public DTO_Appointment(int id, string title, DateTime s, DateTime f, string l, bool e, TimeSpan t)
        {
            this.A_ID = id;
            this.Title = title;
            this.StartTime = s;
            this.FinishTime = f;
            this.LocationAddress = l;
            this.EnableAlarm= e;
            this.GapTime = t;
        }

        public DTO_Appointment(DataRow dr)
        {
            // declare here
        }
    }
}
