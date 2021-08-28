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
    public class VacunacionesController : ControllerBase
    {
        private readonly DIM_APIContext _context;

        public VacunacionesController(DIM_APIContext context)
        {
            _context = context;
        }

        // GET: api/Vacunaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vacunacion>>> GetVacunacion()
        {
            return await _context.Vacunacion.ToListAsync();
        }

        // GET: api/Vacunaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vacunacion>> GetVacunacion(long id)
        {
            var vacunacion = await _context.Vacunacion.FindAsync(id);

            if (vacunacion == null)
            {
                return NotFound();
            }

            return vacunacion;
        }

        // PUT: api/Vacunaciones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacunacion(long id, Vacunacion vacunacion)
        {
            if (id != vacunacion.MascotaID)
            {
                return BadRequest();
            }

            _context.Entry(vacunacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacunacionExists(id))
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

        // POST: api/Vacunaciones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Vacunacion>> PostVacunacion(Vacunacion vacunacion)
        {
            _context.Vacunacion.Add(vacunacion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VacunacionExists(vacunacion.MascotaID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVacunacion", new { id = vacunacion.MascotaID }, vacunacion);
        }

        // DELETE: api/Vacunaciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vacunacion>> DeleteVacunacion(long id)
        {
            var vacunacion = await _context.Vacunacion.FindAsync(id);
            if (vacunacion == null)
            {
                return NotFound();
            }

            _context.Vacunacion.Remove(vacunacion);
            await _context.SaveChangesAsync();

            return vacunacion;
        }

        private bool VacunacionExists(long id)
        {
            return _context.Vacunacion.Any(e => e.MascotaID == id);
        }
    }
}
