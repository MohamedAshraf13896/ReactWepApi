using WebAbi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace WebAbi.Reposatiry
{
    public class CategoryRepo : ICategoryRepo
    {
        GamingStoreDB db;
        public CategoryRepo(GamingStoreDB _context)
        {
            db = _context;
        }
        public List<Cateogory> GetAll()
        {
            return db.Cateogories.Include(s => s.Products).ToList();
        }
        public Cateogory? GetCateogoryByID(int id)
        {
            return db.Cateogories.Include(d => d.Products).SingleOrDefault(e => e.ID == id);
        }
        public int Insert(Cateogory Cat)
        {
            db.Cateogories.Add(Cat);
            return db.SaveChanges();
        }
        public int Edit(int id, Cateogory Cat)
        {
            Cateogory? oldCat = GetCateogoryByID(id);
            if (oldCat != null)
            {
                oldCat.Name = Cat.Name;
                return db.SaveChanges();
            }
            return 0;
        }
        public int Delete(int id)
        {
            Cateogory? oldCat = GetCateogoryByID(id);
            if (oldCat != null)
            {
                db.Remove(oldCat);
                return db.SaveChanges();
            }
            return 0;
        }
    }
}
