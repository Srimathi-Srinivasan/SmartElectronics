using Microsoft.AspNetCore.Mvc;
using SmartElectronicsMVC.Models;
using System.Dynamic;

namespace SmartElectronicsMVC.Controllers
{
    public class AudioController : Controller
    {
        public IActionResult AudioDetails()
        {
            return View();
        }

        public IActionResult Neckbands()
        {
            return View();
        }

        public IActionResult WiredEarphones()
        {
            return View();
        }

        public IActionResult Earpods()
        {
            return View();
        }

        public IActionResult Speakers()
        {
            return View();
        }

        public IActionResult SpecificAudio(int id)
        {
            Product p = new Product();
            AudioDescription t = new AudioDescription();
            dynamic mymodel = new ExpandoObject();
            mymodel.Products = p.GetDescription(id);
            mymodel.AudioDescription = t.GetDescription(id);
            return View(mymodel);
        }
    }
}
