namespace _02.Blobs.Interfaces
{
    using _02.Blobs.Entities;

    public interface ISpecialAttack
    {
        int AttackModifier(Blob blob);
    }
}