namespace _03.IteratorTest
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ListIterator
    {
        private List<string> elements;
        private int index;

        public ListIterator(ICollection<string> elements)
        {
            this.Elements = elements;
            this.index = 0;
        }

        public ICollection<string> Elements
        {
            get
            {
                return this.elements;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Input colection can not be null.");
                }

                this.elements = value.ToList();
            }
        }

        public bool HasNext()
        {
            var hasNext = (this.index + 1) < this.elements.Count ? true : false;
            return hasNext;
        }

        public bool Move()
        {
            if (HasNext())
            {
                this.index++;
                return true;
            }

            return false;
        }

        public string Print()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            var output = this.elements[index];
            return output;
        }
    }
}
