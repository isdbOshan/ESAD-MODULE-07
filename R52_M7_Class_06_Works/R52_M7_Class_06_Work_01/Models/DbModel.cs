using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace R52_M7_Class_06_Work_01.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Title { get; set; }
        [Required, Column(TypeName ="date"), Display(Name ="Publish date"), DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
        public DateTime  PublishDate     { get; set; }
        [Required]
        public int TotalView { get; set; }
        public double Rating { get; set; }
    }
    public class ArticleDbContext : DbContext
    {
       
        public DbSet<Article> Articles { get; set;}
        
    }
}