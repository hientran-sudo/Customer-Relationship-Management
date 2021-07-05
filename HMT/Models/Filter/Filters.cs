using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMT.Models
{
    public class Filters
    {
        public Filters(string filterstring)
        {
            FilterString = filterstring ?? "all-all-all";
            string[] filters = FilterString.Split('-');
            CategoryID = filters[0];
            VendorID = filters[1];
        }
        public string FilterString { get; }
        public string CategoryID { get; }
        public string VendorID { get; }

        public bool HasCategory => CategoryID.ToLower() != "all";
        public bool HasVendor => VendorID.ToLower() != "all";
    }
}
