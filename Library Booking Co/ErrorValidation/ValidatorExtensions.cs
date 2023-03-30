using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace Library_Booking_Co
{
    public static class ValidatorExtensions
    {
        public static bool IsValidEmailAddress(this string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }

        public static bool DoesEmailExist(this string f)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(@"LibraryUsers.xml");

            bool looper = true;
            bool emailExist = false;
            while (looper == true)
            {

                XmlNode nodeCheck = doc.SelectSingleNode("//user[email='" + f + "']");
                if (nodeCheck == null)
                {
                    emailExist = false;
                    looper = false;
                }
                else
                {
                    emailExist = true;
                    looper = false;
                }

            }
            return emailExist;

        }
        public static bool BookIDtrue(string book)
        {
            bool BookExists = false;

            XmlDocument doc = new XmlDocument();
            doc.Load(@"BookInventory.xml");
            XmlNode nodeCheck = doc.SelectSingleNode("//book[ID='" + book + "']");

            if (nodeCheck == null)
            {
                MessageBox.Show("Incorrect Book ID. Please try again");
            }
            else
            {
                BookExists = true;

            }
            return BookExists;
        }
    
    }
}


    


