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

        public void Add(string item)
        {
            var tmpArray = new string[Count + 1];
            for (var i = 0 ; i < Count ; i++)
            {
                tmpArray[i] = _values[i];
            }
            tmpArray[Count] = item;
            _values = tmpArray;
        }

        public void RemoveAt(int index)
        {
            if (_values?.Length == null ||
                index > Count ||
                index < 0)
                throw new IndexOutOfRangeException();
            
            var tmpArray = new string[Count - 1];
            for(var i = 0 ; i < tmpArray.Length ; i++)
            {
                tmpArray[i] =
                    _values[i < index ? i : i + 1];
            }
            _values = tmpArray;
        }

        public int IndexOf(string item)
        {
            var index = -1;
            for(var i = 0 ; i < Count ; i++)
            {
                if(_values[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }
            return index;
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