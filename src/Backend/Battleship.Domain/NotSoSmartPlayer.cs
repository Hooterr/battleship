using Battleship.Domain.Abstract;
using System;

namespace Battleship.Domain
{
    public class NotSoSmartPlayer : IPlayer
    {
        private readonly Random _rng;

        public NotSoSmartPlayer(IRandomProvider randomProvider)
        {
            _rng = randomProvider.Random;
        }

        public (int x, int y) ChooseTarget(GameGrid grid)
        {
            return (_rng.Next(0, grid.Size), _rng.Next(0, grid.Size));
        }
    }
}
