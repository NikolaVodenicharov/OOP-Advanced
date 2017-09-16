namespace Cards
{
    using System;
    using System.Text;

    public class CardsExecution
    {
        public static void Main()
        {
            PrintCardPower();
        }

        public static void PrintCardSuit()
        {
            var input = Console.ReadLine();

            var output = new StringBuilder();
            output.Append(input + ":")
                .AppendLine();

            foreach (var card in Enum.GetValues(typeof(CardSuit)))
            {
                output.Append($"Ordinal value: {(int)card}; Name value: {card}")
                    .AppendLine();
            }

            Console.WriteLine(output.ToString().TrimEnd());
        }

        public static void PrintCardRank()
        {
            var input = Console.ReadLine();

            var output = new StringBuilder();
            output.Append(input + ":")
                .AppendLine();

            foreach (var card in Enum.GetValues(typeof(CardRank)))
            {
                output.AppendFormat($"Ordinal value: {(int)card}; Name value: {card}")
                    .AppendLine();
            }

            Console.WriteLine(output.ToString().TrimEnd());
        }

        public static void PrintCardPower()
        {
            var cardRank = Console.ReadLine();
            var cardSuit = Console.ReadLine();

            var card = new Card(cardRank, cardSuit);

            Console.WriteLine(card);
        }
    }
}
