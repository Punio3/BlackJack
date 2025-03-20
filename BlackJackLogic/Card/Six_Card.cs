
namespace BlackJackLogic
{
    public class Six_Card : Card
    {
        public override CardType Type => CardType.Six;
        public override CardSymbol Symbol { get; }
        public override int Value => 6;
        public Six_Card(CardSymbol symbol)
        {
            Symbol = symbol;
        }
        public override Card Copy()
        {
            return new Six_Card(Symbol);
        }
        public override string CardToString()
        {
            return "6" + CardSymbolToString();
        }
    }
}
