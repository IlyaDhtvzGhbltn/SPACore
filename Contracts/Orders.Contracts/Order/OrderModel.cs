using Newtonsoft.Json;
using System;


namespace Orders.Contracts.Order
{
    public class OrderModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("company")]
        public string Company { get; set; }
        [JsonProperty("customer")]
        public string Customer { get; set; }
        [JsonProperty("minister")]
        public string Minister { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
