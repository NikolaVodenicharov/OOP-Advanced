namespace Problem1Logger.Entities.Appenders.Factories
{
    using Interfaces;
    using System;
    using System.Reflection;
    using System.Linq;

    public class AppenderFactory
    {
        public IAppender CreateAppender (string appenderName, ILayout layout)
        {
            var type = 
                Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .First(t => t.Name == appenderName);
            var appender = 
                (IAppender)Activator
                .CreateInstance(type);
            return appender;
        }
    }
}
