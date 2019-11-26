using System;

namespace Isen.Dotnet.Library.Model
{
    public class Person
    {
        public int Id {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public DateTime? DateOfBirth {get;set;}
        public string BirthCity {get;set;}
        public string ResidenceCity {get;set;}
        public int? Age => DateOfBirth.HasValue ?
            // Nb de jours entre naissance et today / 365
            (int)((DateTime.Now - DateOfBirth.Value).TotalDays / 365) :
            // Pas de date de naissance alors, un entier null
            new int?();
        
        public override string ToString() =>
            $"{FirstName} {LastName} | {DateOfBirth} ({Age}) | {BirthCity} / {ResidenceCity}";
        
    }
}