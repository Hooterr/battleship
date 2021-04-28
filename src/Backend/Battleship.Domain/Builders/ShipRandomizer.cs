using Battleship.Domain.Abstract;
using Battleship.Domain.Abstract.Builders;
using System;

namespace Battleship.Domain.Builders
{
    /// <summary>
    /// Default ship randomizer implementation
    /// </summary>
    public class ShipRandomizer : IShipRandomizer
    {
        private readonly Random _rng;

        public ShipRandomizer(IRandomProvider randomProvider)
        {
            _rng = randomProvider.Random;
        }

        public void Randomize(GameGrid grid)
        {
            // Generate placement
            foreach (var ship in grid.Ships)
            {
                var shipPlaced = false;
                var attempts = 0;
                // Try to place the ship until it fits
                while (!shipPlaced)
                {
                    var vertical = _rng.NextDouble() > 0.5;
                    int posX, posY;

                    // Generate random starting point for the ship. 
                    // PosX and PosY describe far left point of the ship in horizontal mode
                    // or bottom point of the ship in vertical mode

                    // Adjust for boundaries of the board
                    if (vertical)
                    {
                        posX = _rng.Next(0, grid.Size);
                        posY = _rng.Next(0, grid.Size - ship.Length + 1);
                    }
                    // Horizontal
                    else
                    {
                        posX = _rng.Next(0, grid.Size - ship.Length + 1);
                        posY = _rng.Next(0, grid.Size);
                    }

                    // Check if the ship can be placed in this location
                    // Also check if there's padding of 1 around the ship
                    var fits = true;

                    if (vertical)
                    {
                        for (int y = posY; y < posY + ship.Length; y++)
                        {
                            // If already occupied
                            if (grid[posX, y].IsOccupied)
                            {
                                fits = false;
                            }

                            // Check one to the right
                            if (posX + 1 < grid.Size)
                            {
                                if (grid[posX + 1, y].IsOccupied)
                                {
                                    fits = false;
                                }
                            }

                            // Check one to the left
                            if (posX > 0)
                            {
                                if (grid[posX - 1, y].IsOccupied)
                                {
                                    fits = false;
                                }
                            }
                        }

                        // Check one below
                        if (posY > 0)
                        {
                            if (grid[posX, posY - 1].IsOccupied)
                            {
                                fits = false;
                            }
                        }

                        // Check one above
                        if (posY + ship.Length < grid.Size)
                        {
                            if (grid[posX, posY + ship.Length].IsOccupied)
                            {
                                fits = false;
                            }
                        }

                    }
                    // Horizontal
                    else
                    {
                        for (int x = posX; x < posX + ship.Length; x++)
                        {
                            // If already occupied
                            if (grid[x, posY].IsOccupied)
                            {
                                fits = false;
                            }

                            // Check one to the top
                            if (posY + 1 < grid.Size)
                            {
                                if (grid[x, posY + 1].IsOccupied)
                                {
                                    fits = false;
                                }
                            }

                            // Check one to the bottom
                            if (posY > 0)
                            {
                                if (grid[x, posY - 1].IsOccupied)
                                {
                                    fits = false;
                                }
                            }
                        }

                        // Check one to the right
                        if (posX + ship.Length< grid.Size)
                        {
                            if (grid[posX + ship.Length, posY].IsOccupied)
                            {
                                fits = false;
                            }
                        }

                        // Check one to the left
                        if (posX > 0)
                        {
                            if (grid[posX - 1, posY].IsOccupied)
                            {
                                fits = false;
                            }
                        }
                    }

                    attempts++;

                    // This is a dumb algorithm to generate game boards. Sometimes it put itself in a position that 
                    // it can't place all the ships with the correct margins.
                    if (attempts > 100)
                        throw new Exception(@"¯\_(ツ)_/¯");

                    // If it doesn't fit try again
                    if (!fits)
                        continue;

                    grid.PlaceShip(ship, posX, posY, vertical);

                    shipPlaced = true;

                }
            }

        }
    }
}
