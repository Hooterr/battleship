using Battleship.Domain.Abstract.Rules;
using System.Linq;

namespace Battleship.Domain.Rules
{
    /// <summary>
    /// Game ending rule that checks if there's a player whose ships have all sunk.
    /// </summary>
    public class AllShipsSunkGameEndRule : IGameEndRule
    {
        public bool HasEnded(Game game)
        {
            var allSunkPlayer1 = game.PlayerA.Ships.All(x => x.Sunk);
            var allSunkPlayer2 = game.PlayerB.Ships.All(x => x.Sunk);

            return allSunkPlayer1 || allSunkPlayer2;
        }
    }
}
