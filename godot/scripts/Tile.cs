using Godot;
using NMM_Logic.CLI.Classes;
using System.Linq;

public partial class Tile : Node2D
{
	[Signal]
	public delegate void TileSelectedEventHandler(int tileId);
	
	[Export]
	public int TileId { get; set; }
	public int CurrentPlayer { get; set; } = 1;

	private bool _isWithinBoundary = false;
	private int? _playerTile = null;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		//Main.SignalName.PlayerChanged += CurrentPlayerChanged;
	}

	public override void _Process(double delta)
	{
		if (_isWithinBoundary && Input.IsActionJustReleased("SelectTile"))
			SelectTile();
	}

	private void CurrentPlayerChanged(long player)
	{
		CurrentPlayer = (int)player;
	}

	private void SelectTile()
	{
		if (_playerTile == null)
		{
			_playerTile = CurrentPlayer;
			SetAnimationSpriteFrame(CurrentPlayer);
			EmitSignal(SignalName.TileSelected, TileId);
		}
	}

	private void OnMouseEntered()
	{
		_isWithinBoundary = true;

		if(_playerTile == null)
			SetAnimationSpriteFrame(CurrentPlayer);
	}
	private void OnMouseExit()
	{
		_isWithinBoundary = false;

		if (_playerTile == null)
			SetAnimationSpriteFrame(0);
	}

	private void SetAnimationSpriteFrame(int frame) => 
		GetNode<AnimatedSprite2D>($"tile/tile_sprite").Frame = frame;
}
