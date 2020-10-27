using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_softRule;



        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_softRule = a_rulesFactory.softRule();
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(m_deck, this, a_player);   
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
			    DealCard(true, a_player);
			    return true;
		    }

		    if (a_player.CalcScore() >= g_maxScore) {
		    	Stand();
		    }
                return false;
            }

        public bool IsDealerWinner(Player a_player)
        {
            if (a_player.CalcScore() > g_maxScore)
            {
                return true;
            }
            else if (CalcScore() > g_maxScore)
            {
                return false;
            }
            return CalcScore() >= a_player.CalcScore();
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_softRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }

        public bool Stand() {

		if (m_deck != null) {

			ShowHand();

			while (m_softRule.DoHit(this)) {
				DealCard(true, this);
			}
			return true;
		}
		return false;
	    }

        public void DealCard(bool show, Player a_player) 
        {
		Card card = m_deck.GetCard();
		card.Show(show);
		a_player.DealCard(card);
	    }
    }
}
