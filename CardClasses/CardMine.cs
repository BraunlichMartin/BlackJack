using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CardMaintClassLibrary
{
    public class Card
    {
        private int suit; // suit range 1 to 4
        private int cardVal; // values range 1 to 13

        private string[] suits = { "????", "Clubs", "Diamonds", "Hearts", "Spades" };
        private string[] values = { "????", "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "Ten", "Jack", "Queen", "King" };

        public Card() // Constructor for default card ace of clubs
        {
            cardVal = 1;
            suit = 1;
        }

        public Card(int v, int s) //  Constructor for card with specified value
        {
            cardVal = v;
            suit = s;
        }


        public int CardVal
        {
            get
            {
                return cardVal;
            }
            set
            {
                this.cardVal = value;
            }
        }

        public int Suit
        {
            get
            {
                return suit;
            }
            set
            {
                suit = value;
            }
        }

        public bool IsQueen()
        {
            if (cardVal == 12)
            
                return true;
            else
                return false;
        }

        // this is way easier than the if else above
        public bool IsAce() => CardVal == 1;
        public bool IsBlack() => Suit == 1 || Suit == 4;
        public bool IsRed() => Suit == 2 || Suit == 3;
        public bool IsClub() => Suit == 1;
        public bool IsDiamond() => Suit == 2;
        public bool IsHeart() => Suit == 3;
        public bool IsSpade() => Suit == 4;
        public bool IsFaceCard() => CardVal > 10;

        
        public override string ToString()
        {
            
            return values[cardVal] + " of " + suits[suit];
        }
      
    }
}
