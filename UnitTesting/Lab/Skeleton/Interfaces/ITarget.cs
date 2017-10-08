namespace Skeleton.Interfaces
{
    public interface ITarget
    {
        int Healt { get; set; }
        int KeptExperience { get; set; }

        void TakeAttack(int attackPoints);
        int GiveExperience();
        bool IsDead();
    }
}
