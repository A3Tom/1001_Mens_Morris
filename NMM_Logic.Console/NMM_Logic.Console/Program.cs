/*****************
 * 0-----0-----0
 * --0---0---0--
 * ----0-0-0----
 * 0-0-0---0-0-0
 * ----0-0-0----
 * --0---0---0--
 * 0-----0-----0
 *****************/

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

var destination = BoardPosition.Upper_Top_Right;

var hasTriggeredRemovalPhase = solver.HasTriggeredRemovalPhase(currentPositions, destination);


Console.WriteLine($"A cheeky wee slide tae {destination} has {(hasTriggeredRemovalPhase ? string.Empty : "Not ")}triggered a removal phase");