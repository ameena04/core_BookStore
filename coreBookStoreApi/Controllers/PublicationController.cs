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
    public class PublicationController : ControllerBase
    {
        
        
            private readonly BookStoreDbContext _context;

            public PublicationController(BookStoreDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<IActionResult> Get()
            {
                List<Publication> publication =await _context.Publications.ToListAsync();
                 if(publication != null)
                     {
                         return Ok(publication);
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

                    var pub = await _context.Publications.FindAsync(id);
                    if (pub == null)
                    {
                        return NotFound();
                    }
                return Ok(pub);
             }
            catch (Exception)
            {
                return BadRequest();
            }

             }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Publication pub)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
             else

            {
                try
                {
                    _context.Publications.Add(pub);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction(nameof(Get), new { id = pub.PublicationId, pub });
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
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var pub = await _context.Publications.FindAsync(id);
                if (pub == null)
                {
                    return NotFound();
                }
                _context.Publications.Remove(pub);
                await _context.SaveChangesAsync();
                return Ok(pub);
            }

       

        [HttpPut("{id}")]

            public async Task<IActionResult> Put(int? id, [FromBody]Publication newpublication)
            {

            if (id == null)
            {
                return BadRequest();
            }

            if (id != newpublication.PublicationId)
            {
                return NotFound();
            }
            _context.Entry(newpublication).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(newpublication);
        }

        
    }
}







