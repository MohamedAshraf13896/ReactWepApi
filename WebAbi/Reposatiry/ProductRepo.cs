using WebAbi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace WebAbi.Reposatiry
{
    public class ProductRepo : IProductRepo
    {
        GamingStoreDB db;
        public ProductRepo(GamingStoreDB _context)
        {
            db = _context;
        }
        public List<Product> GetAll()
        {
            return db.Products.Include(s => s.Platform).Include(s => s.Cateogory).ToList();
        }
        public Product? GetProductByID(int id)
        {
            return db.Products.Include(d => d.Platform).Include(d => d.Cateogory).SingleOrDefault(e => e.ID == id);
        }
        public int Insert(Product prod)
        {
            db.Products.Add(prod);
            return db.SaveChanges();
        }
        public int Edit(int id, Product prod)
        {
            Product oldProd = GetProductByID(id);
            if (oldProd != null)
            {
                oldProd.Name = prod.Name;
                oldProd.Salary = prod.Salary;
                oldProd.Img = prod.Img;
                return db.SaveChanges();
            }
            return 0;
        }
        public int Delete(int id)
        {
            Product oldProduct = GetProductByID(id);
            if (oldProduct != null)
            {
                db.Remove(oldProduct);
                return db.SaveChanges();
            }
            return 0;
        }
    }
}
