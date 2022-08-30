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
    public class EnumeradosController : ControllerBase
    {
        private readonly PolloRapiContext _context;

        public EnumeradosController(PolloRapiContext context)
        {
            _context = context;
        }

        // GET: api/Enumerados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enumerado>>> GetEnumerado()
        {
          if (_context.Enumerado == null)
          {
              return NotFound();
          }
            return await _context.Enumerado.ToListAsync();
        }

        // GET: api/Enumerados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Enumerado>> GetEnumerado(int id)
        {
          if (_context.Enumerado == null)
          {
              return NotFound();
          }
            var enumerado = await _context.Enumerado.FindAsync(id);

            if (enumerado == null)
            {
                return NotFound();
            }

            return enumerado;
        }

        // PUT: api/Enumerados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnumerado(int id, Enumerado enumerado)
        {
            if (id != enumerado.Id)
            {
                return BadRequest();
            }

            _context.Entry(enumerado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnumeradoExists(id))
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

        // POST: api/Enumerados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Enumerado>> PostEnumerado(Enumerado enumerado)
        {
          if (_context.Enumerado == null)
          {
              return Problem("Entity set 'PolloRapiContext.Enumerado'  is null.");
          }
            _context.Enumerado.Add(enumerado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnumerado", new { id = enumerado.Id }, enumerado);
        }

        // DELETE: api/Enumerados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnumerado(int id)
        {
            if (_context.Enumerado == null)
            {
                return NotFound();
            }
            var enumerado = await _context.Enumerado.FindAsync(id);
            if (enumerado == null)
            {
                return NotFound();
            }

            _context.Enumerado.Remove(enumerado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnumeradoExists(int id)
        {
            return (_context.Enumerado?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
