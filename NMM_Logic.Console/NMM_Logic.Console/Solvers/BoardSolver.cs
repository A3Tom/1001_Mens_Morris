using NMM_Logic.CLI.Classes;

namespace NMM_Logic.CLI.Solvers;
internal abstract class BoardSolver
{
    internal abstract bool IsValidMove(IDictionary<Player, BoardPosition> playerPositions, BoardPosition destination, BoardPosition? sourceTile);
    internal abstract bool HasTriggeredRemovalPhase(BoardPosition playerCurrentPositions, BoardPosition destination);
    internal abstract bool IsValidRemoval(BoardPosition opponentCurrentPositions, BoardPosition chosenTile);
}
