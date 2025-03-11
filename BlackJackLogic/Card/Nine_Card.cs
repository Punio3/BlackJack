using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLogic
{
    public class Nine_Card : Card
    {
        public override CardType Type => CardType.Nine;
        public override CardSymbol Symbol { get; }
        public override int Value => 9;
        public Nine_Card(CardSymbol symbol)
        {
            Symbol = symbol;
        }

    }
}
