namespace KingsGambit.Interfaces
{
    using System;

    public interface IKillable
    {
        event EventHandler Dead;

        int Life { get; }

        void DecreaseLife();
    }
}
