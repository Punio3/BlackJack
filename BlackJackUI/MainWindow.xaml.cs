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
        public MainWindow()
        {
            InitializeComponent();
            InitalizeBoard();

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

                    PlayerCardImages[i,j]= image;
                    KrupierCardImages[i, j] = image2;

                    CardGrid_Krupier.Children.Add(image);
                    CardGrid_Gracz.Children.Add(image2);
                }
            }
        }

        private void DrawBoard()
        {
            for(int i=0;i<10;i++) {
                Card card = gameState.PlayerBoard[i];
                Card card2= gameState.KrupierBoard[i];

                PlayerCardImages[i / 5, i % 5].Source = Images.GetImage(card);
                KrupierCardImages[i/5,i%5].Source = Images.GetImage(card2);
            }
        }
    }
}