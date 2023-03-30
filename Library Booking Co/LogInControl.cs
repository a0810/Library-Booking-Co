using Library_Booking_Co.UserWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace Library_Booking_Co
{
    class LogInControl
    {
        public bool UserLogIn(string UsID,string Password)
        {
            bool LogInSuccessful = false;
           
            XmlDocument doc = new XmlDocument();
            doc.Load(@"LibraryUsers.xml");
            XmlNode nodes = doc.SelectSingleNode("/libraryMembers/user[ID='" + UsID + "']");

            if (nodes == null)
            {
                MessageBox.Show("Incorrect ID or Password");

            }
            else
            {
                string UserID = nodes.ChildNodes.Item(6).InnerText;
                string UserPword = nodes.ChildNodes.Item(9).InnerText;
                if (UsID == UserID && Password == UserPword)
                {
                    LogInSuccessful = true;



                }
                else
                {
                    MessageBox.Show("Incorrect ID or Password");

                }
            }
            return LogInSuccessful;




        }

        
        internal void UserLogin()
        {
            throw new NotImplementedException();
        }
    }
}
