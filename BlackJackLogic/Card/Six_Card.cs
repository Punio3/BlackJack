using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLogic
{
    public class Six_Card : Card
    {
        public override CardType Type => CardType.Six;
        public override CardSymbol Symbol { get; }

        public Six_Card(CardSymbol symbol)
        {
            Symbol = symbol;
        }

    }
}
