namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class BorderControlExecution
    {
        static void Main(string[] args)
        {
            var inhabitants = new List<IIdentifiable>();

            while (true)
            {
                var input = Console.ReadLine();

                bool stopLoop = input.Equals("End", StringComparison.InvariantCultureIgnoreCase);
                if (stopLoop)
                {
                    break;
                }

                AddInhiabitant(inhabitants, input);
            }

            var fakeId = Console.ReadLine();
            StringBuilder rebelionsId = ExtractRebelionsId(inhabitants, fakeId);

            PrintIdsForDetaining(rebelionsId);
        }

        private static StringBuilder ExtractRebelionsId(List<IIdentifiable> inhabitants, string fakeId)
        {
            var rebelionsId = new StringBuilder();
            foreach (var inhab in inhabitants)
            {
                var lastDigits = inhab.Id.Substring(inhab.Id.Length - fakeId.Length);

                if (lastDigits == fakeId)
                {
                    rebelionsId.AppendLine(inhab.Id);
                }
            }

            return rebelionsId;
        }

        private static void PrintIdsForDetaining(StringBuilder rebelionsId)
        {
            Console.WriteLine(rebelionsId.ToString().TrimEnd());
        }

        private static void AddInhiabitant(List<IIdentifiable> inhabitats, string input)
        {
            var splitInput = input.Split();

            if (splitInput.Length == 2)
            {
                IIdentifiable inputRobot = new Robot(splitInput[0], splitInput[1]);
                inhabitats.Add(inputRobot);
            }
            else if (splitInput.Length == 3)
            {
                var inputCitizen = new Citizen(splitInput[0], splitInput[1], splitInput[2]);
                inhabitats.Add(inputCitizen);
            }
        }
    }
}
