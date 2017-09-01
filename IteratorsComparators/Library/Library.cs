namespace Library
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            this.Books = new List<Book>(books);
        }

        public List<Book> Books { get; set; }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.Books);
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private class LibraryIterator : IEnumerator<Book>
        {
            private const int startingIndex = indexStep * -1;
            private const int indexStep = 1;
            public readonly List<Book> books;
            public int currentIndex;

            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }

            public Book Current
            {
                get
                {
                    var current = this.books[currentIndex];
                    return current;
                }
            }

            object IEnumerator.Current => this.Current;

            public void Dispose() { }

            public bool MoveNext()
            {
                this.currentIndex = this.currentIndex + indexStep;
                var isElementExist = this.currentIndex < this.books.Count;

                return isElementExist;
            }

            public void Reset()
            {
                this.currentIndex = startingIndex;
            }
        }
    }
}
