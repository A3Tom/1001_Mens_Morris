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
using NMM_Logic.CLI.Solvers;

var solver = new MovingTileSolver();

var boardState = new BoardState(solver);

boardState.MoveTile(BoardPosition.Upper_Top_Left);
boardState.MoveTile(BoardPosition.Upper_Mid_Left);
boardState.MoveTile(BoardPosition.Upper_Top_Right);
boardState.MoveTile(BoardPosition.Upper_Mid_Right);

AsciiBoardDisplayer.OutputToCLI(boardState);

Console.ReadLine();
