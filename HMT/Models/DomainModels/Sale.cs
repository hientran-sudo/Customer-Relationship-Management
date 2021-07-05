using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMT.Models
{
    public class Sale
    {
        public int SaleID { get; set; }
        public DateTime Date { get; set; }
        public int StoreID { get; set; }
        public int CustomerID { get; set; }
        public Store Store { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Sold> Solds { get; set; }
    }
}
