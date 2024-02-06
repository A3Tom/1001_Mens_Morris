using NMM_Logic.CLI.Extensions;
using NMM_Logic.CLI.Solvers;
using System;
using System.Collections.Generic;

namespace NMM_Logic.CLI.Classes;

public class BoardState
{
	public BoardState(BoardSolver solver)
	{
		BoardId = Guid.NewGuid();
		_solver = solver;
	}

	public readonly Guid BoardId;

	public IDictionary<Player, BoardPosition> PlayerPositions { get; private set; } =
		new Dictionary<Player, BoardPosition>()
	{
		{ Player.White, BoardPosition.None },
		{ Player.Black, BoardPosition.None }
	};
	public GamePhase GamePhase => CalculateCurrentGamePhase();

	public int TurnCount { get; private set; } = 0;
	public Player CurrentPlayer => TurnCount % 2 == 0 ? Player.White : Player.Black;
	public Player AwaitingPlayer => CurrentPlayer != Player.White ? Player.White : Player.Black;

	private bool _removalPhaseTriggered;

	private readonly BoardSolver _solver;

	public void MoveTile(BoardPosition destination, BoardPosition? sourceTile = null)
	{
		if (!_solver.IsValidMove(PlayerPositions, destination, sourceTile))
			return; // TODO: Maybe have some feedback lol ... this is shite like this

		PlayerPositions[CurrentPlayer] |= destination;

		if (_solver.HasTriggeredRemovalPhase(PlayerPositions[CurrentPlayer], destination))
		{
			_removalPhaseTriggered = true;
			return;
		}

		TurnCount++;
	}

	public void RemoveTile(BoardPosition chosenTile)
	{
		if (!_solver.IsValidRemoval(PlayerPositions[AwaitingPlayer], chosenTile))
			return;

		PlayerPositions[AwaitingPlayer] ^= chosenTile;

		_removalPhaseTriggered = false;
		TurnCount++;
	}

	private GamePhase CalculateCurrentGamePhase()
	{
		if (_removalPhaseTriggered)
			return GamePhase.Removal;

		if (TurnCount <= 18)
			return GamePhase.Placement;

		var whiteTilesRemaning = ((int)PlayerPositions[Player.White]).GetSetFlagCount();
		var blackTilesRemaining = ((int)PlayerPositions[Player.Black]).GetSetFlagCount();

		if (whiteTilesRemaning == 3 || blackTilesRemaining == 3)
			return GamePhase.EndGame;

		if (whiteTilesRemaning < 3 || blackTilesRemaining < 3)
			return GamePhase.Concluded;

		return GamePhase.Movement;
	}
}
