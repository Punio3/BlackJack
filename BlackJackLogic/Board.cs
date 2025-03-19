
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
                        return;
                    }                         
                }
                else
                {
                    if (isAssModifier && card.Value + AmountOfPoints > 21)
                    {
                        AmountOfPoints = 11 + AmountOfPoints + card.Value - 21;
                        isAssModifier = false;
                        return;
                    }                                                                     
                }
                AmountOfPoints += card.Value;
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
    }
}
