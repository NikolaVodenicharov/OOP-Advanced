namespace Cards
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;

    public class CardsExecution
    {
        public static void Main()
        {
            // CompareCards(); for Problem 5.Card CompareTo()
            // PrintCustomAttributes(ReadCustomAttribute()); for Problem 6.Custom Enum Attribute
            // PrintCardDeck(CreateCardDeck()); for Problem 7.Deck of Cards

            var playerCardsNumber = 5;
            var playersNumber = 2;

            List<Player> players = ReadPlayers(playersNumber);
            var deck = CreateNamedCards();

            for (int playerIndex = 0; playerIndex < players.Count; playerIndex++)
            {
                AddCardsToPlayer(playerCardsNumber, players, deck, playerIndex);
            }

            var winner = players.OrderByDescending(x => x).FirstOrDefault();
            Console.WriteLine($"{winner.Name} wins with {winner.FindStrongestCard().CreateCardName()}.");
        }

        private static void AddCardsToPlayer(int playerCardsNumber, List<Player> players, Dictionary<string, Card> deck, int playerIndex)
        {
            var currentCardNumber = 0;

            while (currentCardNumber < playerCardsNumber)
            {
                var cardName = Console.ReadLine();

                if (deck.ContainsKey(cardName))
                {
                    if (deck[cardName] != null)
                    {
                        players[playerIndex].AddHandCard(deck[cardName]);
                        deck[cardName] = null;
                        currentCardNumber++;
                    }
                    else
                    {
                        Console.WriteLine("Card is not in the deck.");
                    }
                }
                else
                {
                    Console.WriteLine("No such card exists.");
                }
            }
        }

        /// TKey - cardName
        /// TValue - card
        public static Dictionary<string, Card> CreateNamedCards()
        {
            var temporaryDeck = CreateCardDeck();

            var outputDeck = new Dictionary<string, Card>();
            foreach (var card in temporaryDeck)
            {
                outputDeck.Add(card.CreateCardName(), card);
            }

            return outputDeck;
        }
        public static HashSet<Card> CreateCardDeck()
        {
            var cardDeck = new HashSet<Card>();

            var suits = Enum.GetNames(typeof(CardSuit));
            var ranks = Enum.GetNames(typeof(CardRank));

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    var card = new Card(rank, suit);
                    cardDeck.Add(card);
                }
            }

            return cardDeck;
        }

        public static Card ReadCard()
        {
            var cardRank = Console.ReadLine();
            var cardSuit = Console.ReadLine();

            var card = new Card(cardRank, cardSuit);
            return card;
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
        public static List<Player> ReadPlayers(int playersNumber)
        {
            var players = new List<Player>();
            for (int i = 0; i < playersNumber; i++)
            {
                var name = Console.ReadLine();
                var player = new Player(name);
                players.Add(player);
            }

            return players;
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
        public static void PrintCardDeck(ICollection<Card> cardDeck)
        {
            var sb = new StringBuilder();

            foreach (var card in cardDeck)
            {
                sb.AppendLine(card.CreateCardName());
            }

            var output = sb.ToString().TrimEnd();

            Console.WriteLine(output);
        }
        public static void PrintCustomAttributes(Type type)
        {
            var attributes = type.GetCustomAttributes(false);

            foreach (var attribute in attributes)
            {
                Console.WriteLine(attribute);
            }
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
