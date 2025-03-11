using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLogic
{
    public class Board
    {
        private readonly Card[] Cards = new Card[10];
        private int Size;
        public int AmountOfCards;
        public int AmountOfPoints;

        public Card this[int index]
        {
            get { return Cards[index]; }
            set { Cards[index] = value; }
        }

        public static Board Initial()
        {
            Board board = new Board();
            board.Size = 10;
            board.AmountOfCards = 0;
            board.AmountOfPoints = 0;
            return board;
        }

        public void AddCard(Card card)
        {
            if (AmountOfCards < Size)
            {
                Cards[AmountOfCards] = card;
                AmountOfCards++;
                AmountOfPoints += card.Value;
            }
        }
    }
}
