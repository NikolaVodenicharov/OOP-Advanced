namespace CustomListExercices
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomList<T> : ICustomList<T>, IEnumerable<T>
        where T : IComparable
    {
        private List<T> elements;
        
        public CustomList()
        {
            this.elements = new List<T>();
        }

        public void Add(T element)
        {
            this.elements.Add(element);
        }

        public bool Contains(T element)
        {
            var isContained = this.elements.Contains(element);

            return isContained;
        }

        // count of list elements greater than input element
        public int CountGreaterThan(T element)
        {
            var counter = 0;

            foreach (var listElement in this.elements)
            {
                if (element.CompareTo(listElement) < 0)
                {
                    counter++;
                }
            }

            return counter;
        }

        public T Max()
        {
            var max = this.elements.Max();

            return max;
        }

        public T Min()
        {
            var min = this.elements.Min();

            return min;
        }

        public void Remove(int index)
        {
            this.elements.RemoveAt(index);
        }

        public void Swap(int index1, int index2)
        {
            var temporary = this.elements[index1];
            this.elements[index1] = this.elements[index2];
            this.elements[index2] = temporary;
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.elements.Count; i++)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
