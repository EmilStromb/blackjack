using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BlackJack.model;


namespace BlackJack.controller
{
    class PlayGame : model.Observer
    {
        private model.Game m_game;
        private view.IView m_view;

        public bool Play(model.Game a_game, view.IView a_view)
        {
            m_view = a_view;
            m_game = a_game;

            m_view.DisplayWelcomeMessage();

            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());

            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
            }

            view.MenuEnums input = m_view.GetInput();

            if (view.MenuEnums.PLAY.Equals(input))
            {
                m_game.NewGame(this);
            }
            else if (view.MenuEnums.HIT.Equals(input))
            {
                m_game.Hit();
            }
            else if (view.MenuEnums.STAND.Equals(input))
            {
                m_game.Stand();
            }

            return !view.MenuEnums.QUIT.Equals(input);
        }
        public void observ()
        {
            Thread.Sleep(500);
            m_view.DisplayWelcomeMessage();
            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());
            Thread.Sleep(500);
        }
    }
}
