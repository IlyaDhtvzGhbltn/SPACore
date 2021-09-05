using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orders.Contracts.Order;

namespace Orders.Api.v1.Filters.Orders
{
    public class OrderDoesntExistFilter : Attribute, IActionFilter
    {

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            int orderId = (int)context.ActionArguments["orderId"];
            var ordersCollection = context.HttpContext.RequestServices.GetService<ICollection<OrderModel>>();
            if (!ordersCollection.Any(x => x.Id == orderId))
                throw new ApplicationException("Order doesn't exist");
        }
    }
}
