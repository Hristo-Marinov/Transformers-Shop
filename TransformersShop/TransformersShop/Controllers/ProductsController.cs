using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TransformersShop.Entity;
using TransformersShop.Models;

namespace TransformersShop.Controllers
{
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
                .Include(p => p.Category)
                .Include(p => p.Ratings)
                .ThenInclude(r => r.User)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Picture = product.Picture,
                Description = product.Description,
                StockCount = product.StockCount,
                CategoryName = product.Category.Name,
                Ratings = product.Ratings.Select(r => new RatingViewModel
                {
                    Stars = r.Stars,
                    Comment = r.Comment,
                    UserName = r.User.UserName,
                    Date = r.Date
                }).ToList(),
                Rating = product.Ratings.Any() ? (int)product.Ratings.Average(r => r.Stars) : 0
            };

            return View(productViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SubmitRating(int productId, int stars, string comment)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            if (user == null)
            {
                return BadRequest();
            }

            var rating = new Rating
            {
                ProductId = productId,
                UserId = user.Id,
                Stars = stars,
                Comment = comment,
                Date = DateTime.Now
            };

            _context.Ratings.Add(rating);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = productId });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            if (user == null)
            {
                return BadRequest();
            }

            var cartItem = new Cart
            {
                ProductId = productId,
                UserId = user.Id,
                Quantity = 1,
                IsAccepted = false
            };

            _context.Carts.Add(cartItem);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = productId });
        }
    }
}
