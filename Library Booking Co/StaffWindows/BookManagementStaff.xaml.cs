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

namespace Library_Booking_Co.StaffWindows
{
    /// <summary>
    /// Interaction logic for BookManagementStaff.xaml
    /// </summary>
    public partial class BookManagementStaff : Window
    {
        public string[] genreSelect { get; set; }
        public int curYear = 2023;
        xmlController xmlC = new xmlController();
        Book newBook = new Book();
        Book updateBook = new Book();
        Book delBooks = new Book();
        idGen newID = new idGen();
        //MainMenuStaff StMain = new MainMenuStaff();
        public BookManagementStaff()
        {
            InitializeComponent();
            DataSet dataSet = new DataSet(); // creates an empty dataset to recieve the xml data
            dataSet.ReadXml(@"BookInventory.xml"); // reads the xml file into dataset
            dgBookSearch.ItemsSource = dataSet.Tables[0].DefaultView; //Sets the datasource for the datagrid for the datagrid to be a dataset

            //array that binds to combo box
            genreSelect = new string[] { @"Action/Adventure", "Biography", "Children’s", "Classics", "Classic Foreign", "Comic", "Crime", "Drama", "Education", "Fantasy", "General Fiction", "Graphic Novel", "Health and Fitness", "Historical Fiction", "History", "Horror", "Music", "Mystery and Thriller", "New Adult", "Nonfiction", "Philosophy", "Play", "Poetry", "Psychology", "Religion", "Romance", "Science Fiction", "Self Help", "Short Stories", "Sports", "Travel", "Young Adult" };
            this.txtISBN.MaxLength = 13;
            this.txtAuthor.MaxLength = 100;
            this.txtTitle.MaxLength = 100;
            this.txtPrice.MaxLength = 5;
            
            DataContext = this;

            for (int i = 1400; i <= curYear; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = i;
                drbxPublishDate.Items.Add(item);
            }

        }

        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            bool AddBook = ValidatorExtensions.AddingBook(txtAuthor.Text, txtTitle.Text, txtPrice.Text, txtISBN.Text, txtDescription.Text, drbxGenre.Text, txtPublisher.Text, drbxPublishDate.Text);
            if (AddBook == true)
            {
                bookAdding();
                txtAuthor.Text = "";
                txtTitle.Text = "";
                txtISBN.Text = "";
                drbxGenre.Text = "";
                txtDescription.Text = "";
                txtPrice.Text = "";
                drbxPublishDate.Text = "";
                txtPublisher.Text = "";

            }

        }

        void bookAdding()
        {
            int count = 0;
            newBook.ID = newID.IDgen();
            newBook.author = txtAuthor.Text;
            newBook.title = txtTitle.Text;
            newBook.genre = drbxGenre.Text;
            newBook.publisher = txtPublisher.Text;
            newBook.price = Convert.ToDouble(txtPrice.Text);
            newBook.publishDate = Convert.ToInt32(drbxPublishDate.Text);
            newBook.description = txtDescription.Text;
            newBook.ISBN = Convert.ToInt64(txtISBN.Text); //// Error value too large or too small for int32
            newBook.available = "true";
            newBook.counter = Convert.ToInt32(count);
            xmlC.addBook(newBook);
            dgBookSearch.Items.Refresh();
            MessageBox.Show("Book Added");

        }

        void bookUpdating()
        {
            updateBook.author = txtAuthorUp.Text;
            updateBook.title = txtTitleUp.Text;
            updateBook.genre = drbxGenreUp.Text;
            updateBook.publisher = txtPublisherUp.Text;
            updateBook.price = Convert.ToDouble(txtPriceUp.Text);
            updateBook.publishDate = Convert.ToInt32(drbxPublishDateUp.Text);
            updateBook.description = txtDescriptionUp.Text;
            updateBook.ISBN = Convert.ToInt64(txtISBNUp.Text); 
            xmlC.updateBook(txtIDUp.Text, updateBook);
            dgBookSearch.Items.Refresh();
            MessageBox.Show("Book Updated");

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            DataSet dataSet = new DataSet(); // creates an empty dataset to recieve the xml data
            dataSet.ReadXml(@"BookInventory.xml"); // reads the xml file into dataset
            dgBookSearch.ItemsSource = dataSet.Tables[0].DefaultView; //Sets the datasource for the datagrid for the datagrid to be a dataset
            DataContext = this;
            DataView dv = dataSet.Tables[0].DefaultView;
            dgBookSearch.Columns[5].Width = 300;

            StringBuilder sb = new StringBuilder();
            foreach (DataColumn column in dv.Table.Columns)
            {
                sb.AppendFormat("[{0}] Like '%{1}%' OR ", column.ColumnName, txtSearch.Text);
            }
            sb.Remove(sb.Length - 3, 3);
            dv.RowFilter = sb.ToString();
            dgBookSearch.ItemsSource = dv;
            dgBookSearch.Items.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            //StMain.Show();
        }

         private void dgBookSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = dgBookSearch.SelectedItem as DataRowView; if (row == null) { return; }
            string Description = row.Row.ItemArray[5].ToString();
            string Title = row.Row.ItemArray[1].ToString();
            string Author = row.Row.ItemArray[0].ToString();
            string descLabel = "Description: ";
            string authLabel = "Author: ";
            string TitlLabel = "Title: ";

            if (MessageBox.Show(TitlLabel + Title + "\n" + authLabel + Author + "\n" + descLabel + Description + "\n" + "Do you want to update these details?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                txtAuthorUp.Text = row.Row.ItemArray[0].ToString();
                txtTitleUp.Text = row.Row.ItemArray[1].ToString();
                drbxGenreUp.Text = row.Row.ItemArray[2].ToString();
                txtPublisherUp.Text = row.Row.ItemArray[3].ToString();
                drbxPublishDateUp.Text = row.Row.ItemArray[4].ToString();
                txtDescriptionUp.Text = row.Row.ItemArray[5].ToString();
                txtPriceUp.Text = row.Row.ItemArray[6].ToString();
                txtISBNUp.Text = row.Row.ItemArray[7].ToString();
                txtIDUp.Text = row.Row.ItemArray[8].ToString();
                MessageBox.Show("Go to UPDATE to continue.");
            }
            else
            {
                // Nothing happens 

            
            }

            e.Handled = true;
         }

        private void btnUpdateBook_Click(object sender, RoutedEventArgs e)
        {
            bool UpBook = ValidatorExtensions.AddingBook(txtAuthorUp.Text, txtTitleUp.Text, txtPriceUp.Text, txtISBNUp.Text, txtDescriptionUp.Text, drbxGenreUp.Text, txtPublisherUp.Text, drbxPublishDateUp.Text);
            if (UpBook == true)
            {
                bookUpdating();
                txtAuthorUp.Text = "";
                txtIDUp.Text = "";
                txtTitleUp.Text = "";
                txtISBNUp.Text = "";
                drbxGenreUp.Text = "";
                txtDescriptionUp.Text = "";
                txtPriceUp.Text = "";
                drbxPublishDateUp.Text = "";
                txtPublisherUp.Text = "";
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDelID.Text))
            {

            }
            
            else
            {


                XmlDocument book_doc = new XmlDocument();
                book_doc.Load(@"BookInventory.xml");
                XmlNode borrBook = book_doc.SelectSingleNode("//book[ID='" + txtDelID.Text + "']");
                
                if (borrBook == null)
                {
                    MessageBox.Show("Incorrect Book ID");
                }
                else
                {
                    string BookTitle = borrBook.ChildNodes.Item(1).InnerText;
                    if (MessageBox.Show("Do you want to delete " + BookTitle, "Delete Book", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        xmlC.deleteBook(txtDelID.Text, delBooks);
                        txtDelID.Text = "";
                    }
                    else
                    {

                    }

                }
            }

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainMenuStaff MuS = new MainMenuStaff();
            this.Hide();
            MuS.Show();
        }

        private void btnClearUpdate_Click(object sender, RoutedEventArgs e)
        {
            txtAuthorUp.Text = "";
            txtIDUp.Text = "";
            txtTitleUp.Text = "";
            txtISBNUp.Text = "";
            drbxGenreUp.Text = "";
            txtDescriptionUp.Text = "";
            txtPriceUp.Text = "";
            drbxPublishDateUp.Text = "";
            txtPublisherUp.Text = "";

        }

        private void btnClearAdd_Click(object sender, RoutedEventArgs e)
        {
            txtAuthor.Text = "";
            txtTitle.Text = "";
            txtISBN.Text = "";
            drbxGenre.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
            drbxPublishDate.Text = "";
            txtPublisher.Text = "";

        }
    }


}
