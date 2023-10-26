using Library_Booking_Co.PopupWindows;
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
using System.Xml;

namespace Library_Booking_Co.UserWindows
{
    /// <summary>
    /// Interaction logic for UserProfile.xaml
    /// </summary>
    public partial class UserProfile : Window
    {

        public UserProfile()
        {
            InitializeComponent();

            lblFirstSurname.Content = (GlobalUserID.FirstName + " " + GlobalUserID.SurName);
            lblID.Content = "ID: " + GlobalUserID.UserID;
            lblEmail.Content = "Email: " + GlobalUserID.Email;
            lblMS.Content = "Member Since: " + GlobalUserID.DOI;
            lblAddress.Text = "Address: " + GlobalUserID.Address;
            lblPhone.Content = "Phone: " + GlobalUserID.Phone;
            lblBalance.Content = "Balance: £" + GlobalUserID.Balance;



        }



        private void btnHome_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEmail_Click(object sender, RoutedEventArgs e)
        {
            EditEmail updateEmail = new EditEmail();
            updateEmail.ShowDialog(); // calls dialog window

        }

        private void btnHome_Click_1(object sender, RoutedEventArgs e)
        {
            UserMainMenu mUs = new UserMainMenu();
            this.Hide();
            mUs.Show();
        }

        private void btnPhone_Click(object sender, RoutedEventArgs e)
        {
            EditPhone updatePhone = new EditPhone();
            updatePhone.ShowDialog();
        }

        private void btnAddress_Click(object sender, RoutedEventArgs e)
        {
            EditAddress updateAddress = new EditAddress();
            updateAddress.ShowDialog();
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            EditPassword updatePassword = new EditPassword();
            updatePassword.ShowDialog();
        }
    }
}
