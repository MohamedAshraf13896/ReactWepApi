using System.Collections.Generic;
using WebAbi.Models;

namespace WebAbi.Reposatiry
{
    public interface IPlatformRepo
    {
        int Delete(int id);
        int Edit(int id, Platform plat);
        List<Platform> GetAll();
        Platform GetPlatformByID(int id);
        int Insert(Platform plat);
    }
}