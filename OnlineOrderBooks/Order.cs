using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderBooks
{
    public class Order
    {
        public Book OrderedBook { get; set; }
        public string ReaderName { get; set; }
        public DateTime ReturnDate { get; set; }

        public Order(Book book, string readerName, DateTime returnDate)
        {
            OrderedBook = book;
            ReaderName = readerName;
            ReturnDate = returnDate;
        }
    }
}
