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
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
             private readonly BookStoreDbContext _context;

            public BookController(BookStoreDbContext context)
            {
                _context = context;
            }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Book> book = await _context.Books.ToListAsync();
            if (book != null)
            {
                return Ok(book);
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

                var book = await _context.Books.FindAsync(id);
                if (book == null)
                {
                    return NotFound();
                }
                return Ok(book);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else

            {
                try
                {
                    _context.Books.Add(book);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction(nameof(Get), new { id = book.BookId, book });
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
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return Ok(book);
        }



        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int? id, [FromBody]Book newBook)
        {

            if (id == null)
            {
                return BadRequest();
            }

            if (id != newBook.BookId)
            {
                return NotFound();
            }
            _context.Entry(newBook).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(newBook);
        }


    }
}






