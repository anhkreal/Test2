using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Calendar
{
    public class DTO_GroupMeeting
    {
        private int _G_ID;
        private int _A_ID;
        private int _U_ID;
        public int G_ID
        {
            get { return _G_ID; }
            set { _G_ID = value; }
        }
        public int A_ID
        {
            get { return _A_ID; }
            set { _A_ID = value; }
        }
        public int U_ID
        {
            get { return _U_ID; }
            set { _U_ID = value; }
        }
        public DTO_GroupMeeting(int g, int a, int u) 
        {
            this.G_ID = g;
            this.A_ID = a;
            this.U_ID = u;
        }
        public DTO_GroupMeeting(DataRow dr)
        {
            // declare here
        }
    }
}
