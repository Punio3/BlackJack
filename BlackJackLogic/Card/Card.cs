
namespace BlackJackLogic
{
    public abstract class Card
    {
        public abstract CardSymbol Symbol { get; }
        public abstract CardType Type { get; }

        public abstract int Value {  get; }

        public abstract Card Copy();
    }
}
