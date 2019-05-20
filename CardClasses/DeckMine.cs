using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardMaintClassLibrary;

namespace CardMaintClassLibrary
{
    public class Deck
    {
        private List<Card> cards; // new list of cards
        public int Count => cards.Count; // how many cards are in the deck
        public bool IsEmpty => Count == 0; // is the deck count zero


        public Deck() // create a new deck of playing cards
        {
            cards = new List<Card>();

            for (int suit = 1; suit <= 4; suit++)
            {
                for (int cardVal = 1; cardVal <= 13; cardVal++)
                {
                    cards.Add(new Card(cardVal, suit));
                }
            }
        }

        public void ShuffleDeck()
        {
            int loop = 5;  // shuffle more than once to insure a more even distribution of cards
            for (int l = 0; l <= loop; l++)
            {
                Random rand = new Random();
                for (int i = 0; i < Count; i++)
                {
                    int randindex = rand.Next(0, Count - 1);
                    Card temp = cards[randindex];
                    cards[randindex] = cards[i];
                    cards[i] = temp;
                }
            }
            loop++;


        }

        public Card DealCard()
        {
            if (IsEmpty)
            {
                return null; // no cards left in the deck
            }
            else
            {
                Card draw = cards[0];
                cards.RemoveAt(0);
                return draw;
            }
        }

        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < cards.Count; i++)
            {
                output += cards[i] + "\n";
            }
            return output;
        }

    }
}


