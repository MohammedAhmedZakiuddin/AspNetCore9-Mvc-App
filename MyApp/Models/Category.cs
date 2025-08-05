namespace MyApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!; // Using null-forgiving operator to indicate that Name will not be null
        public List<Item>? Items { get; set; } = new List<Item>(); // Navigation property to the related Items
    }
}
