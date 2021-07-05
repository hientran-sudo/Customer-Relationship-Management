using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMT.Models
{
    public class Sold
    {
        public int ProductID { get; set; }
        public int SaleID { get; set; }
        public Product Product { get; set; }
        public Sale Sale { get; set; }
        public int Item { get; set; }
        
    }
}
