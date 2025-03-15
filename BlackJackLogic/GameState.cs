using BlackJackLogic;
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

        private List<Card> AllCards;
        private PlayerType _PlayerType { get; set; }
        public float PlayerMoney { get; set; }
        public bool IsGameEnded { get; set; }
        public bool CanBet {  get; set; }
        public List<Course> Courses { get; set; }

        public BetCounter _BetCounter { get; set; }


        public GameState(Board playerboard, Board krupierboard,bool SetCards, bool SetBetCounter)
        {
            PlayerBoard = playerboard;
            KrupierBoard = krupierboard;
            _BetCounter = new BetCounter(SetBetCounter);
            Courses= new List<Course>();
            _PlayerType = PlayerType.Gracz;
            PlayerMoney = 100;
            IsGameEnded = false;
            CanBet = false;

            if (SetCards)
            {
                AllCards = new List<Card>();
                AddAllCards();
            }
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
            Courses.Add(new Course());//0
            Courses.Add(new Course());//1
            Courses.Add(new Course());//2
            Courses.Add(new Course());//3
            Courses.Add(new Course());//4
            Courses.Add(new Course());//5
            Courses.Add(new Course());//6
            Courses.Add(new Course());//7
            Courses.Add(new Course());//8
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

        public bool CheckCanBet(float money)
        {
            if (money < PlayerMoney) return true;
            return false;
        }
        public void AddCard()
        {
            Random random = new Random();
            int RandomNumber = random.Next(AllCards.Count);
            Card card = AllCards[RandomNumber];
            AllCards.RemoveAt(RandomNumber);

            if (_PlayerType == PlayerType.Gracz)
            {
                PlayerBoard.AddCard(card);
                _BetCounter.DeleteCard(card);
            }
            else
            {
                KrupierBoard.AddCard(card);
                _BetCounter.DeleteCard(card);
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
                }
                Courses[i].PlayerBet = 0;
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

            PlayerBoard.AmountOfPoints = 0;
            KrupierBoard.AmountOfPoints = 0;
            PlayerBoard.isAssModifier = false;
            KrupierBoard.isAssModifier = false;
            _PlayerType= PlayerType.Gracz;
            CheckWonCourses();
            IsGameEnded = false;
            _BetCounter = new BetCounter(true);
        }

        public void ActualizeCourses()
        {
            _BetCounter.CalculateCoursesValues(this);
            for(int i=0; i<Courses.Count;i++)
            {
                Courses[i]._CourseValue =(float)( 1 / (_BetCounter.CoursesValues[i] / (float)_BetCounter.AllVariants));
            }
        }

        public GameState CopyGameState()
        {
            Board _PlayerCopy = PlayerBoard.Copy();
            Board _Dealer = KrupierBoard.Copy();

            GameState gamestate = new GameState(_PlayerCopy, _Dealer,false,false);
            gamestate._PlayerType = _PlayerType;
            gamestate.IsGameEnded = IsGameEnded;
            gamestate._BetCounter = _BetCounter.Copy(this);
            return gamestate;
        }

        public void AddSpecificCard(int Index)
        {
            if (_PlayerType == PlayerType.Gracz)
            {
                if (Index == 0) PlayerBoard.AddCard(new Two_Card(CardSymbol.Spade));
                else if (Index == 1) PlayerBoard.AddCard(new Three_Card(CardSymbol.Spade));
                else if (Index == 2) PlayerBoard.AddCard(new Four_Card(CardSymbol.Spade));
                else if (Index == 3) PlayerBoard.AddCard(new Five_Card(CardSymbol.Spade));
                else if (Index == 4) PlayerBoard.AddCard(new Six_Card(CardSymbol.Spade));
                else if (Index == 5) PlayerBoard.AddCard(new Seven_Card(CardSymbol.Spade));
                else if (Index == 6) PlayerBoard.AddCard(new Eight_Card(CardSymbol.Spade));
                else if (Index == 7) PlayerBoard.AddCard(new Nine_Card(CardSymbol.Spade));
                else if (Index == 8) PlayerBoard.AddCard(new Ten_Card(CardSymbol.Spade));
                else if (Index == 9) PlayerBoard.AddCard(new Queen_Card(CardSymbol.Spade));
                else if (Index == 10) PlayerBoard.AddCard(new Jopek_Card(CardSymbol.Spade));
                else if (Index == 11) PlayerBoard.AddCard(new King_Card(CardSymbol.Spade));
                else if (Index == 12) PlayerBoard.AddCard(new Ass_Card(CardSymbol.Spade));
            }
            else
            {
                if (Index == 0) KrupierBoard.AddCard(new Two_Card(CardSymbol.Spade));
                else if (Index == 1) KrupierBoard.AddCard(new Three_Card(CardSymbol.Spade));
                else if (Index == 2) KrupierBoard.AddCard(new Four_Card(CardSymbol.Spade));
                else if (Index == 3) KrupierBoard.AddCard(new Five_Card(CardSymbol.Spade));
                else if (Index == 4) KrupierBoard.AddCard(new Six_Card(CardSymbol.Spade));
                else if (Index == 5) KrupierBoard.AddCard(new Seven_Card(CardSymbol.Spade));
                else if (Index == 6) KrupierBoard.AddCard(new Eight_Card(CardSymbol.Spade));
                else if (Index == 7) KrupierBoard.AddCard(new Nine_Card(CardSymbol.Spade));
                else if (Index == 8) KrupierBoard.AddCard(new Ten_Card(CardSymbol.Spade));
                else if (Index == 9) KrupierBoard.AddCard(new Queen_Card(CardSymbol.Spade));
                else if (Index == 10) KrupierBoard.AddCard(new Jopek_Card(CardSymbol.Spade));
                else if (Index == 11) KrupierBoard.AddCard(new King_Card(CardSymbol.Spade));
                else if (Index == 12) KrupierBoard.AddCard(new Ass_Card(CardSymbol.Spade));
            }
        }

    }
}


