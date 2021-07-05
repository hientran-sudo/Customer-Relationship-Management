using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMT.Models
{
    public class PhotoFilter
    {
        public PhotoFilter(string filterstring)
        {
            FilterString = filterstring ?? "all-all-all";
            string[] filters = FilterString.Split('-');
            PStoreID = filters[0];
            PDivID = filters[1];
        }
        public string FilterString { get; }
        public string PStoreID { get; }
        public string PDivID { get; }

        public bool HasStore => PStoreID.ToLower() != "all";
        public bool HasDiv => PDivID.ToLower() != "all";
    }
}

