namespace RecyclingStation.BusinessLayer.Core
{
    using System;
    using System.Reflection;
    using System.Linq;
    using System.Collections.Generic;

    using Contracts.IO;
    using Contracts.Core;

    public class Engine
    {
        private const string InputEndCommand = "TimeToRecycle";
        private IReader reader;
        private IWriter writer;
        private IRecyclingManager recyclingManager;
        private MethodInfo[] recyclingManagerMethods;

        public Engine(IReader reader, IWriter writer, IRecyclingManager recyclingManager)
        {
            this.reader = reader;
            this.writer = writer;
            this.recyclingManager = recyclingManager;
            this.recyclingManagerMethods = this.recyclingManager.GetType().GetMethods();
        }

        public void Run()
        {
            while (true)
            {
                var inputLine = reader.ReadLine();
                var lineSplitByEmptySpace = this.SplitString(inputLine, ' ');

                var command = lineSplitByEmptySpace[0];

                var isLoopStop = command.Equals(InputEndCommand, StringComparison.InvariantCultureIgnoreCase);
                if (isLoopStop)
                {
                    break;
                }

                // Can named the next 3 lines in one method - ExecuteCommand()
                var method = this.GetMethod(command);
                var parameters = GetParameters(lineSplitByEmptySpace, method);
                var message = method.Invoke(this.recyclingManager, parameters);

                this.writer.WriteAllText(message.ToString());
            }
        }       

        private string[] SplitString(string text, params char[] splitBy)
        {
            if (text == null || splitBy == null)
            {
                throw new ArgumentNullException("Input parameters can not be null");
            }

            var result = text.Split(splitBy, StringSplitOptions.RemoveEmptyEntries);
            return result;
        }

        private MethodInfo GetMethod(string methodName)
        {
            if (!this.recyclingManagerMethods.Any(x => x.Name.Equals(methodName, StringComparison.CurrentCultureIgnoreCase)))
            {
                throw new ArgumentException("There is no name of method that match to input command");
            }

            var method =
                this.recyclingManagerMethods
                .FirstOrDefault(x => x.Name.Equals(methodName, StringComparison.CurrentCultureIgnoreCase));

            return method;
        }

        private object[] GetParameters(string[] lineSplitByEmptySpace, MethodInfo executingMethod)
        {
            if (lineSplitByEmptySpace.Length == 1)
            {
                return null;
            }

            var parametersForConverting = this.SplitString(lineSplitByEmptySpace[1], '|');
            var expectedParametersTypes = this.GetMethodParametersTypes(executingMethod);
            var parameters = this.ConvertTypes(parametersForConverting, expectedParametersTypes);

            return parameters;
        }
        private Type[] GetMethodParametersTypes(MethodInfo method)
        {
            if (method == null)
            {
                throw new ArgumentNullException("Input parameter can not be null");
            }

            var parameters = method.GetParameters();
            List<Type> types = new List<Type>();

            foreach (var param in parameters)
            {
                var type = param.ParameterType;
                types.Add(type);
            }

            return types.ToArray();
        }
        private object[] ConvertTypes(object[] elements, Type[] types)
        {
            if (elements == null || types == null)
            {
                throw new ArgumentNullException("Input parameters can not be null");
            }

            var len = elements.Length;
            var convertedElements = new object[len];

            for (int i = 0; i < len; i++)
            {
                var type = types[i];
                var element = elements[i];

                var convertedElement = Convert.ChangeType(element, type);
                convertedElements[i] = convertedElement;
            }

            return convertedElements;
        }
    }
}
