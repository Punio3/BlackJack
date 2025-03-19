
namespace BlackJackLogic
{
    public abstract class Card
    {
        public abstract CardSymbol Symbol { get; }
        public abstract CardType Type { get; }

        public abstract int Value {  get; }

        public abstract Card Copy();

        public abstract string CardToString();

        public string CardSymbolToString()
        {
            if (this.Symbol == CardSymbol.Club) return "C";           
            if (this.Symbol == CardSymbol.Heart) return "H";           
            if (this.Symbol == CardSymbol.Spade) return "S";           
            if (this.Symbol == CardSymbol.Diamond) return "D";
            return null;
        }
    }
}
