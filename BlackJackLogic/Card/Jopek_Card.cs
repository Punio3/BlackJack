using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
