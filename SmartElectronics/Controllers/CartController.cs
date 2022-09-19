using Microsoft.AspNetCore.Mvc;
using SmartElectronicsMVC.Models;
using System.Dynamic;

namespace SmartElectronicsMVC.Controllers
{
    public class CartController : Controller
    {
        public IActionResult CartDetails(int cid,int pid)
        {
            
            ViewBag.CustomerName = HttpContext.Session.GetString("CustomerName");
            if(ViewBag.CustomerName != null)
            {
                Customer c = new Customer();
                Product p = new Product();
                CartDetail cd = new CartDetail();
                //cd.CustomerId = c.CustomerId;
                //cd.ProdId = p.ProdId;
                List<Customer> clist = new List<Customer>();
                List<Product> plist = new List<Product>();

                clist = c.GetDetails(cid);
                plist = p.GetDescription(pid);

                cd.CustomerId = Convert.ToInt32(clist[0]);
                cd.ProdId = Convert.ToInt32(plist[0]);
                cd.Price = Convert.ToInt32(plist[4]);
                //dynamic mymodel = new ExpandoObject();
                //mymodel.Products = p.GetDescription(pid);
                //mymodel.Customers = c.GetDetails(cid);
                return View(cd);
            }
            else
            {
                TempData["Message"] = "Login To Continue...!";
                return RedirectToAction("Login", "Login");
            }
        }
    }
}
