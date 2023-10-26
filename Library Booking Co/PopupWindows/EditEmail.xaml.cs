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
    /// Interaction logic for EditEmail.xaml
    /// </summary>
    public partial class EditEmail : Window
    {
        public EditEmail()
        {
            InitializeComponent();
        }

        private void btnChangeMail_Click(object sender, RoutedEventArgs e)
        {
            xmlControllerUser xmlC = new xmlControllerUser();
            Users upDetails = new Users();

            if (string.IsNullOrEmpty(txtNewEmail.Text))
            {
                MessageBox.Show("Please input an email address");
            }
            else
            {

                if (ValidatorExtensions.IsValidEmailAddress(txtNewEmail.Text) == true)
                {
                    if (ValidatorExtensions.DoesEmailExist(txtNewEmail.Text) == true)
                    {
                        MessageBox.Show("This email already exists");

                    }
                    else
                    {
                        upDetails.email = txtNewEmail.Text;
                        xmlC.UpdateEmail(GlobalUserID.UserID, upDetails);
                        MessageBox.Show("Email Updated");

                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Not a valid emaild address.");
                }
            }

        }
    }
}
