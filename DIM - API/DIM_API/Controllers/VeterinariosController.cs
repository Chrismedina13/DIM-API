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
    public class VeterinariosController : ControllerBase
    {
        private readonly DIM_APIContext _context;

        public VeterinariosController(DIM_APIContext context)
        {
            _context = context;
        }

        // GET: api/Veterinarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veterinario>>> GetVeterinario()
        {
            return await _context.Veterinario.ToListAsync();
        }

        // GET: api/Veterinarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Veterinario>> GetVeterinario(int id)
        {
            var veterinario = await _context.Veterinario.FindAsync(id);

            if (veterinario == null)
            {
                return NotFound();
            }

            return veterinario;
        }

        // PUT: api/Veterinarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeterinario(int id, Veterinario veterinario)
        {
            if (id != veterinario.VeterinarioID)
            {
                return BadRequest();
            }

            _context.Entry(veterinario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeterinarioExists(id))
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

        // POST: api/Veterinarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Veterinario>> PostVeterinario(Veterinario veterinario)
        {
            _context.Veterinario.Add(veterinario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVeterinario", new { id = veterinario.VeterinarioID }, veterinario);
        }

        // DELETE: api/Veterinarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Veterinario>> DeleteVeterinario(int id)
        {
            var veterinario = await _context.Veterinario.FindAsync(id);
            if (veterinario == null)
            {
                return NotFound();
            }

            _context.Veterinario.Remove(veterinario);
            await _context.SaveChangesAsync();

            return veterinario;
        }

        private bool VeterinarioExists(int id)
        {
            return _context.Veterinario.Any(e => e.VeterinarioID == id);
        }
    }
}
