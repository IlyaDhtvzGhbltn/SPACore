using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Contracts
{
    public class ErrorModel
    {
        public string Message { get; set; }

        public string ConvertToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
