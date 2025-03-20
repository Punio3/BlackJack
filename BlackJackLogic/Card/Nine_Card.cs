
namespace BlackJackLogic
{
    public class Nine_Card : Card
    {
        public override CardType Type => CardType.Nine;
        public override CardSymbol Symbol { get; }
        public override int Value => 9;
        public Nine_Card(CardSymbol symbol)
        {
            Symbol = symbol;
        }
        public override Card Copy()
        {
            return new Nine_Card(Symbol);
        }
        public override string CardToString()
        {
            return "9" + CardSymbolToString();
        }
    }
}
