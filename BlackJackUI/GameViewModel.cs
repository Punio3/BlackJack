using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackUI
{
    public class GameViewModel : INotifyPropertyChanged
    {
        private int playerScore;
        private int dealerScore;
        private int gametimer;

        private float playerMoney;

        private float oneCardCourse;
        private float twoCardCourse;
        private float thirdCardCourse;
        private float fourCardCourse;
        private float fiveCardCourse;
        private float playerwinCourse;
        private float dealerwinCourse;
        private float drawwinCourse;
        private float blackjackwinCourse;

        public int PlayerScore
        {
            get { return playerScore; }
            set
            {
                playerScore = value;
                OnPropertyChanged(nameof(PlayerScore));
            }
        }

        public int DealerScore
        {
            get { return dealerScore; }
            set
            {
                dealerScore = value;
                OnPropertyChanged(nameof(DealerScore));
            }
        }

        public float PlayerMoney
        {
            get { return playerMoney; }
            set
            {
                playerMoney = value;
                OnPropertyChanged(nameof(PlayerMoney));
            }
        }

        public float OneCardCourse
        {
            get { return oneCardCourse; }
            set
            {
                oneCardCourse = value;
                OnPropertyChanged(nameof(OneCardCourse));
            }
        }

        public float TwoCardCourse
        {
            get { return twoCardCourse; }
            set
            {
                twoCardCourse = value;
                OnPropertyChanged(nameof(TwoCardCourse));
            }
        }

        public float ThreeCardCourse
        {
            get { return thirdCardCourse; }
            set
            {
                thirdCardCourse = value;
                OnPropertyChanged(nameof(ThreeCardCourse));
            }
        }

        public float FourCardCourse
        {
            get { return fourCardCourse; }
            set
            {
                fourCardCourse = value;
                OnPropertyChanged(nameof(FourCardCourse));
            }
        }

        public float FiveCardCourse
        {
            get { return fiveCardCourse; }
            set
            {
                fiveCardCourse = value;
                OnPropertyChanged(nameof(FiveCardCourse));
            }
        }

        public float PlayerWinCourse
        {
            get { return playerwinCourse; }
            set
            {
                playerwinCourse = value;
                OnPropertyChanged(nameof(PlayerWinCourse));
            }
        }

        public float DealerWinCourse
        {
            get { return dealerwinCourse ; }
            set
            {
                dealerwinCourse = value;
                OnPropertyChanged(nameof(DealerWinCourse));
            }
        }

        public float DrawWinCourse
        {
            get { return drawwinCourse; }
            set
            {
                drawwinCourse = value;
                OnPropertyChanged(nameof(DrawWinCourse));
            }
        }

        public float BlackJackWinCourse
        {
            get { return blackjackwinCourse; }
            set
            {
                blackjackwinCourse = value;
                OnPropertyChanged(nameof(BlackJackWinCourse));
            }
        }

        public int GameTimer
        {
            get { return gametimer; }
            set
            {
                gametimer = value;
                OnPropertyChanged(nameof(GameTimer));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}