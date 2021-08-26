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
    public class CampaniaMascotasController : ControllerBase
    {
        private readonly DIM_APIContext _context;

        public CampaniaMascotasController(DIM_APIContext context)
        {
            _context = context;
        }

        // GET: api/CampaniaMascotas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CampaniaMascota>>> GetCampaniaMascota()
        {
            return await _context.CampaniaMascota.ToListAsync();
        }

        // GET: api/CampaniaMascotas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CampaniaMascota>> GetCampaniaMascota(long id)
        {
            var campaniaMascota = await _context.CampaniaMascota.FindAsync(id);

            if (campaniaMascota == null)
            {
                return NotFound();
            }

            return campaniaMascota;
        }

        // PUT: api/CampaniaMascotas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampaniaMascota(long id, CampaniaMascota campaniaMascota)
        {
            if (id != campaniaMascota.MascotaID)
            {
                return BadRequest();
            }

            _context.Entry(campaniaMascota).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampaniaMascotaExists(id))
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

        // POST: api/CampaniaMascotas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CampaniaMascota>> PostCampaniaMascota(CampaniaMascota campaniaMascota)
        {
            _context.CampaniaMascota.Add(campaniaMascota);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CampaniaMascotaExists(campaniaMascota.MascotaID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCampaniaMascota", new { id = campaniaMascota.MascotaID }, campaniaMascota);
        }

        // DELETE: api/CampaniaMascotas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CampaniaMascota>> DeleteCampaniaMascota(long id)
        {
            var campaniaMascota = await _context.CampaniaMascota.FindAsync(id);
            if (campaniaMascota == null)
            {
                return NotFound();
            }

            _context.CampaniaMascota.Remove(campaniaMascota);
            await _context.SaveChangesAsync();

            return campaniaMascota;
        }

        private bool CampaniaMascotaExists(long id)
        {
            return _context.CampaniaMascota.Any(e => e.MascotaID == id);
        }
    }
}
