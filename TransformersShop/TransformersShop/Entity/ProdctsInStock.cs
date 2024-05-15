using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TransformersShop.Entity
{
    public class ProductsInStock
    {
        [Key, ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Count { get; set; } = 10;
        public Product Product { get; set; }
    }
}
