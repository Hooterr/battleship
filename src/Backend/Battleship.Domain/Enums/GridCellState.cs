namespace Battleship.Domain.Enums
{
    /// <summary>
    /// Represents a state of a single grid cell.
    /// </summary>
    public enum GridCellState
    {
        /// <summary>
        /// The cell has been shot at and missed.
        /// </summary>
        Miss,

        /// <summary>
        /// The cell contains a ship and has been hit.
        /// </summary>
        Hit,

        /// <summary>
        /// The cell is still covered. It hasn't been shot at yet and it may contain a ship.
        /// </summary>
        Covered,
    }
}
