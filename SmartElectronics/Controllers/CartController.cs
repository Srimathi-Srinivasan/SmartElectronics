using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartElectronicsMVC.Models;
using System.Dynamic;

namespace SmartElectronicsMVC.Controllers
{
    public class CartController : Controller
    {
        private readonly SmartElectronicsContext db;

        public CartController(SmartElectronicsContext _db)
        {
            db = _db;
        }


        public IActionResult CartDetails(int pid)
        {
            
            ViewBag.CustomerName = HttpContext.Session.GetString("CustomerName");
            ViewBag.CustomerID = (HttpContext.Session.GetInt32("CustomerID"));
            if (ViewBag.CustomerName != null)
            {
                //Customer c = new Customer();
                Product p = new Product();
                CartDetail cd = new CartDetail();
                cd.ProdId = pid;
                cd.CustId = ViewBag.CustomerID;
                db.CartDetails.Add(cd);
                db.SaveChanges();
                TempData["cartmsg"] = "Item Added to Cart Successfully!";
                dynamic mymodel = new ExpandoObject();
                mymodel.Products = p.GetDescription(pid);
                mymodel.Carts = cd.GetDetails(ViewBag.CustomerID); 

                #region
                ////cd.CustomerId = c.CustomerId;
                ////cd.ProdId = p.ProdId;
                //List<Customer> clist = new List<Customer>();
                //List<Product> plist = new List<Product>();

                //clist = c.GetDetails(cid);
                //plist = p.GetDescription(pid);

                //cd.CustomerId = Convert.ToInt32(clist[0]);
                //cd.ProdId = Convert.ToInt32(plist[0]);
                //cd.Price = Convert.ToInt32(plist[4]);
                //dynamic mymodel = new ExpandoObject();
                //mymodel.Products = p.GetDescription(pid);
                //mymodel.Customers = c.GetDetails(cid);
                #endregion
                return View(mymodel);
            }
            else
            {
                TempData["Message"] = "Login To Continue...!";
                return RedirectToAction("Login", "Login");
            }
        }

        int flag = 0;
        public IActionResult AddCart(int pid)
        {
            ViewBag.CustomerName = HttpContext.Session.GetString("CustomerName");
            ViewBag.CustomerID = (HttpContext.Session.GetInt32("CustomerID"));
            if (ViewBag.CustomerName != null)
            {
                Product p = new Product();
                CartDetail cd = new CartDetail();
                cd.ProdId = pid;
                cd.CustId = ViewBag.CustomerID;
                db.CartDetails.Add(cd);
                db.SaveChanges();
                //flag = 1;
                return RedirectToAction();
            }
            else
            {
                TempData["Message"] = "Login To Continue...!";
                return RedirectToAction("Login", "Login");
            }
        }

        public IActionResult ViewCart()
        {
            ViewBag.CustomerName = HttpContext.Session.GetString("CustomerName");
            ViewBag.CustomerID = (HttpContext.Session.GetInt32("CustomerID"));
            ViewBag.Totalamount = 0;
            if (ViewBag.CustomerName != null)
            {
                Product p = new Product();
                CartDetail cd = new CartDetail();
                dynamic mymodel = new ExpandoObject();
                mymodel.Carts = cd.GetDetails(ViewBag.CustomerID);
                mymodel.Products = p.GetProducts();
                
                return View(mymodel);
            }
            else
            {
                TempData["Message"] = "Login To Continue...!";
                return RedirectToAction("Login", "Login");
            }
        }

        
    }
}
