using System;
using System.Collections;
using System.Collections.Generic;

namespace Indexer
{
    public class Array<T> : ICollection<T>
    {

        T[] elements = new T[0];
        private int lowIndex;
        private int highIndex;

        public Array(int low, int high)
        {
            if (high <= low)
            {
                throw new ArgumentException("High index should be larger, than low index!");
            }
            T[] elements = new T[high - low];
            this.lowIndex = low;
            this.highIndex = high;

        }
        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            var newArray = new T[elements.Length + 1];
            elements.CopyTo(newArray, 0);
            newArray[newArray.Length - 1] = item;
            elements = newArray;
            
            
        }

        private void RemoveAt(int index)
        {
            if ((index > 0) && (index < Count))
            {
                var newArray = new T[Count - 1];

                for (int i = 0; i < index; i++)
                {
                    newArray[i] = elements[i];
                }
                for (int i = index; i < Count - 1; i++)
                {
                    newArray[i] = elements[i + 1];
                }

                elements = newArray;
            }
        }

        public bool Remove(T item)
        {
            if (Contains(item))
            {
                RemoveAt(IndexOf(item));
                return true;
            }
            else return false;
        }

        private int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (elements[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }
        public void Show()
        {
            foreach (var item in elements)
            {
                Console.WriteLine(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)elements).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this as IEnumerable<T>).GetEnumerator();
        }



        public void Clear()
        {
            elements = new T[0];
        }

        public bool Contains(T item)
        {
            foreach (var element in elements)
            {
                if (element.Equals(item))
                {
                    return true;
                }
            }

            return false;

            //return elements.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            elements.CopyTo(array, arrayIndex);
        }



        public T this[int index]
        {
            get
            {
                try
                {
                    return elements[index - lowIndex];
                }
                catch
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (!IsReadOnly)
                {
                    try
                    {
                        elements[index - lowIndex] = value;
                    }
                    catch
                    {
                        throw new IndexOutOfRangeException();
                    }
                }

                else
                {
                    throw new InvalidOperationException("Array is readonly.");
                }
            }
        }

        public int Count => elements.Length;
        public bool IsReadOnly { get; set; } = false;


    }
}