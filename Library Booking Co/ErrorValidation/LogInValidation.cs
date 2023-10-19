using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Library_Booking_Co
{
    class LogInValidation
    {
        public bool UserIDandPword(string UsID,string Pword)
        {
            LogInControl newLogin = new LogInControl();
            bool Logtrue = false;

            if (string.IsNullOrEmpty(UsID)|| string.IsNullOrEmpty(Pword))
            {
             


            }
            else
            {
                 Logtrue = newLogin.UserLogIn(UsID,Pword);

            }
            return Logtrue;
        }
        public bool StaffIDandPword(string StID, string Pword)
        {
            LogInControl newLogin = new LogInControl();
            bool Logtrue = false;

            if (string.IsNullOrEmpty(StID) || string.IsNullOrEmpty(Pword))
            {
               


            }
            else
            {
                Logtrue = newLogin.StaffLogIn(StID, Pword);

            }
            return Logtrue;
        }
    }
}
