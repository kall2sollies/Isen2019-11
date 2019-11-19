using System;
using Isen.Dotnet.Library;

namespace Isen.Dotnet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var myCollection = new MyCollection();
            myCollection.Add("Hello");
            myCollection.Add("world");
            myCollection.Add("of");
            myCollection.Add("useless");
            myCollection.Add("arrays");

            Console.WriteLine(myCollection);
            // Hello world of useless arrays

            myCollection.RemoveAt(3); // Remove au milieu
            Console.WriteLine(myCollection);
            // Hello world of arrays

            myCollection.RemoveAt(3); // Remove à la fin
            Console.WriteLine(myCollection);
            // Hello world of

            myCollection.RemoveAt(0); // Remove au début
            Console.WriteLine(myCollection);
            // world of
        }
    }
}
