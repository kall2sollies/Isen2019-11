using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
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
            CreateHostBuilder(args)
            // le 'construire'
                .Build()
            // l'exécuter
                .Run(); // Loop d'exécution et d'écoute du serveur web
            
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
