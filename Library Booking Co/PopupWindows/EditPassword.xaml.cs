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
    /// Interaction logic for EditPassword.xaml
    /// </summary>
    public partial class EditPassword : Window
    {
        public EditPassword()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            xmlControllerUser xmlC = new xmlControllerUser();
            Users upDetails = new Users();
            //check if old password exists
            // check if new password meets requirements
            //check if new password matches confirm new password
            string newPass = txtNewPassword.Password;
            string confirmNewPass = txtNewPasswordConfirm.Password;

            if (string.IsNullOrEmpty(txtNewPassword.Password) || string.IsNullOrEmpty(txtOldPassword.Password))
            {
                MessageBox.Show("Invalid password");
            }
            else
            {
                if (ValidatorExtensions.DoesPasswordExist(txtOldPassword.Password, GlobalUserID.UserID) == true)
                {
                    if (ValidatorExtensions.IsValidPassword(txtNewPassword.Password) == true && newPass == confirmNewPass)
                    {
                        upDetails.password = txtNewPassword.Password;
                        xmlC.UpdatePassword(GlobalUserID.UserID, upDetails);
                        MessageBox.Show("Password Changed");
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid password");
                    }


                }
                else
                {
                    MessageBox.Show("Invalid password");
                }
            }

        }
    }
}
