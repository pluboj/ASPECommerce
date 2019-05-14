using System.ComponentModel.DataAnnotations;

namespace ASP.Data.Entities
{
    public class ProductVariant
    {
        public int ProductId { get; set; }
        public int ColourId { get; set; }
        public int StorageId { get; set; }

        [Required]
        public decimal Price { get; set; }

        public Product Product { get; set; }
        public Colour Colour { get; set; }
        public Storage Storage { get; set; }
    }
}