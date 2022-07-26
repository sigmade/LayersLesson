﻿using BusinessLayer;
using DataLayer.CurrencyServices;
using DataLayer.DataProviders;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductService _service = new ProductService(new InMemoryDataProvider(), new Mig());

        public ProductsController()
        {

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _service.GetAll();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult AddNew(ProductModel product)
        {
            var result = _service.AddNew(product);
            return Ok(result);
        }
    }
}
