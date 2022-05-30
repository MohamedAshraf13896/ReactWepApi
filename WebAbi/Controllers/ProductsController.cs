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
    public class ProductsController : ControllerBase
    {
        IProductRepo ProductReposatry;
        public ProductsController(IProductRepo prodRepo)
        {
            ProductReposatry = prodRepo;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            List<Product> Products = ProductReposatry.GetAll();
            List<ProductWithCatNameANdPlatName> prod = new List<ProductWithCatNameANdPlatName>();
            foreach (var item in Products)
            {
                ProductWithCatNameANdPlatName ProductwithCat = new ProductWithCatNameANdPlatName();
                ProductwithCat.ID = item.ID;
                ProductwithCat.Name = item.Name;
                ProductwithCat.Salary = item.Salary;
                ProductwithCat.Img = item.Img;
                ProductwithCat.Cateogory_Name = item.Cateogory.Name;
                ProductwithCat.Platform_Name = item.Platform.Name;
                prod.Add(ProductwithCat);
            }
            return Ok(prod);
        }
        [HttpGet]
        [Route("{id:int}", Name = "getbyid")]
        public IActionResult GetProductByID(int id)
        {

            Product products = ProductReposatry.GetProductByID(id);
            if (products != null)
            {
                ProductWithCatNameANdPlatName ProdDto = new ProductWithCatNameANdPlatName();
                ProdDto.Name = products.Name;
                ProdDto.Salary = products.Salary;
                ProdDto.Img = products.Img;
                ProdDto.Salary = products.Salary;
                ProdDto.Cateogory_Name = products.Cateogory.Name;
                ProdDto.Platform_Name = products.Platform.Name;
                return Ok(ProdDto);
            }
            else
            {
                return BadRequest("There is No ID");
            }
        }
        [HttpPost]
        public IActionResult Post(Product pro)
        {

            if (ModelState.IsValid == true)
            {
                var id = ProductReposatry.Insert(pro);
                string url = Url.Link("getbyid", new { id = pro.ID });
                return Created(url, pro);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Product pro)
        {
            if (ModelState.IsValid == true)
            {
                var Prod = ProductReposatry.Edit(id, pro);
                return Ok(Prod);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ProductReposatry.Delete(id);

            }
            catch (Exception ex)
            {
                return BadRequest(ModelState);
            }
            return Ok(ModelState);
        }
    }
}
