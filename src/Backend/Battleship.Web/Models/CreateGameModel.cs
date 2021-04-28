using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Battleship.Web.Models
{
    public class CreateGameModel
    {
        [JsonPropertyName("size")]
        public int Size { get; set; }
    }
}
