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
    public class MedicamentosController : ControllerBase
    {
        private readonly DIM_APIContext _context;

        public MedicamentosController(DIM_APIContext context)
        {
            _context = context;
        }

        // GET: api/Medicamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicamento>>> GetMedicamento()
        {
            return await _context.Medicamento.ToListAsync();
        }

        // GET: api/Medicamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medicamento>> GetMedicamento(string id)
        {
            var medicamento = await _context.Medicamento.FindAsync(id);

            if (medicamento == null)
            {
                return NotFound();
            }

            return medicamento;
        }

        // PUT: api/Medicamentos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicamento(string id, Medicamento medicamento)
        {
            if (id != medicamento.MedicamentoID)
            {
                return BadRequest();
            }

            _context.Entry(medicamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicamentoExists(id))
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

        // POST: api/Medicamentos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Medicamento>> PostMedicamento(Medicamento medicamento)
        {
            _context.Medicamento.Add(medicamento);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MedicamentoExists(medicamento.MedicamentoID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMedicamento", new { id = medicamento.MedicamentoID }, medicamento);
        }

        // DELETE: api/Medicamentos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Medicamento>> DeleteMedicamento(string id)
        {
            var medicamento = await _context.Medicamento.FindAsync(id);
            if (medicamento == null)
            {
                return NotFound();
            }

            _context.Medicamento.Remove(medicamento);
            await _context.SaveChangesAsync();

            return medicamento;
        }

        private bool MedicamentoExists(string id)
        {
            return _context.Medicamento.Any(e => e.MedicamentoID == id);
        }
    }
}
