namespace Cards
{
    using System;

    public class Card : IComparable<Card>
    {
        public Card(string rank, string suit)
        {
            this.Rank = (CardRank)Enum.Parse(typeof(CardRank), rank);
            this.Suit = (CardSuit)Enum.Parse(typeof(CardSuit), suit);
        }

        public CardRank Rank { get; set; }
        public CardSuit Suit { get; set; }

        public int CompareTo(Card other)
        {
            int result = 0;

            if (ReferenceEquals(this, other))
            {
                result = 0;
            }
            else if (ReferenceEquals(null, other))
            {
                result = 1;
            }
            else
            {
                result = this.Rank.CompareTo(other.Rank);

                if (result == 0)
                {
                    result = this.Suit.CompareTo(other.Suit);
                }
            }

            return result;
        }

        public int Power()
        {
            var power = 0;
            power += (int)Rank;
            power += (int)Suit;

            return power;
        }

        public override string ToString()
        {
            var output = $"Card name: {this.Rank} of {this.Suit}; Card power: {this.Power()}";
            return output;
        }
    }
}
