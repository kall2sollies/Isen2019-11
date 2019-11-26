using Isen.Dotnet.Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Isen.Dotnet.Web.Controllers
{
    public class PersonController : Controller
    {
        private readonly IDataInitializer _dataInitializer;

        public PersonController(
            IDataInitializer dataInitializer)
        {
            _dataInitializer = dataInitializer;
        }

        // https://localhost:5001/Person/Index
        [HttpGet] // facultatif car GET par défaut
        public IActionResult Index()
        {            
            var persons = _dataInitializer.GetPersons(20);
            return View(persons);
        }
    }
}