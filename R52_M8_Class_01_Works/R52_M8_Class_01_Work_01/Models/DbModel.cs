using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace R52_M8_Class_01_Work_01.Models
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
    public class Category : EntityBase
    {
        [Required, StringLength(50)]
        public string CategoryName { get; set; } = default!;
        [Required, StringLength(150)]
        public string Description { get; set; } = default!;
        public virtual ICollection<Category> Categories { get;set; }= new List<Category>();
    }
    public class Product : EntityBase
    {
        [Required, StringLength(50)]
        public string ProductName { get; set; } = default!;
        [Required, Column(TypeName ="money")]
        public decimal UnitPrice { get; set; }
        [Required, ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = default!;
    }
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category {  Id=1, CategoryName="Category 1", Description="Description"}
                );
            modelBuilder.Entity<Product>().HasData( new Product { Id=1, ProductName="Product 1", UnitPrice=50.00M, CategoryId=1 } );

        }
    }
}
