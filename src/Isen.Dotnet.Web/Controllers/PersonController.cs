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

        // https://localhost:5001/Person/Edit/42
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            // Pas d'id : formulaire vierge (création)
            if (id == null) return View();
            // Rechercher la personne ayant l'Id <id>
            return View(
                // Contexte > Liste des personnes : prendre la 1ère personne qui...
                Context.Set<Person>().FirstOrDefault(
                    // ... correspond à ce prédicat de recherche
                    e => e.Id == id));
        }

        [HttpPost]
        public IActionResult Edit(Person entity)
        {
            if (entity == null) return RedirectToAction("Index");
            // Créer la personne
            if (entity?.Id == 0) Context.Set<Person>().Add(entity);
            // Mise à jour de la personne
            else Context.Set<Person>().Update(entity);
            // Sauvegarder le contexte
            Context.SaveChanges();
            // Renvoyer à la liste
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Trouver la personne à supprimer
            var entity = Context.Set<Person>()
                .FirstOrDefault(e => e.Id == id);
            // Supprimer la personne
            if (entity != null) Context.Set<Person>().Remove(entity);
            // Sauvegarder
            Context.SaveChanges();
            // Renvoyer vers la liste
            return RedirectToAction("Index");
        }
    }
}