using Library_Booking_Co.BookManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace Library_Booking_Co.UserWindows
{
    /// <summary>
    /// Interaction logic for BookManagementUsers.xaml
    /// </summary>
    public partial class BookManagementUsers : Window
    {
        public BookManagementUsers()
        {
            InitializeComponent();

            DataSet dataSet = new DataSet();
            
            var todayDate = DateTime.Today;
            XmlDocument book_doc = new XmlDocument();
            book_doc.Load(@"BookInventory.xml");

            XmlDocument user_doc = new XmlDocument();
            user_doc.Load(@"LibraryUsers.xml");
            var results = new Dictionary<int, int>();
            int count = 0;
            string title = "";
            string author = "";
            XmlNode userNode = user_doc.SelectSingleNode("//user[ID='" + GlobalUserID.UserID + "']");
            List<DisplayBorrowed> Brrwd = new List<DisplayBorrowed>();
            List<DisplayReserved> Rsrvd = new List<DisplayReserved>();
            //Foreach loops through /borrowedbooks unded the specific user and pulls out the id of the book
            //then uses that id to find the tile and author of the book
            //Appends to list 
            //Populates datagrid

            foreach (XmlNode books in user_doc.SelectNodes("/libraryMembers/user[ID='" + GlobalUserID.UserID + "']/borrowedBooks/book"))
            {
                string rawRTBY = books.ChildNodes.Item(2).InnerText;

                
                    XmlNode borrBook = book_doc.SelectSingleNode("//book[ID='" + books.ChildNodes.Item(0).InnerText + "']");
                    title = borrBook.ChildNodes.Item(1).InnerText;
                    author = borrBook.ChildNodes.Item(0).InnerText;

                Brrwd.Add(new DisplayBorrowed() { Title = title, returnBy= rawRTBY });

                    dgBorrowedBooks.ItemsSource = Brrwd;

            }

            foreach (XmlNode books in user_doc.SelectNodes("/libraryMembers/user[ID='" + GlobalUserID.UserID + "']/savedBooks/book"))
            {

                XmlNode borrBook = book_doc.SelectSingleNode("//book[ID='" + books.ChildNodes.Item(0).InnerText + "']");
                title = borrBook.ChildNodes.Item(1).InnerText;

                Rsrvd.Add(new DisplayReserved() { Title = title });

                dgReservedBooks.ItemsSource = Rsrvd;

            }







            //foreach (XmlNode users in user_doc.SelectNodes("/libraryMembers/user"))

            foreach (XmlNode books in user_doc.SelectNodes("/libraryMembers/user/borrowedBooks/book"))
            {



                


                count = books.SelectNodes("*").Count;

            }









            DataContext = this;




        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = dgBorrowedBooks.SelectedItem as DataRowView;
            
        }


        private void btnBorrowBook_Click(object sender, RoutedEventArgs e)
        {
            bool valBookID = ValidatorExtensions.BookIDtrue(txtBorrowBook.Text);
            if (valBookID == true) //
            {
                ManageBooks newBorrow = new ManageBooks();
                newBorrow.BorrowBook(txtBorrowBook.Text, GlobalUserID.UserID);
                txtBorrowBook.Text = "";
                dgBorrowedBooks.Items.Refresh();


            }

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;
        }

        private void btnReturnBook_Click(object sender, RoutedEventArgs e)
        {
            bool valBookID = ValidatorExtensions.BookIDtrue(txtReturnBook.Text);
            if (valBookID == true) //
            {
                ManageBooks newBorrow = new ManageBooks();
                newBorrow.ReturnBook(txtReturnBook.Text, GlobalUserID.UserID);
                txtReturnBook.Text = "";
                dgBorrowedBooks.Items.Refresh();

            }

        }

        private void txtBorrowBook_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            UserMainMenu mUs = new UserMainMenu();
            this.Hide();
            mUs.Show();
        }

        private void btnRenewBook_Click(object sender, RoutedEventArgs e)
        {
            bool valBookID = ValidatorExtensions.BookIDtrue(txtRenewBook.Text);
            if (valBookID == true) //
            {
                ManageBooks newBorrow = new ManageBooks();
                newBorrow.RenewBook(txtRenewBook.Text, GlobalUserID.UserID);
                txtRenewBook.Text = "";
                dgBorrowedBooks.Items.Refresh();

            }
        }
    }
}
