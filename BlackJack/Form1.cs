using System;
using System.Drawing;
using System.Windows.Forms;
using BlackJack.Class;

namespace BlackJack
{
    public partial class Form1 : Form
    {
        private Game game;
        private Label lblPlayerScore;
        private Label lblDealerScore;
        private PictureBox playerIcon;
        private PictureBox dealerIcon;
        private Label lblPlayerBalance;
        private TextBox txtBetAmount;
        private Button btnBet;
        private Label lblBetAmount;
        private Button btnDealCards;
        private Label deckCount;
        private Panel playerPanel;
        private Panel dealerPanel;
        private Button btnDrawCard;
        private Button btnResetCards;
        private Button btnDoubleBet;
        private Button btnStand;
        private Button btnAddBalance;
        private TextBox txtAddBalance;
        private Button btnAddDeck; 

        public Form1()
        {
            InitializeComponent();
            game = new Game();
            game.DealerDrewCard += Game_DealerDrewCard; 
            game.ResetCards += Game_ResetCards; 

            
            btnAddBalance = new Button
            {
                Text = "Добавить баланс",
                Size = new Size(100, 30) 
            };
            btnAddBalance.Location = new Point(ClientSize.Width - btnAddBalance.Width - 10, 10); 


            btnAddBalance.Click += BtnAddBalance_Click; 

            Controls.Add(btnAddBalance); 

            
            txtAddBalance = new TextBox
            {
                Size = new Size(100, 30) 
            };
            txtAddBalance.Location = new Point(btnAddBalance.Location.X, btnAddBalance.Location.Y + btnAddBalance.Height + 10); 


            Controls.Add(txtAddBalance); 
            

           
            playerIcon = new PictureBox();
            playerIcon.Image = Image.FromFile("Media/player.jpg");
            playerIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            playerIcon.Size = new Size(100, 100);
            playerIcon.Visible = false;


            playerIcon.Location = new Point((ClientSize.Width - playerIcon.Width) / 2, ClientSize.Height - playerIcon.Height);

           
            Controls.Add(playerIcon);

           
            lblPlayerScore = new Label();
            lblPlayerScore.Text = "Счёт игрока: 0"; 
            lblPlayerScore.Visible = false; 

            
            lblPlayerScore.Location = new Point(playerIcon.Location.X + playerIcon.Width + 10, playerIcon.Location.Y);

           
            Controls.Add(lblPlayerScore);

            
            dealerIcon = new PictureBox();
            dealerIcon.Image = Image.FromFile("Media/dealer.png");
            dealerIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            dealerIcon.Size = new Size(100, 100);
            dealerIcon.Visible = false;
            
            dealerIcon.Location = new Point((ClientSize.Width - dealerIcon.Width) / 2, 0);
            
            Controls.Add(dealerIcon);
            

            lblDealerScore = new Label();
            lblDealerScore.Text = "Счёт дилера: 0"; 
            lblDealerScore.Visible = false; 


            lblDealerScore.Location = new Point(dealerIcon.Location.X + dealerIcon.Width + 10, dealerIcon.Location.Y);


            Controls.Add(lblDealerScore);

            lblPlayerBalance = new Label();
            lblPlayerBalance.Text = "Баланс: 1000"; 
            lblPlayerBalance.Location = new Point(10, 10); 
            Controls.Add(lblPlayerBalance);
            int cardsInDeck = game.deck.Count;

            deckCount = new Label();
            deckCount.Location = new Point(10, lblPlayerBalance.Location.Y + lblPlayerBalance.Height + 10); 
            deckCount.Text = "Карт: " + cardsInDeck.ToString(); 
            deckCount.Visible = false; 
            
            btnDealCards.Enabled = false; 

            
            btnDrawCard = new Button
            {
                Text = "Добрать карту",
                Location = new Point(10, 600), 
                Size = new Size(100, 30) 
            };

            btnDrawCard.Click += BtnDrawCard_Click; 

            Controls.Add(btnDrawCard); 

            
            Controls.Add(deckCount);
            
            playerPanel = new Panel
            {
                Location = new Point(10, playerIcon.Location.Y - 320), 
                Size = new Size(this.ClientSize.Width - 20, 300), 
                AutoScroll = true 
            };
            Controls.Add(playerPanel); 

            
            dealerPanel = new Panel
            {
                Location = new Point(10, dealerIcon.Location.Y + dealerIcon.Height + 5), 
                Size = new Size(this.ClientSize.Width - 20, 300), 
                AutoScroll = true 
            };
            Controls.Add(dealerPanel); 
            btnDrawCard.Visible = false; 
            
            
            btnResetCards = new Button
            {
                Text = "Сбросить карты",
                Location = new Point(btnDrawCard.Location.X + btnDrawCard.Width + 10, btnDrawCard.Location.Y), 
                Size = new Size(100, 30), 
                Enabled = false,
                Visible = false 

            };

            btnResetCards.Click += BtnResetCards_Click; 

            Controls.Add(btnResetCards); 
            
            btnDoubleBet = new Button
            {
                Text = "Удвоить ставку",
                Location = new Point(btnResetCards.Location.X + btnResetCards.Width + 10, btnResetCards.Location.Y), 
                Size = new Size(100, 30), 
                Enabled = false, 
                Visible = false 
            };
            
            btnDoubleBet.Click += BtnDoubleBet_Click; 

            Controls.Add(btnDoubleBet); 
            
            btnStand = new Button
            {
                Text = "Остаться",
                Location = new Point(btnDoubleBet.Location.X + btnDoubleBet.Width + 10, btnDoubleBet.Location.Y), 
                Size = new Size(100, 30),  
                Enabled = false, 
                Visible = false  
            };
            
            btnStand.Click += BtnStand_Click;  

            Controls.Add(btnStand);  
            
            btnAddDeck = new Button
            {
                Text = "+Колода",
                Size = new Size(100, 30),
                Visible = false
            };
            btnAddDeck.Location = new Point(this.ClientSize.Width - btnAddDeck.Width - 10, this.ClientSize.Height - btnAddDeck.Height - 10);  


            btnAddDeck.Click += BtnAddDeck_Click;  

            Controls.Add(btnAddDeck);  

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            game.Start();
            lblDealerScore.Visible = true;  
            lblPlayerScore.Visible = true;  
            playerIcon.Visible = true;  
            dealerIcon.Visible = true;  
            btnBet.Visible = true;
            txtBetAmount.Visible = true;
            btnDealCards.Visible = true;
            deckCount.Visible = true;
            btnDrawCard.Visible = true;  
            btnDrawCard.Enabled = false;  
            btnResetCards.Visible = true;  
            btnDoubleBet.Visible = true;  
            btnStand.Visible = true;  
            btnAddBalance.Visible = false;  
            txtAddBalance.Visible = false;
            btnAddDeck.Visible = true;


            
            Button btnStart = sender as Button;
            if (btnStart != null)
            {
                btnStart.Visible = false;
            }
            
            UpdateUI();
        }
        
        private void BtnStand_Click(object sender, EventArgs e)
        {
             
            game.DealerTurn();

             
            DisplayHand(game.Dealer.Hand, dealerPanel);
            btnDrawCard.Enabled = false;  
            btnResetCards.Enabled = false;  
            btnDoubleBet.Enabled = false;  
            btnStand.Enabled = false;  
            btnBet.Enabled = true;  

             
            UpdateUI();
        }
        
        private void BtnDoubleBet_Click(object sender, EventArgs e)
        {
             
            if (game.Player.Balance >= game.Player.Bet * 2)
            {
                 
                game.Player.Bet *= 2;

                 
                lblBetAmount.Text = "Ставка: " + game.Player.Bet.ToString();

                 
                UpdateUI();
                game.Player.Hand.AddCard(game.deck.DrawCard());
                DisplayHand(game.Player.Hand, playerPanel);
                UpdateUI();
            
                if (game.Player.Hand.CalculateScore() > 21)
                {
                     
                    MessageBox.Show("Перебор");

                     
                    game.Player.AdjustBalance(game.Player.Bet);
                    game.Player.Bet = 0;

                     
                    game.Player.Hand.Cards.Clear();
                    game.Dealer.Hand.Cards.Clear();
                    DisplayHand(game.Dealer.Hand, dealerPanel);
                    btnBet.Enabled = true;
                    btnDrawCard.Enabled = false;  
                    btnResetCards.Enabled = false;  
                    btnDoubleBet.Enabled = false;  
                    btnStand.Enabled = false;  
                
                }
                else
                {
                    game.DealerTurn();

                     
                    DisplayHand(game.Dealer.Hand, dealerPanel);
                    btnDrawCard.Enabled = false;  
                    btnResetCards.Enabled = false;  
                    btnDoubleBet.Enabled = false;  
                    btnStand.Enabled = false;  
                    btnBet.Enabled = true;  
                }
            }
            else
            {
                 
                MessageBox.Show("Недостаточно средств для удвоения ставки");
            }
        }
        
        private void BtnResetCards_Click(object sender, EventArgs e)
        {
             
            game.Player.Hand.Cards.Clear();

             
            game.Dealer.Hand.Cards.Clear();

             
            game.Player.AdjustBalance(-(game.Player.Bet)/2);
            game.Player.Bet = 0;

             
            DisplayHand(game.Player.Hand, playerPanel);

             
            DisplayHand(game.Dealer.Hand, dealerPanel);
            
            btnBet.Enabled = true;
            btnDrawCard.Enabled = false;  
            btnResetCards.Enabled = false;  
            btnDoubleBet.Enabled = false;  
            btnStand.Enabled = false;  

             
            UpdateUI();
        }
        
        private void btnBet_Click(object sender, EventArgs e)
        {
             
            int betAmount;
            if (int.TryParse(txtBetAmount.Text, out betAmount))
            {
                 
                if (betAmount <= game.Player.Balance)
                {
                     
                    game.Player.Bet = betAmount;  
                    btnDealCards.Enabled = true;  
                    lblBetAmount.Text = "Ставка:" + betAmount.ToString();  
                    lblBetAmount.Location = new Point(lblPlayerScore.Location.X, lblPlayerScore.Location.Y + lblPlayerScore.Height + 10); 
                    lblBetAmount.Visible = true;  
                    UpdateUI();  
                    btnBet.Enabled = false;
                }
                else
                {
                     
                    MessageBox.Show("Ставка не может превышать текущий баланс");
                }
            }
            else
            {
                 
                MessageBox.Show("Введите корректное значение ставки");
            }
        }
        
        private void DisplayHand(Hand hand, Panel panel)
        {
             
            panel.Controls.Clear();

             
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                Card card = hand.Cards[i];

                 
                PictureBox pictureBox = new PictureBox
                {
                    Width = 200,   
                    Height = 300,
                    Image = card.GetImage(),   
                    SizeMode = PictureBoxSizeMode.StretchImage,   
                    Location = new Point(i * 140, 0)   
                };

                 
                panel.Controls.Add(pictureBox);
            }
        }

        private void BtnDrawCard_Click(object sender, EventArgs e)
        {
             
            game.Player.Hand.AddCard(game.deck.DrawCard());
            DisplayHand(game.Player.Hand, playerPanel);
            UpdateUI();


            
            if (game.Player.Hand.CalculateScore() > 21)
            {
                 
                MessageBox.Show("Перебор");

                 
                game.Player.AdjustBalance(-game.Player.Bet);
                game.Player.Bet = 0;

                 
                game.Player.Hand.Cards.Clear();
                game.Dealer.Hand.Cards.Clear();
                DisplayHand(game.Dealer.Hand, dealerPanel);
                btnBet.Enabled = true;
                btnDrawCard.Enabled = false;  
                btnResetCards.Enabled = false;  
                btnDoubleBet.Enabled = false;  
                btnStand.Enabled = false;  
                DisplayHand(game.Player.Hand, playerPanel);
                UpdateUI();

                
            }
             
        }

        private void Game_DealerDrewCard(Card card)
        {
             
            DisplayHand(game.Dealer.Hand, dealerPanel);
            UpdateUI();
        }
        
        private void btnDealCards_Click(object sender, EventArgs e)
        {
            game.DealCardsToPlayer();
            game.DealCardsToDealer();
            DisplayHand(game.Player.Hand, playerPanel);
            DisplayHand(game.Dealer.Hand, dealerPanel);
            btnDrawCard.Enabled = true;  
            btnResetCards.Enabled = true;  
            btnDoubleBet.Enabled = true;  
            btnStand.Enabled = true; 



            

             
            UpdateUI();
            
            btnDealCards.Enabled = false;

        }
        private void Game_ResetCards()
        {
             
            game.Player.Hand.Cards.Clear();

             
            game.Dealer.Hand.Cards.Clear();

             
            DisplayHand(game.Player.Hand, playerPanel);

             
            DisplayHand(game.Dealer.Hand, dealerPanel);

             
            UpdateUI();
        }
        
        private void BtnAddBalance_Click(object sender, EventArgs e)
        {
             
            int addAmount;
            if (int.TryParse(txtAddBalance.Text, out addAmount))
            {
                 
                game.Player.AdjustBalance(addAmount);

                 
                lblPlayerBalance.Text = "Баланс: " + game.Player.Balance.ToString();

                 
                txtAddBalance.Text = "";
            }
            else
            {
                 
                MessageBox.Show("Введите корректное значение суммы");
            }
        }
        private void BtnAddDeck_Click(object sender, EventArgs e)
        {
             
            game.deck.AddNewDeck();

             
            deckCount.Text = "Карт: " + game.deck.Count.ToString();
        }

        private void UpdateUI()
        {
             
             
            lblPlayerScore.Text = "Счёт игрока: " + game.Player.Hand.CalculateScore().ToString();
            lblDealerScore.Text = "Счёт дилера: " + game.Dealer.Hand.CalculateScore().ToString();
            lblPlayerBalance.Text = "Баланс: " + game.Player.Balance.ToString();
            deckCount.Text = "Карт: " + game.deck.Count.ToString();  
            if (game.Player.Balance == 0)
            {
                btnAddBalance.Visible = true;
                txtAddBalance.Visible = true;
            }
 

        }
    }
}
