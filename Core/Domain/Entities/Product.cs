using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public bool ProductIsActive { get; set; }
        public string ProductCreatedDate { get; set; } = DateTime.Now.ToString();
    }
}
