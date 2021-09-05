using Microsoft.AspNetCore.Mvc.Filters;
using Orders.Contracts.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Api.v1.Filters.Orders
{
    public class InvalidOrderIdFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var orderId = (int)context.ActionArguments["orderId"];
            if (orderId <= 0)
                throw new ApplicationException("Invalid order ID");
        }
    }
}
