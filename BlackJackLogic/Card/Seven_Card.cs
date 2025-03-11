using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLogic
{
    public class Seven_Card : Card
    {
        public override CardType Type => CardType.Seven;
        public override CardSymbol Symbol { get; }
        public override int Value => 7;
        public Seven_Card(CardSymbol symbol)
        {
            Symbol = symbol;
        }

    }
}
