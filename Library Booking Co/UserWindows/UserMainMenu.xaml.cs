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
        MainWindow WindMain = new MainWindow();
        BookManagementUsers BookManU = new BookManagementUsers();

        private void OnClick5(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WindMain.Show();


        }

        private void btnBookManagement_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            BookManU.Show();

        }
    }
}
