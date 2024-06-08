namespace BlackJack.Class
{
    public class Game
    {
        public Player Player { get; set; }
        public Dealer Dealer { get; set; }
        
        public Deck deck; 
        public event Action<Card> DealerDrewCard;
        public event Action ResetCards;



        public Game()
        {
            Player = new Player();
            Dealer = new Dealer();
            deck = new Deck(); 

        }
        
        public void DealCardsToPlayer()
        {
            Player.Hand.AddCard(deck.DrawCard());
            Player.Hand.AddCard(deck.DrawCard());
        }
        
        public void DealCardsToDealer()
        {
            Dealer.Hand.AddCard(deck.DrawCard());
            Dealer.Hand.AddCard(deck.DrawCard());
        }
        
        public void Start()
        {
            deck.Shuffle(); 

        }

        public void DealerTurn()
        {
            while (Dealer.Hand.CalculateScore() < 17)
            {
                Card newCard = deck.DrawCard();
                Dealer.Hand.AddCard(newCard);
                DealerDrewCard?.Invoke(newCard); 

            }
            
            if (Dealer.Hand.CalculateScore() > 21)
            {
                Player.AdjustBalance(Player.Bet); 
                MessageBox.Show("Дилер проиграл. Вы выиграли ставку!");
                ResetCards?.Invoke(); 
            } 
            else if (Player.Hand.CalculateScore() > Dealer.Hand.CalculateScore())
            {
                Player.AdjustBalance(Player.Bet); 
                MessageBox.Show("Вы выиграли ставку!");
                ResetCards?.Invoke(); 

            }
            else if (Player.Hand.CalculateScore() == Dealer.Hand.CalculateScore())
            {
                MessageBox.Show("Ничья!");
                ResetCards?.Invoke(); 

            }
            else
            {
                Player.AdjustBalance(-Player.Bet); 
                MessageBox.Show("Вы проиграли ставку!");
                ResetCards?.Invoke(); 

            }
            {
                
            }
        }
    }
}