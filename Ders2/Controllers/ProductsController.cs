using Ders2.Data;
using Ders2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ders2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var products = _context.CategoryProducts
                .AsNoTracking()
                .Include(cp => cp.Product)
                .Include(cp => cp.Category)
                .Where(cp => cp.CategoryId == 3)
                .ToList();

            if (products.Count <= 0 || products == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(products);
            }
        }

        [HttpGet("detailed/{id}")]
        public IActionResult GetDetailed(int id)
        {
            var product = _context.Products
                // .Include(p => p.Category)
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost("new")]
        public IActionResult AddProduct(CategoryProduct newPair)
        {
            _context.CategoryProducts.Add(newPair);

            int dbRes = _context.SaveChanges();

            if (dbRes > 0)
            {
                return Ok(newPair);
            }
            else
            {
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpPost("delete")]
        public IActionResult DeleteProduct(int id)
        {
            var selectedProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (selectedProduct == null)
            {
                return NotFound(id);
            }

            _context.Products.Remove(selectedProduct);

            var dbRes = _context.SaveChanges();
            if (dbRes > 0)
            {
                return Ok($"deleted: {id}");
            }
            else
            {
                return StatusCode(500);
            }
        }

        [HttpPost("update")]
        public IActionResult UpdateProduct(Product updatedProduct)
        {
            var selectedProduct = _context.Products.FirstOrDefault(p => p.Id == updatedProduct.Id);
            if (selectedProduct == null)
            {
                return NotFound(updatedProduct.Id);
            }

            selectedProduct.Name = updatedProduct.Name;
            selectedProduct.Price = updatedProduct.Price;

            var dbRes = _context.SaveChanges();
            if (dbRes > 0)
            {
                return Ok($"update: {updatedProduct.Id}");
            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}
