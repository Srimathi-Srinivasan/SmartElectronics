using System;
using System.Collections.Generic;

namespace SmartElectronicsMVC.Models
{
    public partial class CartDetail
    {
        public int CartId { get; set; }
        public int? ProdId { get; set; }
        public int? CustId { get; set; }

        public virtual Customer? Cust { get; set; }
        public virtual Product? Prod { get; set; }

        public List<CartDetail> GetDetails(int cid)
        {
            using (var db = new SmartElectronicsContext())
            {
                var res = (from i in db.CartDetails
                           where i.CustId == cid
                           select i).ToList();
                return res;
            }
        }
    }
}
