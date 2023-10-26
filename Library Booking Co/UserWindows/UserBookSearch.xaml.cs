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
    /// Interaction logic for UserBookSearch.xaml
    /// </summary>
    public partial class UserBookSearch : Window
    {
        public UserBookSearch()
        {
            InitializeComponent();
            
            DataSet dataSet = new DataSet(); // creates an empty dataset to recieve the xml data
            dataSet.ReadXml(@"BookInventory.xml"); // reads the xml file into dataset
            dgBookSearch.ItemsSource = dataSet.Tables[0].DefaultView; //Sets the datasource for the datagrid for the datagrid to be a dataset
            dgBookSearch.AutoGenerateColumns = false;
            //dgBookSearch.Columns[0].Visible = true;
            DataContext = this;


        }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = dgBookSearch.SelectedItem as DataRowView;

        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //creates an empty dataset to recievethe XML data
            DataSet dataSet = new DataSet();
            //Reads the XML file into the dataset
            dataSet.ReadXml(@"BookInventory.xml");
            //Sets the datasource for thr datagrod to be the dataset

            DataView dv = dataSet.Tables[0].DefaultView;

            StringBuilder sb = new StringBuilder();
            foreach (DataColumn column in dv.Table.Columns)
            {
                sb.AppendFormat("[{0}] Like '{1}%' OR ", column.ColumnName, txtSearch.Text);
            }
            sb.Remove(sb.Length - 3, 3);
            dv.RowFilter = sb.ToString();
            dgBookSearch.ItemsSource = dv;
            dgBookSearch.Items.Refresh(); 

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //creates an empty dataset to recievethe XML data
            DataSet dataSet = new DataSet();
            //Reads the XML file into the dataset
            dataSet.ReadXml(@"BookInventory.xml");
            //Sets the datasource for thr datagrod to be the dataset

            DataView dv = dataSet.Tables[0].DefaultView;

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

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            UserMainMenu mUs = new UserMainMenu();
            this.Hide();
            mUs.Show();
        }
    }
}
