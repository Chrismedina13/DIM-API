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
    public class TipoVisitasController : ControllerBase
    {
        private readonly DIM_APIContext _context;

        public TipoVisitasController(DIM_APIContext context)
        {
            _context = context;
        }

        // GET: api/TipoVisitas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoVisita>>> GetTipoVisita()
        {
            return await _context.TipoVisita.ToListAsync();
        }

        // GET: api/TipoVisitas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoVisita>> GetTipoVisita(string id)
        {
            var tipoVisita = await _context.TipoVisita.FindAsync(id);

            if (tipoVisita == null)
            {
                return NotFound();
            }

            return tipoVisita;
        }

        // PUT: api/TipoVisitas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoVisita(string id, TipoVisita tipoVisita)
        {
            if (id != tipoVisita.TipoID)
            {
                return BadRequest();
            }

            _context.Entry(tipoVisita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoVisitaExists(id))
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

        // POST: api/TipoVisitas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoVisita>> PostTipoVisita(TipoVisita tipoVisita)
        {
            _context.TipoVisita.Add(tipoVisita);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipoVisitaExists(tipoVisita.TipoID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTipoVisita", new { id = tipoVisita.TipoID }, tipoVisita);
        }

        // DELETE: api/TipoVisitas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoVisita>> DeleteTipoVisita(string id)
        {
            var tipoVisita = await _context.TipoVisita.FindAsync(id);
            if (tipoVisita == null)
            {
                return NotFound();
            }

            _context.TipoVisita.Remove(tipoVisita);
            await _context.SaveChangesAsync();

            return tipoVisita;
        }

        private bool TipoVisitaExists(string id)
        {
            return _context.TipoVisita.Any(e => e.TipoID == id);
        }
    }
}
