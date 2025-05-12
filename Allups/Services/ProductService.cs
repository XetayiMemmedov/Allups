using Allups.DataAccessLayer.DataContext;
using Allups.DataAccessLayer.DataContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace Allups.wwwroot.Services
{
    public class ProductService: IProductService
    {
        private readonly AppDbContext _appDbContext;


        public ProductService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Product GetProductById(int id)
        {
            return _appDbContext.Products
                .Include(p => p.Category)
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProducts(int categoryId, string searchKey)
        {
            var query = _appDbContext.Products.AsQueryable();

            if (categoryId > 0)
            {
                query = query.Where(p => p.CategoryId == categoryId);
            }

            if (!string.IsNullOrEmpty(searchKey))
            {
                query = query.Where(p => p.Name.Contains(searchKey));
            }

            return query.ToList();
        }


        
    }
}
