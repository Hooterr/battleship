using Battleship.Domain.Abstract;
using System;

namespace Battleship.Domain
{
    public class RandomProvider : IRandomProvider
    {
        public Random Random { get; }
        public RandomProvider()
        {
            Random = new Random();
        }
    }
}
