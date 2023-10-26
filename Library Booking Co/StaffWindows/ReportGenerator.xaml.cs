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
    /// Interaction logic for ReportGenerator.xaml
    /// </summary>
    public partial class ReportGenerator : Window
    {
        public ReportGenerator()
        {
            InitializeComponent();

            var todayDate = DateTime.Today;
            XmlDocument book_doc = new XmlDocument();
            book_doc.Load(@"BookInventory.xml");
            DataSet dataSet = new DataSet();

            XmlDocument user_doc = new XmlDocument();
            user_doc.Load(@"LibraryUsers.xml");
            
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

            foreach (XmlNode books in user_doc.SelectNodes("/libraryMembers/user/borrowedBooks/book"))
            {
                string rawReturnBY = books.ChildNodes.Item(2).InnerText;
                RetBy = DateTime.ParseExact(rawReturnBY, "dd/MM/yyyy", null);
                if (todayDate > RetBy)
                {
                    // need to search through 'user' to get name and get name and user id. 
                    //currently goes through book in borrowedbook
                    XmlNode borrBook = book_doc.SelectSingleNode("//book[ID='" + books.ChildNodes.Item(0).InnerText + "']");
                    XmlNode user = books.ParentNode.ParentNode; //climbs up the tree, each parentnode hoes up one step (getting from /libraryMembers/user/borrowedBooks/book to /libraryMembers/user)

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

                    dgReportViewerOverdue.ItemsSource = Fine;


                }
                this.DataContext = this;
                dgReportViewerOverdue.Visibility = Visibility.Hidden;
                dgReportViewer.Visibility = Visibility.Hidden;
            }
        }

        private void btnViewOverdue_Click(object sender, RoutedEventArgs e)
        {
            dgReportViewer.Visibility = Visibility.Hidden;
            dgReportViewerOverdue.Visibility = Visibility.Visible;

        }

        private void btnAddViewLoaned_Click(object sender, RoutedEventArgs e)
        {
            
            dgReportViewerOverdue.Visibility = Visibility.Hidden;
            dgReportViewer.Visibility = Visibility.Visible;
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(@"BookInventory.xml"); 
            //dgReportViewer.ItemsSource = dataSet.Tables[0].DefaultView;
            DataContext = this;
            //DataRowView row = dgReportViewer.SelectedItem as DataRowView; if (row == null) { return; }
            DataView dv = dataSet.Tables[0].DefaultView;


            StringBuilder sb = new StringBuilder();
            foreach (DataColumn column in dv.Table.Columns)
            {
                sb.AppendFormat("[{0}] Like '%{1}%' OR ", column.ColumnName, "false");
            }
            sb.Remove(sb.Length - 3, 3);
            dv.RowFilter = sb.ToString();
            dgReportViewer.ItemsSource = dv;            
            dgReportViewer.Columns[2].Visibility = Visibility.Hidden;
            dgReportViewer.Columns[3].Visibility = Visibility.Hidden;
            dgReportViewer.Columns[4].Visibility = Visibility.Hidden;
            dgReportViewer.Columns[5].Visibility = Visibility.Hidden;
            dgReportViewer.Columns[6].Visibility = Visibility.Hidden;
            dgReportViewer.Columns[7].Visibility = Visibility.Hidden;
            dgReportViewer.Columns[9].Visibility = Visibility.Hidden;
            dgReportViewer.Columns[10].Visibility = Visibility.Hidden;
            dgReportViewer.Items.Refresh();
            

        }

        private void btnMostPopular_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument book_doc = new XmlDocument();
            book_doc.Load(@"BookInventory.xml");
            List<int> BorrowCount = new List<int>();
            //foreach loop iterates through xml, gets all 'couters' and appends them to a list
            foreach (XmlNode books in book_doc.SelectNodes("/inventory/book"))
            {
                BorrowCount.Add(Convert.ToInt32(books.ChildNodes.Item(10).InnerText));
            }
            BorrowCount.Sort(); //sorts all of the counters by ascending order
            BorrowCount.Reverse(); // reverses the order so biggest number is at the begining of the list


            XmlNode PopularBook1 = book_doc.SelectSingleNode("//book[counter='" + BorrowCount[0].ToString() + "']");
            XmlNode PopularBook2 = book_doc.SelectSingleNode("//book[counter='" + BorrowCount[1].ToString() + "']");
            XmlNode PopularBook3 = book_doc.SelectSingleNode("//book[counter='" + BorrowCount[3].ToString() + "']");

            //uses the 3 top numbers and sets variables
            string PopularTitle1 = PopularBook1.ChildNodes.Item(1).InnerText;
            string PopularTitle2 = PopularBook2.ChildNodes.Item(1).InnerText;
            string PopularTitle3 = PopularBook3.ChildNodes.Item(1).InnerText;

            string PopularAuthor1 = PopularBook1.ChildNodes.Item(0).InnerText;
            string PopularAuthor2 = PopularBook2.ChildNodes.Item(0).InnerText;
            string PopularAuthor3 = PopularBook3.ChildNodes.Item(0).InnerText;



            MessageBox.Show("Most Popular Books:\n" + PopularTitle1 + " by " + PopularAuthor1 +"\n" + PopularTitle2 + " by " + PopularAuthor2+"\n" + PopularTitle3 + " by " + PopularAuthor3);
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainMenuStaff MainStaff = new MainMenuStaff();
            this.Hide();
            MainStaff.Show();
        }
    }
}
