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
    /// Interaction logic for EditPhone.xaml
    /// </summary>
    public partial class EditPhone : Window
    {
        public EditPhone()
        {
            InitializeComponent();
        }

        private void btnChangePhone_Click(object sender, RoutedEventArgs e)
        {
            xmlControllerUser xmlC = new xmlControllerUser();
            Users upDetails = new Users();
            //Check phone is valid
            //call add function

            if (ValidatorExtensions.IsValidPhoneNumber(txtNewPhone.Text) == true)
            {
                upDetails.phone = Convert.ToInt64(txtNewPhone.Text);
                xmlC.UpdatePhone(GlobalUserID.UserID, upDetails);
                MessageBox.Show("Phone Number Updated");
                this.Hide();

            }
            else
            {
                MessageBox.Show("Invaid phone number.");
            }
        }
    }
}
