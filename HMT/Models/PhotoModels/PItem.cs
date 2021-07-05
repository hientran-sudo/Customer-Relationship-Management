using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMT.Models
{
    public class PItem
    {
        public string PItemID { get; set; }
        public PStore PStore { get; set; }
        public string PStoreID { get; set; }
        public PDiv PDiv { get; set; }
        public string PDivID { get; set; }
        public string Image { get; set; }
    }
}
