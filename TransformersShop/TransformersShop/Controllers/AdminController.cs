using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TransformersShop.Entity;
using TransformersShop.Models;

namespace YourNamespace.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _context.Carts
                .Include(c => c.Product)
                .Include(c => c.User)
                .Where(c => c.IsAccepted)
                .ToListAsync();

            var orderViewModels = orders.Select(o => new OrderViewModel
            {
                Id = o.Id,
                UserId = o.UserId,
                UserName = o.User.UserName,
                ProductId = o.ProductId,
                ProductName = o.Product.Name,
                Quantity = o.Quantity,
                Status = "Pending"
            }).ToList();

            return View(orderViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Deliver(int id)
        {
            var order = await _context.Carts.Include(c => c.Product).FirstOrDefaultAsync(c => c.Id == id);
            if (order != null && order.Product.StockCount >= order.Quantity)
            {
                order.Product.StockCount -= order.Quantity;
                _context.Carts.Remove(order);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Restock()
        {
            var products = await _context.Products.ToListAsync();
            var productViewModels = products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Picture = p.Picture,
                Description = p.Description,
                StockCount = p.StockCount
            }).ToList();

            return View(productViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Restock(int productId, int stockCount)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                product.StockCount += stockCount;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Restock");
        }
    }
}
