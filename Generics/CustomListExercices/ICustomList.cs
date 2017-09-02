namespace CustomListExercices
{
    public interface ICustomList<T>
    {
        void Add(T element);
        void Remove(int index);
        bool Contains(T element);
        void Swap(int index1, int index2);
        int CountGreaterThan(T element);
        T Max();
        T Min();
    }
}
