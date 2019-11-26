using Isen.Dotnet.Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Isen.Dotnet.Web.Controllers
{
    public class PersonController : Controller
    {
        // https://localhost:5001/Person/Index
        [HttpGet] // facultatif car GET par défaut
        public IActionResult Index()
        {
            var dataInitializer = new DataInitializer();
            var persons = dataInitializer.GetPersons(20);
            return View(persons);
        }
    }
}