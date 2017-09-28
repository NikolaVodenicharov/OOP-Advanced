namespace Cards
{
    using System;
    using System.Collections.Generic;

    public class Player : IComparable<Player>
    {
        private List<Card> handCards;
        public Player(string name)
        {
            this.Name = name;
            this.handCards = new List<Card>();
        }

        public string Name { get; private set; }

        public void AddHandCard(Card card)
        {
            this.handCards.Add(card);
        }
        public Card FindStrongestCard()
        {
            if (this.handCards.Count > 0)
            {
                var strongestCard = this.handCards[0];
                for (int i = 1; i < this.handCards.Count; i++)
                {
                    if (strongestCard.CompareTo(this.handCards[i]) < 0)
                    {
                        strongestCard = this.handCards[i];
                    }
                }

                return strongestCard;
            }
            else
            {
                throw new ArgumentException("There are no cards in hand of player.");
            }

        }
        public int CompareTo(Player other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }
            else if (ReferenceEquals(null, other))
            {
                return 1;
            }
            else
            {
                var result = this.FindStrongestCard().CompareTo(other.FindStrongestCard());
                return result;
            }
        }
    }
}
