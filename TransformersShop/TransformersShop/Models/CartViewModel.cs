using TransformersShop.Entity;

namespace TransformersShop.Models
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string ProductName { get; set; }
        public string Picture { get; set; }
        public int Quantity { get; set; }
        public bool IsAccepted { get; set; } = false;
    }

}
