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
    public class EspeciesController : ControllerBase
    {
        private readonly DIM_APIContext _context;

        public EspeciesController(DIM_APIContext context)
        {
            _context = context;
        }

        // GET: api/Especies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Especie>>> GetEspecie()
        {
            return await _context.Especie.ToListAsync();
        }

        // GET: api/Especies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Especie>> GetEspecie(string id)
        {
            var especie = await _context.Especie.FindAsync(id);

            if (especie == null)
            {
                return NotFound();
            }

            return especie;
        }

        // PUT: api/Especies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspecie(string id, Especie especie)
        {
            if (id != especie.EspecieID)
            {
                return BadRequest();
            }

            _context.Entry(especie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecieExists(id))
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

        // POST: api/Especies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Especie>> PostEspecie(Especie especie)
        {
            _context.Especie.Add(especie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EspecieExists(especie.EspecieID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEspecie", new { id = especie.EspecieID }, especie);
        }

        // DELETE: api/Especies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Especie>> DeleteEspecie(string id)
        {
            var especie = await _context.Especie.FindAsync(id);
            if (especie == null)
            {
                return NotFound();
            }

            _context.Especie.Remove(especie);
            await _context.SaveChangesAsync();

            return especie;
        }

        private bool EspecieExists(string id)
        {
            return _context.Especie.Any(e => e.EspecieID == id);
        }
    }
}
