import { GameLogItemSource } from "./game-log-item-source";

export interface GameSimulationPlayerMove {
    source: GameLogItemSource,
    x: number,
    y: number,
    message: string,
}