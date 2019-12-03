using System.Collections.Generic;
using System.Linq;
using Isen.Dotnet.Library.Context;
using Isen.Dotnet.Library.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Isen.Dotnet.Web.Controllers
{
    public abstract class BaseController<T> : Controller
        where T : BaseEntity
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

        protected virtual IQueryable<T> BaseQuery() => 
            Context.Set<T>().AsQueryable();
 
        // https://localhost:5001/[Controller]/Index
        [HttpGet] // facultatif car GET par défaut
        public virtual IActionResult Index()
        {       
            var entities = BaseQuery().ToList();
            return View(entities);
        }

        // https://localhost:5001/[Controller]/Edit/42
        [HttpGet]
        public virtual IActionResult Edit(int? id)
        {
            // Pas d'id : formulaire vierge (création)
            if (id == null) return View();
            // Rechercher la personne ayant l'Id <id>
            return View(
                // Contexte > Liste des personnes : prendre la 1ère entité qui...
                BaseQuery().FirstOrDefault(
                    // ... correspond à ce prédicat de recherche
                    e => e.Id == id));
        }

        // https://localhost:5001/[Controller]/Edit/ (objet en POST)
        [HttpPost]
        public virtual IActionResult Edit(T entity)
        {
            if (entity == null) return RedirectToAction("Index");
            // Créer l'entité
            if (entity?.Id == 0) Context.Set<T>().Add(entity);
            // Mise à jour de l'entité
            else Context.Set<T>().Update(entity);
            // Sauvegarder le contexte
            Context.SaveChanges();
            // Renvoyer à la liste
            return RedirectToAction("Index");
        }

        // https://localhost:5001/[Controller]/Delete/42
        [HttpGet]
        public virtual IActionResult Delete(int id)
        {
            // Trouver la personne à supprimer
            var entity = Context.Set<T>()
                .FirstOrDefault(e => e.Id == id);
            // Supprimer l'entité
            if (entity != null) Context.Set<T>().Remove(entity);
            // Sauvegarder
            Context.SaveChanges();
            // Renvoyer vers la liste
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("api/[controller]/")]
        public virtual IEnumerable<T> GetData() => 
            BaseQuery().ToList();
    }
}