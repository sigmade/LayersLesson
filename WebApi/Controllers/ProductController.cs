﻿using BusinessLayer;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var productService = new ProductService();
            var products = productService.GetAll();
            return Ok(products);
        }
    }
}
