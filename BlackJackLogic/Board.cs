using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLogic
{
    public class Board
    {
        private readonly Card[] Cards = new Card[10];

        public Card this[int index]
        {
            get { return Cards[index]; }
            set { Cards[index] = value; }
        }

        public static Board Initial()
        {
            Board board = new Board();
            board[1] = new Five_Card(CardSymbol.Diamond);
            return board;
        }

    }
}
