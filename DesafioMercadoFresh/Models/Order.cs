using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioMercadoFresh.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string OrderClientName { get; set; }

        public ICollection<ProductOrder> Products { get; set; }
    }
}