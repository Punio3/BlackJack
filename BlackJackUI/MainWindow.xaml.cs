using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BlackJackLogic;

/*CO ZROBIC TRZEBA:
 * a) przetestowac sprawdzanie wygranej (cos z blackjackiem mozliwe)
 * b) liczenie kursow 
 * c) zaokraglanie pieniedzy, betow do 2 miejsc po przecinku
 * d) ladnijesze gui przyciskow
 * e) background na czerwono przyciskow jak nie mozna stawiac zakladow
 * f) obsluga zasady z asem w grze
 */

namespace BlackJackUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Image[,] PlayerCardImages = new Image[2, 5];
        private readonly Image[,] KrupierCardImages = new Image[2, 5];

        private GameState gameState;
        private GameViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            InitalizeBoard();

            viewModel = new GameViewModel();
            DataContext = viewModel;

            gameState = new GameState(Board.Initial(), Board.Initial());
            DrawBoard();
        }

        private void InitalizeBoard()
        {
            for(int i=0;i<2;i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    Image image = new Image();
                    Image image2 = new Image();

                    image.Width = 50;
                    image.Height = 60;
                    image2.Width = 50;
                    image2.Height = 60;

                    PlayerCardImages[i,j] = image;
                    CardGrid_Gracz.Children.Add(image);


                    KrupierCardImages[i, j] = image2;
                    CardGrid_Krupier.Children.Add(image2);
                }
            }
        }

        private void DrawBoard()
        {
            for(int i=0;i<10;i++) {
                Card card = gameState.PlayerBoard[i];
                Card card2= gameState.KrupierBoard[i];

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
            UpdateViewModel();
            UpdateCourses();
            gameState.CanBet = true;
            await DelayCountdown(10);

            gameState.CanBet = false;
            for (int i = 0; i < 3; i++)
            {
                gameState.AddCard();
                UpdateViewModel();
                DrawBoard();
                gameState.ChangePlayer();
                if (i != 2)
                {
                    await DelayCountdown(2);
                }
            }


            gameState.CheckWin();
            if (!gameState.IsGameEnded)
            {
                UpdateCourses();
                gameState.ChangePlayer();
                gameState.ChangePlayer2();
                gameState.CanBet = true;
                await DelayCountdown(5);
            }
            gameState.CanBet = false;
            while (!gameState.IsGameEnded)
            {
                gameState.AddCard();
                UpdateViewModel();
                DrawBoard();
                gameState.CheckWin();
                gameState.ChangePlayer2();

                if (!gameState.IsGameEnded)
                {
                    await DelayCountdown(3);
                }
            }


            MakeGoldWinCourses();
            await DelayCountdown(5);
            ResetAllButtons();

            gameState.CreateNewGame();
            DrawBoard();
            GameLoop();
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
            OneCardsButton.Background = new SolidColorBrush(Colors.Black);
            TwoCardsButton.Background = new SolidColorBrush(Colors.Black);
            ThreeCardsButton.Background = new SolidColorBrush(Colors.Black);
            FourCardsButton.Background = new SolidColorBrush(Colors.Black);
            FiveCardsButton.Background = new SolidColorBrush(Colors.Black);
            BlackJackWinButton.Background = new SolidColorBrush(Colors.Black);
            DealerWinButton.Background = new SolidColorBrush(Colors.Black);
            PlayerWinButton.Background = new SolidColorBrush(Colors.Black);
            DrawWinButton.Background = new SolidColorBrush(Colors.Black);
        }


        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StartButton.Background = new SolidColorBrush(Colors.Red); 
            GameLoop();
        }


        private void UpdateViewModel()
        {
            viewModel.PlayerScore = gameState.PlayerBoard.AmountOfPoints;
            viewModel.DealerScore = gameState.KrupierBoard.AmountOfPoints;
        }

        private void UpdateCourses()
        {
            viewModel.OneCardCourse = 1.23f;
            viewModel.TwoCardCourse = 1.33f;
            viewModel.ThreeCardCourse = 1.28f;
            viewModel.FourCardCourse = 1.25f;
            viewModel.FiveCardCourse = 1.55f;
            viewModel.PlayerWinCourse = 1.28f;
            viewModel.DealerWinCourse = 1.25f;
            viewModel.BlackJackWinCourse = 1.55f;
            viewModel.DrawWinCourse = 1.66f;

            viewModel.PlayerMoney = gameState.PlayerMoney;
        }

        private void BetOnOneCard(object sender, RoutedEventArgs e)
        {
            float.TryParse(BetAmountTextBox.Text, out float betAmount);

            if (gameState.CanBet && gameState.CheckCanBet(betAmount))
            {
                gameState.PlayerMoney -= betAmount;
                gameState.Courses[0].PlayerBet += betAmount;
                viewModel.PlayerMoney = gameState.PlayerMoney;
            }
        }

        private void BetOnTwoCard(object sender, RoutedEventArgs e)
        {
            float.TryParse(BetAmountTextBox.Text, out float betAmount);

            if (gameState.CanBet && gameState.CheckCanBet(betAmount))
            {
                gameState.PlayerMoney -= betAmount;
                gameState.Courses[1].PlayerBet += betAmount;
                viewModel.PlayerMoney = gameState.PlayerMoney;
            }
        }
        private void BetOnThreeCard(object sender, RoutedEventArgs e)
        {
            float.TryParse(BetAmountTextBox.Text, out float betAmount);

            if (gameState.CanBet && gameState.CheckCanBet(betAmount))
            {
                gameState.PlayerMoney -= betAmount;
                gameState.Courses[2].PlayerBet += betAmount;
                viewModel.PlayerMoney = gameState.PlayerMoney;
            }
        }

        private void BetOnFourCard(object sender, RoutedEventArgs e)
        {
            float.TryParse(BetAmountTextBox.Text, out float betAmount);

            if (gameState.CanBet && gameState.CheckCanBet(betAmount))
            {
                gameState.PlayerMoney -= betAmount;
                gameState.Courses[3].PlayerBet += betAmount;
                viewModel.PlayerMoney = gameState.PlayerMoney;
            }

        }
        private void BetOnFiveCard(object sender, RoutedEventArgs e)
        {
            float.TryParse(BetAmountTextBox.Text, out float betAmount);

            if (gameState.CanBet && gameState.CheckCanBet(betAmount))
            {
                gameState.PlayerMoney -= betAmount;
                gameState.Courses[4].PlayerBet += betAmount;
                viewModel.PlayerMoney = gameState.PlayerMoney;
            }

        }
        private void BetOnPlayerWin(object sender, RoutedEventArgs e)
        {
            float.TryParse(BetAmountTextBox.Text, out float betAmount);

            if (gameState.CanBet && gameState.CheckCanBet(betAmount))
            {
                gameState.PlayerMoney -= betAmount;
                gameState.Courses[6].PlayerBet += betAmount;
                viewModel.PlayerMoney = gameState.PlayerMoney;
            }

        }
        private void BetOnDealerWin(object sender, RoutedEventArgs e)
        {
            float.TryParse(BetAmountTextBox.Text, out float betAmount);

            if (gameState.CanBet && gameState.CheckCanBet(betAmount))
            {
                gameState.PlayerMoney -= betAmount;
                gameState.Courses[7].PlayerBet += betAmount;
                viewModel.PlayerMoney = gameState.PlayerMoney;
            }

        }

        private void BetOnBlackJackWin(object sender, RoutedEventArgs e)
        {
            float.TryParse(BetAmountTextBox.Text, out float betAmount);

            if (gameState.CanBet && gameState.CheckCanBet(betAmount))
            {
                gameState.PlayerMoney -= betAmount;
                gameState.Courses[5].PlayerBet += betAmount;
                viewModel.PlayerMoney = gameState.PlayerMoney;
            }

        }
        private void BetOnDrawWin(object sender, RoutedEventArgs e)
        {
            float.TryParse(BetAmountTextBox.Text, out float betAmount);

            if (gameState.CanBet && gameState.CheckCanBet(betAmount))
            {
                gameState.PlayerMoney -= betAmount;
                gameState.Courses[8].PlayerBet += betAmount;
                viewModel.PlayerMoney = gameState.PlayerMoney;
            }

        }
    }
}