using Microsoft.AspNetCore.Mvc;

namespace Isen.Dotnet.Web.Controllers
{
    public class PersonController : Controller
    {
        // https://localhost:5001/Person/Index
        [HttpGet] // facultatif car GET par défaut
        public IActionResult Index()
        {
            return View();
        }
    }
}