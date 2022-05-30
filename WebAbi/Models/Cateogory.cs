using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAbi.Models
{
    public class Cateogory
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public virtual List<Product> Products { get; set; } 
    }
}
