using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioMercadoFresh.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int CategoryPriority { get; set; }

        public List<Product> Products { get; set; }
    }
}