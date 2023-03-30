using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace Library_Booking_Co
{
    class ManageBooks
    {
        XmlController_BorrowBooks conn = new XmlController_BorrowBooks();
        BorrowedBook newBorrowedBook = new BorrowedBook();
        //public string bookID { get; set; }
        //public string userEmail { get; set; }
        //public string userID { get; set; }
        public void BorrowBook(string book, string user)
        {
            DateTime DOI_DT = DateTime.Today; // generates today's date
            DateTime retunBy_DT = DOI_DT.AddDays(21); //Adds 21 days to today's date (3 weeks)

            string available = "";
            XmlDocument book_doc = new XmlDocument();
            book_doc.Load(@"BookInventory.xml");

            XmlDocument user_doc = new XmlDocument();
            user_doc.Load(@"LibraryUsers.xml");

            XmlNode borrBook = book_doc.SelectSingleNode("//book[ID='" + book + "']");
            available = borrBook.ChildNodes.Item(9).InnerText;

            //JAMES CODE
            //XmlDocument jDoc = new XmlDocument();
            //jDoc.LoadXml(@"LibraryUsers.xml");
            var results = new Dictionary<int, int>();
            int count = 0;
            foreach (XmlNode books in user_doc.SelectNodes("/libraryMembers/user[ID='" + user + "']/borrowedBooks"))
            {
                //string id = books.SelectSingleNode("book").InnerText;
                count = books.SelectNodes("*").Count;
                //MessageBox.Show(""+count);
            }

            int maxBookCount = count;

            if (maxBookCount < 3)
            {
                if (available.Equals("true"))
                {
                    borrBook.ChildNodes.Item(9).InnerText = "false"; //Changes text in "available" to false
                    newBorrowedBook.ID = book;
                    newBorrowedBook.dateOfIssue = DOI_DT.ToShortDateString();
                    newBorrowedBook.returnBy = retunBy_DT.ToShortDateString();
                    conn.BorrowBook(user, newBorrowedBook);
                    book_doc.Save(@"BookInventory.xml");


                }
                else
                {
                    MessageBox.Show("This book is currently on loan. Please double check and try again");


                }
            }
            else
            {
                MessageBox.Show("Only 3 books can be loaned to a single user at a time.\nOutstanding books must be retuned before more can be loaned ");
            }



        }

        public void ReturnBook(string book, string user)
        {

            XmlDocument book_doc = new XmlDocument();
            book_doc.Load(@"BookInventory.xml");

            XmlDocument user_doc = new XmlDocument();
            user_doc.Load(@"LibraryUsers.xml");
            XmlNode borrBook = book_doc.SelectSingleNode("//book[ID='" + book + "']");
            //available = borrBook.ChildNodes.Item(9).InnerText;


            XmlNode nodes = user_doc.SelectSingleNode("/libraryMembers/user[ID='" + user + "']/borrowedBooks/book[ID='" + book + "']");

            if (nodes == null)
            {
                MessageBox.Show("This book is not currently loaned by user");
            }
            else
            {

                borrBook.ChildNodes.Item(9).InnerText = "true";
                book_doc.Save(@"BookInventory.xml");
                conn.retunBook(user, book, newBorrowedBook);

            }

        }
        public void ReserveBook(string bookISBN, string user)
        {
            DateTime DOI_DT = DateTime.Today; // generates today's date


            XmlDocument book_doc = new XmlDocument();
            book_doc.Load(@"BookInventory.xml");

            XmlDocument user_doc = new XmlDocument();
            user_doc.Load(@"LibraryUsers.xml");

            //XmlNode borrBook = book_doc.SelectSingleNode("//book[ID='" + book + "']");

            //JAMES CODE

            var results = new Dictionary<int, int>();
            int count = 0;
            foreach (XmlNode books in user_doc.SelectNodes("/libraryMembers/user[ID='" + user + "']/savedBooks"))
            {
                //string id = books.SelectSingleNode("book").InnerText;
                count = books.SelectNodes("*").Count;
                //MessageBox.Show(""+count);
            }

            int maxBookCount = count;

            if (maxBookCount < 5)
            {

                newBorrowedBook.ISBN = bookISBN;
                newBorrowedBook.dateOfIssue = DOI_DT.ToShortDateString();
                conn.reserveBook(user, newBorrowedBook);
                //book_doc.Save(@"BookInventory.xml");
            }
            else
            {
                MessageBox.Show("Only 5 books can be reserved to a single user at a time.");
            }


        }
    }
}

