using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackUI
{
    public class LastCourseViewModel : INotifyPropertyChanged
    {
        private int _PageNumber;

        private int[] playerScores = new int[5];
        private int[] dealerScores = new int[5];


        // Dynamiczne właściwości powiązane z UI, zwracające pusty string jeśli -1
        public string PlayerScore1 => playerScores[0] == -1 ? "" : playerScores[0].ToString();
        public string PlayerScore2 => playerScores[1] == -1 ? "" : playerScores[1].ToString();
        public string PlayerScore3 => playerScores[2] == -1 ? "" : playerScores[2].ToString();
        public string PlayerScore4 => playerScores[3] == -1 ? "" : playerScores[3].ToString();
        public string PlayerScore5 => playerScores[4] == -1 ? "" : playerScores[4].ToString();

        public string DealerScore1 => dealerScores[0] == -1 ? "" : dealerScores[0].ToString();
        public string DealerScore2 => dealerScores[1] == -1 ? "" : dealerScores[1].ToString();
        public string DealerScore3 => dealerScores[2] == -1 ? "" : dealerScores[2].ToString();
        public string DealerScore4 => dealerScores[3] == -1 ? "" : dealerScores[3].ToString();
        public string DealerScore5 => dealerScores[4] == -1 ? "" : dealerScores[4].ToString();


        public int PageNumber
        {
            get { return _PageNumber; }
            set
            {
                _PageNumber = value;
                OnPropertyChanged(nameof(PageNumber));
            }
        }

        public void SetScores(int index, int playerScore, int dealerScore)
        {
            if (index >= 1 && index <= 5)
            {
                if (playerScore != -1)
                {
                    playerScores[index - 1] = playerScore;
                    dealerScores[index - 1] = dealerScore;
                }
                else
                {
                    playerScores[index - 1] = -1; // Ustawienie jako niewidoczny
                    dealerScores[index - 1] = -1;
                }

                // Powiadomienie UI o zmianach
                OnPropertyChanged($"PlayerScore{index}");
                OnPropertyChanged($"DealerScore{index}");
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index must be between 1 and 5.");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
