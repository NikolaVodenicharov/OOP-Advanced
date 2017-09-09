namespace Froggy
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Lake : IEnumerable<int>
    {
        private readonly List<int> elements;

        public Lake (IEnumerable<int> elements)
        {
            this.elements = new List<int>(elements);
        }

        public IEnumerator<int> GetEnumerator()
        {
            var count = this.elements.Count;

            for (int i = 0; i < count; i += 2)
            {
                yield return this.elements[i];
            }

            var lastOddIndex = count - 1;
            if (count % 2 == 1)
            {
                lastOddIndex--;
            }

            for (int i = lastOddIndex; i > 0; i -=2)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
