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
    public class PromocionesController : ControllerBase
    {
        private readonly PolloRapiContext _context;

        public PromocionesController(PolloRapiContext context)
        {
            _context = context;
        }

        // GET: api/Promociones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Promocion>>> GetPromociones()
        {
          if (_context.Promociones == null)
          {
              return NotFound();
          }
            return await _context.Promociones.ToListAsync();
        }

        // GET: api/Promociones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Promocion>> GetPromocion(int id)
        {
          if (_context.Promociones == null)
          {
              return NotFound();
          }
            var promocion = await _context.Promociones.FindAsync(id);

            if (promocion == null)
            {
                return NotFound();
            }

            return promocion;
        }

        // PUT: api/Promociones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPromocion(int id, Promocion promocion)
        {
            if (id != promocion.Id)
            {
                return BadRequest();
            }

            _context.Entry(promocion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromocionExists(id))
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

        // POST: api/Promociones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Promocion>> PostPromocion(Promocion promocion)
        {
          if (_context.Promociones == null)
          {
              return Problem("Entity set 'PolloRapiContext.Promociones'  is null.");
          }
            _context.Promociones.Add(promocion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPromocion", new { id = promocion.Id }, promocion);
        }

        // DELETE: api/Promociones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromocion(int id)
        {
            if (_context.Promociones == null)
            {
                return NotFound();
            }
            var promocion = await _context.Promociones.FindAsync(id);
            if (promocion == null)
            {
                return NotFound();
            }

            _context.Promociones.Remove(promocion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PromocionExists(int id)
        {
            return (_context.Promociones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
