using CoreWebApi.Filters;
using CoreWebApi.Models;
using CoreWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [TypeFilter(typeof(ExceptionFilter))]
    [ApiController]
    public class OrderStatusController : ControllerBase
    {
        private readonly IOrderStatusService orderStatusService;

        public OrderStatusController(IOrderStatusService orderStatusService)
        {
            this.orderStatusService = orderStatusService;
        }

        // GET: api/OrderStatus
        [HttpGet]
        public async Task<IActionResult> GetOrderStatus()
        {
            return Ok(await orderStatusService.GetOrderStatusList());
        }

        // GET: api/OrderStatus/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderStatus(int id)
        {
            var orderStatus = orderStatusService.GetOrderStatus(id);
            if (orderStatus == null)
            {
                return NotFound();
            }
            return Ok(await orderStatus);
        }

        // PUT: api/OrderStatus/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderStatus(int id, OrderStatusModel orderStatus)
        {
            if (id != orderStatus.OrderStatusId)
            {
                return BadRequest();
            }

            try
            {
                await orderStatusService.PutOrderStatus(id, orderStatus);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!orderStatusService.OrderStatusExists(id).Result)
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
        public async Task<IActionResult> PostOrderStatus(OrderStatusModel orderStatus)
        {
            await orderStatusService.PostOrderStatus(orderStatus);
            return CreatedAtAction("GetOrderStatus", new { id = orderStatus.OrderStatusId }, orderStatus);
        }

        // DELETE: api/OrderStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderStatus(int id)
        {
            var orderStatus = await orderStatusService.DeleteOrderStatus(id);
            if (orderStatus == null)
            {
                return NotFound();
            }
            return Ok(orderStatus);
        }

        // HEAD: api/OrderStatus/5
        [HttpHead("{id}")]
        public async Task<IActionResult> OrderStatusExists(int id)
        {
            return Ok(await orderStatusService.OrderStatusExists(id));
        }
    }
}
