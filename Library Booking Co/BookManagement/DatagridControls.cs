using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Library_Booking_Co.BookManagement
{
    class DatagridControls
    {
        void BorrowedBook()
        {
            int i = 0;
            XmlDocument book_doc = new XmlDocument();
            book_doc.Load(@"BookInventory.xml");

            XmlDocument user_doc = new XmlDocument();
            user_doc.Load(@"LibraryUsers.xml");
            string[] BBookID = new string[] { };

            //check through the borrowed book subchild and get the id's and due dates 

            XmlNode nodeCheck = user_doc.SelectSingleNode("/libraryMembers/user[ID='" + GlobalUserID.UserID + "']/borrowedBooks");
            XmlNode nodeBook = user_doc.SelectSingleNode("/libraryMembers/user[ID='" + GlobalUserID.UserID + "']/borrowedBooks/book");
            foreach (XmlNode node in nodeCheck )
            {
                string BookID = nodeBook.ChildNodes.Item(0).InnerText;
                BBookID[i] = BookID;
                i++;
            }

            for (int it= 0; it< BBookID.Length;it++)
            {

            }
        }
       
        

    }
}
