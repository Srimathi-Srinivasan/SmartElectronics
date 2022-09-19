using SmartElectronicsMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace ElectronicsShoppingMVC.Controllers
{
    public class TelevisionController : Controller
    {
        private readonly SmartElectronicsContext db;
        
        public TelevisionController(SmartElectronicsContext _db)
        {
            db = _db;
        }
        public IActionResult TVDetails()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Details(Product p)
        {
            return View();
        }

        public IActionResult SpecificTV(int id)
        {            
            Product p = new Product();
            Tvdescription t = new Tvdescription();            
            dynamic mymodel = new ExpandoObject();
            mymodel.Products = p.GetDescription(id);
            mymodel.TVDescription = t.GetDescription(id);
            return View(mymodel);            
        }

        public IActionResult SmartTV()
        {
            return View();
        }

        public IActionResult AndroidTV()
        {
            return View();
        }


    }
}
