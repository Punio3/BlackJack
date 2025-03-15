using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLogic
{
    public class BetCounter
    {

        public float[] CoursesValues;
        public long AllVariants;
        public int[] AmountOfCards;
        public BetCounter(bool SetCoursesValues)
        {
            if (SetCoursesValues)
            {
                CoursesValues = new float[9];
                for (int i = 0; i < 9; i++)
                {
                    CoursesValues[i] = 0;
                }
                AllVariants = 0;
            }

            AmountOfCards = new int[13];
            for(int i = 0; i < 13; i++)
            {
                AmountOfCards[i] = 2;
            }
        }

        public void DeleteCard(Card card)
        {
            switch (card.Type)
            {
                case CardType.Ass:
                    AmountOfCards[12]--;
                    break;
                case CardType.Queen:
                    AmountOfCards[9]--;
                    break;
                case CardType.Jopek:
                    AmountOfCards[10]--;
                    break;
                case CardType.King:
                    AmountOfCards[11]--;
                    break;
                case CardType.Two:
                    AmountOfCards[0]--;
                    break;
                case CardType.Three:
                    AmountOfCards[1]--;
                    break;
                case CardType.Four:
                    AmountOfCards[2]--;
                    break;
                case CardType.Five:
                    AmountOfCards[3]--;
                    break;
                case CardType.Six:
                    AmountOfCards[4]--;
                    break;
                case CardType.Seven:
                    AmountOfCards[5]--;
                    break;
                case CardType.Eight:
                    AmountOfCards[6]--;
                    break;
                case CardType.Nine:
                    AmountOfCards[7]--;
                    break;
                case CardType.Ten:
                    AmountOfCards[8]--;
                    break;
            }
        }
        public void CalculateCoursesValues(GameState _GameState)
        {

            if (!_GameState.IsGameEnded)
            {
                for (int i = 0; i < 13; i++)
                {
                    if (_GameState._BetCounter.AmountOfCards[i] > 0)
                    {
                        GameState NewGameState = _GameState.CopyGameState();
                        NewGameState.AddSpecificCard(i); 
                        NewGameState._BetCounter.AmountOfCards[i]--;

                        if (NewGameState.PlayerBoard.AmountOfCards + NewGameState.KrupierBoard.AmountOfCards <= 3)
                        {
                            NewGameState.ChangePlayer();
                        }
                        else
                        {
                            NewGameState.ChangePlayer2();
                        }

                        if (NewGameState.PlayerBoard.AmountOfCards + NewGameState.KrupierBoard.AmountOfCards == 3)
                        {
                            NewGameState.ChangePlayer();
                            NewGameState.ChangePlayer2();
                        }

                        NewGameState.CheckWin();
                        CalculateCoursesValues(NewGameState);
                    }
                }
            }
            else
            {
                for (int i = 0; i < _GameState.Courses.Count; i++)
                {
                    if (_GameState.Courses[i].IsWin)
                    {
                        if (i == 0)
                        {
                            int z = 0;
                        }
                        CoursesValues[i]++;
                    }
                }
                AllVariants++;
            }
        }


        public BetCounter Copy(GameState gamestate)
        {
            BetCounter _NewBetCounter=new BetCounter(false);
            for(int k = 0; k < 13; k++)
            {
                _NewBetCounter.AmountOfCards[k] = gamestate._BetCounter.AmountOfCards[k];
            }
            return _NewBetCounter;
        }
    }
}