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

        public int CalculatePower()
        {
            var power = 0;
            power += (int)Rank;
            power += (int)Suit;

            return power;
        }
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
                result = this.CalculatePower().CompareTo(other.CalculatePower());
            }

            return result;
        }
        public string CreateCardName()
        {
            var output = $"{this.Rank} of {this.Suit}";
            return output;
        }
        public override string ToString()
        {
            var output = $"Card name: {this.CreateCardName()}; Card power: {this.CalculatePower()}";
            return output;
        }
        //public override bool Equals(object obj)
        //{
        //    var other = obj as Card;
        //    if (other == null)
        //    {
        //        return false;
        //    }
        //    else if (ReferenceEquals(this, other))
        //    {
        //        return true;
        //    }
        //    bool areEquals = this.CreateCardName().Equals(other.CreateCardName());
        //    return areEquals;
        //}
    }
}
