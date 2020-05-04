namespace BLL.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public int Sales { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int AvailableItems { get; set; }
    }
}
