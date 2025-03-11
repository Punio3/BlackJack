using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLogic
{
    public class BetCounter
    {

        private int AmountOfTwo;
        private int AmountOfThree;
        private int AmountOfFour;
        private int AmountOfFive;
        private int AmountOfSix;
        private int AmountOfSeven;
        private int AmountOfEight;
        private int AmountOfNine;
        private int AmountOfTen;
        private int AmountOfQueen;
        private int AmountOfKing;
        private int AmountOfJopek;
        private int AmountOfAss;

        public BetCounter()
        {
            AmountOfTwo = 4;
            AmountOfThree = 4;
            AmountOfFour = 4;
            AmountOfFive = 4;
            AmountOfSix = 4;
            AmountOfSeven = 4;
            AmountOfEight = 4;
            AmountOfNine = 4;
            AmountOfTen = 4;
            AmountOfQueen = 4;
            AmountOfKing = 4;
            AmountOfJopek = 4;
            AmountOfAss = 4;
        }


        public void DeleteCard(Card card)
        {
            switch (card.Type)
            {
                case CardType.Ass:
                    AmountOfAss--;
                    break;
                case CardType.Queen:
                    AmountOfQueen--;
                    break;
                case CardType.Jopek:
                    AmountOfJopek--;
                    break;
                case CardType.King:
                    AmountOfKing--;
                    break;
                case CardType.Two:
                    AmountOfTwo--;
                    break;
                case CardType.Three:
                    AmountOfThree--;
                    break;
                case CardType.Four:
                    AmountOfFour--;
                    break;
                case CardType.Five:
                    AmountOfFive--;
                    break;
                case CardType.Six:
                    AmountOfSix--;
                    break;
                case CardType.Seven:
                    AmountOfSeven--;
                    break;
                case CardType.Eight:
                    AmountOfEight--;
                    break;
                case CardType.Nine:
                    AmountOfNine--;
                    break;
                case CardType.Ten:
                    AmountOfTen--;
                    break;
            }
        }
/*
        private float TwoCardsCourse(int PlayerPoints, int DealerPoints)
        {

        }
        private float ThirdCardsCourse(int PlayerPoints, int DealerPoints)
        {

        }

        private float FourCardsCourse(int PlayerPoints, int DealerPoints)
        {

        }

        private float FiveCardsCourse(int PlayerPoints, int DealerPoints)
        {

        }

        private float PlayerWin(int PlayerPoints, int DealerPoints)
        {

        }

        private float DealerWin(int PlayerPoints, int DealerPoints)
        {

        }

        private float Draw(int PlayerPoints, int DealerPoints)
        {

        }
  */
    }
}
