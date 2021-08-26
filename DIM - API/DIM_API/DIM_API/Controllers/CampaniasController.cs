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
    public class CampaniasController : ControllerBase
    {
        private readonly DIM_APIContext _context;

        public CampaniasController(DIM_APIContext context)
        {
            _context = context;
        }

        // GET: api/Campanias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campania>>> GetCampania()
        {
            return await _context.Campania.ToListAsync();
        }

        // GET: api/Campanias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Campania>> GetCampania(long id)
        {
            var campania = await _context.Campania.FindAsync(id);

            if (campania == null)
            {
                return NotFound();
            }

            return campania;
        }

        // PUT: api/Campanias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampania(long id, Campania campania)
        {
            if (id != campania.CampaniaID)
            {
                return BadRequest();
            }

            _context.Entry(campania).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampaniaExists(id))
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

        // POST: api/Campanias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Campania>> PostCampania(Campania campania)
        {
            _context.Campania.Add(campania);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCampania", new { id = campania.CampaniaID }, campania);
        }

        // DELETE: api/Campanias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Campania>> DeleteCampania(long id)
        {
            var campania = await _context.Campania.FindAsync(id);
            if (campania == null)
            {
                return NotFound();
            }

            _context.Campania.Remove(campania);
            await _context.SaveChangesAsync();

            return campania;
        }

        private bool CampaniaExists(long id)
        {
            return _context.Campania.Any(e => e.CampaniaID == id);
        }
    }
}
