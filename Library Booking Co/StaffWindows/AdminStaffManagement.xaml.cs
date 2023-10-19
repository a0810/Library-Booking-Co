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
    /// Interaction logic for AdminStaffManagement.xaml
    /// </summary>
    public partial class AdminStaffManagement : Window
    {
        xmlControllerUser xmlC = new xmlControllerUser();
        Staff newStaff = new Staff();
        PasswordGen newPassword = new PasswordGen();
        StaffIDGen newID = new StaffIDGen();
        public AdminStaffManagement()
        {
            InitializeComponent();
            DataSet dataSet = new DataSet(); // creates an empty dataset to recieve the xml data
            dataSet.ReadXml(@"BookInventory.xml"); // reads the xml file into dataset
            dgStaffSearch.ItemsSource = dataSet.Tables[0].DefaultView; 
            DataContext = this;

        }
        void StaffAdding()
        {
            var todayDate = DateTime.Today;
            newStaff.ID = newID.StaffID();
            newStaff.firstName = txtFirstName.Text;
            newStaff.surName = txtSurname.Text;
            newStaff.phone = Convert.ToInt64(txtPhone.Text);
            newStaff.startDate = todayDate.ToShortDateString();
            newStaff.password = newPassword.RandomPassword();

            xmlC.addStaff(newStaff);
            MessageBox.Show("New Staff Added");
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainMenuStaff MainStaff = new MainMenuStaff();
            this.Hide();
            MainStaff.Show();
        }


        private void btnAddStaff_Click(object sender, RoutedEventArgs e)
        {
            bool AddStaff = ValidatorExtensions.AddingStaff(txtFirstName.Text, txtSurname.Text, txtPhone.Text);
            if (AddStaff == true)
            {
                StaffAdding();

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
                book_doc.Load(@"Staff.xml");
                XmlNode borrBook = book_doc.SelectSingleNode("//staff[ID='" + txtDelID.Text + "']");

                if (borrBook == null)
                {
                    MessageBox.Show("Incorrect ID");
                }
                else
                {
                    
                    if (MessageBox.Show("Do you want to remove staff member?" , "Delete Book", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        xmlC.deleteStaff(txtDelID.Text);
                        txtDelID.Text = "";
                    }
                    else
                    {

                    }

                }
            }

        }
    } 
}
