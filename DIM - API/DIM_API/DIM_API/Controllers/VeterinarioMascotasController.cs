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
    public class VeterinarioMascotasController : ControllerBase
    {
        private readonly DIM_APIContext _context;

        public VeterinarioMascotasController(DIM_APIContext context)
        {
            _context = context;
        }

        // GET: api/VeterinarioMascotas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeterinarioMascota>>> GetVeterinarioMascota()
        {
            return await _context.VeterinarioMascota.ToListAsync();
        }

        // GET: api/VeterinarioMascotas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VeterinarioMascota>> GetVeterinarioMascota(long id)
        {
            var veterinarioMascota = await _context.VeterinarioMascota.FindAsync(id);

            if (veterinarioMascota == null)
            {
                return NotFound();
            }

            return veterinarioMascota;
        }

        // PUT: api/VeterinarioMascotas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeterinarioMascota(long id, VeterinarioMascota veterinarioMascota)
        {
            if (id != veterinarioMascota.MascotaID)
            {
                return BadRequest();
            }

            _context.Entry(veterinarioMascota).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeterinarioMascotaExists(id))
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

        // POST: api/VeterinarioMascotas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VeterinarioMascota>> PostVeterinarioMascota(VeterinarioMascota veterinarioMascota)
        {
            _context.VeterinarioMascota.Add(veterinarioMascota);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VeterinarioMascotaExists(veterinarioMascota.MascotaID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVeterinarioMascota", new { id = veterinarioMascota.MascotaID }, veterinarioMascota);
        }

        // DELETE: api/VeterinarioMascotas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VeterinarioMascota>> DeleteVeterinarioMascota(long id)
        {
            var veterinarioMascota = await _context.VeterinarioMascota.FindAsync(id);
            if (veterinarioMascota == null)
            {
                return NotFound();
            }

            _context.VeterinarioMascota.Remove(veterinarioMascota);
            await _context.SaveChangesAsync();

            return veterinarioMascota;
        }

        private bool VeterinarioMascotaExists(long id)
        {
            return _context.VeterinarioMascota.Any(e => e.MascotaID == id);
        }
    }
}
