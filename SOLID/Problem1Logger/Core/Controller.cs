namespace Problem1Logger.Core
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using Entities;
    using Entities.Appenders.Factories;
    using Entities.Layouts.Factories;
    using Enumerations;
    using Interfaces;

    public class Controller
    {
        private LayoutFactory layoutFactory;
        private AppenderFactory appenderFactory;
        private ILogger logger;

        public Controller(LayoutFactory LayoutFactory, AppenderFactory AppenderFactory)
        {
            this.layoutFactory = LayoutFactory;
            this.appenderFactory = AppenderFactory;
        }

        public void InitializeLogger()
        {
            var appenders = CreateAppenders().ToArray();
            this.logger = new Logger(appenders);
        }

        private ICollection<IAppender> CreateAppenders()
        {
            var inputAppendersCount = int.Parse(Console.ReadLine());
            var appenders = new List<IAppender>();

            for (int i = 0; i < inputAppendersCount; i++)
            {
                //read input information about appender
                var inputInfo = Console.ReadLine().Split();
                var appenderName = inputInfo[0];
                var layoutName = inputInfo[1];

                //create layout and appender according to input information
                var layout = this.layoutFactory.CreateLayout(layoutName);
                var appender = this.appenderFactory.CreateAppender(appenderName, layout);

                //If input have that info, add ReportLevel;
                if (inputInfo.Length > 2)
                {
                    var reportLevelName = this.ToTitleCase(inputInfo[2]);
                    var reportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), reportLevelName);
                    appender.ReportLevel = reportLevel;
                }

                appenders.Add(appender);
            }

            return appenders;
        }

        private string ToTitleCase(string text)
        {
            var titleCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
            return titleCase;
        }

        public void SendMessageToLogger(string text)
        {
            var input = text.Split('|');

            var methodName = input[0];
            var method = typeof(Logger).GetMethod(methodName);

            var timeStamp = input[1];
            var message = input[2];
            var obj = new object[] { timeStamp, message };

            method.Invoke(this.logger, obj);
        }
    }
}
