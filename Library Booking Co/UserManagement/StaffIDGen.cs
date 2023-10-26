using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Library_Booking_Co.UserManagement
{
    class StaffIDGen
    {
        public string StaffID()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"LibraryUsers.xml"); // 
            Random random = new Random();
            var IDBuild = new System.Text.StringBuilder();
            string charPool = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numPool = @"1234567890";
            string symPool = @"-_";
            int rand1 = random.Next(4, 7);
            int rand2 = random.Next(4, 6);
            int randSym1 = random.Next(0, 2);

            bool looper = true;
            string ID = "";
            while (looper == true)
            {

                for (int i = 0; i < rand1; i++)
                {
                    int picker = random.Next(0, 25);
                    IDBuild.Append(charPool[picker]);
                }
                IDBuild.Append(symPool[randSym1]);
                for (int i = 0; i < rand2; i++)
                {
                    int picker = random.Next(0, 9);
                    IDBuild.Append(numPool[picker]);
                }

                ID = IDBuild.ToString();


                XmlNode nodeCheck = doc.SelectSingleNode("//staff[ID='" + ID + "']");
                if (nodeCheck == null)
                {
                    looper = false;
                }
                else
                {
                }

            }
            return ID;
        }
    }
}
