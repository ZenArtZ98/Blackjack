namespace BlackJack.Class
{
    public class Player
    {
        public Hand Hand { get; private set; }
        public int Balance { get; set; } 
        public int Bet { get; set; } 

        public Player()
        {
            Hand = new Hand();
            Balance = 1000; 
            Bet = 0; 
        }

        public void AdjustBalance(int amount)
        {
            Balance += amount;
        }
    }
}