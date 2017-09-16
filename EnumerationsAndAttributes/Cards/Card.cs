namespace Cards
{
    using System;

    public class Card
    {
        public Card(string rank, string suit)
        {
            this.Rank = (CardRank)Enum.Parse(typeof(CardRank), rank);
            this.Suit = (CardSuit)Enum.Parse(typeof(CardSuit), suit);
        }

        public CardRank Rank { get; set; }
        public CardSuit Suit { get; set; }

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
