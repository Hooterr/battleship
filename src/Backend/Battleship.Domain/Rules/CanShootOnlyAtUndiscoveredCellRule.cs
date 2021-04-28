using Battleship.Domain.Abstract.Rules;

namespace Battleship.Domain.Rules
{
    /// <summary>
    /// Game rule that check if the cell the player tries to shot at is a valid target.
    /// </summary>
    public class CanShootOnlyAtUndiscoveredCellRule : IPlayerShootingRule
    {
        public bool IsAllowed(GameGrid grid, int x, int y)
        {
            var allowed = grid[x, y].State == Enums.GridCellState.Covered;
            return allowed;
        }
    }
}
