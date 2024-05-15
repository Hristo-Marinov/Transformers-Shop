using Microsoft.AspNetCore.Identity;

namespace TransformersShop.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsAdmin { get; set; } = false;
        public ICollection<Cart> Carts { get; set; }
    }
}
