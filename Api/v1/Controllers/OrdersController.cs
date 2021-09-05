using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orders.Contracts.Order;
using System.Text.Json;
using Orders.Api.v1.Filters.Orders;

namespace SPA_Test.Controllers
{
    [ApiController]
    [Route("api/v1/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly ICollection<OrderModel> _orders;

        public OrdersController(ICollection<OrderModel> orders)
        {
            _orders = orders;
        }

        [HttpGet("{orderId:int}")]
        [InvalidOrderIdFilter]
        [OrderDoesntExistFilter]
        public async Task<IActionResult> GetById(int orderId)
        {
            return Ok(_orders.First(x => x.Id == orderId));
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_orders);
        }

        [HttpPost]
        [ValidateNewOrderFilter]
        public async Task<IActionResult> Post(OrderModel order)
        {
            int count = _orders.Count();
            order.Id = count + 1;
            order.Date = DateTime.UtcNow;
            _orders.Add(order);
            return Ok(order);
        }

        [HttpPut("{orderId:int}")]
        [InvalidOrderIdFilter]
        [OrderDoesntExistFilter]
        [ValidateNewOrderFilter]
        public async Task<IActionResult> Put(int orderId, OrderModel order)
        {
            var updatedOrder = _orders.First(x => x.Id == orderId);
            updatedOrder.Company = order.Company;
            updatedOrder.Customer = order.Customer;
            updatedOrder.Date = DateTime.UtcNow;
            updatedOrder.Email = order.Email;
            updatedOrder.Minister = order.Minister;
            return Ok(updatedOrder);
        }

        [HttpDelete("{orderId:int}")]
        [InvalidOrderIdFilter]
        [OrderDoesntExistFilter]
        public async Task<IActionResult> Delete(int orderId)
        {
            _orders.Remove(_orders.First(x => x.Id == orderId));
            return Ok();
        }
    }
}
