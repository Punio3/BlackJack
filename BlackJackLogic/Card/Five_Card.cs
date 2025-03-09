using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLogic
{
    public class Five_Card : Card
    {
        public override CardType Type => CardType.Five;
        public override CardSymbol Symbol { get; }

        public Five_Card(CardSymbol symbol)
        {
            Symbol = symbol;
        }

    }
}
