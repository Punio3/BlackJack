using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLogic
{
    public class King_Card : Card
    {
        public override CardType Type => CardType.King;
        public override CardSymbol Symbol { get; }
        public override int Value => 10;
        public King_Card(CardSymbol symbol)
        {
            Symbol = symbol;
        }

    }
}
