using System.Collections.Generic;
using Isen.Dotnet.Library.Model;

namespace Isen.Dotnet.Library.Services
{
    public interface IDataInitializer
    {
         List<Person> GetPersons(int size);
    }
}