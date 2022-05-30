using System.Collections.Generic;
using WebAbi.Models;

namespace WebAbi.Reposatiry
{
    public interface IProductRepo
    {
        int Delete(int id);
        int Edit(int id, Product prod);
        List<Product> GetAll();
        Product GetProductByID(int id);
        int Insert(Product prod);
    }
}