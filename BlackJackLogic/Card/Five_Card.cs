
namespace BlackJackLogic
{
    public class Five_Card : Card
    {
        public override CardType Type => CardType.Five;
        public override CardSymbol Symbol { get; }
        public override int Value => 5;
        public Five_Card(CardSymbol symbol)
        {
            Symbol = symbol;
        }
        public override Card Copy()
        {
            return new Five_Card(Symbol);
        }

    }
}
