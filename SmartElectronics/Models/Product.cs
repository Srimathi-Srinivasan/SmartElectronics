using System;
using System.Collections.Generic;

namespace SmartElectronicsMVC.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProdId { get; set; }
        public int? CategoryId { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public double? Price { get; set; }
        public int? Count { get; set; }
        public string? Img1 { get; set; }
        public string? Img2 { get; set; }
        public string? Img3 { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public List<Product> GetDescription(int id)
        {
            using (var db = new SmartElectronicsContext())
            {
                var res = (from i in db.Products
                           where i.ProdId == id
                           select i).ToList();
                return res;
            }
        }

        
    }
}
