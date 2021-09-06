using Microsoft.AspNetCore.Mvc.Filters;
using Orders.Contracts.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Orders.Api.v1.Filters.Orders
{
    public class ValidateNewOrderFilter : Attribute, IActionFilter
    {
        private readonly Regex emailValidate = new Regex("^\\S+@\\S+\\.\\S+$");

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var order = context.ActionArguments["order"];
            if (order is OrderModel castedOrder)
            {
                ICollection<Exception> exceptions = new List<Exception>();

                if (string.IsNullOrWhiteSpace(castedOrder.Company))
                    exceptions.Add(new FormatException("Company Name can't be empty"));
                if (string.IsNullOrWhiteSpace(castedOrder.Customer))
                    exceptions.Add(new FormatException("Customer Name can't be empty"));
                if (string.IsNullOrWhiteSpace(castedOrder.Minister))
                    exceptions.Add(new FormatException("Minister Name can't be empty"));
                if (string.IsNullOrWhiteSpace(castedOrder.Email))
                    exceptions.Add(new FormatException("Email can't be empty"));
                else
                {
                    if (!emailValidate.IsMatch(castedOrder.Email))
                        exceptions.Add(new FormatException("Invalid email format"));
                }

                if (exceptions.Count > 0)
                    throw new AggregateException(exceptions);
            }
            else throw new InvalidCastException();
        }
    }
}
