using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAbi.Models;
using WebAbi.Reposatiry;
using WebAbi.DTO;
using System.Collections.Generic;
using System;


namespace WebAbi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        IPlatformRepo platRepo;
        public PlatformController(IPlatformRepo platrep)
        {
            platRepo = platrep;
        }
        [HttpGet]
        public IActionResult GetAllPlatforms()
        {
            List<Platform> platforms = platRepo.GetAll();
            List<PlatFormsWithProductList> Plat = new List<PlatFormsWithProductList>();
            foreach (var item in platforms)
            {
                PlatFormsWithProductList PlatwithProducts = new PlatFormsWithProductList();
                PlatwithProducts.ID = item.ID;
                PlatwithProducts.Name = item.Name;
                foreach (var key in item.Products)
                {
                    PlatwithProducts.Product_Name.Add(key.Name);
                }
                Plat.Add(PlatwithProducts);
            }
            return Ok(Plat);
        }
        [HttpGet]
        [Route("{id:int}", Name = "getPlatbyid")]
        public IActionResult GetPlatwithProducts(int id)
        {
            Platform platforms = platRepo.GetPlatformByID(id);
            PlatFormsWithProductList PlatDto = new PlatFormsWithProductList();
            PlatDto.ID = platforms.ID;
            PlatDto.Name = platforms.Name;
            foreach (var item in platforms.Products)
            {
                PlatDto.Product_Name.Add(item.Name);
            }
            return Ok(PlatDto);
        }
        [HttpPost]
        public IActionResult Post(Platform plat)
        {

            if (ModelState.IsValid == true)
            {
                var id = platRepo.Insert(plat);
                string url = Url.Link("getPlatbyid", new { id = plat.ID });
                return Created(url, plat);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Platform plat)
        {
            if (ModelState.IsValid == true)
            {
                var platform = platRepo.Edit(id, plat);
                return Ok(platform);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                platRepo.Delete(id);

            }
            catch (Exception ex)
            {
                return BadRequest(ModelState);
            }
            return Ok(ModelState);
        }
    }
}
