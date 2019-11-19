using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Isen.Dotnet.Library
{
    public class MyCollection<T> : IList<T>
    {
        // stockage interne de la liste
        private T[] _values;
        public T[] Values => _values;
        // Dimension de la liste
        public int Count => _values.Length;

        public MyCollection()
        {
            Clear();
        }
        public MyCollection(T [] array)
        {
            _values = array;
        }

        // syntaxe myCollection[2]
        public T this[int index]
        {
            get => _values[index];
            set => _values[index] = value;
        }

        // Ajoute l'élément en fin de liste
        public void Add(T item)
        {
            var tmpArray = new T[Count + 1];
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
            
            var tmpArray = new T[Count - 1];
            for(var i = 0 ; i < tmpArray.Length ; i++)
            {
                tmpArray[i] =
                    this[i < index ? i : i + 1];
            }
            _values = tmpArray;
        }

        // Renvoie l'index du 1er élément trouvé (ou -1)
        public int IndexOf(T item)
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

        public bool Remove(T item)
        {
            var index  = IndexOf(item);
            if (index >= 0) RemoveAt(index);
            return index >= 0;
        }

        public void Insert(int index, T item)
        {
            if (index > Count || index < 0)
                throw new IndexOutOfRangeException();

            var tmpArray = new T[Count + 1];
            for (var i = 0 ; i < tmpArray.Length ; i++)
            {
                if (i < index) tmpArray[i] = this[i];
                else if (i == index) tmpArray[i] = item;
                else tmpArray[i] = this[i - 1];
            }
            _values = tmpArray;
        }

        public void Clear() => _values = new T[0];
        
        public bool IsReadOnly => false;

        public bool Contains(T item) => 
            IndexOf(item) >= 0;

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException();
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException();
            if (Count + arrayIndex > array.Length) throw new ArgumentException();
            
            for(var i = 0; i < Count ; i++)
            {
                array[arrayIndex + i] = this[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0 ; i < Count ; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => 
            GetEnumerator();

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Dimension={Count} ");
            sb.Append("[ ");
            foreach(var v in this)
            {
                sb.Append(v);
                sb.Append(" ");
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}