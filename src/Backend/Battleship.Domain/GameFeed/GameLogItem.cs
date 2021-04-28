using Battleship.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Domain.Log
{
    /// <summary>
    /// Represents a single game log entry.
    /// </summary>
    public abstract class GameLogItem
    {
        /// <summary>
        /// The message of the item.
        /// </summary>
        public string Message { get; init; }

        /// <summary>
        /// The source of the message.
        /// </summary>
        public GameLogItemSource Source { get; init; }
    }
}
