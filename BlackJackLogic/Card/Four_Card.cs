using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLogic
{
    public class Four_Card : Card
    {
        public override CardType Type => CardType.Four;
        public override CardSymbol Symbol { get; }

        public Four_Card(CardSymbol symbol)
        {
            Symbol = symbol;
        }

    }
}
