using R52_M8_Class_01_Work_01.Models;

namespace R52_M8_Class_01_Work_01.Repositories.Interfaces
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetAsync();
        Task<IEnumerable<Product>> GetWithIncludeAsync();
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Product> GetAsync(int id);
        Task InsertAsysnc(Product product);
        Task UpdateAsysnc(Product product);
        Task DeleteAsysnc(Product product);
        Task CompleteAsysnc();
    }
}
