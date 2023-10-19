using Library_Booking_Co.BookManagement;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for StaffMainMenu.xaml
    /// </summary>
    public partial class StaffMainMenu : Window
    {
       // UserManagementStaff UsMan = new UserManagementStaff();
       BookManagementStaff BoMan = new BookManagementStaff();
        StaffUserFines FinMsn = new StaffUserFines();
        ReportGenerator Rep = new ReportGenerator();
        MainWindow Main = new MainWindow();
       

        public StaffMainMenu()
        {
            InitializeComponent();
           

        }

        private void btnBookM_Click(object sender, RoutedEventArgs e)
        {
            this.Hide(); // hides current window form view
            BoMan.Show();
        }

        private void btnUserM_Click(object sender, RoutedEventArgs e)
        {
            this.Hide(); // hides current window form view
           // UsMan.Show();
        }

        private void btnFines_Click(object sender, RoutedEventArgs e)
        {
            this.Hide(); // hides current window form view
            FinMsn.Show();
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            this.Hide(); // hides current window form view
            Rep.Show();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Hide(); // hides current window form view
            Main.Show();
        }
    }
}
