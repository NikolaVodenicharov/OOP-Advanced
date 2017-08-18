namespace MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using MilitaryElite.Classes;
    using MilitaryElite.Interfaces;
    using System.Linq;
    using System.Text;

    public class MilitaryEliteExecution
    {
        public static void Main()
        {
            var army = new List<Soldier>();

            while (true)
            {
                var inputLine = Console.ReadLine();

                var stopLoop = inputLine.Equals("End", StringComparison.OrdinalIgnoreCase);
                if (stopLoop)
                {
                    break;
                }

                try
                {
                    AddSoldier(army, inputLine);
                }
                catch (Exception)
                {
                }
            }

            var output = ExctractOutput(army);

            PrintAnswer(output);
        }

        private static void PrintAnswer(string output)
        {
            Console.WriteLine(output.TrimEnd());
        }

        private static string ExctractOutput(List<Soldier> army)
        {
            var output = new StringBuilder();
            foreach (var soldier in army)
            {
                output.AppendLine(soldier.ToString());
            }

            return output.ToString();
        }

        private static void AddSoldier(List<Soldier> army, string inputLine)
        {
            var splitedInput = inputLine.Split();

            var soldierType = splitedInput[0];
            var id = splitedInput[1];
            var firstName = splitedInput[2];
            var lastName = splitedInput[3];

            bool isPrivate = soldierType.Equals("Private", StringComparison.OrdinalIgnoreCase);
            bool isLeutenantGeneral = soldierType.Equals("LeutenantGeneral", StringComparison.OrdinalIgnoreCase);
            bool isEngineer = soldierType.Equals("Engineer", StringComparison.OrdinalIgnoreCase);
            bool isCommando = soldierType.Equals("Commando", StringComparison.OrdinalIgnoreCase);
            bool isSpy = soldierType.Equals("Spy", StringComparison.OrdinalIgnoreCase);

            if (isPrivate)
            {
                var salary = double.Parse(splitedInput[4]);

                var inputPrivate = new Private(firstName, lastName, id, salary);
                army.Add(inputPrivate);
            }
            else if (isLeutenantGeneral)
            {
                var salary = double.Parse(splitedInput[4]);
                List<ISoldier> privates = ExtractPrivates(splitedInput, army);

                var inputLeutenantGeneral = new LeutenantGeneral(firstName, lastName, id, salary, privates);
                army.Add(inputLeutenantGeneral);
            }
            else if (isEngineer)
            {
                var salary = double.Parse(splitedInput[4]);
                var corps = splitedInput[5];
                List<IRepair> repairs = ExtractRepairs(splitedInput);

                var inputEngineer = new Engineer(firstName, lastName, id, salary, corps, repairs);
                army.Add(inputEngineer);
            }
            else if (isCommando)
            {
                var salary = double.Parse(splitedInput[4]);
                var corps = splitedInput[5];
                List<IMission> missions = ExtractMissions(splitedInput);

                var inputCommando = new Commando(firstName, lastName, id, salary, corps, missions);
                army.Add(inputCommando);
            }
            else if (isSpy)
            {
                var code = int.Parse(splitedInput[4]);

                var inputSpy = new Spy(firstName, lastName, id, code);
                army.Add(inputSpy);
            }
        }

        private static List<IMission> ExtractMissions(string[] splitedInput)
        {
            List<IMission> missions = new List<IMission>();

            var missionsInfo = splitedInput.Skip(6).ToArray();
            for (int i = 0; i < missionsInfo.Length; i += 2)
            {
                try
                {
                    var codeName = missionsInfo[i];
                    var state = missionsInfo[i + 1];
                    var inputMission = new Mission(codeName, state);

                    missions.Add(inputMission);
                }
                catch (Exception)
                {
                }
            }

            return missions;
        }

        private static List<IRepair> ExtractRepairs(string[] splitedInput)
        {
            var repairs = new List<IRepair>();

            var repairsInfo = splitedInput.Skip(6).ToArray();
            for (int i = 0; i < repairsInfo.Length; i += 2)
            {
                var partName = repairsInfo[i];
                var hoursWorked = repairsInfo[i + 1];
                var inputRepair = new Repair(hoursWorked, partName);

                repairs.Add(inputRepair);
            }

            return repairs;
        }

        private static List<ISoldier> ExtractPrivates(string[] splitedInput, List<Soldier> army)
        {
            var privates = new List<ISoldier>();

            var Ids = splitedInput.Skip(5).ToArray();
            foreach (var id in Ids)
            {
                privates.Add(army.First(s => s.Id == id));
            }

            return privates;
        }
    }
}
