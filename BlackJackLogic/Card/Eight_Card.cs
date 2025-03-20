
namespace BlackJackLogic
{
    public class Eight_Card : Card
    {
        public override CardType Type => CardType.Eight;
        public override CardSymbol Symbol { get; }
        public override int Value => 8;
        public Eight_Card(CardSymbol symbol)
        {
            Symbol = symbol;
        }
        public override Card Copy()
        {
            return new Eight_Card(Symbol);
        }
        public override string CardToString()
        {
            return "8" + CardSymbolToString();
        }
    }
}
