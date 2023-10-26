using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Library_Booking_Co.UserManagement
{
    class userIDgen
    {
        public string UserIDgen()
        {
            string ID = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(@"LibraryUsers.xml"); // 
            Random random = new Random();
            var identifier = new System.Text.StringBuilder();
            bool looper = true;
            while (looper == true)
            {
                for (int i = 0; i < 11; i++)
                {
                    int randIterator = random.Next(0, 9);
                    identifier.Append(randIterator.ToString());

                }
                ID = identifier.ToString();
                string check = ID.Substring(0, 10);

                if (check.Equals("0000000000"))
                {
                }
                else
                {
                    XmlNode nodeCheck = doc.SelectSingleNode("//user[ID='" + ID + "']");// change to user
                    if (nodeCheck == null)
                    {
                        looper = false;
                    }
                    else
                    {
                    }

                }

            }
            return ID;
        }
    }
}
