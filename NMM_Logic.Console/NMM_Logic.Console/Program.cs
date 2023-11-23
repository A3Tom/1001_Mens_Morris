/*
 
1 -------------- 2 --------------- 3
|                |                 |
|    4 --------- 5 ---------- 6    |
|    |           |            |    |
|    |    7 ---- 8 ---- 9     |    |
|    |    |             |     |    |
10-- 11-- 12            13-- 14-- 15
|    |    |             |     |    |
|    |    16 --- 17 --- 18    |    |
|    |           |            |    |
|    19 -------- 20 -------- 21    |
|                |                 |
22 ------------- 23 -------------- 24

*/

using NMM_Logic.CLI.Classes;
using NMM_Logic.Console.Classes;
using NMM_Logic.Console.Solvers;

var solver = new MovingTileSolver();

var boardState = new BoardState(solver);


var currentPositions = 
    BoardPosition.Upper_Top_Left | 
    BoardPosition.Upper_Top_Middle | 
    BoardPosition.Upper_Mid_Left | 
    BoardPosition.Upper_Mid_Right | 
    BoardPosition.Right_Mid_Far;

var destination = BoardPosition.Upper_Bottom_Right;

boardState.MoveTile(destination);

var hasTriggeredRemovalPhase = solver.HasTriggeredRemovalPhase(currentPositions, destination);


Console.WriteLine($"A cheeky wee slide tae {destination} has {(hasTriggeredRemovalPhase ? string.Empty : "Not ")}triggered a removal phase");