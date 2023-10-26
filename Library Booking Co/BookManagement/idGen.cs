using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Library_Booking_Co.BookManagement
{
    class idGen
    {
        public string IDgen()
        {
            string ID = "";
            XmlDocument doc = new XmlDocument();
            doc.Load("BookInventory.xml");
            Random random = new Random();
            var identifier = new System.Text.StringBuilder();
            bool looper = true;
            while (looper == true)
            {
                for (int i = 0; i < 10; i++)
                {
                    int randIterator = random.Next(0, 9);
                    identifier.Append(randIterator.ToString());

                }
                ID = identifier.ToString();
                string check = ID.Substring(0, 9);

                if (check.Equals("000000000"))
                {
                }
                else
                {
                    XmlNode nodeCheck = doc.SelectSingleNode("//book[ID='" + ID + "']");
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
