using Library_Booking_Co.BookManagement;
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
    /// Interaction logic for UserManagementStaff.xaml
    /// </summary>
    public partial class UserManagementStaff : Window
    {
        DateTime today = DateTime.Today;
        xmlControllerUser xmlC = new xmlControllerUser();
        Users newUser = new Users();
        Users upDetails = new Users();
        Users delUser = new Users();
        userIDgen newID = new userIDgen();
        PasswordGen newPassword = new PasswordGen();
       
        public UserManagementStaff()
        {
            InitializeComponent();
            DataSet dataSet = new DataSet(); // creates an empty dataset to recieve the xml data
            dataSet.ReadXml(@"LibraryUsers.xml"); // reads the xml file into dataset
            dgUserSearch.ItemsSource = dataSet.Tables[0].DefaultView;
            DataContext = this;
            dpDOB.BlackoutDates.Add(new CalendarDateRange((today), new DateTime(9000, 12, 31))); // makes dates form today into the future inaccessible

        }

        void userAdding() //method that appends user values to class
        {
            double startBal = 0.00;
            var todayDate = DateTime.Today;
            newUser.ID = newID.UserIDgen();
            newUser.firstName = txtFirstName.Text;
            newUser.surName = txtSurname.Text;
            newUser.DOB = dpDOB.Text;
            newUser.address = txtAddress.Text;
            newUser.email = txtEmail.Text;
            newUser.dateOfIssue = todayDate.ToShortDateString();
            newUser.password = newPassword.RandomPassword();
            newUser.phone = Convert.ToInt64(txtPhone.Text);
            newUser.balance = Convert.ToDouble(startBal);


            xmlC.addUser(newUser); // calls add user method form class. appends new user to xml
            MessageBox.Show("User Added");

        }

        void userUpdating()//method that appends user values to class
        {

            upDetails.firstName = txtFirstNameUp.Text;
            upDetails.surName = txtSurnameUp.Text;
            upDetails.address = txtAddressUp.Text;
            upDetails.email = txtEmailUp.Text;
            upDetails.phone = Convert.ToInt64(txtPhoneUp.Text);

            dgUserSearch.Items.Refresh();
            xmlC.UpdateUserDetails(txtIDUp.Text,upDetails);//calls method from class. Edits user details
            MessageBox.Show("User updated");

        }

        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            bool AddUser = ValidatorExtensions.AddingUser(txtFirstName.Text, txtSurname.Text, txtPhone.Text, txtEmail.Text, dpDOB.Text, txtAddress.Text);
            if (AddUser == true)
            {
                userAdding();
                txtFirstName.Text = "";
                txtSurname.Text = "";
                txtPhone.Text = "";
                txtEmail.Text = "";
                dpDOB.Text = "";
                txtAddress.Text = "";

            }

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true; //Handles tab selection event
        }

        private void dgUserSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = dgUserSearch.SelectedItem as DataRowView; if (row == null) { return; }
            dgUserSearch.Columns[8].Visibility = Visibility.Hidden;
            dgUserSearch.Columns[7].Visibility = Visibility.Hidden;
            dgUserSearch.Columns[11].Visibility = Visibility.Hidden;
            dgUserSearch.Columns[12].Visibility = Visibility.Hidden;

            string name = row.Row.ItemArray[0].ToString();
            string surname = row.Row.ItemArray[1].ToString();
            string id = row.Row.ItemArray[6].ToString();

            string NameLabel = "Name: ";
            string IDLabel = "ID: ";
            //string TitlLabel = "Title: ";

            if (MessageBox.Show(NameLabel+ name+ " " + surname + "\n" + IDLabel + id + "\n" + "Do you want to update this user's details?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                txtFirstNameUp.Text = row.Row.ItemArray[0].ToString();
                txtSurnameUp.Text = row.Row.ItemArray[1].ToString();
                txtAddressUp.Text = row.Row.ItemArray[3].ToString();
                txtEmailUp.Text = row.Row.ItemArray[4].ToString();
                txtPhoneUp.Text = row.Row.ItemArray[9].ToString();
                txtIDUp.Text = row.Row.ItemArray[6].ToString();
                MessageBox.Show("Go to UPDATE to continue.");
            }
            else
            {
                // Nothing happens 


            }

            

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDelID.Text))
            {

            }

            else
            {


                XmlDocument user_doc = new XmlDocument();
                user_doc.Load(@"LibraryUsers.xml");
                XmlNode borrBook = user_doc.SelectSingleNode("//user[ID='" + txtDelID.Text + "']");

                if (borrBook == null)
                {
                    MessageBox.Show("Incorrect User ID");
                }
                else
                {
                    string First = borrBook.ChildNodes.Item(0).InnerText;
                    string Sur = borrBook.ChildNodes.Item(1).InnerText;

                    if (MessageBox.Show("Do you want to delete " + First + " " + Sur, "Delete User", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        xmlC.deleteUser(txtDelID.Text);
                    }
                    else
                    {

                    }

                }
            }
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            MainMenuStaff menuS = new MainMenuStaff();
            this.Hide();
            menuS.Show();
        }

        private void btnClearUpdate_Click(object sender, RoutedEventArgs e)
        {
            txtIDUp.Text = "";
            txtAddressUp.Text = "";
            txtEmailUp.Text = "";
            txtFirstNameUp.Text = "";
            txtPhoneUp.Text = "";
            txtSurnameUp.Text = "";
        }

        private void btnUpdateUser_Click(object sender, RoutedEventArgs e)
        {
            bool AddUser = ValidatorExtensions.UpdatingUser(txtFirstNameUp.Text, txtSurnameUp.Text, txtPhoneUp.Text, txtEmailUp.Text, txtAddressUp.Text,txtIDUp.Text);
            if (AddUser == true)
            {
                userUpdating();
                txtIDUp.Text = "";
                txtAddressUp.Text = "";
                txtEmailUp.Text = "";
                txtFirstNameUp.Text = "";
                txtPhoneUp.Text = "";
                txtSurnameUp.Text = "";

            }

        }

        private void btnClearAdd_Click(object sender, RoutedEventArgs e)
        {
            txtFirstName.Text = "";
            txtSurname.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            dpDOB.Text = "";
            txtAddress.Text = "";
        }
    }
}
