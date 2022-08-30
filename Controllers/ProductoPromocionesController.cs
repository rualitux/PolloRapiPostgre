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
    public class ProductoPromocionesController : ControllerBase
    {
        private readonly PolloRapiContext _context;

        public ProductoPromocionesController(PolloRapiContext context)
        {
            _context = context;
        }

        // GET: api/ProductoPromociones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoPromocion>>> GetProductoPromociones()
        {
          if (_context.ProductoPromociones == null)
          {
              return NotFound();
          }
            return await _context.ProductoPromociones.ToListAsync();
        }

        // GET: api/ProductoPromociones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoPromocion>> GetProductoPromocion(int id)
        {
          if (_context.ProductoPromociones == null)
          {
              return NotFound();
          }
            var productoPromocion = await _context.ProductoPromociones.FindAsync(id);

            if (productoPromocion == null)
            {
                return NotFound();
            }

            return productoPromocion;
        }

        // PUT: api/ProductoPromociones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductoPromocion(int id, ProductoPromocion productoPromocion)
        {
            if (id != productoPromocion.ProductoPromocionId)
            {
                return BadRequest();
            }

            _context.Entry(productoPromocion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoPromocionExists(id))
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

        // POST: api/ProductoPromociones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductoPromocion>> PostProductoPromocion(ProductoPromocion productoPromocion)
        {
          if (_context.ProductoPromociones == null)
          {
              return Problem("Entity set 'PolloRapiContext.ProductoPromociones'  is null.");
          }
            _context.ProductoPromociones.Add(productoPromocion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductoPromocion", new { id = productoPromocion.ProductoPromocionId }, productoPromocion);
        }

        // DELETE: api/ProductoPromociones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductoPromocion(int id)
        {
            if (_context.ProductoPromociones == null)
            {
                return NotFound();
            }
            var productoPromocion = await _context.ProductoPromociones.FindAsync(id);
            if (productoPromocion == null)
            {
                return NotFound();
            }

            _context.ProductoPromociones.Remove(productoPromocion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoPromocionExists(int id)
        {
            return (_context.ProductoPromociones?.Any(e => e.ProductoPromocionId == id)).GetValueOrDefault();
        }
    }
}
