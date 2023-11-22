using NMM_Logic.Console.Extensions;
using NMM_Logic.Console.Solvers;

namespace NMM_Logic.Console.Classes;

internal class BoardState(BoardSolver solver)
{
    public static Guid BoardId => Guid.NewGuid();

    public IDictionary<Player, BoardPosition> PlayerPositions { get; private set; } = 
        new Dictionary<Player, BoardPosition>()
    {
        { Player.White, BoardPosition.None },
        { Player.Black, BoardPosition.None }
    };
    public GamePhase GamePhase => CalculateCurrentGamePhase();

    public int TurnCount { get; private set; } = 0;
    public Player CurrentPlayer => TurnCount % 2 == 0 ? Player.White : Player.Black;
    private Player _awaitingPlayer => CurrentPlayer != Player.White ? Player.White : Player.Black;

    private bool _removalPhaseTriggered;

    public void MoveTile(BoardPosition destination, BoardPosition? sourceTile = null)
    {
        if (!solver.IsValidMove(PlayerPositions, destination, sourceTile))
            return; // TODO: Maybe have some feedback lol ... this is shite like this

        PlayerPositions[CurrentPlayer] |= destination;

        if (solver.HasTriggeredRemovalPhase(PlayerPositions[CurrentPlayer], destination))
        {
            _removalPhaseTriggered = true;
            return;
        }

        TurnCount++;
    }

    public void RemoveTile(BoardPosition chosenTile)
    {
        if (!solver.IsValidRemoval(PlayerPositions[_awaitingPlayer], chosenTile))
            return;

        PlayerPositions[_awaitingPlayer] ^= chosenTile;

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
