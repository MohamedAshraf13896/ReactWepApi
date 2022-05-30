using System.Collections.Generic;
using WebAbi.Models;

namespace WebAbi.DTO
{
    public class PlatFormsWithProductList
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public List<string> Product_Name { get; set; } = new List<string>();

    }
}
