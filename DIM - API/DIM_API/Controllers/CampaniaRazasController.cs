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
    public class CampaniaRazasController : ControllerBase
    {
        private readonly DIM_APIContext _context;

        public CampaniaRazasController(DIM_APIContext context)
        {
            _context = context;
        }

        // GET: api/CampaniaRazas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CampaniaRaza>>> GetCampaniaRaza()
        {
            return await _context.CampaniaRaza.ToListAsync();
        }

        // GET: api/CampaniaRazas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CampaniaRaza>> GetCampaniaRaza(long id)
        {
            var campaniaRaza = await _context.CampaniaRaza.FindAsync(id);

            if (campaniaRaza == null)
            {
                return NotFound();
            }

            return campaniaRaza;
        }

        // PUT: api/CampaniaRazas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampaniaRaza(long id, CampaniaRaza campaniaRaza)
        {
            if (id != campaniaRaza.CampaniaID)
            {
                return BadRequest();
            }

            _context.Entry(campaniaRaza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampaniaRazaExists(id))
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

        // POST: api/CampaniaRazas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CampaniaRaza>> PostCampaniaRaza(CampaniaRaza campaniaRaza)
        {
            _context.CampaniaRaza.Add(campaniaRaza);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CampaniaRazaExists(campaniaRaza.CampaniaID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCampaniaRaza", new { id = campaniaRaza.CampaniaID }, campaniaRaza);
        }

        // DELETE: api/CampaniaRazas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CampaniaRaza>> DeleteCampaniaRaza(long id)
        {
            var campaniaRaza = await _context.CampaniaRaza.FindAsync(id);
            if (campaniaRaza == null)
            {
                return NotFound();
            }

            _context.CampaniaRaza.Remove(campaniaRaza);
            await _context.SaveChangesAsync();

            return campaniaRaza;
        }

        private bool CampaniaRazaExists(long id)
        {
            return _context.CampaniaRaza.Any(e => e.CampaniaID == id);
        }
    }
}
