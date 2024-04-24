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
    public class BUS_Appointment
    {
        private static BUS_Appointment _instance;
        public static BUS_Appointment Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new BUS_Appointment();
                return _instance;
            }
            private set { _instance = value; }
        }
        private BUS_Appointment() { }
        public DataTable getAppointment()
        {
            return DAL_Appointment.Instance.getAppointment();
        }
        public bool themAppointment(DTO_Appointment da)
        {
            return DAL_Appointment.Instance.themAppointment(da);
        }
        public bool suaAppointment(DTO_Appointment da)
        {
            return DAL_Appointment.Instance.suaAppointment(da);
        }
        public bool xoaAppointment(int da)
        {
            return DAL_Appointment.Instance.xoaAppointment(da);
        }
        public int timAppointment(string da)    // title
        {
            return DAL_Appointment.Instance.FindByTitle(da);
        }
    }
}
