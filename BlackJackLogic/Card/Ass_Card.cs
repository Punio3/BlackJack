using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLogic
{
    public class Ass_Card : Card
    {
        public override CardType Type => CardType.Ass;
        public override CardSymbol Symbol { get; }

        public Ass_Card(CardSymbol symbol)
        {
            Symbol = symbol;
        }

    }
}
