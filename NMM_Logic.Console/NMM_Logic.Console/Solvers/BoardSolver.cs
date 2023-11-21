using NMM_Logic.Console.Classes;

namespace NMM_Logic.Console.Solvers;
internal abstract class BoardSolver
{
    internal abstract bool IsValidMove(BoardState boardState, byte[] destination);
    internal abstract bool MoveTile(BoardState board, byte[] source, byte[] destination);
    internal abstract bool HasTriggeredRemovalPhase(byte[] destination);
}
