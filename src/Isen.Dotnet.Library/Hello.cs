// Déclaration des imports
using System;

// Déclaration du namespace, et c'est un bloc
namespace Isen.Dotnet.Library
{
    // Déclaration de la classe (ou des classes)
    
    /// <summary>
    /// Cette classe vous dit Bonjour.
    /// </summary>
    public class Hello
    {
        /// <summary>
        /// Nom de la personne
        /// </summary>
        /// <value></value>
        public string Name { get; private set; }

        /// <summary>
        /// Construit la classe Hello 
        /// </summary>
        /// <param name="name">Le nom de la personne à saluer</param>
        public Hello(string name)
        {
            Name = name;
        }

        // Syntaxe "Expression body"
        public string Greet() => 
            $"Hello, {Name}!";
      }
}