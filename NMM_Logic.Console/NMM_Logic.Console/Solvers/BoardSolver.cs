using NMM_Logic.Console.Classes;

namespace NMM_Logic.Console.Solvers;
internal abstract class BoardSolver
{
    internal abstract bool IsValidMove(BoardState boardState, BoardPosition destination);
    internal abstract bool MoveTile(BoardState board, BoardPosition source, BoardPosition destination);
    internal abstract bool HasTriggeredRemovalPhase(BoardPosition currentPositions, BoardPosition destination);
}
