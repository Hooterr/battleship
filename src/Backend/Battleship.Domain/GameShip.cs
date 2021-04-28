namespace Battleship.Domain
{
    /// <summary>
    /// Represents a ship in the game.
    /// </summary>
    public class GameShip
    {
        /// <summary>
        /// The length of the ship.
        /// </summary>
        public int Length { get; init; }

        /// <summary>
        /// Number of hits the ship has taken
        /// </summary>
        public int NumberOfHits { get; private set; }

        /// <summary>
        /// Indicates if the ship has sunk.
        /// </summary>
        public bool Sunk => Length == NumberOfHits;

        /// <summary>
        /// The ship has been hit!
        /// </summary>
        public void Hit()
        {
            NumberOfHits++;
        }
    }
}
