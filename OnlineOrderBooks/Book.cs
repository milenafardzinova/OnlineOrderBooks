using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderBooks
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author {  get; set; }
        public int AvailableCount { get; set; }

        public Book (int id, string title, string author, int count) 
        {
            Id = id;
            Title = title;
            Author = author;
            AvailableCount= count;
        }

    }
}
