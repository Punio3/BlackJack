
namespace BlackJackLogic
{
    public class Queen_Card : Card
    {
        public override CardType Type => CardType.Queen;
        public override CardSymbol Symbol { get; }
        public override int Value => 10;
        public Queen_Card(CardSymbol symbol)
        {
            Symbol = symbol;
        }
        public override Card Copy()
        {
            return new Queen_Card(Symbol);
        }
        public override string CardToString()
        {
            return "Q" + CardSymbolToString();
        }
    }
}
