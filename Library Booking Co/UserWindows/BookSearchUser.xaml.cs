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

namespace Library_Booking_Co.UserWindows
{
    /// <summary>
    /// Interaction logic for BookSearchUser.xaml
    /// </summary>
    public partial class BookSearchUser : Window
    {
        public BookSearchUser()
        {

            InitializeComponent();


        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            
            DataSet dataSet = new DataSet(); // creates an empty dataset to recieve the xml data
            dataSet.ReadXml(@"BookInventory.xml"); // reads the xml file into dataset
            dgBookSearch.ItemsSource = dataSet.Tables[0].DefaultView; //Sets the datasource for the datagrid for the datagrid to be a dataset
            DataContext = this;
            DataView dv = dataSet.Tables[0].DefaultView;
            //Hides columns by index
            dgBookSearch.Columns[6].Visibility = System.Windows.Visibility.Hidden;
            dgBookSearch.Columns[9].Visibility = System.Windows.Visibility.Hidden;
            dgBookSearch.Columns[10].Visibility = System.Windows.Visibility.Hidden;
            dgBookSearch.Columns[5].Width = 300;
            dgBookSearch.Columns[3].Width = 180;

            
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

        private void dgBookSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)

        {
            
           // DataRowView row = dgBookSearch.SelectedItem as DataRowView;

            //Appends data from row to variable so it can be displayed in a message box
            DataRowView row = dgBookSearch.SelectedItem as DataRowView; if (row == null) { return; }
            string Description = row.Row.ItemArray[5].ToString();
            string Title = row.Row.ItemArray[1].ToString();
            string Author = row.Row.ItemArray[0].ToString();
            string descLabel = "Description: ";
            string authLabel = "Author: ";
            string TitlLabel = "Title: ";

            MessageBox.Show( TitlLabel +Title +"\n" + authLabel + Author + "\n" + descLabel + Description + "\n");
             

        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            UserMainMenu mUs = new UserMainMenu();
            this.Hide();
            mUs.Show();
        }
    }
}
