using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame
    {
        private model.Game game;
        private view.IView view;

        public bool Play(model.Game a_game, view.IView a_view)
        {
            view = a_view;
            game = a_game;

            view.DisplayWelcomeMessage();
            
            view.DisplayDealerHand(game.GetDealerHand(), game.GetDealerScore());
            view.DisplayPlayerHand(game.GetPlayerHand(), game.GetPlayerScore());

            if (game.IsGameOver())
            {
                view.DisplayGameOver(game.IsDealerWinner());
            }

            int input = view.GetInput();

            if (input == 'p')
            {
                game.NewGame();
            }
            else if (input == 'h')
            {
                game.Hit();
            }
            else if (input == 's')
            {
                game.Stand();
            }

            return input != 'q';
        }
    }
}
