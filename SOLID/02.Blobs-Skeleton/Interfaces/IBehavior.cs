namespace _02.Blobs.Interfaces
{
    using _02.Blobs.Entities;

    public interface IBehavior
    {
        int HealthModificator { get; }
        int DamageModificator { get; }
        bool IsTriggered { get; }

        //bool ToDelayRecurrentEffect { get; }

        void Trigger(Blob blob);
        void ProcessNextTurn();

        //void ApplyDecrementer();
    }
}