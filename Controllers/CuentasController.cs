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
    public class CuentasController : ControllerBase
    {
        private readonly PolloRapiContext _context;

        public CuentasController(PolloRapiContext context)
        {
            _context = context;
        }

        // GET: api/Cuentas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuentas>>> GetCuentas()
        {
          if (_context.Cuentas == null)
          {
              return NotFound();
          }
            return await _context.Cuentas.ToListAsync();
        }

        // GET: api/Cuentas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cuentas>> GetCuentas(int id)
        {
          if (_context.Cuentas == null)
          {
              return NotFound();
          }
            var cuentas = await _context.Cuentas.FindAsync(id);

            if (cuentas == null)
            {
                return NotFound();
            }

            return cuentas;
        }

        // PUT: api/Cuentas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuentas(int id, Cuentas cuentas)
        {
            if (id != cuentas.Id)
            {
                return BadRequest();
            }

            _context.Entry(cuentas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuentasExists(id))
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

        // POST: api/Cuentas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cuentas>> PostCuentas(Cuentas cuentas)
        {
          if (_context.Cuentas == null)
          {
              return Problem("Entity set 'PolloRapiContext.Cuentas'  is null.");
          }
            _context.Cuentas.Add(cuentas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCuentas", new { id = cuentas.Id }, cuentas);
        }

        // DELETE: api/Cuentas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuentas(int id)
        {
            if (_context.Cuentas == null)
            {
                return NotFound();
            }
            var cuentas = await _context.Cuentas.FindAsync(id);
            if (cuentas == null)
            {
                return NotFound();
            }

            _context.Cuentas.Remove(cuentas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CuentasExists(int id)
        {
            return (_context.Cuentas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
