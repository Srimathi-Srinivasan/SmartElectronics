using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartElectronicsMVC.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CartDetails = new HashSet<CartDetail>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "*")]
        public string? CustomerName { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter valid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "*")]
        public long? MobileNumber { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [NotMapped]
        [Compare("Password", ErrorMessage = "Passwords donot match")]
        public string ConfirmPassword { get; set; }

        public virtual ICollection<CartDetail> CartDetails { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public List<Customer> GetDetails(int id)
        {
            using (var db = new SmartElectronicsContext())
            {
                var res = (from i in db.Customers
                           where i.CustomerId == id
                           select i).ToList();
                return res;
            }
        }
    }
}
