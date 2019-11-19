using System;
using Isen.Dotnet.Library;

namespace Isen.Dotnet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instancier un tableau
            var array = new string[]
            {
                 "Hello", 
                 "world", 
                 "of", 
                 "useless", 
                 "arrays"
            };
            var myCollection = new MyCollection(array);
            Console.WriteLine(myCollection);
        }
    }
}
