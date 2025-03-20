
namespace BlackJackLogic
{
    public class King_Card : Card
    {
        public override CardType Type => CardType.King;
        public override CardSymbol Symbol { get; }
        public override int Value => 10;
        public King_Card(CardSymbol symbol)
        {
            Symbol = symbol;
        }
        public override Card Copy()
        {
            return new King_Card(Symbol);
        }
        public override string CardToString()
        {
            return "K" + CardSymbolToString();
        }
    }
}
