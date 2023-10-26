using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Booking_Co.UserManagement
{
    class PasswordGen
    {
        public PasswordGen()
        {
        }

        public string RandomPassword()
        {
            Random random = new Random();
            var passwordBuild = new System.Text.StringBuilder();
            string charPool = @"abcdefghABCDEFGH1234567890";
            string symPool = @"-_";
            int rand1 = random.Next(3, 5);
            int rand2 = random.Next(3, 5);
            int rand3 = random.Next(3, 5);
            int randSym1 = random.Next(0, 2);
            int randSym2 = random.Next(0, 2);

            // password format 3 parts, each section random length between 3 and 4
            // dash (-) or underscore (_) between sections

            for (int i = 0; i < rand1; i++)
            {
                int picker = random.Next(0, 25);
                passwordBuild.Append(charPool[picker]);
            }
            passwordBuild.Append(symPool[randSym1]);
            for (int i = 0; i < rand2; i++)
            {
                int picker = random.Next(0, 25);
                passwordBuild.Append(charPool[picker]);
            }
            passwordBuild.Append(symPool[randSym2]);
            for (int i = 0; i < rand3; i++)
            {
                int picker = random.Next(0, 25);
                passwordBuild.Append(charPool[picker]);
            }
            string password = passwordBuild.ToString();
            return password;
        }
    }
}
