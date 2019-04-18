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
    public class OrderController : ControllerBase
    {
        private readonly BookStoreDbContext context;

        public OrderController(BookStoreDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            return await context.Orders.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            var ord = await context.Orders.FindAsync(id);
            if (ord == null)
            {
                return NotFound();
            }
            return ord;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] Order ord)
        {
            context.Orders.Add(ord);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = ord.OrderId, ord });
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<Order>> Delete(int id)
        {
            var ord = await context.Orders.FindAsync(id);
            if (ord == null)
            {
                return NotFound();
            }
            context.Orders.Remove(ord);
            await context.SaveChangesAsync();
            return NoContent();
        }



        [HttpPut("{id}")]

        public async Task<ActionResult<Order>> Put(int id, [FromBody]Order newOrder)
        {

            if (id != newOrder.OrderId)
            {
                return BadRequest();
            }
            context.Entry(newOrder).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
