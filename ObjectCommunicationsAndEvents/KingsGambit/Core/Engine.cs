namespace KingsGambit.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using KingsGambit.IO;
    using Interfaces;
    using Models;

    public class Engine
    {
        private ICollection<IServant> servants;
        private IReader consoleReader;
        private IWrite consoleWriter;
        private King king;

        public Engine (ICollection<IServant> servants, IReader consoleReader, IWrite consoleWriter, King king)
        {
            this.servants = servants;
            this.consoleReader = consoleReader;
            this.consoleWriter = consoleWriter;
            this.king = king;
        }

        public void Run()
        {
            CreateRoyalGuards();
            CreateFootmen();

            while (true)
            {
                var line = this.consoleReader.ReadLine().Split();
                var command = line[0];

                bool isStopLoop = command.Equals("End");
                if (isStopLoop)
                {
                    break;
                }

                if (command == "Attack")
                {
                    this.king.KingIsAttacked();
                }
                else if (command == "Kill")
                {
                    var name = line[1];
                    this.TryKill(name);
                }
            }
        }

        private void CreateFootmen()
        {
            var footmansNames = this.consoleReader.ReadLine().Split();

            //if not null
            foreach (var footmanName in footmansNames)
            {
                var footman = new Footman(footmanName);
                footman.Dead += this.RemoveDeadServant;
                this.king.KingUnderAttack += footman.OnKingUnderAttack;
                this.servants.Add(footman);
            }
        }
        private void CreateRoyalGuards()
        {
            var royalGuardsNames = this.consoleReader.ReadLine().Split();

            //exception if null ? How can be null ?
            foreach (var royalGuardName in royalGuardsNames)
            {
                var royalGuard = new RoyalGuard(royalGuardName);
                royalGuard.Dead += this.RemoveDeadServant;
                this.king.KingUnderAttack += royalGuard.OnKingUnderAttack;
                this.servants.Add(royalGuard);
            }
        }
        private void TryKill(string serventName)
        {
            // exception if servent does not exist
            //exception if null ?
            var servant = this.servants.First(x => x.Name == serventName);
            servant.DecreaseLife();
        }
        private void RemoveDeadServant(object sender, EventArgs e)
        {
            var servant = (IServant)sender;
            this.king.KingUnderAttack -= servant.OnKingUnderAttack;
            this.servants.Remove(servant);
        }
    }
}
