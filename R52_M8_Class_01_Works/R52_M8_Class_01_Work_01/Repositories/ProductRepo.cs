using Microsoft.EntityFrameworkCore;
using R52_M8_Class_01_Work_01.Models;
using R52_M8_Class_01_Work_01.Repositories.Interfaces;

namespace R52_M8_Class_01_Work_01.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly ProductDbContext db;
        public ProductRepo(ProductDbContext db)
        {
            this.db = db;
        }

        public async Task CompleteAsysnc()
        {
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsysnc(Product product)
        {
            db.Products.Remove(product);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await db.Products.ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await db.Products.FirstAsync(x=>x.Id==id);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await db.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetWithIncludeAsync()
        {
            return await db.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task InsertAsysnc(Product product)
        {
            await db.Products.AddAsync(product);
        }

        public async Task UpdateAsysnc(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            await Task.CompletedTask;
        }
    }
}
