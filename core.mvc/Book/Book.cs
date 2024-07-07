using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.mvc.Book
{
    public class Book
    {
        public int Id { get; set; }
       // public int BookID { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public int PublishedYear { get; set; }
        public int Quantity { get; set; }
    }
    //public class BookDto
    //{
    //    public int Id { get; set; }
    //    public string? Title { get; set; }
    //    public string? Author { get; set; }
    //}

    public class BookDto
    {
        public int BookID { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public int PublishedYear { get; set; }
        public int Quantity { get; set; }
    }
    public class BookInsert
    {
       
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public int PublishedYear { get; set; }
        public int Quantity { get; set; }
    }
    public class BookUpdate
    {
        public int BookID { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public int PublishedYear { get; set; }
        public int Quantity { get; set; }
    }
}
