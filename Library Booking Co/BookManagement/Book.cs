using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Booking_Co.BookManagement
{
    class Book
    {
        public string title { get; set; }
        public string genre { get; set; }
        public string author { get; set; }
        public int publishDate { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public long ISBN { get; set; }
        public string ID { get; set; }
        public string publisher { get; set; }
        public string available { get; set; }
        public int counter { get; set; }
    }
}
