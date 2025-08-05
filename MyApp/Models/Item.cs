using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!; // Using null-forgiving operator to indicate that Name will not be null
        public double Price { get; set; }
        public int? SerialNumberId { get; set; } // Foreign key to link to a SerialNumber
        public SerialNumber? SerialNumber { get; set; } // Navigation property to the related SerialNumber
        public int ItemId { get; internal set; }
        public int? CategoryId { get; set; } // Foreign key to link to a Category
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; } // Navigation property to the related Category
    }
}
