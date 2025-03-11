using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLogic
{
    public class Three_Card : Card
    {
        public override CardType Type => CardType.Three;
        public override CardSymbol Symbol { get; }
        public override int Value => 3;
        public Three_Card(CardSymbol symbol)
        {
            Symbol = symbol;
        }

    }
}
