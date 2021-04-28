using Battleship.Domain.Enums;
using System;

namespace Battleship.Domain
{
    /// <summary>
    /// Represents single grid cell in the game.
    /// </summary>
    public class GameGridCell
    {
        /// <summary>
        /// The current state of the cell.
        /// </summary>
        public GridCellState State { get; private set; }
        
        /// <summary>
        /// The ship this cell is occupied by.
        /// </summary>
        public GameShip OccupiedBy { get; private set; }

        /// <summary>
        /// Checks if the cell is occupied by a ship.
        /// </summary>
        public bool IsOccupied => OccupiedBy != null;

        public GameGridCell()
        {
            State = GridCellState.Covered;
        }

        /// <summary>
        /// Places a ship onto the current cell.
        /// </summary>
        /// <param name="ship">The ship to be placed.</param>
        /// <exception cref="InvalidOperationException">Thrown if the cell is already occupied.</exception>
        public void PlaceShip(GameShip ship)
        {
            if (IsOccupied)
                throw new InvalidOperationException("This cell is already occupied");

            OccupiedBy = ship;
        }

        /// <summary>
        /// Shoots at this cell.
        /// </summary>
        /// <returns>The new state of the cell. Available also through <see cref="GameGridCell.State"/>.</returns>
        public GridCellState Shoot()
        {
            if (State != GridCellState.Covered)
                throw new InvalidOperationException("This cell has already been shot at.");

            if (IsOccupied)
            {
                State = GridCellState.Hit;
                OccupiedBy.Hit();
            }
            else
            {
                State = GridCellState.Miss;
            }

            return State;
        }
    }
}