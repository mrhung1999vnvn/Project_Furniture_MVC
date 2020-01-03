using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_NoiThat.Models
{
    public class ProductForCart
    {
        public int Id { get; set; }
        public double? price { get; set; }
        public string categories { get; set; }
        public string name { get; set; }
        public string picture { get; set; }
        public int quantity { get; set; }
        public string address { get; set; }
    }
}