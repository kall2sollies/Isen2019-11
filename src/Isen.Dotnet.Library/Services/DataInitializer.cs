using System;
using System.Collections.Generic;
using System.Linq;
using Isen.Dotnet.Library.Context;
using Isen.Dotnet.Library.Model;
using Microsoft.Extensions.Logging;

namespace Isen.Dotnet.Library.Services
{
    public class DataInitializer : IDataInitializer
    {
        private List<string> _firstNames => new List<string>
        {
            "Sang", 
            "Anne",
            "Boris",
            "Pierre",
            "Laura",
            "Hadrien",
            "Camille",
            "Louis",
            "Alicia"
        };
        private List<string> _lastNames => new List<string>
        {
            "Schuck",
            "Arbousset",
            "Lopasso",
            "Jubert",
            "Lebrun",
            "Dutaud",
            "Sarrazin",
            "Vu Dinh"
        };

        private List<string> _serviceNames => new List<string>
        {
            "Marketing",
            "Développement",
            "Commercial",
            "Maîtrise d'ouvrage",
            "Référenceur",
            "Designer",
            "Administration"
        };

        private List<string> _roleNames => new List<string>
        {
            "Responsable",
            "Assistant",
            "Chef de produit",
            "Chef de projet",
            "Maitre de l'air",
            "Développeur fullstack",
            "Développeur frontend",
            "Développeur backend",
            "Administrateur",
            "Testeur",
            "Stagiaire"
        };

        // Générateur aléatoire
        private readonly Random _random;

        // DI de ApplicationDbContext
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DataInitializer> _logger;
        public DataInitializer(
            ILogger<DataInitializer> logger,
            ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
            _random = new Random();
        }

        // Générateur de prénom
        private string RandomFirstName => 
            _firstNames[_random.Next(_firstNames.Count)];
        // Générateur de nom
        private string RandomLastName => 
            _lastNames[_random.Next(_lastNames.Count)];
        // Générateur de date
        private DateTime RandomDate =>
            new DateTime(_random.Next(1980, 2010), 1, 1)
                .AddDays(_random.Next(0, 365));
        // Générateur de téléphone
        private string RandomTelephone =>
            '0' + _random.Next(100000000, 999999999).ToString();
        // Générateur de personne
        private Person RandomPerson()
        {
            Person person =  new Person();
            string firstName = RandomFirstName;
            string lastName = RandomLastName;
            person.FirstName = firstName;
            person.LastName = lastName;
            person.DateOfBirth = RandomDate;
            person.Telephone = RandomTelephone;
            person.Email = firstName.ToLower() + '.' + lastName.ToLower() + "@isen.yncrea.fr";
            return person;
        }

        // Générateur de personnes
        public List<Person> GetPersons(int size)
        {
            var persons = new List<Person>();
            for(var i = 0 ; i < size ; i++)
            {
                persons.Add(RandomPerson());
            }
            return persons;
        }

        private Service OneService(string name)
        {
            Service service = new Service();
            service.Name = name;
            return service;
        }

        public List<Service> GetServices()
        {
            var services = new List<Service>();
            int totalService = _serviceNames.Count();
            for (var i = 0; i < totalService; i++)
            {
                services.Add(OneService(_serviceNames[i]));
            }
            return services;
        }

        public List<Role> GetRoles()
        {
            var roles = new List<Role>();
            int nbRoles = _roleNames.Count();
            for (var i = 0; i < nbRoles; i++)
            {
                roles.Add(new Role(_roleNames[i]));
            }
            return roles;
        }   

        public void DropDatabase()
        {
            _logger.LogWarning("Dropping database");
            _context.Database.EnsureDeleted();
        }

        public void CreateDatabase()
        {
            _logger.LogWarning("Creating database");
            _context.Database.EnsureCreated();
        }

        public void AddPersons()
        {
            _logger.LogWarning("Adding persons...");
            // S'il y a déjà des personnes dans la base -> ne rien faire
            if (_context.PersonCollection.Any()) return;
            // Générer des personnes
            var persons = GetPersons(50);
            // Les ajouter au contexte
            _context.AddRange(persons);
            // Sauvegarder le contexte
            _context.SaveChanges();
        }

        public void AddServices()
        {
            _logger.LogWarning("Adding services...");
            if (_context.ServiceCollection.Any()) return;
            var services = GetServices();
            _context.AddRange(services);
            _context.SaveChanges();
        }

        public void AddRoles()
        {
            _logger.LogWarning("Adding roles...");
            if (_context.RoleCollection.Any()) return;
            var roles = GetRoles();
            _context.AddRange(roles);
            _context.SaveChanges();
        }
    }
}