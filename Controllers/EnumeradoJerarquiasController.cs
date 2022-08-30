using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PolloRapiApi.Data;
using PolloRapiApi.Models;

namespace PolloRapiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumeradoJerarquiasController : ControllerBase
    {
        private readonly PolloRapiContext _context;

        public EnumeradoJerarquiasController(PolloRapiContext context)
        {
            _context = context;
        }

        // GET: api/EnumeradoJerarquias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnumeradoJerarquia>>> GetEnumeradoJerarquias()
        {
          if (_context.EnumeradoJerarquias == null)
          {
              return NotFound();
          }
            return await _context.EnumeradoJerarquias.ToListAsync();
        }

        // GET: api/EnumeradoJerarquias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnumeradoJerarquia>> GetEnumeradoJerarquia(int? id)
        {
          if (_context.EnumeradoJerarquias == null)
          {
              return NotFound();
          }
            var enumeradoJerarquia = await _context.EnumeradoJerarquias.FindAsync(id);

            if (enumeradoJerarquia == null)
            {
                return NotFound();
            }

            return enumeradoJerarquia;
        }

        // PUT: api/EnumeradoJerarquias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnumeradoJerarquia(int? id, EnumeradoJerarquia enumeradoJerarquia)
        {
            if (id != enumeradoJerarquia.AncestroId)
            {
                return BadRequest();
            }

            _context.Entry(enumeradoJerarquia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnumeradoJerarquiaExists(id))
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

        // POST: api/EnumeradoJerarquias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EnumeradoJerarquia>> PostEnumeradoJerarquia(EnumeradoJerarquia enumeradoJerarquia)
        {
          if (_context.EnumeradoJerarquias == null)
          {
              return Problem("Entity set 'PolloRapiContext.EnumeradoJerarquias'  is null.");
          }
            _context.EnumeradoJerarquias.Add(enumeradoJerarquia);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EnumeradoJerarquiaExists(enumeradoJerarquia.AncestroId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEnumeradoJerarquia", new { id = enumeradoJerarquia.AncestroId }, enumeradoJerarquia);
        }

        // DELETE: api/EnumeradoJerarquias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnumeradoJerarquia(int? id)
        {
            if (_context.EnumeradoJerarquias == null)
            {
                return NotFound();
            }
            var enumeradoJerarquia = await _context.EnumeradoJerarquias.FindAsync(id);
            if (enumeradoJerarquia == null)
            {
                return NotFound();
            }

            _context.EnumeradoJerarquias.Remove(enumeradoJerarquia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnumeradoJerarquiaExists(int? id)
        {
            return (_context.EnumeradoJerarquias?.Any(e => e.AncestroId == id)).GetValueOrDefault();
        }
    }
}
