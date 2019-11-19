using System;
using System.Text;

namespace Isen.Dotnet.Library
{
    public class MyCollection
    {
        // stockage interne de la liste
        private string[] _values;
        // Dimension de la liste
        public int Count => _values.Length;
 
        public MyCollection()
        {
            // Une new liste a 0 éléments
            _values = new string[0];
        }
        public MyCollection(string [] array)
        {
            _values = array;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Dimension={Count} ");
            sb.Append("[ ");
            foreach(var v in _values)
            {
                sb.Append(v);
                sb.Append(" ");
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}