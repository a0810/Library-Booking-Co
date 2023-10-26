using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Booking_Co.UserManagement
{
    class Users
    {
        public string firstName { get; set; }
        public string surName { get; set; }
        public string DOB { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string dateOfIssue { get; set; }
        public string borrowedBooks { get; set; }
        public string savedBooks { get; set; }
        public string ID { get; set; }
        public string password { get; set; }
        public long phone { get; set; }
        public double balance { get; set; }
    }
}
