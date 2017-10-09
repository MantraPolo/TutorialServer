using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TutorialServer.Models;

namespace TutorialServer.Controllers
{
    [Produces("application/json")]
    [Route("api/OrderDetailsApi")]
    public class OrderDetailsApiController : Controller
    {
        private readonly OrderDetailContext _context;

        public OrderDetailsApiController(OrderDetailContext context)
        {
            _context = context;
        }

        // GET: api/OrderDetailsApi
        [HttpGet]
        public IEnumerable<OrderDetail> GetOrderDetails()
        {
            return _context.OrderDetails;
        }

        // GET: api/OrderDetailsApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetail([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderDetail = await _context.OrderDetails.SingleOrDefaultAsync(m => m.Id == id);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return Ok(orderDetail);
        }

        // PUT: api/OrderDetailsApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderDetail([FromRoute] long id, [FromBody] OrderDetail orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailExists(id))
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

        // POST: api/OrderDetailsApi
        [HttpPost]
        public async Task<IActionResult> PostOrderDetail([FromBody] OrderDetail orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OrderDetails.Add(orderDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderDetail", new { id = orderDetail.Id }, orderDetail);
        }

        // DELETE: api/OrderDetailsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderDetail = await _context.OrderDetails.SingleOrDefaultAsync(m => m.Id == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();

            return Ok(orderDetail);
        }

        private bool OrderDetailExists(long id)
        {
            return _context.OrderDetails.Any(e => e.Id == id);
        }
    }
}