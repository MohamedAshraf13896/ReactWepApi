using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAbi.Models
{
    public class Platform
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; } 
    }
}
