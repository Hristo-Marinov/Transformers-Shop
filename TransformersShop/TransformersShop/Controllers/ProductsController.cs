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

        public async Task<IActionResult> ProductList(int page = 1, int pageSize = 6)
        {
            var products = await _context.Products
                .Include(p => p.ProductsInStock)
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Picture = p.Picture,
                    Description = p.Description,
                    StockCount = p.ProductsInStock.Count,
                    Rating = 5
                })
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var totalProducts = await _context.Products.CountAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);

            return View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Products
                .Include(p => p.ProductsInStock)
                .Where(p => p.Id == id)
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Picture = p.Picture,
                    Description = p.Description,
                    StockCount = p.ProductsInStock.Count,
                    Rating = 5
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
