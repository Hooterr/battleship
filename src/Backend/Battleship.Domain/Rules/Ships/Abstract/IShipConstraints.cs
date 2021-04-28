using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Domain.Rules.Ships.Abstract
{
    /// <summary>
    /// Represents a ship count and type constraint for the game.
    /// </summary>
    public interface IShipConstraints
    {
        /// <summary>
        /// The list of ship constraints for the game.
        /// </summary>
        IReadOnlyList<ShipConstraint> Constraints { get; }
    }
}
