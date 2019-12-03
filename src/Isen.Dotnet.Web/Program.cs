using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Isen.Dotnet.Library.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Isen.Dotnet.Web
{
    public class Program
    {
        // Lancer le serveur d'application Kestrel
        public static void Main(string[] args)
        {
            Console.WriteLine("Program.Main.Start");
            // Définir un 'hote'
             var host = CreateHostBuilder(args)
            // le 'construire'
                .Build();
            // Récupérer une instance de IDataInitializer
            using(var serviceScope = host.Services.CreateScope())
            {
                var dataInitializer = serviceScope
                    .ServiceProvider.GetService<IDataInitializer>();
                dataInitializer.DropDatabase();
                dataInitializer.CreateDatabase();
                dataInitializer.AddCities();
                dataInitializer.AddPersons();
            }
            // l'exécuter
            host.Run(); // Loop d'exécution et d'écoute du serveur web
            
            // Ceci ne s'exécute que quand le serveur web
            // est arrêté
            Console.WriteLine("Program.Main.End");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Référence à une classe 'Startup'
                    webBuilder.UseStartup<Startup>();
                });
    }
}
