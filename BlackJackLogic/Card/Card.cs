using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLogic
{
    public abstract class Card
    {
        public abstract CardSymbol Symbol { get; }
        public abstract CardType Type { get; }

        public abstract int Value {  get; }
    }
}
