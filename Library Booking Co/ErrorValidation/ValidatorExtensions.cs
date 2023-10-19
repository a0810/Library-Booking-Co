
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace Library_Booking_Co
{
    public static class ValidatorExtensions

    {
        
        public static bool IsValidEmailAddress(this string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }

        public static bool DoesEmailExist(this string f)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(@"LibraryUsers.xml");

            bool looper = true;
            bool emailExist = false;
            while (looper == true)
            {

                XmlNode nodeCheck = doc.SelectSingleNode("//user[email='" + f + "']");
                if (nodeCheck == null)
                {
                    emailExist = false;
                    looper = false;
                }
                else
                {
                    emailExist = true;
                    looper = false;
                }

            }
            return emailExist;

        }

        public static bool DoesEmailExistUpdate(this string f,string UsID)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(@"LibraryUsers.xml");

            bool looper = true;
            bool emailExist = false;
            bool emailIsSame = false;
            bool ValEmail = false;
            XmlNode nodes = doc.SelectSingleNode("/libraryMembers/user[ID='" + UsID + "']");
            string OriginalEmail = nodes.ChildNodes.Item(4).InnerText;

            if (OriginalEmail == f)
            { emailIsSame = true; }

            while (looper == true)
            {

                XmlNode nodeCheck = doc.SelectSingleNode("//user[email='" + f + "']");
                if (nodeCheck == null)
                {
                    emailExist = false;
                    looper = false;
                }
                else
                {
                    emailExist = true;
                    looper = false;
                }

            }

            if (emailExist == false || emailIsSame == true)
            { ValEmail = true; }

            return ValEmail;

        }
        public static bool BookIDtrue(this string book)
        {
            bool BookExists = false;

            XmlDocument doc = new XmlDocument();
            doc.Load(@"BookInventory.xml");
            XmlNode nodeCheck = doc.SelectSingleNode("//book[ID='" + book + "']");

            if (nodeCheck == null)
            {
                MessageBox.Show("Incorrect Book ID. Please try again");
            }
            else
            {
                BookExists = true;

            }
            return BookExists;
        }

        public static bool AddingBook(string author, string title, string price, string isbn, string description, string genre, string publisher, string publishDate)

        {

            string specialChar = @"&»«{}<>_";
            string specialCharISBN = @"-.";
            string specialCharPrice = @"-";
            bool addBook = false; // if addBook false then do NOT add book
            var ISBNNumeric = Int64.TryParse(isbn, out _); //Checks if ISBN input is numeric
            var priceNumeric = double.TryParse(price, out _); //Checks if price input is numeric
            var PDNNumeric = Int32.TryParse(publishDate, out _);//Checks if publish date input is numeric
            bool valCheck = false; // if valCheck true then do NOT add book
            bool range = false;
            bool lengrange = false;

            if (string.IsNullOrEmpty(author) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(price) || string.IsNullOrEmpty(isbn) || string.IsNullOrEmpty(genre) || string.IsNullOrEmpty(publisher) || string.IsNullOrEmpty(publishDate) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Cannot leave fields empty");

            }
            else
            {
                if (Convert.ToInt32(publishDate) > 2023 || Convert.ToInt32(publishDate) < 1000)
                {
                    range = true;
                }

                if (ISBNNumeric == true || priceNumeric == true)
                {
                    foreach (var item in specialCharISBN)
                    {
                        if (isbn.Contains(item))
                        {
                            valCheck = true;
                        }
                    }
                    foreach (var item in specialCharPrice)
                    {
                        if (price.Contains(item))
                        {
                            valCheck = true;
                        }
                    }

                    if (Convert.ToDouble(price) < 0 || Convert.ToDouble(price) >= 100) // if price is smaller than 0 OR price is bigger/equals to 100
                    {
                        valCheck = true;
                    }
                    if (isbn.Length == 13)
                    {
                        lengrange = true; // SHOULD equal 13
                    }

                }
                else
                {
                }

                foreach (var item in specialChar)
                {
                    if (title.Contains(item))
                    {
                        valCheck = true;
                    }
                    if (author.Contains(item))
                    {
                        valCheck = true;
                    }
                    if (description.Contains(item))
                    {
                        valCheck = true;
                    }
                    if (publisher.Contains(item))
                    {
                        valCheck = true;
                    }
                }
                if (ISBNNumeric == false || priceNumeric == false || PDNNumeric == false || valCheck == true || range == true || lengrange == false)
                {
                    MessageBox.Show("Invalid input. Please check your fields and try again");
                }
                else
                {

                    addBook = true;

                }

                
            }

            return addBook;

        }

        public static bool AddingUser(string FirstName, string SurName, string Phone, string Email, string DOB, string Address)
        {

            bool AddUser = false;
            bool valEmail = ValidatorExtensions.IsValidEmailAddress(Email);
            bool existEmail = ValidatorExtensions.DoesEmailExist(Email);
            bool valPhone = ValidatorExtensions.IsValidPhoneNumber(Phone);
            //bool phoneNumeric = long.TryParse(Phone, out _);
            
            string specialChar = @"&»«{}<>_@()[]#?!£$%^*|+=";
            bool spCheck = false;

            if (string.IsNullOrEmpty(DOB) || string.IsNullOrEmpty(Address) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(SurName) || string.IsNullOrEmpty(Phone))
            {
                MessageBox.Show("Cannot leave fields empty");

            }
            else

            {

                foreach (var item in specialChar)
                {
                    if (Address.Contains(item))
                    {
                        spCheck = true;
                    }
                    if (FirstName.Contains(item))
                    {
                        spCheck = true;
                    }
                    if (SurName.Contains(item))
                    {
                        spCheck = true;
                    }


                }
                if (spCheck == true || valPhone == false)
                {
                    MessageBox.Show("Invalid input. Please check your fields and try again");
                }
                else if (valEmail == false)
                {
                    MessageBox.Show("Email not valid");
                    // txtEmail.ForeColor = valid ? Color.Black : Color.Red;
                }
                else if (existEmail == true)
                {
                    MessageBox.Show("This email already exists");
                }
                else
                {
                    AddUser = true;

                }

            }
            
            return AddUser;
        }

        public static bool IsValidPhoneNumber(this string n)
        {
            bool validNumber = false;
            //check if numeric
            //check if length matches
            bool PhoneNumeric = Int64.TryParse(n, out _);
            if (PhoneNumeric==true)
            {
                string Checklength = Convert.ToString(n);
                if (Checklength.Length == 11 || Checklength.Length == 10 || Checklength.Length == 9)
                {
                    validNumber = true;
                }
                else
                {
                   
                }
            }
            else
            {

            }

            return validNumber;
        }
        public static bool IsValidString(this string s)
        {
            bool validString = false;
            string specialChar = @"&»«{}<>_@()[]#?!£$%^*|+=";
            foreach (var item in specialChar)
            {
                if (s.Contains(item))
                {

                }
                else
                {
                    validString = true;
                }

            }
            return validString;
        }

        public static bool IsValidPassword(this string p)
        {
            //checks if length is atleast 8 characters
            //checks if it has atleast one capital letter 
            // Checks if it has a number 
            // Checks if it has no illegal characters
            bool Capital = false;
            bool Number = false;
            bool noSC = false;
            bool validPassword = false;
            if (p.Length >= 8)
            {
                string specialChar = @"&»«{}<>()""''[]^";
                string CAPpool = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string numPool = @"1234567890";
                foreach (var item in specialChar)
                {
                    if (p.Contains(item))
                    {

                    }
                    else
                    {
                        noSC = true;
                    }
                }

                foreach (var item in CAPpool)
                {
                    if (p.Contains(item))
                    {
                        Capital = true;
                    }
                    else
                    {

                    }
                }

                foreach (var item in numPool)
                {
                    if (p.Contains(item))
                    {
                        Number = true;
                    }
                    else
                    {

                    }

                }
            }
            else
            {

            }

            if (Capital == true && Number == true && noSC == true)
            {
                validPassword = true;
            }
            return validPassword;

        }

        public static bool DoesPasswordExist(this string oldPassword, string UsID)
        {
            bool existingPassword = false;
            XmlDocument doc = new XmlDocument();
            doc.Load(@"LibraryUsers.xml");
            XmlNode nodes = doc.SelectSingleNode("/libraryMembers/user[ID='" + UsID + "']");

            

            if (nodes == null)
            {

            }
            else
            {
                string UserPword = nodes.ChildNodes.Item(9).InnerText;
                if (UserPword.Equals(oldPassword)) 
                {
                    existingPassword = true;
                }

                
            }
            return existingPassword;

        }

        public static bool AddingStaff(string FirstName, string SurName, string Phone)
        {
            bool validName = ValidatorExtensions.IsValidString(FirstName);
            bool validSurName = ValidatorExtensions.IsValidString(SurName);
            bool validPhone = ValidatorExtensions.IsValidPhoneNumber(Phone);
            bool AddStaff = false;

            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(SurName) || string.IsNullOrEmpty(Phone)== true)
            {
                MessageBox.Show("Cannot leave fields empty");

            }
            else
            {
                if (validName == true && validSurName ==true  && validPhone==true)
                {
                    AddStaff = true;
                }
            }


            return AddStaff;
        }

        public static bool UpdatingUser(string FirstName, string SurName, string Phone, string Email, string Address, string ID)
        {

            bool AddUser = false;

            //bool phoneNumeric = long.TryParse(Phone, out _);

            string specialChar = @"&»«{}<>_@()[]#?!£$%^*|+=";
            bool spCheck = false;

            if (string.IsNullOrEmpty(Address) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(SurName) || string.IsNullOrEmpty(Phone))
            {
                MessageBox.Show("Cannot leave fields empty");

            }
            else

            {            
                bool valEmail = ValidatorExtensions.IsValidEmailAddress(Email);
                bool existEmail = ValidatorExtensions.DoesEmailExistUpdate(Email,ID);
                bool valPhone = ValidatorExtensions.IsValidPhoneNumber(Phone);

                foreach (var item in specialChar)
                {
                    if (Address.Contains(item))
                    {
                        spCheck = true;
                    }
                    if (FirstName.Contains(item))
                    {
                        spCheck = true;
                    }
                    if (SurName.Contains(item))
                    {
                        spCheck = true;
                    }


                }
                if (spCheck == true || valPhone == false)
                {
                    MessageBox.Show("Invalid input. Please check your fields and try again");
                }
                else if (valEmail == false)
                {
                    MessageBox.Show("Email not valid");
                    // txtEmail.ForeColor = valid ? Color.Black : Color.Red;
                }
                else if (existEmail == false)
                {
                    MessageBox.Show("This email already exists");
                }
                else
                {
                    AddUser = true;

                }

            }

            return AddUser;
        }


    }
}


    


