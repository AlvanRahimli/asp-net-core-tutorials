using System.Collections.Generic;

namespace Ders2.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        public List<CategoryProduct> Products { get; set; }
    }
}