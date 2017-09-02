namespace CustomListExercices
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomList<T> : ICustomList<T>
        where T : IComparable
    {
        private List<T> list;
        
        public CustomList()
        {
            this.list = new List<T>();
        }

        public void Add(T element)
        {
            this.list.Add(element);
        }

        public bool Contains(T element)
        {
            var isContained = this.list.Contains(element);

            return isContained;
        }

        public int CountGreaterThan(T element)
        {
            var counter = 0;

            foreach (var listElement in this.list)
            {
                if (element.CompareTo(listElement) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }

        public T Max()
        {
            var max = this.list.Max();

            return max;
        }

        public T Min()
        {
            var min = this.list.Min();

            return min;
        }

        public void Remove(int index)
        {
            this.list.RemoveAt(index);
        }

        public void Swap(int index1, int index2)
        {
            var temporary = this.list[index1];
            this.list[index1] = this.list[index2];
            this.list[index2] = temporary;
        }
    }
}
