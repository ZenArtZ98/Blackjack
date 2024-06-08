namespace BlackJack.Class
{
    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }
    
    public enum Value
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }
    
    

    public class Card
    {
        public Suit Suit { get; set; }
        public int Value { get; set; }
        


        public Image GetImage()
        {
            return Image.FromFile($"Media/Card/{Suit}/{Value}.png");
        }
    }
}