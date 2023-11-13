using Microsoft.AspNetCore.Mvc;

namespace MIS3033_LC_1106_BenReilly.Controllers
{
    public class AController : Controller // inherit A name of the controller is A
    {
        public IActionResult B() 
        {
            return View();
        }


        public JsonResult GetR() // functio, action, web api,
        {
            var r = new { ID = "s123", Name = "Ben", Grade = 96.6 };
            return Json(r);
        }

        public IActionResult Index() // action, view, webpage
        {
            ViewBag.stu= new { ID = "s123", Name = "Ben", Grade = 96.6 };
            ViewBag.age = 20;


            return View();
        }
    }
}
