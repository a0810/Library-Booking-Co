using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Library_Booking_Co
{
    class FineManagement
    {
        public void CalculateFine()
        {
            var todayDate = DateTime.Today;
            XmlDocument book_doc = new XmlDocument();
            book_doc.Load(@"BookInventory.xml");

            XmlDocument user_doc = new XmlDocument();
            user_doc.Load(@"LibraryUsers.xml");
            var results = new Dictionary<int, int>();
            int count = 0;
            double price = 0.0;
            XmlNode userNode = user_doc.SelectSingleNode("//user[ID='" + GlobalUserID.UserID + "']");

            DateTime RetBy = new DateTime();
            foreach (XmlNode users in user_doc.SelectNodes("/libraryMembers/user"))
            {
                foreach (XmlNode books in user_doc.SelectNodes("/libraryMembers/user/borrowedBooks/book"))
                {
                    string rawRTBY = books.ChildNodes.Item(2).InnerText;
                    RetBy = DateTime.ParseExact(rawRTBY, "dd/MM/yyyy", null);
                    if (RetBy>todayDate)
                    {
                        XmlNode borrBook = book_doc.SelectSingleNode("//book[ID='" + books.ChildNodes.Item(0).InnerText + "']");
                        price =Convert.ToDouble( borrBook.ChildNodes.Item(6).InnerText);
                        double fee = price / 100;
                        double oldprice = Convert.ToDouble(userNode.ChildNodes.Item(11).InnerText);
                        double add = Math.Round((oldprice + fee),2);
                        userNode.ChildNodes.Item(11).InnerText = add.ToString();
                        user_doc.Save(@"LibraryUsers.xml");


                    }


                    count = books.SelectNodes("*").Count;

                }
            }
            
        }
    }
}
