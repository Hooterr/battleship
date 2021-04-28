using Battleship.Domain.Abstract.Builders;
using Battleship.Domain.Rules.Ships;
using Battleship.Domain.Rules.Ships.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.Domain.Builders
{
    /// <summary>
    /// Default game builder implementation
    /// </summary>
    public class GameBuilder : IGameBuilder
    {
        private readonly IShipRandomizer _shipRandomizer;

        private int _size;
        private IShipConstraints _shipConstraints;

        public GameBuilder(IShipRandomizer shipRandomizer)
        {
            _shipRandomizer = shipRandomizer;

            WithBoardSize(10);
            WithClassicShips();
        }

        public IGameBuilder WithBoardSize(int size)
        {
            if (size < 10)
                throw new ArgumentException($"Size of the board can't be less than 10. Supplied value was '{size}'.");

            _size = size;
            return this;
        }

        public IGameBuilder WithCustomShips()
        {
            _shipConstraints = new CustomShipConstraints();
            return this;
        }

        public IGameBuilder WithClassicShips()
        {
            _shipConstraints = new ClassicShipConstraints();
            return this;
        }

        public Game Build()
        {
            var shipSetA = GenerateShipsFromConstraints();
            var shipSetB = GenerateShipsFromConstraints();
            var game = new Game()
            {
                Size = _size,
                ShipConstraints = _shipConstraints,
                PlayerA = new(_size, shipSetA.ToList()),
                PlayerB = new(_size, shipSetB.ToList()),
            };

            _shipRandomizer.Randomize(game.PlayerA);
            _shipRandomizer.Randomize(game.PlayerB);

            return game;
        }

        private IEnumerable<GameShip> GenerateShipsFromConstraints()
        {
            foreach (var constraint in _shipConstraints.Constraints)
            {
                var count = constraint.Count;
                while (count-- > 0)
                {
                    yield return new GameShip()
                    {
                        Length = constraint.Length
                    };
                }
            }
        }
    }
}
