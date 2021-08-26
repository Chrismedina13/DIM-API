using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DIM_API.Data;
using DIM_API.Models;

namespace DIM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RazasController : ControllerBase
    {
        private readonly DIM_APIContext _context;

        public RazasController(DIM_APIContext context)
        {
            _context = context;
        }

        // GET: api/Razas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Raza>>> GetRaza()
        {
            return await _context.Raza.ToListAsync();
        }

        // GET: api/Razas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Raza>> GetRaza(string id)
        {
            var raza = await _context.Raza.FindAsync(id);

            if (raza == null)
            {
                return NotFound();
            }

            return raza;
        }

        // PUT: api/Razas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRaza(string id, Raza raza)
        {
            if (id != raza.RazaID)
            {
                return BadRequest();
            }

            _context.Entry(raza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RazaExists(id))
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

        // POST: api/Razas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Raza>> PostRaza(Raza raza)
        {
            _context.Raza.Add(raza);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RazaExists(raza.RazaID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRaza", new { id = raza.RazaID }, raza);
        }

        // DELETE: api/Razas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Raza>> DeleteRaza(string id)
        {
            var raza = await _context.Raza.FindAsync(id);
            if (raza == null)
            {
                return NotFound();
            }

            _context.Raza.Remove(raza);
            await _context.SaveChangesAsync();

            return raza;
        }

        private bool RazaExists(string id)
        {
            return _context.Raza.Any(e => e.RazaID == id);
        }
    }
}
