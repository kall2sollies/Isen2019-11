using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Isen.Dotnet.Web.Models;

namespace Isen.Dotnet.Web.Controllers
{
    // Nom du contrôleur : Playground
    // Hérite de Controller (qui fait partie du framework ASP.Net MVC Core)
    // via le using Microsoft.AspNetCore.Mvc
    public class PlaygroundController : Controller
    {
        // Membre privé + même paramètre constructeur :
        // Pattern d'injection de dépendance d'une interface ILogger
        private readonly ILogger<PlaygroundController> _logger;
        public PlaygroundController(ILogger<PlaygroundController> logger)
        {
            _logger = logger;
        }
        // Code de la vue/action Index
        public IActionResult Index()
        {
            _logger.LogInformation("[ /playground/index ]");

            // Controller.ViewData est un Dictionnary<string, object>
            ViewData["ViewDataVar"] = "Je suis une variable du ViewData";
            ViewData["ViewDataList"] = new List<int> { 10, 20, 30 };

            // ViewBag est un type `dynamic`
            ViewBag.ViewBagVar = "Je suis une variable du ViewBag";
            ViewBag.ViewBagList = new List<DateTime> { DateTime.Now, DateTime.MaxValue };

            // Classe de modèle
            var model = new MyDataClass()
            {
                SomeField = "Je suis le champ SomeField",
                SomeList = new List<string> { "Je", "suis", "SomeList" }
            };
            // Passage d'un modèle à la vue
            return View(model);
        }
    }
    // Idéalement, à mettre dans le dossier Model/
    public class MyDataClass
    {
        public string SomeField {get;set;}
        public List<string> SomeList {get;set;}
    }
}
