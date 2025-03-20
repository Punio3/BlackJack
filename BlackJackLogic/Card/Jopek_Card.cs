
namespace BlackJackLogic
{
    public class Jopek_Card : Card
    {
        public override CardType Type => CardType.Jopek;
        public override CardSymbol Symbol { get; }
        public override int Value => 10;
        public Jopek_Card(CardSymbol symbol)
        {
            Symbol = symbol;
        }
        public override Card Copy()
        {
            return new Jopek_Card(Symbol);
        }
        public override string CardToString()
        {
            return "J" + CardSymbolToString();
        }
    }
}
