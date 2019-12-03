using System.Linq;
using Isen.Dotnet.Library.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Isen.Dotnet.Web.Controllers
{
    public abstract class BaseController<T> : Controller
        where T : class
    {
        protected readonly ILogger<BaseController<T>> Logger;
        protected readonly ApplicationDbContext Context;

        protected BaseController(
            ILogger<BaseController<T>> logger,
            ApplicationDbContext context)
        {
            Logger = logger;
            Context = context;
            Logger.LogDebug("BaseController<T>/constructeur");
        }

        [HttpGet] // facultatif car GET par défaut
        public virtual IActionResult Index()
        {       
            var entities = Context.Set<T>().ToList();
            return View(entities);
        }
    }
}