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
            int BoorrowedCount = 0;
            XmlDocument book_doc = new XmlDocument();
            book_doc.Load(@"BookInventory.xml");

            XmlDocument user_doc = new XmlDocument();
            user_doc.Load(@"LibraryUsers.xml");

            XmlNode borrBook = book_doc.SelectSingleNode("//book[ID='" + book + "']");
            available = borrBook.ChildNodes.Item(9).InnerText;
            BoorrowedCount =Convert.ToInt32( borrBook.ChildNodes.Item(10).InnerText);

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


                    string Title = borrBook.ChildNodes.Item(1).InnerText;
                    string Author = borrBook.ChildNodes.Item(0).InnerText;

            if (maxBookCount < 3)
            {
                if (available.Equals("true"))
                {
                    int AddToCount = BoorrowedCount + 1;
                    borrBook.ChildNodes.Item(10).InnerText = AddToCount.ToString();

                    borrBook.ChildNodes.Item(9).InnerText = "false"; //Changes text in "available" to false
                    newBorrowedBook.ID = book;
                    newBorrowedBook.dateOfIssue = DOI_DT.ToShortDateString();
                    newBorrowedBook.returnBy = retunBy_DT.ToShortDateString();
                    conn.BorrowBook(user, newBorrowedBook);
                    book_doc.Save(@"BookInventory.xml");


                    MessageBox.Show(""+Title+" by " +Author+ " has been booked out.\nThe books should be returned by " + retunBy_DT.ToShortDateString());


                }
                else
                {
                    // MessageBox.Show("This book is currently on loan. Please double check and try again");
                    // shows choice if they want to reserve book

                    if (MessageBox.Show("" + Title + " by " + Author + " is currently on loan.\n Would you like to reserve this book?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        ManageBooks RenewB = new ManageBooks();
                        RenewB.ReserveBook(book, user);
                        MessageBox.Show("" + Title + " by " + Author + " has been reverved.");

                    }
                    else
                    {
                        // Nothing happens 


                    }


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
                string Title = borrBook.ChildNodes.Item(1).InnerText;
                string Author = borrBook.ChildNodes.Item(0).InnerText;
                MessageBox.Show("" + Title + " by " + Author + " has been returned ");

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

        public void RenewBook(string book, string user)
        {
            // checks id of book exists within user
            // adds 2 weeks to returnByDate
            var todayDate = DateTime.Today;
            DateTime RetBy = new DateTime();


            XmlDocument user_doc = new XmlDocument();
            user_doc.Load(@"LibraryUsers.xml");

            XmlDocument book_doc = new XmlDocument();
            book_doc.Load(@"BookInventory.xml");

            XmlNode borrBook = book_doc.SelectSingleNode("//book[ID='" + book + "']");

            XmlNode nodes = user_doc.SelectSingleNode("/libraryMembers/user[ID='" + user + "']/borrowedBooks/book[ID='" + book + "']");
            string rawRTBY = nodes.ChildNodes.Item(2).InnerText;
            RetBy = DateTime.ParseExact(rawRTBY, "dd/MM/yyyy", null);

            string Title = borrBook.ChildNodes.Item(1).InnerText;
            string Author = borrBook.ChildNodes.Item(0).InnerText;


            if (nodes == null)
            {
                MessageBox.Show("This book is not currently loaned by user");
            }
            else
            {

                DateTime newReturnDate = RetBy.AddDays(14); //adds 2 weeks to original duedate


                nodes.ChildNodes.Item(2).InnerText = newReturnDate.ToShortDateString();
                user_doc.Save(@"LibraryUsers.xml");
                MessageBox.Show("" + Title + " by " + Author + " has been renewed.\nThe books should be returned by " + newReturnDate.ToShortDateString());


            }

        }









    }
}

