namespace Battleship.Domain.Abstract.Rules
{
    /// <summary>
    /// A rule that verifies if a player can perform a 'shoot' at a target cell.
    /// </summary>
    public interface IPlayerShootingRule
    {
        /// <summary>
        /// Checks if the player is allowed to shoot at a given coordinates.
        /// </summary>
        /// <param name="grid">The game grid.</param>
        /// <param name="x">X coordinate. 0 - far left.</param>
        /// <param name="y">Y coordinate. 0 - bottom.</param>
        /// <returns><c>True</c> if the player is allowed to shoot there, otherwise <c>false</c>.</returns>
        bool IsAllowed(GameGrid grid, int x, int y);
    }
}
