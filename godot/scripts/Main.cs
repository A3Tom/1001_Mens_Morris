using Godot;
using NMM_Logic.CLI.Classes;
using NMM_Logic.CLI.Solvers;

public partial class Main : Node
{
	[Signal]
	public delegate void PlayerChangedEventHandler(long player);

	public int CurrentPlayer => (int)_boardState.CurrentPlayer;

	private BoardState _boardState = new(new MovingTileSolver());

	public override void _Ready()
	{
	}

	private void OnTileSelected(long tileId)
	{
		GD.Print($"Main: Tile triggered: {tileId}");

		int hing = (int)tileId - 1;
		var tilePosition = (BoardPosition)(1 << hing);
		GD.Print(tilePosition);
		_boardState.MoveTile(tilePosition);
		
		EmitSignal(SignalName.PlayerChanged, (int)_boardState.CurrentPlayer);
	}

	public override void _Process(double delta)
	{
		GetNode<Label>("gamestate_panel/board_status/lbl_boardstatus").Text = _boardState.BoardId.ToString();
		GetNode<Label>("gamestate_panel/currentplayer/lbl_currentplayer").Text = _boardState.CurrentPlayer.ToString();
		GetNode<Label>("gamestate_panel/turn_count/lbl_turncount").Text = _boardState.TurnCount.ToString();
		GetNode<Label>("gamestate_panel/game_phase/lbl_gamephase").Text = _boardState.GamePhase.ToString();
	}
}
