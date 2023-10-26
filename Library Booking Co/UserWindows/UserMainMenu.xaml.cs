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

namespace Library_Booking_Co.UserWindows
{
    /// <summary>
    /// Interaction logic for UserMainMenu.xaml
    /// </summary>
    public partial class UserMainMenu : Window
    {
        public UserMainMenu()
        {
            InitializeComponent();
            
        }
        
       
        
        

        private void OnClick5(object sender, RoutedEventArgs e)
        {
            MainWindow WindMain = new MainWindow();
            this.Hide();
            WindMain.Show();


        }

        private void btnBookManagement_Click(object sender, RoutedEventArgs e)
        {
            BookManagementUsers BookManU = new BookManagementUsers();
            this.Hide();
            BookManU.Show();

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            BookSearchUser BooS = new BookSearchUser();
            this.Hide();
            BooS.Show();

        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            UserProfile UsP = new UserProfile();
            this.Hide();
            UsP.Show();
        }
    }
}
