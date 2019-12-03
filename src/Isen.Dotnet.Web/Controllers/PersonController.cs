using System;
using System.Linq;
using Isen.Dotnet.Library.Context;
using Isen.Dotnet.Library.Model;
using Isen.Dotnet.Library.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Isen.Dotnet.Web.Controllers
{
    public class PersonController : BaseController<Person>
    {
        public PersonController(
            ILogger<PersonController> logger,
            ApplicationDbContext context) : base(logger, context)
        {
            Logger.LogDebug("PersonController/constructeur");
        }               

        // Exemple d'override de la query : liste les personnes
        // par ordre alpha de leur ville de naissance
        protected override IQueryable<Person> BaseQuery() =>
            base.BaseQuery()
                //.Where(p => p.BirthCity.StartsWith("Toul"))
                .OrderBy(p => p.BirthCity);        

         public override IActionResult Delete(int id)
         {
             // override du comportement par défaut : ne jamais autoriser
             // la suppression de la personne ayant l'id=10
             if (id == 10) return RedirectToAction("Index");
             // En dehors de ce cas, effectuer l'implémentation normale
             // de cette méthode
             return base.Delete(id);
         } 
    }
}