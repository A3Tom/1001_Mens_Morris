using Godot;
using System.Linq;

public partial class board : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ResetBoard();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void UpdateTilesForCurrentPlayer(long player)
	{
		var tiles = GetNode<Godot.Node2D>("tiles")
			.GetChildren()
			.Select(tileNode => (Tile)tileNode);

		foreach (var tile in tiles)
			tile.CurrentPlayer = (int)player + 1;
	}

	private void ResetBoard()
	{
		var tiles = GetNode<Godot.Node2D>("tiles").GetChildren();

		foreach (var tile in tiles)
			tile.GetNode<AnimatedSprite2D>("tile/tile_sprite").Frame = 0;
	}
}
