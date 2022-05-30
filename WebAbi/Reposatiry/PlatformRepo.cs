using WebAbi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace WebAbi.Reposatiry
{
    public class PlatformRepo : IPlatformRepo
    {
        GamingStoreDB db;
        public PlatformRepo(GamingStoreDB _context)
        {
            db = _context;
        }
        public List<Platform> GetAll()
        {
            return db.Platforms.Include(s => s.Products).ToList();
        }
        public Platform? GetPlatformByID(int id)
        {
            return db.Platforms.Include(d => d.Products).SingleOrDefault(e => e.ID == id);
        }
        public int Insert(Platform plat)
        {
            db.Platforms.Add(plat);
            return db.SaveChanges();
        }
        public int Edit(int id, Platform plat)
        {
            Platform? oldPlat = GetPlatformByID(id);
            if (oldPlat != null)
            {
                oldPlat.Name = plat.Name;
                return db.SaveChanges();
            }
            return 0;
        }
        public int Delete(int id)
        {
            Platform? oldPlat = GetPlatformByID(id);
            if (oldPlat != null)
            {
                db.Remove(oldPlat);
                return db.SaveChanges();
            }
            return 0;
        }
    }
}
