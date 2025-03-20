
namespace BlackJackLogic
{
    public class Four_Card : Card
    {
        public override CardType Type => CardType.Four;
        public override CardSymbol Symbol { get; }
        public override int Value => 4;
        public Four_Card(CardSymbol symbol)
        {
            Symbol = symbol;
        }
        public override Card Copy()
        {
            return new Four_Card(Symbol);
        }
        public override string CardToString()
        {
            return "4" + CardSymbolToString();
        }
    }
}
