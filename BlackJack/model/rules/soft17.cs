using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class softRule : IHitStrategy
    {
        private const int g_hitLimit = 17;
        public bool DoHit(model.Player a_dealer)
        {
            int dealerScore = a_dealer.CalcScore();
            bool ace = false;

            if (dealerScore >= g_hitLimit && dealerScore < 21)
            {

                foreach (Card c in a_dealer.GetHand())
                {
                    if (c.GetValue() == Card.Value.Ace)
                    {
                        ace = true;
                    }
                }
            }

            return dealerScore < g_hitLimit || ace;
        }
    }
}
 