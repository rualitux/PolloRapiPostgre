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
    public class ComprobantesController : ControllerBase
    {
        private readonly PolloRapiContext _context;

        public ComprobantesController(PolloRapiContext context)
        {
            _context = context;
        }

        // GET: api/Comprobantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comprobante>>> GetComprobantes()
        {
          if (_context.Comprobantes == null)
          {
              return NotFound();
          }
            return await _context.Comprobantes.ToListAsync();
        }

        // GET: api/Comprobantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comprobante>> GetComprobante(int id)
        {
          if (_context.Comprobantes == null)
          {
              return NotFound();
          }
            var comprobante = await _context.Comprobantes.FindAsync(id);

            if (comprobante == null)
            {
                return NotFound();
            }

            return comprobante;
        }

        // PUT: api/Comprobantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComprobante(int id, Comprobante comprobante)
        {
            if (id != comprobante.Id)
            {
                return BadRequest();
            }

            _context.Entry(comprobante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComprobanteExists(id))
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

        // POST: api/Comprobantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comprobante>> PostComprobante(Comprobante comprobante)
        {
          if (_context.Comprobantes == null)
          {
              return Problem("Entity set 'PolloRapiContext.Comprobantes'  is null.");
          }
            _context.Comprobantes.Add(comprobante);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ComprobanteExists(comprobante.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetComprobante", new { id = comprobante.Id }, comprobante);
        }

        // DELETE: api/Comprobantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComprobante(int id)
        {
            if (_context.Comprobantes == null)
            {
                return NotFound();
            }
            var comprobante = await _context.Comprobantes.FindAsync(id);
            if (comprobante == null)
            {
                return NotFound();
            }

            _context.Comprobantes.Remove(comprobante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComprobanteExists(int id)
        {
            return (_context.Comprobantes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
