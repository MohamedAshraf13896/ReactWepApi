using System.Collections.Generic;

namespace WebAbi.DTO
{
    public class CateogoriesWithListProducts
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public List<string> Product_Name { get; set; } = new List<string>();

    }
}
