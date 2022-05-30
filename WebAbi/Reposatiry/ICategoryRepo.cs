using System.Collections.Generic;
using WebAbi.Models;

namespace WebAbi.Reposatiry
{
    public interface ICategoryRepo
    {
        int Delete(int id);
        int Edit(int id, Cateogory Cat);
        List<Cateogory> GetAll();
        Cateogory GetCateogoryByID(int id);
        int Insert(Cateogory Cat);
    }
}