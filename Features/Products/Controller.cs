using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Data;
using ASP.Data.Entities;
using ASP.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;

namespace ASP.Features.Products
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly Context _db;


        public ProductsController(Context db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Find()
        {
            var products = await _db.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> Get(string slug)
        {
            var product = await _db.Products.SingleOrDefaultAsync(x =>  
            x.Slug == slug);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}