using Library_Booking_Co.StaffWindows;
using Library_Booking_Co.UserWindows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library_Booking_Co
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string AdminID = @"L2TTC8O";
        public string AdminPassword = @"7aF3_EM1c_qhK7";
        public MainWindow()
        {
            InitializeComponent();
       
        }
        
        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
           
            MainWindow windMain = new MainWindow();
            LogInValidation newLogIn = new LogInValidation();
            xmlControllerUser details = new xmlControllerUser();
            
            FineManagement newFine = new FineManagement();

            

            bool UserLogtrue = newLogIn.UserIDandPword(txtIdUI.Text, txtPasswordUI.Password); //Checks if ID and password match if yes returns true
            bool StaffLogtrue = newLogIn.StaffIDandPword(txtIdUI.Text, txtPasswordUI.Password);
            

            


            if (UserLogtrue== true)
            {
                //loads user menu window
                GlobalUserID.UserID = txtIdUI.Text; //stores id in global class so it can be used accross the program.
                details.GetInfo(txtIdUI.Text);
                UserMainMenu usMain = new UserMainMenu();
                this.Hide();
                usMain.Show();

            }
            else if (StaffLogtrue==true)
            {
                //loads staff menu window
                MainMenuStaff stMain = new MainMenuStaff();
                this.Hide();
                stMain.Show();

            }
            else
            {
                MessageBox.Show("Incorrect ID or Password");
            }

        }
    }
}
