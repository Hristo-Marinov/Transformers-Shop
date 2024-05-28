namespace TransformersShop.Models
{
    using TransformersShop.Entity;
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public int StockCount { get; set; }
        public int Rating { get; set; }
        public string CategoryName { get; set; }
    }
}
