namespace Battleship.Domain.Abstract.Rules
{
    /// <summary>
    /// A rule that checks if the game has ended.
    /// </summary>
    public interface IGameEndRule
    {
        /// <summary>
        /// Determines if the game has ended based on the game's state.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <returns><c>True</c> if the game has ended, otherwise <c>false</c>.</returns>
        bool HasEnded(Game game);
    }
}
