using Allups.DataAccessLayer.DataContext.Entities;

namespace Allups.wwwroot.Services
{
    public interface IProductService
    {
        Product GetProductById(int id);
        IEnumerable<Product> GetProducts(int categoryId, string searchKey);
    }
}
