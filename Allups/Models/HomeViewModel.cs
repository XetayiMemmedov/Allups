using Allups.DataAccessLayer.DataContext.Entities;

namespace Allups.Models
{
    public class HomeViewModel
    {
        public List<Product>Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}
