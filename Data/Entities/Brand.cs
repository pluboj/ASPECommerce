using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP.Data.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}