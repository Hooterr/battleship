using Battleship.Domain.Rules.Ships.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Domain.Rules.Ships
{
    /// <summary>
    /// Custom constraints to demonstrate the point.
    /// </summary>
    public class CustomShipConstraints : IShipConstraints
    {
        private static List<ShipConstraint> _constraints = new()
        {
            new ShipConstraint(5, 1),
            new ShipConstraint(3, 2),
            new ShipConstraint(1, 2),
        };

        public IReadOnlyList<ShipConstraint> Constraints => _constraints;
    }
}
