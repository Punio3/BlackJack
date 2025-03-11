using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLogic
{
    public class Queen_Card : Card
    {
        public override CardType Type => CardType.Queen;
        public override CardSymbol Symbol { get; }
        public override int Value => 10;
        public Queen_Card(CardSymbol symbol)
        {
            Symbol = symbol;
        }

    }
}
