using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class msController : ControllerBase
    {
        private readonly TodoContext _context;

        public msController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/ms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ms>>> Getms()
        {
            return await _context.ms.ToListAsync();
        }

        // GET: api/ms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ms>> Getms(long id)
        {
            var ms = await _context.ms.FindAsync(id);

            if (ms == null)
            {
                return NotFound();
            }

            return ms;
        }

        // PUT: api/ms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putms(long id, ms ms)
        {
            if (id != ms.id)
            {
                return BadRequest();
            }

            _context.Entry(ms).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!msExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ms>> Postms(ms ms)
        {
            _context.ms.Add(ms);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getms", new { id = ms.id }, ms);
        }

        // DELETE: api/ms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ms>> Deletems(long id)
        {
            var ms = await _context.ms.FindAsync(id);
            if (ms == null)
            {
                return NotFound();
            }

            _context.ms.Remove(ms);
            await _context.SaveChangesAsync();

            return ms;
        }

        private bool msExists(long id)
        {
            return _context.ms.Any(e => e.id == id);
        }
    }
}
