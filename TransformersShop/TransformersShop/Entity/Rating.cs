using System.ComponentModel.DataAnnotations.Schema;
using TransformersShop.Entity;

namespace TransformersShop.Entity
{
    public class Rating
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Stars { get; set; } 
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
