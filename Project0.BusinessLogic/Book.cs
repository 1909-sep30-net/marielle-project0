using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.library
{
    public class Book : Product
    {
        private string title;
        private string author;
        private string genre;

        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
    }
}
