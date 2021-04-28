using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Domain.Enums
{
    /// <summary>
    /// Represents the source of a log item.
    /// </summary>
    public enum GameLogItemSource
    {
        /// <summary>
        /// Message triggered by player A.
        /// </summary>
        PlayerA,

        /// <summary>
        /// Message triggered by player B.
        /// </summary>
        PlayerB,

        /// <summary>
        /// System message.
        /// </summary>
        System = 99,
    }
}
