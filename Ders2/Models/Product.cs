using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ders2.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Produkt adi 3 ve 150 simvol arasinda olmalidir!")]
        public string Name { get; set; }
        [Range(0, int.MaxValue)]
        public int Price { get; set; }
    }
}
