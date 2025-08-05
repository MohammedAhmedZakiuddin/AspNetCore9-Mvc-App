using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models
{
    public class SerialNumber
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!; // Using null-forgiving operator to indicate that Serial will not be null
        public int? ItemId { get; set; } // Foreign key to link to an Item
        [ForeignKey("ItemId")]
        public Item? Item { get; set; } // Navigation property to the related Item. 

    }
}
