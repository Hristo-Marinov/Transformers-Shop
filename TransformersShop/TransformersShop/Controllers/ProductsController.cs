using Microsoft.AspNetCore.Mvc;

namespace TransformersShop.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;
    using TransformersShop.Entity;
    using TransformersShop.Models;

    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ProductList(int? categoryId, int page = 1, int pageSize = 10)
        {
            var categories = await _context.Categories.ToListAsync();
            ViewBag.Categories = categories;

            var products = _context.Products.Include(p => p.Category).AsQueryable();

            if (categoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == categoryId.Value);
            }

            var productViewModels = await products
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Picture = p.Picture,
                    StockCount = p.StockCount,
                    CategoryName = p.Category.Name,
                }).ToListAsync();

            ViewBag.TotalPages = (int)Math.Ceiling(products.Count() / (double)pageSize);
            ViewBag.CurrentPage = page;

            return View(productViewModels);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Products
                .Where(p => p.Id == id)
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Picture = p.Picture,
                    Description = p.Description,
                    StockCount = p.StockCount,
                    Rating = 5,
                    CategoryName = p.Category.Name
                })
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }

}
