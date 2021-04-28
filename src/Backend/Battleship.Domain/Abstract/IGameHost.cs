using Battleship.Domain.Enums;
using Battleship.Domain.Log;
using System.Collections.Generic;

namespace Battleship.Domain.Abstract
{
    /// <summary>
    /// Represents a game host that can host a given game.
    /// </summary>
    public interface IGameHost
    {
        /// <summary>
        /// The game being hosted
        /// </summary>
        Game Game { get; }

        /// <summary>
        /// The list of all players moves.
        /// </summary>
        IReadOnlyList<PlayerShotLogItem> PlayerMoves { get; }

        /// <summary>
        /// Gets the result of the simulate game.
        /// </summary>
        /// <value>The result of the last simulated game or default value if no game's have been simulated 
        /// by this host yet.</value>
        GameResult GameResult { get; }

        /// <summary>
        /// Sets a new game to be hosted.
        /// </summary>
        /// <param name="game">The game to be hosted.</param>
        void Host(Game game);

        /// <summary>
        /// Simulates the current <see cref="Game"/>
        /// </summary>
        void Simulate();
    }
}