using Battleship.Domain.Abstract.Rules;
using Battleship.Domain.Enums;
using System;
using System.Linq;

namespace Battleship.Domain.Rules
{
    /// <summary>
    /// Game rule that chooses a winner based on their fleet state.
    /// The player who's ships have all sunk loses. 
    /// If ships of both players have sunk the game ends in a draw.
    /// </summary>
    public class DefaultChooseWinnerRule : IChooseWinnerRule
    {
        public GameResult ChooseWinner(Game game)
        {
            var playerAAllSunk = game.PlayerA.Ships.All(x => x.Sunk);
            var playerBAllSunk = game.PlayerB.Ships.All(x => x.Sunk);

            if (playerAAllSunk && playerBAllSunk)
                return GameResult.Draw;

            if (playerAAllSunk)
                return GameResult.PlayerBWon;

            if (playerBAllSunk)
                return GameResult.PlayerAWon;

            throw new InvalidOperationException("Impossible to choose a winner.");
        }
    }
}
