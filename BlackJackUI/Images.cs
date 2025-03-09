using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BlackJackLogic;

namespace BlackJackUI
{
    public static class Images
    {
        private static readonly Dictionary<CardType, ImageSource> ClubCardsSources = new()
        {
            { CardType.Two, LoadImage("Assets/Clubs/2club.png") },
            { CardType.Three, LoadImage("Assets/Clubs/3club.png") },
            { CardType.Four, LoadImage("Assets/Clubs/4club.png") },
            { CardType.Five, LoadImage("Assets/Clubs/5club.png") },
            { CardType.Six, LoadImage("Assets/Clubs/6club.png") },
            { CardType.Seven, LoadImage("Assets/Clubs/7club.png") },
            { CardType.Eight, LoadImage("Assets/Clubs/8club.png") },
            { CardType.Nine, LoadImage("Assets/Clubs/9club.png") },
            { CardType.Ten, LoadImage("Assets/Clubs/10club.png") },
            { CardType.Queen, LoadImage("Assets/Clubs/Q.png") },
            { CardType.King, LoadImage("Assets/Clubs/Kclub.png") },
            { CardType.Jopek, LoadImage("Assets/Clubs/Jclub.png") },
            { CardType.Ass, LoadImage("Assets/Clubs/Aclub.png") }
        };

        private static readonly Dictionary<CardType, ImageSource> DiamondCardsSources = new()
        {
            { CardType.Two, LoadImage("Assets/Diamonds/2diamond.png") },
            { CardType.Three, LoadImage("Assets/Diamonds/3diamond.png") },
            { CardType.Four, LoadImage("Assets/Diamonds/4diamond.png") },
            { CardType.Five, LoadImage("Assets/Diamonds/5diamond.png") },
            { CardType.Six, LoadImage("Assets/Diamonds/6diamond.png") },
            { CardType.Seven, LoadImage("Assets/Diamonds/7diamond.png") },
            { CardType.Eight, LoadImage("Assets/Diamonds/8diamond.png") },
            { CardType.Nine, LoadImage("Assets/Diamonds/9diamond.png") },
            { CardType.Ten, LoadImage("Assets/Diamonds/10diamond.png") },
            { CardType.Queen, LoadImage("Assets/Diamonds/Qdiamond.png") },
            { CardType.King, LoadImage("Assets/Diamonds/Kdiamond.png") },
            { CardType.Jopek, LoadImage("Assets/Diamonds/Jdiamond.png") },
            { CardType.Ass, LoadImage("Assets/Diamonds/Adiamond.png") }
        };

        private static readonly Dictionary<CardType, ImageSource> HeartCardsSources = new()
        {
            { CardType.Two, LoadImage("Assets/Hearts/2heart.png") },
            { CardType.Three, LoadImage("Assets/Hearts/3heart.png") },
            { CardType.Four, LoadImage("Assets/Hearts/4heart.png") },
            { CardType.Five, LoadImage("Assets/Hearts/5heart.png") },
            { CardType.Six, LoadImage("Assets/Hearts/6heart.png") },
            { CardType.Seven, LoadImage("Assets/Hearts/7heart.png") },
            { CardType.Eight, LoadImage("Assets/Hearts/8heart.png") },
            { CardType.Nine, LoadImage("Assets/Hearts/9heart.png") },
            { CardType.Ten, LoadImage("Assets/Hearts/10heart.png") },
            { CardType.Queen, LoadImage("Assets/Hearts/Qheart.png") },
            { CardType.King, LoadImage("Assets/Hearts/Kheart.png") },
            { CardType.Jopek, LoadImage("Assets/Hearts/Jheart.png") },
            { CardType.Ass, LoadImage("Assets/Hearts/Aheart.png") }
        };

        private static readonly Dictionary<CardType, ImageSource> SpadeCardsSources = new()
        {
            { CardType.Two, LoadImage("Assets/Spades/2spade.png") },
            { CardType.Three, LoadImage("Assets/Spades/3spade.png") },
            { CardType.Four, LoadImage("Assets/Spades/4spade.png") },
            { CardType.Five, LoadImage("Assets/Spades/5spade.png") },
            { CardType.Six, LoadImage("Assets/Spades/6spade.png") },
            { CardType.Seven, LoadImage("Assets/Spades/7spade.png") },
            { CardType.Eight, LoadImage("Assets/Spades/8spade.png") },
            { CardType.Nine, LoadImage("Assets/Spades/9spade.png") },
            { CardType.Ten, LoadImage("Assets/Spades/10spade.png") },
            { CardType.Queen, LoadImage("Assets/Spades/Qspade.png") },
            { CardType.King, LoadImage("Assets/Spades/Kspade.png") },
            { CardType.Jopek, LoadImage("Assets/Spades/Jspade.png") },
            { CardType.Ass, LoadImage("Assets/Spades/Aspade.png") }
        };

        private static ImageSource LoadImage(string filePath)
        {
            return new BitmapImage(new Uri(filePath, UriKind.Relative));
        }

        public static ImageSource GetImage(CardType Type, CardSymbol Symbol)
        {
            return Symbol switch
            {
                CardSymbol.Club => ClubCardsSources[Type],
                CardSymbol.Diamond => DiamondCardsSources[Type],
                CardSymbol.Heart => HeartCardsSources[Type],
                CardSymbol.Spade => SpadeCardsSources[Type],
                _ => null
            };
        }

        public static ImageSource GetImage(Card card)
        {
            if (card == null)
            {
                return null;
            }

            return GetImage(card.Type, card.Symbol);
        }
    }
}
