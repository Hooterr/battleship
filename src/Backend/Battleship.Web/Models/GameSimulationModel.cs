using Battleship.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Battleship.Web.Models
{
    public class GameSimulationModel
    {
        [JsonPropertyName("boardA")]
        public List<List<GameGridCellModel>> BoardA { get; set; }

        [JsonPropertyName("boardB")]
        public List<List<GameGridCellModel>> BoardB { get; set; }

        [JsonPropertyName("ships")]
        public List<GameSimulationShip> Ships { get; set; }

        [JsonPropertyName("moves")]
        public List<GameSimulationPlayerMove> PlayerMoves { get; set; }

        [JsonPropertyName("result")]
        public GameResult GameResult { get; set; }
    }
}
