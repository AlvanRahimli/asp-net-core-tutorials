using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ders2.Models
{
    public class CategoryProduct
    {
        public int CategoryId { get; set; }
        [Required]
        public Category Category { get; set; }

        public int ProductId { get; set; }
        [Required]
        public Product Product { get; set; }
    }
}