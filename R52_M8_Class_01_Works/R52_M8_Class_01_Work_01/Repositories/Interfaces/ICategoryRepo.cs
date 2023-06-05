using R52_M8_Class_01_Work_01.Models;

namespace R52_M8_Class_01_Work_01.Repositories.Interfaces
{
    public interface ICategoryRepo
    {
        Task<IEnumerable<Category>> GetAsync();
        Task<Category> GetAsync(int id);
        Task InsertAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Category category);
        Task CompleteAsync();
    }
}
