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
        private async void GameLoop()
        {
            for (int i = 0; i < 3; i++)
            {
                gameState.AddCard();
                UpdateViewModel();
                DrawBoard();
                gameState.ChangePlayer();
                await Task.Delay(2000);
            }
            UpdateCourses();
            gameState.ChangePlayer();
            gameState.ChangePlayer2();
            gameState.CheckWin();
            await Task.Delay(5000);

            while (!gameState.IsGameEnded)
            {
                gameState.AddCard();
                UpdateViewModel();
                DrawBoard();
                gameState.CheckWin();
                gameState.ChangePlayer2();
                await Task.Delay(2500);
            }

            for(int i=0;i<gameState.Courses.Count;i++)
            {
                if (gameState.Courses[i].IsWin)
                {
                    MessageBox.Show($"Wygralo: {i}");
                }
            }
        }


        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StartButton.Background = new SolidColorBrush(Colors.Red); // Zmiana koloru przycisku
            GameLoop();
        }

        
        private void BetOnOneCard(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Gra xd!");

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

            viewModel.PlayerMoney = gameState.PlayerMoney;
        }
    }
}