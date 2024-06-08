using System.Collections.Generic;
using System;

namespace BlackJack.Class
{
    public class Deck
    {
        public List<Card> cards;
        private Random random = new Random();

        
        public int Count 
        {
            get { return cards.Count; }
        }

        public Deck()
        {
            cards = new List<Card>();
            Initialize();
        }
        
        public void AddNewDeck()
        {
            Initialize();
        }

        private void Initialize()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                for (int i = 1; i <= 13; i++)
                {
                    cards.Add(new Card { Suit = suit, Value = i });
                }
            }
        }

        public void Shuffle()
        {
            int n = cards.Count;
            for (int i = 0; i < n; i++)
            {
                int r = i + random.Next(n - i);
                Card temp = cards[r];
                cards[r] = cards[i];
                cards[i] = temp;
            }
        }

        public Card DrawCard() 
        {
            var card = cards.First();
            cards.RemoveAt(0);
            return card;
        }
    }
}