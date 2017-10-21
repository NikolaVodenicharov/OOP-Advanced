namespace Problem1Logger.Entities.Layouts.Factories
{
    using Interfaces;
    using System;
    using System.Linq;
    using System.Reflection;

    public class LayoutFactory
    {
        public ILayout CreateLayout (string layoutName)
        {
            var type =
                Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .First(t => t.Name == layoutName);
            var layout =
                (ILayout)Activator
                .CreateInstance(type);
            return layout;
        }
    }
}
