using Battleship.Domain.Enums;
using System.Text.Json.Serialization;

namespace Battleship.Web.Models
{
    public class GameSimulationPlayerMove
    {
        [JsonPropertyName("source")]
        public GameLogItemSource Source { get; set; }

        [JsonPropertyName("x")]
        public int X { get; set; }
        
        [JsonPropertyName("y")]
        public int Y { get; set; }

        [JsonPropertyName("message")]
        public string Messgae { get; set; }
    }
}
