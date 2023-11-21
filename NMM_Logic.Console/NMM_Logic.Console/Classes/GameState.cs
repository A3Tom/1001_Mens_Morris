namespace NMM_Logic.Console.Classes;
internal class GameState()
{
    public static Guid GameId => Guid.NewGuid();
    public IDictionary<Player, PlayerPhase> PlayerPhases { get; private set; } = new Dictionary<Player, PlayerPhase>()
    {
        { Player.White, PlayerPhase.Placement }, 
        { Player.Black, PlayerPhase.Placement }
    };
    public Player CurrentPlayerTurn { get; private set; } = Player.White;

    public BoardState BoardState { get; set; } = new();
}
