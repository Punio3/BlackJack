
namespace BlackJackLogic
{
    public class Ten_Card : Card
    {
        public override CardType Type => CardType.Ten;
        public override CardSymbol Symbol { get; }
        public override int Value => 10;
        public Ten_Card(CardSymbol symbol)
        {
            Symbol = symbol;
        }
        public override Card Copy()
        {
            return new Ten_Card(Symbol);
        }
        public override string CardToString()
        {
            return "T" + CardSymbolToString();
        }
    }
}
