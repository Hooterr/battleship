using Battleship.Domain.Enums;
using System.Text.Json.Serialization;

namespace Battleship.Web.Models
{
    public class GameGridCellModel
    {
        [JsonPropertyName("state")]
        public GridCellState State { get; set; }

        [JsonPropertyName("isOccupied")]
        public bool IsOccupied { get; set; }
    }
}
