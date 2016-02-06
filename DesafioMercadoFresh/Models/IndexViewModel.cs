using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioMercadoFresh.Models
{
    public class IndexViewModel
    {
        public int IndexViewModelId { get; set; }

        public int ProductId { get; set; }        

        public string ProductName { get; set; }

        public byte[] ProductImage { get; set; }

        public double TotalQuantity { get; set; }

        public string QntyUnity { get; set; }

        public string Observations { get; set; }
    }
}