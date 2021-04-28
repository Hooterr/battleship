using System;

namespace Battleship.Domain.Rules.Ships.Abstract
{
    /// <summary>
    /// Represents a single ship type constraint for the game.
    /// </summary>
    public class ShipConstraint
    {
        /// <summary>
        /// The length of the ship
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// Number of ships of this type to be included in the game.
        /// </summary>
        public int Count { get; }

        public ShipConstraint(int length, int count)
        {
            if (length < 0)
                throw new ArgumentException($"Length cannot be less than 0. Value: {length}", nameof(length));

            if (count < 0)
                throw new ArgumentException($"Count cannot be less than 0. Value: {count}", nameof(count));

            Length = length;
            Count = count;
        }
    }
}
