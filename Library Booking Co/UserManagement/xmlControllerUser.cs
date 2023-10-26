using Library_Booking_Co.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Library_Booking_Co
{
    class xmlControllerUser
    {
        string path = @"LibraryUsers.xml";
        string StaffPath = @"Staff.xml";
        public void addUser(Users newUser)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNode ROOT = doc.SelectSingleNode("/libraryMembers");
            XmlNode User = doc.CreateElement("user");
            XmlNode FirstName = doc.CreateElement("firstName");
            XmlNode SurName = doc.CreateElement("surName");
            XmlNode DOB = doc.CreateElement("DOB");
            XmlNode Address = doc.CreateElement("adress");
            XmlNode Email = doc.CreateElement("email");
            XmlNode DateOfIssue = doc.CreateElement("dateOfIssue");
            XmlNode ID = doc.CreateElement("ID");
            XmlNode BorrowedBooks = doc.CreateElement("borrowedBooks");
            XmlNode SavedBooks = doc.CreateElement("savedBooks");
            XmlNode Password = doc.CreateElement("password");
            XmlNode PhoneNumber = doc.CreateElement("phone");
            XmlNode Balance = doc.CreateElement("balance");




            FirstName.InnerText = newUser.firstName;
            SurName.InnerText = newUser.surName;
            DOB.InnerText = newUser.DOB;
            Address.InnerText = newUser.address;
            Email.InnerText = newUser.email;
            DateOfIssue.InnerText = newUser.dateOfIssue;
            BorrowedBooks.InnerText = newUser.borrowedBooks;
            ID.InnerText = newUser.ID;
            SavedBooks.InnerText = newUser.savedBooks;
            Password.InnerText = newUser.password;
            PhoneNumber.InnerText = newUser.phone.ToString();
            Balance.InnerText = newUser.balance.ToString();



            User.AppendChild(FirstName);
            User.AppendChild(SurName);
            User.AppendChild(DOB);
            User.AppendChild(Address);
            User.AppendChild(Email);
            User.AppendChild(DateOfIssue);
            User.AppendChild(ID);
            User.AppendChild(BorrowedBooks);
            User.AppendChild(SavedBooks);
            User.AppendChild(Password);
            User.AppendChild(PhoneNumber);
            User.AppendChild(Balance);

            ROOT.AppendChild(User);
            doc.Save(path);
        }
        public void deleteUser(string ID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode nodes = doc.SelectSingleNode("//user[ID='" + ID + "']");
            nodes.ParentNode.RemoveChild(nodes);
            doc.Save(path);
        }

        public void GetInfo(string ID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);


            XmlNode userDeet = doc.SelectSingleNode("//user[ID='" + ID + "']");
            if (userDeet != null)
            {


                GlobalUserID.FirstName = userDeet.ChildNodes.Item(0).InnerText;
                GlobalUserID.SurName = userDeet.ChildNodes.Item(1).InnerText;
                GlobalUserID.Address = userDeet.ChildNodes.Item(3).InnerText;
                GlobalUserID.Email = userDeet.ChildNodes.Item(4).InnerText;
                GlobalUserID.DOI = userDeet.ChildNodes.Item(5).InnerText;
                GlobalUserID.Phone = userDeet.ChildNodes.Item(10).InnerText;
                GlobalUserID.Balance = userDeet.ChildNodes.Item(11).InnerText;

            }
        }
        public void UpdateEmail(string ID, Users upDetails)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode oldEmail = doc.SelectSingleNode("//user[ID='" + ID + "']");
            oldEmail.ChildNodes.Item(4).InnerText = upDetails.email;
            doc.Save(path);
            GlobalUserID.Email = oldEmail.ChildNodes.Item(4).InnerText;

        }
        public void UpdatePhone(string ID, Users upDetails)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode oldPhone = doc.SelectSingleNode("//user[ID='" + ID + "']");
            oldPhone.ChildNodes.Item(10).InnerText = upDetails.phone.ToString();
            doc.Save(path);
            GlobalUserID.Phone = oldPhone.ChildNodes.Item(10).InnerText;

        }

        public void UpdateAddress(string ID, Users upDetails)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode oldAddress = doc.SelectSingleNode("//user[ID='" + ID + "']");
            oldAddress.ChildNodes.Item(3).InnerText = upDetails.address;
            doc.Save(path);
            GlobalUserID.Address = oldAddress.ChildNodes.Item(3).InnerText;

        }
        public void UpdatePassword(string ID, Users upDetails)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode oldPassword = doc.SelectSingleNode("//user[ID='" + ID + "']");
            oldPassword.ChildNodes.Item(9).InnerText = upDetails.password;
            doc.Save(path);

        }

        public void UpdateUserDetails(string ID, Users upDetails)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode oldDetails = doc.SelectSingleNode("//user[ID='" + ID + "']");

            oldDetails.ChildNodes.Item(0).InnerText = upDetails.firstName;
            oldDetails.ChildNodes.Item(1).InnerText = upDetails.surName;
            oldDetails.ChildNodes.Item(3).InnerText = upDetails.address;
            oldDetails.ChildNodes.Item(4).InnerText = upDetails.email;
            oldDetails.ChildNodes.Item(9).InnerText = upDetails.phone.ToString();

            doc.Save(path);

        }

        public void addStaff(Staff newStaff)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaffPath);

            XmlNode ROOT = doc.SelectSingleNode("/staffMembers");
            XmlNode Staff = doc.CreateElement("staff");
            XmlNode FirstName = doc.CreateElement("firstName");
            XmlNode SurName = doc.CreateElement("surName");
            XmlNode StartDate = doc.CreateElement("startDate");
            XmlNode ID = doc.CreateElement("ID");
            XmlNode Password = doc.CreateElement("password");
            XmlNode PhoneNumber = doc.CreateElement("Phone");



            FirstName.InnerText = newStaff.firstName;
            SurName.InnerText = newStaff.surName;
            StartDate.InnerText = newStaff.startDate;
            ID.InnerText = newStaff.ID;
            Password.InnerText = newStaff.password;
            PhoneNumber.InnerText = newStaff.phone.ToString();


            Staff.AppendChild(FirstName);
            Staff.AppendChild(SurName);

            Staff.AppendChild(ID);
            Staff.AppendChild(Password);
            Staff.AppendChild(PhoneNumber);
            Staff.AppendChild(StartDate);

            ROOT.AppendChild(Staff);
            doc.Save(StaffPath);
        }

        public void deleteStaff(string ID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaffPath);
            XmlNode nodes = doc.SelectSingleNode("//staff[ID='" + ID + "']");
            nodes.ParentNode.RemoveChild(nodes);
            doc.Save(StaffPath);
        }
    }
}

