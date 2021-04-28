import { GridCellState } from "./game-grid-cell-state.enum";

export interface GameGridCellModel {
    state: GridCellState,
    isOccupied: boolean,
}