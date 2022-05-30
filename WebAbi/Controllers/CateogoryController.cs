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
    public class CateogoryController : ControllerBase
    {
        ICategoryRepo CategoryRepo;
        public CateogoryController(ICategoryRepo Catrepo)
        {
            CategoryRepo = Catrepo;
        }
        [HttpGet]
        public IActionResult GetAllCateogories()
        {
            List<Cateogory> cateogories = CategoryRepo.GetAll();
            List<CateogoriesWithListProducts> Cat = new List<CateogoriesWithListProducts>();
            foreach (var item in cateogories)
            {
                CateogoriesWithListProducts CatWithproduct = new CateogoriesWithListProducts();
                CatWithproduct.ID = item.ID;
                CatWithproduct.Name = item.Name;
                foreach (var key in item.Products)
                {
                    CatWithproduct.Product_Name.Add(key.Name);
                }
                Cat.Add(CatWithproduct);
            }
            return Ok(Cat);
        }
        [HttpGet]
        [Route("{id:int}", Name = "getCatbyid")]
        public IActionResult GetCatwithProducts(int id)
        {
            Cateogory cateogories = CategoryRepo.GetCateogoryByID(id);
            CateogoriesWithListProducts CatDto = new CateogoriesWithListProducts();
            CatDto.ID = cateogories.ID;
            CatDto.Name = cateogories.Name;
            foreach (var item in cateogories.Products)
            {
                CatDto.Product_Name.Add(item.Name);
            }
            return Ok(CatDto);
        }
        [HttpPost]
        public IActionResult Post(Cateogory cat)
        {

            if (ModelState.IsValid == true)
            {
                CategoryRepo.Insert(cat);
                string url = Url.Link("getCatbyid", new { id = cat.ID });
                return Created(url, cat);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Cateogory cat)
        {
            if (ModelState.IsValid == true)
            {
                var category = CategoryRepo.Edit(id, cat);
                return Ok(category);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                CategoryRepo.Delete(id);

            }
            catch (Exception ex)
            {
                return BadRequest(ModelState);
            }
            return Ok(ModelState);
        }
    }
}
