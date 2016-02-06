using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioMercadoFresh.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public byte[] ProductImage { get; set; }

        public string ProductName { get; set; }

        public Category Category { get; set; }

        public ICollection<ProductOrder> Order { get; set; }
    }
}