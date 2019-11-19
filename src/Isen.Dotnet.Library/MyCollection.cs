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

        // syntaxe myCollection[2]
        public string this[int index]
        {
            get => _values[index];
            set => _values[index] = value;
        }

        // Ajoute l'élément en fin de liste
        public void Add(string item)
        {
            var tmpArray = new string[Count + 1];
            for (var i = 0 ; i < Count ; i++)
            {
                tmpArray[i] = this[i];
            }
            tmpArray[Count] = item;
            _values = tmpArray;
        }

        // Retire l'élément à l'index donné
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
                    this[i < index ? i : i + 1];
            }
            _values = tmpArray;
        }

        // Renvoie l'index du 1er élément trouvé (ou -1)
        public int IndexOf(string item)
        {
            var index = -1;
            for(var i = 0 ; i < Count ; i++)
            {
                if(this[i].Equals(item))
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