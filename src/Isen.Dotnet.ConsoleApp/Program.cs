using System;
using Isen.Dotnet.Library;

namespace Isen.Dotnet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var myCollection = new MyCollection<string>();
            myCollection.Add("Hello");
            myCollection.Add("world");
            myCollection.Add("of");
            myCollection.Add("useless");
            myCollection.Add("arrays");

            Console.WriteLine(myCollection);
            // Hello world of useless arrays

            var indexOfWorld = myCollection.IndexOf("world");
            Console.WriteLine($"Index of 'world' is {indexOfWorld}");
            // 1

            var elementAt = myCollection[1];
            Console.WriteLine(elementAt);
            // world

            var indexOfFoo = myCollection.IndexOf("foo");
            Console.WriteLine($"Index of 'foo' is {indexOfFoo}");
            // -1

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
