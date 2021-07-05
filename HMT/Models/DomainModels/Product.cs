using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HMT.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        public int VendorID { get; set; }
        public Category Category { get; set; }
        public Vendor Vendor { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter price")]
        public decimal? Price { get; set; }
        public ICollection<Sold> Solds { get; set; }
    }
}
