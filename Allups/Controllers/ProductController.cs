using Allups.DataAccessLayer.DataContext;
using Allups.wwwroot.Services;
using Microsoft.AspNetCore.Mvc;

public class ProductController : Controller
{

    private readonly IProductService _productService;
    private readonly AppDbContext _appDbContext;

    public ProductController(IProductService productService, AppDbContext appDbContext)
    {
        _productService = productService;
        _appDbContext = appDbContext;
    }

    public ActionResult Details(int id)
    {
        var product = _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }

        ViewData["Categories"] = _appDbContext.Categories.ToList();

        return View(product);
    }
}
