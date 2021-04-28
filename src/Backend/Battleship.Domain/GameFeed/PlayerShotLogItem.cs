using Battleship.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Domain.Log
{
    /// <summary>
    /// Represents a message when the players shoots at a cell.
    /// </summary>
    public class PlayerShotLogItem : GameLogItem
    {
        private const string PlayerChoiceGameMessage = "Player{0} shoots at {1}{2}!";

        /// <summary>
        /// X position that the player shot at.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y position that the player shot at.
        /// </summary>
        public int Y { get; set; }

        public PlayerShotLogItem(PlayersEnum player, int x, int y)
        {
            var symbol = player == PlayersEnum.PlayerA ? "A" : "B";
            Source = player == PlayersEnum.PlayerA ? GameLogItemSource.PlayerA : GameLogItemSource.PlayerB;
            Message = string.Format(PlayerChoiceGameMessage, symbol, NumToBoardLetter(x), y);
            X = x;
            Y = y;
        }

        private static char NumToBoardLetter(int number)
        {
            return (char)(number + 'A');
        }
    }
}
