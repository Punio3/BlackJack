using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using BlackJackLogic;

namespace BlackJackUI
{
    /*
    a) dodac przycisk pokaz ostatnie gry
    c) zapisywanie gier do bazy i zczytywanie ich ( mozliwe nowe okno z widokiem tego )
    */
    public partial class MainWindow : Window
    {
        private readonly Image[,] PlayerCardImages = new Image[2, 5];
        private readonly Image[,] KrupierCardImages = new Image[2, 5];

        private GameState gameState;
        private GameViewModel viewModel;
        private bool StopGame;
        private bool CanStartGame;
        public MainWindow()
        {
            StopGame = false;
            CanStartGame = true;
            InitializeComponent();
            InitalizeBoard();

            viewModel = new GameViewModel();
            DataContext = viewModel;

            gameState = new GameState(Board.Initial(), Board.Initial());

            DrawBoard();
        }

        private void InitalizeBoard()
        {
            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    Image image = new Image();
                    image.Width = 50;
                    image.Height = 60;

                    PlayerCardImages[i,j] = image;
                    CardGrid_Gracz.Children.Add(image);

                    image = new Image();
                    image.Width = 50;
                    image.Height = 60;

                    KrupierCardImages[i, j] = image;
                    CardGrid_Krupier.Children.Add(image);
                }
            }
        }

        private void DrawBoard()
        {
            for(int i=0;i<10;i++) {
                Card card = gameState.PlayerBoard[i];
                Card card2= gameState.DealerBoard[i];

                PlayerCardImages[i / 5, i % 5].Source = Images.GetImage(card);
                KrupierCardImages[i / 5, i % 5].Source = Images.GetImage(card2);
            }
        }

        private async Task DelayCountdown(int seconds)
        {
            for (int j = seconds; j >= 0; j--)
            {
                viewModel.GameTimer = j;
                await Task.Delay(1000);
            }
        }

        private async void GameLoop()
        {
            if (StopGame)
            {
                CanStartGame = false;
                UpdateViewModel();
                gameState.CanBet = true;

                await DelayCountdown(10);

                gameState.CanBet = false;

                for (int i = 0; i < 3; i++)
                {
                    gameState.AddCard();
                    UpdateViewModel();
                    DrawBoard();
                    gameState.ChangePlayer_Phase1();
                    if (i != 2)
                    {
                        await DelayCountdown(2);
                    }
                }

                gameState.CheckWin();

                gameState.ChangePlayer_Phase1();
                gameState.ChangePlayer_Phase2();

                while (!gameState.IsGameEnded)
                {
                    await DelayCountdown(3);

                    gameState.AddCard();
                    UpdateViewModel();
                    DrawBoard();
                    gameState.CheckWin();
                    gameState.ChangePlayer_Phase2();
                }

                MakeGoldWinCourses();
                await DelayCountdown(5);
                ResetAllButtons();

                gameState.CreateNewGame();
                DrawBoard();
                UpdateViewModel();
                CanStartGame = true;
                GameLoop();
            }

        }

        private void MakeGoldWinCourses()
        {
            if (gameState.Courses[0].IsWin) OneCardsButton.Background= new SolidColorBrush(Colors.Gold);
            if (gameState.Courses[1].IsWin) TwoCardsButton.Background = new SolidColorBrush(Colors.Gold);
            if (gameState.Courses[2].IsWin) ThreeCardsButton.Background = new SolidColorBrush(Colors.Gold);
            if (gameState.Courses[3].IsWin) FourCardsButton.Background = new SolidColorBrush(Colors.Gold);
            if (gameState.Courses[4].IsWin) FiveCardsButton.Background = new SolidColorBrush(Colors.Gold);
            if (gameState.Courses[5].IsWin) BlackJackWinButton.Background = new SolidColorBrush(Colors.Gold);
            if (gameState.Courses[6].IsWin) PlayerWinButton.Background = new SolidColorBrush(Colors.Gold);
            if (gameState.Courses[7].IsWin) DealerWinButton.Background = new SolidColorBrush(Colors.Gold);
            if (gameState.Courses[8].IsWin) DrawWinButton.Background = new SolidColorBrush(Colors.Gold);

        }

        private void ResetAllButtons()
        {
            OneCardsButton.Background = new SolidColorBrush(Colors.White);
            TwoCardsButton.Background = new SolidColorBrush(Colors.White);
            ThreeCardsButton.Background = new SolidColorBrush(Colors.White);
            FourCardsButton.Background = new SolidColorBrush(Colors.White);
            FiveCardsButton.Background = new SolidColorBrush(Colors.White);
            BlackJackWinButton.Background = new SolidColorBrush(Colors.White);
            DealerWinButton.Background = new SolidColorBrush(Colors.White);
            PlayerWinButton.Background = new SolidColorBrush(Colors.White);
            DrawWinButton.Background = new SolidColorBrush(Colors.White);
        }


        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (StopGame)
            {
                StopGame = false;
                StartButton.Background = new SolidColorBrush(Colors.Green);
            }
            if (CanStartGame)
            {
                StartButton.Background = new SolidColorBrush(Colors.Red);
                UpdateCoursesText();
                StopGame = true;
                GameLoop();
            }
        }

        private void PrevGames_Click(object sender, RoutedEventArgs e)
        {
            List<GameData> list = gameState.GiveAllPreviousBets();
            LastCourses secondWindow = new LastCourses(list);
            secondWindow.Show();
        }

        private void UpdateCoursesText()
        {
            viewModel.OneCardCourse = gameState.Courses[0]._CourseValue;
            viewModel.TwoCardCourse = gameState.Courses[1]._CourseValue;
            viewModel.ThreeCardCourse = gameState.Courses[2]._CourseValue;
            viewModel.FourCardCourse = gameState.Courses[3]._CourseValue;
            viewModel.FiveCardCourse = gameState.Courses[4]._CourseValue;
            viewModel.PlayerWinCourse = gameState.Courses[6]._CourseValue;
            viewModel.DealerWinCourse = gameState.Courses[7]._CourseValue;
            viewModel.BlackJackWinCourse = gameState.Courses[5]._CourseValue;
            viewModel.DrawWinCourse = gameState.Courses[8]._CourseValue;

        }

        private void UpdateViewModel()
        {
            viewModel.PlayerScore = gameState.PlayerBoard.AmountOfPoints;
            viewModel.DealerScore = gameState.DealerBoard.AmountOfPoints;

            viewModel.PlayerMoney = gameState.PlayerMoney;
        }

        private void BetOnOneCard(object sender, RoutedEventArgs e)
        {
            int.TryParse(BetAmountTextBox.Text, out int betAmount);

            if (gameState.CanBet && gameState.CheckCanBet(betAmount))
            {
                gameState.PlayerMoney -= betAmount;
                gameState.Courses[0].PlayerBet += betAmount;
                viewModel.PlayerMoney = gameState.PlayerMoney;
            }
        }

        private void BetOnTwoCard(object sender, RoutedEventArgs e)
        {
            int.TryParse(BetAmountTextBox.Text, out int betAmount);

            if (gameState.CanBet && gameState.CheckCanBet(betAmount))
            {
                gameState.PlayerMoney -= betAmount;
                gameState.Courses[1].PlayerBet += betAmount;
                viewModel.PlayerMoney = gameState.PlayerMoney;
            }
        }
        private void BetOnThreeCard(object sender, RoutedEventArgs e)
        {
            int.TryParse(BetAmountTextBox.Text, out int betAmount);

            if (gameState.CanBet && gameState.CheckCanBet(betAmount))
            {
                gameState.PlayerMoney -= betAmount;
                gameState.Courses[2].PlayerBet += betAmount;
                viewModel.PlayerMoney = gameState.PlayerMoney;
            }
        }

        private void BetOnFourCard(object sender, RoutedEventArgs e)
        {
            int.TryParse(BetAmountTextBox.Text, out int betAmount);

            if (gameState.CanBet && gameState.CheckCanBet(betAmount))
            {
                gameState.PlayerMoney -= betAmount;
                gameState.Courses[3].PlayerBet += betAmount;
                viewModel.PlayerMoney = gameState.PlayerMoney;
            }

        }
        private void BetOnFiveCard(object sender, RoutedEventArgs e)
        {
            int.TryParse(BetAmountTextBox.Text, out int betAmount);

            if (gameState.CanBet && gameState.CheckCanBet(betAmount))
            {
                gameState.PlayerMoney -= betAmount;
                gameState.Courses[4].PlayerBet += betAmount;
                viewModel.PlayerMoney = gameState.PlayerMoney;
            }

        }
        private void BetOnPlayerWin(object sender, RoutedEventArgs e)
        {
            int.TryParse(BetAmountTextBox.Text, out int betAmount);

            if (gameState.CanBet && gameState.CheckCanBet(betAmount))
            {
                gameState.PlayerMoney -= betAmount;
                gameState.Courses[6].PlayerBet += betAmount;
                viewModel.PlayerMoney = gameState.PlayerMoney;
            }

        }
        private void BetOnDealerWin(object sender, RoutedEventArgs e)
        {
            int.TryParse(BetAmountTextBox.Text, out int betAmount);

            if (gameState.CanBet && gameState.CheckCanBet(betAmount))
            {
                gameState.PlayerMoney -= betAmount;
                gameState.Courses[7].PlayerBet += betAmount;
                viewModel.PlayerMoney = gameState.PlayerMoney;
            }

        }

        private void BetOnBlackJackWin(object sender, RoutedEventArgs e)
        {
            int.TryParse(BetAmountTextBox.Text, out int betAmount);

            if (gameState.CanBet && gameState.CheckCanBet(betAmount))
            {
                gameState.PlayerMoney -= betAmount;
                gameState.Courses[5].PlayerBet += betAmount;
                viewModel.PlayerMoney = gameState.PlayerMoney;
            }

        }
        private void BetOnDrawWin(object sender, RoutedEventArgs e)
        {
            int.TryParse(BetAmountTextBox.Text, out int betAmount);

            if (gameState.CanBet && gameState.CheckCanBet(betAmount))
            {
                gameState.PlayerMoney -= betAmount;
                gameState.Courses[8].PlayerBet += betAmount;
                viewModel.PlayerMoney = gameState.PlayerMoney;
            }

        }
    }
}