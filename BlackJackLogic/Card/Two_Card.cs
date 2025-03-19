
namespace BlackJackLogic
{
    public class Two_Card : Card
    {
        public override CardType Type => CardType.Two;
        public override CardSymbol Symbol { get; }
        public override int Value => 2;
        public Two_Card(CardSymbol symbol) 
        {
            Symbol = symbol;
        }
        public override Card Copy()
        {
            return new Two_Card(Symbol);
        }
        public override string CardToString()
        {
            return "2-" + CardSymbolToString();
        }
    }
}
