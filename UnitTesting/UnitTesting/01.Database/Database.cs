namespace _01.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Database
    {
        private const int containerCapacity = 16;
        private int[] numbers;
        private int currentIndex;

        public Database(ICollection<int> numbers)
        {
            this.Numbers = numbers;
        }

        public ICollection<int> Numbers
        {
            get
            {
                var output = new int[currentIndex + 1];
                Array.Copy(this.numbers, output, currentIndex + 1);

                return output;
            }
            private set
            {
                if (value != null && value.Count() <= containerCapacity)
                {
                    this.numbers = new int[containerCapacity];
                    Array.Copy(value.ToArray(), this.numbers, value.Count);

                    this.currentIndex = value.Count - 1;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public void Add(int number)
        {
            if (this.currentIndex + 1 < containerCapacity)
            {
                this.numbers[this.currentIndex + 1] = number;

                this.currentIndex++;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public void Remove()
        {
            if (this.currentIndex >= 0 )
            {
                this.currentIndex--;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public ICollection<int> Fetch ()
        {
            return this.Numbers;
        }
    }
}
