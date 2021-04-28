using Battleship.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.Domain
{
    /// <summary>
    /// Represents the battlefield grid.
    /// </summary>
    public class GameGrid
    {
        /// <summary>
        /// Gets the size of the board.
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// Gets all the ships on the board.
        /// </summary>
        public IReadOnlyList<GameShip> Ships { get; }
        
        /// <summary>
        /// Gets a cell at the given location.
        /// </summary>
        /// <param name="x">The X coordinate. 0 - far left.</param>
        /// <param name="y">The Y coordinate. 0 - bottom.</param>
        /// <returns>A cell at the given (x,y) location.</returns>
        public GameGridCell this[int x, int y]
        {
            get => _grid[x, y];
        }

        private readonly GameGridCell[,] _grid;

        public GameGrid(int size, List<GameShip> ships)
        {
            Size = size;
            _grid = new GameGridCell[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    _grid[i, j] = new GameGridCell();
                }
            }
            Ships = ships;
        }

        /// <summary>
        /// Places a ship at a given location
        /// </summary>
        /// <param name="ship">The ship to place. Must an instance from <see cref="Ships"/> collection.</param>
        /// <param name="startX">The X coordinate the ships far left cell for horizontal placement.</param>
        /// <param name="startX">The Y coordinate the ships far left cell for vertical placement.</param>
        /// <param name="vertical">If <c>true</c> the ship will be placed vertically, otherwise the ship will be placed horizontally.</param>
        public void PlaceShip(GameShip ship, int startX, int startY, bool vertical)
        {
            if (!Ships.Contains(ship))
                throw new ArgumentException("This ship doesn't belong to this board.", nameof(ship));
            
            // Vertical
            if (vertical)
            {
                for (int y = startY; y < startY + ship.Length; y++)
                {
                    _grid[startX, y].PlaceShip(ship);
                }
            }
            // Horizontal
            else
            {
                for (int x = startX; x < startX + ship.Length; x++)
                {
                    _grid[x, startY].PlaceShip(ship);
                }
            }
        }

        /// <summary>
        /// Performs a shooting operation at a given coordinates.
        /// </summary>
        /// <param name="x">X - coordinate.</param>
        /// <param name="y">Y - coordinate.</param>
        /// <returns><c>True</c> if the shoot is a hit. <c>False</c> if the shoot is a miss.</returns>
        public bool Shoot(int x, int y)
        {
            var cell = _grid[x, y];
            var result = cell.Shoot();
            return result == GridCellState.Hit;
        }
    }
}
