using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMT.Models
{
    public class Filter
    {
        public Filter(string filterstring)
        {
            FilterString = filterstring ?? "all-all-all";
            string[] filters = FilterString.Split('-');
            CustomerID = filters[0];
            StoreID = filters[1];
        }
        public string FilterString { get; }
        public string CustomerID { get; }
        public string StoreID { get; }

        public bool HasCustomer => CustomerID.ToLower() != "all";
        public bool HasStore => StoreID.ToLower() != "all";
    }
}

