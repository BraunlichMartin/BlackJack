using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CardClasses;

namespace BlackJack
{
    public partial class boardFormSimple : Form
    {
        #region Instance Variables
        private BJHand playerHand;
        private BJHand dealerHand;

        private List<PictureBox> playerpb;
        private List<PictureBox> dealerpb;

        private Deck deck = new Deck();

        //keep track of how many cards a player has drawn-MWB_4/29/2019
        private int playerNextDrawIndex = 0;
        private int dealerNextDrawIndex = 0;


        //keep track of who's turn it is; will either be "player" or "dealer"-MWB_4/29/2019
        //private string turn = "player";

        #endregion

        public boardFormSimple()
        {
            InitializeComponent();
        }

        #region Methods
        public void Show(PictureBox p, Card c)
        {
            p.Image = Image.FromFile(System.Environment.CurrentDirectory
                + "\\Cards\\" + c.FileName);
        }

        public void ShowBack(PictureBox p, Card c)
        {
            p.Image = Image.FromFile(System.Environment.CurrentDirectory
                + "\\Cards\\black_back.jpg");
        }
        #endregion

        private void frmBoard_Load(object sender, EventArgs e)
        {
           // MessageBox.Show("I got to here");
            hitButton.Enabled = true;
            standButton.Enabled = true;
            playerWinLabel.Visible = false;
            dealerWinLabel.Visible = false;
            playAgainButton.Enabled = false;
            //shuffle the deck and give both the player and the dealer two cards-MWB_4/29/2019
            deck.Shuffle();
            playerHand = new BJHand(deck, 2);
            dealerHand = new BJHand(deck, 2);

            playerpb = new List<PictureBox> { card1, card2, card3, card4, card5 };
            dealerpb = new List<PictureBox> { card16, card17, card18, card19, card20 };

            //show faces of first two cards and backs of remaining cards immediately -MWB_4/29/2019
            Show(playerpb[0], playerHand[0]);
            Show(playerpb[1], playerHand[1]);
            ShowBack(playerpb[2], playerHand[0]);
            ShowBack(playerpb[3], playerHand[0]);
            ShowBack(playerpb[4], playerHand[0]);
            //next card should be the third card which is called position 2-MWB_4/29/2019
            playerNextDrawIndex = 2;
            //the dealer gets some cards too-MWB_4/29/2019
            Show(dealerpb[0], dealerHand[0]);
            Show(dealerpb[1], dealerHand[1]);
            ShowBack(dealerpb[2], dealerHand[0]);
            ShowBack(dealerpb[3], dealerHand[0]);
            ShowBack(dealerpb[4], dealerHand[0]);
            //next card should be the third card which is called position 2-MWB_4/29/2019
            dealerNextDrawIndex = 2;
        }
        /**/
        //need to create picturebox's for the user's hand; from "PlayMTDRightClick.cs"-MWB_4/26/2019
        private PictureBox CreatePlayerHandPb(int index)
        {
            PictureBox pb = new PictureBox();
            pb.Visible = true;
            pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pb.Location = new System.Drawing.Point(24 + (index % 5) * 90, 366 + (index / 5) * 60);
            pb.Size = new System.Drawing.Size(100, 50);
            pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Controls.Add(pb);
            return pb;
        }
        
        private void hitButton_Click(object sender, EventArgs e)
        {
            /*
            first time the player clicks the "Hit" button they should be dealt 2 cards, thereafter only 1 card.  after each deal should
            check to see if the player is busted.  
            -MWB_4/28/2019
            */
            //Show(playerpb[0], playerHand[0]);
            if(playerNextDrawIndex < 5)
            {
                Card c1 = deck.Deal();
                playerHand.AddCard(c1);
                //Show(playerpb[playerHand.NumCards+1], c1);

                //if there is an ace and the score is greater than 21 ace is worth one
                //if playerHand.HasAce() = true;

                Show(playerpb[playerNextDrawIndex], c1);
                playerNextDrawIndex += 1;
            }
            else
            {
                MessageBox.Show("no more cards for player");
            }

            //check score
            //MessageBox.Show(playerHand.ToString());
            //MessageBox.Show(playerHand.NumCards.ToString());
            if (playerHand.Score > 21)
            {
                MessageBox.Show("player is busted");
                playAgainButton.Enabled = true;
            }
            
        }

        private void standButton_Click(object sender, EventArgs e)
        {
            //player is done switch to computer player or vice versa-MWB_4/29/2019
            //turn = "dealer";
            

            if (dealerHand.Score < 12)
            {
                Card c1 = deck.Deal();
                dealerHand.AddCard(c1);

                Show(dealerpb[dealerNextDrawIndex], c1);
                dealerNextDrawIndex += 1;
            }
            else
            {
                MessageBox.Show("no more cards for dealer");
            }

            if(dealerHand.Score > 21)
            {
                MessageBox.Show("dealer is busted");
                playAgainButton.Enabled = true;
            }
            
        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            //reset values;-MWB_4/29/2019
            //Deck deck = this.deck();
            //MessageBox.Show("you clicked the play again button");
            deck = new Deck();
            deck.Shuffle();
            playerHand = new BJHand(deck, 2);
            dealerHand = new BJHand(deck, 2);


            //show faces of first two cards and backs of remaining cards immediately -MWB_4/29/2019
            Show(playerpb[0], playerHand[0]);
            Show(playerpb[1], playerHand[1]);
            ShowBack(playerpb[2], playerHand[0]);
            ShowBack(playerpb[3], playerHand[0]);
            ShowBack(playerpb[4], playerHand[0]);
            //next card should be the third card which is called position 2-MWB_4/29/2019
            playerNextDrawIndex = 2;
            //the dealer gets some cards too-MWB_4/29/2019
            Show(dealerpb[0], dealerHand[0]);
            Show(dealerpb[1], dealerHand[1]);
            ShowBack(dealerpb[2], dealerHand[0]);
            ShowBack(dealerpb[3], dealerHand[0]);
            ShowBack(dealerpb[4], dealerHand[0]);
            //next card should be the third card which is called position 2-MWB_4/29/2019
            dealerNextDrawIndex = 2;


            playAgainButton.Enabled = false;
        }

        
    }
}
