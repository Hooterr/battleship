using Battleship.Domain.Enums;
using System;

namespace Battleship.Domain.Log
{
    /// <summary>
    /// Represents a message sent by the system.
    /// </summary>
    public class SystemAnnounceResultLogItem : GameLogItem
    {
        public const string PlayerWonMessage = "Player {0} won the game!";
        public const string DrawMessage = "Game ends in a draw.";

        public SystemAnnounceResultLogItem(GameResult result)
        {
            Source = GameLogItemSource.System;
            Message = result switch
            {
                GameResult.PlayerAWon => string.Format(PlayerWonMessage, "A"),
                GameResult.PlayerBWon => string.Format(PlayerWonMessage, "B"),
                GameResult.Draw => DrawMessage,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
