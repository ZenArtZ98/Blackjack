namespace BlackJack.Class
{
    public class Dealer
    {
        public Hand Hand { get; private set; }

        public Dealer()
        {
            Hand = new Hand();
        }

        public int CalculateScore()
        {
            return Hand.CalculateScore();
        }
    }
}