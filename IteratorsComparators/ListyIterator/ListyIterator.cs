using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerable<T>
{
    private const int step = 1;

    private List<T> elements;
    private int index = 0;

    public ListyIterator(List<T> elements)
    {
        this.Elements = elements;
    }

    public List<T> Elements { get; set; }

    public bool Move()
    {
        if (this.HasNext())
        {
            this.index += step;
            return true;
        }

        return false;
    }

    public string Print()
    {
        if (this.Elements.Count > 0 )
        {
            var output = this.Elements[index];
            return output.ToString();
        }

        return "Invalid Operation!";
    }

    public bool HasNext()
    {
        return (this.index + step) < this.Elements.Count;
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}