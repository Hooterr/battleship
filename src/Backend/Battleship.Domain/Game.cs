using Battleship.Domain.Rules.Ships.Abstract;

namespace Battleship.Domain
{
    /// <summary>
    /// Represents the game in the application.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Gets ship information for this game. How many of each type there are in this game.
        /// </summary>
        public IShipConstraints ShipConstraints { get; init; }

        /// <summary>
        /// Gets the board of player A.
        /// </summary>
        public GameGrid PlayerA { get; init; }

        /// <summary>
        /// Gets the board of player B.
        /// </summary>
        public GameGrid PlayerB { get; init; }

        /// <summary>
        /// Gets the size of the game board.
        /// </summary>
        /// <remarks>Common for both players.</remarks>
        public int Size { get; init; }

    }
}
