import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, ElementRef, Inject, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { CreateGameModel } from '../models/create-game.mode';
import { GridCellState } from '../models/game-grid-cell-state.enum';
import { GameLogItemSource } from '../models/game-log-item-source';
import { GameResult } from '../models/game-result.enum';
import { GameSimulationModel } from '../models/game-simulation.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, AfterViewInit {
  @ViewChild('scroll', {static: false}) private scrollFrame: ElementRef;
  @ViewChildren('item') itemElements: QueryList<any>;
  
  private readonly http: HttpClient;
  private readonly baseUrl: string;
  private scrollContainer: any;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }
  ngAfterViewInit(): void {
    this.scrollContainer = this.scrollFrame.nativeElement;  
    this.itemElements.changes.subscribe(_ => this.onItemElementsChanged());   
  }

  cellState = GridCellState;

  ngOnInit(): void {
    
  }

  size: number = 10;
  stringRef = String;
  game: GameSimulationModel;
  playing: boolean;
  currentMove: number;
  timer;
  logs: string[];

  play_pause(): void {

    if (this.playing) {
      clearInterval(this.timer);
      this.playing = false;
      return;
    }

    this.playing = true;
    this.timer = setInterval(() => {

      const move = this.game.moves[this.currentMove]
      switch (move.source) {
        case GameLogItemSource.PlayerA:
          {
            const cell = this.game.boardB[move.x][move.y];
            cell.state = cell.isOccupied ? GridCellState.Hit : GridCellState.Miss;
            break;
          }
        case GameLogItemSource.PlayerB:
          {
            const cell = this.game.boardA[move.x][move.y];
            cell.state = cell.isOccupied ? GridCellState.Hit : GridCellState.Miss;
            break;
          }
        default:
          break;
      }
      this.logs.push(move.message);
      this.currentMove++;
      if (this.currentMove >= this.game.moves.length) {
        if (this.game.gamerResult !== GameResult.Draw)
        {
          this.logs.push(`Player ${this.game.gamerResult == GameResult.PlayerAWon ? 'A': 'B'} won the game!.`)
        }
        else {
          this.logs.push('Game ends in a draw.');
        }
        clearInterval(this.timer);
      }

    }, 200);
  }

  newGame(): void {
    clearInterval(this.timer);
    this.logs = [];
    this.playing = false
    this.currentMove = 0;
    const body: CreateGameModel = {
      size: this.size,
    }
    this.http.post<GameSimulationModel>(this.baseUrl + 'game/new', body).subscribe(result => {
      console.log(result);
      this.game = result;
    }, error => console.error(error));
  }
 
  private onItemElementsChanged(): void {
    this.scrollToBottom();
  }

  private scrollToBottom(): void {
    this.scrollContainer.scroll({
      top: this.scrollContainer.scrollHeight,
      left: 0,
      duration: 0,
    });
  }
}
