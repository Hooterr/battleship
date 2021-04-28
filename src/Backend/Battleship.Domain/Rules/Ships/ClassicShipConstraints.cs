using Battleship.Domain.Rules.Ships.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Domain.Rules.Ships
{
    /// <summary>
    /// Classic battle ships game constraints
    /// </summary>
    public class ClassicShipConstraints : IShipConstraints
    {
        private static List<ShipConstraint> _constraints = new()
        {
            new ShipConstraint(5, 1),
            new ShipConstraint(4, 2),
            new ShipConstraint(3, 3),
            new ShipConstraint(2, 4),
        };

        public IReadOnlyList<ShipConstraint> Constraints => _constraints;
    }
}
