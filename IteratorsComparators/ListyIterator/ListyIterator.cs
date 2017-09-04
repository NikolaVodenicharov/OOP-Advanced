using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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

    public string PrintAll()
    {
        StringBuilder output = new StringBuilder();

        foreach (var element in this.Elements)
        {
            output.Append(element)
                  .Append(" ");
        }

        return output.ToString().TrimEnd();
    }

    public bool HasNext()
    {
        return (this.index + step) < this.Elements.Count;
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