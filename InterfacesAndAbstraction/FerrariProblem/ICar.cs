namespace FerrariProblem
{
    public interface ICar
    {
        string Driver { get; }
        string Move();
        string Stop();
    }
}
