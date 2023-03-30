using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace Library_Booking_Co
{
    class XmlController_BorrowBooks
    {
        string path = @"LibraryUsers.xml";
        public void BorrowBook(string iD, BorrowedBook newBorrowedBook)
        {


            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode borrBook = doc.SelectSingleNode("//user[ID='" + iD + "']");
            XmlNode borrow = borrBook.SelectSingleNode("borrowedBooks");
            //XmlNode ROOT = doc.SelectSingleNode("user ID='" + iD + "'/borrowedBooks");
            XmlNode Book = doc.CreateElement("book");
            XmlNode ID = doc.CreateElement("ID");
            XmlNode DateOfIssue = doc.CreateElement("dateOfIssue");
            XmlNode ReturnBy = doc.CreateElement("returnBy");

            ID.InnerText = newBorrowedBook.ID;
            DateOfIssue.InnerText = newBorrowedBook.dateOfIssue;
            ReturnBy.InnerText = newBorrowedBook.returnBy;


            Book.AppendChild(ID);
            Book.AppendChild(DateOfIssue);
            Book.AppendChild(ReturnBy);
            borrow.AppendChild(Book);

            doc.Save(path);


        }

        public void retunBook(string iD, string bookID, BorrowedBook newBorrowedBook)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode nodes = doc.SelectSingleNode("/libraryMembers/user[ID='" + iD + "']/borrowedBooks/book[ID='" + bookID + "']");

            if (nodes == null)
            {
                MessageBox.Show("This book is not currently loaned by user");
            }
            else
            {
                nodes.ParentNode.RemoveChild(nodes);
                doc.Save(path);
            }



        }
        public void reserveBook(string iD, BorrowedBook newReservedBook)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode borrBook = doc.SelectSingleNode("//user[ID='" + iD + "']");
            XmlNode borrow = borrBook.SelectSingleNode("savedBooks");
            XmlNode Book = doc.CreateElement("book");
            XmlNode ISBN = doc.CreateElement("ISBN");
            XmlNode DateOfIssue = doc.CreateElement("dateOfIssue");

            ISBN.InnerText = newReservedBook.ISBN;
            DateOfIssue.InnerText = newReservedBook.dateOfIssue;

            Book.AppendChild(ISBN);
            Book.AppendChild(DateOfIssue);
            borrow.AppendChild(Book);

            doc.Save(path);

        }


    }
}
