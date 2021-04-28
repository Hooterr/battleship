using System;

namespace Battleship.Domain.Abstract
{
    /// <summary>
    /// Abstraction that provides random number generator to allow for unit testing.
    /// </summary>
    public interface IRandomProvider
    {
        /// <summary>
        /// Gets and instance of a random number generator.
        /// </summary>
        /// <value>Initialized random number generator.</value>
        public Random Random { get; }
    }
}
