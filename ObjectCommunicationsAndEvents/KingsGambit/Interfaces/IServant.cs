namespace KingsGambit.Interfaces
{
    using System;

    public interface IServant : IPerson
    {
        void SubscribeKingUnderAttack(object sender, EventArgs e);
    }
}
