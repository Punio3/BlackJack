using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLogic
{
    public class Eight_Card : Card
    {
        public override CardType Type => CardType.Eight;
        public override CardSymbol Symbol { get; }
        public override int Value => 8;
        public Eight_Card(CardSymbol symbol)
        {
            Symbol = symbol;
        }

    }
}
