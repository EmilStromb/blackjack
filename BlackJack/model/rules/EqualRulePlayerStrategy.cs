using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class EqualRulePlayer : IWinStrategy
    {
        private const int g_maxLimit = 21;

        public bool calcWinner(model.Player a_dealer, model.Player a_player)
        {
            if (a_player.CalcScore() > g_maxLimit)
            {
                return true;
            }
            else if (a_dealer.CalcScore() > g_maxLimit)
            {
                return false;
            }
            else if (a_dealer.CalcScore() == a_player.CalcScore())
            {
                return false;
            }
            return a_dealer.CalcScore() > a_player.CalcScore();
        }
    }
}
