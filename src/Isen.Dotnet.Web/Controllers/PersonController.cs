using System;
using System.Linq;
using Isen.Dotnet.Library.Context;
using Isen.Dotnet.Library.Model;
using Isen.Dotnet.Library.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Isen.Dotnet.Web.Controllers
{
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly ApplicationDbContext _context;

        public PersonController(
            ILogger<PersonController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // https://localhost:5001/Person/Index
        [HttpGet] // facultatif car GET par défaut
        public IActionResult Index()
        {       
            _logger.LogInformation("Appel de /person/index");
            var persons = _context.PersonCollection.ToList();
            _logger.LogDebug($"Passage de {persons.Count} personnes à la vue");
            return View(persons);
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
                _context.PersonCollection.FirstOrDefault(
                    // ... correspond à ce prédicat de recherche
                    person => person.Id == id));
        }

        [HttpPost]
        public IActionResult Edit(Person model)
        {
            if (model == null) return RedirectToAction("Index");
            // Créer la personne
            if (model?.Id == 0) _context.PersonCollection.Add(model);
            // Mise à jour de la personne
            else _context.PersonCollection.Update(model);
            // Sauvegarder le contexte
            _context.SaveChanges();
            // Renvoyer à la liste
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Trouver la personne à supprimer
            var person = _context.PersonCollection
                .FirstOrDefault(p => p.Id == id);
            // Supprimer la personne
            if (person != null) _context.PersonCollection.Remove(person);
            // Sauvegarder
            _context.SaveChanges();
            // Renvoyer vers la liste
            return RedirectToAction("Index");
        }
    }
}