using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAbi.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public int Salary { get; set; }
        public string? Img { get; set; }
        [ForeignKey("Cateogory")]
        public int? Cateogory_ID { get; set; }
        [ForeignKey("Platform")]
        public int? Platform_ID { get; set; }
        public Cateogory? Cateogory { get; set; }
        public Platform? Platform { get; set; }
    }
}
