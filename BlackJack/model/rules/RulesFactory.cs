using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class RulesFactory
    {
        public IHitStrategy softRule() {
            return new softRule();
        }

        public INewGameStrategy GetNewGameRule()
        {
            return new AmericanNewGameStrategy();
        }
    }
}
