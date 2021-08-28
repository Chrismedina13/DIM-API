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
    public class MedicamentosMascotasController : ControllerBase
    {
        private readonly DIM_APIContext _context;

        public MedicamentosMascotasController(DIM_APIContext context)
        {
            _context = context;
        }

        // GET: api/MedicamentosMascotas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicamentosMascotas>>> GetMedicamentosMascotas()
        {
            return await _context.MedicamentosMascotas.ToListAsync();
        }

        // GET: api/MedicamentosMascotas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicamentosMascotas>> GetMedicamentosMascotas(long id)
        {
            var medicamentosMascotas = await _context.MedicamentosMascotas.FindAsync(id);

            if (medicamentosMascotas == null)
            {
                return NotFound();
            }

            return medicamentosMascotas;
        }

        // PUT: api/MedicamentosMascotas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicamentosMascotas(long id, MedicamentosMascotas medicamentosMascotas)
        {
            if (id != medicamentosMascotas.MascotaID)
            {
                return BadRequest();
            }

            _context.Entry(medicamentosMascotas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicamentosMascotasExists(id))
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

        // POST: api/MedicamentosMascotas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MedicamentosMascotas>> PostMedicamentosMascotas(MedicamentosMascotas medicamentosMascotas)
        {
            _context.MedicamentosMascotas.Add(medicamentosMascotas);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MedicamentosMascotasExists(medicamentosMascotas.MascotaID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMedicamentosMascotas", new { id = medicamentosMascotas.MascotaID }, medicamentosMascotas);
        }

        // DELETE: api/MedicamentosMascotas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MedicamentosMascotas>> DeleteMedicamentosMascotas(long id)
        {
            var medicamentosMascotas = await _context.MedicamentosMascotas.FindAsync(id);
            if (medicamentosMascotas == null)
            {
                return NotFound();
            }

            _context.MedicamentosMascotas.Remove(medicamentosMascotas);
            await _context.SaveChangesAsync();

            return medicamentosMascotas;
        }

        private bool MedicamentosMascotasExists(long id)
        {
            return _context.MedicamentosMascotas.Any(e => e.MascotaID == id);
        }
    }
}
