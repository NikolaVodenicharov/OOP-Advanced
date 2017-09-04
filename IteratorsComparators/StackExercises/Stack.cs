namespace StackExercises
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IEnumerable<T>
    {
        private const int inititialCapacity = 10;
        private int Count;

        public Stack()
        {
            this.Elements = new T[inititialCapacity];
            this.Count = 0;
        }

        public T[] Elements { get; set; }

        public void Push(T element)
        {
            if (this.Count == this.Elements.Length)
            {
                Resize();
            }

            this.Elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            this.Count--;
            if (this.Count < 0)
            {
                throw new ArgumentException("No elements");
            }

            T removedElement = this.Elements[Count];

            return removedElement;
        }

        private void Resize()
        {
            T[] resizedElements = new T[this.Elements.Length * 2];
            this.Elements.CopyTo(resizedElements, 0);
            this.Elements = resizedElements;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0 ; i--)
            {
                yield return this.Elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
