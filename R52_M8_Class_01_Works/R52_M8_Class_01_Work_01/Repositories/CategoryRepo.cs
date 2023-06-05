using Microsoft.EntityFrameworkCore;
using R52_M8_Class_01_Work_01.Models;
using R52_M8_Class_01_Work_01.Repositories.Interfaces;

namespace R52_M8_Class_01_Work_01.Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        ProductDbContext db;
        public CategoryRepo(ProductDbContext db)
        {
            this.db = db;
        }

        public async Task CompleteAsync()
        {
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
            db.Categories.Remove(category);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            return await db.Categories.ToListAsync();
           
        }
        public async Task<Category> GetAsync(int id)
        {
            return await db.Categories.FirstAsync(x => x.Id == id);
        }

        public async Task InsertAsync(Category category)
        {
            await db.Categories.AddAsync(category);
        }

        public async Task UpdateAsync(Category category)
        {
            db.Entry(category).State = EntityState.Modified;   
            await Task.CompletedTask;
        }
    }
}
