namespace KingsGambit.Interfaces
{
    using System;

    public interface IServant : IPerson, IKillable
    {
        void OnKingUnderAttack(object sender, EventArgs e);
    }
}
