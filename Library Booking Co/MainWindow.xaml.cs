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
        public MainWindow()
        {
            InitializeComponent();
            
            
        }
        
        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            UserMainMenu usMain = new UserMainMenu();
            MainWindow windMain = new MainWindow();
            LogInValidation newLogIn = new LogInValidation();
            

            bool Logtrue = newLogIn.UserIDandPword(txtIdUI.Text, txtPasswordUI.Text);
            GlobalUserID.UserID = txtIdUI.Text;


            if (Logtrue== true)
            {
                this.Hide();
                usMain.Show();

            }

        }
    }
}
