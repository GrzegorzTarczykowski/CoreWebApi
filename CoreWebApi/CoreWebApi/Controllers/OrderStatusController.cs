using CoreWebApi.MsSqlServerDB;
using CoreWebApi.MsSqlServerDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController : ControllerBase
    {
        private readonly MsSqlServerContext context;
        private readonly IConfiguration configuration;

        public OrderStatusController(MsSqlServerContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        // GET: api/OrderStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderStatus>>> GetOrderStatus()
        {
            string environmentVariable = configuration.GetValue<string>("EnvironmentVariable");
            string environmentVariable2 = Environment.GetEnvironmentVariable("EnvironmentVariable");
            string secretVariable = configuration.GetValue<string>("SecretVariable");
            return await context.OrderStatus.ToListAsync();
        }

        // GET: api/OrderStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderStatus>> GetOrderStatus(int id)
        {
            var orderStatus = await context.OrderStatus.FindAsync(id);

            if (orderStatus == null)
            {
                return NotFound();
            }

            return orderStatus;
        }

        // PUT: api/OrderStatus/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderStatus(int id, OrderStatus orderStatus)
        {
            if (id != orderStatus.OrderStatusId)
            {
                return BadRequest();
            }

            context.Entry(orderStatus).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderStatusExists(id))
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

        // POST: api/OrderStatus
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<OrderStatus>> PostOrderStatus(OrderStatus orderStatus)
        {
            context.OrderStatus.Add(orderStatus);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetOrderStatus", new { id = orderStatus.OrderStatusId }, orderStatus);
        }

        // DELETE: api/OrderStatus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderStatus>> DeleteOrderStatus(int id)
        {
            var orderStatus = await context.OrderStatus.FindAsync(id);
            if (orderStatus == null)
            {
                return NotFound();
            }

            context.OrderStatus.Remove(orderStatus);
            await context.SaveChangesAsync();

            return orderStatus;
        }

        private bool OrderStatusExists(int id)
        {
            return context.OrderStatus.Any(e => e.OrderStatusId == id);
        }
    }
}
