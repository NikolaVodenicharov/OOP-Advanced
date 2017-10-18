namespace KingsGambit
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Models;
    using System.Linq;

    public class KingsGambitExecution
    {
        public static void Main()
        {
            var servants = new List<IServant>();
            var consoleReader = new ConsoleReader();

            var kingName = consoleReader.ReadLine();
            var king = new King(kingName);

            var royalGuardsNames = consoleReader.ReadLine().Split();
            foreach (var royalGuardName in royalGuardsNames)
            {
                var royalGuard = new RoyalGuard(royalGuardName);
                king.KingUnderAttack += royalGuard.SubscribeKingUnderAttack;
                servants.Add(royalGuard);
            }

            var footmansNames = consoleReader.ReadLine().Split();
            foreach (var footmanName in footmansNames)
            {
                var footman = new Footman(footmanName);
                king.KingUnderAttack += footman.SubscribeKingUnderAttack;
                servants.Add(footman);
            }

            while (true)
            {
                var command = consoleReader.ReadLine().Split();

                bool isStopLoop = command[0].Equals("End");
                if (isStopLoop)
                {
                    break;
                }

                if (command[0] == "Attack")
                {
                    king.KingIsAttacked();
                }
                else
                {
                    var killedPerson = servants.First(x => x.Name == command[1]);
                    king.KingUnderAttack -= killedPerson.SubscribeKingUnderAttack;
                    servants.Remove(killedPerson);
                }
            }
        }
    }
}
