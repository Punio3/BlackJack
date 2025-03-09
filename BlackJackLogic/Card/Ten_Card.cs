using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLogic
{
    public class Ten_Card : Card
    {
        public override CardType Type => CardType.Ten;
        public override CardSymbol Symbol { get; }

        public Ten_Card(CardSymbol symbol)
        {
            Symbol = symbol;
        }

    }
}
