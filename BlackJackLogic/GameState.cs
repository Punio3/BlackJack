using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLogic
{
    public class GameState
    {
        public Board PlayerBoard { get; }
        public Board KrupierBoard { get; }
        private readonly List<Card> AllCards = new List<Card>();

        public GameState(Board playerboard, Board krupierboard)
        {
            PlayerBoard = playerboard;
            KrupierBoard = krupierboard;

            AddAllCards();
        }

        private void AddAllCards()
        {
            AllCards.Add(new Queen_Card(CardSymbol.Spade));
            AllCards.Add(new Queen_Card(CardSymbol.Club));
            AllCards.Add(new Queen_Card(CardSymbol.Diamond));
            AllCards.Add(new Queen_Card(CardSymbol.Heart));

            AllCards.Add(new Ass_Card(CardSymbol.Spade));
            AllCards.Add(new Ass_Card(CardSymbol.Club));
            AllCards.Add(new Ass_Card(CardSymbol.Diamond));
            AllCards.Add(new Ass_Card(CardSymbol.Heart));

            AllCards.Add(new Eight_Card(CardSymbol.Spade));
            AllCards.Add(new Eight_Card(CardSymbol.Club));
            AllCards.Add(new Eight_Card(CardSymbol.Diamond));
            AllCards.Add(new Eight_Card(CardSymbol.Heart));

            AllCards.Add(new Five_Card(CardSymbol.Spade));
            AllCards.Add(new Five_Card(CardSymbol.Club));
            AllCards.Add(new Five_Card(CardSymbol.Diamond));
            AllCards.Add(new Five_Card(CardSymbol.Heart));

            AllCards.Add(new Four_Card(CardSymbol.Spade));
            AllCards.Add(new Four_Card(CardSymbol.Club));
            AllCards.Add(new Four_Card(CardSymbol.Diamond));
            AllCards.Add(new Four_Card(CardSymbol.Heart));

            AllCards.Add(new Jopek_Card(CardSymbol.Spade));
            AllCards.Add(new Jopek_Card(CardSymbol.Club));
            AllCards.Add(new Jopek_Card(CardSymbol.Diamond));
            AllCards.Add(new Jopek_Card(CardSymbol.Heart));

            AllCards.Add(new King_Card(CardSymbol.Spade));
            AllCards.Add(new King_Card(CardSymbol.Club));
            AllCards.Add(new King_Card(CardSymbol.Diamond));
            AllCards.Add(new King_Card(CardSymbol.Heart));

            AllCards.Add(new Nine_Card(CardSymbol.Spade));
            AllCards.Add(new Nine_Card(CardSymbol.Club));
            AllCards.Add(new Nine_Card(CardSymbol.Diamond));
            AllCards.Add(new Nine_Card(CardSymbol.Heart));

            AllCards.Add(new Seven_Card(CardSymbol.Spade));
            AllCards.Add(new Seven_Card(CardSymbol.Club));
            AllCards.Add(new Seven_Card(CardSymbol.Diamond));
            AllCards.Add(new Seven_Card(CardSymbol.Heart));

            AllCards.Add(new Six_Card(CardSymbol.Spade));
            AllCards.Add(new Six_Card(CardSymbol.Club));
            AllCards.Add(new Six_Card(CardSymbol.Diamond));
            AllCards.Add(new Six_Card(CardSymbol.Heart));

            AllCards.Add(new Ten_Card(CardSymbol.Spade));
            AllCards.Add(new Ten_Card(CardSymbol.Club));
            AllCards.Add(new Ten_Card(CardSymbol.Diamond));
            AllCards.Add(new Ten_Card(CardSymbol.Heart));

            AllCards.Add(new Three_Card(CardSymbol.Spade));
            AllCards.Add(new Three_Card(CardSymbol.Club));
            AllCards.Add(new Three_Card(CardSymbol.Diamond));
            AllCards.Add(new Three_Card(CardSymbol.Heart));

            AllCards.Add(new Two_Card(CardSymbol.Spade));
            AllCards.Add(new Two_Card(CardSymbol.Club));
            AllCards.Add(new Two_Card(CardSymbol.Diamond));
            AllCards.Add(new Two_Card(CardSymbol.Heart));
        }
    }
}
