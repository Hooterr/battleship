using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Domain
{
    /// <summary>
    /// Represents a player and their actions in game.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Asks the player to choose a target to shoot at.
        /// </summary>
        /// <param name="gird">The game grid.</param>
        /// <returns>The coordinates choosen by the player to shoot at.</returns>
        (int x, int y) ChooseTarget(GameGrid gird);
    }
}
