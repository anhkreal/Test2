using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Calendar
{
    public class DTO_Users
    {
        private int _U_ID;
        private string _Username;
        public int U_ID
        {
            get { return _U_ID; }
            set { _U_ID = value; }
        }
        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }
        public DTO_Users(int id, string name)
        {
            this._U_ID = id;
            this.Username = name;
        }
        public DTO_Users(DataRow dr)
        {
            // declare here
        }
    }
}
