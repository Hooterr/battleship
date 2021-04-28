namespace Battleship.Domain.Abstract.Builders
{
    /// <summary>
    /// Randomly places the ships on the board
    /// </summary>
    public interface IShipRandomizer
    {
        /// <summary>
        /// Randomize ship placement on the game grid.
        /// </summary>
        /// <param name="grid">The game grid to randomize.</param>
        void Randomize(GameGrid grid);
    }
}
