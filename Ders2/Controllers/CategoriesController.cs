using System;
using System.Linq;
using Ders2.Data;
using Ders2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ders2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var categories = _context.Categories
                .AsNoTracking()
                // .Include(c => c.Products)
                .ToList();

            if (categories == null || categories.Count == 0)
            {
                return NotFound();
            }

            return Ok(categories);
        }

        [HttpPost("new")]
        public IActionResult AddCategory(Category newCat)
        {
            _context.Categories.Add(newCat);
            int dbRes = _context.SaveChanges();

            if (dbRes > 0)
            {
                return Ok(newCat);
            }
            else
            {
                return StatusCode(500, "Something went wrong!");
            }
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var oldCat = _context.Categories.FirstOrDefault(c => c.Id == id);

            if (oldCat != null)
            {
                _context.Categories.Remove(oldCat);
            }
            else 
            {
                return StatusCode(500);
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}