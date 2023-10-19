using Library_Booking_Co.UserManagement;
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

namespace Library_Booking_Co.PopupWindows
{
    /// <summary>
    /// Interaction logic for EditAddress.xaml
    /// </summary>
    public partial class EditAddress : Window
    {
        public EditAddress()
        {
            InitializeComponent();
        }

        private void btnChangePhone_Click(object sender, RoutedEventArgs e)
        {
            xmlControllerUser xmlC = new xmlControllerUser();
            Users upDetails = new Users();

            if (string.IsNullOrEmpty(txtNewAddress.Text))
            {
                MessageBox.Show("Please input a valid address");
            }
            else
            {
                if (ValidatorExtensions.IsValidString(txtNewAddress.Text) == true) // checking it does not contain unauthorised charachers 
                {
                    upDetails.address = txtNewAddress.Text;
                    xmlC.UpdateAddress(GlobalUserID.UserID, upDetails);
                    MessageBox.Show("Address Updated");
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Invaid Input.");
                }
            }
        }
    }
}
