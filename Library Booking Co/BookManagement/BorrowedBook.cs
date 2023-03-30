using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Booking_Co
{
    class BorrowedBook
    {
        public string ID { get; set; }
        public string dateOfIssue { get; set; }
        public string returnBy { get; set; }
        public string ISBN { get; set; }
    }
}
