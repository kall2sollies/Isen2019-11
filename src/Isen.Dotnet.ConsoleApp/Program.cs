using System;
using Isen.Dotnet.Library;

namespace Isen.Dotnet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Hello hello = new Hello("Kall");
            Console.WriteLine(hello.Greet());
        }
    }
}
