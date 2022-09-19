using System;
using System.Collections.Generic;

namespace SmartElectronicsMVC.Models
{
    public partial class CartDetail
    {
        public int? CustomerId { get; set; }
        public int? ProdId { get; set; }
        public double? Price { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Product? Prod { get; set; }
    }
}
