using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMT.Models
{
    public class ViewModel
    {
        public IEnumerable<Sold> Solds { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Customer> Sales { get; set; }
    }
}
