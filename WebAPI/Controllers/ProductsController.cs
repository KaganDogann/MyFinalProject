using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] //bu isteği yaparken bu insanlar bize nasıl ulaşsın
    [ApiController] //ATTRIBUTE bir class la ilgili bilgi verme onu imzalama yöntemidir
    public class ProductsController : ControllerBase
    {   
        // Loosely coupled
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")] // bunu kendimiz yazdık.
        public IActionResult GetAll()
        {
           
            var result= _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result); //400
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result); //400
        }

        [HttpGet("getbycategory")]
        public IActionResult GetByCategory(int categoryId)
        {
            var result = _productService.GetAllByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result); //400
        }

        [HttpPost("add")]

        public IActionResult Add(Product product) //istedğin nesneyi buraya parametre oalrka yazarım. bana verdiğin clientten ürünü buraya koy
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
