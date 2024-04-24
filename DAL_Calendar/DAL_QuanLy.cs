using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Calendar
{
    public class DBQuanLy
    {
        protected SqlConnection _conn = new SqlConnection("Data Source=DESKTOP-SCUSLUI;Initial Catalog=CALENDAR;Integrated Security=True");
    }

}
