namespace TransformersShop.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public int StockCount { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
