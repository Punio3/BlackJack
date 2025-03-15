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
        public bool isAssModifier;

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
            board.isAssModifier = false;
            return board;
        }

        public void AddCard(Card card)
        {
            if (AmountOfCards < Size)
            {
                Cards[AmountOfCards] = card;
                AmountOfCards++;
                if (card.Type == CardType.Ass)
                {
                    isAssModifier = true;
                    if (card.Value + AmountOfPoints > 21)
                    {
                        AmountOfPoints += 1;
                    }
                    else
                    {
                        AmountOfPoints += card.Value;
                    }
                }
                else
                {
                    if (isAssModifier)
                    {
                        if (card.Value + AmountOfPoints > 21)
                        {
                            AmountOfPoints = 11 + AmountOfPoints + card.Value - 21;
                            isAssModifier = false;
                        }
                        else
                        {
                            AmountOfPoints += card.Value;
                        }
                    }
                    else
                    {
                        AmountOfPoints += card.Value;
                    }
                }
            }
        }

        public Card DeleteCard()
        {
            if(AmountOfCards > 0)
            {
                Card card = Cards[AmountOfCards-1];
                Cards[AmountOfCards - 1] = null;
                AmountOfCards--;
                return card;
            }
            return null;
        }

        public Card CopyCard(Card card)
        {
            switch (card.Type)
            {
                case CardType.Two:
                    return new Two_Card(card.Symbol);
                case CardType.Three:
                    return new Three_Card(card.Symbol);
                case CardType.Four:
                    return new Four_Card(card.Symbol);
                case CardType.Five:
                    return new Five_Card(card.Symbol);
                case CardType.Six:
                    return new Six_Card(card.Symbol);
                case CardType.Seven:
                    return new Seven_Card(card.Symbol);
                case CardType.Eight:
                    return new Eight_Card(card.Symbol);
                case CardType.Nine:
                    return new Nine_Card(card.Symbol);
                case CardType.Ten:
                    return new Ten_Card(card.Symbol);
                case CardType.Queen:
                    return new Queen_Card(card.Symbol);
                case CardType.King:
                    return new King_Card(card.Symbol);
                case CardType.Jopek:
                    return new Jopek_Card(card.Symbol);
                case CardType.Ass:
                    return new Ass_Card(card.Symbol);

            }
            return null;
        }

        public Board Copy()
        {
            Board copy = new Board();
            copy.Size = this.Size;
            copy.AmountOfCards = this.AmountOfCards;
            copy.AmountOfPoints = this.AmountOfPoints;
            copy.isAssModifier = this.isAssModifier;

            for (int i = 0; i < this.AmountOfCards; i++)
            {
                if (this.Cards[i] != null)
                {
                    copy.Cards[i] = CopyCard(this.Cards[i]);
                }
                else
                {
                    break;
                }
            }

            return copy;
        }
    }
}
