using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class BJHand : Hand
    {
        //private List<Card> cards;
        //public BJHand() : base() {}

        public BJHand(Deck d, int numCards) :base(d, numCards)
        { 
        }

        //MWB_4/29/2019
        
        public Card this[int i] => cards[i];

        public int Score
        {
            get 
            {
                int score = 0;
                foreach (Card c in cards)
                {
                    if (c.IsFaceCard())
                        score += 10;
                    else
                        score += c.Value;

                    if (HasAce && score <= 11)
                        score += 10;
                }
                return score;

            }
        }

        public bool HasAce
        {
            get 
            {
                return HasCard(1);
            }
        }

        public bool IsBusted
        {
            get 
            {
                return Score > 21;
            }
        }
    }
}
