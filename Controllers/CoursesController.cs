using Microsoft.AspNetCore.Mvc;

namespace MyCourse.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return Content("Sono index");
        }
         public IActionResult Detail(string Id)
        {
            return Content($"Sono Detail, ho ricevuto l'id {Id}");
        }

    }
}