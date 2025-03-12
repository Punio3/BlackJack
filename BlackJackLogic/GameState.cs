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
        private PlayerType _PlayerType { get; set; }
        public float PlayerMoney { get; set; }
        public bool IsGameEnded { get; set; }

        public List<Course> Courses { get; set; }

        private BetCounter _BetCounter { get; set; }

        private Random random = new Random();


        public GameState(Board playerboard, Board krupierboard)
        {
            PlayerBoard = playerboard;
            KrupierBoard = krupierboard;
            _BetCounter = new BetCounter();
            Courses= new List<Course>();
            _PlayerType = PlayerType.Gracz;
            PlayerMoney = 100;
            IsGameEnded = false;

            AddAllCards();
            AddCourses();
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

        private void AddCourses()
        {
            Courses.Add(new Course(TypeOfWin.OneCard));//0
            Courses.Add(new Course(TypeOfWin.TwoCards));//1
            Courses.Add(new Course(TypeOfWin.ThreeCards));//2
            Courses.Add(new Course(TypeOfWin.FourCards));//3
            Courses.Add(new Course(TypeOfWin.FiveCards));//4
            Courses.Add(new Course(TypeOfWin.BlackJack));//5
            Courses.Add(new Course(TypeOfWin.PlayerWin));//6
            Courses.Add(new Course(TypeOfWin.DealerWin));//7
            Courses.Add(new Course(TypeOfWin.Draw));//8
        }

        public void ChangePlayer()
        {
            if (_PlayerType == PlayerType.Gracz)
            {
                _PlayerType = PlayerType.Krupier;
            }
            else
            {
                _PlayerType = PlayerType.Gracz;
            }
        }

        public void ChangePlayer2()
        {
            if (_PlayerType == PlayerType.Gracz)
            {
                if (KrupierBoard.AmountOfPoints > 16) _PlayerType = PlayerType.Gracz; 
                else if(KrupierBoard.AmountOfPoints<=16 && PlayerBoard.AmountOfPoints<=16) _PlayerType = PlayerType.Gracz;
                else _PlayerType = PlayerType.Krupier;                
            }
            else
            {
                if (PlayerBoard.AmountOfPoints > 16) _PlayerType = PlayerType.Krupier;
                else if (KrupierBoard.AmountOfPoints <= 16 && PlayerBoard.AmountOfPoints <= 16) _PlayerType = PlayerType.Krupier;
                else _PlayerType = PlayerType.Gracz;
            }
        }

        public void CheckWin()
        {
            if (KrupierBoard.AmountOfPoints > 21) Courses[6].IsWin = true;
            else if (PlayerBoard.AmountOfPoints>21) Courses[7].IsWin = true;    
            else if(PlayerBoard.AmountOfPoints == 21 && PlayerBoard.AmountOfCards == 2 && KrupierBoard.AmountOfPoints<10)
            {
                Courses[6].IsWin = true;
                Courses[5].IsWin = true;
            }
            else if (PlayerBoard.AmountOfPoints == 21 && PlayerBoard.AmountOfCards == 2 && KrupierBoard.AmountOfCards>1 && KrupierBoard.AmountOfPoints!=21)
            {
                Courses[6].IsWin = true;
                Courses[5].IsWin = true;
            }
            else if (KrupierBoard.AmountOfPoints == 21 && KrupierBoard.AmountOfCards == 2 && PlayerBoard.AmountOfPoints!=21 && PlayerBoard.AmountOfCards!=2)
            {
                Courses[7].IsWin = true;
                Courses[5].IsWin = true;
            }
            else if(PlayerBoard.AmountOfPoints>16 && KrupierBoard.AmountOfPoints>16)
            {
                if (PlayerBoard.AmountOfPoints > KrupierBoard.AmountOfPoints)
                {
                    Courses[6].IsWin = true;
                }
                else if (KrupierBoard.AmountOfPoints > PlayerBoard.AmountOfPoints)
                {
                    Courses[7].IsWin = true;
                }
                else Courses[8].IsWin = true;                
            }
            else
            {
                IsGameEnded = false;
                return;
            }

            IsGameEnded = true;
            if (Courses[6].IsWin)
            {
                if (PlayerBoard.AmountOfCards < 6) Courses[PlayerBoard.AmountOfCards - 1].IsWin = true;               
            }else if (Courses[7].IsWin)
            {
                if (KrupierBoard.AmountOfCards < 6) Courses[KrupierBoard.AmountOfCards - 1].IsWin = true;            
            }
        }

        public void AddCard()
        {
            int RandomNumber = random.Next(AllCards.Count);
            Card card = AllCards[RandomNumber];
            AllCards.RemoveAt(RandomNumber);

            if (_PlayerType == PlayerType.Gracz)
            {
                _BetCounter.DeleteCard(card);
                PlayerBoard.AddCard(card);
            }
            else
            {
                _BetCounter.DeleteCard(card);
                KrupierBoard.AddCard(card);
            }

        }

        private void CheckWonCourses()
        {
            for(int i=0;i<Courses.Count;i++)
            {
                if (Courses[i].IsWin)
                {
                    PlayerMoney += Courses[i].PlayerBet * Courses[i]._CourseValue;
                    Courses[i].IsWin = false;
                    Courses[i].PlayerBet = 50.0f;
                }
            }
        }
        public void CreateNewGame()
        {
            while (PlayerBoard.AmountOfCards != 0)
            {
                AllCards.Add(PlayerBoard.DeleteCard());
            }
            while (KrupierBoard.AmountOfCards != 0)
            {
                AllCards.Add(KrupierBoard.DeleteCard());
            }

            _PlayerType= PlayerType.Gracz;
            CheckWonCourses();
            IsGameEnded = false;
        }

    }
}
