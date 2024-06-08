namespace BlackJack;
using System.Drawing;
using System.Windows.Forms;
using BlackJack.Class;

partial class Form1
{
      
      
      
    private System.ComponentModel.IContainer components = null;

      
      
      
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

      
      
      
      
    private void InitializeComponent()
    {
        this.game = new Game();
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1280, 720);
        this.Text = "BlackJack";

          
        Button btnStart = new Button();
        btnStart.Location = new Point(10, 10);   
        btnStart.Text = "Начать игру";   
        btnStart.Click += btnStart_Click;   

        btnStart.Location = new Point((this.ClientSize.Width - btnStart.Width) / 2, (this.ClientSize.Height - btnStart.Height) / 2);

        

          
        lblPlayerScore = new Label();
        lblPlayerScore.Location = new Point(10, 50);   
        lblPlayerScore.Text = "Счёт игрока: ";   
        lblPlayerScore.Visible = false;   
        

          
        this.Controls.Add(btnStart);
        this.Controls.Add(lblPlayerScore);
        
        PictureBox playerIcon = new PictureBox();
        playerIcon.Location = new Point((this.ClientSize.Width - playerIcon.Width) / 2, this.ClientSize.Height - playerIcon.Height - 10);   
        playerIcon.Image = Image.FromFile("Media/player.jpg");   
        playerIcon.SizeMode = PictureBoxSizeMode.StretchImage;   
        playerIcon.Size = new Size(50, 50);   
        playerIcon.Visible = false;
        
        PictureBox dealerIcon = new PictureBox();
        dealerIcon.Location = new Point((this.ClientSize.Width - dealerIcon.Width) / 2, 10);   
        dealerIcon.Image = Image.FromFile("Media/dealer.png");   
        dealerIcon.SizeMode = PictureBoxSizeMode.StretchImage;   
        dealerIcon.Size = new Size(50, 50);   
        dealerIcon.Visible = false;   


          
        this.Controls.Add(playerIcon);
        this.Controls.Add(dealerIcon);
        
        
          
        btnBet = new Button();
        btnBet.Location = new Point(10, this.ClientSize.Height - btnBet.Height - 10);   
        btnBet.Text = "Ставка";   
        btnBet.Visible = false;   
        btnBet.Click += btnBet_Click;   

          
        txtBetAmount = new TextBox();
        txtBetAmount.Location = new Point(btnBet.Location.X + btnBet.Width + 10, btnBet.Location.Y);   
        txtBetAmount.Visible = false;   

          
        this.Controls.Add(btnBet);
        this.Controls.Add(txtBetAmount);
        
          
        lblBetAmount = new Label();
        lblBetAmount.Location = new Point(lblPlayerScore.Location.X, lblPlayerScore.Location.Y + lblPlayerScore.Height + 10); 
        lblBetAmount.Text = "Ставка: 0";   
        lblBetAmount.Visible = false;   

          
        this.Controls.Add(lblBetAmount);
        
          
        btnDealCards = new Button();
        btnDealCards.Location = new Point(btnBet.Location.X, btnBet.Location.Y - btnDealCards.Height - 10); 
        btnDealCards.Text = "Раздать";   
        btnDealCards.Visible = false;   
        btnDealCards.Click += btnDealCards_Click;   

          
        this.Controls.Add(btnDealCards);
        
        

    }

    #endregion
}
