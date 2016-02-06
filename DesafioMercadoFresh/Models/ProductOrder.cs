using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioMercadoFresh.Models
{
    public class ProductOrder
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public double Quantity { get; set; }

        public string QntyUnity { get; set; }

        public string Observations { get; set; }

        public Status Status { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }
    }

    public enum Status
    {
        Waiting_For_Picking,
        Picked,
        Not_Found,
        Standby_Picked,
        Standby_Not_Found
    }
}