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
    public class PedidoDetallesController : ControllerBase
    {
        private readonly PolloRapiContext _context;

        public PedidoDetallesController(PolloRapiContext context)
        {
            _context = context;
        }

        // GET: api/PedidoDetalles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoDetalle>>> GetPedidoDetalles()
        {
          if (_context.PedidoDetalles == null)
          {
              return NotFound();
          }
            return await _context.PedidoDetalles.ToListAsync();
        }

        // GET: api/PedidoDetalles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoDetalle>> GetPedidoDetalle(int id)
        {
          if (_context.PedidoDetalles == null)
          {
              return NotFound();
          }
            var pedidoDetalle = await _context.PedidoDetalles.FindAsync(id);

            if (pedidoDetalle == null)
            {
                return NotFound();
            }

            return pedidoDetalle;
        }

        // PUT: api/PedidoDetalles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedidoDetalle(int id, PedidoDetalle pedidoDetalle)
        {
            if (id != pedidoDetalle.Id)
            {
                return BadRequest();
            }

            _context.Entry(pedidoDetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoDetalleExists(id))
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

        // POST: api/PedidoDetalles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PedidoDetalle>> PostPedidoDetalle(PedidoDetalle pedidoDetalle)
        {
          if (_context.PedidoDetalles == null)
          {
              return Problem("Entity set 'PolloRapiContext.PedidoDetalles'  is null.");
          }
            _context.PedidoDetalles.Add(pedidoDetalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedidoDetalle", new { id = pedidoDetalle.Id }, pedidoDetalle);
        }

        // DELETE: api/PedidoDetalles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedidoDetalle(int id)
        {
            if (_context.PedidoDetalles == null)
            {
                return NotFound();
            }
            var pedidoDetalle = await _context.PedidoDetalles.FindAsync(id);
            if (pedidoDetalle == null)
            {
                return NotFound();
            }

            _context.PedidoDetalles.Remove(pedidoDetalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedidoDetalleExists(int id)
        {
            return (_context.PedidoDetalles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
