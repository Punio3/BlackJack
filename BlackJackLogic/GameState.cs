
namespace BlackJackLogic
{
    public class GameState
    {
        public Board PlayerBoard { get; }
        public Board DealerBoard { get; }

        private List<Card> AllCards;
        private PlayerType _PlayerType { get; set; }
        public float PlayerMoney { get; set; }
        public bool IsGameEnded { get; set; }
        public bool CanBet {  get; set; }
        public Course[] Courses { get; set; }
        private Database _DataBase {  get; set; }


        public GameState(Board playerboard, Board dealerboard)
        {
            PlayerBoard = playerboard;
            DealerBoard = dealerboard;
            Courses = new Course[9];
            _PlayerType = PlayerType.Player;
            PlayerMoney = 100;
            IsGameEnded = false;
            CanBet = false;
            AllCards = new List<Card>();
            AddAllCards();
            SetCoursesValues();
            _DataBase=new Database();

            _DataBase.Initialize();
        }
        private void SetCoursesValues()
        {
            for (int i = 0; i < Courses.Length; i++)
            {
                Courses[i] = new Course();
            }

            Courses[0]._CourseValue = 3.35f;
            Courses[1]._CourseValue = 3.1f;
            Courses[2]._CourseValue = 4.13f;
            Courses[3]._CourseValue = 13f;
            Courses[4]._CourseValue = 82f;
            Courses[5]._CourseValue = 12f; //Blackjack
            Courses[6]._CourseValue = 2.3f; //Player
            Courses[7]._CourseValue = 1.93f; //Dealer
            Courses[8]._CourseValue = 10f; //Draw
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

        public void ChangePlayer_Phase1()
        {
            if (_PlayerType == PlayerType.Player)  _PlayerType = PlayerType.Dealer;         
            else  _PlayerType = PlayerType.Player;
            
        }

        public void ChangePlayer_Phase2()
        {
            if (_PlayerType == PlayerType.Player)
            {
                if (DealerBoard.AmountOfPoints > 16) _PlayerType = PlayerType.Player; 
                else if(DealerBoard.AmountOfPoints<=16 && PlayerBoard.AmountOfPoints<=16) _PlayerType = PlayerType.Player;
                else _PlayerType = PlayerType.Dealer;                
            }
            else
            {
                if (PlayerBoard.AmountOfPoints > 16) _PlayerType = PlayerType.Dealer;
                else if (DealerBoard.AmountOfPoints <= 16 && PlayerBoard.AmountOfPoints <= 16) _PlayerType = PlayerType.Dealer;
                else _PlayerType = PlayerType.Player;
            }
        }

        public void CheckWin()
        {
            if (DealerBoard.AmountOfPoints > 21) Courses[6].IsWin = true;
            else if (PlayerBoard.AmountOfPoints>21) Courses[7].IsWin = true;    
            else if(PlayerBoard.AmountOfPoints == 21 && PlayerBoard.AmountOfCards == 2 && DealerBoard.AmountOfPoints<10)
            {
                Courses[6].IsWin = true;
                Courses[5].IsWin = true;
            }
            else if (PlayerBoard.AmountOfPoints == 21 && PlayerBoard.AmountOfCards == 2 && DealerBoard.AmountOfCards>1 && DealerBoard.AmountOfPoints!=21)
            {
                Courses[6].IsWin = true;
                Courses[5].IsWin = true;
            }
            else if (DealerBoard.AmountOfPoints == 21 && DealerBoard.AmountOfCards == 2 && PlayerBoard.AmountOfPoints!=21 && PlayerBoard.AmountOfCards!=2)
            {
                Courses[7].IsWin = true;
                Courses[5].IsWin = true;
            }
            else if(PlayerBoard.AmountOfPoints>16 && DealerBoard.AmountOfPoints>16)
            {
                if (PlayerBoard.AmountOfPoints > DealerBoard.AmountOfPoints)
                {
                    Courses[6].IsWin = true;
                }
                else if (DealerBoard.AmountOfPoints > PlayerBoard.AmountOfPoints)
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
                if (DealerBoard.AmountOfCards < 6) Courses[DealerBoard.AmountOfCards - 1].IsWin = true;
            }
            AddGameToDataBase();
        }

        private void AddGameToDataBase()
        {
            string PlayerCards = "";
            for(int k=0;k<PlayerBoard.AmountOfCards-1;k++)
            {
                PlayerCards += PlayerBoard[k].CardToString();
                PlayerCards += ",";
            }
            PlayerCards += PlayerBoard[PlayerBoard.AmountOfCards -1].CardToString();

            string DealerCards = "";
            for (int k = 0; k < DealerBoard.AmountOfCards-1; k++)
            {
                DealerCards += DealerBoard[k].CardToString();
                DealerCards += ",";
            }
            DealerCards += DealerBoard[DealerBoard.AmountOfCards - 1].CardToString();

            int Sum = 0;
            for(int k=0;k<Courses.Length;k++)
            {
                Sum += Courses[k].PlayerBet; 
            }
            _DataBase.SaveGameData(PlayerCards, DealerCards, Sum);
        }

        public List<GameData> GiveAllPreviousBets()
        {
            return _DataBase.GetAllGameData();
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

            if (_PlayerType == PlayerType.Player) PlayerBoard.AddCard(card);           
            else DealerBoard.AddCard(card);
           
        }

        private void CheckWonCourses()
        {
            for(int i = 0; i < Courses.Length; i++)
            {
                if (Courses[i].IsWin)
                {
                    PlayerMoney += Courses[i].PlayerBet * Courses[i]._CourseValue;
                    PlayerMoney = (float)Math.Round(PlayerMoney, 2);
                    Courses[i].IsWin = false;
                }
                Courses[i].PlayerBet = 0;
            }
        }

        public void CreateNewGame()
        {
            while (PlayerBoard.AmountOfCards != 0)  AllCards.Add(PlayerBoard.DeleteCard());           
            while (DealerBoard.AmountOfCards != 0)  AllCards.Add(DealerBoard.DeleteCard());
            
            PlayerBoard.AmountOfPoints = 0;
            DealerBoard.AmountOfPoints = 0;
            PlayerBoard.isAssModifier = false;
            DealerBoard.isAssModifier = false;
            _PlayerType= PlayerType.Player;
            CheckWonCourses();
            IsGameEnded = false;
        }
    }
}


