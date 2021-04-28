namespace Battleship.Domain.Abstract.Builders
{
    /// <summary>
    /// Enables easy game generation.
    /// </summary>
    public interface IGameBuilder
    {
        /// <summary>
        /// Creates a new game with the current settings.
        /// </summary>
        /// <returns>A brand new instance of the game ready to be used.</returns>
        Game Build();

        /// <summary>
        /// Sets the board to be a square with a given size.
        /// </summary>
        /// <param name="size">The size of the board.</param>
        /// <returns>The instance of the builder for chaining.</returns>
        IGameBuilder WithBoardSize(int size);

        /// <summary>
        /// Enables classic variant of ship types.
        /// </summary>
        /// <returns>The instance of the builder for chaining.</returns>
        /// <returns></returns>
        IGameBuilder WithClassicShips();

        /// <summary>
        /// Enables custom variant of ship types.
        /// </summary>
        /// <returns>The instance of the builder for chaining.</returns>
        IGameBuilder WithCustomShips();
    }
}