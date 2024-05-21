using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TransformersShop.Entity;
using TransformersShop.Models;
using TransformersShop.Models;

namespace TransformersShop.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var cartItems = await _context.Carts
                .Include(c => c.Product)
                .Where(c => c.UserId == user.Id && !c.IsAccepted)
                .ToListAsync();

            var cartViewModels = cartItems.Select(c => new CartViewModel
            {
                Id = c.Id,
                ProductId = c.ProductId,
                ProductName = c.Product.Name,
                Quantity = c.Quantity,
                Picture = c.Product.Picture
            }).ToList();

            return View(cartViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            var user = await _userManager.GetUserAsync(User);
            var cartItem = await _context.Carts
                .FirstOrDefaultAsync(c => c.UserId == user.Id && c.ProductId == productId && !c.IsAccepted);

            if (cartItem == null)
            {
                cartItem = new Cart
                {
                    UserId = user.Id,
                    ProductId = productId,
                    Quantity = quantity
                };
                _context.Carts.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var cartItem = await _context.Carts.FindAsync(id);
            _context.Carts.Remove(cartItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Checkout()
        {
            var user = await _userManager.GetUserAsync(User);
            var cartItems = await _context.Carts
                .Where(c => c.UserId == user.Id && !c.IsAccepted)
                .ToListAsync();

            foreach (var item in cartItems)
            {
                item.IsAccepted = true;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
