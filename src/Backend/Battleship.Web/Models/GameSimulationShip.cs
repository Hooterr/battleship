using System.Text.Json.Serialization;

namespace Battleship.Web.Models
{
    public class GameSimulationShip
    {
        [JsonPropertyName("length")]
        public int Length { get; set; }
    }
}
