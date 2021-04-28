using Battleship.Domain.Enums;

namespace Battleship.Domain.Abstract.Rules
{
    /// <summary>
    /// A rule that chooses the game winner.
    /// </summary>
    public interface IChooseWinnerRule
    {
        /// <summary>
        /// Chooses the winner of the game based on current game state.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <returns>The result of the game.</returns>
        GameResult ChooseWinner(Game game);
    }
}
