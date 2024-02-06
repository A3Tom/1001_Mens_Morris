using NMM_Logic.CLI.Classes;
using System.Collections.Generic;

namespace NMM_Logic.CLI.Solvers;
public abstract class BoardSolver
{
	internal abstract bool IsValidMove(IDictionary<Player, BoardPosition> playerPositions, BoardPosition destination, BoardPosition? sourceTile);
	internal abstract bool HasTriggeredRemovalPhase(BoardPosition playerCurrentPositions, BoardPosition destination);
	internal abstract bool IsValidRemoval(BoardPosition opponentCurrentPositions, BoardPosition chosenTile);
}
