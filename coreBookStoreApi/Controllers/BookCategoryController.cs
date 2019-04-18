using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using coreBookStoreApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace coreBookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [EnableCors("AllowMyOrigin")]
    
    public class BookCategoryController : ControllerBase
    {
       
            private readonly BookStoreDbContext _context;

            public BookCategoryController(BookStoreDbContext context)
            {
                _context = context;
            }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<BookCategory> bookCategories = await _context.BookCategories.ToListAsync();
            if (bookCategories != null)
            {
                return Ok(bookCategories);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            try
            {

                var bookCategories = await _context.BookCategories.FindAsync(id);
                if (bookCategories == null)
                {
                    return NotFound();
                }
                return Ok(bookCategories);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookCategory bookCategories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    _context.BookCategories.Add(bookCategories);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction(nameof(Get), new { id = bookCategories.BookCategoryId, bookCategories });
                }

                catch (Exception)
                {
                    return BadRequest();
                }
            }


        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bookCategory = await _context.BookCategories.FindAsync(id);
            if (bookCategory == null)
            {
                return NotFound();
            }
            _context.BookCategories.Remove(bookCategory);
            await _context.SaveChangesAsync();
            return Ok(bookCategory);
        }



        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int? id, [FromBody]BookCategory newbookCategory)
        {

            if (id == null)
            {
                return BadRequest();
            }

            if (id != newbookCategory.BookCategoryId)
            {
                return NotFound();
            }
            _context.Entry(newbookCategory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(newbookCategory);
        }


    }
}







