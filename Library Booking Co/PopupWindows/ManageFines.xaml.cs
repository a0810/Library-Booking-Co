using Microsoft.VisualBasic;
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
using System.Xml;

namespace Library_Booking_Co.PopupWindows
{
    /// <summary>
    /// Interaction logic for ManageFines.xaml
    /// </summary>
    public partial class ManageFines : Window
    {
        string path = @"LibraryUsers.xml";
        public ManageFines()
        {
            InitializeComponent();
            
            lblNameSurname.Text = StaffGlobalUserID.Name + " " + StaffGlobalUserID.Surname;
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode nodes = doc.SelectSingleNode("//user[ID='" + StaffGlobalUserID.ID + "']");
            lblBalance.Text = "Balance: £" + nodes.ChildNodes.Item(11).InnerText;
        }

        private void btnIncrease_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode nodes = doc.SelectSingleNode("//user[ID='" + StaffGlobalUserID.ID + "']");

            string stringUserFee = Interaction.InputBox("Enter fine in pounds. (Remember 50 pence is 0.5 pounds)", "Add to balance", "");

            if (Double.TryParse(stringUserFee, out double doubleUserFee) == true && doubleUserFee>0)//|| doubleUserFee != 0
            {
                double userBalance = Convert.ToDouble(nodes.ChildNodes.Item(11).InnerText);
                double newUserBalance = Math.Round((userBalance + doubleUserFee),2);
                nodes.ChildNodes.Item(11).InnerText = newUserBalance.ToString();
                doc.Save(@"LibraryUsers.xml");
                MessageBox.Show("£" + doubleUserFee + " has been added to the account.");

            }
            else
            {
                MessageBox.Show("Invalid input.");
            }

            


        }

        private void btnDecrease_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode nodes = doc.SelectSingleNode("//user[ID='" + StaffGlobalUserID.ID + "']");

            string stringUserFee = Interaction.InputBox("Enter amount paid in pounds. (Remember 50 pence is 0.5 pounds)", "Remove from balance", "");

            if (Double.TryParse(stringUserFee, out double doubleUserFee) == true && doubleUserFee > 0)
            {
                double userBalance = Convert.ToDouble(nodes.ChildNodes.Item(11).InnerText);
                double newUserBalance = Math.Round((userBalance - doubleUserFee), 2);
                if (newUserBalance>0)
                {
                    nodes.ChildNodes.Item(11).InnerText = newUserBalance.ToString();
                    doc.Save(@"LibraryUsers.xml");
                    MessageBox.Show("£" + doubleUserFee + " has been paid into the account.");
                }
                else
                {
                    MessageBox.Show("Value entered cannot be bigger than the member's current balance");
                }

            }
            else
            {
                MessageBox.Show("Invalid input.");
            }

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode nodes = doc.SelectSingleNode("//user[ID='" + StaffGlobalUserID.ID + "']");

            nodes.ChildNodes.Item(11).InnerText = "0.00";
            doc.Save(@"LibraryUsers.xml");
            MessageBox.Show("Balance has been cleared.");
        }
    }
}
