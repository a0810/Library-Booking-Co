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

namespace Library_Booking_Co.StaffWindows
{
    /// <summary>
    /// Interaction logic for MainMenuStaff.xaml
    /// </summary>
    public partial class MainMenuStaff : Window
    {
        
        
        
        
        
        public MainMenuStaff()
        {
            InitializeComponent();
        }



        private void btnManageBooks_Click(object sender, RoutedEventArgs e)
        {
            BookManagementStaff BoMan = new BookManagementStaff();
            this.Hide();
            BoMan.Show();

        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Main = new MainWindow();
            this.Hide();
            Main.Show();
        }

        private void btnManageUsers_Click(object sender, RoutedEventArgs e)
        {
            UserManagementStaff UsMan = new UserManagementStaff();
            this.Hide();
            UsMan.Show();
        }

        private void btnFines_Click(object sender, RoutedEventArgs e)
        {
            StaffUserFines FinMan = new StaffUserFines();
            this.Hide();
            FinMan.Show();
        }

        private void btnReports_Click(object sender, RoutedEventArgs e)
        {
            ReportGenerator Rep = new ReportGenerator();
            this.Hide();
            Rep.Show();
        }
    }
}
