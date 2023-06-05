using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace R52_M7_Class_02_Work_01.Models
{
    
    public class Product
    {
        public int ProductId { get; set; }
        [Required, StringLength(40), Display(Name ="Product Name")]
        public string ProductName { get; set; }
        [Required, Column(TypeName ="money"), DisplayFormat(DataFormatString ="{0:0.00}")]
        public decimal Price { get; set; }
    }
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set;}
        
    }
}