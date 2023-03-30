using System;
using System.Collections.Generic;
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
        }
        
            

        private void btnBorrowBook_Click(object sender, RoutedEventArgs e)
        {
            bool valBookID = ValidatorExtensions.BookIDtrue(txtBorrowBook.Text);
            if (valBookID == true) //
            {
                ManageBooks newBorrow = new ManageBooks();
                newBorrow.BorrowBook(txtBorrowBook.Text, GlobalUserID.UserID);
                txtBorrowBook.Text = "";

            }

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;
        }

        private void btnReturnBook_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
