import { GameGridCellModel } from "./game-grid-cell.model";
import { GameResult as GameResultEnum } from "./game-result.enum";
import { GameSimulationPlayerMove } from "./game-simulation-player-mode.model";
import { GameSimulationShip } from "./game-simulation-ship.model";

export interface GameSimulationModel {
    boardA: GameGridCellModel[][],
    boardB: GameGridCellModel[][],
    ships: GameSimulationShip[],
    moves: GameSimulationPlayerMove[],
    gamerResult: GameResultEnum,
}