using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLogic
{
    public class Two_Card : Card
    {
        public override CardType Type => CardType.Two;
        public override CardSymbol Symbol { get; }

        public Two_Card(CardSymbol symbol) 
        {
            Symbol = symbol;
        }

    }
}
