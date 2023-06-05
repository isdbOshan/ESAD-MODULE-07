using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace R52_M7_Class_07_Work_01.Models
{
    public enum Genre { Novel=1, Drama, Autobigraphy, Classics }
    public enum Format { Ebook = 1, PDF, Print }
    public class Book
    {
        public int BookId { get; set; }
        [Required, StringLength(40), Display(Name = "Book Title")]
        public string Title { get; set; }
        [Required, EnumDataType(typeof(Genre))]
        public Genre Genre { get; set; }
        [Required, Display(Name = "Cover Price"), DisplayFormat(DataFormatString = "{0:0.00}")]
        public double Price { get; set; }
        [Required, EnumDataType(typeof(Format))]
        public Format Format { get; set; }

    }
    public class BooksDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}