
namespace BlackJackLogic
{
    public class Ass_Card : Card
    {
        public override CardType Type => CardType.Ass;
        public override CardSymbol Symbol { get; }
        public override int Value => 11;

        public Ass_Card(CardSymbol symbol)
        {
            Symbol = symbol;
        }
        public override Card Copy()
        {
            return new Ass_Card(Symbol);
        }

    }
}
