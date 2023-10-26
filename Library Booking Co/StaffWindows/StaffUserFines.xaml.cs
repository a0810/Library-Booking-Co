using Library_Booking_Co.PopupWindows;
using Library_Booking_Co.UserManagement;
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

namespace Library_Booking_Co.StaffWindows
{
    /// <summary>
    /// Interaction logic for StaffUserFines.xaml
    /// </summary>
    public partial class StaffUserFines : Window
    {
        public StaffUserFines()
        {
            InitializeComponent();

            var todayDate = DateTime.Today;
            //loading xml files 
            XmlDocument book_doc = new XmlDocument();
            book_doc.Load(@"BookInventory.xml");
            DataSet dataSet = new DataSet();

            XmlDocument user_doc = new XmlDocument();
            user_doc.Load(@"LibraryUsers.xml");
            var results = new Dictionary<int, int>();
            //declearing variables
            string title = "";
            string author = "";
            string ID = "";
            string ISBN = "";
            string price = "";
            string name = "";
            string usID = "";
            string surname = "";
            string fullName = "";
            List<DisplayFines> Fine = new List<DisplayFines>();

            DateTime RetBy = new DateTime();
            //foreach loop foes through each book under brrowedbooks then checks if today is later than the return by date.
            //Appends to list
            //Builds Datagrid

            foreach (XmlNode books in user_doc.SelectNodes("/libraryMembers/user/borrowedBooks/book"))
            {
                string rawReturnBY = books.ChildNodes.Item(2).InnerText;
                RetBy = DateTime.ParseExact(rawReturnBY, "dd/MM/yyyy", null);
                if (todayDate > RetBy)
                {
                    // need to search through 'user' to get name and get name and user id. 
                    //currently goes through book in borrowedbook
                    XmlNode borrBook = book_doc.SelectSingleNode("//book[ID='" + books.ChildNodes.Item(0).InnerText + "']");
                    XmlNode user = books.ParentNode.ParentNode;

                    name = user.ChildNodes.Item(0).InnerText;
                    surname = user.ChildNodes.Item(1).InnerText;
                    usID = user.ChildNodes.Item(6).InnerText;
                    fullName = name + " " + surname;



                    title = borrBook.ChildNodes.Item(1).InnerText;
                    author = borrBook.ChildNodes.Item(0).InnerText;
                    ID = borrBook.ChildNodes.Item(8).InnerText;
                    ISBN = borrBook.ChildNodes.Item(7).InnerText;
                    price = borrBook.ChildNodes.Item(6).InnerText;

                    Fine.Add(new DisplayFines() { Title = title, returnBy = rawReturnBY, BookID = ID, Author = author, ISBN = ISBN, Price = price, User = fullName, UserID = usID });

                    dgViewFines.ItemsSource = Fine;


                }
                this.DataContext = this;




            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainMenuStaff menuS = new MainMenuStaff();
            this.Hide();
            menuS.Show();
        }

        private void dgViewFines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DataRowView row = dgViewFines.SelectedItem as DataRowView; if (row == null) { return; }

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;
        }

        private void btnGoFines_Click(object sender, RoutedEventArgs e)
        {
            //ID validation
            //if yes open pop up if no, 'incorrect id'
           

            XmlDocument doc = new XmlDocument();

            if (string.IsNullOrEmpty(txtFineID.Text))
            {
                MessageBox.Show("Incorrect ID");

            }
            else
            {
                doc.Load(@"LibraryUsers.xml");
                XmlNode nodes = doc.SelectSingleNode("/libraryMembers/user[ID='" + txtFineID.Text + "']"); //checks through xml for ID
                
                if (nodes == null)
                {
                    MessageBox.Show("Incorrect ID");

                }
                else
                {

                    StaffGlobalUserID.Name = nodes.ChildNodes.Item(0).InnerText;
                    StaffGlobalUserID.Surname = nodes.ChildNodes.Item(1).InnerText;
                    StaffGlobalUserID.ID = nodes.ChildNodes.Item(6).InnerText;
                    ManageFines Fine = new ManageFines();
                    Fine.ShowDialog();

                }
            }


        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainMenuStaff MainStaff = new MainMenuStaff();
            this.Hide();
            MainStaff.Show();
        }
    }
}
