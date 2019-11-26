using System;
using Isen.Dotnet.Library;
using Isen.Dotnet.Library.Services;

namespace Isen.Dotnet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataInitializer = new DataInitializer();
            var persons = dataInitializer.GetPersons(10);
            foreach(var p in persons) Console.WriteLine(p);
        }
    }
}
