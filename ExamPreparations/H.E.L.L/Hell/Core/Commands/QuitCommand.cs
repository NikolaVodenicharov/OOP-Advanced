namespace Hell.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    using Attributes;
    using Interfaces.Repositories;

    public class QuitCommand : Command
    {
        [CommandInjection]
        private IHeroRepository heroRepository;

        public override string Execute()
        {
            var counter = 1;
            var formatMessage = new StringBuilder();

            foreach (var hero in heroRepository.Heroes.Values.OrderByDescending(h => h))
            {
                formatMessage
                    .AppendLine($"{counter}. {hero.GetType().Name}: {hero.Name}")
                    .AppendLine($"###HitPoints: {hero.HitPoints}")
                    .AppendLine($"###Damage: {hero.Damage}")
                    .AppendLine($"###Strength: {hero.Strength}")
                    .AppendLine($"###Agility: {hero.Agility}")
                    .AppendLine($"###Intelligence: {hero.Intelligence}");

                if (hero.Inventory.Items.Count == 0)
                {
                    formatMessage.AppendLine("###Items: None");
                }
                else
                {
                    var itemNames = new List<string>();
                    foreach (var item in hero.Inventory.Items.Values)
                    {
                        itemNames.Add(item.Name);
                    }

                    var itemNamesText = string.Join(", ", itemNames);

                    formatMessage
                        .AppendLine($"###Items: {itemNamesText}");
                }

                counter++;
            }

            return formatMessage.ToString().TrimEnd();
        }
    }
}