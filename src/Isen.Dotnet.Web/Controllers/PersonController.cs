using Isen.Dotnet.Library.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Isen.Dotnet.Web.Controllers
{
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IDataInitializer _dataInitializer;

        public PersonController(
            ILogger<PersonController> logger,
            IDataInitializer dataInitializer)
        {
            _logger = logger;
            _dataInitializer = dataInitializer;
        }

        // https://localhost:5001/Person/Index
        [HttpGet] // facultatif car GET par défaut
        public IActionResult Index()
        {       
            _logger.LogInformation("Appel de /person/index");
            var persons = _dataInitializer.GetPersons(20);
            _logger.LogDebug($"Passage de {persons.Count} personnes à la vue");
            return View(persons);
        }
    }
}