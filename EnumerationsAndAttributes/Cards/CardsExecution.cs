namespace Cards
{
    using System;
    using System.Text;

    public class CardsExecution
    {
        public static void Main()
        {
            // CompareCards(); for Problem 5.Card CompareTo()
            //ReadCustomAttribute(); for Problem 6.Custom Enum Attribute
            PrintCustomAttributes(ReadCustomAttribute());
        }



        public static Type ReadCustomAttribute()
        {
            var input = Console.ReadLine();

            if (input == "Rank")
            {
                return typeof(CardRank);
            }
            else if(input == "Suit")
            {
                return typeof(CardSuit);
            }
            else
            {
                throw new ArgumentException("Invalid data");
            }
        }

        public static void PrintCustomAttributes(Type type)
        {
            var attributes = type.GetCustomAttributes(false);

            foreach (var attribute in attributes)
            {
                Console.WriteLine(attribute);
            }
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
            var card = ReadCard();

            Console.WriteLine(card);
        }

        public static Card ReadCard()
        {
            var cardRank = Console.ReadLine();
            var cardSuit = Console.ReadLine();

            var card = new Card(cardRank, cardSuit);
            return card;
        }

        public static void CompareCards()
        {
            var card1 = ReadCard();
            var card2 = ReadCard();

            if (card1.CompareTo(card2) > 0)
            {
                Console.WriteLine(card1);
            }
            else
            {
                Console.WriteLine(card2);
            }
        }
    }
}
