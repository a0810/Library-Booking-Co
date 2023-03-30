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
                MessageBox.Show("Incorrect ID or Password");


            }
            else
            {
                 Logtrue = newLogin.UserLogIn(UsID,Pword);

            }
            return Logtrue;
        }
    }
}
