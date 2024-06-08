namespace BlackJack.Class
{
    public class Hand
    {
        public List<Card> Cards { get; set; }

        public Hand()
        {
            Cards = new List<Card>();
        }
        
        public void AddCard(Card card)
        {
            Cards.Add(card);
        }

        public int CalculateScore()
        {
            int score = 0;
            int aceCount = 0;

            foreach (var card in Cards)
            {
                if (card.Value >= 2 && card.Value <= 10)
                {
                    score += card.Value;
                }
                else if (card.Value > 10)
                {
                    score += 10;
                }
                else if (card.Value == 1)
                {
                    aceCount++;
                    score += 11;
                }
            }

            while (score > 21 && aceCount > 0)
            {
                score -= 10;
                aceCount--;
            }

            return score;
        }
        
        
    }
}