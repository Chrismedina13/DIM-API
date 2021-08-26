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
    public class FallecimientosController : ControllerBase
    {
        private readonly DIM_APIContext _context;

        public FallecimientosController(DIM_APIContext context)
        {
            _context = context;
        }

        // GET: api/Fallecimientos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fallecimiento>>> GetFallecimiento()
        {
            return await _context.Fallecimiento.ToListAsync();
        }

        // GET: api/Fallecimientos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fallecimiento>> GetFallecimiento(long id)
        {
            var fallecimiento = await _context.Fallecimiento.FindAsync(id);

            if (fallecimiento == null)
            {
                return NotFound();
            }

            return fallecimiento;
        }

        // PUT: api/Fallecimientos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFallecimiento(long id, Fallecimiento fallecimiento)
        {
            if (id != fallecimiento.MascotaID)
            {
                return BadRequest();
            }

            _context.Entry(fallecimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FallecimientoExists(id))
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

        // POST: api/Fallecimientos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Fallecimiento>> PostFallecimiento(Fallecimiento fallecimiento)
        {
            _context.Fallecimiento.Add(fallecimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFallecimiento", new { id = fallecimiento.MascotaID }, fallecimiento);
        }

        // DELETE: api/Fallecimientos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Fallecimiento>> DeleteFallecimiento(long id)
        {
            var fallecimiento = await _context.Fallecimiento.FindAsync(id);
            if (fallecimiento == null)
            {
                return NotFound();
            }

            _context.Fallecimiento.Remove(fallecimiento);
            await _context.SaveChangesAsync();

            return fallecimiento;
        }

        private bool FallecimientoExists(long id)
        {
            return _context.Fallecimiento.Any(e => e.MascotaID == id);
        }
    }
}
