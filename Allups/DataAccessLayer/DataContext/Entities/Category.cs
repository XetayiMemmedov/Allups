namespace Allups.DataAccessLayer.DataContext.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public required string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
