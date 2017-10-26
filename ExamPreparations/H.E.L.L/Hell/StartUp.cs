namespace Hell
{

    using System.Collections.Generic;

    using Interfaces.IO;
    using IO;
    using Core;
    using Interfaces.Repositories;
    using Repositories;
    using Interfaces.Factories;
    using Factories;
    using Interfaces.Entities.Heroes;
    using Interfaces.Core;
    using System.Collections.Specialized;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IHeroRepository heroRepository = new HeroRepository(new Dictionary<string, IHero>());
            IHeroFactory heroFactory = new HeroFactory();
            IItemFactory itemFactory = new ItemFactory();
            IRecipeFactory recipeFactory = new RecipeFactory();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(heroRepository, heroFactory, itemFactory, recipeFactory);

            Engine engine = new Engine(reader, writer, commandInterpreter);
            engine.Run();
        }
    }
}
