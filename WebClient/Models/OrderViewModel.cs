using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPAWebClient.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Company { get; set; }
        public string Customer { get; set; }
        public string Minister { get; set; }
        public string Email { get; set; }
    }
}