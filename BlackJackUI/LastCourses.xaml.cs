using BlackJackLogic;
using System.Windows;
using System.Windows.Controls;

namespace BlackJackUI
{
    /// <summary>
    /// Logika interakcji dla klasy LastCourses.xaml
    /// </summary>
    public partial class LastCourses : Window
    {
        private readonly Image[,] PlayerCardImages = new Image[5, 9];
        private readonly Image[,] KrupierCardImages = new Image[5, 9];

        private LastCourseViewModel viewModel;
        private List<GameData> PrevGamesList { get; set; }
        private int ActualPage { get; set; }
        public LastCourses(List<GameData> prevGamesList)
        {
            InitializeComponent();
            InitalizeBoard();

            viewModel=new LastCourseViewModel();
            DataContext = viewModel;

            PrevGamesList = prevGamesList;
            ActualPage = 0;

            viewModel.PageNumber = ActualPage+1;
            DisplayCardsFromPage(ActualPage);
        }


        private void InitalizeBoard()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Image image = new Image();
                    image.Width = 30;
                    image.Height = 70;

                    PlayerCardImages[i, j] = image;
                    CardGrid_Gracz.Children.Add(image);

                    image = new Image();
                    image.Width = 30;
                    image.Height = 70;

                    KrupierCardImages[i, j] = image;
                    CardGrid_Krupier.Children.Add(image);
                }
            }
        }

        private void Right_Button_Click(object sender, RoutedEventArgs e)
        {
            if ((ActualPage+1) * 5 - 1 < PrevGamesList.Count)
            {
                ClearCardsFromPage(ActualPage);
                ActualPage++;
                DisplayCardsFromPage(ActualPage);
            }
            viewModel.PageNumber = ActualPage + 1;
        }

        private void Left_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ActualPage > 0)
            {
                ClearCardsFromPage(ActualPage);
                ActualPage--;
                DisplayCardsFromPage(ActualPage);
            }
            viewModel.PageNumber = ActualPage + 1;
        }

        private void DisplayCardsFromPage(int PageNumber)
        {
            if (PrevGamesList.Count != 0)
            {
                int size = 0;
                if (PrevGamesList.Count - ((PageNumber + 1) * 5) < 0)  size = PrevGamesList.Count % 5;                
                else  size = 5;
                

                for (int i = PageNumber * 5; i < PageNumber * 5 + size ; i++)
                {

                    GameData data = PrevGamesList[i];
                    for (int k = 0; k < data.Player1Cards.Length / 2; k++)
                    {
                        PlayerCardImages[i % 5, k].Source = Images.GetImage(GiveCardFromString(data.Player1Cards[k * 2], data.Player1Cards[k * 2 + 1]));
                    }

                    for (int k = 0; k < data.Player2Cards.Length / 2; k++)
                    {
                        KrupierCardImages[i % 5, k].Source = Images.GetImage(GiveCardFromString(data.Player2Cards[k * 2], data.Player2Cards[k * 2 + 1]));
                    }
                    viewModel.SetScores(i % 5 + 1, data.Player1_Points, data.Player2_Points);
                }
            }
        }

        private void ClearCardsFromPage(int PageNumber)
        {
            if (PrevGamesList.Count != 0)
            {
                int size = 0;
                if (PrevGamesList.Count - ((PageNumber +1) * 5) < 0) size = PrevGamesList.Count % 5;               
                else size = 5;
                
                for (int i = PageNumber * 5; i < PageNumber * 5 + size; i++)
                {

                    GameData data = PrevGamesList[i];
                    for (int k = 0; k < data.Player1Cards.Length / 2; k++)
                    {
                        PlayerCardImages[i % 5, k].Source = null;
                    }

                    for (int k = 0; k < data.Player2Cards.Length / 2; k++)
                    {
                        KrupierCardImages[i % 5, k].Source = null;
                    }
                    viewModel.SetScores(i % 5 + 1, -1, -1);
                }
            }
        }

        private Card GiveCardFromString(char Type, char Symbol)
        {
            if(Symbol == 'C')
            {
                if (Type == '2') return new Two_Card(CardSymbol.Club);
                else if (Type == '3') return new Three_Card(CardSymbol.Club);
                else if (Type == '4') return new Four_Card(CardSymbol.Club);
                else if (Type == '5') return new Five_Card(CardSymbol.Club);
                else if (Type == '6') return new Six_Card(CardSymbol.Club);
                else if (Type == '7') return new Seven_Card(CardSymbol.Club);
                else if (Type == '8') return new Eight_Card(CardSymbol.Club);
                else if (Type == '9') return new Nine_Card(CardSymbol.Club);
                else if (Type == 'T') return new Ten_Card(CardSymbol.Club);
                else if (Type == 'Q') return new Queen_Card(CardSymbol.Club);
                else if (Type == 'K') return new King_Card(CardSymbol.Club);
                else if (Type == 'J') return new Jopek_Card(CardSymbol.Club);
                else if (Type == 'A') return new Ass_Card(CardSymbol.Club);
            }
            else if (Symbol ==  'D')
            {
                if (Type == '2') return new Two_Card(CardSymbol.Diamond);
                else if (Type == '3') return new Three_Card(CardSymbol.Diamond);
                else if (Type == '4') return new Four_Card(CardSymbol.Diamond);
                else if (Type == '5') return new Five_Card(CardSymbol.Diamond);
                else if (Type == '6') return new Six_Card(CardSymbol.Diamond);
                else if (Type == '7') return new Seven_Card(CardSymbol.Diamond);
                else if (Type == '8') return new Eight_Card(CardSymbol.Diamond);
                else if (Type == '9') return new Nine_Card(CardSymbol.Diamond);
                else if (Type == 'T') return new Ten_Card(CardSymbol.Diamond);
                else if (Type == 'Q') return new Queen_Card(CardSymbol.Diamond);
                else if (Type == 'K') return new King_Card(CardSymbol.Diamond);
                else if (Type == 'J') return new Jopek_Card(CardSymbol.Diamond);
                else if (Type == 'A') return new Ass_Card(CardSymbol.Diamond);
            }
            else if (Symbol == 'H')
            {
                if (Type == '2') return new Two_Card(CardSymbol.Heart);
                else if (Type == '3') return new Three_Card(CardSymbol.Heart);
                else if (Type == '4') return new Four_Card(CardSymbol.Heart);
                else if (Type == '5') return new Five_Card(CardSymbol.Heart);
                else if (Type == '6') return new Six_Card(CardSymbol.Heart);
                else if (Type == '7') return new Seven_Card(CardSymbol.Heart);
                else if (Type == '8') return new Eight_Card(CardSymbol.Heart);
                else if (Type == '9') return new Nine_Card(CardSymbol.Heart);
                else if (Type == 'T') return new Ten_Card(CardSymbol.Heart);
                else if (Type == 'Q') return new Queen_Card(CardSymbol.Heart);
                else if (Type == 'K') return new King_Card(CardSymbol.Heart);
                else if (Type == 'J') return new Jopek_Card(CardSymbol.Heart);
                else if (Type == 'A') return new Ass_Card(CardSymbol.Heart);
            }
            else if (Symbol == 'S')
            {
                if (Type == '2') return new Two_Card(CardSymbol.Spade);
                else if (Type == '3') return new Three_Card(CardSymbol.Spade);
                else if (Type == '4') return new Four_Card(CardSymbol.Spade);
                else if (Type == '5') return new Five_Card(CardSymbol.Spade);
                else if (Type == '6') return new Six_Card(CardSymbol.Spade);
                else if (Type == '7') return new Seven_Card(CardSymbol.Spade);
                else if (Type == '8') return new Eight_Card(CardSymbol.Spade);
                else if (Type == '9') return new Nine_Card(CardSymbol.Spade);
                else if (Type == 'T') return new Ten_Card(CardSymbol.Spade);
                else if (Type == 'Q') return new Queen_Card(CardSymbol.Spade);
                else if (Type == 'K') return new King_Card(CardSymbol.Spade);
                else if (Type == 'J') return new Jopek_Card(CardSymbol.Spade);
                else if (Type == 'A') return new Ass_Card(CardSymbol.Spade);
            }
            return null;
        }
    }
}
